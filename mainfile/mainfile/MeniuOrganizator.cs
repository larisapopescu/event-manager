namespace mainfile;

public partial class MeniuOrganizator : Form
{
    public MeniuOrganizator()
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
        /*var f = new ManageEvents();// asta urmeaza sa o fac
        f.ShowDialog(); // teoretic aici se opreste codul ca sa pot face ce trebuie facut in manageevenst*/
        MessageBox.Show("Urmeaza");
    }
    private void button2_Click(object? sender, EventArgs e)
    {
        /*var f = new ManageTyketTypes();// asta urmeaza sa o fac
        f.ShowDialog(); */
        MessageBox.Show("Urmeaza");
    }

    private void button3_Click(object? sender, EventArgs e)
    {
        /*var f = new SalesStatus(); // asta urmeaza sa o fac
        f.ShowDialog();*/
        MessageBox.Show("Urmeaza");
    }
    private void button4_Click(object? sender, EventArgs e)
    {
        /*var f = new ChangeEventStatus();// asta urmeaza sa o fac
        f.ShowDialog();*/
        MessageBox.Show("Urmeaza");
    }
    private void button5_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}