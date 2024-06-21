using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naloga3
{
    public partial class Users : Form
    {
        private readonly string connectionString = "Data Source=C:\\Users\\prose\\OneDrive\\Namizje\\feri\\Orodja za razvoj aplikacij\\Naloga3\\Naloga3\\baza.db;";

        private int id;
        public Users(int id)
        {
            InitializeComponent();
            this.id = id;
            label1.Text = id.ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7257/api/Users/" + id);

            if (response.IsSuccessStatusCode)
            {
                Main mainForm = new Main();
                mainForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to delete user.");
            }
        }

        private async void Users_Load(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            string isAdmin = "";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Users/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Models.User user = JsonConvert.DeserializeObject<Models.User>(json);
                    textBox1.Text = user.username;
                    //textBox2.Text = user.password;
                    checkBox1.Checked = Convert.ToBoolean(user.isadmin);
                }
                else
                {
                    MessageBox.Show("Error retrieving user details.");
                }
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string isAdmin = checkBox1.Checked.ToString();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }
            string hash = Convert.ToBase64String(hashBytes);

            Models.User updatedUser = new Models.User
            {
                id = id,
                username = username,
                password = hash,
                isadmin = isAdmin
            };

            string json = JsonConvert.SerializeObject(updatedUser);

            HttpClient client = new HttpClient();
            string url = $"https://localhost:7257/api/Users/{id}";
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("User updated successfully!");
                Main mainForm = new Main();
                mainForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error updating user.");
            }
        }
    }
}
