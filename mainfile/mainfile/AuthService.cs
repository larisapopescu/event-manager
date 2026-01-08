using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace mainfile;

public static class AuthService
{
    private static readonly ILogger logger =
        Program.LoggerFactory.CreateLogger("AuthService");

    
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
    
    /*// Logica de înregistrare cont nou
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
    
    // Metodă generică pentru salvarea listei curente în fișier
    public static void Save(List<User> Utilizatori, string FilePath, JsonSerializerOptions Options)
    {
        string json = JsonSerializer.Serialize(Utilizatori, Options);
        File.WriteAllText(FilePath, json);
    }*/
    
    
    
    
    // login ul din WINDOWS FORMS
    public static User LoginWithCredentials(List<User> utilizatori, string username, string password)
    {
        logger.LogDebug("Login attempt for {Username}", username);

        string hp = Hashing.ToSHA256(password);
        return utilizatori.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&u.Password == hp);
    }
    public static (bool ok, string error) RegisterWithCredentials(List<User> utilizatori, string username, string password, bool isOrganizer, string filePath, JsonSerializerOptions options)
    {
        if (string.IsNullOrWhiteSpace(username))
        { 
            return (false, "Username is empty");
        }
        if (utilizatori.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            return (false, "Username is already in use");
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            return (false, "Password cannot be empty");
        }
        string hashedPassword = Hashing.ToSHA256(password);
        User newUser = isOrganizer ? new Organizer(username, hashedPassword) : new Client(username, hashedPassword, new List<Ticket>());
        utilizatori.Add(newUser);
        Save(utilizatori, filePath, options);
        
        logger.LogInformation("User saved: {Username}", username);

        return (true, " ");
    }
    public static void Save(List<User> utilizatori, string filePath, JsonSerializerOptions options)
    {
        string json = JsonSerializer.Serialize(utilizatori, options);
        File.WriteAllText(filePath, json);// salvam lista de utilizatori
        logger.LogInformation("Users saved to file");
    }
    
}