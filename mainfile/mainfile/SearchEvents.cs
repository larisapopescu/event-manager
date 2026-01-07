namespace mainfile;
using System.Text;
public partial class SearchEvents : Form
{
    private Event? selectedEvent; // event-ul selectat din listBox
    private readonly List<Event> evenimente;
    private List<Event> results = new();// rezulatele ultimei cautari
    public SearchEvents(List<Event> evenimente)
    {
        InitializeComponent();
        this.evenimente = evenimente;
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;// ne asiguram ca poza se potriveste
        comboBox1.Items.Clear();
        comboBox1.Items.Add("Name");
        comboBox1.Items.Add("Description");
        comboBox1.Items.Add("Location");
        comboBox1.Items.Add("Date");
        comboBox1.SelectedIndex = 0; // default: pe nume
        textBox1.Visible = true;
        dateTimePicker1.Visible = false;// sa nu apara si date picker
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; 
        button1.Click += button1_Click;   
        button2.Click += button2_Click;   
        button5.Click += button5_Click;                          
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;  
        ResetResults();
    }
     private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        string mode = comboBox1.SelectedItem?.ToString() ?? "Name";
        // dacă e "date", input devine dateTimePicker
        bool isDate = mode.Equals("Date", StringComparison.OrdinalIgnoreCase);
        dateTimePicker1.Visible = isDate;
        textBox1.Visible = !isDate;
        textBox1.Clear();//curatam
        ResetResults();
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        string mode = comboBox1.SelectedItem?.ToString() ?? "Name";// in functie de modul ales cautam diferit
        results = mode switch
        {
            "Name" => SearchText(ev => ev.EventName, textBox1.Text),
            "Description" => SearchText(ev => ev.EventDescription, textBox1.Text),
            "Location" => SearchText(ev => ev.EventLocation, textBox1.Text),
            "Date" => SearchByDate(dateTimePicker1.Value.Date), _ => new List<Event>()
        };
        
        listBox1.Items.Clear();
        pictureBox1.Image = null;
        label2.Text = "";
        if (results.Count == 0)
        {
            MessageBox.Show("No events found.");
            return;
        }
        foreach (var ev in results)
        {
            listBox1.Items.Add($"{ev.EventName} | {ev.EventDate:yyyy-MM-dd} | {ev.EventLocation}");
        }
        listBox1.SelectedIndex = 0;// selectam automat primul rezultat ca să apara detaliile imediat
        selectedEvent = results[0];
    }
    
    private List<Event> SearchText(Func<Event, string?> selector, string queryRaw)
    {
        string query = (queryRaw ?? "").Trim();
        if (string.IsNullOrWhiteSpace(query))
        {
            MessageBox.Show("Enter text to search.");
            return new List<Event>();
        }
        return evenimente.Where(ev =>
            {
                var value = selector(ev);
                return !string.IsNullOrWhiteSpace(value) &&
                       value.Contains(query, StringComparison.OrdinalIgnoreCase);
            }).ToList();
    }
    
    private List<Event> SearchByDate(DateTime date)
    {
        return evenimente.Where(ev => ev.EventDate.Date == date).ToList();
    }
    private void listBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int idx = listBox1.SelectedIndex;
        if (idx < 0 || idx >= results.Count)
        {
            return;// daca nu e selectat nimic, iesim
        }
        selectedEvent = results[idx];
        ShowEvent(selectedEvent);  
    }
    private void ShowEvent(Event ev)
    {
        if (!string.IsNullOrWhiteSpace(ev.ImagePath) && File.Exists(ev.ImagePath))// aici la imagine, daca exista path ul spre imagine
        {
            pictureBox1.ImageLocation = ev.ImagePath;
        }
        else
        {
            pictureBox1.Image = null;
        }
        var sb = new StringBuilder();
        sb.AppendLine($"Event: {ev.EventName}");
        sb.AppendLine($"Status: {ev.EventStatus}");
        sb.AppendLine();
        sb.AppendLine($"Description: {ev.EventDescription}");
        sb.AppendLine();
        sb.AppendLine($"Location: {ev.EventLocation}");
        sb.AppendLine($"Date: {ev.EventDate:yyyy-MM-dd}");
        sb.AppendLine($"Capacity: {ev.EventCapacity}");
        sb.AppendLine($"Organizer: {ev.OrganizerUsername}");
        label2.Text = sb.ToString();
    }
    private void ResetResults()
    {
        listBox1.Items.Clear();
        pictureBox1.Image = null;
        label2.Text = "";
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        if (selectedEvent == null)
        {
            MessageBox.Show("Select an event first.");
            return;
        }
        using var f = new ViewEventDetail(selectedEvent);
        f.ShowDialog(this);
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}
