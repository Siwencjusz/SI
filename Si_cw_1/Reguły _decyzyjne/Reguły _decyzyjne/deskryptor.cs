using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reguły__decyzyjne
{
    public class deskryptor
    {
        public int indeks;
        public int wartosc;
        public List<int> wystapienie= new List<int>();
        public deskryptor(int Indeks, int Wartosc)
        {
            this.wartosc = Wartosc;
            this.indeks = Indeks;
        }
        public void dodajPokrywajacyObiekt(int obiekt)
        {
            if (!wystapienie.Contains(obiekt))
            {
                this.wystapienie.Add(obiekt);
            }            
            this.wystapienie.Sort();
        }
    }
}
