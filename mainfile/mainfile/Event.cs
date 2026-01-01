using System.Runtime.InteropServices.JavaScript;

namespace mainfile;
using System.Text.Json.Serialization;

public class Event
{
    // Proprietăți setate ca private set pentru a proteja datele (încapsulare)
    public string EventName { get;private set; }
    public string EventDescription { get;private set; }
    public string EventLocation { get;private set; }
    public string EventStatus { get; set; } // Starea: scheduled, modified, canceled
    public DateTime EventDate { get;private set; }
    public int EventCapacity { get;private set; }
    public string OrganizerUsername { get; private set; }

    
    // Lista cu tipurile de bilete disponibile (VIP, Standard)
    [JsonPropertyName("OptiuniTichete")]
    public List<TicketType> OptiuniTichete { get; set; } = new List<TicketType>();
    public Event(string EventName, string EventDescription, string EventLocation, string EventStatus, DateTime EventDate,
        int EventCapacity, List<TicketType> OptiuniTichete,string OrganizerUsername)
    {
        this.EventName = EventName;
        this.EventDescription = EventDescription;
        this.EventLocation = EventLocation;
        this.EventStatus = EventStatus;
        this.EventDate = EventDate;
        this.EventCapacity = EventCapacity;
        this.OptiuniTichete = OptiuniTichete ?? new List<TicketType>();
        this.OrganizerUsername = OrganizerUsername;
    }

    // Adaugă o categorie nouă de bilete cu validare de capacitate
    public void AddTicketType(string categoryName, decimal ticketPrice, int quantity)
    {
        // 1. Calculăm câte bilete sunt deja planificate
        int currentlyPlanned = 0;
        foreach (var t in OptiuniTichete)
        {
            currentlyPlanned = currentlyPlanned + t.MaxQuantity;
        }
        
        // 2. Verificăm dacă adăugarea noii cantități depășește capacitatea sălii
        if (currentlyPlanned + quantity > EventCapacity)
        {
            throw new Exception("Event Capacity exceeded");
        }
        
        // 3. Creăm și adăugăm noul tip de bilet
        TicketType newTier=new TicketType(categoryName, ticketPrice, quantity);
        OptiuniTichete.Add(newTier);
    }

    // Actualizează detaliile evenimentului cu validări stricte
    public void UpdateDetails(string NewName, string NewDescription, string NewLocation, DateTime NewDate,
        int NewCapacity)
    {
        // Verificăm dacă noua capacitate este suficientă pentru biletele deja create
        int currentlyPlanned = 0;
        foreach (var t in OptiuniTichete)
        {
            currentlyPlanned=currentlyPlanned+t.MaxQuantity;
        }
        if(NewCapacity < currentlyPlanned)
        {
            throw new Exception($"Cannot reduce capacity to {NewCapacity} you already have {currentlyPlanned} tickets allocated");
        }
        
        // Actualizăm câmpurile doar dacă nu sunt goale
        if(!string.IsNullOrEmpty(NewName)) EventName = NewName;
        if(!string.IsNullOrEmpty(NewDescription)) EventDescription = NewDescription;
        if(!string.IsNullOrEmpty(NewLocation))EventLocation = NewLocation;
        EventCapacity = NewCapacity;
        
        // Validare dată: Nu putem muta evenimentul în trecut
        if (NewDate > DateTime.MinValue)
        {
            if (NewDate < DateTime.Now)
            {
                throw new Exception("Event Date is in the past");
            }
            else
            {
                EventDate = NewDate;
            }
        }
        // Dacă se fac modificări, statusul devine automat "Modified"
        EventStatus = "Modified";
    }
}