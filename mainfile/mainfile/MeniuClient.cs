namespace mainfile;

public partial class MeniuClient : Form
{
    public MeniuClient()
    {
        InitializeComponent();
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        button5.Click += button5_Click;
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        //var f = new SearchEvents();//urmeaza sa o fac
        MessageBox.Show("Urmeaza");
        //f.ShowDialog();
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        //var f = new ViewEventdetail();//urmeaza sa o fac
        //f.ShowDialog();
        MessageBox.Show("Urmeaza");
    }
    private void button3_Click(object? sender, EventArgs e)
    {
        /*var f = new BuyingTickets();//urmeaza sa o fac
        f.ShowDialog();*/
        MessageBox.Show("Urmeaza");
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        /*var f = new ManageTickets();//urmeaza sa o fac
        f.ShowDialog();*/
        MessageBox.Show("Urmeaza");
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}