namespace mainfile;
using Microsoft.Extensions.Logging;
public partial class DeleteEvent : Form
{
    private readonly ILogger<DeleteEvent> logger;
    private readonly User user;
    private readonly List<Event> evenimente;

    private List<Event> myEvents = new();

    public DeleteEvent(User user, List<Event> evenimente)
    {
        logger = Program.LoggerFactory.CreateLogger<DeleteEvent>();
        logger.LogInformation("DeleteEvent opened");
        
        InitializeComponent();
        this.user = user ;
        this.evenimente = evenimente;
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        LoadMyEvents();
    }
    private void LoadMyEvents()
    {
        logger.LogInformation("Loaded {Count} events for deletion", myEvents.Count);
        // doar evenimentele organizatorului logat
        myEvents = evenimente.Where(e => e.OrganizerUsername == user.Username).ToList();
        comboBox1.DataSource = null;
        comboBox1.DisplayMember = nameof(Event.EventName);
        comboBox1.DataSource = myEvents;
        if (myEvents.Count == 0)
        {
            logger.LogWarning("Delete attempted without selecting event");
            MessageBox.Show("You don't have any events to delete.");
            button1.Enabled = false;
        }
    }
    
    private void button1_Click(object? sender, EventArgs e)
    {
        if (comboBox1.SelectedItem is not Event ev)
        {
            logger.LogWarning("Delete attempted without selecting event");
            MessageBox.Show("Choose an event first.");
            return;
        }
        var confirm = MessageBox.Show("Are you sure you want to delete this event?", "Confirm delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
        if (confirm == DialogResult.No)
            return;
        // calculam biletele vandute
        
        logger.LogInformation("Delete requested for event {Event}", ev.EventName);
        
        int totalSold = 0;
        
        if (ev.OptiuniTichete != null)
        {
            foreach (var t in ev.OptiuniTichete)
                totalSold += t.SoldCount;
        }
        if (totalSold > 0)
        {
            logger.LogWarning("Event canceled instead of deleted: {Event}", ev.EventName);
            // daca avem bilete vandute doar dam cancel la event
            ev.EventStatus = "Canceled";
            MessageBox.Show("This event has sold tickets.\nIt cannot be deleted, but it was marked as CANCELED.", "Event canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            logger.LogInformation("Event deleted: {Event}", ev.EventName);
            evenimente.Remove(ev);
            MessageBox.Show("Event deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button2_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("DeleteEvent canceled");
        DialogResult = DialogResult.Cancel;
        Close();
    }
}