namespace mainfile;
using System.Text.Json.Serialization;

public class Client : User
{
    // Portofelul clientului: Lista de bilete cumpărate
    public List<Ticket> Tichetemele { get; set; }=new List<Ticket>();
    
    [JsonConstructor]
    public Client(string Username, string Password,List<Ticket> Tichetemele) : base(Username, Password, "Client")
    {
        // Dacă lista este null la citire, inițializăm una goală
        this.Tichetemele = Tichetemele ?? new List<Ticket>();
    }

    // Meniul Clientului (urmează a fi implementat complet)
    public override void DisplayMenu(List<Event> evenimente)
    {
        bool logout=false;
        while (!logout)
        {
            Console.WriteLine($"\n --- Client MENU: {Username} ---");
            Console.WriteLine("1.Search event");
            Console.WriteLine("2.Manage own tickets");
            Console.WriteLine("3.Purchase history");
            Console.WriteLine("4.Logout");
            Console.Write("option: ");
            string choice=Console.ReadLine();
            switch (choice)
            {
                case "1": break;
                case "2": break;
                case "3": break;
                case "4": logout = true; break;
                default: break;
            }
        }
    }
}