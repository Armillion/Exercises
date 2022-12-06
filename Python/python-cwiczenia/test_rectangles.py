import pytest
from pythoon_8_1 import Rectangle
from python_6_2 import Point

def test_int_properties():
    rec1 = Rectangle(1,1,2,2)
    rec2 = Rectangle(4,2,5,7)
    assert rec1.bottom == 1
    assert rec1.top == 2
    assert rec1.left == 1
    assert rec1.right == 2
    assert rec2.bottom == 2
    assert rec2.top == 7
    assert rec2.left == 4
    assert rec2.right == 5

def test_point_propperties():
    rec1 = Rectangle(1,1,2,2)
    rec2 = Rectangle(4,2,5,7)
    assert rec1.bottom_left == Point(1,1)
    assert rec1.top_left == Point(1,2)
    assert rec1.bottom_right == Point(2,1)
    assert rec1.top_right == Point(2,2)
    assert rec2.bottom_left == Point(4,2)
    assert rec2.top_left == Point(4,7)
    assert rec2.bottom_right == Point(5,2)
    assert rec2.top_right == Point(5,7)

def test_from_points():
    rec = Rectangle(1,1,2,2)
    assert rec == Rectangle(1,1,2,2)
    rec = rec.from_points(Point(4,2),Point(5,7))
    assert rec == Rectangle(4,2,5,7)
    
def test_str():
    assert str(Rectangle(1,1,1,1)) ==  "[(1, 1), (1, 1)]"
    assert str(Rectangle(1,3,6,2)) ==  "[(1, 3), (6, 2)]"

def test_repr(): 
    assert repr(Rectangle(1,1,1,1)) == "Rectangle(1, 1, 1, 1)"
    assert repr(Rectangle(1,3,6,2)) == "Rectangle(1, 3, 6, 2)"

def test_equal():
    assert Rectangle(2,2,4,4) == Rectangle(2,2,4,4)
    assert Rectangle(2,1,4,2) == Rectangle(2,1,4,2)

def test_not_equal(): 
    assert Rectangle(2,2,4,4) != Rectangle(3,3,4,4)
    assert Rectangle(2,2,4,4) != Rectangle(2,2,3,3)

def test_center(): 
    assert Rectangle(2,2,4,4).center() == Point(3,3)
    assert Rectangle(0,0,3,3).center() == Point(1.5,1.5)

def test_area():
    assert Rectangle(2,2,4,4).area() == 4
    assert Rectangle(0,0,4,4).area() == 16

def test_move():
    a = Rectangle(2,2,4,4)
    a.move(1,1)
    assert a == Rectangle(3,3,5,5)


if __name__ == "__main__":
    pytest.main()
