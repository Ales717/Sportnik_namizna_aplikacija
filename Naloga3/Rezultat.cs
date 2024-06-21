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

namespace Naloga3
{
    public partial class Rezultat : Form
    {
        int id;
        string izbira;
        public Rezultat(int id, string izbira)
        {
            InitializeComponent();
            this.id = id;
            label1.Text = "ID: " + id.ToString();
            this.izbira = izbira;
        }

        private void Rezultat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main form2 = new Main();
            form2.Show();
        }

        private async void Rezultat_Load(object sender, EventArgs e)
        {
            if (izbira == "U/D")
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7257/api/Rezultati/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    Rezultati rezultat = JsonConvert.DeserializeObject<Rezultati>(json);
                    textBox1.Text = rezultat.ime_tekmovalca;
                    textBox2.Text = rezultat.uvrstitev_spol;
                    textBox3.Text = rezultat.uvrstitev_kategorija;
                    textBox4.Text = rezultat.uvrstitev_skupna;
                    textBox5.Text = rezultat.bib;
                    textBox6.Text = rezultat.kategorija;
                    textBox7.Text = rezultat.starost;
                    textBox8.Text = rezultat.kraj;
                    textBox9.Text = rezultat.drzava;
                    textBox10.Text = rezultat.poklic;
                    textBox11.Text = rezultat.tocke;
                    textBox12.Text = rezultat.cas_plavanja;
                    textBox13.Text = rezultat.cas_t1;
                    textBox14.Text = rezultat.cas_kolesarjenja;
                    textBox15.Text = rezultat.cas_t2;
                    textBox16.Text = rezultat.cas_teka;
                    textBox17.Text = rezultat.skupni_cas;
                    textBox18.Text = rezultat.starostna_kategorija;
                    textBox19.Text = rezultat.komentar;
                    textBox20.Text = rezultat.tekmovanje_id.ToString();
                }
                else
                {
                    MessageBox.Show("Error retrieving tekmovanja.");
                }
            }
            else
            {
                button1.Text = "Dodaj";
                label1.Hide();
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
                    ime_tekmovalca = textBox1.Text,
                    uvrstitev_spol = textBox2.Text,
                    uvrstitev_kategorija = textBox3.Text,
                    uvrstitev_skupna = textBox4.Text,
                    bib = textBox5.Text,
                    kategorija = textBox6.Text,
                    starost = textBox7.Text,
                    kraj = textBox8.Text,
                    drzava = textBox9.Text,
                    poklic = textBox10.Text,
                    tocke = textBox11.Text,
                    cas_plavanja = textBox12.Text,
                    cas_t1 = textBox13.Text,
                    cas_kolesarjenja = textBox14.Text,
                    cas_t2 = textBox15.Text,
                    cas_teka = textBox16.Text,
                    skupni_cas = textBox17.Text,
                    starostna_kategorija = textBox18.Text,
                    komentar = textBox19.Text,
                    tekmovanje_id = Int32.Parse(textBox20.Text)

                };

                string json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("https://localhost:7257/api/Rezultati/" + id, content);

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
                    ime_tekmovalca = textBox1.Text,
                    uvrstitev_spol = textBox2.Text,
                    uvrstitev_kategorija = textBox3.Text,
                    uvrstitev_skupna = textBox4.Text,
                    bib = textBox5.Text,
                    kategorija = textBox6.Text,
                    starost = textBox7.Text,
                    kraj = textBox8.Text,
                    drzava = textBox9.Text,
                    poklic = textBox10.Text,
                    tocke = textBox11.Text,
                    cas_plavanja = textBox12.Text,
                    cas_t1 = textBox13.Text,
                    cas_kolesarjenja = textBox14.Text,
                    cas_t2 = textBox15.Text,
                    cas_teka = textBox16.Text,
                    skupni_cas = textBox17.Text,
                    starostna_kategorija = textBox18.Text,
                    komentar = textBox19.Text,
                    tekmovanje_id = Int32.Parse(textBox20.Text)

                };

                string json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:7257/api/Rezultati/", content);

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

            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7257/api/Rezultati/" + id);

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
}
