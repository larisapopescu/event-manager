namespace mainfile;
using System.IO;
using System.Text.Json;
public partial class MeniuOrganizator : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    public MeniuOrganizator( User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        button5.Click += button5_Click;
        this.user = user;
        this.evenimente = evenimente;
        this.eventsPath = eventsPath;
        this.options = options;

    }
    private void button1_Click(object? sender, EventArgs e)
    {
        var f = new ManageEvents(user, evenimente, eventsPath, options);
        f.ShowDialog(); // teoretic aici se opreste codul ca sa pot face ce trebuie facut in manageevenst
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        var f = new ManageTicketTypes(user, evenimente, eventsPath, options);
        f.ShowDialog(); 
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        var f = new SalesStatus(user, evenimente); 
        f.ShowDialog();
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        var f = new ChangeEventStatus(user, evenimente, eventsPath, options);
        f.ShowDialog();
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        EventsStore.SaveEvents(evenimente, eventsPath, options);
        this.Close();
    }
}