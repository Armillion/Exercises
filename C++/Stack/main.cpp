#include <iostream>
#include "ArrayStack.h"
#include "LinkedStack.h"
#define N 4

using namespace std;

int main()
{
    ArrayStack<int> stos_tab(N);
    LinkedStack<char> stos_wsk(N);

    if(stos_tab.isEmpty())
        cout << "Stos tablicowy jest pusty" << endl;
    if(stos_wsk.isEmpty())
        cout << "Stos wskaznikowy jest pusty" << endl;

    int a = 1;
    char b = 'a';

    cout << "Dodaje element do obu stosow" << endl;
    stos_tab.push(a);
    stos_wsk.push(b);
    cout << "Gora stosu tablicowego: " << stos_tab.peek() << endl << "Gora stosu wskaznicowego: " << stos_wsk.peek() << endl;
    a++;
    b++;

    while(!stos_tab.isFull() || !stos_wsk.isFull())
    {
        cout << "Dodaje element do obu stosow" << endl;
        stos_tab.push(a);
        stos_wsk.push(b);
        cout << "Gora stosu tablicowego: " << stos_tab.peek() << endl << "Gora stosu wskaznicowego: " << stos_wsk.peek() << endl;

        a++;
        b++;
    }

    while(!stos_tab.isEmpty() || !stos_wsk.isEmpty())
    {
        cout << "Usuwam element z obu stosow" << endl;
        stos_tab.pop();
        stos_wsk.pop();
        cout << "Gora stosu tablicowego: " << stos_tab.peek() << endl << "Gora stosu wskaznicowego: " << stos_wsk.peek() << endl;

    }

    return 0;
}
