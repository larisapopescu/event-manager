namespace mainfile;

public class Client : User
{
    public Client(string Username, string Password) : base(Username, Password, "Client")
    {
        
    }
    public Client() : base("", "", "Client") 
    {
        
    }
    //needs to be worked on
    public override void DisplayMenu()
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
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    logout = true;
                    break;
                default:
                    break;
            }
        }
    }
    
}
