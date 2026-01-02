//Program.cs

using System.Text.Json;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

using System.Text.Json;

namespace mainfile;

class Program
{
    static void Main(string[] args)
    {
        // Inițializăm logger-ul custom (fără librării externe)
        ILogger logger = new ConsoleLogger();
        logger.Info("Aplicatia a pornit.");

        // Calea către fișierul JSON unde stocăm toți utilizatorii
        string filePath = "test.json";
        string eventsPath = "events.json";
        
        // Configurări pentru JSON: 
        // WriteIndented face fișierul ușor de citit de către oameni.
        // PropertyNameCaseInsensitive ajută la citirea datelor indiferent de litere mari/mici.
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        
        // PAS 1: Încărcăm lista de utilizatori (Clienti și Organizatori) din fișier la pornirea aplicației
        List<User> utilizatori = AuthService.LoadUsers(filePath, options, logger);
        List<Event> evenimente = EventsStore.LoadEvents(eventsPath, options);
        
        // Bucla infinită a meniului principal (Start Menu)
        while (true)
        {
            Console.Write("\n1.Login\n2.Register\n3.Exit\n");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Încercare de autentificare
                logger.Info("Incercare de login.");

                User sessionUser = AuthService.Login(utilizatori, logger);
                
                if (sessionUser != null)
                {
                    // Dacă login-ul reușește, afișăm meniul specific rolului (Client sau Organizator)
                    // Polimorfism: metoda DisplayMenu() corectă este apelată automat
                    logger.Info($"Utilizator autentificat: {sessionUser.Username}");

                    sessionUser.DisplayMenu(evenimente);
                    
                    // După ce utilizatorul face logout (iese din DisplayMenu), salvăm modificările
                    logger.Info("Se salveaz modificarile.");
                    EventsStore.SaveEvents(evenimente, eventsPath, options);
                    AuthService.Save(utilizatori, filePath, options, logger);
                }
                else
                {
                    logger.Warning("Username sau parola incorecta.");
                    Console.WriteLine("Username or password is incorrect");
                }
            }
            else if (choice == "2")
            {
                // Înregistrare utilizator nou
                logger.Info("Inregistrare utilizator nou.");
                AuthService.RegisterUser(utilizatori, filePath, options, logger);
            }
            else if (choice == "3")
            {
                // Oprire aplicație
                logger.Info("Aplicatia se inchide.");
                break;
            }
            else
            {
                logger.Warning("Optiune invalida selectata.");
            }
        }
    }
}
