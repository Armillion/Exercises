import pytest
from python_10_2 import Stack

def test_push():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    # stack.push(4) # wystąpi wyjatek
    assert stack.pop() == 3
    assert stack.pop() == 2
    assert stack.pop() == 1
    
def test_pop():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    assert stack.pop() == 3
    stack.pop()
    assert stack.pop() == 1
    # stack.pop() # wystąpi wyjątek
    
def test_isFull():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    assert stack.is_full()
    stack.pop()
    assert not stack.is_full()
    
    
def test_isEmpty():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    assert not stack.is_empty()
    stack.pop()
    assert not stack.is_empty()
    stack.pop()
    stack.pop()
    assert stack.is_empty()
    
if __name__ == "__main__":
    pytest.main()
