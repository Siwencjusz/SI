using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    public class AprioriAlg
    {
        public int phi;
        public List<Paragon>  zbiorParagonow;
        public List<string> zbiorZdarzenCzesttych;
        public List<List<string>> zbiorC2;
        public List<List<string>> kombinacjeF2;
        public List<List<string>> zbiorC3;
        public List<List<string>> kombinacjeF3;
        public List<Regula> reguly = new List<Regula>();
        public AprioriAlg(List<Paragon> ZbiorParagonow, int Phi)
        {
            this.zbiorZdarzenCzesttych = new List<string>();
            this.zbiorParagonow = ZbiorParagonow;
            this.phi = Phi;
        }
        public void znajdzZbiorZdarzenCzestych()
        {
            for (int i = 0; i < zbiorParagonow.Count(); i++)
            {
                for (int j = 0; j < zbiorParagonow[i].listaZakupow.Count; j++)
                {
                    int czestosc = 0;
                    foreach (var item in zbiorParagonow)
                    {
                        for (int k = 0; k < item.listaZakupow.Count; k++)
                        {
                            if (zbiorParagonow[i].listaZakupow[j]==item.listaZakupow[k])
                            {
                                czestosc++;
                            }
                        }
                    }
                    if (czestosc>=phi&&!zbiorZdarzenCzesttych.Contains(zbiorParagonow[i].listaZakupow[j]))
                    {
                        zbiorZdarzenCzesttych.Add(zbiorParagonow[i].listaZakupow[j]);
                    }
                }
            }
            zbiorZdarzenCzesttych.Sort((x, y) => string.Compare(x, y));
        }
        public static IEnumerable<int[]> Combinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
        public void stworzZbiorC2()
        {
            this.zbiorC2=new List<List<string>>();
            var tmpKombinations = Combinations(2,this.zbiorZdarzenCzesttych.Count);
            List<List<int>> numericCombinatiosn = new List<List<int>>();
            foreach (var item in tmpKombinations)
            {
                numericCombinatiosn.Add(item.ToList());
            }
            foreach (var element in numericCombinatiosn)
            {
                List<string> kombinacja = new List<string>();
                foreach (var item in element)
                {
                    kombinacja.Add(zbiorZdarzenCzesttych[item]);
                }
                if (!zbiorC2.Contains(kombinacja))
                {
                    this.zbiorC2.Add(kombinacja);
                }
                
            }
        }
        public void znajdzKombinacjeF2()
        {
            kombinacjeF2 = new List<List<string>>();
            foreach (var kombinacja in zbiorC2)
            {
                int czestosc = 0;
                foreach (var paragon in zbiorParagonow)
                {
                    if (paragon.listaZakupow.Intersect(kombinacja).Count()==kombinacja.Count())
                    {
                        czestosc++;
                    }
                }
                if (czestosc>=phi)
                {
                    kombinacjeF2.Add(kombinacja);
                }
            }
        }
        public void utworzZbiorC3()
        {
            this.zbiorC3 = new List<List<string>>();
            var tmpKombinations = Combinations(3, this.zbiorZdarzenCzesttych.Count);
            List<List<int>> numericCombinatiosn = new List<List<int>>();
            foreach (var item in tmpKombinations)
            {
                numericCombinatiosn.Add(item.ToList());
            }
            foreach (var element in numericCombinatiosn)
            {
                List<string> kombinacja = new List<string>();
                foreach (var item in element)
                {
                    kombinacja.Add(zbiorZdarzenCzesttych[item]);
                }
                if (!zbiorC3.Contains(kombinacja))
                {
                    this.zbiorC3.Add(kombinacja);
                }

            }
        }
        public void znajdzKombinacjeF3()
        {
            kombinacjeF3 = new List<List<string>>();
            foreach (var kombinacja in zbiorC3)
            {
                int czestosc = 0;
                foreach (var paragon in zbiorParagonow)
                {
                    if (paragon.listaZakupow.Intersect(kombinacja).Count() == kombinacja.Count())
                    {
                        czestosc++;
                    }
                }
                if (czestosc >= phi)
                {
                    kombinacjeF3.Add(kombinacja);
                    break;
                }
            }
        }
        public void zapiszReguly()
        {
            foreach (var item in kombinacjeF2)
            {
                reguly.Add(new Regula(item));
            }
            foreach (var item in kombinacjeF3)
            {
                reguly.Add(new Regula(item));
            }
        }
        public void znajdzsupportReguly(Regula regula)
        {
            foreach (var item in zbiorParagonow)
            {
                if (item.listaZakupow.Intersect(regula.regulaToList()).Count()==regula.regulaToList().Count())
                {
                    regula.zwiekszSupport();   
                }
            }
        }
        

    }
}
