#include <iostream>
#include <fstream>
#include <cstdio>
#include <vector>
#include <math.h>

using namespace std;

double **G;
int xcel = 20;
int ycel = 20;
class kwadrat;

std::vector < kwadrat > otwarta;
std::vector < kwadrat > zamknieta;
class kwadrat {
	public :int x;
	public :int y;

	public :int pozycjaRodzica;

	public :double koszt;
	public :double euklides;
	public :double fx;

	public :void eukalidesLicz() {
		euklides = sqrt(pow((double)(x - xcel),2) + pow((double)(y - ycel),2));
	}
	public :void kosztLicz() {
		koszt = zamknieta[pozycjaRodzica].koszt+1;
	}
	public :void fxLicz() {
		fx = koszt + euklides;
	}
};
kwadrat start;
int najmniejszeFx (){
	if(otwarta.size()==1){
		return 0;
	}
	kwadrat tmpMin = otwarta[0];
	int pozycja=0;
	for(int i=1;i<otwarta.size();i++)
	{
		if(tmpMin.fx>otwarta[i].fx)
		{
			tmpMin=otwarta[i];
			pozycja=i;
		}
	}
	return pozycja;
	
}
void sprawdzObiekt (kwadrat jedynka){
	int tempx=jedynka.x;
	int tempy=jedynka.y;
	double tempfx=jedynka.fx;
	bool flaga = false;
	int max_i=(int)otwarta.size();
	for(int i=0;i<max_i;i++){
		if(otwarta[i].x==tempx && otwarta[i].y==tempy)
		{
			flaga = true;
			if(otwarta[i].fx>tempfx)
			{
				otwarta[i]=jedynka;
			}
			break;
		}
	}
	if(flaga==false)
	{
		otwarta.push_back(jedynka);
	}
}

bool czyCel(){
	if(zamknieta[zamknieta.size()-1].x == xcel && zamknieta[zamknieta.size()-1].y == ycel)
	{
		return true;
	}
	return false;
	
}

void powrot (){
	kwadrat temp=zamknieta[zamknieta.size()-1];
	while(temp.x != start.x ||temp.y != start.y){
		G[temp.x][temp.y] = 1;
		temp=zamknieta[temp.pozycjaRodzica];
	}
	G[start.x][start.y]=4;
	G[xcel][ycel]=7;
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
   




start.x = 1;
start.y = 1;

start.pozycjaRodzica = -1;
start.koszt = 0;

zamknieta.push_back(start);
bool prawda = true;
while(prawda)
{
	int tmpx = zamknieta[zamknieta.size() - 1].x;
	int tmpy = zamknieta[zamknieta.size() - 1].y;
	int tabx [4] = {0, -1, 0, 1};
	int taby [4]= {-1, 0, 1, 0};
	int pozRodz=zamknieta.size()-1;
	for (int i = 0;i<4;i++){
		if (tmpx+tabx[i]>=1 && tmpx+tabx[i]<=20 && tmpy+taby[i]>=1 && tmpy+taby[i]<=20 && G[tmpx+tabx[i]][tmpy+taby[i]]!=5){
			kwadrat jeden;
			jeden.x=tmpx+tabx[i];
			jeden.y=tmpy+taby[i];
			jeden.pozycjaRodzica = pozRodz;
			jeden.eukalidesLicz();
			jeden.kosztLicz();
			jeden.fxLicz();
			sprawdzObiekt(jeden);
		}
	}
	
	if(otwarta.size()==0){
		cout<<"Nie mo¿na osi¹gn¹æ celu"<<endl;
		prawda = false;
	}
	if(otwarta.size()>0){
		int pozycja=najmniejszeFx();
		zamknieta.push_back(otwarta[pozycja]);
		otwarta.erase (otwarta.begin()+pozycja);	
	}
	if(czyCel())
	{
		cout<<"Cel zosta³ osi¹gniety"<<endl;
		prawda =false;
		powrot();
	}
	
}
for(int i=1;i<wym2+1;i++)
 {
  for(int j=1;j<wym1+1;j++)
   {
    cout<<" "<<G[i][j];
   }cout<<"\n";
 }

//na koniec czyœcimy pamiêæ po naszej tablicy
for(int i=0;i<wym2+1;i++)
{delete[] G[i];}//czyscimy wiersze
delete[] G;//zwalniamy tablice wskaznikow do wierszy


cout<<"\n\nNacisnij ENTER aby zakonczyc";
getchar();

return 0;
}
