using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reguły__decyzyjne
{
    public class Regula
    {
        public List<int> indeksyReguly = new List<int>();
        public List<int> wartosciReguly = new List<int>();
        public int klasaReguly = 0;
        public int supportReguly = 0;
        public List<int> obiektyWspierane;

        public Regula(List<int> IndeksyReguly, int KlasaReguly, int SupportReguly, List<int> WartosciReguly)
        {
            this.indeksyReguly = IndeksyReguly;
            this.klasaReguly = KlasaReguly;
            this.supportReguly = SupportReguly;
            this.wartosciReguly = WartosciReguly;
        }

        public Regula(int numerKonceptu, List<deskryptor> regulaTmp)
        {
            this.klasaReguly = numerKonceptu;
            regulaTmp.OrderBy(x => x.indeks);
            List<int> suport = regulaTmp[0].wystapienie;
            if (regulaTmp.Count>1)
            {
                for (int i = 0; i < regulaTmp.Count-1; i++)
                {
                    suport=suport.Intersect(regulaTmp[i+1].wystapienie).ToList();

                    this.indeksyReguly.Add(regulaTmp[i].indeks);
                    this.wartosciReguly.Add(regulaTmp[i].wartosc);
                }
            }
            this.supportReguly = suport.Count();
            this.obiektyWspierane = suport;
        }
    }
}
