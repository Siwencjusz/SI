using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_v_2
{
    public class Obiekt
    {
        public int klasa;
        public deskryptor[] deskryptory;
        public int? decyzja=null;
        public int? klasyfikacja=null;
        public List<double> listaMetryk= new List<double>();
        public List<double> listaklasMetryk = new List<double>();
        public List<int> klasaMetryki;
        public List<double[]> listasort0 = new List<double[]>();
        public List<double[]> listasort1 = new List<double[]>();
        public Obiekt(int Klasa, deskryptor[] Deskryptory)
        {
            this.klasa = Klasa;
            this.deskryptory = Deskryptory;
        }
        public void ileListMetryk(List<int> ile)
        {
            klasaMetryki= ile;
            klasaMetryki.Sort((x, y) => x.CompareTo(y));
        }
        public void rozdzielMetryki()
        {
            listasort0.Clear();
            listasort1.Clear();
            for (int i = 0; i < listaMetryk.Count(); i++)
            {
                if (listaklasMetryk[i]== klasaMetryki[0])
                {
                    double[] znacznik= new double[2];

                    znacznik[0]=i;
                    znacznik[1]=listaMetryk[i];
                    listasort0.Add(znacznik);
                }
                else
                {
                     double[] znacznik= new double[2];

                    znacznik[0]=i;
                    znacznik[1]=listaMetryk[i];
                    listasort1.Add(znacznik);
                }

            }
            listasort0.Sort((x, y) => x[1].CompareTo(y[1])); // asc
            listasort1.Sort((x, y) => x[1].CompareTo(y[1]));
        }
        public void decyzyjnik(int k)
        {
            double suma0=0;
            double suma1=0;
            for (int i = 0; i < k; i++)
            {
                suma1 += listasort1[i][1];
                suma0 += listasort0[i][1];
                
            }
            if(suma0==suma1)
            {
                
            }
            else if(suma0<suma1)
            {
                decyzja = klasaMetryki[0];
            }
            else
            {
                decyzja = klasaMetryki[1];
            }

        }
        public void klasyfikator()
        {
            if (decyzja==null)
            {
            }
            else if (decyzja==klasa)
            {
                klasyfikacja = 1;
            }
            else
            {
                klasyfikacja = 0;

            }
        }
    }
}
