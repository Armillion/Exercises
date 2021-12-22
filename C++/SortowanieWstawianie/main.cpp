#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

//wrazliwosc to sup(zlozonosc1 - zlozonosc2), gdzie zlozonosc 1 i 2 to
//ilosci operacji dla dowolnych tablic rozmiaru n, wiêc zawsze bedzie ona
//wygladac tak: przypadek pesymistyczny - przypadek optymistyczny
//pesymistyczny wynosi n*(n-1)/2 + 1, optymistyczny n - 1 - ztad zwracana wartosc
int szacowanie_wrazliwosci(const int& n)
{
    return (n*(n-1)/2 + n - 1) - (n - 1);
}

//zwraca zlozonosc pesymistyczna
int szacowanie_pesymistycznej(const int& n)
{
    return n*(n-1)/2 + n - 1;
}

//w itracji petli nr i wykonujemy srednio (i+1)2 operacji
//by wyliczyc sredni¹ zlorzonosc zsumujemy srednia iliosc
//dla kazdej iteracji petli
int szacowanie_sredniej(const int& n)
{
    int wynik = 0;
    for(int i = 1; i < n; i++)
    {
        wynik += (i+1)/2;
    }
    return wynik;
}

//zastosowanie algorytmy sortawania przez wstawianie
//zwraca ilosc operacji dominujacych, naliczanych w trakcie wykonywania funkcji
int sortowanie_przez_wstawianie(int n, int *tab)
{
    int pom, j,opDominujace = 0;
    for(int i=1; i<n; i++)
    {
        //wstawienie elementu w odpowiednie miejsce
        pom = tab[i]; //ten element bêdzie wstawiony w odpowiednie miejsce
        j = i-1;

        //przesuwanie elementów wiêkszych od pom
        //operacja dominujaca jest porownanie, wykonuje sie
        //ono tyle razy co wnetrze petli + 1
        while(j>=0 && tab[j]>pom )
        {
            tab[j+1] = tab[j]; //przesuwanie elementów
            --j;
            opDominujace++;
        }
        opDominujace++;     //naliczenie 1 pozostalego porownania
        tab[j+1] = pom; //wstawienie pom w odpowiednie miejsce
    }


    return opDominujace;
}

int main()
{
    //srand() by skozystac z generacji liczb losowych
    srand(time(NULL));

    //prosimy uzytkownika o podanie roamiaru tablcy
    cout << "Podaj prosze rozmiar tablicy wejsciowej:";
    int n;
    cin >> n;

    //inicjujemy tablice o podanym rozmiarze i wypelniamy ja
    //najpierw liczbami posortowanymi
    int *tabDoPosortowania = new int[n];
    cout << "Dzialanie dla tablicy posortawanej:" << endl;
    for(int i = 0; i < n; i++)
    {
        tabDoPosortowania[i] = i;
        cout << tabDoPosortowania[i] << ", ";
    }

    //wypisujemy wyniki
    int iloscOperacjiDominujacych = sortowanie_przez_wstawianie(n,tabDoPosortowania);
    cout << endl << "Ilosc operacji dominujacych wyniosla " << iloscOperacjiDominujacych << endl
         << "Zlozonosc pesymistyczna: " << szacowanie_pesymistycznej(n) << endl
         << "Zlozonosc srednia: " << szacowanie_sredniej(n) << endl
         << "Wrazliwosc pesymistyczna: " <<szacowanie_wrazliwosci(n) << endl;

    //inicjujemy tablice o podanym rozmiarze i wypelniamy ja
    //najpierw liczbami posortowanymi od tylu
    cout << "Dzialanie dla tablicy w przypadku pesymistycznym:" << endl;
    for(int i = 0; i < n; i++)
    {
        tabDoPosortowania[i] = n-i;
        cout << tabDoPosortowania[i] << ", ";
    }

    //wypisujemy wyniki
    iloscOperacjiDominujacych = sortowanie_przez_wstawianie(n,tabDoPosortowania);
    cout << endl << "Ilosc operacji dominujacych wyniosla " << iloscOperacjiDominujacych << endl
         << "Zlozonosc pesymistyczna: " << szacowanie_pesymistycznej(n) << endl
         << "Zlozonosc srednia: " << szacowanie_sredniej(n) << endl
         << "Wrazliwosc pesymistyczna: " <<szacowanie_wrazliwosci(n) << endl;;


    //kolejno wypelniamy tablice losowymi liczbami i rozwarzamy ten przypadek
    cout << "Dzialanie dla tablicy wartosci losowych:" << endl;
    for(int i = 0; i < n; i++)
    {
        tabDoPosortowania[i] = rand()%n;
        cout << tabDoPosortowania[i] << ", ";
    }
    iloscOperacjiDominujacych = sortowanie_przez_wstawianie(n,tabDoPosortowania);

    //ponownie wypisujemy wyniki
    cout << endl << "Ilosc operacji dominujacych wyniosla " << iloscOperacjiDominujacych << endl;
    cout << "Posortowana tablica:" << endl;
    for(int i = 0; i < n; i++)
    {
        cout << tabDoPosortowania[i] << ", ";
    }

    //czyslimy pamiec i konczymy program
    delete(tabDoPosortowania);
    return 0;
}
