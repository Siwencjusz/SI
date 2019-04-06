using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reguły__decyzyjne
{
    public class Obiekt
    {
        public int klasa;
        public deskryptor[] deskryptory;
        public int sumaDeskryptorow;
        public Obiekt(int Klasa, deskryptor[] Deskryptory)
        {
            this.klasa = Klasa;
            this.deskryptory = Deskryptory;
        }

    }
}
