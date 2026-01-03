namespace mainfile;
using System.Text.Json.Serialization;

// Aceste atribute spun serializatorului JSON cum să facă diferența între un Client și un Organizator
[JsonDerivedType(typeof(Client), "Client")]
[JsonDerivedType(typeof(Organizer), "Organizer")]
public abstract class User
{
    protected ILogger logger = new ConsoleLogger();
    public string Username { get; private set; }
    public string Password { get; private set; } // Aici se stochează hash-ul parolei, nu parola în clar
    public string Role { get; private set; } // Rolul: "Organizer" sau "Client"

    public User(string Username, string Password, string Role)
    {
        this.Username=Username;
        this.Password=Password;
        this.Role=Role;
        
        //logger.Info($"User created: {Username} with role {Role}");
    }
    
    // Optional: permite setarea loggerului din exterior
    public void SetLogger(ILogger logger)
    {
        if (logger != null)
        {
            this.logger = logger;
        }
    }
    
    // Metodă abstractă: obligă clasele copil să își definească propriul meniu
    public abstract void DisplayMenu(List<Event> evenimente);


    public void Afisare()
    {
        logger.Info($"You logged in as a {Role}, {Username}!");
    }
}