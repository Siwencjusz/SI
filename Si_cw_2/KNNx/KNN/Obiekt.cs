using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    public class Obiekt
    {
        public List<int> listaAtrybutow = new List<int>();
        public List<double> listaMetryk = new List<double>();
        public List<int> klasaMetryki = new List<int>();
        public int klasa;
        public int decyzja;
        public int klasyfikacja;
        public List<double[]> listasort0 = new List<double[]>();
        public List<double[]> listasort1 = new List<double[]>();
        public void decyzyjnik(int k)
        {

            listasort0.Clear();
            listasort1.Clear();
            for (int i = 0; i < listaMetryk.Count(); i++)
            {
                if (klasaMetryki[i]==0)
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
            k=sprawdzK(k);
            double suma0=0;
            double suma1=0;
            for (int i = 0; i < k; i++)
            {
                suma1 += listasort1[i][1];
                suma0 += listasort0[i][1];
                
            }
            if(suma0==suma1)
            {
                decyzja = -1;
                
            }
            else if(suma0<suma1)
            {
                decyzja = 0;
            }
            else
            {
                decyzja = 1;
            }

        }
        public void klasyfikator()
        {
            if (decyzja==-1)
            {
                klasyfikacja = -1;
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

        internal int sprawdzK(int newK)
        {

            if (listasort0.Count < newK)
            {
                newK = listasort0.Count;
            }
            if (listasort1.Count < newK)
            {
                newK = listasort1.Count;
            }
            return newK;

        }
    }
}
