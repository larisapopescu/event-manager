using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace mainfile;

public partial class ManageTickets : Form
{
    private readonly ILogger<ManageTickets> logger;
    private readonly User user;
    private readonly List<User> utilizatori;
    private readonly List<Event> evenimente;
    private readonly string usersPath;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;

    public ManageTickets(
        User user,
        List<User> utilizatori,
        List<Event> evenimente,
        string usersPath,
        string eventsPath,
        JsonSerializerOptions options)
    {
        InitializeComponent();

        logger = Program.LoggerFactory.CreateLogger<ManageTickets>();
        logger.LogInformation("ManageTickets opened");

        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;

        this.user = user;
        this.utilizatori = utilizatori;
        this.evenimente = evenimente;
        this.usersPath = usersPath;
        this.eventsPath = eventsPath;
        this.options = options;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        logger.LogInformation("ActiveTickets opened");

        using var f = new Activetickets(user, evenimente);
        f.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        logger.LogInformation("History opened");

        using var f = new History(user);
        f.ShowDialog();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        logger.LogInformation("CancelTickets opened");

        using var f = new Canceltickets(user, utilizatori, evenimente, usersPath, eventsPath, options);
        f.ShowDialog();
    }

    private void button4_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("ManageTickets closed");
        Close();
    }
}