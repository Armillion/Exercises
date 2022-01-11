#ifndef AVLTREE_H
#define AVLTREE_H
#include <iostream>


template <class T>
class AVLTree
{
private:
    struct Node
    {
        T data;
        Node* leftChild;
        Node* rightChild;
        Node* Parent;
        int height;
    };

    Node* root;

    T max(T a, T b)
    {
        return (a > b)? a : b;
    }
    int height(Node *N)
    {
        if (N == NULL)
            return 0;
        return N->height;
    }

    Node *rRotate(Node *y)
    {
        Node *x = y->leftChild;
        Node *T2 = x->rightChild;

        x->rightChild = y;
        y->leftChild = T2;

        x->Parent = y->Parent;
        y->Parent = x;
        if(T2 != NULL)
            T2->Parent = y;


        y->height = max(height(y->leftChild),
                        height(y->rightChild)) + 1;
        x->height = max(height(x->leftChild),
                        height(x->rightChild)) + 1;

        recalculateRoot(root);

        return x;
    }

    Node *lRotate(Node *x)
    {
        Node *y = x->rightChild;
        Node *T2 = y->leftChild;

        y->leftChild = x;
        x->rightChild = T2;

        y->Parent = x->Parent;
        x->Parent = y;
        if(T2 != NULL)
            T2->Parent = x;

        x->height = max(height(x->leftChild),
                        height(x->rightChild)) + 1;
        y->height = max(height(y->leftChild),
                        height(y->rightChild)) + 1;

        recalculateRoot(root);

        return y;
    }

    int Balance(Node *N)
    {
        if (N == NULL)
            return 0;

        if(N->leftChild == NULL && N->rightChild == NULL)
            return 0;

        if(N->leftChild == NULL)
            return 0 - (*N->rightChild).height;

        if(N->rightChild == NULL)
            return (*N->leftChild).height;

        return (*N->leftChild).height - (*N->rightChild).height;
    }

    void recalculateRoot(Node* currentRoot)
    {
        if(currentRoot->Parent == NULL)
        {
            root = currentRoot;
            return;
        }

        recalculateRoot(currentRoot->Parent);
    }

    Node* insertNode(Node* node,const T& data)
    {
        if(node == NULL)
        {
            Node* newNode = new Node;
            newNode->data = data;
            newNode->leftChild = NULL;
            newNode->rightChild = NULL;
            newNode->Parent = NULL;
            newNode->height = 1;
            node = newNode;
            return node;
        }

        if(data < node->data)
        {
            node->leftChild = insertNode(node->leftChild, data);
            node->leftChild->Parent = node;
        }
        else if (data > node->data)
        {
            node->rightChild = insertNode(node->rightChild, data);
            node->rightChild->Parent = node;
        }
        else
            return node;

        node->height = 1 + max(height(node->leftChild),
                               height(node->rightChild));

        int balance = Balance(node);

        if (balance > 1 && data < node->leftChild->data)
            return rRotate(node);

        if (balance < -1 && data > node->rightChild->data)
            return lRotate(node);

        if (balance > 1 && data > node->leftChild->data)
        {
            node->leftChild = lRotate(node->leftChild);
            return rRotate(node);
        }

        if (balance < -1 && data < node->rightChild->data)
        {
            node->rightChild = rRotate(node->rightChild);
            return lRotate(node);
        }

        return node;
    }

    void destroyTree(Node* node)
    {
        if(node != NULL)
        {
            destroyTree(node->leftChild);
            destroyTree(node->rightChild);
            delete node;
        }
    }

    Node* find(Node* node, T element)
    {
        if (node == NULL || node->data == element)
            return node;

        if (node->data < element)
            return find(node->rightChild, element);
        else
            return find(node->leftChild, element);
    }

    T findMin(Node* node,T currMin)
    {
        if(node->data < currMin)
            currMin = node->data;

        if(node->leftChild != NULL)
            currMin = findMin(node->leftChild,currMin);

        int a;
        if(node->rightChild != NULL )
            if((a = findMin(node->rightChild,currMin)) < currMin)
                currMin = a;

        return currMin;
    }

    T findMax(Node* node,T currMax)
    {
        if(node->data > currMax)
            currMax = node->data;

        if(node->leftChild != NULL)
            currMax = findMax(node->leftChild,currMax);

        int a;
        if(node->rightChild != NULL )
            if(( a = findMax(node->rightChild,currMax)) > currMax)
                currMax = a;

        return currMax;
    }

