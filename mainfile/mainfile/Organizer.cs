using System.Text.Json.Serialization;
using System.Xml.Schema;
using System.Linq;
namespace mainfile;
public class Organizer : User
{
    // Lista de evenimente create de acest organizator specific
    //public List<Event> CreatedEvents { get; set; } = new List<Event>();

    [JsonConstructor]
    public Organizer(string Username, string Password) : base(Username, Password, "Organizer")
    {
        //Console.WriteLine("organizer json");
    }
    private List<Event> MyEvents(List<Event> evenimente)
    {
        return evenimente.Where(e => e.OrganizerUsername == this.Username).ToList();// returnam evenimentele create doar de utilizatorul logat
    }
    // Meniul specific Organizatorului
    public override void DisplayMenu(List<Event> evenimente)
    {
        bool logout = false;
        while (!logout)
        {
            Console.WriteLine($"\n --- Organizer MENU: {Username} ---");
            Console.WriteLine("1.Manage events");
            Console.WriteLine("2.Manage ticket types");
            Console.WriteLine("3.Sales status management");
            Console.WriteLine("4.Change Event status");
            Console.WriteLine("5.Logout");
            Console.Write("option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageEvent(evenimente); // Sub-meniu pentru CRUD evenimente
                    break;
                case "2":
                    ManageTicketTypes(evenimente); // Adăugare bilete (VIP, Standard etc.)
                    break;
                case "3":
                    SalesStatusManagement(evenimente); // Rapoarte vânzări
                    break;
                case "4":
                    ChangeEventStatus(evenimente); // Anulare/Modificare status
                    break;
                case "5":
                    logout = true; // Ieșire din cont
                    break;
                default:
                    break;
            }
        }
    }

