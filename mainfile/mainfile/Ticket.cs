namespace mainfile;
public class Ticket
{
    // ID unic generat automat (GUID) pentru a identifica biletul
    public string TicketId {get; private set;} 
    public string EventName {get; private set;}
    public string CategoryName {get; private set;}
    public decimal PricePaid {get; private set;}
    public DateTime PurchaseDate {get; private set;}

    public Ticket(string EventName, string CategoryName, decimal PricePaid)
    {
        this.TicketId = Guid.NewGuid().ToString(); // Generare ID unic
        this.EventName = EventName;
        this.CategoryName = CategoryName;
        this.PricePaid = PricePaid;
        this.PurchaseDate = DateTime.Now; // Data curentă
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
}