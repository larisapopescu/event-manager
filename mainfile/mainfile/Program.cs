using System.Text.Json;
using System.Linq;
namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        
        string filePath = "test.json";
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        //load savedUsers
        List<User> utilizatori=AuthService.LoadUsers(filePath, options);

        while (true)
        {
            Console.Write("\n1.Login\n2.Register\n3.Exit\n");
            string choice=Console.ReadLine();

            if (choice == "1")
            {
                User SessionUser=AuthService.Login(utilizatori);
                if (SessionUser!=null) SessionUser.DisplayMenu();
                else Console.WriteLine("Username or password is incorrect");
            }
            else if (choice == "2")
            {
                AuthService.RegisterUser(utilizatori,filePath,options);
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}