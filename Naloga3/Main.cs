using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Naloga3.Models;
using Newtonsoft.Json;
using System.Data.SQLite;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Cryptography;
using System.Web;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Naloga3
{
    public partial class Main : Form
    {
        private readonly string connectionString = "Data Source=C:\\Users\\prose\\OneDrive\\Namizje\\feri\\Orodja za razvoj aplikacij\\Naloga3\\Naloga3\\baza.db;";
        private SQLiteConnection _connection;

        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _connection = new SQLiteConnection(connectionString);
            label4.Text = "Dodaj Tekmovanje:";
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            HttpClient client2 = new HttpClient();

            HttpResponseMessage response2 = await client2.GetAsync("https://localhost:7257/api/Users");

            if (response2.IsSuccessStatusCode)
            {
                string json = await response2.Content.ReadAsStringAsync();

                List<Models.User> users = JsonConvert.DeserializeObject<List<Models.User>>(json);

                foreach (Models.User user in users)
                {
                    listBox1.Items.Add($"{user.id} ({user.username})");
                }
            }
            else
            {
                MessageBox.Show("Error retrieving tekmovanja.");
            }

            /*await _connection.OpenAsync();
            using (var command = new SQLiteCommand("SELECT id, username FROM users", _connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32(0);
                    string username = reader.GetString(1);
                    listBox1.Items.Add($"{id} - {username}");
                }
            }
            */

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Tekmovanja");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<Tekmovanje> tekmovanja = JsonConvert.DeserializeObject<List<Tekmovanje>>(json);

                dataGridView1.DataSource = tekmovanja;
            }
            else
            {
                MessageBox.Show("Error retrieving tekmovanja.");
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tekmovanja")
            {
                label4.Text = "Dodaj Tekmovanje:";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Tekmovanja");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Tekmovanje> tekmovanja = JsonConvert.DeserializeObject<List<Tekmovanje>>(json);

                    dataGridView1.DataSource = tekmovanja;
                }
                else
                {
                    MessageBox.Show("Error retrieving tekmovanja.");
                }
            }
            if (comboBox1.Text == "Rezultati")
            {
                label4.Text = "Dodaj Rezultat:";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Rezultati");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Rezultati> rezultati = JsonConvert.DeserializeObject<List<Rezultati>>(json);


                    dataGridView1.DataSource = rezultati;
                }
                else
                {
                    MessageBox.Show("Error retrieving tekmovanja.");
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedUser = listBox1.SelectedItem.ToString();
                int id = int.Parse(selectedUser.Substring(0, selectedUser.IndexOf("(") - 1));
                this.Hide();
                Users userForm = new Users(id);
                userForm.ShowDialog();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            string password = textBox2.Text;

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }
            string hash = Convert.ToBase64String(hashBytes);

            HttpClient client = new HttpClient();

            var data = new
            {
                username = textBox1.Text,
                password = hash,
                isadmin = checkBox1.Checked.ToString()
            };

            string json = JsonConvert.SerializeObject(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhost:7257/api/Users", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("API call successful.");
                //this.Close();
            }
            else
            {
                MessageBox.Show("API call failed.");
            }
            listBox1.Items.Clear();
            HttpClient client2 = new HttpClient();

            HttpResponseMessage response2 = await client2.GetAsync("https://localhost:7257/api/Users");

            if (response2.IsSuccessStatusCode)
            {
                string json2 = await response2.Content.ReadAsStringAsync();

                List<Models.User> users = JsonConvert.DeserializeObject<List<Models.User>>(json2);

                foreach (Models.User user in users)
                {
                    listBox1.Items.Add($"{user.id} ({user.username})");
                }
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            _connection.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Tekmovanja/ime/" + textBox3.Text);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Tekmovanje> tekmovanja = JsonConvert.DeserializeObject<List<Tekmovanje>>(json);

                    dataGridView1.DataSource = tekmovanja;
                }
                else
                {
                    MessageBox.Show("Error retrieving tekmovanja.");
                }
            }
            else
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Rezultati/rezultati/ime_tekmovalca/" + textBox3.Text);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Rezultati> rezultati = JsonConvert.DeserializeObject<List<Rezultati>>(json);

                    dataGridView1.DataSource = rezultati;
                }
                else
                {
                    MessageBox.Show("Error retrieving tekmovanja.");
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            int id = Convert.ToInt32(row.Cells[0].Value);
            string izbira = "U/D";

            if (comboBox1.SelectedIndex == 0)
            {
                this.Hide();
                Tekmovanja newForm = new Tekmovanja(id,izbira);
                newForm.ShowDialog();
            }
            else
            {
                this.Hide();
                Rezultat form = new Rezultat(id, izbira);
                form.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            string izbira = "ADD";
            if (comboBox1.SelectedIndex == 0)
            {
                this.Hide();
                Tekmovanja newForm = new Tekmovanja(id, izbira);
                newForm.ShowDialog();
            }
            else
            {
                this.Hide();
                Rezultat form = new Rezultat(id, izbira);
                form.ShowDialog();
            }
        }
    }
}
