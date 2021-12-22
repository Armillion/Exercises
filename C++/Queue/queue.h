#ifndef QUEUE_H
#define QUEUE_H

template <class T>
class queue {
    public:
        virtual bool isEmpty() = 0;
        virtual int  getSize() = 0;
        virtual bool enqueue(T element) = 0;
        virtual void dequeue() = 0;
        virtual T    front() = 0;
        virtual T    rear() = 0;
};

#endif // QUEUE_H
