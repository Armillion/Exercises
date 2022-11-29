from points import Point

class Triangle:
    """Klasa reprezentująca trójkąty na płaszczyźnie."""

    def __init__(self, x1, y1, x2, y2, x3, y3):
        # Należy zabezpieczyć przed sytuacją, gdy punkty są współliniowe.
        if (x2 - x1)*(y3 - y1) == (y2 - y1)*(x3 - x1):
            raise ValueError("Punkty sa wspulliniowe")
        
        self.pt1 = Point(x1, y1)
        self.pt2 = Point(x2, y2)
        self.pt3 = Point(x3, y3)

    def __str__(self): return "[" + str(self.pt1) + ", " + str(self.pt2) + ", " + str(self.pt3) + "]"        # "[(x1, y1), (x2, y2), (x3, y3)]"

    def __repr__(self): return "Triangle(" + str(self.pt1) + ", " + str(self.pt2) + ", " + str(self.pt3) + ")"        # "Triangle(x1, y1, x2, y2, x3, y3)"

    def __eq__(self, other): return self.pt1 == other.pt1 and self.pt2 == other.pt2 and self.pt3 == other.pt3   # obsługa tr1 == tr2

    def __ne__(self, other):        # obsługa tr1 != tr2
        return not self == other

    def center(self): return Point((self.pt1.x + self.pt2.x + self.pt3.x)/3,(self.pt1.y + self.pt2.y + self.pt3.y)/3)          # zwraca środek trójkąta

    mod = lambda x : -x if( x < 0 ) else x

    def area(self): 
        mod = lambda x : -x if( x < 0 ) else x
        return 0.5 * mod(self.pt1.x*(self.pt2.y - self.pt3.y) + self.pt2.x*(self.pt3.y - self.pt1.y) + self.pt3.x*(self.pt1.y - self.pt2.y))            # pole powierzchni

    def move(self, x, y): # przesunięcie o (x, y)
        pt = Point(x,y)
        self.pt1 += pt
        self.pt2 += pt
        self.pt3 += pt

    def make4(self):           # zwraca krotkę czterech mniejszych
#     A       po podziale    A
#    / \                    / \
#   /   \                  +---+
#  /     \                / \ / \
# C-------B              C---+---B
        ac = Point((self.pt1.x + self.pt3.x)/2 ,(self.pt1.y + self.pt3.y)/2)
        ab = Point((self.pt1.x + self.pt2.x)/2 ,(self.pt1.y + self.pt2.y)/2)
        cb = Point((self.pt3.x + self.pt2.x)/2 ,(self.pt3.y + self.pt2.y)/2)
        return Triangle(self.pt1.x,self.pt1.y,ab.x,ab.y,ac.x,ac.y), Triangle(ac.x,ac.y,self.pt2.x,self.pt2.y,cb.x,cb.y), Triangle(ab.x,ab.y,cb.x,cb.y,self.pt3.x,self.pt3.y), Triangle(cb.x,cb.y,ac.x,ac.y,ab.x,ab.y) 
        
# Kod testujący moduł.

import unittest

class TestTriangle(unittest.TestCase): 
    def test_str(self):
        self.assertEqual(str(Triangle(1,1,2,2,1,3)), "[(1, 1), (2, 2), (1, 3)]")

    def test_repr(self): 
        self.assertEqual(repr(Triangle(1,1,2,2,1,3)),"Triangle((1, 1), (2, 2), (1, 3))")

    def test_equal(self):
        self.assertEqual(Triangle(2,2,4,4,2,6) == Triangle(2,2,4,4,2,6),True)
        self.assertEqual(Triangle(2,2,4,4,2,6) == Triangle(2,2,3,3,2,6),False)

    def test_not_equal(self): 
        self.assertEqual(Triangle(2,2,4,4,2,6) != Triangle(2,2,4,4,2,6),False)
        self.assertEqual(Triangle(2,2,4,4,2,6) != Triangle(2,2,3,3,2,6),True)

    def test_center(self): 
        self.assertEqual(Triangle(2,2,4,4,3,6).center(),Point(3,4))
        self.assertEqual(Triangle(0,0,3,3,0,6).center(),Point(1,3))

    def test_area(self):
        self.assertEqual(Triangle(2,2,4,4,2,6).area(),4)
        self.assertEqual(Triangle(0,0,4,4,0,3).area(),6)

    def test_move(self):
        a = Triangle(2,2,4,4,2,6)
        a.move(1,1)
        self.assertEqual(a,Triangle(3,3,5,5,3,7))
        
    def test_make4(self):
        self.assertEqual(Triangle(2,2,4,4,2,6).make4(),(Triangle(2,2,3,3,2,4),Triangle(2,4,4,4,3,5),Triangle(3,3,3,5,2,6),Triangle(3,5,2,4,3,3)))
        
    def tearDown(self): pass

if __name__ == '__main__':
    unittest.main()     # uruchamia wszystkie testy
