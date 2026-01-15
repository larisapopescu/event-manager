namespace mainfile;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;


public partial class CreateEvent : Form
{
    private readonly ILogger<CreateEvent> logger;
    private readonly User user;
    private readonly List<Event> evenimente;
    private string? selectedImagePath;

    public CreateEvent(User user, List<Event> evenimente)
    {
        InitializeComponent();

        logger = Program.LoggerFactory.CreateLogger<CreateEvent>();
        logger.LogInformation("CreateEvent form opened");

        button1.Click += button1Image_Click;
        button2.Click += buttonCreate_Click;
        button3.Click += button3_Click;

        this.user = user;
        this.evenimente = evenimente;
    }

    private void button1Image_Click(object sender, EventArgs e)
    {
        logger.LogInformation("Image selection started");

        using var openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Title = "Choose image";
        openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = openFileDialog1.FileName;
            pictureBox1.ImageLocation = selectedImagePath;
            logger.LogInformation("Image selected: {Path}", selectedImagePath);
        }
    }

    private void buttonCreate_Click(object sender, EventArgs e)
    {
        logger.LogInformation("Create event attempt");

        string name = textBox1.Text.Trim();
        string description = textBox2.Text.Trim();
        string location = textBox3.Text.Trim();
        DateTime data = dateTimePicker1.Value;
        int capacitate = (int)numericUpDown1.Value;

        if (string.IsNullOrWhiteSpace(name))
        {
            logger.LogWarning("Event creation failed: empty name");
            MessageBox.Show("Event name is required");
            return;
        }

        if (data < DateTime.Now)
        {
            logger.LogWarning("Event creation failed: date in the past");
            MessageBox.Show("Event date must be in the future");
            return;
        }

        string? savedImagePath = null;

        if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
        {
            try
            {
                string imagesDir = Path.Combine(AppContext.BaseDirectory, "event_images");
                Directory.CreateDirectory(imagesDir);
                string ext = Path.GetExtension(selectedImagePath);
                string fileName = $"{Guid.NewGuid()}{ext}";
                string destPath = Path.Combine(imagesDir, fileName);

                File.Copy(selectedImagePath, destPath, overwrite: true);
                savedImagePath = destPath;

                logger.LogInformation("Image copied to {Path}", destPath);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to copy image");
            }
        }

        var ev = new Event(
            EventName: name,
            EventDescription: description,
            EventLocation: location,
            EventStatus: "scheduled",
            EventDate: data,
            EventCapacity: capacitate,
            OptiuniTichete: new List<TicketType>(),
            OrganizerUsername: user.Username,
            ImagePath: savedImagePath
        );

        evenimente.Add(ev);
        logger.LogInformation("Event created: {EventName}", name);

        MessageBox.Show("Event created successfully!");
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button3_Click(object? sender, EventArgs e)
    {
        logger.LogInformation("CreateEvent closed");
        Close();
    }
}
