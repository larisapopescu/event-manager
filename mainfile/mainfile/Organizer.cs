namespace mainfile;

public class Organizer : User
{
    public List<Event> CreatedEvents { get; set; } = new List<Event>();
    public Organizer(string Username, string Password) : base(Username, Password, "Organizer")
    {
        
    }
    public Organizer() : base("", "", "Organizer")
    {
        
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
            Console.WriteLine("4.Sales status ticket management");
            Console.WriteLine("5.Logout");
            Console.Write("option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case"1":
                    break;
                case"2":
                    break;
                case"3":
                    break;
                case"4":
                    break;
                case"5":
                    logout = true;
                    break;
                default:
                    break;
            }
        }
        
    }
}