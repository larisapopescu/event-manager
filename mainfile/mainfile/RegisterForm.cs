using System.Text.Json;

namespace mainfile;

public partial class RegisterForm : Form
{
    private readonly string usersPath;
    private readonly JsonSerializerOptions options;

    public RegisterForm(string usersPath, JsonSerializerOptions options)
    {
        InitializeComponent();
        this.usersPath = usersPath;
        this.options = options;
        radioButton2.Checked = true; // default client
        button1.Click += button1_Click;
    }
    private void button1_Click(object? sender, EventArgs e)
    {
        string username = textBox1.Text.Trim();// trim vede spatiile de la username la fel 
        string password = textBox2.Text;
        bool isOrganizer = radioButton1.Checked;
        List<User> utilizatori = AuthService.LoadUsers(usersPath, options);
        var (ok, err) = AuthService.RegisterWithCredentials(utilizatori, username, password, isOrganizer, usersPath, options);
        if (!ok)
        {
            MessageBox.Show(err);
            return;
        }
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}