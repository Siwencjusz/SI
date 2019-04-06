
#include<iostream>
#include<fstream>
#include<string>
#include<vector>
#include<conio.h>
#include<math.h>
#include <cstring>

using namespace std;

void wczytanie_mapy(char*);
void wczytajPozycje();
void blokuj(int index);
void wypisanieMacierzy();
int wyszukajNajmniejszy();
void cofanie();
void liczeniePol(int x, int y, int skok);
void usuwanie(int x, int y);
bool czyIstnieje(int w, int k, int Rw, int Rk, double heurystyka, int skok);

struct ElZamkienty
{
	int X;
	int Y;
	int RX;
	int RY;
};

struct ElOtwarty
{
	double wartosc;
	int X;
	int Y;
	int RX;
	int RY;
	int skok;
};

vector<ElZamkienty> ListaZamknieta;
vector<ElOtwarty> ListaOtwarta;
int mapa[20][20];
int startX;
int startY;
int celX;
int celY;

int main(int argc, char *argv[])
{
	std::string str = "grid.txt";
	char *cstr = new char[str.length() + 1];
	strcpy(cstr, str.c_str());
	
	wczytanie_mapy(cstr);
	
	wczytajPozycje();
	while (ListaOtwarta.size() > 0)
	{
		blokuj(wyszukajNajmniejszy());
		if (ListaZamknieta[ListaZamknieta.size() - 1].X == celX && ListaZamknieta[ListaZamknieta.size() - 1].Y == celY)
			break;
	}
	if (!(ListaZamknieta[ListaZamknieta.size() - 1].X == celX && ListaZamknieta[ListaZamknieta.size() - 1].Y == celY))
	{
		cout << "Brak rozwiazania" << endl;
		_getch();
		return 0;
	}
	cofanie();
	wypisanieMacierzy();
	_getch();
	return 0;
}

void wczytanie_mapy(char* plik)
{
	ifstream myfile(plik);
	string line;
	if (myfile.is_open())
	{
		for (int i = 0; i < 20; i++)
		{
			getline(myfile, line);
			int j = 0;
			int point = 0;
			while (line[point] != '\0')
			{
				if (line[point] != ' ')
					mapa[i][j++] = line[point] - 48;
				point++;
			}
		}
	}
}

void wczytajPozycje()
{
	cout << "Podaj poczatkowy X:";
	cin >> startY;
	startY = startY;
	cout << "Podaj poczatkowy Y:";
	cin >> startX;
	startX = 19 - startX;
	cout << "Podaj celowy X:";
	cin >> celY;
	celY = celY;
	cout << "Podaj celowy Y:";
	cin >> celX;
	celX = 19 - celX;

	ElOtwarty piewszy;
	piewszy.RX = -1;
	piewszy.RY = -1;
	piewszy.skok = 1;
	piewszy.wartosc = 0;
	piewszy.X = startX;
	piewszy.Y = startY;
	ListaOtwarta.push_back(piewszy);
}

bool czyZawiera(int x, int y)
{
	for (int i = 0; i < ListaZamknieta.size(); i++)
	{
		if (ListaZamknieta[i].X == x && ListaZamknieta[i].Y == y)
			return true;
	}
	return false;
}

