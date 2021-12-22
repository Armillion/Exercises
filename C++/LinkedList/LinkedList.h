#ifndef LINKEDLIST_H_INCLUDED
#define LINKEDLIST_H_INCLUDED
#include "..\ArrayList\List.h"

template <class T>
class LinkedList : public List<T>
{
private:

    int rozmiar;
    struct Node
    {
        T data;
        Node* next;
    };
    Node* header;

public:

    LinkedList()
    {
        header = new Node;
        rozmiar = 0;
    };

    ~LinkedList()
    {
        Node* obecny = header;
        while( obecny != 0 )
        {
            Node* next = obecny->next;
            delete obecny;
            obecny = next;
        }
        delete(header);
    };

    bool insert(const int& index,T element)
    {
        if(index > rozmiar + 1 || index < 0)
            return false;

        rozmiar++;
        Node* nowy = new Node;
        nowy->data = element;

        Node *n = header, *k = header;
        for(int i = 0; i < index - 1; i++)
        {
            n = n->next;
            k = k->next;
        }
        k = k->next;

        if(index < rozmiar - 1)
            nowy->next = k;
        else
            nowy->next = NULL;

        if(index != 0)
            n->next = nowy;

        if(index == 0)
            header = nowy;

        //delete(n,k);
        if(nowy->data == element)
        {
            return true;
        }
        return false;
    }

    bool remove(const int& index)
    {
        if(index > rozmiar - 1 || index < 0)
            return false;

        rozmiar--;
        Node *n = header, *k = header, *j = header;
        for(int i = 0; i < index - 1; i++)
        {
            n = n->next;
            k = k->next;
            j = j->next;
        }
        j = j->next;

        if(index == rozmiar - 1)
        {
            n->next = NULL;
            return true;
        }

        if(index != rozmiar - 1)
        {
            k = k->next;
            k = k->next;
        }

        if(index != 0)
        {
            n->next = k;
            return true;
        }
        else
        {
            header = k;
            return true;
        }

        delete(j);
        return false;
    }

    T get(const int& index)
    {
        if(index >= rozmiar || index < 0)
            return (T)NULL;

        Node* n = header;
        for(int i = 0; i < index;i++)
        {
            n = n->next;
        }

        return n->data;
    }

    int find(T element)
    {
        Node *n = header;
        for(int i = 0; i < rozmiar; i++)
        {
            if(n->data == element)
            {
                return i;
            }
            n = n->next;
        }

        return -1;
    }

    bool set(const int& index, T element)
    {
        if(index > rozmiar - 1 || index < 0)
            return false;

        Node *n = header;
        for(int i = 0; i < index; i++)
        {
            n = n->next;
        }

        n->data = element;

        return true;;
    }

    int getSize()
    {
        return rozmiar;
    }

    bool push_front(T element)
    {
        rozmiar++;

        Node *nowy = new Node;
        nowy->data = element;
        nowy->next = header;

        header = nowy;

        return true;
    }
    bool push_back(T element)
    {
        rozmiar++;

        Node* nowy = new Node;
        nowy->data = element;
        Node* n = header;

        while(n->next != NULL)
            n = n->next;

        n->next = nowy;

        return true;
    }

    void pop_front()
    {
        remove(0);
    }
    void pop_back()
    {
        remove(rozmiar-1);
    }

    void delete_elements(T element)
    {
        Node *n = header;
        int i = 0;

        while(i < rozmiar)
        {
            if(n->data == element)
            {
                remove(i);
            }
            else
            {
                i++;
            }
            n = n->next;
        }
    }

    void delete_duplicate(T element)
    {
        Node *n = header;
        int i = 0;

        while(i < rozmiar)
        {
            if(n->data == element)
            {
                i++;
                n = n->next;
                break;
            }

            i++;
            n = n->next;
        }

        while(i < rozmiar)
        {
            if(n->data == element)
            {
                remove(i);
            }
            else
            {
                i++;
            }
            n = n->next;
        }
    }

    void reverse()
    {
        Node* obecny = header;
        Node *poprz = NULL, *nast = NULL;

        while (obecny != NULL) {
            nast = obecny->next;

            obecny->next = poprz;

            poprz = obecny;
            obecny = nast;
        }
        header = poprz;
    }

    T first()
    {
        return header->data;
    }
    T last()
    {
        Node* n = header;

        while(n->next != NULL)
            n = n->next;

        return n->data;
    }
    int end()
    {
        return rozmiar-1;
    }
    T previous(const int& index )
    {
        if(index > rozmiar - 1 || index <= 0)
            return (T)NULL;

        Node* n = header;

        for(int i = 0 ; i < index-1 ; i++)
            n = n->next;

        return n->data;
    }
    T next(const int& index )
    {
        if(index > rozmiar - 2 || index < 0)
            return (T)NULL;

        Node* n = header;

        for(int i = 0 ; i < index+1  ; i++)
            n = n->next;

        return n->data;
    }

};


#endif // LINKEDLIST_H_INCLUDED
