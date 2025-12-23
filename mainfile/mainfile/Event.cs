namespace mainfile;

public class Event
{
    public string EventName { get;private set; }
    public string EventDescription { get;private set; }
    public string EventLocation { get;private set; }
    public string Status { get; set; } // scheduled, modified or canceled
    public DateTime EventDate { get;private set; }
    public int EventCapacity { get;private set; }

    public Event(string EventName, string EventDescription, string EventLocation, string Status, DateTime EventDate,
        int EventCapacity)
    {
        this.EventName = EventName;
        this.EventDescription = EventDescription;
        this.EventLocation = EventLocation;
        this.Status = Status;
        this.EventDate = EventDate;
        this.EventCapacity = EventCapacity;
    }
}