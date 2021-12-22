#ifndef ARRAYQUEUE_H
#define ARRAYQUEUE_H

#include <iostream>
#include <array>
#include "queue.h"
#pragma once
template <class T>
class ArrayQueue : public queue<T>
{
private:
    int rozmiar;            //pozycja koncowa
    int maxRozmiar;         //maksymalna ilosc elementow w danym momencie
    T* zawartosc;           //sama tablica elementow T
    int elementy;           //ilosc elementow w kolejce

public:

    //konstruktor
    ArrayQueue(int rozm)
    {
        this->maxRozmiar = rozm;
        this->zawartosc = new T[rozm];
        this->rozmiar = 0;
        this->elementy = 0;
    }

    //dekonstruktor
    ~ArrayQueue()
    {
        delete[] zawartosc;
    }

    //zwraca obecna ilosc elementow
    int getSize()
    {
        return elementy;
    }

    //dodaje 1 element na koniec, zwraca false w przypadku wyjscia poza rozmiar kolejki
    bool enqueue(T element)
    {
        if(rozmiar > maxRozmiar - 1 )
            return false;

        rozmiar++;
        elementy++;
        zawartosc[rozmiar - 1] = element;
        if(zawartosc[rozmiar -1] != element)
        {
            return false;
        }

        return true;
    }

    //usuwa element z poczatku
    void dequeue()
    {
        if(isEmpty())
            return;

        if(rozmiar == 0 && elementy == maxRozmiar)
            rozmiar = maxRozmiar;
        rozmiar--;
        elementy--;


        for (int x = 0; x < elementy; x++)
        {
            zawartosc[x] = zawartosc[x + 1];
        }

        return;
    }

    //zwraca true jesli kolejka jest pusta
    bool isEmpty()
    {
        if(elementy == 0)
            return true;

        return false;

    }

    //zwraca ostatni element kolejki
    //jesli kolejka jest pusta zwraca NULL
    T rear()
    {
        if(isEmpty())
            return (T)NULL;

        if(rozmiar != 0)
            return zawartosc[rozmiar - 1];
        else
            return zawartosc[0];
    }

    //zwraca pierwszy element kolejki
    //jesli jest pusta zwraca NULL
    T front()
    {
        if(isEmpty())
            return (T)NULL;

        return zawartosc[0];
    }

};



#endif // ARRAYQUEUE_H
