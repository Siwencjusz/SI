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

namespace Reguły__decyzyjne
{
    public partial class regulyDecyzyjne : Form
    {
        public Obiekt[] daneZPliku = null;
        public string strinIle = "";
        public regulyDecyzyjne()
        {
            InitializeComponent();
            btnRun.Enabled = false;
            exhaustivBtn.Enabled = false;
            lem2ChckBox.Enabled = false;
            coveringBox.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var wynik = oFDData.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                string[] trescPliku = null;
                trescPliku = System.IO.File.ReadAllLines(oFDData.FileName);              
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
                path1.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(oFDData.FileName), oFDData.FileName);


                btnRun.Enabled = true;
                exhaustivBtn.Enabled = true;
                lem2ChckBox.Enabled = true;
                coveringBox.Enabled = true;
            }

            }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (daneZPliku == null)
                MessageBox.Show("Paramtry zostały podane nieodpowiednio");
            else
            {
                if (coveringBox.Checked)
                {
                    Covering cover = new Covering(daneZPliku);
                    cover.szukajRegul();
                    cover.wypiszReguły();
                }
                if (exhaustivBtn.Checked)
                {
                    Exhaustiv exhaust = new Exhaustiv(daneZPliku);
                    exhaust.szukajRegul();
                    exhaust.wypiszReguły();
                }
                if (lem2ChckBox.Checked)
                {
                    LEM2 Lem = new LEM2(daneZPliku);
                    Lem.znajdzReguly();
                    Lem.wypiszReguły();
                }
                else
                {
                    MessageBox.Show("Nie wybrano reguły");
                }
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void coveringBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        
    }
}
