#ifndef LIST_H
#define LIST_H

template <class T>
class List {

    public:
        virtual bool insert(const int& index,T element) = 0;
        virtual bool remove(const int& index) = 0;
        virtual T get(const int& index) = 0;
        virtual int find(T element) = 0;

        virtual bool set(const int& index, T element) = 0;
        virtual int getSize() = 0;
        virtual bool push_front(T element) = 0;
        virtual bool push_back(T element) = 0;
        virtual void pop_front() = 0;
        virtual void pop_back() = 0;
        virtual void delete_elements(T element) = 0;
        virtual void delete_duplicate(T element) = 0;
        virtual void reverse() = 0;
};

#endif // LIST_H_INCLUDED
