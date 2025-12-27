using System.Text.Json;

namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        
        //adds users
        
        /*User p1 = new Client("Axvwy","12345");
        User p2= new Organizer("Narcis","67melons");
        
        utilizatori.Add(p1);
        utilizatori.Add(p2);
        foreach (User p in utilizatori)
        {
            p.Afisare();
        }*/
        
        //hash passwords
        //Console.Write("Password you wanna hash: \n\n");
        //string inputPassword = Console.ReadLine();
        //Console.WriteLine($"hashed password: {Hashing.ToSHA256(inputPassword)}");
        //for new users
        //p.Password=Hashing.ToSHA256(p.Password);
        
        //Ticket
        //Ticket t = new Ticket("VIP", "You are allowed to enter and sit on a chair if you stay silent", "0", 199.99m);
        //t.Afisare();
        //Console.WriteLine("End.");
        
        
        
        //create user
        
        
        //save new user to the list
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
        
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        string hashedPassword=Hashing.ToSHA256(password);
        User newUser=new Client(username, hashedPassword);
        utilizatori.Add(newUser);
        
        string updatedJson=JsonSerializer.Serialize(utilizatori, options);
        File.WriteAllText(filePath, updatedJson);

        //json file
        //
        //options.WriteIndented = true;

        //string jsonString = JsonSerializer.Serialize(utilizatori, options);
        //File.WriteAllText("test.json", jsonString);

    }
}