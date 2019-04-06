using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNN_v_2
{
    public partial class KNN : Form
    {
        Dane daneTestowe=null;
        Dane daneTreningowe=null;
        public KNN()
        {
            InitializeComponent();
            this.btnRun.Enabled = false;
            this.metrykaComboBox.Enabled = false;
            numericUpDown1.Enabled = false;
            this.metrykaComboBox.DataSource = typeof(Metryki).GetMethods().Where(
                metoda => metoda.ReturnType == typeof(double) &&
                          metoda.GetParameters().Length == 2
            ).ToList();
            this.metrykaComboBox.DisplayMember = "Name";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wynik = TestOFD.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                string[] trescPliku = null;
                trescPliku = System.IO.File.ReadAllLines(TestOFD.FileName);
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
                daneTestowe = new Dane(daneZPliku);
                txtBoxWczTst.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(TestOFD.FileName), TestOFD.FileName);
                if (this.daneTreningowe != null && this.daneTestowe != null)
                {
                    List<int> iList = new List<int>();
                    for (int i = 1; i <= daneTestowe.daneZPliku[0].deskryptory.Count(); i++)
                    {
                        iList.Add(i);
                    }
                    numericUpDown1.Maximum = iList.Count;
                    numericUpDown1.Enabled = true;
                    this.metrykaComboBox.Enabled = true;
                    this.btnRun.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var wynik = TreningOFD.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                string[] trescPliku = null;
                trescPliku = System.IO.File.ReadAllLines(TreningOFD.FileName);
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
                daneTreningowe = new Dane(daneZPliku);
                txtBoxTrening.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(TreningOFD.FileName), TreningOFD.FileName);
                if (this.daneTreningowe != null && this.daneTestowe != null)
                {
                    List<int> iList = new List<int>();
                    for (int i = 1; i <= daneTestowe.daneZPliku[0].deskryptory.Count(); i++)
                    {
                        iList.Add(i);
                    }
                    numericUpDown1.Maximum = iList.Count;
                    numericUpDown1.Enabled = true;

                    this.metrykaComboBox.Enabled = true;
                    this.btnRun.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Metryka metryka =  (Metryka)Metryka.CreateDelegate(typeof(Metryka), this.metrykaComboBox.SelectedItem as MethodInfo);
            SystemDecyzyjnycs sysDec = new SystemDecyzyjnycs(daneTestowe, daneTreningowe,(int)numericUpDown1.Value,metryka);
            sysDec.ileKlas();
            sysDec.liczMetryki();
            sysDec.rozdzielKlasymetryk();
            sysDec.zweryfikujK();
            sysDec.klasyfikujObiekty();
            sysDec.SprawdzObiekty();
            sysDec.liczElemntyMacierzyPredykcji();
            sysDec.wypiszMacierzPredykcji();
        }

        private void KNN_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
