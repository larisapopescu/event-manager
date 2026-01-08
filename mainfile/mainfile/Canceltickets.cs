namespace mainfile;
using System.Text.Json;
using Microsoft.Extensions.Logging;
public partial class Canceltickets : Form
{
    private readonly ILogger<Canceltickets> logger;
    private readonly User user;
    private readonly List<User> utilizatori;
    private readonly List<Event> evenimente;
    private readonly string usersPath;
    private readonly string eventsPath;
    private readonly JsonSerializerOptions options;
    private List<Ticket> shownTickets = new();
    public Canceltickets(User user, List<User> utilizatori, List<Event> evenimente, string usersPath, string eventsPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        
        logger = Program.LoggerFactory.CreateLogger<Canceltickets>();
        
        this.user = user;
        this.utilizatori = utilizatori;
        this.evenimente = evenimente;
        this.usersPath = usersPath;
        this.eventsPath = eventsPath;
        this.options = options;
        button1.Click += button1_Click;
        button2.Click += button2_Click; 
        
        logger.LogInformation("Cancel tickets form opened for {Username}", user.Username);
        
        LoadTicketsIntoList();
    }
    private bool IsEventActive(Event ev)
    {
        string st = (ev.EventStatus ?? "").Trim();

        bool locked =
            st.Equals("Canceled", StringComparison.OrdinalIgnoreCase) ||
            st.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) ||
            st.Equals("Completed", StringComparison.OrdinalIgnoreCase)||
            st.Equals("completed", StringComparison.OrdinalIgnoreCase)||
            st.Equals("canelled", StringComparison.OrdinalIgnoreCase)||
            st.Equals("canceled", StringComparison.OrdinalIgnoreCase);
        bool inPast = ev.EventDate.Date < DateTime.Now.Date;
        return !locked && !inPast;
    }
    private void LoadTicketsIntoList()
    {
        listBox1.Items.Clear();
        shownTickets.Clear();
        if (user is not Client client)
        {
            logger.LogWarning("Non client attempted to cancel tickets");
            MessageBox.Show("Only clients can cancel tickets");
            button1.Enabled = false;
            return;
        }
        var allTickets = client.Tichetemele ?? new List<Ticket>();// gasim evenimentul
        foreach (var t in allTickets)
        {
            var ev = evenimente.FirstOrDefault(e => e.EventName == t.EventName);
            if (ev == null || !CanCancelTicket(ev))
            {
                continue;
            }
            shownTickets.Add(t);
            string idText = "";
            try { idText = $" | ID: {t.TicketId}"; } catch { }
            listBox1.Items.Add($"{t.EventName} | {t.CategoryName} | {t.PricePaid}$ | {t.PurchaseDate:yyyy-MM-dd}{idText}");
        }
        if (shownTickets.Count == 0)
        {
            listBox1.Items.Add("No active tickets.");
            button1.Enabled = false;
        }
        else
        {
            button1.Enabled = true;
            listBox1.SelectedIndex = 0;
        }
    }
    private void LoadActiveTickets()
    {
        listBox1.Items.Clear();
        if (user is not Client client)
        {
            return;
        }
        foreach (var t in client.Tichetemele)
        {
            listBox1.Items.Add($"{t.EventName} | {t.CategoryName} | {t.PricePaid}$ | {t.PurchaseDate:yyyy-MM-dd} | ID: {t.TicketId}");
        }
    }

    private bool CanCancelTicket(Event ev)
    {
        string st = (ev.EventStatus ?? "").Trim();
        bool locked = st.Equals("Canceled", StringComparison.OrdinalIgnoreCase) || st.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) || st.Equals("Completed", StringComparison.OrdinalIgnoreCase)|| st.Equals("completed", StringComparison.OrdinalIgnoreCase)|| st.Equals("canelled", StringComparison.OrdinalIgnoreCase)|| st.Equals("canceled", StringComparison.OrdinalIgnoreCase);
        if (locked)
        {
            return false;
        }
        TimeSpan remaining = ev.EventDate - DateTime.Now;
        if (remaining.TotalHours <= 48)
        {
            return false;
        }
        return true;
    }


    private void button1_Click(object sender, EventArgs e)
    {
        var confirm = MessageBox.Show(
            "Are you sure you want to cancel this ticket?", "Confirm cancel",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );
        if (confirm != DialogResult.Yes)
        {
            return;
        }
        int idx = listBox1.SelectedIndex;
        if (idx < 0 || idx >= shownTickets.Count)
        {
            MessageBox.Show("Select a ticket first");
            return;
        }
        var selected = shownTickets[idx];
        if (user is not Client client)
        {
            MessageBox.Show("Only clients can cancel tickets");
            return;
        }
        client.Tichetemele.Remove(selected);
        var ev = evenimente.FirstOrDefault(e => e.EventName == selected.EventName);
        if (ev != null)
        {
            var tt = ev.OptiuniTichete
                .FirstOrDefault(t => t.CategoryName == selected.CategoryName);
            if (tt != null && tt.SoldCount > 0)
            {
                tt.DecrementSales();
            }
        }
        AuthService.Save(utilizatori, usersPath, options);
        EventsStore.SaveEvents(evenimente, eventsPath, options);
        logger.LogInformation("Ticket cancelled for event {EventName}", selected.EventName);
        MessageBox.Show("Ticket cancelled successfully");
        LoadActiveTickets();
    }

    private void button2_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("Cancel tickets form closed");
        this.Close();
    }
}