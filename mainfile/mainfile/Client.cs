using System.Runtime.InteropServices.JavaScript;

namespace mainfile;
using System.Text.Json.Serialization;
using System.Linq;

// mostenim o clasa record imutabila 
public record Client : User
{
    // Portofelul clientului: Lista de bilete cumpărate
    public List<Ticket> Tichetemele { get; private set; } = new List<Ticket>();

    [JsonConstructor]
    public Client(string Username, string Password, List<Ticket> Tichetemele) : base(Username, Password, "Client")
    {
        // Dacă lista este null la citire, inițializăm una goală
        this.Tichetemele = Tichetemele ?? new List<Ticket>();
    }
    public void AddTicket(Ticket ticket) // adaug un bilet in lista clientului
    {
        Tichetemele.Add(ticket);
    }
    public override void DisplayMenu(List<Event> evenimente) // Meniul Clientului 
    {
        bool logout = false;
        while (!logout)
        {
            Console.WriteLine($"\n --- Client MENU: {Username} ---");
            Console.WriteLine("1.Search event");
            Console.WriteLine("2.Viewing event details");
            Console.WriteLine("3.Buying tickets");
            Console.WriteLine("4.Managing personal tickets");
            Console.WriteLine("5.Logout");
            Console.Write("option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (evenimente.Count == 0)
                    {
                        Console.WriteLine("No events found");
                        Console.ReadKey();
                        break;
                    }

                    bool found = false;
                    while (!found)// aici un switch ca sa putem cauta un eveniment in functie de ce stim despre el
                    {
                        Console.WriteLine("\n------Search events by-------");
                        Console.WriteLine("1.Enter event's name");
                        Console.WriteLine("2.Enter event's date");
                        Console.WriteLine("3.Enter event's location");
                        Console.WriteLine("4.Enter event's description");
                        Console.WriteLine("5.Return");
                        Console.WriteLine("Enter your option :");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                Console.WriteLine("Enter event's name");
                                string name = Console.ReadLine();
                                bool verificare = false;
                                foreach (var ev in evenimente)
                                {
                                    if (ev.EventName != null &&
                                        ev.EventName.Contains(name ?? "", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine(
                                            $"{ev.EventName} | {ev.EventDate:yyyy-MM-dd} | {ev.EventLocation} | {ev.EventStatus}");
                                        verificare = true;
                                    }

                                }
                                if (!verificare)
                                {
                                    Console.WriteLine("Invalid event name");
                                }
                                break;
                            case "2":
                                Console.WriteLine("Enter event's date");
                                string input = Console.ReadLine();


                                if (DateTime.TryParse(input, out DateTime date))
                                {
                                    foreach (var ev in evenimente)
                                    {
                                        if (ev.EventDate.Date == date.Date)
                                        {
                                            Console.WriteLine(
                                                $"{ev.EventName} | {ev.EventDate:yyyy-MM-dd} | {ev.EventLocation} | {ev.EventStatus}");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid event date");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Enter event's location");
                                string location = Console.ReadLine();
                                bool verificare3 = false;
                                foreach (var ev in evenimente)
                                {
                                    if (ev.EventLocation != null && ev.EventLocation.Contains(location ?? "",StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine(
                                            $"{ev.EventName} | {ev.EventDate:yyyy-MM-dd} | {ev.EventLocation} | {ev.EventStatus}");
                                        verificare3 = true;
                                    }

                                }

                                if (!verificare3)
                                    Console.WriteLine("Invalid event location");

                                break;
                            case "4":
                                Console.WriteLine("Enter event's description");
                                string description = Console.ReadLine();
                                bool verificare4 = false;
                                foreach (var ev in evenimente)
                                {
                                    if (ev.EventDescription != null && ev.EventDescription.Contains(description ?? "",
                                            StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine(
                                            $"{ev.EventName} | {ev.EventDate:yyyy-MM-dd} | {ev.EventLocation} | {ev.EventStatus}");
                                        verificare4 = true;
                                    }
                                }

                                if (!verificare4)
                                {
                                    Console.WriteLine("Invalid event description");
                                }

                                break;
                            case "5":
                                found = true;
                                break;
                            default:
                                Console.WriteLine("Invalid option");
                                break;

                        }
                    }

                    break;
                case "2"://Viewing event details
                    if (evenimente.Count == 0)
                    {
                        Console.WriteLine("No events found");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("\n------Events list ------");//lista de evenimente din care clientul isi alege 
                    for (int i = 0; i < evenimente.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {evenimente[i].EventName}");
                    }
                    Console.WriteLine("Choose event number");
                    if (!int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.WriteLine("Invalid number");
                        break;
                    }
                    
                    if (index < 1 || index > evenimente.Count)
                    {
                        Console.WriteLine("Invalid number");
                    }
                    Event e =evenimente[index-1];
                    Console.WriteLine("\n--- Event Details ---");
                    Console.WriteLine($"Name: {e.EventName}");
                    Console.WriteLine($"Description: {e.EventDescription}");
                    Console.WriteLine($"Location: {e.EventLocation}");
                    Console.WriteLine($"Date: {e.EventDate:yyyy-MM-dd}");
                    Console.WriteLine($"Status: {e.EventStatus}");
                    Console.WriteLine($"Capacity: {e.EventCapacity}");
                    Console.WriteLine("\n----Tickets-----");
                    if (e.OptiuniTichete == null || e.OptiuniTichete.Count == 0)
                    {
                        Console.WriteLine("No ticket is available for this event");
                    }
                    else
                    {
                        foreach (var t in e.OptiuniTichete)
                        {
                            int ramase = t.MaxQuantity - t.SoldCount;
                            Console.WriteLine($"Category: {t.CategoryName} | Price: {t.Price} | Remaining: {ramase}");
                        }
                    }
                    break;
                case "3"://Buying tickets
                    if (evenimente.Count == 0)
                    {
                        Console.WriteLine("No events found");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("\n-----Events list------");
                    for (int i = 0; i < evenimente.Count; i++)
                    {
                        Console.WriteLine($"{i+1}.{evenimente[i].EventName} | {evenimente[i].EventDate:yyyy-MM-dd} | {evenimente[i].EventLocation} | {evenimente[i].EventStatus}");
                    }
                    Console.Write("Choose event number: ");
                    if (!int.TryParse(Console.ReadLine(), out int eventIndex))
                    {
                        Console.WriteLine("Invalid number");
                        break;
                    }

                    if (eventIndex < 1 || eventIndex > evenimente.Count)
                    {
                        Console.WriteLine("Invalid event number");
                        break;
                    }

                    Event e3 = evenimente[eventIndex - 1];
                    if (e3.EventStatus != null && e3.EventStatus.Equals("canceled", StringComparison.OrdinalIgnoreCase))// in cazul in care e anulat
                    {
                        Console.WriteLine("This event is canceled,you cannot buy tickets");
                        break;
                    }
                    if (e3.OptiuniTichete == null || e3.OptiuniTichete.Count == 0)
                    {
                        Console.WriteLine("No ticket is available for this event");
                        break;
                    }

                    if (e3.EventDate < DateTime.Now)
                    {
                        Console.WriteLine("This event happened, you cannot buy a ticket");// daca deja s a intamplat 
                        break;
                    }
                    Console.WriteLine("\n----Tickets-----");
                    for (int i = 0; i < e3.OptiuniTichete.Count; i++)
                    {
                        var t=e3.OptiuniTichete[i];
                        int ramase=t.MaxQuantity - t.SoldCount;
                        Console.WriteLine($"{i+1}.Category: {t.CategoryName} | Price: {t.Price} | Remaining: {ramase}");
                    }
                    Console.WriteLine("Choose ticket category number");
                    if (!int.TryParse(Console.ReadLine(), out int typeIndex))
                    {
                        Console.WriteLine("Invalid number");
                        break;
                    }
                    if (typeIndex < 1 || typeIndex > e3.OptiuniTichete.Count)
                    {
                        Console.WriteLine("Invalid ticket type number");
                        break;
                    }
                    TicketType chosenType = e3.OptiuniTichete[typeIndex - 1];
                    Console.Write("How many tickets do you want to buy? ");
                    if (!int.TryParse(Console.ReadLine(), out int cantitate))
                    {
                        Console.WriteLine("Invalid quantity.");
                        break;
                    }
                    if (cantitate <= 0)
                    {
                        Console.WriteLine("Quantity must be greater than 0.");
                        break;
                    }
                    int ramase3= chosenType.MaxQuantity - chosenType.SoldCount;
                    if (cantitate > ramase3)
                    {
                        Console.WriteLine($"Not enough tickets available. Remaining: {ramase3}");
                        break;
                    }
                    // cumparam cantitate de bilete
                    try
                    {
                        for (int i = 0; i < cantitate; i++)
                        {
                            chosenType.IncrementSales(); // creste SoldCount
                            Ticket biletnou= new Ticket(e3.EventName, chosenType.CategoryName, chosenType.Price);
                            AddTicket(biletnou);
                        }

                        Console.WriteLine($" You bought {cantitate} ticket/s");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Purchase failed: {ex.Message}");
                    }
                    break;
                case "4":
                    bool caz4 = false;
                    while (!caz4)// tot ca la 1 un mic meniu
                    {
                        Console.WriteLine("\n----------Managing personal tickets--------");
                        Console.WriteLine("1.Active tickets");
                        Console.WriteLine("2.Purchase history");
                        Console.WriteLine("3.Cancel a ticket");
                        Console.WriteLine("4.Return");
                        Console.WriteLine("Choose an option");
                        string op=Console.ReadLine();
                        switch (op)
                        {
                            case "1":
                                Console.WriteLine("\n-----------Active tickets----------");
                                bool verificare = false;
                                foreach (var t in Tichetemele)
                                {
                                    Event E=evenimente.FirstOrDefault(x=> x.EventName==t.EventName);
                                    if (E != null && E.EventDate.Date >= DateTime.Now.Date)
                                    {
                                        Console.WriteLine($"{t.EventName} | {t.CategoryName} | {t.PricePaid} | {t.PurchaseDate} | Ticket ID : {t.TicketId} ");
                                        verificare = true;
                                    }
                                }
                                if (!verificare)
                                {
                                    Console.WriteLine("No available tickets found");
                                }
                                break;
                            case "2":
                                Console.WriteLine("\n--------History tickets------------");
                                bool verificare2 = false;
                                foreach (var t in Tichetemele)
                                {
                                    Event e2=evenimente.FirstOrDefault(x=> x.EventName==t.EventName);
                                    if (e2 != null && e2.EventDate.Date < DateTime.Now.Date)// evenimente trecute "<"
                                    {
                                        Console.WriteLine($"{t.EventName} | {t.CategoryName} | {t.PricePaid} | {t.PurchaseDate} | Ticket ID : {t.TicketId} ");
                                            verificare2 = true;
                                    }
                                }
                                if (!verificare2)
                                {
                                    Console.WriteLine("No history available");
                                }
                                break;
                            case "3"://partea de anulare a evenimentului
                                Console.WriteLine("\n-------Cancel ticket----------");
                                if (Tichetemele.Count == 0)
                                {
                                    Console.WriteLine("No tickets available");
                                }
                                var activeTickets=new List<Ticket>();
                                Console.WriteLine("----------Your tikets------");
                                for (int i = 0; i < Tichetemele.Count; i++)
                                {
                                    var t=Tichetemele[i];
                                    Event ev=evenimente.FirstOrDefault(x=> x.EventName==t.EventName);
                                    if (ev != null && ev.EventDate.Date >= DateTime.Now.Date) // DACA biletul e activ
                                    {
                                        activeTickets.Add(t);
                                        Console.WriteLine($"{activeTickets.Count}.{t.EventName} | {t.CategoryName} | {t.PricePaid}$ | {ev.EventDate:yyyy-MM-dd}");
                                    }
                                }
                                if (activeTickets.Count == 0)
                                {
                                    Console.WriteLine("No tickets available");
                                    break;
                                }
                                Console.WriteLine("Choose a ticket to cancel");
                                if (!int.TryParse(Console.ReadLine(), out int index3))
                                {
                                    Console.WriteLine("Invalid number");
                                    break;
                                }

                                if (index3 < 1 || index3 >= Tichetemele.Count)
                                {
                                    Console.WriteLine("Invalid number");
                                    break;
                                }
                                Ticket selected=activeTickets[index3-1];
                                Event evSelected = evenimente.FirstOrDefault(x => x.EventName == selected.EventName);
                                if (evSelected == null)
                                {
                                    Console.WriteLine("Event not found");
                                    break;
                                }
                                // regulile pentru a putea anula un eveniment
                                if (evSelected != null && evSelected.EventStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase) || evSelected.EventStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine("You cannot cancel tickets for completed/canceled events");// mai sus verificam daca e copleted sau canceld
                                    break;
                                }
                                TimeSpan dif=evSelected.EventDate-DateTime.Now;
                                if (dif.TotalHours < 48)// nu putem anula un eveniment cu mai putin de 48 de ore inainte
                                {
                                    Console.WriteLine("You cannot cancel an event less than 48h before");
                                    break;
                                }

                                if (dif.TotalDays >= 7)
                                {
                                    Console.WriteLine("Since you cancelled more than a week before the event, you will receive 100% of the ticket price back the following week");
                                    break;
                                }

                                if (dif.TotalDays < 7 && dif.TotalHours > 48)
                                {
                                    Console.WriteLine("Since you cancelled less than a week before the event you will receive 50% of the ticket price back the following week ");
                                    break;
                                }
                                TicketType tichet=evSelected.OptiuniTichete.FirstOrDefault(x=> x.CategoryName == selected.CategoryName);
                                if (tichet != null)
                                {
                                    tichet.DecrementSales();
                                }
                                Tichetemele.RemoveAt(index3);// scoatem tichetul din portofel
                                Console.WriteLine("Ticket canceled successfully!");
                                break;
                            case "4":
                                caz4 = true;
                                break;
                        }
                    }
                    break;
                case "5":
                    logout = true;
                    break;
            }
        }
    }
}

                                    
                        
                        
                    