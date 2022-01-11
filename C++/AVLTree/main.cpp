#include <iostream>
#include "AVLTree.h"

using namespace std;

int main()
{
    AVLTree<float> drzewo;
    if(!drzewo.insert(1))
        cout << "sos";
    drzewo.preOrder(drzewo.getRoot());
    cout<< endl;
    drzewo.insert(2);
    drzewo.preOrder(drzewo.getRoot());
        cout<< endl;
    drzewo.insert(3);
    drzewo.preOrder(drzewo.getRoot());
        cout<< endl;
    drzewo.insert(4);
    drzewo.preOrder(drzewo.getRoot());
        cout<< endl;
    drzewo.insert(5);
    drzewo.preOrder(drzewo.getRoot());
        cout<< endl;
    drzewo.insert(6);
    drzewo.preOrder(drzewo.getRoot());
    cout << endl;
    drzewo.insert(7);
    drzewo.preOrder(drzewo.getRoot());
        cout<< endl;
    drzewo.insert(8);
        cout<< endl;
    drzewo.preOrder(drzewo.getRoot());

    drzewo.remove(6);
    cout << endl;
    drzewo.preOrder(drzewo.getRoot());
    cout << endl;

    cout << drzewo.getSize(drzewo.getRoot()) << endl <<
    drzewo.isFull(drzewo.getRoot()) << endl <<
    drzewo.maximum() << endl <<
    drzewo.minimum() << endl <<
    drzewo.search(4) << endl;

    return 0;
}
