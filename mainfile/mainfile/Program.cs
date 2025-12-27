using System.Text.Json;

namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        List<User> utilizatori = new List<User>();
        //adds users to a list
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
        Ticket t = new Ticket("VIP", "You are allowed to enter and sit on a chair if you stay silent", "0", 199.99m);
        t.Afisare();
        Console.WriteLine("End.");
        
        //json file
        var options = new JsonSerializerOptions();
        options.WriteIndented = true;
        
        string jsonString = JsonSerializer.Serialize(utilizatori, options);
        File.WriteAllText("test.json", jsonString);
        
    }
}