using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace Reguły__decyzyjne
{
    public class Covering
    {
        Obiekt[] daneZPliku = null;
        List<Regula> reguly = new List<Regula>();
        List<int> obiektyWykluczone = new List<int>();
        List<int> indeksyPotencjalnieWykluczone = new List<int>();
        public Covering(Obiekt[] DaneZPliku)
        {
            this.daneZPliku = DaneZPliku;
        }
        public void szukajRegul()
        {
            for (int i = 1; i < daneZPliku[0].deskryptory.Length+1; i++)
            {
                List<List<int>> kombinacje=new List<List<int>>();
                kombinacje.Clear();
                var x= Combinations(i, daneZPliku[0].deskryptory.Length);
                foreach (var item in x)
                {
                    kombinacje.Add(item.ToList());
                }
                
                szukajReguly(kombinacje);
            }
        }
        public void szukajReguly( List<List<int>> kombinacje)
        {
            List<List<int>> KombinacjeSprawdzone = new List<List<int>>();
            List<int> indeksy = new List<int>();
            indeksy.Clear();
            List<int> wartosciTstReg = new List<int>();
            List<int> regulaTmp=new List<int>();
            int klasaReguly=0;
            for (int k = 0; k < kombinacje.Count; k++)
            {
                    for (int l = 0; l < daneZPliku.Length; l++)
                        {
                            if (!obiektyWykluczone.Contains(l))
                            {


                                wartosciTstReg.Clear();
                                for (int i = 0; i < kombinacje[0].Count; i++)
                                {                             
                                    klasaReguly = daneZPliku[l].klasa;
                                    wartosciTstReg.Add(daneZPliku[l].deskryptory[kombinacje[k][i]].wartosc);
                                    regulaTmp = kombinacje[k];

                                }
                                if (CzyNieZgodna(wartosciTstReg, regulaTmp, klasaReguly) == false)
                                {
                                    int zgodnoscReguly = CzyZgodna(wartosciTstReg, regulaTmp, klasaReguly);
                                    if (zgodnoscReguly > 0)
                                    {
                                        obiektyWykluczone.AddRange(indeksyPotencjalnieWykluczone);
                                        reguly.Add(new Regula(kombinacje[k], klasaReguly, zgodnoscReguly, wartosciTstReg.ToList()));
                                        KombinacjeSprawdzone.Add(kombinacje[k]);
                                    }
                                }

                            }
                        }
            }
        }

        public bool CzyNieZgodna(List<int> wartosciTstReg,List<int> kombinacja,int klasaReguly)
        {
            int niezgodne = 0;
            for (int p = 0; p < daneZPliku.Length; p++)
            {
                if (daneZPliku[p].klasa != klasaReguly)
                {
                    niezgodne = 0;
                    for (int i = 0; i < kombinacja.Count; i++)
                    {
                        if (wartosciTstReg[i]==(daneZPliku[p].deskryptory[kombinacja[i]].wartosc))
                        {
                            niezgodne += 1;
                        }
                    }
                    if (niezgodne==wartosciTstReg.Count)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int CzyZgodna(List<int> wartosciTstReg, List<int> kombinacja, int klasaReguly)
        {
            indeksyPotencjalnieWykluczone.Clear();
            int zgodne = 0;
            int support = 0;
            for (int p = 0; p < daneZPliku.Length; p++)
            {
                if (daneZPliku[p].klasa == klasaReguly && !obiektyWykluczone.Contains(p))
                {
                    zgodne = 0;
                    for (int i = 0; i < kombinacja.Count; i++)
                    {
                        if (wartosciTstReg[i]==daneZPliku[p].deskryptory[kombinacja[i]].wartosc)
                        {
                            zgodne += 1;
                        }
                    }
                    if (zgodne == kombinacja.Count)
                    {
                        support += 1;
                        indeksyPotencjalnieWykluczone.Add(p);
                    }
                }
            }

            return support;
        }
        public void wypiszReguły()
        {
            string path = string.Concat(Environment.CurrentDirectory, @"\cover.txt");
            File.WriteAllText(path, String.Empty);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
            string linia="";
            int nrReguly = 0;
            if (reguly.Count!=0)
            {
                for (int i = 0; i < reguly.Count; i++)
                {
                    linia = "";
                    nrReguly += 1;
                    for (int j = 0; j < reguly[i].indeksyReguly.Count; j++)
                    {
                        linia += "(a" + (reguly[i].indeksyReguly[j]+1) + "= " + reguly[i].wartosciReguly[j]+")";
                        if (reguly[i].indeksyReguly.Count>1&& j<reguly[i].indeksyReguly.Count-1)
                        {
                            linia += "^";
                        }
                        else
                        {
                            linia += " ";
                        }
                    }
                    linia +="=> (d = "+ reguly[i].klasaReguly+ ")[" + reguly[i].supportReguly+"]";
                    file.WriteLine(linia);
                }  
            }
                     
                //file.WriteLine("0 \t "+poprawne0+" \t "+niepoprawne0+" \t "+klasa0+" \t "+acc0+ " \t "+ cov0);

                // Write the string to a file.
                
                

                file.Close();
                Process.Start("notepad.exe", path);
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

    }
}