namespace mainfile;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;

public partial class LoginForm : Form
{
    private readonly ILogger<LoginForm> logger;
    private readonly string usersPath = Path.Combine(AppContext.BaseDirectory, "test.json");
    private readonly string eventsPath = Path.Combine(AppContext.BaseDirectory, "events.json");
    private readonly JsonSerializerOptions options;
    private List<User> utilizatori = new();
    private List<Event> evenimente = new();

    public LoginForm()
    {
        InitializeComponent();

        logger = Program.LoggerFactory.CreateLogger<LoginForm>();

        options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        textBox2.UseSystemPasswordChar = true;// sa ascundem scrisul de la parola
        ReloadData();
        utilizatori = AuthService.LoadUsers(usersPath, options); // incarc datele când porneste form-ul
        button1.Click += button1_Click;   // LOGIN
        button2.Click += button2_Click;   // EXIT
        label5.Click += label5_Click;     // SIGN UP
        label5.Cursor = Cursors.Hand;// aici il fac sa arate ca link
    }

    private void ReloadData()// reincarcare users si events ca sa nu ramana null
    {
        utilizatori = AuthService.LoadUsers(usersPath, options) ?? new List<User>();
        logger.LogInformation("Users loaded");

        evenimente = EventsStore.LoadEvents(eventsPath, options) ?? new List<Event>();
        logger.LogInformation("Events loaded");
    }

    private void button1_Click(object? sender, EventArgs e)
    {
        string username = textBox1.Text.Trim();
        string password = textBox2.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            logger.LogWarning("Login attempt with empty fields");
            MessageBox.Show("Write your username and password.");
            return;
        }

        ReloadData();// reincarc userii inainte de login

        var user = AuthService.LoginWithCredentials(utilizatori, username, password);
        if (user == null)
        {
            logger.LogWarning("Invalid login for username {Username}", username);
            MessageBox.Show("Username or password is incorrect.");
            return;
        }

        logger.LogInformation("User logged in {Username} Role {Role}", user.Username, user.Role);

        this.Hide();// ascund login ul
        Form next;// aici pt ca urmeaza un form ori de client ori de organizator

        if (user.Role.Equals("Organizer", StringComparison.OrdinalIgnoreCase))
        {
            next = new MeniuOrganizator(user, evenimente, eventsPath, options);
        }
        else
        {
            next = new MeniuClient(user, utilizatori, evenimente, usersPath, eventsPath, options);
        }

        next.FormClosed += (_, __) =>// aici daca apas logout revenim la pagina de login(principala noastra)
        {
            logger.LogInformation("Returned to login screen");
            textBox1.Clear();
            textBox2.Clear();
            this.Show();// aratam iar loginul
            this.Activate();
        };

        next.Show();
    }

    private void button2_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Application exit");
        Application.Exit();
    }

    private void label5_Click(object? sender, EventArgs e)// aici urmeaza pagina de sign up
    {
        logger.LogInformation("Opening register form");

        this.Hide();// ascundem login ul cat timp creeam un cont nou pt ca va trebui sa ne intoarcem la el
        using (var register = new RegisterForm(usersPath, options))
        {
            var result = register.ShowDialog();
            if (result == DialogResult.OK)
            {
                utilizatori = AuthService.LoadUsers(usersPath, options);// am creat contul deci reincarcam utilizatorii
                logger.LogInformation("Account registered successfully");
                MessageBox.Show("Account has been successfully registered");
            }
        }
        this.Show();// revenim la login
        this.Activate();
    }
}
