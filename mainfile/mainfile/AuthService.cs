using System.Text.Json;

namespace mainfile;

public static class AuthService
{
    //load data
    public static List<User> LoadUsers(string FilePath, JsonSerializerOptions Options)
    {
        if (File.Exists(FilePath))
        {
            string json =File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json, Options) ?? new List<User>();
        }
        return new List<User>();
    }
    //register func
    public static void RegisterUser(List<User> Utilizatori, string FilePath, JsonSerializerOptions Options)
    {
        string username =" ";
        while (true)
        {
            Console.Write("Username: ");
            username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username is empty");
            }
            else if(Utilizatori.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Username is already in use");
            }
            else
            {
                break;
            }
        }
        //check if password is empty or white space
        Console.Write("Password: ");
        string password = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(password))
        {
           Console.WriteLine("Error: password cannot be empty"); 
           password = Console.ReadLine();
        }
        string hashedPassword=Hashing.ToSHA256(password);
        Console.Write("Do you want an organizer account? (y/n): ");
        string choice = Console.ReadLine();
        User newUser;
        if (choice == "y")
        {
            newUser= new Organizer(username, hashedPassword);
        }
        else
        {
            newUser=new Client(username, hashedPassword);
        }
        Utilizatori.Add(newUser);
        string json = JsonSerializer.Serialize(Utilizatori, Options);
        File.WriteAllText(FilePath, json);
    }
    //login func
    public static User Login(List<User> Utilizatori)
    {
        Console.Write("Username: ");
        string u = Console.ReadLine();
        Console.Write("Password: ");
        string p = Console.ReadLine();
        string hp = Hashing.ToSHA256(p);
        return Utilizatori.FirstOrDefault(user => user.Username == u && user.Password == hp);
    }
    //update list
    private static void Save(List<User> Utilizatori, string FilePath, JsonSerializerOptions Options)
    {
        string json = JsonSerializer.Serialize(Utilizatori, Options);
        File.WriteAllText(FilePath, json);
    }
    
}