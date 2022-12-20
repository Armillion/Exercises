import pytest
from python_10_8 import RandomQueue

def test_push_pop():
    values = [1,2,3,4,5]
    queue = RandomQueue()
    for i in values:
        queue.insert(i)
    
    assert queue.remove() in values
    assert queue.remove() in values
    assert queue.remove() in values
    assert queue.remove() in values
    assert queue.remove() in values
    
def test_isEmpty():
    queue = RandomQueue()
    assert queue.is_empty()
    queue.insert(1)
    assert not queue.is_empty()
    queue.remove()
    assert queue.is_empty()
    
if __name__ == "__main__":
    pytest.main()
