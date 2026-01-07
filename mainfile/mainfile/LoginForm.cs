using System.Runtime.CompilerServices;
namespace mainfile;
using System.IO;
using System.Text.Json;
public partial class LoginForm : Form
{
    private readonly string usersPath = Path.Combine(AppContext.BaseDirectory, "test.json");
    private readonly string eventsPath = Path.Combine(AppContext.BaseDirectory, "events.json");
    private readonly JsonSerializerOptions options;
    private List<User> utilizatori = new();
    private List<Event> evenimente = new();
    public LoginForm()
    {
        InitializeComponent();
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
        evenimente = EventsStore.LoadEvents(eventsPath, options) ?? new List<Event>();
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
        ReloadData();// reincarc userii inainte de login
        var user = AuthService.LoginWithCredentials(utilizatori, username, password);
        if (user == null)
        {
            MessageBox.Show("Username or password is incorrect.");
            return;
        }
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
            textBox1.Clear();
            textBox2.Clear();
            this.Show();// aratam iar loginul
            this.Activate();
        };
        next.Show(); 
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
    private void label5_Click(object? sender, EventArgs e)// aici urmeaza pagina de sign up
    {
        this.Hide();// ascundem login ul cat timp creeam un cont nou pt ca va trebui sa ne intoarcem la el
        using (var register = new RegisterForm(usersPath, options))
        {
            var result=register.ShowDialog();
            if (result == DialogResult.OK)
            {
                utilizatori = AuthService.LoadUsers(usersPath, options);// am creat contul deci reincarcam utilizatorii
                MessageBox.Show("Account has been successfully registered");
            }
        }
        this.Show();// revenim la login
        this.Activate();
    }
    
}
