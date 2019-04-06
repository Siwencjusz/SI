#include <iostream>
#include <fstream>
#include <cmath>
#include <vector>
using namespace std;
double **G;
int celx=19;
int cely=19;
double minimum=9999;
class Node
{
	public:
		int g;
		double h;
		double f;
		int cord_x;
		int cord_y;
		int parent_x;
		int parent_y;
		int q_i;
		void H()
		{
			int x=pow((cord_x-celx),2);
			int y=pow((cord_y-cely),2);
			h=sqrt(x+y);
		}
		void F()
		{
			f=h+g;
		}
	
};
std::vector < Node > Ol;
std::vector < Node > Cl;

Node start;


bool find_Cl(int x, int y)
{
 	for(int i=1;i<Cl.size();i++)
 	{
 		if(Cl[i].cord_x==x&&Cl[i].cord_y==y)return 1;  		
	}
	return 0;
}
bool find_Ol(int x, int y)
{
 	for(int i=1;i<Ol.size();i++)
 	{
 		if(Ol[i].cord_x==x&&Ol[i].cord_y==y)return 1;  		
	}
	return 0;
}
int find_and_return_Ol(int x,int y)
{
	
	for(int i=1;i<Ol.size();i++)
 	{
 		if(Ol[i].cord_x==x&&Ol[i].cord_y==y)return i;  		
	}
	return -1;
}
int find_Ol_not_Cl()
{
	for(int i=0;i<Ol.size();i++)
	{
		if(!find_Cl(Ol[i].cord_x,Ol[i].cord_y))return i;
	}
}
bool minimal(double x)
{
	if(minimum>=x)
	{
		//cout<<x<<"\n";
		minimum=x;
		return 1;
	}
	return 0;
}
bool rekonstruuj(int x)
{
	cout<<Cl[x].cord_x<<" "<<Cl[x].cord_y<<"\n";
	if(Cl[x].cord_x==start.cord_x&&Cl[x].cord_y==start.cord_y)
	{
		cout<<"ostatni? "<<Ol[x].cord_x<<"\n";
		cout<<Cl[x].cord_y<<"\n";
		cout<<Cl[x].parent_x<<"\n";
		cout<<Cl[x].parent_y<<"\n";
		cout<<Cl[x].q_i<<" dalej nic nie robie \n";
		G[Cl[x].cord_x+1][Cl[x].cord_y+1]=3;
		return 1;
	}
	G[Cl[x].cord_x+1][Cl[x].cord_y+1]=3;
	if(Cl[x].q_i!=-1);rekonstruuj(Cl[x].q_i);
	if(Cl.size()==x-1)cout<<"nie znaleziono drogi";
}
bool a_star()
{	
	while(!Ol.empty())
	{
		minimum=999;
		int Q=find_Ol_not_Cl();
		for(int i=Ol.size()-1;i>-1;i--)
		{
			if(!find_Cl(Ol[i].cord_x,Ol[i].cord_y)&&minimal(Ol[i].f))
			{
				int Q=i;
			}
		}
		Cl.push_back(Ol[Q]);
		Ol.erase(Ol.begin()+Q);
		
		int newQ=Cl.size()-1;
		if(Cl[newQ].cord_x==celx&&Cl[newQ].cord_y==cely)
		{
			rekonstruuj(newQ);
			return 1;
		}
				int przegladx[4]={0,-1,0,1};
		int przeglady[4]={1,0,-1,0};
		for(int i=0;i<4;i++){
			
			int tmpx=Cl[newQ].cord_x+przegladx[i];	
			int tmpy=Cl[newQ].cord_y+przeglady[i];
			if(tmpx>=0&&tmpy>=0&&tmpx<20&&tmpy<20)
			{
				if(find_Cl(tmpx,tmpy)||G[tmpx+1][tmpy+1]==5)
				{
					
				}
				else if(!find_Ol(tmpx,tmpy))
				{
					Node nowy;
					nowy.parent_x=Cl[newQ].cord_x;
					nowy.parent_y=Ol[newQ].cord_y;
					nowy.cord_x=tmpx;
					nowy.cord_y=tmpy;
					nowy.q_i=newQ;
					nowy.g=Cl[newQ].g+1;
					nowy.H();
					nowy.F();
					Ol.push_back(nowy);
				}
				else
				{
					int tmpg=Cl[newQ].g+1;
					int indeks=find_and_return_Ol(tmpx,tmpy);
					if(Ol[indeks].g>tmpg)
					{
						Ol[indeks].q_i=newQ;
						Ol[indeks].parent_x=Cl[newQ].cord_x;
						Ol[indeks].parent_y=Cl[newQ].cord_y;
						Ol[indeks].g=tmpg;
						Ol[indeks].H();
						Ol[indeks].F();
					}
					
				}
			}
		}
	
	}
	cout<<"nie znaleziono drogi";
	return 0;
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
 
 
 
 
 
 
 
 
 
 //////////////////////////////////
start.g=0;
start.H();
start.F();
start.cord_x=0;
start.cord_y=0;
start.q_i=-1;
Ol.reserve(1000);
Cl.reserve(1000);
Ol.push_back(start);
int wynik=a_star();
if(wynik==0)cout<<"nie znaleziono drogi";
else{
cout<<"\nWypisujemy na ekran\n\n";
for(int i=1;i<wym2+1;i++)
 {
  for(int j=1;j<wym1+1;j++)
   {
    cout<<" "<<G[i][j];
   }cout<<"\n";
 }
	
	
}

 
// double test[20][20];
// for(int j=0;j<Cl.size()-1;j++)
//   {
//    test[Cl[j].cord_x][Cl[j].cord_y]=Cl[j].f;
//   };
// 
//  for(int j=0;j<Ol.size()-1;j++)
//   {
//    test[Ol[j].cord_x][Ol[j].cord_y]=Ol[j].f;
//   };
// 
// cout<<"\nWypisujemy na ekran\n\n";
//for(int i=0;i<20;i++)
// {
//  for(int j=0;j<20;j++)
//   {
//    cout<<" "<<test[i][j];
//   }cout<<"\n";
// }
// 
   
//na koniec czyœcimy pamiêæ po naszej tablicy
for(int i=0;i<wym2+1;i++)
{delete[] G[i];}//czyscimy wiersze
delete[] G;//zwalniamy tablice wskaznikow do wierszy

cout<<"\n\nNacisnij ENTER aby zakonczyc";
getchar();

return 0;
}
