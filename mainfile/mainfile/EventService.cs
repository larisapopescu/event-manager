using Microsoft.Extensions.Logging;

namespace mainfile;

public class EventService
{
    private readonly List<Event> _events = new();
    private readonly ILogger<EventService> _logger;

    public EventService(ILogger<EventService> logger)
    {
        _logger = logger;
    }

    // 🔹 DOAR citire din exterior
    public IReadOnlyList<Event> GetAllEvents()
    {
        return _events.AsReadOnly();
    }

    // 🔹 Creare eveniment
    public void CreateEvent(
        string name,
        string description,
        string location,
        DateTime date,
        int capacity,
        string organizerUsername,
        string? imagePath = null)
    {
        var ev = new Event(
            name,
            description,
            location,
            "Scheduled",
            date,
            capacity,
            new List<TicketType>(),
            organizerUsername,
            imagePath
        );

        _events.Add(ev);
        _logger.LogInformation("Event created: {EventName}", name);
    }

    // 🔹 Adăugare tip de bilet (folosește logica TA din Event)
    public void AddTicketTypeToEvent(
        string eventName,
        string categoryName,
        decimal price,
        int quantity)
    {
        var ev = FindEvent(eventName);
        ev.AddTicketType(categoryName, price, quantity);

        _logger.LogInformation(
            "Ticket type {Category} added to event {Event}",
            categoryName, eventName);
    }

    // 🔹 Update detalii eveniment
    public void UpdateEvent(
        string eventName,
        string newName,
        string newDescription,
        string newLocation,
        DateTime newDate,
        int newCapacity)
    {
        var ev = FindEvent(eventName);
        ev.UpdateDetails(newName, newDescription, newLocation, newDate, newCapacity);

        _logger.LogInformation("Event updated: {EventName}", eventName);
    }

    // 🔹 Anulare eveniment
    public void CancelEvent(string eventName)
    {
        var ev = FindEvent(eventName);
        ev.EventStatus = "Canceled";

        _logger.LogInformation("Event canceled: {EventName}", eventName);
    }

    // 🔹 Metodă internă de căutare (parte din agregat)
    private Event FindEvent(string eventName)
    {
        var ev = _events.FirstOrDefault(e => e.EventName == eventName);
        if (ev == null)
            throw new Exception($"Event '{eventName}' not found");

        return ev;
    }
}
