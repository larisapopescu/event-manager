namespace mainfile;

public class Ticket
{
    //this class is prone to change
    //should it be sectioned in 2 classes? ticketType and ticket
    public string TicketType {get; private set;} // VIP, Standard or Early Bird
    public string TicketId {get; private set;} // is generated using guid (Global Unique Identifier)
    public string TicketDescription {get; private set;}
    public string TicketRestriction {get; private set;} // age? Purchase limits? time? max tickets/person? non-refundable?
    public decimal TicketPrice {get; private set;}

    public Ticket(string TicketType, string TicketDescription, string TicketRestriction,
        decimal TicketPrice)
    {
        this.TicketType = TicketType;
        this.TicketId = Guid.NewGuid().ToString();
        this.TicketDescription = TicketDescription;
        this.TicketRestriction = TicketRestriction;
        this.TicketPrice = TicketPrice;
    }

    public void Afisare()
    {
        Console.WriteLine($"Type: {this.TicketType}, TicketId: {this.TicketId},\nTicketDescription: {this.TicketDescription},\n" +
                          $"TicketRestriction: {this.TicketRestriction}, TicketPrice: {this.TicketPrice}");   
    }
    //Guid id = Guid.NewGuid();
    //Console.WriteLine($"id: {id}");
}