void liczeniePol(int x, int y, int skok)
{
	if (y < 19 && mapa[x][y + 1] == 0 && !czyZawiera(x, y + 1) && !czyIstnieje(x, y + 1, x, y, sqrt((x - celX)*(x - celX) + ((y + 1) - celY)*((y + 1) - celY)) + skok, skok + 1)) // prawa
	{
		ElOtwarty nowy;
		nowy.RX = x;
		nowy.RY = y;
		nowy.skok = skok + 1;
		nowy.wartosc = sqrt((x - celX)*(x - celX) + ((y + 1) - celY)*((y + 1) - celY)) + skok;
		nowy.X = x;
		nowy.Y = y + 1;
		ListaOtwarta.push_back(nowy);
	}
	if (x > 0 && mapa[x - 1][y] == 0 && !czyZawiera(x - 1, y) && !czyIstnieje(x - 1, y, x, y, sqrt((x - 1 - celX)*(x - 1 - celX) + (y - celY)*(y - celY)) + skok, skok + 1)) // gora
	{
		ElOtwarty nowy;
		nowy.RX = x;
		nowy.RY = y;
		nowy.skok = skok + 1;
		nowy.wartosc = sqrt(((x - 1) - celX)*((x - 1) - celX) + (y - celY)*(y - celY)) + skok;
		nowy.X = x - 1;
		nowy.Y = y;
		ListaOtwarta.push_back(nowy);
	}
	if (y > 0 && mapa[x][y - 1] == 0 && !czyZawiera(x, y - 1) && !czyIstnieje(x, y - 1, x, y, sqrt((x - celX)*(x - celX) + ((y - 1) - celY)*((y - 1) - celY)) + skok, skok + 1)) // lewa
	{
		ElOtwarty nowy;
		nowy.RX = x;
		nowy.RY = y;
		nowy.skok = skok + 1;
		nowy.wartosc = sqrt((x - celX)*(x - celX) + ((y - 1) - celY)*((y - 1) - celY)) + skok;
		nowy.X = x;
		nowy.Y = y - 1;
		ListaOtwarta.push_back(nowy);
	}
	if (x < 19 && mapa[x + 1][y] == 0 && !czyZawiera(x + 1, y) && !czyIstnieje(x + 1, y, x, y, sqrt((x + 1 - celX)*(x + 1 - celX) + (y - celY)*(y - celY)) + skok, skok + 1)) // dol
	{
		ElOtwarty nowy;
		nowy.RX = x;
		nowy.RY = y;
		nowy.skok = skok + 1;
		nowy.wartosc = sqrt(((x + 1) - celX)*((x + 1) - celX) + (y - celY)*(y - celY)) + skok;
		nowy.X = x + 1;
		nowy.Y = y;
		ListaOtwarta.push_back(nowy);
	}
}

int wyszukajNajmniejszy()
{
	int index = ListaOtwarta.size() - 1;
	double war = ListaOtwarta[ListaOtwarta.size() - 1].wartosc;

	for (int i = ListaOtwarta.size() - 2; i >= 0; i--)
	{
		if (ListaOtwarta[i].wartosc < war)
		{
			war = ListaOtwarta[i].wartosc;
			index = i;
		}
	}
	return index;
}

void blokuj(int index)
{
	ElZamkienty nowy;
	nowy.RX = ListaOtwarta[index].RX;
	nowy.RY = ListaOtwarta[index].RY;
	nowy.X = ListaOtwarta[index].X;
	nowy.Y = ListaOtwarta[index].Y;
	liczeniePol(ListaOtwarta[index].X, ListaOtwarta[index].Y, ListaOtwarta[index].skok);
	usuwanie(nowy.X, nowy.Y);
	ListaZamknieta.push_back(nowy);
}

void cofanie()
{
	mapa[ListaZamknieta[ListaZamknieta.size() - 1].X][ListaZamknieta[ListaZamknieta.size() - 1].Y] = 3;
	int rodzicX = ListaZamknieta[ListaZamknieta.size() - 1].RX;
	int rodzicY = ListaZamknieta[ListaZamknieta.size() - 1].RY;
	for (int i = ListaZamknieta.size() - 2; i >= 0; i--)
	{
		if (ListaZamknieta[i].X == rodzicX && ListaZamknieta[i].Y == rodzicY)
		{
			mapa[ListaZamknieta[i].X][ListaZamknieta[i].Y] = 3;
			rodzicX = ListaZamknieta[i].RX;
			rodzicY = ListaZamknieta[i].RY;
		}
	}
}

void wypisanieMacierzy()
{
	for (int i = 0; i < 20; i++)
	{
		for (int j = 0; j < 20; j++)
		{
			cout << mapa[i][j] << " ";
		}
		cout << endl;
	}
}

void usuwanie(int x, int y)
{
	for (int i = ListaOtwarta.size() - 1; i >= 0; i--)
	{
		if (ListaOtwarta[i].X == x && ListaOtwarta[i].Y == y)
		{
			ListaOtwarta.erase(ListaOtwarta.begin() + i);
		}
	}
}


bool czyIstnieje(int w, int k, int Rw, int Rk, double heurystyka, int skok)
{
	for (int i = 0; i < ListaOtwarta.size(); i++)
	{
		if (ListaOtwarta[i].X == w && ListaOtwarta[i].Y == k)
		{
			if (heurystyka < ListaOtwarta[i].wartosc)
			{
				ListaOtwarta[i].RX = Rw;
				ListaOtwarta[i].RY = Rk;
				ListaOtwarta[i].wartosc = heurystyka;
				ListaOtwarta[i].skok = skok;
			}
			return true;
		}
	}
	return false;

}
