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

namespace Apriori
{
    public partial class Apriori : Form
    {
        List<Paragon> daneZPliku = null;
        public Apriori()
        {
            InitializeComponent();
            
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        { var wynik = aprioriOFD.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                

                string[] trescPliku = null;
                trescPliku = System.IO.File.ReadAllLines(aprioriOFD.FileName);
                //Paragon[] daneZPliku = null;
                //daneZPliku = new Paragon[trescPliku.Length];
                daneZPliku= new List<Paragon>();
                for (int i = 0; i < trescPliku.Length; i++)
                {
                    string[] words = trescPliku[i].Split(' ');
                    List<string> listaZakupow = new List<string>();

                    foreach (var word in words)
                    {
                        if (word!="")
                        {
                            listaZakupow.Add(word);
                        }                        
                    }
                    if (listaZakupow.Count()>0)
                    {
                        daneZPliku.Add(new Paragon(listaZakupow));
                    }
                    
                }
                aprioriTxtBox.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(aprioriOFD.FileName), aprioriOFD.FileName);
            }

          }

        private void button1_Click(object sender, EventArgs e)
        {
            AprioriAlg apriori = new AprioriAlg(daneZPliku, 2);
            apriori.znajdzZbiorZdarzenCzestych();
            apriori.stworzZbiorC2();
            apriori.znajdzKombinacjeF2();
            apriori.utworzZbiorC3();
            apriori.znajdzKombinacjeF3();
            apriori.zapiszReguly();
            foreach (var item in apriori.reguly)
            {
                apriori.znajdzsupportReguly(item);
            }

        }
      }
}
