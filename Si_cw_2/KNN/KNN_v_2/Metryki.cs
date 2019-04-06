using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KNN_v_2
{
    public delegate double Metryka(Obiekt X, Obiekt Y);
    public static class Metryki
    {
        public static double metrykaManhattan(Obiekt testowy, Obiekt treningowy)
        {
            
                double suma = 0;
                for (int i = 0; i < testowy.deskryptory.Count(); i++)
                {
                    suma += Math.Abs(Convert.ToDouble((testowy.deskryptory[i].wartosc - treningowy.deskryptory[i].wartosc)));
                }
                return suma;
            
        }
        public static double metrykaEuklidesowa(Obiekt testowy, Obiekt treningowy)
            {
                double wynik = 0;
                for (int i = 0; i < testowy.deskryptory.Count(); i++)
                {

                    wynik += Math.Pow((double)(testowy.deskryptory[i].wartosc - treningowy.deskryptory[i].wartosc),2);
                }
                return Math.Sqrt(wynik);
            }

        public static double MetrykaCanberra(Obiekt testowy, Obiekt treningowy)
                {
                    double wynik = 0;
                    for (int i = 0; i < testowy.deskryptory.Count(); i++)
                    {

                        wynik += Math.Abs((Convert.ToDouble(testowy.deskryptory[i].wartosc - treningowy.deskryptory[i].wartosc)) / Convert.ToDouble((testowy.deskryptory[i].wartosc + treningowy.deskryptory[i].wartosc)));
                    }
                    return wynik;
                }
        public static double metrykaCzebyszewa(Obiekt testowy, Obiekt treningowy)
            {
                double tmp = 0;
                double wynik = Math.Abs(Convert.ToDouble((testowy.deskryptory[0].wartosc - treningowy.deskryptory[0].wartosc)));

                    for (int i = 0; i < testowy.deskryptory.Count(); i++)
                    {
                        tmp = Math.Abs(Convert.ToDouble((testowy.deskryptory[i].wartosc - treningowy.deskryptory[i].wartosc)));
                        if (tmp>wynik)
                        {
                            wynik=tmp;
                        }
                    }
                    return wynik;
            }

        public static double bezwzglednyWspołczynnikKorelacjiPearsona(Obiekt testowy, Obiekt treningowy)
            {

                double r = 0;
                double Y = 0;
                double X = 0;
                double mian1 = 0;
                double mian2 = 0;
                for (int i = 0; i < testowy.deskryptory.Count(); i++)
                {
                    X += testowy.deskryptory[i].wartosc;
                    Y += treningowy.deskryptory[i].wartosc;
                }
                X = 1 / Convert.ToDouble(testowy.deskryptory.Count()) * X;
                Y = 1 / Convert.ToDouble(treningowy.deskryptory.Count()) * Y;
                for (int i = 0; i < testowy.deskryptory.Count(); i++)
                {
                    mian1 = Math.Pow((Convert.ToDouble(testowy.deskryptory[i].wartosc) - X), 2);
                    mian2 = Math.Pow((Convert.ToDouble(treningowy.deskryptory[i].wartosc) - Y), 2);
                }
                mian1 = Math.Sqrt(Convert.ToDouble(1) / Convert.ToDouble(testowy.deskryptory.Count()) * mian1);
                mian2 = Math.Sqrt(Convert.ToDouble(1) / Convert.ToDouble(treningowy.deskryptory.Count()) * mian2);
                for (int i = 0; i < testowy.deskryptory.Count(); i++)
                {
                    r += ((Convert.ToDouble(testowy.deskryptory[i].wartosc) - X) / mian1) * ((Convert.ToDouble(testowy.deskryptory[i].wartosc) - Y) / mian2);
                }

                r = Convert.ToDouble(1) / Convert.ToDouble(testowy.deskryptory.Count()) * r;
                return Convert.ToDouble(1) - Math.Abs(r);
            }
    }
}
