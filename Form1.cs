﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Cashback2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gigio = JsonConvert.DeserializeObject<Deserializzazione>(File.ReadAllText("utenti.json"));
            amogus = JsonConvert.DeserializeObject<DeserCarte>(File.ReadAllText("cartedicredito.json"));
        }

        public Deserializzazione gigio = new Deserializzazione();   //tutto il file
        public Persona astolfo = new Persona();     //singola persona

        public DeserCarte amogus = new DeserCarte();
        public Carta bigchungus = new Carta();
        internal static string json;

        private void Login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gigio.Utenti.Count; i++)
            {
                if (gigio.Utenti[i].Username == textBox1.Text & gigio.Utenti[i].Password == textBox2.Text)
                {
                    User.BringToFront();
                    Login.Enabled = false;
                    astolfo = gigio.Utenti[i];
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registrazione.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)  //registrazione
        {
            string username, password;
            json = File.ReadAllText("utenti.json");
            Deserializzazione Utenti = JsonConvert.DeserializeObject<Deserializzazione>(json);
            
            if (string.IsNullOrWhiteSpace(textBox3.Text) && string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("I campi non possono essere vuoti");
                return;
            }

            username = textBox3.Text;
            password = textBox4.Text;

            if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Le password non coincidono");
                return;
            }

            /////fine//////
            for (int i = 0; i < gigio.Utenti.Count; i++)
            {
                if (gigio.Utenti[i].Username == username)
                {
                    MessageBox.Show("Username non disponibile");
                    return;
                }
            }
            gigio.Utenti.Add(new Persona { Username = username, Password = password });
            File.WriteAllText("utenti.json", JsonConvert.SerializeObject(gigio, Formatting.Indented));

            Carte.BringToFront();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)  //aggiunta carte
        {
            string carta, nome, cognome, cvc, mese, anno;
            json = File.ReadAllText("cartedicredito.json");
            DeserCarte Carte = JsonConvert.DeserializeObject<DeserCarte>(json);

            if (string.IsNullOrWhiteSpace(textBox6.Text) && string.IsNullOrWhiteSpace(textBox7.Text) && string.IsNullOrWhiteSpace(textBox8.Text)
                && string.IsNullOrWhiteSpace(textBox9.Text) && string.IsNullOrWhiteSpace(textBox10.Text) && string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("I campi non possono essere vuoti");
                return;
            }

            carta = textBox6.Text;
            nome = textBox7.Text;
            cognome = textBox8.Text;
            cvc = textBox9.Text;
            mese = textBox10.Text;
            anno = textBox11.Text;

            //////controllo finale///////
            for (int i = 0; i < amogus.Carte.Count; i++)
            {
                if (amogus.Carte[i].Numero == carta)
                {
                    MessageBox.Show("La carta non può essere doppia");
                    return;
                }
            }

            amogus.Carte.Add(new Carta { Nome = nome, Cognome = cognome, Numero = carta, CVC = cvc, Anno = anno, Mese = mese});
            File.WriteAllText("cartedicredito.json", JsonConvert.SerializeObject(amogus, Formatting.Indented));

            MessageBox.Show("La carta è stata aggiunta");
            Login.BringToFront();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Carte_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class Deserializzazione
    {
        public List<Persona> Utenti { get; set; }
    }

    public class DeserCarte
    {
        public List<Carta> Carte { get; set; }
    }
    public class Persona
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Carta1 { get; set; }
        public string Carta2 { get; set; }
        public string Carta3 { get; set; }
    }

    public class Carta
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Numero { get; set; }
        public string CVC { get; set; }
        public string Mese { get; set; }
        public string Anno { get; set; }
    }
}
