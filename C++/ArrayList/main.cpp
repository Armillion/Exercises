#include <iostream>
#include "ArrayList.h"
//#include "ArrayList.cpp"

using namespace std;

int main()
{
    cout << "Podaj rozmiar listy:";
    int n;
    cin >> n;

    //konstruktor
    ArrayList<int> lista1(n);
    ArrayList<char> lista2(n);

    //wypeliamy liste
    //metoda push_back()
    for(int i = 0 ; i < n; i++)
    {
        lista1.push_back(i);
        lista2.push_back('a');
    }

    //wypisujemy zawartosc po kazdej dokonanej operacji
    cout << "Lista integer'ow po wypelnieniu metoda push_back:" << endl;
    for(int i = 0 ; i < lista1.getSize(); i++)
    {
        cout << lista1.get(i) << ", ";
    }
    cout << endl;
    cout << "Lista char'ow po wypelnieniu metoda push_back:" << endl;
    for(int i = 0 ; i < lista2.getSize(); i++)
    {
        cout << lista2.get(i) << ", ";
    }
    cout << endl;

    //wstawmy 1 element
    lista2.insert(0,'b');
    cout << "Lista char'ow po wykonaniu metody insert:" << endl;
    for(int i = 0 ; i < lista2.getSize(); i++)
    {
        cout << lista2.get(i) << ", ";
    }
    cout << endl;

    //zamienmy 1 element
    lista2.set(1,'c');
    cout << "Lista char'ow po wykonaniu metody set:" << endl;
    for(int i = 0 ; i < lista2.getSize(); i++)
    {
        cout << lista2.get(i) << ", ";
    }
    cout << endl;

    //usunmy 1 element
    lista2.remove(1);
    cout << "Lista char'ow po wykonaniu metody remove:" << endl;
    for(int i = 0 ; i < lista2.getSize(); i++)
    {
        cout << lista2.get(i) << ", ";
    }
    cout << endl;

    //zobaczmy na jakiej pozycji jest b
    cout << "b znajduje sie na pozycji " << lista2.find('b') << endl;

    //wepchnijmy na 1 pozycje
    lista1.push_front(-1);
    cout << "Lista integer'ow po wykonaniu metody push_front:" << endl;
    for(int i = 0 ; i < lista1.getSize(); i++)
    {
        cout << lista1.get(i) << ", ";
    }
    cout << endl;

    //usunmy 1 i ostatnia pozycje
    lista1.pop_front();
    lista1.pop_back();
    cout << "Lista integer'ow po wykonaniu metody pop_front i pop_back:" << endl;
    for(int i = 0 ; i < lista1.getSize(); i++)
    {
        cout << lista1.get(i) << ", ";
    }
    cout << endl;

    //usunmy duplikaty z listy charow
    lista2.delete_duplicate('a');
    cout << "Lista char'ow po wykonaniu metody delete_dupicates:" << endl;
    for(int i = 0 ; i < lista2.getSize(); i++)
    {
        cout << lista2.get(i) << ", ";
    }
    cout << endl;

    //zmienmy kolejnosc w liscie intow
    lista1.reverse();
    cout << "Lista char'ow po wykonaniu metody reverse:" << endl;
    for(int i = 0 ; i < lista1.getSize(); i++)
    {
        cout << lista1.get(i) << ", ";
    }
    cout << endl;


    return 0;
}

