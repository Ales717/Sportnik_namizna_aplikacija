using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace Naloga3
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = "Data Source=C:\\Users\\prose\\OneDrive\\Namizje\\feri\\Orodja za razvoj aplikacij\\Naloga3\\Naloga3\\baza.db;";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }
            string hash = Convert.ToBase64String(hashBytes);

            HttpClient client = new HttpClient();
            string url = $"https://localhost:7257/api/Users?username={username}&password={hash}";
            HttpResponseMessage response = await client.GetAsync(url);


            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<Models.User> users = JsonConvert.DeserializeObject<List<Models.User>>(json);

                if (users.Count > 0 && users[0].isadmin == "True")
                {
                    MessageBox.Show("Login successful!");
                    this.Hide();
                    var form2 = new Main();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();

                }
                else
                {
                    MessageBox.Show("Invalid username/password or the user is not admin.");
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}