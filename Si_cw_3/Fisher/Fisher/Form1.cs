using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Fisher
{
    public partial class Form1 : Form
    {
        public Dane zbiorDanych=null;    
        public Form1()
        {
            InitializeComponent();
            numericUpDownFisher.Enabled = false;
            btnRun.Enabled = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if ( zbiorDanych==null)
                MessageBox.Show("Paramtry zostały podane nieodpowiednio");
            else
            {
                int ile = (int)numericUpDownFisher.Value;
                zbiorDanych.znajdzKlasy();
                zbiorDanych.ileElemntowklasy();
                zbiorDanych.obliczCKlas();
                zbiorDanych.obliczZKlas();
                zbiorDanych.obliczSCI();
                zbiorDanych.znajdzNajlepszeSeparatory(ile);
                zbiorDanych.wypiszSystemDecyzyjny(ile);
            }

        }

        private void ofdBtn_Click(object sender, EventArgs e)
        {
            var wynik = OFDfish.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                string[] trescPliku = null;
                trescPliku = System.IO.File.ReadAllLines(OFDfish.FileName);
                Obiekt[] daneZPliku = null;
                daneZPliku = new Obiekt[trescPliku.Length];

                for (int i = 0; i < trescPliku.Length; i++)
                {
                    string[] wartoscAtrybutu = trescPliku[i].Split(' ');
                    deskryptor[] listaDeskryptorów = new deskryptor[wartoscAtrybutu.Length - 1];


                    for (int j = 0; j < wartoscAtrybutu.Length - 1; j++)
                    {
                        listaDeskryptorów[j] = new deskryptor(j, int.Parse(wartoscAtrybutu[j]));
                    }
                    daneZPliku[i] = new Obiekt(int.Parse(wartoscAtrybutu[wartoscAtrybutu.Length - 1]), listaDeskryptorów);

                }
                zbiorDanych = new Dane(daneZPliku);
                path1.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(OFDfish.FileName), OFDfish.FileName);


                numericUpDownFisher.Minimum = 1;
                numericUpDownFisher.Maximum = daneZPliku[0].deskryptory.Count();
                numericUpDownFisher.Enabled = true;
                btnRun.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
