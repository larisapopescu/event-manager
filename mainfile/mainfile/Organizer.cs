using System.Text.Json.Serialization;
using System.Xml.Schema;

namespace mainfile;

public class Organizer : User
{

    public List<Event> CreatedEvents { get; set; } = new List<Event>();

    [JsonConstructor]
    public Organizer(string Username, string Password) : base(Username, Password, "Organizer")
    {
        Console.WriteLine("organizer json");
    }

    //needs rework
    public override void DisplayMenu()
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
                    ManageEvent();
                    break;
                case "2":
                    ManageTicketTypes();
                    break;
                case "3":
                    SalesStatusManagement();
                    break;
                case "4":
                    ChangeEventStatus();
                    break;
                case "5":
                    logout = true;
                    break;
                default:
                    break;
            }
        }
    }

    //1.manage events menu
    private void ManageEvent()
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
                    CreateEvent();
                    break;
                case "2":
                    ModifyEvent();
                    break;
                case "3":
                    DeleteEvent();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void CreateEvent()
    {
        Console.WriteLine("Creating Event");
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

        Event newEvent = new Event(eventName, eventDescription, eventLocation, "scheduled",
            date, capacity, new List<TicketType>());
        CreatedEvents.Add(newEvent);
        Console.WriteLine("Event created!");
    }

    public void ModifyEvent()
    {
        if (CreatedEvents.Count == 0)
        {
            Console.WriteLine("No events created");
            return;
        }

        for (int i = 0; i < CreatedEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {CreatedEvents[i].EventName}");
        }

        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= CreatedEvents.Count)
        {
            Event ev = CreatedEvents[index - 1];
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
            Console.Write("Enter new Capacity: ");
            int.TryParse(Console.ReadLine(), out int newcapacity);
            try
            {
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

    public void DeleteEvent()
    {
        Console.WriteLine("Deleting Event");
        if (CreatedEvents.Count == 0)
        {
            Console.WriteLine("No events deleted");
            return;
        }

        for (int i = 0; i < CreatedEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {CreatedEvents[i].EventName}");
        }

        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= CreatedEvents.Count)
        {
            Event ev = CreatedEvents[index - 1];
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
                CreatedEvents.RemoveAt(index - 1);
                Console.WriteLine("Event removed!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    public void ManageTicketTypes()
    {
        if (CreatedEvents.Count == 0)
        {
            Console.WriteLine("\nNo events created");
            return;
        }

        Console.Write("\n--- Manage Ticket Types ---");
        for (int i = 0; i < CreatedEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {CreatedEvents[i].EventName}");
        }

        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= CreatedEvents.Count)
        {
            Event ev = CreatedEvents[index - 1];
            bool back = false;
            while (!back)
            {
                Console.WriteLine($"--- Managing tickets for Event {ev.EventName} ---");
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
                    if (remaining <= 0)
                    {
                        Console.WriteLine("Error: You can't add more tickets");
                        continue;
                    }
                    Console.WriteLine($"Enter Category name (Eg: VIP, Standard, Early Bird): ");
                    string CategoryName = Console.ReadLine();
                    Console.WriteLine($"Enter Price($): ");
                    decimal.TryParse(Console.ReadLine(), out decimal Price);
                    Console.WriteLine($"Enter Quantity ($) (Max remaining: {remaining}): ");
                    int.TryParse(Console.ReadLine(), out int Quantity);
                    try
                    {
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

    public void SalesStatusManagement()
    {
        if (CreatedEvents.Count == 0)
        {
            Console.WriteLine("No events created");
            return;
        }
        Console.Write("--- Manage Sales Status ---");
        foreach (var ev in CreatedEvents)
        {
            int totalSold = 0;
            decimal totalRevenue = 0;
            foreach (var t in ev.OptiuniTichete)
            {
                totalSold += t.SoldCount;
                totalRevenue+=(t.SoldCount * t.Price);
            }
            int available = ev.EventCapacity - totalSold;
            
            Console.WriteLine($"Event: {ev.EventName}");
            Console.WriteLine($"Status: {ev.EventStatus.ToUpper()}");
            Console.WriteLine($"Tickets: Sold: {totalSold}  |  Available Tickets:{available} ");
            Console.WriteLine($"Revenue: ${totalRevenue}");

            if (ev.EventStatus.ToUpper()=="CANCELED")
            {
                Console.WriteLine("!!! THIS EVENT IS CANCELED  - SALES STOPPED !!!");
            }
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
    }

    public void ChangeEventStatus()
    {
        if (CreatedEvents.Count == 0)
        {
            Console.WriteLine("No events created");
            return;
        }

        for (int i = 0; i < CreatedEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {CreatedEvents[i].EventName}");
        }
        Console.Write("Enter Event number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= CreatedEvents.Count)
        {
            Event ev = CreatedEvents[index - 1];
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
                case "1":
                    newStatus= "Scheduled";
                    break;
                case "2":
                    newStatus= "Modified";
                    break;
                case "3":
                    newStatus= "Canceled";
                    break;
                case "4":
                    newStatus= "Completed";
                    break;
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
    
