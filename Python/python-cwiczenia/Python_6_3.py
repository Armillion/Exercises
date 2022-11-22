from python_6_2 import Point

class Rectangle:
    """Klasa reprezentująca prostokąt na płaszczyźnie."""

    def __init__(self, x1, y1, x2, y2):
        self.pt1 = Point(x1, y1)
        self.pt2 = Point(x2, y2)

    def __str__(self): return "[" + str(self.pt1) + ", " + str(self.pt2) + "]"         # "[(x1, y1), (x2, y2)]"

    def __repr__(self): return "Rectangle(" + str(self.pt1.x) + ", " + str(self.pt1.y) + ", " + str(self.pt2.x) + ", " + str(self.pt2.y) + ")"        # "Rectangle(x1, y1, x2, y2)"

    def __eq__(self, other): return self.pt1 == other.pt1 and self.pt2 == other.pt2   # obsługa rect1 == rect2

    def __ne__(self, other):        # obsługa rect1 != rect2
        return not self == other

    def center(self): 
        xCenter = (self.pt1.x + self.pt2.x) / 2
        yCenter = (self.pt1.y + self.pt2.y) / 2
        return Point(xCenter,yCenter)

    def area(self): return (self.pt2.y - self.pt1.y) * (self.pt2.x - self.pt1.x)            # pole powierzchni

    def move(self, x, y): self.pt1.x += x; self.pt2.x += x; self.pt1.y += y; self.pt2.y += y      # przesunięcie o (x, y)

# Kod testujący moduł.

import unittest

class TestRectangle(unittest.TestCase): 
    def test_str(self):
        self.assertEqual(str(Rectangle(1,1,1,1)), "[(1, 1), (1, 1)]")
        self.assertEqual(str(Rectangle(1,3,6,2)), "[(1, 3), (6, 2)]")

    def test_repr(self): 
        self.assertEqual(repr(Rectangle(1,1,1,1)),"Rectangle(1, 1, 1, 1)")
        self.assertEqual(repr(Rectangle(1,3,6,2)),"Rectangle(1, 3, 6, 2)")

    def test_equal(self):
        self.assertEqual(Rectangle(2,2,4,4) == Rectangle(2,2,4,4),True)
        self.assertEqual(Rectangle(2,2,4,4) == Rectangle(2,2,3,3),False)

    def test_not_equal(self): 
        self.assertEqual(Rectangle(2,2,4,4) != Rectangle(2,2,4,4),False)
        self.assertEqual(Rectangle(2,2,4,4) != Rectangle(2,2,3,3),True)

    def test_center(self): 
        self.assertEqual(Rectangle(2,2,4,4).center(),Point(3,3))
        self.assertEqual(Rectangle(0,0,3,3).center(),Point(1.5,1.5))

    def test_area(self):
        self.assertEqual(Rectangle(2,2,4,4).area(),4)
        self.assertEqual(Rectangle(0,0,4,4).area(),16)

    def test_move(self):
        a = Rectangle(2,2,4,4)
        a.move(1,1)
        self.assertEqual(a,Rectangle(3,3,5,5))

    def tearDown(self): pass

if __name__ == '__main__':
    unittest.main()     # uruchamia wszystkie testy

