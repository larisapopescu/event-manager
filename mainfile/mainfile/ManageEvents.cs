using System.Diagnostics.Tracing;
using System.IO;
using System.Text.Json;
namespace mainfile;

public partial class ManageEvents : Form
{
    private readonly User user;
    private readonly List<Event> evenimente; 
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    public ManageEvents(User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        this.user = user;
        this.evenimente = evenimente;
        this.eventsPath = eventsPath;
        this.options = options;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using var f=new CreateEvent(user,evenimente);
        f.ShowDialog();
        var result = f.ShowDialog();
        if (result == DialogResult.OK)
        {
            EventsStore.SaveEvents(evenimente, eventsPath, options);
            MessageBox.Show("Event saved successfully");
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        using var f = new ModifyEvent(user, evenimente);
        var result = f.ShowDialog();

        if (result == DialogResult.OK)
        {
            EventsStore.SaveEvents(evenimente, eventsPath, options);
            MessageBox.Show("Event updated and saved ");
        }
    }
    private void button3_Click(object sender, EventArgs e)
    {
        using var f=new DeleteEvent(user,evenimente);
        var result=f.ShowDialog();
        if (result == DialogResult.OK)
        {
            EventsStore.SaveEvents(evenimente, eventsPath, options);
            MessageBox.Show("Changes saved");
        }
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}