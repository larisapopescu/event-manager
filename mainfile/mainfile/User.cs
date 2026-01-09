namespace mainfile;
using System.Text.Json.Serialization;

// Aceste atribute spun serializatorului JSON cum să facă diferența între un Client și un Organizator
[JsonDerivedType(typeof(Client), "Client")]
[JsonDerivedType(typeof(Organizer), "Organizer")]

// folosim cuvantul cheie record alatrui de atributele init pentru a transforma clas in una imutabila
public abstract record User
{
    public string Username { get; init; }
    public string Password { get; init; } // Aici se stochează hash-ul parolei, nu parola în clar
    public string Role { get; init; } // Rolul: "Organizer" sau "Client"

    protected User(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }
    // public User(string Username, string Password, string Role)
    // {
    //     this.Username=Username;
    //     this.Password=Password;
    //     this.Role=Role;
    // }
    
    // Metodă abstractă: obligă clasele copil să își definească propriul meniu
    public abstract void DisplayMenu(List<Event> evenimente);


    public void Afisare()
    {
        Console.WriteLine($"You logged in as a {Role}, {Username}!");
    }
}