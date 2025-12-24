namespace mainfile;

public class Client : User
{
    public Client(string Username, string Password) : base(Username, Password, "Client")
    {
        
    }
    
    public override void DisplayMenu()
    {
        throw new NotImplementedException();
    }
}