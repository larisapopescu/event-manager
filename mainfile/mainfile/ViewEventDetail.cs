namespace mainfile;
using System.Text;
using Microsoft.Extensions.Logging;
public partial class ViewEventDetail : Form
{
    private readonly ILogger<ViewEventDetail> logger;
    private readonly Event ev;
    public ViewEventDetail(Event ev)
    {
        InitializeComponent();
        
        logger = Program.LoggerFactory.CreateLogger<ViewEventDetail>();
        logger.LogInformation("ViewEventDetail opened for {Event}", ev.EventName);
        
        this.ev = ev ?? throw new ArgumentNullException(nameof(ev));
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        button1.Click += button1_Click;
        ShowEvent();
    }
    private void ShowEvent()
    {
        if (!string.IsNullOrWhiteSpace(ev.ImagePath) && File.Exists(ev.ImagePath))
        {
            pictureBox1.ImageLocation = ev.ImagePath;
        }
        else
        {
            pictureBox1.Image = null;
        }
        var sb = new StringBuilder();
        sb.AppendLine("--- EVENT DETAILS ---");
        sb.AppendLine($"Name: {ev.EventName}");
        sb.AppendLine($"Description: {ev.EventDescription}");
        sb.AppendLine($"Location: {ev.EventLocation}");
        sb.AppendLine($"Date: {ev.EventDate:yyyy-MM-dd}");
        sb.AppendLine($"Status: {ev.EventStatus}");
        sb.AppendLine($"Capacity: {ev.EventCapacity}");
        sb.AppendLine($"Organizer: {ev.OrganizerUsername}");
        sb.AppendLine();
        sb.AppendLine("---- TICKETS ----");

        if (ev.OptiuniTichete == null || ev.OptiuniTichete.Count == 0)
        {
            sb.AppendLine("No ticket types available.");
        }
        else
        {
            foreach (var t in ev.OptiuniTichete)
            {
                int remaining = t.MaxQuantity - t.SoldCount;
                if (remaining < 0)
                {
                    remaining = 0;
                }
                sb.AppendLine($"Category: {t.CategoryName} | Price: {t.Price}$ | Total: {t.MaxQuantity} | Sold: {t.SoldCount}");
            }
        }
        int totalSold = 0;
        decimal revenue = 0;
        if (ev.OptiuniTichete != null)
        {
            foreach (var t in ev.OptiuniTichete)
            {
                totalSold += t.SoldCount;
                revenue += t.SoldCount * t.Price;
            }
        }
        int available = ev.EventCapacity - totalSold;
        if (available < 0)
        {
            available = 0;
        }
        sb.AppendLine();
        sb.AppendLine("---- SUMMARY ----");
        sb.AppendLine($"Tickets sold: {totalSold}");
        sb.AppendLine($"Available: {available}");
        sb.AppendLine($"Revenue: {revenue}$");
        label3.Text = sb.ToString();
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("ViewEventDetail closed");
        this.Close();
    }
}