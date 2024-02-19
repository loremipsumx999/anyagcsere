using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        public OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Anyagcsere";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double co2 = double.Parse(textBox1.Text);
            double o2 = double.Parse(textBox2.Text);
            double rq = co2 / o2;
            listBox1.Items.Add(rq);
            if( rq < 0.8)
            {
                MessageBox.Show("A szervezeted a zsírokból nyeri az energiát!");
            }
            else if(rq > 0.8)
            {
                MessageBox.Show("A szervezeted a szénhidrátokból nyeri az energiát!");
            }
            else if( rq == 0.8)
            {
                MessageBox.Show("A légzési hányados megfelelő!");
            }
            textBox1.Clear(); textBox2.Clear() ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Anyagcsere.txt";
            saveFileDialog1.Title = "Anyagcsere";
            saveFileDialog1.InitialDirectory = "c:\\Desktop";
            saveFileDialog1.Filter = "Szövegfájlok (*.txt) | MindenFájl(*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                int i = 0;
                TextWriter tw = File.CreateText(saveFileDialog1.FileName);
                while (i < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex = i;
                    tw.WriteLine(listBox1.SelectedItem);
                    i++;
                }
                tw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Válassz egy szövegfájlt";
            openFileDialog1.Filter = "Szövegfájlok|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string text = sr.ReadToEnd();
                        listBox1.Items.Add(text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt: " + ex.Message);
                }
            }
        }
    }
}
