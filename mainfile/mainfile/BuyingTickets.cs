namespace mainfile;
using System.Text.Json;
public partial class BuyingTickets : Form
{
    private readonly User user;                 
    private readonly List<User> utilizatori;    
    private readonly List<Event> evenimente;  
    private readonly string usersPath;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    private List<Event> availableEvents = new();// lista cu evenimente de la care pot cumpara bilete
    public BuyingTickets(  User user, List<User> utilizatori, List<Event> evenimente, string usersPath, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        this.user = user;
            this.utilizatori =utilizatori;
            this.evenimente = evenimente;
            this.usersPath = usersPath;
            this.eventsPath = eventsPath;
            this.options = options;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; 
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        numericUpDown1.Minimum = 1;
        numericUpDown1.Value = 1;// initial valorile sunt 1
        LoadAvailableEvents();
    }
    private bool IsEventBuyable(Event ev)// daca e canceled sau completed nu mai poti lua bilet
    {
        string st = (ev.EventStatus ?? "").Trim();
        bool locked = st.Equals("Canceled", StringComparison.OrdinalIgnoreCase) || st.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) || st.Equals("Completed", StringComparison.OrdinalIgnoreCase)|| st.Equals("cancelled", StringComparison.OrdinalIgnoreCase)|| st.Equals("canceled", StringComparison.OrdinalIgnoreCase)|| st.Equals("completed", StringComparison.OrdinalIgnoreCase);
        bool inPast = ev.EventDate.Date < DateTime.Now.Date;
        return !locked && !inPast;
    }
    private void LoadAvailableEvents()
    {
        availableEvents = evenimente.Where(IsEventBuyable).ToList();
        comboBox1.DataSource = null;
        if (availableEvents.Count == 0)
        {
            MessageBox.Show("No events available for buying tickets");
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            return;
        }
        comboBox1.DisplayMember = nameof(Event.EventName);
        comboBox1.DataSource = availableEvents;
        comboBox1.SelectedIndex = 0; // declanseaza select
    }
    private Event? GetSelectedEvent()
    {
        return comboBox1.SelectedItem as Event;
    }

    private TicketType? GetSelectedTicketType()
    {
        return comboBox2.SelectedItem as TicketType;
    }
    
    private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)// cand schimbam eventul
    {
        var ev = GetSelectedEvent();
        if (ev == null) return;
        LoadTicketTypes(ev); // pune tipurile de bilet 
    }
    private void LoadTicketTypes(Event ev)// biletele disponibile
    {
        comboBox2.DataSource = null;
        comboBox2.Items.Clear();
        if (ev.OptiuniTichete == null || ev.OptiuniTichete.Count == 0)
        {
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            MessageBox.Show("This event has no ticket types yet");
            return;
        }
        var typesAvailable = ev.OptiuniTichete.Where(t => (t.MaxQuantity - t.SoldCount) > 0).ToList();
        if (typesAvailable.Count == 0)
        {
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            MessageBox.Show("All ticket types are sold out for this event");
            return;
        }
        comboBox2.Enabled = true;
        numericUpDown1.Enabled = true;
        button1.Enabled = true;
        comboBox2.DisplayMember = nameof(TicketType.CategoryName);
        comboBox2.DataSource = typesAvailable;
        comboBox2.SelectedIndex = 0; // declanseaza cantitate max
    }
    private void comboBox2_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var tt = GetSelectedTicketType();// dupa ce am cumparat un nr de bilete ajustam cantitatea maxima pe care clientul o poate cumpara
        if (tt == null)
        {
            return;
        }
        int remaining = tt.MaxQuantity - tt.SoldCount;
        if (remaining < 1)
        {
            remaining = 1;
        }
        numericUpDown1.Minimum = 1;
        numericUpDown1.Maximum = remaining;
        numericUpDown1.Value = 1;
    }
    
    private void button1_Click(object? sender, EventArgs e)
    {
        if (user is not Client client)
        {
            MessageBox.Show("Only clients can buy tickets");
            return;
        }
        var ev = GetSelectedEvent();
        var tt = GetSelectedTicketType();
        if (ev == null || tt == null)
        {
            MessageBox.Show("Choose an event and a ticket type");
            return;
        }
        if (!int.TryParse(numericUpDown1.Text, out int qtyTyped))
        {
            MessageBox.Show("Invalid quantity");
            return;
        }
        int remaining = tt.MaxQuantity - tt.SoldCount;
        if (qtyTyped <= 0)
        {
            MessageBox.Show("Quantity must be at least 1");
            return;
        }
        if (qtyTyped > remaining)
        {
            MessageBox.Show($"Not enough tickets. Remaining: {remaining}");
            return;
        }
        int qty = qtyTyped;
        try
        {
            // cumparam qty bilete crestem SoldCount si adaugam in wallet
            for (int i = 0; i < qty; i++)
            {
                tt.IncrementSales();
                client.AddTicket(new Ticket(ev.EventName, tt.CategoryName, tt.Price));
            }
            
            EventsStore.SaveEvents(evenimente, eventsPath, options); 
            AuthService.Save(utilizatori, usersPath, options);
            MessageBox.Show($"Successfully bought {qty} ticket(s) for {ev.EventName}!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Purchase failed: {ex.Message}");
            return;
        }
        
        LoadTicketTypes(ev);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}