namespace mainfile;

using Microsoft.Extensions.Logging;
public partial class Activetickets : Form
{
    private readonly ILogger<Activetickets> logger;
    private readonly User user;
    private readonly List<Event> evenimente;
    public Activetickets(User user, List<Event> evenimente)
    {
        InitializeComponent();
        
        logger = Program.LoggerFactory.CreateLogger<Activetickets>();
        
        this.user = user;
        this.evenimente = evenimente;
        button1.Click += button1_Click;
        
        logger.LogInformation("Active tickets form opened for {Username}", user.Username);
        
        LoadActiveTickets();
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
    private void LoadActiveTickets()
    {
        listBox1.Items.Clear();

        if (user is not Client client)
        {
            logger.LogWarning("Non client attempted to view active tickets");
            
            listBox1.Items.Add("Only clients have active tickets");
            return;
        }

        if (client.Tichetemele == null || client.Tichetemele.Count == 0)
        {
            logger.LogInformation("Client has no tickets");
            listBox1.Items.Add("You have no active tickets");
            return;
        }
        var activeTickets = from t in client.Tichetemele let ev = evenimente.FirstOrDefault(e => e.EventName == t.EventName) where ev != null && IsEventActive(ev) select new { Ticket = t, Event = ev };
        if (!activeTickets.Any())// vedem care sunt active
        {
            logger.LogInformation("Client has no active tickets after filtering");
            listBox1.Items.Add("You have no active tickets");
            return;
        }
        foreach (var x in activeTickets)
        {
            var t = x.Ticket;
            var ev = x.Event;
            listBox1.Items.Add($"{ev.EventName} | {t.CategoryName} | {t.PricePaid}$ | {ev.EventDate:yyyy-MM-dd} | ID: {t.TicketId}");
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        logger.LogInformation("Active tickets form closed");
        this.Close();
    }
}