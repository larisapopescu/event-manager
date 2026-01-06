namespace mainfile;
using System.IO;
public partial class CreateEvent : Form
{
    private readonly User user;
    private readonly List<Event> evenimente;
    private string? selectedImagePath;
    public CreateEvent(User user, List<Event> evenimente)
    {
        InitializeComponent();
        button1.Click += button1Image_Click;
        button2.Click += buttonCreate_Click;
        button3.Click += button3_Click;
        this.user = user ?? throw new ArgumentNullException(nameof(user));
        this.evenimente = evenimente ?? new List<Event>();
    }
    private void button1Image_Click(object sender, EventArgs e)
    {
        using var openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Title = "Choose image";
        openFileDialog1.Filter="Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";// aici lasam utilizatorul sa aleaga doar fisiere de tip imagine
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = openFileDialog1.FileName;
            pictureBox1.ImageLocation=selectedImagePath;
        } 
    }
    private void buttonCreate_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text.Trim();
        string description=textBox2.Text.Trim();
        string location=textBox3.Text.Trim();
        DateTime data = dateTimePicker1.Value;
        int capacitate = (int)numericUpDown1.Value;
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Event name is required");
            return;
        }
        if (data < DateTime.Now)
        {
            MessageBox.Show("Event date must be in the future");
            return;
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Event description is required");
            return;
        }

        if (string.IsNullOrWhiteSpace(location))
        {
            MessageBox.Show("Event location is required");
            return;
        }
        if (capacitate <= 0)
        {
            MessageBox.Show("Capacity must be > 0");
            return;
        }
        string? savedImagePath = null;// copiez imaginea in folderul aplicatiei
        if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
        {
            string imagesDir = Path.Combine(AppContext.BaseDirectory, "event_images");
            Directory.CreateDirectory(imagesDir);
            // nume unic ca să nu se suprascrie
            string ext = Path.GetExtension(selectedImagePath);
            string fileName = $"{Guid.NewGuid()}{ext}";
            string destPath = Path.Combine(imagesDir, fileName);
            File.Copy(selectedImagePath, destPath, overwrite: true);
            savedImagePath = destPath; // asta o salvam în event
        }
        var ev = new Event(EventName: name, EventDescription: description, EventLocation: location, EventStatus: "scheduled", EventDate: data, EventCapacity: capacitate, OptiuniTichete: new List<TicketType>(), OrganizerUsername: user.Username, ImagePath: savedImagePath);
        evenimente.Add(ev);
        MessageBox.Show("Event created successfully!");
        this.DialogResult = DialogResult.OK; // spune ca s a creat
        this.Close();
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
    
}