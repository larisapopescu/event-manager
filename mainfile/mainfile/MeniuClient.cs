namespace mainfile;
using System.IO;
using System.Text.Json;
public partial class MeniuClient : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
  
    public MeniuClient(User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        button1.Click += button1_Click;
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
        using var f = new SearchEvents(evenimente);
        f.ShowDialog(this);
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        /*var f = new BuyingTickets();//urmeaza sa o fac
        f.ShowDialog();*/
        MessageBox.Show("Urmeaza");
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        /*var f = new ManageTickets();//urmeaza sa o fac
        f.ShowDialog();*/
        MessageBox.Show("Urmeaza");
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}