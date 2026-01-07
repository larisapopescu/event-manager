namespace mainfile;
using System.IO;
using System.Text.Json;
public partial class MeniuClient : Form
{
    private readonly User user;
    private readonly List<User> utilizatori;
    private readonly List<Event> evenimente;
    private readonly string usersPath;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    public MeniuClient(User user, List<User> utilizatori, List<Event> evenimente, string usersPath, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        button1.Click += button1_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        button5.Click += button5_Click;
        this.user = user;
        this.utilizatori = utilizatori;
        this.evenimente = evenimente;
        this.usersPath = usersPath;
        this.eventsPath = eventsPath;
        this.options = options;
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        using var f = new SearchEvents(evenimente);
        f.ShowDialog(this);
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        var f = new BuyingTickets(user, utilizatori, evenimente, usersPath, eventsPath, options);
        f.ShowDialog();
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        var f = new ManageTickets(user, utilizatori, evenimente, usersPath, eventsPath, options);
        f.ShowDialog();
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}