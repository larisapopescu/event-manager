namespace mainfile;

public class Organizer : User
{
    public Organizer(string Username, string Password) : base(Username, Password, "Organizer")
    {
        
    }
    public Organizer() : base("", "", "Organizer")
    {
        
    }
    public override void DisplayMenu()
    {
        throw new NotImplementedException();
    }
}