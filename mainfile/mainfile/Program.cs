using System.Text.Json;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        // Calea către fișierul JSON unde stocăm toți utilizatorii
        string filePath = "test.json";
        
        // Configurări pentru JSON: 
        // WriteIndented face fișierul ușor de citit de către oameni.
        // PropertyNameCaseInsensitive ajută la citirea datelor indiferent de litere mari/mici.
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive=true
        };
        
        // PAS 1: Încărcăm lista de utilizatori (Clienti și Organizatori) din fișier la pornirea aplicației
        List<User> utilizatori = AuthService.LoadUsers(filePath, options);
        
        // Bucla infinită a meniului principal (Start Menu)
        while (true)
        {
            Console.Write("\n1.Login\n2.Register\n3.Exit\n");
            string choice=Console.ReadLine();

            if (choice == "1")
            {
                // Încercare de autentificare
                User sessionUser = AuthService.Login(utilizatori);
                
                if (sessionUser != null)
                {
                    // Dacă login-ul reușește, afișăm meniul specific rolului (Client sau Organizator)
                    // Polimorfism: metoda DisplayMenu() corectă este apelată automat
                    sessionUser.DisplayMenu();
                    
                    // După ce utilizatorul face logout (iese din DisplayMenu), salvăm modificările
                    AuthService.Save(utilizatori,filePath, options);
                }
                else Console.WriteLine("Username or password is incorrect");
            }
            else if (choice == "2")
            {
                // Înregistrare utilizator nou
                AuthService.RegisterUser(utilizatori,filePath,options);
            }
            else if (choice == "3")
            {
                // Oprire aplicație
                break;
            }
        }
    }
}