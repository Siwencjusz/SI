using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Fisher
{
    public class Klasa
    {
        public int numerKlasy;
        public List<int> indeksyObiektow=new List<int>();
        public int sumaWartosciObiektow = 0;
        public List<double> cNieZawierajace=new List<double>();
        public List<double> cZawierajace=new List<double>();
        public List<double> zNiezawierajace= new List<double>();
        public List<double> zZawierajace=new List<double>();
        public List<List<double>> stopienSeparacji=new List<List<double>>();
        public Klasa(int NumerKlasy)
        {
            this.numerKlasy = NumerKlasy;
        }
        public void obliczCZawierajace(List<Obiekt> lista)
        {
            cZawierajace.Clear();
            for (int j = 0; j < lista[0].deskryptory.Length; j++)
            {
                double licznikcLokal = 0;
                for (int i = 0; i < indeksyObiektow.Count; i++)
                {
                    licznikcLokal += lista[indeksyObiektow[i]].deskryptory[j].wartosc;
                }
                cZawierajace.Add(licznikcLokal / Convert.ToDouble(indeksyObiektow.Count));
            }
        }
        public void obliczNieCZawierajace(List<Obiekt> lista)
        {
            cNieZawierajace.Clear();
            double licznikcSrednie;
            for (int j = 0; j < lista[0].deskryptory.Length; j++)
            {
                licznikcSrednie = 0;
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].klasa != this.numerKlasy)
                    {
                    
                        licznikcSrednie += lista[i].deskryptory[j].wartosc;
                    }
                }
                if (licznikcSrednie != 0)
                {
                    cNieZawierajace.Add(licznikcSrednie / (Convert.ToDouble(lista.Count - indeksyObiektow.Count)));
                }
            }
            
        }
        public void obliczZZawierajace(List<Obiekt> lista)
        {
            zZawierajace.Clear();
            double licznikLokal=0;
            for (int z = 0; z < lista[indeksyObiektow[0]].deskryptory.Length; z++)
            {
                licznikLokal = 0;
                  
                    for (int j = 0; j < indeksyObiektow.Count; j++)
                    {
                        licznikLokal += Math.Pow((Convert.ToDouble(lista[indeksyObiektow[j]].deskryptory[z].wartosc) - cZawierajace[z]),2);
                    }
                zZawierajace.Add(licznikLokal / Convert.ToDouble(indeksyObiektow.Count));
            }
            
        }
        public void obliczZNieZawierajace(int length, List<Obiekt> dane)
        {
            zNiezawierajace.Clear();
            double licznikGlobal = 0;
            for (int j = 0; j < dane[0].deskryptory.Length; j++)
            {
                licznikGlobal = 0;
                for (int i = 0; i < dane.Count; i++)
                {
                    if (dane[i].klasa != this.numerKlasy)
                    {
                        licznikGlobal += Math.Pow((Convert.ToDouble(dane[i].deskryptory[j].wartosc) - (cNieZawierajace[j])),2);
                    }
                }
                if (licznikGlobal != 0)
                {
                    zNiezawierajace.Add(licznikGlobal / (Convert.ToDouble(dane.Count - indeksyObiektow.Count)));
                }
            }
        }
        public void obliczstopienSeparacji()
        {            
            for (int i = 0; i < cZawierajace.Count; i++)
            {
                List<double> lista=new List<double>();
                lista.Add((cZawierajace[i] - cNieZawierajace[i]) * (cZawierajace[i] - cNieZawierajace[i]) / (zZawierajace[i] + zNiezawierajace[i]));
                lista.Add(i);
                stopienSeparacji.Add(lista);
            }
            stopienSeparacji.Sort((x, y) => -1*x[0].CompareTo(y[0]));
        }
    }
}
