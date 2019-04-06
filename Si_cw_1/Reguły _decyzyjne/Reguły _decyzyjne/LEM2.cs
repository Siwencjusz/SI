using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reguły__decyzyjne
{
    public class LEM2
    {
        Obiekt[] daneZPliku = null;
        List<Regula> reguly = new List<Regula>();
        List<List<Obiekt>> listaKonceptow = new List<List<Obiekt>>();
        List<List<deskryptor>> najczestszeDeskryptory = new List<List<deskryptor>>();
        public LEM2(Obiekt[] DaneZPliku)
        {
            this.daneZPliku = DaneZPliku;
        }
        public void znajdzReguly()
        {
            ilekonceptow();
            znajdzKoncepty();
            for (int i = 0; i < listaKonceptow.Count; i++)
            {
                czestoscDeskryptorow(i);
                znajdzNajczestszeDeskryptory(i);
            }
            for (int i = 0; i < listaKonceptow.Count; i++)
            {
                utworzRegule(i);
            }
        }
        public void ilekonceptow()
        {
            List<int> znalezioneKoncepty = new List<int>();
            for (int i = 0; i < daneZPliku.Length; i++)
            {
                if (!znalezioneKoncepty.Contains(daneZPliku[i].klasa))
                {
                    znalezioneKoncepty.Add(daneZPliku[i].klasa);
                }
            }
            for (int i = 0; i < znalezioneKoncepty.Count; i++)
            {
                listaKonceptow.Add(new List<Obiekt>());
                najczestszeDeskryptory.Add(new List<deskryptor>());
            }
        }
        public void znajdzKoncepty()
        {
            for (int i = 0; i < daneZPliku.Length; i++)
            {
                listaKonceptow[daneZPliku[i].klasa].Add(daneZPliku[i]);
            }
        }
        public void czestoscDeskryptorow(int numerKoncept)
        {
            for (int i = 0; i < listaKonceptow[numerKoncept].Count; i++)
            {
                for (int j = 0; j < listaKonceptow[numerKoncept].Count; j++)
                {
                    for (int k = 0; k < listaKonceptow[numerKoncept][i].deskryptory.Count(); k++)
                    {
                            if (listaKonceptow[numerKoncept][i].deskryptory[k].wartosc==listaKonceptow[numerKoncept][j].deskryptory[k].wartosc)
                            {
                                listaKonceptow[numerKoncept][i].deskryptory[k].dodajPokrywajacyObiekt(j);
                            }
                    }
                }
            }
        }
        public void znajdzNajczestszeDeskryptory(int numerKonceptu)
        {
            najczestszeDeskryptory[numerKonceptu].Clear();
            najczestszeDeskryptory[numerKonceptu] = new List<deskryptor>();
            for (int i = 0; i < listaKonceptow[numerKonceptu].Count; i++)
            {
                
                for (int j = 0; j < listaKonceptow[numerKonceptu][i].deskryptory.Count(); j++)
                {
                    if (najczestszeDeskryptory.Count>0&&!najczestszeDeskryptory[numerKonceptu].Contains(listaKonceptow[numerKonceptu][i].deskryptory[j]))
                    {
                        najczestszeDeskryptory[numerKonceptu].Add(listaKonceptow[numerKonceptu][i].deskryptory[j]);
                    }
                }
            }
            najczestszeDeskryptory[numerKonceptu].OrderBy(x => -1 * x.wystapienie.Count()).ThenBy(x => -1* x.indeks);
        }
        public void znajdzNajczestszeDeskryptory(int numerKonceptu, List<int> wykluczone)
        {
            najczestszeDeskryptory[numerKonceptu].Clear();
            najczestszeDeskryptory[numerKonceptu] = new List<deskryptor>();
            for (int i = 0; i < listaKonceptow[numerKonceptu].Count; i++)
            {
                if (!wykluczone.Contains(i))
                {

                }
                for (int j = 0; j < listaKonceptow[numerKonceptu][i].deskryptory.Count(); j++)
                {
                    if (najczestszeDeskryptory.Count > 0 && !najczestszeDeskryptory[numerKonceptu].Contains(listaKonceptow[numerKonceptu][i].deskryptory[j]))
                    {
                        najczestszeDeskryptory[numerKonceptu].Add(listaKonceptow[numerKonceptu][i].deskryptory[j]);
                    }
                }
            }
            najczestszeDeskryptory[numerKonceptu].OrderBy(x => -1 * x.wystapienie.Count()).ThenBy(x => -1 * x.indeks);
        }
        public void utworzRegule(int numerKoncepptu)
        {
            List<deskryptor> regulaTmp = new List<deskryptor>();

                for (int i = 0; i < najczestszeDeskryptory[numerKoncepptu].Count; i++)
                {
                    if (czyNieZawiera(najczestszeDeskryptory[numerKoncepptu][i],regulaTmp)&&czyOBiektuzyty(najczestszeDeskryptory[numerKoncepptu][i]))
                    {
                        if (czyPodobny(najczestszeDeskryptory[numerKoncepptu][i],regulaTmp))
                        {
                            regulaTmp.Add(najczestszeDeskryptory[numerKoncepptu][i]);
                            if (testujRegule(regulaTmp,numerKoncepptu))
                            {
                                reguly.Add(new Regula(numerKoncepptu, regulaTmp));
                                regulaTmp = new List<deskryptor>();
                            }
                            if(regulaTmp.Count()==6)
                            {
                                regulaTmp = new List<deskryptor>();
                            }
                        }
                    }
                }
            
            znajdzNajczestszeDeskryptory(numerKoncepptu);
        }

        private bool czyOBiektuzyty(deskryptor deskryptor)
        {
            //chuj wi jak to napisac
            int pokrycie = 0;
            for (int i = 0; i < reguly.Count; i++)
            {
                for (int j = 0; j < deskryptor.wystapienie.Count(); j++)
                {
                    if (reguly[i].obiektyWspierane.Contains(deskryptor.wystapienie[j]))
                    {
                        pokrycie++;
                        //deskryptor.wystapienie.Remove(deskryptor.wystapienie[j]);
                    }
                    if (pokrycie == deskryptor.wystapienie.Count())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool testujRegule(List<deskryptor> regulaTmp, int numerKonceptu)
        {
            if (regulaTmp.Count()==0)
            {
                return false;
            }
            for (int i = 0; i < listaKonceptow.Count; i++)
            {
                if (i!=numerKonceptu)
                {
                    if (!TestujKoncept(regulaTmp, i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool TestujKoncept(List<deskryptor> regulaTmp, int numerKonceptu)
        {
            int sprzecznosc=0;
            for (int i = 0; i < listaKonceptow[numerKonceptu].Count; i++)
            {
                for (int j = 0; j < listaKonceptow[numerKonceptu][0].deskryptory.Count(); j++)
                {
                    for (int k = 0; k < regulaTmp.Count; k++)
                    {
                        if (listaKonceptow[numerKonceptu][i].deskryptory[j].wartosc==regulaTmp[k].wartosc&& listaKonceptow[numerKonceptu][i].deskryptory[j].indeks == regulaTmp[k].indeks)
                        {
                            sprzecznosc += 1;
                        }
                    }
                }
                if (sprzecznosc==regulaTmp.Count)
                {
                    return false;
                }
                sprzecznosc = 0;
            }
            return true;
        }

        private bool czyPodobny(deskryptor deskryptor, List<deskryptor> regulaTmp)
        {
            if (regulaTmp.Count==0)
            {
                return true;
            }
            List<int> podobienstwo =regulaTmp[0].wystapienie;
            for (int i = 0; i < regulaTmp.Count; i++)
            {
                if (regulaTmp[i].wystapienie.Intersect(deskryptor.wystapienie).Count()==0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool czyNieZawiera(deskryptor tst,List<deskryptor> regulaTmp)
        {
            for (int i = 0; i < regulaTmp.Count; i++)
            {
                if (tst.indeks==regulaTmp[i].indeks)
                {
                    return false;
                }
            }
            return true;
        }
        public void wypiszReguły()
        {
            string path = string.Concat(Environment.CurrentDirectory, @"\LEM2.txt");
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
