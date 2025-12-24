namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        //adding users to a list
        User p1 = new Client("Axvwy","12345");
        User p2= new Organizer("Narcis","67melons");
        List<User> utilizatori = new List<User>();
        utilizatori.Add(p1);
        utilizatori.Add(p2);
        foreach (User p in utilizatori)
        {
            p.Afisare();
        }
        //hashing passwords
        Console.Write("Password you wanna hash: ");
        string inputPassword = Console.ReadLine();
        Console.WriteLine($"hashed password: {Hashing.ToSHA256(inputPassword)}");
        //guid (Global Unique Identifier) ok test
        Guid id = Guid.NewGuid();
        Console.WriteLine($"id: {id}");
        
        
        Console.WriteLine("End.");
    }
}