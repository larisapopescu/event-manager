using System.Runtime.InteropServices.JavaScript;

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
    
    public List<TicketType> OptiuniTichete { get; set; } = new List<TicketType>();
    [JsonConstructor]
    public Event(string EventName, string EventDescription, string EventLocation, string EventStatus, DateTime EventDate,
        int EventCapacity, List<TicketType> OptiuniTichete)
    {
        this.EventName = EventName;
        this.EventDescription = EventDescription;
        this.EventLocation = EventLocation;
        this.EventStatus = EventStatus;
        this.EventDate = EventDate;
        this.EventCapacity = EventCapacity;
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
            throw new Exception("Event Capacity exceeded");
        }
        //Initialize a new ticket category
        TicketType newTier=new TicketType(categoryName, ticketPrice, quantity);
        //add the new category to the event's ticket options
        OptiuniTichete.Add(newTier);
    }

    public void UpdateDetails(string NewName, string NewDescription, string NewLocation, DateTime NewDate,
        int NewCapacity)
    {
        int currentlyPlanned = 0;
        foreach (var t in OptiuniTichete)
        {
            currentlyPlanned=currentlyPlanned+t.MaxQuantity;
        }
        if(NewCapacity < currentlyPlanned)
        {
            throw new Exception($"Cannot reduce capacity to {NewCapacity} you already have {currentlyPlanned} tickets allocated");
        }
        
        if(!string.IsNullOrEmpty(NewName)) EventName = NewName;
        if(!string.IsNullOrEmpty(NewDescription)) EventDescription = NewDescription;
        if(!string.IsNullOrEmpty(NewLocation))EventLocation = NewLocation;
        EventCapacity = NewCapacity;
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
        EventStatus = "Modified";
    }
}