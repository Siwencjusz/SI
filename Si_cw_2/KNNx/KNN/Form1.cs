using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNN
{

    public partial class Form1 : Form
    {
        public Obiekt[] systemTestowy;
        public Obiekt[] systemTreningowy;
        public string k="";
        public string metryka = "";
        public Obiekt trenObjc;
        public Obiekt tstObjc;
        public double accGlob;
        public double covGlob;
        public double cov0 = 0;
        public double cov1 = 0;
        public double acc0 = 0;
        public double acc1 = 0;
        public double tpr0 = 0;
        public double tpr1 = 0;
        public double chwytane = 0;
        public double chwytane0 = 0;
        public double chwytane1 = 0;
        public double sklasyfikowane0 = 0;
        public double sklasyfikowane1 = 0;
        public double sklasyfikowane = 0;
        public double klasa0;
        public double klasa1;
        public double niepoprawne0;
        public double poprawne1 = 0;
        public double poprawne0 = 0;
        public double niepoprawne1 = 0;
        public double bledne0;
        public double bledne1;
        public Form1()
        {
            InitializeComponent();
        }

        private void WczytajTest_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnWczTest_Click(object sender, EventArgs e)
        {
            var arrayTest = TestOFD.ShowDialog();
            if (arrayTest != DialogResult.OK)
            {
                MessageBox.Show("Brak systemu testowego"); 
                return;
            }
                
                

            if (arrayTest == DialogResult.OK)
            {
                string trescPliku = System.IO.File.ReadAllText(TestOFD.FileName);

                string[] poziomy = trescPliku.Split('\n');

                systemTestowy = new Obiekt[poziomy.Length];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    tstObjc = new Obiekt();
                    string poziom = poziomy[i].Trim();
                    string[] wartoscAtrybutu = poziom.Split(' ');
                    //systemTestowy[i] = new int[wartoscAtrybutu.Length];
                    for (int j = 0; j < wartoscAtrybutu.Length-1; j++)
                    {
                        tstObjc.listaAtrybutow.Add(int.Parse(wartoscAtrybutu[j]));

                    }
                    tstObjc.klasa=int.Parse(wartoscAtrybutu[wartoscAtrybutu.Length-1]);
                    systemTestowy[i] = tstObjc;
                }
                txtBoxTest.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(TestOFD.FileName), TestOFD.FileName);
                
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnTrenngOFD_Click(object sender, EventArgs e)
        {
            var arrayTrening = TreningOFD.ShowDialog();
            if (arrayTrening != DialogResult.OK)
            {
                MessageBox.Show("Brak systemu treningowego");
                return;
            }


            if (arrayTrening == DialogResult.OK)
            {
                //string trescPliku = System.IO.File.ReadAllText(TestOFD.FileName);

                //string[] poziomy = trescPliku.Split('\n');

                //Obiekt[] systemTreningowy = new Obiekt[poziomy.Length];

                //for (int i = 0; i < poziomy.Length; i++)
                //{
                //    Obiekt trenObjc = new Obiekt();
                //    string poziom = poziomy[i].Trim();
                //    string[] wartoscAtrybutu = poziom.Split(' ');
                //    //systemTreningowy[i] = new int[wartoscAtrybutu.Length];
                //    for (int j = 0; j < wartoscAtrybutu.Length-1; j++)
                //    {
                //        trenObjc.listaAtrybutow.Add(int.Parse(wartoscAtrybutu[j]));

                //    }
                //    trenObjc.klasa=int.Parse(wartoscAtrybutu[wartoscAtrybutu.Length-1]);
                //    systemTreningowy[i] = trenObjc;
                   
                //}
                string[] trescPliku = System.IO.File.ReadAllLines(TreningOFD.FileName);

                systemTreningowy = new Obiekt[trescPliku.Length];

                for (int i = 0; i < trescPliku.Length; i++)
                {
                    trenObjc = new Obiekt();
                    string[] wartoscAtrybutu = trescPliku[i].Split(' ');
                    for (int j = 0; j < wartoscAtrybutu.Length - 1; j++)
                    {
                        trenObjc.listaAtrybutow.Add(int.Parse(wartoscAtrybutu[j]));

                    }
                    trenObjc.klasa = int.Parse(wartoscAtrybutu[wartoscAtrybutu.Length - 1]);
                    systemTreningowy[i] = trenObjc;

                }
                txtBoxTrening.Text = string.Format("{0}/{1}",
                Path.GetDirectoryName(TreningOFD.FileName), TreningOFD.FileName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            metryka = metrykaComboBox.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            k = kNNComboBox.Text;
        }
        ////
        public double obliczOdleglosc(Obiekt testowy, Obiekt treningowy, string metryka)
        {
            if (metryka == "Metryka Manhattan")
            {
                double suma = 0;
                for (int i = 0; i < testowy.listaAtrybutow.Count(); i++)
                {
                    suma += Math.Abs(testowy.listaAtrybutow[i] - treningowy.listaAtrybutow[i]);
                }
                return suma;
            }
            if (metryka == "Metryka Euklidesowa")
            {
                double wynik = 0;
                for (int i = 0; i < testowy.listaAtrybutow.Count(); i++)
                {

                    wynik += (testowy.listaAtrybutow[i] - treningowy.listaAtrybutow[i]) * (testowy.listaAtrybutow[i] - treningowy.listaAtrybutow[i]);
                }
                return Math.Sqrt(Convert.ToDouble(wynik));

                }
            if (metryka == "Metryka Canberra")
                {
                    double wynik = 0;
                    for (int i = 0; i < testowy.listaAtrybutow.Count; i++)
                    {

                        wynik += Math.Abs((Convert.ToDouble(testowy.listaAtrybutow[i] - treningowy.listaAtrybutow[i])) / Convert.ToDouble((testowy.listaAtrybutow[i] + treningowy.listaAtrybutow[i])));
                    }
                    return wynik;
                }
            if (metryka == "Metryka Czebyszewa")
            {
                double tmp = 0;
                double wynik = Math.Abs(Convert.ToDouble((testowy.listaAtrybutow[0] - treningowy.listaAtrybutow[0])));

                    for (int i = 0; i < testowy.listaAtrybutow.Count(); i++)
                    {
                        tmp = Math.Abs(Convert.ToDouble((testowy.listaAtrybutow[i] - treningowy.listaAtrybutow[i])));
                        if (tmp>wynik)
                        {
                            wynik=tmp;
                        }
                    }
                    return wynik;
            }

            if (metryka == "Bezwzgledny współczynnik korelacji Pearsona")
            {

                double r = 0;
                double Y = 0;
                double X = 0;
                double mian1 = 0;
                double mian2 = 0;
                for (int i = 0; i < testowy.listaAtrybutow.Count(); i++)
                {
                    X += testowy.listaAtrybutow[i];
                    Y += treningowy.listaAtrybutow[i];
                }
                X = 1 / Convert.ToDouble(testowy.listaAtrybutow.Count()) * X;
                Y = 1 / Convert.ToDouble(treningowy.listaAtrybutow.Count()) * Y;
                for (int i = 0; i < testowy.listaAtrybutow.Count(); i++)
                {
                    mian1 = Math.Pow((Convert.ToDouble(testowy.listaAtrybutow[i]) - X), 2);
                    mian2 = Math.Pow((Convert.ToDouble(treningowy.listaAtrybutow[i]) - Y), 2);
                }
                mian1 = Math.Sqrt(Convert.ToDouble(1) / Convert.ToDouble(testowy.listaAtrybutow.Count()) * mian1);
                mian2 = Math.Sqrt(Convert.ToDouble(1) / Convert.ToDouble(treningowy.listaAtrybutow.Count()) * mian2);
                for (int i = 0; i < testowy.listaAtrybutow.Count(); i++)
                {
                    r += ((Convert.ToDouble(testowy.listaAtrybutow[i]) - X) / mian1) * ((Convert.ToDouble(testowy.listaAtrybutow[i]) - Y) / mian2);
                }

                r = Convert.ToDouble(1) / Convert.ToDouble(testowy.listaAtrybutow.Count()) * r;
                return Convert.ToDouble(1) - Math.Abs(r);
            }
            return 0;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
       
            if ( metryka == "" || k == ""||systemTestowy==null||systemTreningowy==null)
                MessageBox.Show("Paramtry zostały podane nieodpowiednio");
            else
            {
                int newK=Int32.Parse(k);
                for (int i = 0; i < systemTestowy.Length; i++)
                {
                    for (int j = 0; j < systemTreningowy.Length; j++)
                    {
                        systemTestowy[i].listaMetryk.Add(obliczOdleglosc(systemTestowy[i], systemTreningowy[j], metryka));
                        systemTestowy[i].klasaMetryki.Add(systemTreningowy[j].klasa);
                    }
                    systemTestowy[i].decyzyjnik(newK);
                    systemTestowy[i].klasyfikator();
                }
                for (int i = 0; i < systemTestowy.Length; i++)
                {
                    if (systemTestowy[i].klasa==0)
                    {
                        klasa0 += 1;
                    }
                    else
                    {
                        klasa1 += 1;
                    }
                    if (systemTestowy[i].klasyfikacja == 1 || systemTestowy[i].klasyfikacja == 0)
                    {
                        chwytane += 1;
                        if (systemTestowy[i].klasa==0)
                        {
                            chwytane0 += 1;
                        }
                        else
                        {
                            chwytane1 += 1;
                        }
                    }
                    if (systemTestowy[i].klasyfikacja == 1)
                    {
                        sklasyfikowane += 1;
                        if (systemTestowy[i].klasa==0)
                        {
                            sklasyfikowane0 += 1;
                        }
                        else
                        {
                            sklasyfikowane1 += 1;
                        }

                    }
                    if (systemTestowy[i].klasyfikacja == 0)
                    {
                        sklasyfikowane += 1;
                        if (systemTestowy[i].klasa == 0)
                        {
                            bledne0 += 1;
                        }
                        else
                        {
                            bledne1 += 1;
                        }

                    }

                }
                if (chwytane!=0)
                {
                    accGlob = Convert.ToDouble(sklasyfikowane) / Convert.ToDouble(chwytane);
                }
                covGlob = chwytane / systemTestowy.Length;
                if (chwytane0 != 0)
                {
                    acc0 = Convert.ToDouble(sklasyfikowane0) / Convert.ToDouble(chwytane0);
                }
                if (chwytane1 != 0)
                {
                    acc1 = Convert.ToDouble(sklasyfikowane1) / Convert.ToDouble(chwytane1);
                }
                if (klasa0!=0)
                {
                    cov0 = Convert.ToDouble(chwytane0) / Convert.ToDouble(klasa0);
                    tpr0 = Convert.ToDouble(sklasyfikowane0) / (Convert.ToDouble(sklasyfikowane0) + bledne0);
                }
                if (klasa1!=0)
                {
                    cov1 = Convert.ToDouble(chwytane1) / Convert.ToDouble(klasa1);
                    tpr1 = Convert.ToDouble(sklasyfikowane1) / (Convert.ToDouble(sklasyfikowane1) + bledne1);
                }           
                string path = string.Concat(Environment.CurrentDirectory, @"\wynik.txt");
                File.WriteAllText(path, String.Empty);
                System.IO.StreamWriter file = new System.IO.StreamWriter(path,true);
                for (int i = 0; i < systemTestowy.Length; i++)
                {
                    if (systemTestowy[i].klasyfikacja==-1)
                    {
                    //    file.WriteLine("Obiekt x" + i + " nie chwytany");
                    }
                    else if (systemTestowy[i].klasyfikacja==1)
                    {
                        //file.WriteLine("Obiekt x" + i + " otrzymuje decyzje "+ systemTestowy[i].decyzja+", jest poprawnie sklasyfikowany");
                        if (systemTestowy[i].klasa==1)
                        {
                            poprawne1 += 1;
                        }
                        else
                        {
                            poprawne0 += 1;
                        }
                    }
                    else
                    {
                        //file.WriteLine("Obiekt x" + i + " otrzymuje decyzje " + systemTestowy[i].decyzja + ", jest błednie sklasyfikowany");
                        if (systemTestowy[i].klasa == 1)
                        {
                            niepoprawne1 += 1;
                        }
                        else
                        {
                            niepoprawne0 += 1;
                        }
                    }
                }
                file.WriteLine(" \t 0 \t 1\t Obj# \t Acc \t Cov");
                file.WriteLine("0 \t "+poprawne0+" \t "+niepoprawne0+" \t "+klasa0+" \t "+acc0+ " \t "+ cov0);
                file.WriteLine("1 \t "+niepoprawne1+" \t "+poprawne1+" \t " + klasa1 + " \t " + acc1 + " \t " + cov1);
                file.WriteLine("TPR \t"+tpr0+" \t "+tpr1);

                // Write the string to a file.
                
                

                file.Close();
                Process.Start("notepad.exe", path);
                accGlob=0;
                 covGlob=0;
                 cov0 = 0;
                 cov1 = 0;
                 bledne0 = 0;
                 bledne1 = 0;
                 acc0 = 0;
                 acc1 = 0;
                 tpr0 = 0;
                 tpr1 = 0;
                 chwytane = 0;
                 chwytane0 = 0;
                 chwytane1 = 0;
                 sklasyfikowane0 = 0;
                 sklasyfikowane1 = 0;
                 sklasyfikowane = 0;
                 klasa0=0;
                 klasa1=0;
                 niepoprawne0=0;
                 poprawne1 = 0;
                 poprawne0 = 0;
                 niepoprawne1 = 0;
                 for (int i = 0; i < systemTestowy.Length; i++)
                 {
                     for (int j = 0; j < systemTreningowy.Length; j++)
                     {
                         systemTestowy[i].listaMetryk.Clear();
                         systemTestowy[i].klasaMetryki.Clear();
                     }
                 }
            }
        }



        private void txtBoxTest_TextChanged(object sender, EventArgs e)
        {

        }

        private void TestOFD_FileOk(object sender, CancelEventArgs e)
        {

        }

        //            private int znajdz_najwieksza_k(int findK, Obiekt[] systemTestowy)
        //{
        //    for (int i = 0; i < systemTestowy.Length; i++)
        //    {
        //        if (systemTestowy[i].listasort0.Count < findK)
        //        {
        //            findK = systemTestowy[i].listasort0.Count();
        //        }
        //        if (systemTestowy[i].listasort1.Count < findK)
        //        {
        //            findK = systemTestowy[i].listasort1.Count();
        //        }
        //    }
        //    return findK;
        //}



    }
}
