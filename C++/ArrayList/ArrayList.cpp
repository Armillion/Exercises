#include "List.h"
#include "ArrayList.h"
#include <iostream>
#include <array>
template <class T>
ArrayList<T>::ArrayList(int rozm)
{
    this->maxRozmiar = rozm;
    this->zawartosc = new T[rozm];
    this->rozmiar = 0;
}

template <class T>
bool ArrayList<T>::insert(const int& index, T element)
{
    rozmiar++;

    for (int i = rozmiar; i >= index ; i--)
    {
        zawartosc[i] = zawartosc[i - 1];
    }

    zawartosc[index - 1] = element;
    if (zawartosc[index - 1] != element)
    {
        return false;
    }

    return true;
}

template <class T>
bool ArrayList<T>::remove(const int& index)
{
    int i;
    for ( i = 0; i < rozmiar; i++)
    {
        if (zawartosc[i] == zawartosc[index])
            break;
    }
    if (i<rozmiar)
    {
        rozmiar = rozmiar - 1;
        for (int x = i; x < rozmiar; x++)
        {
            zawartosc[i] = zawartosc[i + 1];
            return true;
        }
    }

    return false;
}

template <class T>
T ArrayList<T>::find(const int& index)
{

    for (int i = 0; i < rozmiar; i++)
    {
        if (zawartosc[i] == zawartosc[index])
        {
            return zawartosc[index];
        }
    }

    return NULL;
}

template <class T>
int ArrayList<T>::locate(T element)
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

template <class T>
T ArrayList<T>::first()
{
    return zawartosc[0];
}
template <class T>
int ArrayList<T>::next(const int& index)
{
    return index + 1;
}
template <class T>
int ArrayList<T>::previous(const int& index)
{
    return index - 1;
}
template <class T>
int ArrayList<T>::last()
{
    return rozmiar - 1;
}

template <class T>
T ArrayList<T>::back()
{
    int lastElement = zawartosc[rozmiar - 1];
    return lastElement;
}
template <class T>
bool ArrayList<T>::push_front(T element)
{
    rozmiar++;

    for (int i = rozmiar; i > 0; i--)
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
template <class T>
bool ArrayList<T>::push_back(T element)
{
    rozmiar++;
    zawartosc[rozmiar -1] = element;
    if(zawartosc[rozmiar -1] != element)
    {
        return false;
    }

    return true;
}
template <class T>
void ArrayList<T>::pop_front()
{
    remove(0);
}
template <class T>
void ArrayList<T>::pop_back()
{
    remove(rozmiar - 1);
}
template <class T>
void ArrayList<T>::delete_elements(T element)
{
    for (int i = 0; i < rozmiar; i++)
    {
        if (zawartosc[i] == element)
        {
            remove(i);
        }
    }

}
template <class T>
void ArrayList<T>::delete_duplicate(T element)
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
    for (int x = i; x < rozmiar; x++)
    {
        if (zawartosc[x] == element)
        {
            remove(x);
        }
    }
}

template <class T>
void ArrayList<T>::reverse()
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
