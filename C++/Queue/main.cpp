#include <iostream>
#include "ArrayQueue.h"
#include "LinkedQueue.h"

using namespace std;

int main()
{
    ArrayQueue<int> kolejka(3);


    cout << "dodaje 1" << endl;
    kolejka.enqueue(1);
    cout << "poczatek: " << kolejka.front() << endl;
    cout << "koniec: " << kolejka.rear() << endl;
    cout << "dodaje 2" << endl;
    kolejka.enqueue(2);
    cout << "poczatek: " << kolejka.front() << endl;
    cout << "koniec: " << kolejka.rear() << endl;
    cout << "dodaje 3" << endl;
    kolejka.enqueue(3);
    cout << "poczatek: " << kolejka.front() << endl;
    cout << "koniec: " << kolejka.rear() << endl;
    cout << "usuwam 1" << endl;
    kolejka.dequeue();
    cout << "poczatek: " << kolejka.front() << endl;
    cout << "koniec: " << kolejka.rear() << endl;


    while(!kolejka.isEmpty())
    {
        kolejka.dequeue();
        cout << kolejka.front() << endl;
        cout << kolejka.rear() << endl;
    }

    LinkedQueue<int> kolejka2;
    cout << endl;

    cout << "dodaje 1" << endl;
    kolejka2.enqueue(1);
    cout << "poczatek: " << kolejka2.front() << endl;
    cout << "koniec: " << kolejka2.rear() << endl;
    cout << "dodaje 2" << endl;
    kolejka2.enqueue(2);
    cout << "poczatek: " << kolejka2.front() << endl;
    cout << "koniec: " << kolejka2.rear() << endl;
    cout << "dodaje 3" << endl;
    kolejka2.enqueue(3);
    cout << "poczatek: " << kolejka2.front() << endl;
    cout << "koniec: " << kolejka2.rear() << endl;
    cout << "usuwam 1" << endl;
    kolejka2.dequeue();
    cout << "poczatek: " << kolejka2.front() << endl;
    cout << "koniec: " << kolejka2.rear() << endl;


    while(!kolejka2.isEmpty())
    {
        kolejka2.dequeue();
        cout << kolejka2.front() << endl;
        cout << kolejka2.rear() << endl;
    }

    return 0;
}
