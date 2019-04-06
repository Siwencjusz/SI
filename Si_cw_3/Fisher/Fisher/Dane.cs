using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace Fisher
{
    public class Dane
    {
        public Obiekt[] daneZPliku;
        public List<int> klasy=new List<int>();
        public List<Klasa> listaKlas=new List<Klasa>();
        public List<List<double>> najlepszeSepraratory=new List<List<double>>();
        public Dane(Obiekt[] DaneZPliku)
        {
            this.daneZPliku = DaneZPliku;
        }
        public void znajdzKlasy()
        {
            listaKlas.Clear();
            klasy.Clear();
            for (int i = 0; i < daneZPliku.Length; i++)
            {
                if(klasy.Count==0)
                {
                    klasy.Add(daneZPliku[i].klasa);
                    listaKlas.Add(new Klasa(daneZPliku[i].klasa));
                }
                else
                {
                    if(!klasy.Contains(daneZPliku[i].klasa))
                    {
                        klasy.Add(daneZPliku[i].klasa);
                        listaKlas.Add(new Klasa(daneZPliku[i].klasa));
                    }
                }
                    
            }
            klasy.Sort((x, y) => x.CompareTo(y));
            listaKlas.Sort((x, y) => x.numerKlasy.CompareTo(y.numerKlasy));
        }
        public void ileElemntowklasy()
        {
            for (int u = 0; u < listaKlas.Count; u++)
            {
                listaKlas[u].indeksyObiektow.Clear();
                
            }
            for (int i = 0; i < daneZPliku.Length; i++)
            {   
                for (int j = 0; j < listaKlas.Count; j++)
                {
                    if (daneZPliku[i].klasa==listaKlas[j].numerKlasy)
                    {
                        listaKlas[j].indeksyObiektow.Add(i);
                    }
                }
            }
        }
        public void obliczCKlas()
        {
            for (int i = 0; i < listaKlas.Count; i++)
            {
                listaKlas[i].obliczNieCZawierajace(daneZPliku.ToList());
                listaKlas[i].obliczCZawierajace(daneZPliku.ToList());
            }
        }
        public void obliczZKlas()
        {

            for (int i = 0; i < listaKlas.Count; i++)
            {
                listaKlas[i].obliczZZawierajace(daneZPliku.ToList());
                listaKlas[i].obliczZNieZawierajace(daneZPliku.Length, daneZPliku.ToList());
            }
        }
        public  void obliczSCI()
        {
            for (int i = 0; i < listaKlas.Count; i++)
            {
                listaKlas[i].obliczstopienSeparacji();
            }
        }
        public  void znajdzNajlepszeSeparatory(int ile)
        {
             List<double> indeksy=new List<double>();
             indeksy.Clear();
             najlepszeSepraratory.Clear();

            for (int j = 0; j < daneZPliku[0].deskryptory.Count(); j++)
            {
                for (int i = 0; i < listaKlas.Count; i++)
                {
                    if (indeksy.Count == 0 || !indeksy.Contains(listaKlas[i].stopienSeparacji[j][1]) && indeksy.Count < ile)
                    {
                        indeksy.Add(listaKlas[i].stopienSeparacji[j][1]);
                        List<double> tmp = new List<double>();
                        tmp.Add(listaKlas[i].stopienSeparacji[j][0]);
                        tmp.Add(listaKlas[i].stopienSeparacji[j][1]);
                        najlepszeSepraratory.Add(tmp);
                    }

                }
            }
            najlepszeSepraratory.Sort((x, y) => x[1].CompareTo(y[1]));
        }

        public void wypiszSystemDecyzyjny(int ile)
        {
            string path = string.Concat(Environment.CurrentDirectory, @"\wynik.txt");
            File.WriteAllText(path, String.Empty);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
            string header = "\t";
            for (int i = 0; i < ile; i++)
            {
                header += "a" + (najlepszeSepraratory[i][1]+1) + "\t";
            }
            header += "d";
            file.WriteLine(header);
            for (int i = 0; i < daneZPliku.Length; i++)
            {
                string row = "o"+(i+1)+"\t";
                for (int j = 0; j < ile; j++)
                {
                    row += daneZPliku[i].deskryptory[Convert.ToInt32(najlepszeSepraratory[j][1])].wartosc + "\t";
                }
                row += daneZPliku[i].klasa;
                file.WriteLine(row);
            }
            file.Close();
            Process.Start("notepad.exe", path);
        }
    }
}
