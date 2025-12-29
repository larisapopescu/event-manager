namespace mainfile;
using System.Text.Json.Serialization;
public class Event
{
    public string EventName { get;private set; }
    public string EventDescription { get;private set; }
    public string EventLocation { get;private set; }
    public string EventStatus { get; set; } // scheduled, modified or canceled
    public DateTime EventDate { get;private set; }
    public int EventCapacity { get;private set; }
    
    public List<TicketType> OptiuniTichete = new List<TicketType>();
    [JsonConstructor]
    public Event(string eventName, string eventDescription, string eventLocation, string eventStatus, DateTime eventDate,
        int eventCapacity, List<TicketType> OptiuniTichete)
    {
        this.EventName = eventName;
        this.EventDescription = eventDescription;
        this.EventLocation = eventLocation;
        this.EventStatus = eventStatus;
        this.EventDate = eventDate;
        this.EventCapacity = eventCapacity;
        this.OptiuniTichete = OptiuniTichete ?? new List<TicketType>();
    }

    public void AddTicketType(string categoryName, decimal ticketPrice, int quantity)
    {
        // Calculate the total number of tickets already allocated across all categories
        int currentlyPlanned = 0;
        foreach (var t in OptiuniTichete)
        {
            currentlyPlanned = currentlyPlanned + t.MaxQuantity;
        }
        
        //verify that adding this new category won't exceed the event capacity
        if (currentlyPlanned + quantity > EventCapacity)
        {
            throw new Exception("EventCapacity exceeded");
        }
        //Initialize a new ticket category
        TicketType newTier=new TicketType(categoryName, ticketPrice, quantity);
        //add the new category to the event s ticket options
        OptiuniTichete.Add(newTier);
    }
}