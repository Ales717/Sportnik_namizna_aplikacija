using Naloga3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Naloga3
{
    public partial class Tekmovanja : Form
    {
        int id;
        string izbira;
        public Tekmovanja(int id, string izbira)
        {
            InitializeComponent();
            this.id = id;
            this.izbira = izbira;
        }

        private async void Tekmovanja_Load(object sender, EventArgs e)
        {
            if (izbira == "U/D")
            {
                label1.Text = "ID: " + id.ToString();
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Tekmovanja/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    Tekmovanje tekmovanje = JsonConvert.DeserializeObject<Tekmovanje>(json);
                    textBox1.Text = tekmovanje.ime;
                    textBox2.Text = tekmovanje.leto_izvedbe;
                    textBox3.Text = tekmovanje.tip;
                }
                else
                {
                    MessageBox.Show("Error retrieving tekmovanja.");
                }
            }
            else
            {
                label1.Hide();
                button1.Text = "Dodaj";
                button2.Hide();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (izbira == "U/D")
            {
                HttpClient client = new HttpClient();

                var data = new
                {
                    id = id,
                    ime = textBox1.Text,
                    leto_izvedbe = textBox2.Text,
                    tip = textBox3.Text
                };

                string json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("https://localhost:7257/api/Tekmovanja/" + id, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("API call successful.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("API call failed.");
                }
            }
            else
            {
                HttpClient client = new HttpClient();

                var data = new
                {
                    ime = textBox1.Text,
                    leto_izvedbe = textBox2.Text,
                    tip = textBox3.Text
                };

                string json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:7257/api/Tekmovanja", content);
                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("API call successful.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("API call failed.");
                }
            }
            
        }



        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7257/api/Tekmovanja/" + id);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("API call successful.");
                this.Close();
            }
            else
            {
                MessageBox.Show("API call failed.");
            }
        }

        private void Tekmovanja_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Main form2 = new Main();
            form2.Show();
        }
    }
}
