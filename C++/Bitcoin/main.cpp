#include <iostream>
#include "sha256.h"
#include <string>
#include <chrono>
#define MAX_NR 1000000000

using namespace std;
using namespace chrono;

string kop(int nr_bloku,const string transakcje, const string poprzedni,int trudnosc)
{
    for(int nonce = 1; nonce < MAX_NR; nonce++ )
    {
        string tekst = to_string(nr_bloku) + transakcje + poprzedni + to_string(nonce);
        SHA256 sha;
        string wynik = sha(tekst);
        for(int i = 0; i < trudnosc; i++)
        {
            if(wynik[i] != '0')
            {
                break;
            }
            if(i == trudnosc-1)
            {
                cout << "Hurra, jestesmy bogaci!\n" << wynik << endl;
                return wynik;
            }
        }
    }
    throw out_of_range("Za duzo roboty\n");
}

int main()
{
    string transakcja = "Oswald->Kamil->20";
    int poziom = 6;
    for(int i = 1; i <= poziom; i++)
    {
        auto czas_pocz = high_resolution_clock::now();
        kop(5,transakcja,"0000000000000000000128a2d002db3f28d8fef87566004830085dca27ae0cc0",i);
        auto czas_kon = high_resolution_clock::now();
        auto czas = duration_cast<microseconds>(czas_kon - czas_pocz);
        cout << "Z trudnoscia " << i << " zajelo mi to " << czas.count() << " mikrosekund\n";
    }
    return 0;
}
