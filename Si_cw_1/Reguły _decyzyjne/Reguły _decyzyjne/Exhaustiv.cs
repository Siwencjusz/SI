using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reguły__decyzyjne
{
    public class Exhaustiv
    {
        Obiekt[] daneZPliku = null;
        List<Regula> reguly = new List<Regula>();
        List<List<List<int>>> macierzNieodroznialnosci = new List<List<List<int>>>();
        public Exhaustiv(Obiekt[] DaneZPliku)
        {
            this.daneZPliku = DaneZPliku;
        }
        public void szukajRegul()
        {
            utworzMacierzNieodroznialnosci();
            for (int i = 1; i < daneZPliku[0].deskryptory.Length + 1; i++)
            {
                //List<List<int>> kombinacje = znajdzKombinacje(i);
                List<List<int>> kombinacje = new List<List<int>>();
                kombinacje.Clear();
                var x = Combinations(i, daneZPliku[0].deskryptory.Length);
                foreach (var item in x)
                {
                    kombinacje.Add(item.ToList());
                }

                szukajReguly(kombinacje);
            }
            
        }
        public void szukajReguly(List<List<int>> kombinacje)
        {
            for (int i = 0; i < kombinacje.Count; i++)
            {
                for (int j = 0; j < daneZPliku.Length; j++)
                {
                    if (sprawdzRegule(j,kombinacje[i]))
                    {
                        int zgodnoscReguly = 0;
                        int supportReguly = 0;
                        for (int k = 0; k < daneZPliku.Length; k++)
                        {
                            for (int l = 0; l < kombinacje[i].Count; l++)
                            {
                                if (l==0)
                                {
                                    zgodnoscReguly = 0;
                                }
                                if (daneZPliku[j].deskryptory[kombinacje[i][l]].wartosc==daneZPliku[k].deskryptory[kombinacje[i][l]].wartosc)
                                {
                                    zgodnoscReguly += 1;
                                }
                                if (zgodnoscReguly==kombinacje[i].Count)
                                {
                                    supportReguly += 1;
                                    zgodnoscReguly = 0;
                                }
                            }
                        }
                        if (supportReguly>0)
                        {
                            List<int> wartosciTstReguly = new List<int>();
                            for (int k = 0; k < kombinacje[i].Count; k++)
                            {
                                wartosciTstReguly.Add(daneZPliku[j].deskryptory[kombinacje[i][k]].wartosc);
                            }
                            Regula regulaTmp = new Regula(kombinacje[i], daneZPliku[j].klasa, supportReguly, wartosciTstReguly);
                            if (czyRegulaUnikalna(regulaTmp)&&CzyNieistnieje(regulaTmp))
                            {
                                reguly.Add(regulaTmp);
                            }
                            
                        }
                    }
                }
            }
        }

        private bool CzyNieistnieje(Regula regulaTmp)
        {
                int podobienstwo = 0;
                for (int i = 0; i < reguly.Count; i++)
                {
                    if (reguly[i].indeksyReguly.Count == regulaTmp.indeksyReguly.Count)
                    {
                        for (int j = 0; j < reguly[i].indeksyReguly.Count; j++)
                        {
                            if (j==0)
                            {
                                podobienstwo=0;
                            }
                            if (reguly[i].indeksyReguly[j] == regulaTmp.indeksyReguly[j] && reguly[i].wartosciReguly[j] == regulaTmp.wartosciReguly[j])
                            {
                                podobienstwo += 1;
                            }
                            if (podobienstwo==regulaTmp.wartosciReguly.Count)
                            {
                                return false;
                            }

                        }
                    }
                }
            return true;
        }

        private bool sprawdzRegule(int kolumna,List<int> kombinacja)
        {
            for (int i = 0; i < daneZPliku.Length; i++)
            {
                int niezgodnoscReguly = 0;
                for (int j = 0; j < kombinacja.Count; j++)
                {
                    if (j==0)
                    {
                        niezgodnoscReguly = 0;
                    }
                    if (macierzNieodroznialnosci[kolumna][i].Contains(kombinacja[j]))
                    {
                        niezgodnoscReguly += 1;
                    }
                    if (niezgodnoscReguly==kombinacja.Count)
                    {
                        return false;
                    }
                }              
            }
            return true;
        }
        private void modyfikujMacierzNieodroznialnosci(int j, List<int> indeksyReguly, List<int> kombinacja)
        {
            for (int i = 0; i < indeksyReguly.Count; i++)
            {
                for (int k = 0; k < kombinacja.Count; k++)
                {
                    macierzNieodroznialnosci[j][indeksyReguly[i]].Add(kombinacja[k]);
                }
            }
        }

        private bool czyRegulaUnikalna(Regula regulaTmp)
        {
            for (int k = 0; k < regulaTmp.indeksyReguly.Count; k++)
            {
                for (int i = 0; i < reguly.Count; i++)
                {
                    if (reguly[i].indeksyReguly.Count<regulaTmp.indeksyReguly.Count || regulaTmp.indeksyReguly.Count==1)
                    {
                         for (int j = 0; j < reguly[i].indeksyReguly.Count; j++)
                        {
                            if (reguly[i].indeksyReguly[j] == regulaTmp.indeksyReguly[k] && reguly[i].wartosciReguly[j]==regulaTmp.wartosciReguly[k])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
            
        }
        public bool czyKombinacjaOk(int indexi, int indexj, List<int> kombinacja)
        {
            int niezgodnosc = 0;
            for (int j = 0; j < daneZPliku.Length; j++)
            {
                niezgodnosc = 0;
                for (int i = 0; i < kombinacja.Count; i++)
                {

                    if (macierzNieodroznialnosci[indexi][j].Contains(kombinacja[i]))
                    {
                        if (daneZPliku[j].deskryptory[kombinacja[i]].wartosc==daneZPliku[i].deskryptory[kombinacja[i]].wartosc)
                        {
                            
                        }
                        niezgodnosc += 1;
                    }
                    if (niezgodnosc == kombinacja.Count)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void utworzMacierzNieodroznialnosci()
        {

            for (int i = 0; i < daneZPliku.Length; i++)
            {
                macierzNieodroznialnosci.Add(new List<List<int>>());
                int klasaI = daneZPliku[i].klasa;
                for (int j = 0; j < daneZPliku.Length; j++)
                {
                    macierzNieodroznialnosci[i].Add(new List<int>());
                    int klasaJ = daneZPliku[j].klasa;
                    if (klasaI != klasaJ)
                    {
                        for (int k = 0; k < daneZPliku[i].deskryptory.Length; k++)
                        {
                            if (daneZPliku[i].deskryptory[k].wartosc == daneZPliku[j].deskryptory[k].wartosc)
                            {

                                macierzNieodroznialnosci[i][j].Add(k);
                            }
                        }
                    }
                }
            }
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
        public void wypiszReguły()
        {
            string path = string.Concat(Environment.CurrentDirectory, @"\Exaust.txt");
            File.WriteAllText(path, String.Empty);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
            string linia = "";
            int nrReguly = 0;
            if (reguly.Count != 0)
            {
                for (int i = 0; i < reguly.Count; i++)
                {
                    linia = "";
                    nrReguly += 1;
                    for (int j = 0; j < reguly[i].indeksyReguly.Count; j++)
                    {
                        linia += "(a" + (reguly[i].indeksyReguly[j] + 1) + "= " + reguly[i].wartosciReguly[j] + ")";
                        if (reguly[i].indeksyReguly.Count > 1 && j < reguly[i].indeksyReguly.Count - 1)
                        {
                            linia += "^";
                        }
                        else
                        {
                            linia += " ";
                        }
                    }
                    linia += "=> (d = " + reguly[i].klasaReguly + ")[" + reguly[i].supportReguly + "]";
                    file.WriteLine(linia);
                }
            }
            file.Close();
            Process.Start("notepad.exe", path);
        }
    }
}
