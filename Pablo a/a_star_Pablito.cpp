#include <iostream>
#include <fstream>
#include <cmath>
#include <vector>

using namespace std;

int celx;
int cely;
double **G;
double euklides (int pozx, int pozy) // krok 2 dobieramy heurystyke
{
	return sqrt (pow((pozx - celx),2)+pow((pozy - cely),2));   // równanie H
}
 class kratka                      //   krok 1 ustalenie sposobu poruszania sie
        {
		public:
        int x;
        int y;
        int g;
        double h;
        double f;
        int rodzic;
        void ustawg(int grodzica){
        	g = grodzica + 1;
		}
		void ustawh(){
			h = euklides(x,y);
		}
		void ustawf(){
			f = g + h;
		}
    };
std::vector < kratka > listaotwarta;     //krok 5 
std::vector < kratka > listazamknieta;   //
//sprawdzamy czy rozwa¿ane pole nie jest dodane juz do listy zamknietej
bool NieMaNaZamknietej(int x, int y)
{
	for(int i=0;i<listazamknieta.size();i++)
	{
		if(listazamknieta[i].x==x&&listazamknieta[i].y==y)return false;
	}
	return true;
}
//patrzymy czy rozwazane pole jest juz na liscie otwartej
int IstniejeNaOtwartej(int x, int y)
{
	if(listaotwarta.size()>0)
	{
		for(int i=0;i<listaotwarta.size();i++)
		{
			if(listaotwarta[i].x==x&&listaotwarta[i].y==y)return i;
		}
	}
	return -1;
}
// pkt 6. przegladamy pola wokó³ ostatniego pola na liscie zamknietej
           
void przegladaj()            // funckja do kroku 6 
{
	int przegladx[4]={0,-1,0,1};
	int przeglady[4]={1,0,-1,0};
	int xrodzica= listazamknieta.back().x;	
	int yrodzica= listazamknieta.back().y;
	int grodzica= listazamknieta.back().g;
	
	for(int i=0;i<4;i++)
	{
		//dla przejrzystosci kodu przegladane wartosci przechowujemy w zmiennych tymczasowych
		int tmpx=xrodzica+przegladx[i];
		int tmpy=yrodzica+przeglady[i];
		//przegl¹damy pola wokó³ rodzica, zmieniamy x i y odpowiednio o wartoœæ z tablicy przegladx i przeglady czy nie s¹ przeszkodami
		if(tmpx>=0 && tmpx<=19 && tmpy>=0 && tmpy<=19 && G[tmpx][tmpy]==0&&NieMaNaZamknietej(tmpx,tmpy))//krok 3 sposoby rozwiazywania konfliktów
		{
			int indeks=-1;
			kratka obiektSprawdzany;
			obiektSprawdzany.x=tmpx;
			obiektSprawdzany.y=tmpy;
			obiektSprawdzany.ustawh();
			obiektSprawdzany.ustawg(grodzica);
			obiektSprawdzany.ustawf();
			obiektSprawdzany.rodzic= listazamknieta.size()-1;
			//cout<<"wartosc x"<<obiektSprawdzany.x<<" wartosc y "<<obiektSprawdzany.x<<endl;
			//2
			indeks=IstniejeNaOtwartej(tmpx,tmpy);
			if(indeks!=-1)                              //krok 3
			{
				//jesli znajdzie na liscie otwartej obiekt z takimi samymi wspolrzednymi to porownujemy ich wartosci f, jesli obiekt juz istniejacy ma wieksza wartosc to jest on zastepowany prze obiekt erozwazany
				if(listaotwarta[indeks].f>obiektSprawdzany.f) //krok 3
				{
					listaotwarta[indeks]=obiektSprawdzany;
				}
			}
			//jesli nie ma takiego obiektu na liscie otwartej to po prostu dodajemy go na liste
			else{
					listaotwarta.push_back(obiektSprawdzany);
				}
		} 
	}	
}

