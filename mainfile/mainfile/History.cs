namespace mainfile;
using Microsoft.Extensions.Logging;
public partial class History : Form
{
    private readonly User user;
    private readonly ILogger<History> logger;
    public History(User user)
    {
        InitializeComponent();
        
        logger = Program.LoggerFactory.CreateLogger<History>();
        logger.LogInformation("History opened");
        
        this.user = user;
        button1.Click += button1_Click;
        LoadHistory();
    }
    private void LoadHistory()
    {
        listBox1.Items.Clear();
        if (user is not Client client)
        {
            logger.LogWarning("History opened by non-client");

            listBox1.Items.Add("Only clients have purchase history.");
            return;
        }
        if (client.Tichetemele == null || client.Tichetemele.Count == 0)
        {
            listBox1.Items.Add("You don't have any tickets yet.");
            return;
        }
        foreach (var t in client.Tichetemele)
        {
            listBox1.Items.Add($"{t.EventName} | {t.CategoryName} | {t.PricePaid}$ | Ticket ID: {t.TicketId}"
            );
        }
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("History closed");
        this.Close();
    }
}