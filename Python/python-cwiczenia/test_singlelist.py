import pytest
from python_9_2 import SingleList
from python_9_2 import Node

def test_add():
    list = SingleList()
    assert list.head == None
    list.add(1)
    assert list.head.data == 1
    list.add(2)
    assert list.tail.data == 2

def test_remove_tail():
    list = SingleList()
    list.add(1)
    list.add(2)
    list.add(3)
    assert list.tail.data == 3
    assert list.remove_tail().data == 3
    assert list.tail.data == 2
    
def test_join():
    list1 = SingleList()
    list1.add(1)
    list1.add(2)
    list1.add(3)
    list2 = SingleList()
    list2.add(6)
    list2.add(5)
    list2.add(4)
    assert list1.tail.data == 3
    list1.join(list2)
    assert list1.tail.data == 4
    assert list2.head == None
    
def test_search():
    list1 = SingleList()
    list1.add(1)
    list1.add(2)
    list1.add(3)
    a = list1.search(4)
    assert a == None
    assert list1.search(2).data == 2
    
def test_find_min(): 
    list1 = SingleList()
    assert list1.find_min() == None
    list1.add(1)
    list1.add(2)
    list1.add(3)
    assert list1.find_min().data == 1
    
def test_find_max():
    list1 = SingleList()
    assert list1.find_max() == None
    list1.add(1)
    list1.add(2)
    list1.add(3)
    assert list1.find_max().data == 3

def test_reverse(): 
    list1 = SingleList()
    list1.add(1)
    list1.add(2)
    list1.add(3)
    assert list1.head.data == 1 and list1.tail.data == 3
    list1.reverse()
    assert list1.head.data == 3 and list1.tail.data == 1

if __name__ == "__main__":
    pytest.main()