void DodajDoListyZamknietej()          // krok 7 
{
	//jesli lista otwarta nie jest pusta to przenosimy element z listy otwartej na zamknieta
	if(listaotwarta.size()>0)
	{
		int najmniejszy=0;
		if(listaotwarta.size()>1)     
		{
					for(int i=1;i<listaotwarta.size();i++)
					{			
						if(listaotwarta[najmniejszy].f>listaotwarta[i].f)najmniejszy=i;
					}
		}
		listazamknieta.push_back(listaotwarta[najmniejszy]);
		listaotwarta.erase(listaotwarta.begin()+najmniejszy);
	}

}        
bool aGwiazdka(int startx, int starty,int ycel, int xcel)      // funkcja g³ówna , krok 4 , cel i start przyjmowane jako argumenty funkcji
  {
  	
  
  	celx = xcel;
  	cely = ycel;
  	kratka start;
  	start.x=startx;
  	start.y=starty;
  	start.g=0;
  	start.f=-1;
  	listazamknieta.push_back(start);
  	przegladaj();
  	DodajDoListyZamknietej();
	while(listaotwarta.size()>0)  // krok 6 ---> // krok 8 
	{
		
		przegladaj();
		///////////////////////////////////////////////////////	
		//cout<<listaotwarta.size()<<endl;
		
		DodajDoListyZamknietej();
		
		if(listazamknieta.back().x==celx&&listazamknieta.back().y==cely)
		{
			//cout<<"yep iam here"<<endl;
			return true;
		}
	}  
  	return false;
  }
  void rysujDroge() // krok 9 rysuj 
  {
  	
  	kratka koniec=listazamknieta.back();
  	G[koniec.x+1][koniec.y+1]=3;
  	kratka krok = listazamknieta[koniec.rodzic];
  	while(krok.f!=-1)
  	{
  		G[krok.x+1][krok.y+1]=3;
  		krok = listazamknieta[krok.rodzic];
	}
	G[krok.x+1][krok.y+1]=3;
  	
  }      
int main (void) {

cout<<"Wczytywanie danych z pliku\n";

string nazwap="grid.txt";
int wym2=20;
int wym1=20;

//teraz deklarujemy dynamicznie tablice do, której wczytamyu nasz plik,
int rows = wym2+1;

G = new double*[rows];
while(rows--) G[rows] = new double[wym1+1];

cout<<"\n\nNacisnij ENTER aby wczytac tablice o nazwie "<< nazwap;
getchar();

std::ifstream plik(nazwap.c_str());
  
for ( unsigned int i=1;i<wym2+1;i++)    
  {
    for ( unsigned int j=1;j<wym1+1;j++) 
    {
         plik >> G[i][j];
    }
  }  
plik.close();

cout<<"\nWypisujemy na ekran\n\n";
for(int i=1;i<wym2+1;i++)
 {
  for(int j=1;j<wym1+1;j++)
   {
    cout<<" "<<G[i][j];
   }cout<<"\n";
 }
////wywo³anie a gwiazdki
if(aGwiazdka(0,0,19,19))    
{
	rysujDroge();
	cout<<"\nWypisujemy na ekran\n\n";
	for(int i=1;i<wym2+1;i++)
	 {
	  for(int j=1;j<wym1+1;j++)
	   {
	    cout<<" "<<G[i][j];
	   }cout<<"\n";
	 }
}
else{                          // krok 9 niemo¿liwoœæ dotarcia do celu 
	cout<<"nie znaleziono drogi"<<endl;
}

//na koniec czyœcimy pamiêæ po naszej tablicy
for(int i=0;i<wym2+1;i++)
{delete[] G[i];}//czyscimy wiersze
delete[] G;//zwalniamy tablice wskaznikow do wierszy

cout<<"\n\nNacisnij ENTER aby zakonczyc";
getchar();

return 0;
}
