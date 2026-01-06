namespace mainfile;

public partial class SalesStatus : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    private List<Event> myEvents = new();

    public SalesStatus(User user, List<Event> evenimente)
    {
        InitializeComponent();

        this.user = user ?? throw new ArgumentNullException(nameof(user));// daca e null aplicatia se opreste
        this.evenimente = evenimente ?? throw new ArgumentNullException(nameof(evenimente));
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        button1.Click += button1_Click;
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
            comboBox1.Enabled = false;
            label3.Text = "You don't have any events.";
            return;
        }
        comboBox1.SelectedIndex = 0;
        UpdateSalesInfo(myEvents[0]);
    }
    private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboBox1.SelectedItem is Event ev)
        {
            UpdateSalesInfo(ev);
        }
    }
    private void UpdateSalesInfo(Event ev)
    {
        int capacity = ev.EventCapacity;
        int totalSold = 0;
        decimal totalRevenue = 0m;
        foreach (var t in ev.OptiuniTichete)
        {
            totalSold += t.SoldCount;
            totalRevenue += t.SoldCount * t.Price;
        }
        int available = capacity - totalSold;
        if (available < 0)
        {
            available = 0;
        }
        label3.Text = $"Event: {ev.EventName}\n" + $"Status: {ev.EventStatus}\n\n" + $"Capacity: {capacity}\n" + $"Tickets sold: {totalSold}\n" + $"Available: {available}\n" + $"Revenue: {totalRevenue}$\n\n"  + $"{FormatType(ev, "VIP")}\n" + $"{FormatType(ev, "Standard")}\n" + $"{FormatType(ev, "Early Bird", "Early Access")}";
    }
    private string FormatType(Event ev, string name, string? alt = null)
    {
        var t = ev.OptiuniTichete.FirstOrDefault(x =>
            x.CategoryName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
            (!string.IsNullOrEmpty(alt) &&
             x.CategoryName.Equals(alt, StringComparison.OrdinalIgnoreCase)));
        if (t == null)// daca nu exista tipul ala de bilet 
        {
            return $"{name}: not set";
        }
        int remaining = t.MaxQuantity - t.SoldCount;
        if (remaining < 0)
        {
            remaining = 0;
        }
        return $"{name}: Sold {t.SoldCount}/{t.MaxQuantity} | Remaining {remaining} | Price {t.Price}$";
    }

    private void button1_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
