#include <iostream>
#include "LinkedList.h"

using namespace std;

int main()
{
    LinkedList<int> lista;
    lista.insert(0,2);
    lista.insert(1,3);
    lista.insert(2,4);

    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    lista.remove(2);
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    lista.push_front(5);
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    lista.push_back(10);
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }


    cout << endl;
    lista.pop_back();
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }


    lista.push_back(10);
    lista.push_back(10);
    lista.push_back(3);
    lista.push_back(10);
    cout << endl;
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    lista.delete_elements(10);
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    lista.delete_duplicate(3);
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    lista.reverse();
    for(int i = 0; i < lista.getSize() ; i++)
    {
        cout << lista.get(i) << " ";
    }

    cout << endl;
    cout << lista.first();
    cout << endl;
    cout << lista.last();
    cout << endl;

    return 0;
}

