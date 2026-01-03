using System.Runtime.InteropServices.JavaScript;

namespace mainfile;
using System.Text.Json.Serialization;

public class Event
{
    private ILogger logger = new ConsoleLogger();

    // Proprietăți setate ca private set pentru a proteja datele (încapsulare)
    public string EventName { get; private set; }
    public string EventDescription { get; private set; }
    public string EventLocation { get; private set; }
    public string EventStatus { get; set; } // Starea: scheduled, modified, canceled
    public DateTime EventDate { get; private set; }
    public int EventCapacity { get; private set; }
    public string OrganizerUsername { get; private set; }

    // Lista cu tipurile de bilete disponibile (VIP, Standard)
    [JsonPropertyName("OptiuniTichete")]
    public List<TicketType> OptiuniTichete { get; set; } = new List<TicketType>();

    // NU schimbam constructorul existent
    protected Event(
        string EventName,
        string EventDescription,
        string EventLocation,
        string EventStatus,
        DateTime EventDate,
        int EventCapacity,
        List<TicketType> OptiuniTichete,
        string OrganizerUsername)
    {
        this.EventName = EventName;
        this.EventDescription = EventDescription;
        this.EventLocation = EventLocation;
        this.EventStatus = EventStatus;
        this.EventDate = EventDate;
        this.EventCapacity = EventCapacity;
        this.OptiuniTichete = OptiuniTichete ?? new List<TicketType>();
        this.OrganizerUsername = OrganizerUsername;

        //logger.Info($"Event created: {EventName} by {OrganizerUsername}");
    }

    // Optional: permite setarea loggerului din exterior
    public void SetLogger(ILogger logger)
    {
        if (logger != null)
        {
            this.logger = logger;
        }
    }

    // Adaugă o categorie nouă de bilete cu validare de capacitate
    public void AddTicketType(string categoryName, decimal ticketPrice, int quantity)
    {
        logger.Info($"Trying to add ticket type {categoryName} with quantity {quantity} to event {EventName}");

        // 1. Calculăm câte bilete sunt deja planificate
        int currentlyPlanned = 0;
        foreach (var t in OptiuniTichete)
        {
            currentlyPlanned = currentlyPlanned + t.MaxQuantity;
        }

        // 2. Verificăm dacă adăugarea noii cantități depășește capacitatea sălii
        if (currentlyPlanned + quantity > EventCapacity)
        {
            logger.Error("Event capacity exceeded while adding ticket type");
            throw new Exception("Event Capacity exceeded");
        }

        // 3. Creăm și adăugăm noul tip de bilet
        TicketType newTier = new TicketType(categoryName, ticketPrice, quantity);
        OptiuniTichete.Add(newTier);

        logger.Info($"Ticket type {categoryName} added successfully to event {EventName}");
    }

    // Actualizează detaliile evenimentului cu validări stricte
    public void UpdateDetails(
        string NewName,
        string NewDescription,
        string NewLocation,
        DateTime NewDate,
        int NewCapacity)
    {
        logger.Info($"Updating event details for {EventName}");

        // Verificăm dacă noua capacitate este suficientă pentru biletele deja create
        int currentlyPlanned = 0;
        foreach (var t in OptiuniTichete)
        {
            currentlyPlanned = currentlyPlanned + t.MaxQuantity;
        }

        if (NewCapacity < currentlyPlanned)
        {
            logger.Error("Cannot reduce event capacity below already allocated tickets");
            throw new Exception($"Cannot reduce capacity to {NewCapacity} you already have {currentlyPlanned} tickets allocated");
        }

        // Actualizăm câmpurile doar dacă nu sunt goale
        if (!string.IsNullOrEmpty(NewName)) EventName = NewName;
        if (!string.IsNullOrEmpty(NewDescription)) EventDescription = NewDescription;
        if (!string.IsNullOrEmpty(NewLocation)) EventLocation = NewLocation;

        EventCapacity = NewCapacity;

        // Validare dată: Nu putem muta evenimentul în trecut
        if (NewDate > DateTime.MinValue)
        {
            if (NewDate < DateTime.Now)
            {
                logger.Error("Attempted to set event date in the past");
                throw new Exception("Event Date is in the past");
            }
            else
            {
                EventDate = NewDate;
            }
        }

        // Dacă se fac modificări, statusul devine automat "Modified"
        EventStatus = "Modified";

        logger.Info($"Event {EventName} updated successfully");
    }
}
