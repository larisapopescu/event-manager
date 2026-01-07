namespace mainfile;
public partial class ModifyEvent : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    // lista filtrata(doar ale organizatorului)
    private List<Event> myEvents = new();
    public ModifyEvent(User user, List<Event> evenimente)
    {
        InitializeComponent();
        this.user = user;
        this.evenimente = evenimente;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        LoadMyEvents();
    }
    private void LoadMyEvents()
    {
        myEvents = evenimente.Where(e => e.OrganizerUsername == user.Username).ToList();
        comboBox1.DataSource = null;
        comboBox1.DisplayMember = nameof(Event.EventName);
        comboBox1.DataSource = myEvents;
        if (myEvents.Count == 0)
        {
            MessageBox.Show("You don't have any events to modify.");
            button1.Enabled = false;
        }
        comboBox1.SelectedIndex = 0;// selectam primul element
        LoadSelectedEventToInputs();
    }
    private void LoadSelectedEventToInputs()
    {
        if (comboBox1.SelectedItem is not Event ev) return;
        textBox1.Text = ev.EventName;// default aratam valorile curente
        textBox2.Text = ev.EventDescription;
        textBox3.Text = ev.EventLocation;
        dateTimePicker1.Value = ev.EventDate;
        numericUpDown1.Value = ev.EventCapacity > 0 ? ev.EventCapacity : 1;
    }
    private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        LoadSelectedEventToInputs();
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        if (comboBox1.SelectedItem is not Event ev)
        {
            MessageBox.Show("Choose an event first");
            return;
        }
        string newName = textBox1.Text.Trim();
        string newDesc = textBox2.Text.Trim();
        string newLoc  = textBox3.Text.Trim();
        bool changeDate = dateTimePicker1.Checked;
        DateTime newDate = dateTimePicker1.Value;
        bool changeCapacity = false;
        if (Controls.Find("checkCapacity", true).FirstOrDefault() is CheckBox cb)
        {
            changeCapacity = cb.Checked;
        }
        int newCap = (int)numericUpDown1.Value;
        if (!string.IsNullOrWhiteSpace(newName) && newName.Length < 2)
        {
            MessageBox.Show("New name is too short.");
            return;
        }
        if (changeDate && newDate < DateTime.Now)
        {
            MessageBox.Show("Event date must be in the future.");
            return;
        }
        if (changeCapacity && newCap <= 0)
        {
            MessageBox.Show("Capacity must be > 0.");
            return;
        }
        string finalName = string.IsNullOrWhiteSpace(newName) ? "" : newName;
        string finalDesc = string.IsNullOrWhiteSpace(newDesc) ? "" : newDesc;
        string finalLoc  = string.IsNullOrWhiteSpace(newLoc)  ? "" : newLoc;
        DateTime finalDate = changeDate ? newDate : DateTime.MinValue;
        int finalCap = changeCapacity ? newCap : ev.EventCapacity;
        bool changed = !ev.EventName.Equals(newName, StringComparison.Ordinal) || !ev.EventDescription.Equals(newDesc, StringComparison.Ordinal) || !ev.EventLocation.Equals(newLoc, StringComparison.Ordinal) || ev.EventDate != newDate || ev.EventCapacity != newCap;
        if (!changed)// aici verificam daca cumva s au produs modificari
        {
            MessageBox.Show("No changes to save");
            return;
        }
        try
        {
            ev.UpdateDetails(finalName, finalDesc, finalLoc, finalDate, finalCap);

            MessageBox.Show("Changes saved");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Update failed: {ex.Message}");
        }
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
