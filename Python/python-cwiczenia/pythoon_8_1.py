from python_6_2 import Point

class Rectangle:
    """Klasa reprezentująca prostokąt na płaszczyźnie."""

    def __init__(self, x1, y1, x2, y2):
        self.pt1 = Point(x1, y1)
        self.pt2 = Point(x2, y2)
        
    def from_points(self, pta : Point, ptb : Point):
        self.pt1 = pta
        self.pt2 = ptb
        return self    
    
    @property
    def bottom_left(self):
        """Bottom left coordinates are 
        """
        return self.pt1
    
    @bottom_left.setter
    def bottom_left(self, x : Point):
        self.pt1 = x
    
    @bottom_left.deleter
    def bottom_left(self):
        self.pt1 = None
    
    @property
    def top_left(self):
        """Top left coordinates are
        """
        return Point(self.pt1.x,self.pt2.y)
    
    @top_left.setter
    def top_left(self, x : Point):
        self.pt1.x = x.x
        self.pt2.y = x.y
        
    @top_left.deleter
    def top_left(self):
        self.pt1.x = None
        self.pt2.y = None
    
    @property
    def bottom_right(self):
        """Bottom right coordinates are
        """
        return Point(self.pt2.x,self.pt1.y)
    
    @bottom_right.setter
    def bottom_right(self, x : Point):
        self.pt1.y = x.y
        self.pt2.x = x.x
        
    @bottom_right.deleter
    def bottom_right(self, x : Point):
        self.pt1.y = None
        self.pt2.x = None
    
    @property
    def top_right(self):
        """Top right coordinates are
        """
        return self.pt2
    
    @top_right.setter
    def top_right(self, x : Point):
        self.pt2 = x

    @top_right.deleter
    def top_right(self):
        self.pt2 = None
        
    @property
    def top(self):
        return self.pt2.y
    
    @top.setter
    def top(self,x):
        self.pt2.y = x
        
    @top.deleter
    def top(self):
        self.pt2.y = None
        
    @property
    def bottom(self):
        return self.pt1.y
    
    @bottom.setter
    def bottom(self,x):
        self.pt1.y = x
        
    @bottom.deleter
    def bottom(self):
        self.pt1.y = None
        
    @property
    def left(self):
        return self.pt1.x
    
    @left.setter
    def left(self,x):
        self.pt1.x = x
        
    @left.deleter
    def left(self):
        self.pt1.x = None
        
    @property
    def right(self):
        return self.pt2.x
    
    @right.setter
    def right(self,x):
        self.pt2.x = x
        
    @right.deleter
    def right(self):
        self.pt2.x = None   

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
