class Point:
    """Klasa reprezentująca punkty na płaszczyźnie."""

    def __init__(self, x, y):  # konstuktor
        self.x = x
        self.y = y

    def __str__(self): return "(" + str(self.x) + ", " + str(self.y) + ")"          # zwraca string "(x, y)"

    def __repr__(self): return "Point(" + str(self.x) + ", " + str(self.y) + ")"        # zwraca string "Point(x, y)"

    def __eq__(self, other): return self.x == other.x and self.y == other.y   # obsługa point1 == point2

    def __ne__(self, other):        # obsługa point1 != point2
        return not self == other

    # Punkty jako wektory 2D.
    def __add__(self, other): return Point(self.x + other.x, self.y + other.y)  # v1 + v2

    def __sub__(self, other): return Point(self.x - other.x, self.y - other.y)  # v1 - v2

    def __mul__(self, other): return self.x * other.x + self.y * other.y  # v1 * v2, iloczyn skalarny, zwraca liczbę

    def cross(self, other):         # v1 x v2, iloczyn wektorowy 2D, zwraca liczbę
        return self.x * other.y - self.y * other.x

    def length(self): return pow((pow(self.x,2) + pow(self.y,2)),0.5)          # długość wektora

    def __hash__(self):
        return hash((self.x, self.y))   # bazujemy na tuple, immutable points

# Kod testujący moduł.

import unittest

class TestPoint(unittest.TestCase): 

    def test_str(self):
        self.assertEqual(str(Point(1,2)), "(1, 2)")
        self.assertEqual(str(Point(6,3)), "(6, 3)")
        self.assertEqual(str(Point(10,6)), "(10, 6)")

    def test_repr(self): 
        self.assertEqual(repr(Point(1,2)),"Point(1, 2)")
        self.assertEqual(repr(Point(8,3)),"Point(8, 3)")
        self.assertEqual(repr(Point(12,5)),"Point(12, 5)")

    def test_equal(self):
        self.assertEqual(Point(4,4) == Point(4,4),True)
        self.assertEqual(Point(4,4) == Point(1,4),False)
        self.assertEqual(Point(4124,21) == Point(4444,12123),False)

    def test_not_equal(self): 
        self.assertEqual(Point(4,4) != Point(4,4),False)
        self.assertEqual(Point(4,4) != Point(1,4),True)
        self.assertEqual(Point(4124,21) != Point(4444,12123),True)

    def test_add(self): 
        self.assertEqual(Point(1,1) + Point(1,1),Point(2,2))
        self.assertEqual(Point(-1,4) + Point(1,1),Point(0,5))
        self.assertEqual(Point(100,-55) + Point(100,55),Point(200,0))

    def test_sub(self):
        self.assertEqual(Point(1,1) - Point(1,1),Point(0,0))
        self.assertEqual(Point(-1,4) - Point(1,1),Point(-2,3))
        self.assertEqual(Point(100,-55) - Point(100,55),Point(0,-110))

    def test_mul(self):
        self.assertEqual(Point(1,1) * Point(1,1),2)
        self.assertEqual(Point(1,5) * Point(5,1),10)
        self.assertEqual(Point(1,1) * Point(-1,1),0)

    def test_length(self):
        self.assertEqual(Point(3,4).length(),5)

    def tearDown(self): pass

if __name__ == '__main__':
    unittest.main()     # uruchamia wszystkie testy

