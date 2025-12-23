namespace mainfile;

public abstract class User
{
    public string Username { get; private set; }
    public string Password { get; private set; } // hashing function
    public string Role { get; private set; } // Organizer or Client (maybe bool instead of string) 
    
    public abstract void DisplayMenu();
}