    Node* findMinNode(Node* node, Node* currMin)
    {
        if(node->data < currMin->data)
            currMin = node;

        if(node->leftChild != NULL)
            currMin = findMinNode(node->leftChild,currMin);

        Node* a;
        if(node->rightChild != NULL )
            if((a = findMinNode(node->rightChild,currMin))->data <= currMin->data)
                currMin = a;

        return currMin;
    }

    Node* deleteNode(Node* node, T data)
    {
        if (node == NULL)
            return node;
        if ( data < node->data )
            node->leftChild = deleteNode(node->leftChild, data);
        else if( data > node->data )
            node->rightChild = deleteNode(node->rightChild, data);
        else
        {
            if((node->leftChild == NULL) || (node->rightChild == NULL) )
            {
                Node *temp = node->leftChild ?
                             node->leftChild :
                             node->rightChild;

                if (temp == NULL)
                {
                    temp = node;
                    node = NULL;
                }
                else
                    *node = *temp;

                free(temp);
            }
            else
            {
                Node* temp = findMinNode(node->rightChild,node->rightChild);
                node->data = temp->data;
                node->rightChild = deleteNode(node->rightChild,
                                              temp->data);
            }
        }
        if(node == NULL)
            return node;

        node->height = 1 + max(height(node->leftChild),
                               height(node->rightChild));

        int balance = Balance(node);

        if(balance > 1 && Balance(node->leftChild) >= 0)
            return rRotate(node);

        if(balance > 1 && Balance(node->leftChild) < 0)
        {
            node->leftChild = lRotate(node->leftChild);
            return rRotate(node);
        }

        if(balance < -1 && Balance(node->rightChild) <= 0)
            return lRotate(node);

        if(balance < -1 && Balance(node->rightChild) > 0)
        {
            node->rightChild = rRotate(node->rightChild);
            return lRotate(node);
        }

        return node;
    }

public:
    AVLTree()
    {
        root = NULL;
    }
    ~AVLTree()
    {
        destroyTree(root);
    }

    int getSize(Node* node)
    {
        int size = 0;

        if(node != NULL)
            size++;
        else
            return 0;

        if(node->leftChild != NULL)
            size += getSize(node->leftChild);

        if(node->rightChild != NULL)
            size += getSize(node->rightChild);

        return size;
    }

    Node* getParent(Node* node)
    {
        return node->Parent;
    }
    Node** getChildern(Node* node)
    {
        Node* chld[] = {node->leftChild,node->rightChild};
        return chld;
    }
    Node* getSibling(Node* node)
    {
        if(node->Parent->rightChild == node)
            return node->Parent->leftChild;

        return node->Parent->rightChild;
    }


    bool insert(const T& data)
    {
        if(root == NULL)
        {
            Node* newNode = new Node;
            newNode->data = data;
            newNode->leftChild = NULL;
            newNode->rightChild = NULL;
            newNode->Parent = NULL;
            newNode->height = 1;
            root = newNode;
            return true;
        }

        if(insertNode(root,data) == NULL)
            return false;

        //checkBalanceRecursively(root);

        return true;
    }

    void preOrder(Node *node)
    {
        if(node != NULL)
        {
            std::cout << node->data << " ";
            preOrder(node->leftChild);
            preOrder(node->rightChild);
        }
    }

    Node* getRoot()
    {
        return root;
    }

    bool isFull(Node* node)
    {
        bool ifFull = false;

        if(node != NULL)
            ifFull = false;
        else
            return false;

        if(node->leftChild == NULL && node->rightChild == NULL)
            return true;

        if(node->leftChild != NULL)
            ifFull = isFull(node->leftChild);

        if(node->rightChild != NULL)
            ifFull = isFull(node->rightChild);


        return ifFull;
    }

    int getDepht(Node* node)
    {
        return root->height - node->height;
    }

    bool isLeaf(Node* node)
    {
        if(node->leftChild != NULL)
            return false;

        if(node->rightChild != NULL)
            return false;

        return true;
    }

    bool isEmpty()
    {
        if(root == NULL)
            return true;

        return false;
    }

    bool search(T element)
    {
        if(find(root,element) != NULL)
            return true;

        return false;
    }

    T minimum()
    {
        return findMin(root,2147483646);
    }

    T maximum()
    {
        return findMax(root,-2147483646);
    }

    bool remove(T element)
    {
        if(deleteNode(root,element) == NULL)
            return false;

        return true;
    }

};



#endif // AVLTREE_H
