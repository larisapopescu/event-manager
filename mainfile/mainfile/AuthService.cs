using System.Text.Json;

namespace mainfile;

public static class AuthService
{
    // Încarcă datele din fișierul JSON și le transformă în obiecte
    public static List<User> LoadUsers(string FilePath, JsonSerializerOptions Options)
    {
        if (File.Exists(FilePath))
        {
            string json =File.ReadAllText(FilePath);
            // Deserializare: Text -> Listă de Useri
            return JsonSerializer.Deserialize<List<User>>(json, Options) ?? new List<User>();
        }
        return new List<User>();
    }
    
    // Logica de înregistrare cont nou
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
            // Verificare duplicate: nu putem avea doi useri cu același nume
            else if(Utilizatori.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Username is already in use");
            }
            else
            {
                break;
            }
        }
        
        Console.Write("Password: ");
        string password = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(password))
        {
           Console.WriteLine("Error: password cannot be empty"); 
           password = Console.ReadLine();
        }
        
        // Hășuim parola pentru securitate (nu o salvăm text clar)
        string hashedPassword=Hashing.ToSHA256(password);
        
        Console.Write("Do you want an organizer account? (y/n): ");
        string choice = Console.ReadLine();
        User newUser;
        
        // Creare instanță în funcție de rolul ales
        if (choice == "y")
        {
            newUser= new Organizer(username, hashedPassword);
        }
        else
        {
            newUser=new Client(username, hashedPassword,new List<Ticket>());
        }
        
        // Adăugare în listă și salvare imediată în fișier
        Utilizatori.Add(newUser);
        string json = JsonSerializer.Serialize(Utilizatori, Options);
        File.WriteAllText(FilePath, json);
    }
    
    // Logica de login
    public static User Login(List<User> Utilizatori)
    {
        Console.Write("Username: ");
        string u = Console.ReadLine();
        Console.Write("Password: ");
        string p = Console.ReadLine();
        
        // Hășuim parola introdusă pentru a o compara cu cea stocată
        string hp = Hashing.ToSHA256(p);
        
        // Căutăm utilizatorul care are ȘI username-ul ȘI parola corecte
        return Utilizatori.FirstOrDefault(user => user.Username == u && user.Password == hp);
    }
    
    // Metodă generică pentru salvarea listei curente în fișier
    public static void Save(List<User> Utilizatori, string FilePath, JsonSerializerOptions Options)
    {
        string json = JsonSerializer.Serialize(Utilizatori, Options);
        File.WriteAllText(FilePath, json);
    }
}