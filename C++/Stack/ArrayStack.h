#ifndef ARRAYSTACK_H
#define ARRAYSTACK_H

#include <iostream>
#include <array>
#include "Stack.h"
#pragma once
template <class T>
class ArrayStack : public Stack<T>
{
private:
    int rozmiar;            //obecny roazmiar stosu
    int maxRozmiar;         //maksymalna ilosc elementow
    T* zawartosc;           //sama tablica elementow T

public:

    //konstruktor
    ArrayStack(int rozm)
    {
        this->maxRozmiar = rozm;
        this->zawartosc = new T[rozm];
        this->rozmiar = 0;
    }

    //dekonstruktor
    ~ArrayStack()
    {
        delete[] zawartosc;
    }

    //zwraca obecna ilosc elementow
    int getSize()
    {
        return rozmiar;
    }

    //dodaje 1 element na koniec, zwraca false w przypadku wyjscia poza rozmiar
    bool push(T element)
    {
        if(rozmiar > maxRozmiar - 1 )
            return false;

        rozmiar++;
        zawartosc[rozmiar - 1] = element;
        if(zawartosc[rozmiar -1] != element)
        {
            return false;
        }

        return true;
    }

    //usuwa element z konca stosu
    void pop()
    {
        if(isEmpty())
            return;

        rozmiar--;

        return;
    }

    //zwraca true jesli stos jest pusty
    bool isEmpty()
    {
        if(rozmiar == 0)
            return true;

        return false;

    }

    //zwraca ostatni element stosu
    //jesli stos jest pusty zwraca NULL
    T peek()
    {
        if(isEmpty())
            return (T)NULL;

            return zawartosc[rozmiar - 1];
    }

    bool isFull()
    {
        if(rozmiar == maxRozmiar)
            return true;

        return false;
    }

};


#endif // ARRAYSTACK_H
