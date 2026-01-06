namespace mainfile;
using System.Text.Json;
public partial class ManageTicketTypes : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    private List<Event> myEvents = new();

    public ManageTicketTypes(User user, List<Event> evenimente, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        this.user = user ?? throw new ArgumentNullException(nameof(user));
        this.evenimente = evenimente ?? throw new ArgumentNullException(nameof(evenimente));
        this.eventsPath = eventsPath ?? throw new ArgumentNullException(nameof(eventsPath));
        this.options = options ?? throw new ArgumentNullException(nameof(options));
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        //button3.Click += button3_Click;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        SetupTicketTypesCombo();
        LoadMyEvents();
        ResetInputs();
    }

    private void SetupTicketTypesCombo()
    {
        comboBox2.DataSource = null;
        comboBox2.Items.Clear();
        comboBox2.Items.Add("VIP");
        comboBox2.Items.Add("Standard");
        comboBox2.Items.Add("Early Bird");
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
            MessageBox.Show("You don't have any events,create an event first");
            button1.Enabled = false;
            button2.Enabled = false;
            return;
        }
        comboBox1.SelectedIndex = 0;
        var ev = GetSelectedEvent();
        if (ev != null)
        {
            UpdateEventInfo(ev);
            ResetInputs();
            ApplyLockUI(ev);
        }
    }
    private Event? GetSelectedEvent()
    {
        return comboBox1.SelectedItem as Event;
    }
    private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var ev = GetSelectedEvent();
        if (ev == null) return;
        UpdateEventInfo(ev);
        ResetInputs();// cand schimbam eventurile sa resetam inputurile
        ApplyLockUI(ev);
    }
    private void comboBox2_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var ev = GetSelectedEvent();
        if (ev == null)
        {
            return;
        }
        string typeName = comboBox2.SelectedItem?.ToString() ?? "";
        if (string.IsNullOrWhiteSpace(typeName))
        {
            return;
        }
        var existing = ev.OptiuniTichete?.FirstOrDefault(t => t.CategoryName.Equals(typeName, StringComparison.OrdinalIgnoreCase));
        if (existing != null)
        {
            numericUpDown1.Value = existing.MaxQuantity;// daca biletul exista,lasam cantitatea default
            numericUpDown2.Value = (decimal)existing.Price;
        }
        else
        {
            // daca nu exista, lasam cantitatea default
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }
    }
    private void ResetInputs()
    {
        numericUpDown1.Value = 0; // cantitate
        numericUpDown2.Value = 0; // pret
        if (comboBox2.Items.Count > 0)
        {
            comboBox2.SelectedIndex = 0;
        }
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        var ev = GetSelectedEvent();
        if (ev == null)
        {
            MessageBox.Show("Choose an event first");
            return;
        }
        string typeName = comboBox2.SelectedItem?.ToString() ?? "";
        if (string.IsNullOrWhiteSpace(typeName))
        {
            MessageBox.Show("Choose a ticket type.");
            return;
        }
        int qty = (int)numericUpDown1.Value;
        decimal price = numericUpDown2.Value;
        
        if (qty == 0)
        {
            MessageBox.Show("Nothing was saved for this ticket type");
            return;
        }
        if (price <= 0)
        {
            MessageBox.Show("Price must be > 0 when quantity is > 0");
            return;
        }
        int allocated = 0;// calculam cate bilete sunt alocate acum
        foreach (var t in ev.OptiuniTichete)
        {
            allocated += t.MaxQuantity;
        }
        var existing = ev.OptiuniTichete.FirstOrDefault(t => t.CategoryName.Equals(typeName, StringComparison.OrdinalIgnoreCase));
        int oldQty = existing?.MaxQuantity ?? 0;
        int newAllocated = allocated - oldQty + qty;// daca exista scadem
        if (newAllocated > ev.EventCapacity)
        {
            int remaining = ev.EventCapacity - (allocated - oldQty);
            MessageBox.Show($"Capacity exceeded! Remaining tickets you can allocate: {remaining}");
            return;
        }
        if (existing == null)
        {
            try
            {
                ev.AddTicketType(typeName, price, qty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed: {ex.Message}");
                return;
            }
        }
        else
        {
            int sold = existing.SoldCount;

            if (qty < sold)
            {
                MessageBox.Show($"You cannot set quantity below sold count ({sold})");
                return;
            }
            // scoatem vechiul și punem unul nou
            ev.OptiuniTichete.Remove(existing);
            ev.OptiuniTichete.Add(new TicketType(typeName, price, qty, sold));
        }
        UpdateEventInfo(ev);
        EventsStore.SaveEvents(evenimente, eventsPath, options);
        MessageBox.Show("Ticket type saved successfully!");
    }
    /*private void button3_Click(object? sender, EventArgs e)
    {
        ResetInputs();// dam reset ca sa putem adauga alt tip de bilet mai repede
    }*/
    private void button2_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
    private void UpdateEventInfo(Event ev)
    {
        int capacity = ev.EventCapacity;
        int vip = 0, standard = 0, early = 0;
        int allocated = 0;
        foreach (var t in ev.OptiuniTichete)
        {
            allocated += t.MaxQuantity;
            switch (t.CategoryName.ToLower())
            {
                case "vip":
                    vip = t.MaxQuantity;
                    break;
                case "standard":
                    standard = t.MaxQuantity;
                    break;
                case "early bird":
                case "early access":
                    early = t.MaxQuantity;
                    break;
            }
        }
        int remaining = capacity - allocated;
        if (remaining < 0)
        {
            remaining = 0;
        }
        lblEventInfo.Text = $"Capacity: {capacity}\n" + $"Allocated: {allocated} | Remaining: {remaining}\n" + $"VIP: {vip} | Standard: {standard} | Early Bird: {early}";
    }
    private bool IsLocked(Event ev)// verifica daca e calcelled sau completed ca sa nu mai poti seta bilete
    {
        var st = (ev.EventStatus ?? "").Trim();
        return st.Equals("Canceled", StringComparison.OrdinalIgnoreCase) ||
               st.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) ||
               st.Equals("Completed", StringComparison.OrdinalIgnoreCase) ||
               st.Equals("cancelled", StringComparison.OrdinalIgnoreCase) ||
               st.Equals("canceled", StringComparison.OrdinalIgnoreCase) ||
               st.Equals("completed", StringComparison.OrdinalIgnoreCase);
    }
    private void ApplyLockUI(Event ev)
    {
        bool locked = IsLocked(ev);
        button1.Enabled = !locked;
        comboBox2.Enabled = !locked;
        numericUpDown1.Enabled = !locked;
        numericUpDown2.Enabled = !locked;
        if (locked)
        {
            lblEventInfo.Text += $"\n\n This event is {ev.EventStatus}. You cannot set ticket types.";
        }
    }

}
