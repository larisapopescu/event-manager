using System.Text.Json;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        
        string filePath = "test.json";
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive=true
        };
        //load savedUsers
        List<User> utilizatori=AuthService.LoadUsers(filePath, options);
        
        while (true)
        {
            Console.Write("\n1.Login\n2.Register\n3.Exit\n");
            string choice=Console.ReadLine();

            if (choice == "1")
            {
                User sessionUser=AuthService.Login(utilizatori);
                if (sessionUser != null)
                {
                    sessionUser.DisplayMenu();
                    AuthService.Save(utilizatori,filePath, options);
                }
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
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(currentDate.ToString("dd/MM/yyyy"));
    }
}