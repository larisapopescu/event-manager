using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;

namespace mainfile;

public partial class ManageEvents : Form
{
    private readonly ILogger<ManageEvents> logger;
    private readonly User user;
    private readonly List<Event> evenimente;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;

    public ManageEvents(User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();

        logger = Program.LoggerFactory.CreateLogger<ManageEvents>();
        logger.LogInformation("ManageEvents opened");

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
        logger.LogInformation("CreateEvent button clicked");

        using var f = new CreateEvent(user, evenimente);
        var result = f.ShowDialog();

        if (result == DialogResult.OK)
        {
            EventsStore.SaveEvents(evenimente, eventsPath, options);
            logger.LogInformation("Event created and saved");
            MessageBox.Show("Event saved successfully");
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        logger.LogInformation("ModifyEvent button clicked");

        using var f = new ModifyEvent(user, evenimente);
        var result = f.ShowDialog();

        if (result == DialogResult.OK)
        {
            EventsStore.SaveEvents(evenimente, eventsPath, options);
            logger.LogInformation("Event modified and saved");
            MessageBox.Show("Event updated and saved ");
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        logger.LogInformation("DeleteEvent button clicked");

        using var f = new DeleteEvent(user, evenimente);
        var result = f.ShowDialog();

        if (result == DialogResult.OK)
        {
            EventsStore.SaveEvents(evenimente, eventsPath, options);
            logger.LogInformation("Event deleted or canceled and saved");
            MessageBox.Show("Changes saved");
        }
    }

    private void button4_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("ManageEvents closed");
        Close();
    }
}
