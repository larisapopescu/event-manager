//AuthService.cs

using System.Text.Json;

namespace mainfile;

public static class AuthService
{
    // Încarcă utilizatorii din fișier JSON și le transformă în obiecte
    public static List<User> LoadUsers(
        string filePath,
        JsonSerializerOptions options,
        ILogger logger)
    {
        logger.Info("Se incearcă incarcarea utilizatorilor.");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            
            // Deserializare: Text -> Listă de Useri
            
            logger.Info("Fisier utilizatori gasit si citit.");
            return JsonSerializer.Deserialize<List<User>>(json, options) ?? new List<User>();
        }

        logger.Warning("Fisierul de utilizatori nu exista. Se creează listă goala.");
        return new List<User>();
    }

    // Logica de înregistrare cont nou
    public static void RegisterUser(
        List<User> utilizatori,
        string filePath,
        JsonSerializerOptions options,
        ILogger logger)
    {
        logger.Info("Incepe procesul de inregistrare.");

        string username;
        while (true)
        {
            Console.Write("Username: ");
            username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                logger.Warning("Username gol introdus.");
                Console.WriteLine("Username is empty");
            }
            
            // Verificare duplicate: nu putem avea doi useri cu același nume
            
            else if (utilizatori.Any(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                logger.Warning("Incercare de username duplicat.");
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
            logger.Warning("Parola goala introdusa.");
            Console.WriteLine("Error: password cannot be empty");
            password = Console.ReadLine();
        }
        
        // Hășuim parola pentru securitate (nu o salvăm text clar)
        string hashedPassword=Hashing.ToSHA256(password);
        
        Console.Write("Do you want an organizer account? (y/n): ");
        string choice = Console.ReadLine();

        User newUser;
        
        // Creare instanță în funcție de rolul ales
        // choice poate sa fie doar y sau n
        if (choice != "y" || choice != "n")
        {
            Console.Write("Do you want an organizer account? (y/n): ");
            choice = Console.ReadLine(); 
            
        }
        if (choice == "y")
        {
            logger.Info("Se creeaza cont de Organizer.");
            newUser = new Organizer(username, hashedPassword);
        }
        else
        {
            logger.Info("Se creeaza cont de Client.");
            newUser = new Client(username, hashedPassword, new List<Ticket>());
        }

        // Adăugare în listă și salvare imediată în fișie
        
        utilizatori.Add(newUser);

        string json = JsonSerializer.Serialize(utilizatori, options);
        File.WriteAllText(filePath, json);

        logger.Info($"Utilizatorul {username} a fost inregistrat cu succes.");
    }

    // Login
    public static User Login(List<User> utilizatori, ILogger logger)
    {
        Console.Write("Username: ");
        string u = Console.ReadLine();

        Console.Write("Password: ");
        string p = Console.ReadLine();
        
        // Hășuim parola introdusă pentru a o compara cu cea stocată
        string hp = Hashing.ToSHA256(p);

        // Căutăm utilizatorul care are ȘI username-ul ȘI parola corecte
        User user = utilizatori.FirstOrDefault(
            user => user.Username == u && user.Password == hp);

        if (user != null)
        {
            logger.Info($"Login reusit pentru utilizatorul {u}.");
        }
        else
        {
            logger.Warning($"Login esuat pentru username-ul {u}.");
        }

        return user;
    }

    // Metodă generică pentru salvarea listei curente în fișie
    public static void Save(
        List<User> utilizatori,
        string filePath,
        JsonSerializerOptions options,
        ILogger logger)
    {
        string json = JsonSerializer.Serialize(utilizatori, options);
        File.WriteAllText(filePath, json);

        //logger.Info("Lista de utilizatori a fost salvata.");
    }
}
