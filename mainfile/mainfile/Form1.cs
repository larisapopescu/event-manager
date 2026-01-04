using System.Text.Json;

namespace mainfile;

public partial class Form1 : Form
{
    private readonly string usersPath = "test.json";
    private readonly string eventsPath = "events.json";
    private readonly JsonSerializerOptions options;
    private List<User> utilizatori;
    private List<Event> evenimente;
    public Form1()
    {
        InitializeComponent();
        options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        utilizatori = AuthService.LoadUsers(usersPath, options); // incarc datele când porneste form-ul
        evenimente = EventsStore.LoadEvents(eventsPath, options);
        button1.Click += button1_Click;   // Login
        button2.Click += button2_Click;   // Exit
        label5.Click += label5_Click;     // Sign up
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        string username = textBox1.Text.Trim();
        string password = textBox2.Text;
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Write your username and password.");
            return;
        }
        var user = AuthService.LoginWithCredentials(utilizatori, username, password);
        if (user == null)
        {
            MessageBox.Show("Username or password is incorrect.");
            return;
        }
        MessageBox.Show($"You ve succesfully logged in as {user.Role}: {user.Username}");// aici decizi ce form deschizi mai departe (Client/Organizer)
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
    private void label5_Click(object? sender, EventArgs e)// aici urmeaza pagina de sign up
    {
        MessageBox.Show("Sign up");
    }
}
