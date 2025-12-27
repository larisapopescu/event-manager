using System.Text.Json;

namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        
        //Ticket
        //Ticket t = new Ticket("VIP", "You are allowed to enter and sit on a chair if you stay silent", "0", 199.99m);
        //t.Afisare();
        //Console.WriteLine("End.");
        
        string filePath = "test.json";
        List<User> utilizatori;
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        
        //load savedUsers
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            utilizatori = JsonSerializer.Deserialize<List<User>>(json, options);
        }
        else
        {
            utilizatori = new List<User>();
        }
        
        //create new user
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        string hashedPassword=Hashing.ToSHA256(password);

        Console.Write("Do you want an organizer account? y/n\n");
        string accountChoice = Console.ReadLine();
        if (accountChoice == "y")
        {
            User newUser=new Organizer(username, hashedPassword);
            utilizatori.Add(newUser);
        }
        else
        {
            User newUser=new Client(username, hashedPassword);
            utilizatori.Add(newUser);
        }
        
        string updatedJson=JsonSerializer.Serialize(utilizatori, options);
        File.WriteAllText(filePath, updatedJson);
        
        //show login message for all the users
        foreach (User p in utilizatori)
        {
            p.Afisare();
        }
        
    }
}