    // Sub-meniu pentru gestionarea evenimentelor (Creare, Modificare, Ștergere)
    private void ManageEvent(List<Event> evenimente)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n --- Manage Events ---");
            Console.WriteLine("1.Create Event");
            Console.WriteLine("2.Modify Event");
            Console.WriteLine("3.Delete Event");
            Console.WriteLine("4.Return");
            Console.Write("option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateEvent(evenimente);
                    break;
                case "2":
                    ModifyEvent(evenimente);
                    break;
                case "3":
                    DeleteEvent(evenimente);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    break;
            }
        }
    }

    // Metoda de creare a unui eveniment nou
    public void CreateEvent(List<Event> evenimente)
    {
        Console.WriteLine("Creating Event");
        // ... (Citire date de la tastatură) ...
        Console.Write("Enter Event name: ");
        string eventName = Console.ReadLine();
        Console.Write("Enter description: ");
        string eventDescription = Console.ReadLine();
        Console.Write("Enter Location: ");
        string eventLocation = Console.ReadLine();
        Console.Write("Enter Date (yyyy-mm-dd): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime date);
        Console.Write("Enter Capacity: ");
        int.TryParse(Console.ReadLine(), out int capacity);

        // Instanțiere obiect Event și adăugare în listă
        Event newEvent = new Event(eventName, eventDescription, eventLocation, "scheduled", date, capacity, new List<TicketType>(),this.Username );
        evenimente.Add(newEvent);    // evenimentul global (toata aplicatia)

        Console.WriteLine("Event created successfully!");
    }

    // Metoda de modificare a unui eveniment existent
    public void ModifyEvent(List<Event> evenimente)
    {
        var evenimentem = MyEvents(evenimente);
        if (evenimentem.Count == 0)
        {
            Console.WriteLine("No events created");
            return;
        }

        // Afișare listă pentru selecție
        for (int i = 0; i < evenimentem.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {evenimentem[i].EventName}");
        }

        Console.Write("Enter Event number: ");
        // Validare input index
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= evenimentem.Count)
        {
            Event ev = evenimentem[index - 1];
            // ... (Citire noile date) ...
            Console.WriteLine($"editing event {ev.EventName}");
            Console.Write($"Enter new Event name: ");
            string newName = Console.ReadLine();
            Console.WriteLine($"Description: {ev.EventDescription}");
            Console.Write("Enter new description: ");
            string newDescription = Console.ReadLine();
            Console.WriteLine($"Location: {ev.EventLocation}");
            Console.Write("Enter new Location: ");
            string eventLocation = Console.ReadLine();
            Console.WriteLine($"Event date: {ev.EventDate}");
            Console.Write("Enter new Date (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime newdate);
            Console.WriteLine($"Event capacity: {ev.EventCapacity}");
            Console.Write("Enter new Capacity (leave empty to keep): ");
            string capacitatenoua = Console.ReadLine();
            int newcapacity = ev.EventCapacity; // default(pastreaza vechea valoare)
            if (!string.IsNullOrWhiteSpace(capacitatenoua))
            {
                if (!int.TryParse(capacitatenoua ,out newcapacity))
                {
                    Console.WriteLine("Invalid capacity input,keeping old capacity");
                    newcapacity = ev.EventCapacity;
                }
            }

            
            try
            {
                // Apelăm metoda din Event pentru a valida regulile de business (ex: data în viitor)
                ev.UpdateDetails(newName, newDescription, eventLocation, newdate, newcapacity);
                Console.WriteLine("Event modified!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update Failed: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    // Ștergerea unui eveniment
    public void DeleteEvent(List<Event> evenimente)
    {
        Console.WriteLine("Deleting Event");
        var evenimentem = MyEvents(evenimente);
        if (evenimentem.Count == 0)
        {
            Console.WriteLine("No events deleted");
            return;
        }

        // Afișare evenimente
        for (int i = 0; i < evenimentem.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {evenimentem[i].EventName}");
        }

        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= evenimentem.Count)
        {
            Event ev = evenimentem[index - 1];
            
            // Verificare critică: Nu ștergem evenimentul dacă s-au vândut deja bilete!
            int totalTicketSold = 0;
            foreach (var t in ev.OptiuniTichete)
            {
                totalTicketSold += t.SoldCount;
            }

            if (totalTicketSold > 0)
            {
                Console.WriteLine("Cannot delete event, tickets already sold");
                Console.WriteLine("change status to 'Canceled' instead");
            }
            else
            {
                evenimentem.RemoveAt(index - 1);
                Console.WriteLine("Event removed!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    // Gestionarea tipurilor de bilete (ex: VIP, Standard) pentru un eveniment
    public void ManageTicketTypes(List<Event> evenimente)
    {
        var evenimentem = MyEvents(evenimente);
        if (evenimentem.Count == 0)
        {
            Console.WriteLine("\nNo events created");
            return;
        }

        Console.WriteLine("\n ---- Manage Ticket Types---");
        // Listare evenimente
        for (int i = 0; i < evenimentem.Count; i++)
        {
            Console.WriteLine($" {i+1}.{evenimentem[i].EventName}");
        }

        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= evenimentem.Count)
        {
            Event ev = evenimentem[index - 1];
            bool back = false;
            while (!back)
            {
                Console.WriteLine($"--- Managing tickets for Event {ev.EventName} ---");
                
                // Calcul locuri ocupate vs locuri rămase
                int currentlyAllocated = 0;
                foreach (var t in ev.OptiuniTichete)
                {
                    currentlyAllocated += t.MaxQuantity;
                    Console.WriteLine($"Tier:{t.CategoryName} Price:{t.Price} Quantity:{t.MaxQuantity}");
                }
                int remaining=ev.EventCapacity-currentlyAllocated;
                Console.WriteLine($"Remaining Tickets:{remaining}");
                
                Console.WriteLine($"1.Add new ticket type");
                Console.WriteLine($"2.Back to menu");
                Console.Write("Option: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    // Validare capacitate înainte de a cere datele
                    if (remaining <= 0)
                    {
                        Console.WriteLine("Error: You can't add more tickets");
                        continue;
                    }
                    // Citire date bilet
                    Console.WriteLine($"Enter Category name (Eg: VIP, Standard, Early Bird): ");
                    string CategoryName = Console.ReadLine();
                    Console.WriteLine($"Enter Price($): ");
                    decimal.TryParse(Console.ReadLine(), out decimal Price);
                    Console.WriteLine($"Enter Quantity ($) (Max remaining: {remaining}): ");
                    int.TryParse(Console.ReadLine(), out int Quantity);
                    try
                    {
                        // Încercare adăugare bilet în eveniment
                        ev.AddTicketType(CategoryName, Price, Quantity);
                        Console.WriteLine("Ticket type created!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed {ex.Message}");
                    }
                }
                else if (choice == "2")
                {
                    back = true;
                }
            }
        }
    }
    public void SalesStatusManagement(List<Event> evenimente)
    {
        var evenimentem = MyEvents(evenimente);
        if (evenimentem.Count == 0)
        {
            Console.WriteLine("No events created");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("\n------Manage Sales Status----");
        for (int i = 0; i < evenimentem.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {evenimentem[i].EventName}");//lista evenimente
        }
        Console.Write("Choose event number: ");
        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Invalid number");
            Console.ReadKey();
            return;
        }
        if (index < 1 || index > evenimentem.Count)
        {
            Console.WriteLine("Invalid event number");
            Console.ReadKey();
            return;
        }
        Event ev = evenimentem[index - 1];
        int totalSold = 0;//incepem prin a calcula vanzarile
        decimal totalRevenue = 0;
        foreach (var t in ev.OptiuniTichete)
        {
            totalSold += t.SoldCount;
            totalRevenue += t.SoldCount * t.Price;
        }
        int available = ev.EventCapacity - totalSold;
        Console.WriteLine("\n--- Sales Status ---");
        Console.WriteLine($"Event: {ev.EventName}");
        Console.WriteLine($"Status: {ev.EventStatus.ToUpper()}");
        Console.WriteLine($"Tickets sold: {totalSold}");
        Console.WriteLine($"Available tickets: {available}");
        Console.WriteLine($"Revenue: ${totalRevenue}");
        if (ev.EventStatus.Equals("Canceled", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("!!! THIS EVENT IS CANCELED - SALES STOPPED !!!");
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }


    // Modificarea stării evenimentului (ex: din Scheduled în Canceled)
    public void ChangeEventStatus(List<Event> evenimente)
    {
        var evenimentem = MyEvents(evenimente);
        if (evenimentem.Count == 0)
        {
            Console.WriteLine("No events created");
            return;
        }

        // Selecție eveniment
        for (int i = 0; i < evenimentem.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {evenimentem[i].EventName}");
        }
        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= evenimentem.Count)
        {
            Event ev = evenimentem[index - 1];
            Console.WriteLine($"Current Status: {ev.EventStatus.ToUpper()}");
            Console.WriteLine($"Choose new Status");
            Console.WriteLine("1.Scheduled");
            Console.WriteLine("2.Modified");
            Console.WriteLine("3.Canceled");
            Console.WriteLine("4.Completed");
            Console.Write("Option: ");
            string choice = Console.ReadLine();
            string newStatus = "";
            switch (choice)
            {
                case "1": newStatus= "Scheduled"; break;
                case "2": newStatus= "Modified"; break;
                case "3": newStatus= "Canceled"; break;
                case "4": newStatus= "Completed"; break;
                default:
                    Console.WriteLine("Invalid Status selected");
                    return;
            }
             ev.EventStatus = newStatus;
             Console.WriteLine("Status updated!");
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}