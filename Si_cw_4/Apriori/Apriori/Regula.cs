using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    public class Regula
    {
        List<string> poprzednik = new List<string>();
        string nastepnik;
        int support = 0;
        public Regula(List<string> Regula)
        {
            for (int i = 0; i < Regula.Count-1; i++)
            {
                this.poprzednik.Add(Regula[i]);
            }
            this.nastepnik = Regula[Regula.Count()-1];
        }
        public void zwiekszSupport()
        {
            support++;
        }
        public List<string> regulaToList()
        {
            List<string> tmpList = new List<string>();
            foreach (var item in this.poprzednik)
            {
                //List<string>  tmpElem= new List<string>();
                //tmpElem.Add(item);
                //tmpList.Add(tmpElem);
                tmpList.Add(item);
            }
            tmpList.Add(nastepnik);
            return tmpList;
        }

    }
}
