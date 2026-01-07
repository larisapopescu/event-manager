using System.IO;
using System.Text.Json;
namespace mainfile;
public partial class ManageTickets : Form
{
    private readonly User user;
    private readonly List<User> utilizatori;
    private readonly List<Event> evenimente;
    private readonly string usersPath;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    private List<Ticket> shownTickets = new();
    public ManageTickets(User user, List<User> utilizatori, List<Event> evenimente, string usersPath, string eventsPath, JsonSerializerOptions options)
    { 
        InitializeComponent();
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        this.user = user;
        this.evenimente = evenimente;
        this.usersPath = usersPath;
        this.utilizatori = utilizatori;
        this.eventsPath = eventsPath;
        this.options = options;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using var f=new Activetickets(user,evenimente);
        f.ShowDialog();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        using var f = new History(user);
        var result = f.ShowDialog();
        
    }
    private void button3_Click(object sender, EventArgs e)
    {
        using var f=new Canceltickets(  user, utilizatori, evenimente, usersPath, eventsPath, options);
        var result=f.ShowDialog();
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}
