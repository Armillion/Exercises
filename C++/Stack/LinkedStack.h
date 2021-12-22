#ifndef LINKEDSTACK_H
#define LINKEDSTACK_H

#include "Stack.h"

template <class T>
class LinkedStack : public Stack<T>
{
private:

    int rozmiar;        //ilosc elementow obecnie w kolejce
    int maxRozmiar;     //maksymalna ilosc elementow
    struct Node
    {
        T data;
        Node* next;
    };
    Node* top;          //wskaznik na poczatek kolejki


public:

    //konstruktor
    LinkedStack(int rozm)
    {
        rozmiar = 0;
        top = NULL;
        maxRozmiar = rozm;
    };

    //dekonstruktor
    ~LinkedStack()
    {
        Node* obecny = top;
        while( obecny != NULL )          //usuwamy elementy kolejki
        {
            Node* next = obecny->next;
            delete obecny;
            obecny = next;
        }
    };

    //usuwamy pierwszy element z kolejki
    //w przypadku gdy nie ma 1 elementu nie robimy nic
    void pop()
    {
        if(top == NULL)
            return;

        rozmiar--;
        Node* tmp = top;
        top = top->next;

        delete(tmp);
        return;
    }

    int getSize()
    {
        return rozmiar;
    }

    //dodaje element na koniec kolejki
    bool push(T element)
    {
        if(isFull())
            return false;

        rozmiar++;

        Node* nowy = new Node;
        nowy->data = element;

        if(top == NULL)
        {
            top = nowy;
            return true;
        }

        nowy->next = top;
        top = nowy;

        return true;
    }

    bool isEmpty()
    {
        if(rozmiar == 0)
            return true;

        return false;
    }

    T peek()
    {
        if(rozmiar == 0)
            return (T)NULL;

        return top->data;
    }
    bool isFull()
    {
        if(rozmiar == maxRozmiar)
            return true;

        return false;
    }

};

#endif // LINKEDSTACK_H
