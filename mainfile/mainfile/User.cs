namespace mainfile;
using System.Text.Json.Serialization;
[JsonDerivedType(typeof(Client), "Client")]
[JsonDerivedType(typeof(Organizer), "Organizer")]
public abstract class User
{
    public string Username { get; set; }
    public string Password { get; set; } // hashing function
    public string Role { get; set; } // Organizer or Client (maybe bool instead of string) 

    public User(string Username, string Password, string Role)
    {
        this.Username=Username;
        this.Password=Password;
        this.Role=Role;
    }
    public abstract void DisplayMenu();

    public void Afisare()
    {
        Console.WriteLine($"You logged in as a {Role}, {Username}!");
    }
}