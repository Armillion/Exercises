#ifndef ARRAYLIST_H
#define ARRAYLIST_H
#include <iostream>
#include <array>
#include "List.h"
#pragma once
template <class T>
class ArrayList : public List<T>
{
private:
    int rozmiar;            //ilosc elementow obecnie w liscie
    int maxRozmiar;         //maksymalna ilosc elementow w danym momencie
    T* zawartosc;           //sama tablica elementow T

    //prywatna metoda wywolywana w innych metodach, powiekszajacych
    //rozmiar listy, slurzy do powiekszania samej tablicy zawartosc
    //do rozmiaru 2 razy wiekszego niz w danym momencie
    inline void spaceCheck()
    {
        if(rozmiar == maxRozmiar)
        {
            int i;

            //tworzymy tymczasowa tabice i kopiujemy do niej zawartosc
            T *temp = new T[maxRozmiar];
            for (i = 0; i < rozmiar; ++i)
            {
                temp[i] = zawartosc[i];
            }

            //po czym tworzymy nowa wieksza zawartosc
            delete [] zawartosc;
            maxRozmiar += rozmiar;
            zawartosc = new T[maxRozmiar];

            //i spisujemy warotsci z temp po czym je suswamy
            for (i = 0; i < rozmiar; ++i)
            {
                zawartosc[i] = temp[i];
            }

            delete[] temp;
        }
    }

public:

    //wstawia dany element na wybrany index
    bool insert(const int& index, T element)
    {
        if(!(index<rozmiar || index<0))
            return false;

        rozmiar++;
        spaceCheck();

        //przesuwamy wszystkie elementy za podanym indexem na index wyrzej
        for (int i = rozmiar; i >= index ; i--)
        {
            zawartosc[i] = zawartosc[i - 1];
        }

        //wstawiamy sama wartosc i sprawdzamy czy wstawenie sie udalo
        zawartosc[index] = element;
        if(zawartosc[index] != element)
        {
            return false;
        }

        return true;
    }

    ArrayList(int rozm)
    {
        this->maxRozmiar = rozm;
        this->zawartosc = new T[rozm];
        this->rozmiar = 0;
    }

    //usuwa wybrany element
    bool remove(const int& index)
    {
        //jesli index miesci sie w przedziae naszej listy
        if (index<rozmiar || index<0)
        {
            //zmniejszamy rozmiar i spisujemy wszystkie elementu ponad wybrany o index w dol
            rozmiar = rozmiar - 1;
            for (int x = index; x < rozmiar; x++)
            {
                zawartosc[x] = zawartosc[x + 1];
            }
            return true;
        }

        return false;
    }

    //zwraca element pod danym indexem
    //w przypadku blednego indexu zwraca NULL
    T get(const int& index)
    {
        if(!(index<rozmiar || index<0))
            return (T)NULL;

        return zawartosc[index];
    }

    //zwraca index 1 wystapienia danego elementu
    int find(T element)
    {

        for(int i = 0; i < rozmiar; i++)
        {
            if (zawartosc[i] == element)
            {
                return i;
            }
        }

        return -1;

    }


    //zwraca obecny rozmiar listy
    //do uzycia np. w petli for
    int getSize()
    {
        return rozmiar;
    }


    //dziala dokladnie jak insert ale na element o indexie 0
    bool push_front(T element)
    {
        rozmiar++;
        spaceCheck();

        for (int i = rozmiar; i >= 0; i--)
        {
            zawartosc[i] = zawartosc[i - 1];
        }

        zawartosc[0] = element;
        if (zawartosc[0] != element)
        {
            return false;
        }

        return true;
    }
    //dziala jak insert ale na element ostatni
    bool push_back(T element)
    {
        rozmiar++;
        spaceCheck();
        zawartosc[rozmiar -1] = element;
        if(zawartosc[rozmiar -1] != element)
        {
            return false;
        }

        return true;
    }

    //dziala jak remove ale na element o nidexie 0
    void pop_front()
    {
        remove(0);
    }
    //dziala jak remove ale na element ostatni
    void pop_back()
    {
        remove(rozmiar - 1);
    }

    //usuwa kazde wystapienie danego elementu
    void delete_elements(T element)
    {
        for (int i = 0; i < rozmiar; i++)
        {
            if (zawartosc[i] == element)
            {
                remove(i);
            }
        }
    }

    //usuwa wszystkie wystapienia danego elementu, oprucz pierwszego
    void delete_duplicate(T element)
    {

        int i;
        for (i = 0; i < rozmiar; i++)
        {
            if (zawartosc[i] == element)
            {
                i++;
                break;
            }
        }
        for (int x = i; x < rozmiar; )
        {
            if (zawartosc[x] == element)
            {
                remove(x);
            }
        }
    }

    //odwrca liste
    void reverse()
    {
        int j = rozmiar - 1;
        int temp;
        for (int i = 0; i < j; i++, j--)
        {
            temp = zawartosc[i];
            zawartosc[i] = zawartosc[j];
            zawartosc[j] = temp;
        }
    }

    //podstawia element na wybrany index bez przesowania pozostalych elementow
    bool set(const int& index, T element)
    {
        if(!(index<rozmiar || index<0))
            return false;

        zawartosc[index] = element;
        if (zawartosc[index] != element)
        {
            return false;
        }

        return true;
    }

};


#endif // ARRAYLIST_H_INCLUDED
