namespace mainfile;

public class Client : User
{
    public Client(string Username, string Password) : base(Username, Password, "Client")
    {
        
    }
    //public Client() : base("", "", "Client") 
    //{
    //}
    
    public override void DisplayMenu()
    {
        throw new NotImplementedException();
    }
}
