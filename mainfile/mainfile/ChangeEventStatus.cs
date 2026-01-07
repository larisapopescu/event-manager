using System.Text.Json;

namespace mainfile;

public partial class ChangeEventStatus : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    private List<Event> myEvents = new();
    public ChangeEventStatus(User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        this.user = user ;
        this.evenimente = evenimente ;
        this.eventsPath = eventsPath ;
        this.options = options ;

        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        SetupStatusCombo();
        LoadMyEvents();
        SyncStatusWithSelectedEvent();
    }

    private void SetupStatusCombo()
    {
        comboBox2.DataSource = null;
        comboBox2.Items.Clear();
        comboBox2.Items.Add("Scheduled");
        comboBox2.Items.Add("Modified");
        comboBox2.Items.Add("Canceled");
        comboBox2.Items.Add("Completed");
        comboBox2.SelectedIndex = 0;
    }

    private void LoadMyEvents()
    {
        myEvents = evenimente.Where(e => e.OrganizerUsername == user.Username).ToList();
        comboBox1.DataSource = null;
        comboBox1.DisplayMember = nameof(Event.EventName);
        comboBox1.DataSource = myEvents;
        if (myEvents.Count == 0)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
            MessageBox.Show("You don't have any events,create an event first");
            return;
        }
        comboBox1.SelectedIndex = 0;
    }
    private Event? GetSelectedEvent()
    {
        return comboBox1.SelectedItem as Event;
    }
    private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        SyncStatusWithSelectedEvent();
    }
    private void SyncStatusWithSelectedEvent()
    {
        var ev = GetSelectedEvent();
        if (ev == null) return;
        string currentStatus = ev.EventStatus ?? "Scheduled";
        // alegem în combo statusul curent
        for (int i = 0; i < comboBox2.Items.Count; i++)
        {
            if (comboBox2.Items[i]!.ToString()!.Equals(currentStatus, StringComparison.OrdinalIgnoreCase))
            {
                comboBox2.SelectedIndex = i;
                return;
            }
        }
        // dacă nu gssim statusul, punem scheduled by default
        comboBox2.SelectedIndex = 0;
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        var ev = GetSelectedEvent();
        if (ev == null)
        {
            MessageBox.Show("Choose an event first");
            return;
        }
        string newStatus = comboBox2.SelectedItem?.ToString() ?? "";
        if (string.IsNullOrWhiteSpace(newStatus))
        {
            MessageBox.Show("Choose a status.");
            return;
        }
        // confirmare dacă anuleaza
        if (newStatus.Equals("Canceled", StringComparison.OrdinalIgnoreCase))
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to cancel this event?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
            {
                return;
            }
        }
        ev.EventStatus = newStatus;
        EventsStore.SaveEvents(evenimente, eventsPath, options);
        MessageBox.Show("Status updated and saved!");
    }

    private void button2_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
