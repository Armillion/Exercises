#ifndef LINKEDQUEUE_H
#define LINKEDQUEUE_H
#include "queue.h"

template <class T>
class LinkedQueue : public queue<T>
{
private:

    int rozmiar;        //ilosc elementow obecnie w kolejce
    struct Node
    {
        T data;
        Node* next;
    };
    Node* n_front;      //wskaznik na poczatek kolejki
    Node* n_rear;       //wskaznik na koniec kolejki

public:

    //konstruktor
    LinkedQueue() : rozmiar(0),n_front(NULL),n_rear(NULL)
    { };

    //dekonstruktor
    ~LinkedQueue()
    {
        Node* obecny = n_front;
        while( obecny != NULL )          //usuwamy elementy kolejki
        {
            Node* next = obecny->next;
            delete obecny;
            obecny = next;
        }
        delete(next);
        delete(n_front);
        delete(n_rear);
    };

    //usuwamy pierwszy element z kolejki
    //w przypadku gdy nie ma 1 elementu nie robimy nic
    void dequeue()
    {
        if(n_front == NULL)
            return;

        rozmiar--;
        Node* tmp = n_front;
        n_front = n_front->next;

        if(n_front == NULL)
            n_rear = NULL;

        delete(tmp);
        return;
    }

    int getSize()
    {
        return rozmiar;
    }

    //dodaje element na koniec kolejki
    bool enqueue(T element)
    {
        rozmiar++;

        Node* nowy = new Node;
        nowy->data = element;

        if(n_rear == NULL)
        {
            n_front = nowy;
            n_rear = nowy;
            return true;
        }

        n_rear->next = nowy;
        n_rear = nowy;

        return true;
    }

    bool isEmpty()
    {
        if(rozmiar == 0)
            return true;

        return false;
    }

    T front()
    {
        if(rozmiar == 0)
            return (T)NULL;

        return n_front->data;
    }
    T rear()
    {
        if(rozmiar == 0)
            return (T)NULL;

        return n_rear->data;
    }

};


#endif // LINKEDQUEUE_H
