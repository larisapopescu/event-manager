using System.Text.Json;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace mainfile;

internal static class Program
{
    public static ILoggerFactory LoggerFactory { get; private set; }
    
    [STAThread] // pentru interfata
    static void Main(string[] args)
    {
        // ApplicationConfiguration.Initialize();
        // Application.Run(new LoginForm()); // pentru interfata

        ApplicationConfiguration.Initialize();
        
        LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.DisableColors = false;
                })
                .AddDebug()
                .SetMinimumLevel(LogLevel.Debug);
        });
        
        Application.Run(new LoginForm()); // pentru interfata
        
        
        // aici e partea care se facea pana acum in terminal
        /*// Calea către fișierul JSON unde stocăm toți utilizatorii
        string filePath = "test.json";
        string eventsPath = "events.json";

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
        List<Event> evenimente= EventsStore.LoadEvents(eventsPath, options);// lista evenimente
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
                    sessionUser.DisplayMenu(evenimente);

                    // După ce utilizatorul face logout (iese din DisplayMenu), salvăm modificările
                    EventsStore.SaveEvents(evenimente, eventsPath, options);
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
    }*/
    }
}