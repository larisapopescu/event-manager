namespace mainfile;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
public partial class MeniuOrganizator : Form
{
    private readonly ILogger<MeniuOrganizator> logger;
    private readonly User user;
    private readonly List<Event> evenimente;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    public MeniuOrganizator( User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        
        logger = Program.LoggerFactory.CreateLogger<MeniuOrganizator>();
        
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        button5.Click += button5_Click;
        this.user = user;
        this.evenimente = evenimente;
        this.eventsPath = eventsPath;
        this.options = options;
        
        logger.LogInformation("Organizer menu opened for {Username}", user.Username);
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Manage events opened");
        var f = new ManageEvents(user, evenimente, eventsPath, options);
        f.ShowDialog(); // teoretic aici se opreste codul ca sa pot face ce trebuie facut in manageevenst
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Manage ticket types opened");
        var f = new ManageTicketTypes(user, evenimente, eventsPath, options);
        f.ShowDialog(); 
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Sales status opened");
        var f = new SalesStatus(user, evenimente); 
        f.ShowDialog();
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Change event status opened");
        var f = new ChangeEventStatus(user, evenimente, eventsPath, options);
        f.ShowDialog();
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Organizer menu closed, saving events");
        EventsStore.SaveEvents(evenimente, eventsPath, options);
        this.Close();
    }
}