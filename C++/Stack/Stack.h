#ifndef STACK_H
#define STACK_H

template <class T>
class Stack {
    public:
        virtual bool isEmpty() = 0;
        virtual int  getSize() = 0;
        virtual bool push(T element) = 0;
        virtual void pop() = 0;
        virtual T    peek() = 0;
        virtual bool isFull() = 0;
};

#endif // STACK_H
