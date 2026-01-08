using Microsoft.Extensions.Logging;

namespace mainfile;

public partial class History : Form
{
    private readonly ILogger<History> logger;
    private readonly User user;

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
        if (user is not Client client)
        {
            logger.LogWarning("History opened by non-client");
            listBox1.Items.Add("Only clients have purchase history.");
            return;
        }

        logger.LogInformation("Loaded {Count} tickets in history", client.Tichetemele?.Count ?? 0);
    }

    private void button1_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("History closed");
        Close();
    }
}