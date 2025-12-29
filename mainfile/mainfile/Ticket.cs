namespace mainfile;
public class Ticket
{
    //this class is hopefully not prone to change anymore
    //IS sectioned in 2 classes! ticketType and ticket
    public string TicketId {get; private set;} // is generated using guid (Global Unique Identifier)
    public string EventName {get; private set;}
    public string CategoryName {get; private set;}
    public decimal PricePaid {get; private set;}
    public DateTime PurchaseDate {get; private set;}

    public Ticket(string eventName, string categoryName, decimal pricePaid)
    {
        this.TicketId = Guid.NewGuid().ToString();
        this.EventName = eventName;
        this.CategoryName = categoryName;
        this.PricePaid = pricePaid;
        this.PurchaseDate = DateTime.Now;
    }

    public void Afisare()
    {
        Console.WriteLine("--- Ticket ---");
        Console.WriteLine($"ID: {TicketId}");
        Console.WriteLine($"Event: {EventName}");
        Console.WriteLine($"Category: {CategoryName}");
        Console.WriteLine($"Price: {PricePaid}");
        Console.WriteLine($"PurchaseDate: {PurchaseDate}");
    }
    //Guid id = Guid.NewGuid();
    //Console.WriteLine($"id: {id}");
}