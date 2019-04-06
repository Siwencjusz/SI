using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_v_2
{
    public class SystemDecyzyjnycs
    {
        private Dane daneTestowe;
        private Dane daneTreningowe;
        private int k;
        private Metryka metryka;
        public int klasa0 { get; set; }
        public int klasa1 { get; set; }
        public int chwytane { get; set; }
        public int chwytane0 { get; set; }
        public int chwytane1 { get; set; }
        public int sklasyfikowane { get; set; }
        public int sklasyfikowane0 { get; set; }
        public int sklasyfikowane1 { get; set; }
        public int bledne0 { get; set; }
        public int bledne1 { get; set; }
        public double accGlob { get; set; }
        public int covGlob { get; set; }
        public double acc0 { get; set; }
        public double acc1 { get; set; }
        public double cov0 { get; set; }
        public double tpr0 { get; set; }
        public double cov1 { get; set; }
        public double tpr1 { get; set; }
        public int poprawne1 { get; set; }
        public int poprawne0 { get; set; }
        public int niepoprawne1 { get; set; }
        public int niepoprawne0 { get; set; }
        public SystemDecyzyjnycs(Dane daneTestowe, Dane danetreningowe, int K, Metryka metryka)
        {
            // TODO: Complete member initialization
            this.daneTestowe = daneTestowe;
            this.daneTreningowe = danetreningowe;
            this.k = K;
            this.metryka = metryka;
        }
        public void ileKlas()
        {
            List<int> ile = new List<int>();
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                if (!ile.Contains(daneTestowe.daneZPliku[i].klasa))
                {
                    ile.Add(daneTestowe.daneZPliku[i].klasa);
                }
            }
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                daneTestowe.daneZPliku[i].ileListMetryk(ile);
            }
        }
        public void liczMetryki()
        {
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
			{
                daneTestowe.daneZPliku[i].listaMetryk.Clear();
                daneTestowe.daneZPliku[i].listaklasMetryk.Clear();
                for (int j = 0; j < daneTreningowe.daneZPliku.Length; j++)
                {
                    daneTestowe.daneZPliku[i].listaMetryk.Add(metryka(daneTestowe.daneZPliku[i],daneTreningowe.daneZPliku[j]));
                    daneTestowe.daneZPliku[i].listaklasMetryk.Add(daneTreningowe.daneZPliku[j].klasa);
                }
			}
        }
        public void rozdzielKlasymetryk()
        {
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                daneTestowe.daneZPliku[i].rozdzielMetryki();
            }
        }
        public void zweryfikujK()
        {
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                for (int j = 0; j < daneTestowe.daneZPliku[i].listaMetryk.Count; j++)
                {
                    if (k > daneTestowe.daneZPliku[i].listasort0.Count())
                    {
                        k = daneTestowe.daneZPliku[i].listasort0.Count();
                    }
                    if (k > daneTestowe.daneZPliku[i].listasort1.Count())
                    {
                        k = daneTestowe.daneZPliku[i].listasort1.Count();
                    }
                }
            }
        }
        public void klasyfikujObiekty()
        {
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                daneTestowe.daneZPliku[i].decyzyjnik(k);
            }
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                daneTestowe.daneZPliku[i].klasyfikator();
            }
        }
        public void SprawdzObiekty()
        {
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                if (daneTestowe.daneZPliku[i].klasa == daneTestowe.daneZPliku[i].klasaMetryki[0])
                {
                    klasa0 += 1;
                }
                else
                {
                    klasa1 += 1;
                }
                if (daneTestowe.daneZPliku[i].klasyfikacja != null)
                {
                    chwytane += 1;
                    if (daneTestowe.daneZPliku[i].klasa == daneTestowe.daneZPliku[i].klasaMetryki[0])
                    {
                        chwytane0 += 1;
                    }
                    else
                    {
                        chwytane1 += 1;
                    }
                }
                if (daneTestowe.daneZPliku[i].klasyfikacja == 1)
                {
                    sklasyfikowane += 1;
                    if (daneTestowe.daneZPliku[i].klasa == daneTestowe.daneZPliku[i].klasaMetryki[0])
                    {
                        sklasyfikowane0 += 1;
                    }
                    else
                    {
                        sklasyfikowane1 += 1;
                    }

                }
                if (daneTestowe.daneZPliku[i].klasyfikacja ==0)
                {
                    sklasyfikowane += 1;
                    if (daneTestowe.daneZPliku[i].klasa == daneTestowe.daneZPliku[i].klasaMetryki[0])
                    {
                        bledne0 += 1;
                    }
                    else
                    {
                        bledne1 += 1;
                    }

                }

            }
        }
        public void liczElemntyMacierzyPredykcji()
        {
            if (chwytane != 0)
            {
                accGlob = Convert.ToDouble(sklasyfikowane) / Convert.ToDouble(chwytane);
            }
            covGlob = chwytane / daneTestowe.daneZPliku.Length;
            if (chwytane0 != 0)
            {
                acc0 = Convert.ToDouble(sklasyfikowane0) / Convert.ToDouble(chwytane0);
            }
            if (chwytane1 != 0)
            {
                acc1 = Convert.ToDouble(sklasyfikowane1) / Convert.ToDouble(chwytane1);
            }
            if (klasa0 != 0)
            {
                cov0 = Convert.ToDouble(chwytane0) / Convert.ToDouble(klasa0);
                tpr0 = Convert.ToDouble(sklasyfikowane0) / (Convert.ToDouble(sklasyfikowane0 + bledne1));
                if (klasa0 == 0)
                {
                    cov0 = 0;
                }
                if (sklasyfikowane0 + bledne1==0)
                {
                    tpr0 = 0;
                }
            }
            if (klasa1 != 0)
            {
                cov1 = Convert.ToDouble(chwytane1) / Convert.ToDouble(klasa1);
                tpr1 = Convert.ToDouble(sklasyfikowane1) / Convert.ToDouble(sklasyfikowane1 + bledne0);
                if (klasa1 == 0)
                {
                    cov1 = 0;
                }
                if (sklasyfikowane1 + bledne0 == 0)
                {
                    tpr1 = 0;
                }
            }
            for (int i = 0; i < daneTestowe.daneZPliku.Length; i++)
            {
                if (daneTestowe.daneZPliku[i].klasyfikacja == null)
                {
                    //    file.WriteLine("Obiekt x" + i + " nie chwytany");
                }
                else if (daneTestowe.daneZPliku[i].klasyfikacja == 1)
                {
                    //file.WriteLine("Obiekt x" + i + " otrzymuje decyzje "+ systemTestowy[i].decyzja+", jest poprawnie sklasyfikowany");
                    if (daneTestowe.daneZPliku[i].klasa == daneTestowe.daneZPliku[i].klasaMetryki[1])
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
                    if (daneTestowe.daneZPliku[i].klasa == daneTestowe.daneZPliku[i].klasaMetryki[1])
                    {
                        niepoprawne1 += 1;
                    }
                    else
                    {
                        niepoprawne0 += 1;
                    }
                }
            }
        }
        public void wypiszMacierzPredykcji()
        {
            string path = string.Concat(Environment.CurrentDirectory, @"\wynik.txt");
            File.WriteAllText(path, String.Empty);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
            file.WriteLine(" \t " + daneTestowe.daneZPliku[0].klasaMetryki[0] + " \t" + daneTestowe.daneZPliku[0].klasaMetryki[1] + " \t Obj# \t Acc \t Cov");
            file.WriteLine(daneTestowe.daneZPliku[0].klasaMetryki[0] + " \t " + poprawne0 + " \t " + niepoprawne0 + " \t " + klasa0 + " \t " + acc0 + " \t " + cov0);
            file.WriteLine(daneTestowe.daneZPliku[0].klasaMetryki[1] + " \t " + niepoprawne1 + " \t " + poprawne1 + " \t " + klasa1 + " \t " + acc1 + " \t " + cov1);
            file.WriteLine("TPR \t" + tpr0 + " \t " + tpr1);
            file.Close();
            Process.Start("notepad.exe", path);
        }





    }
}
