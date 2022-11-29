import random

class Binary:

    def __init__(self):
        self.bin = -1

    def __iter__(self):
        self.bin = -1
        return self

    def __next__(self):
        if self.bin == 1:
            self.bin = 0
            return self.bin
        else:
            self.bin += 1
            return self.bin
        
a = Binary()
b = iter(a)

for i in range(7):
    print(next(b))
    
print("-------------")

class News:
    
    def __init__(self):
        self.chars = ['N',"E",'S','W']

    def __iter__(self):
        return self

    def __next__(self):
        return self.chars[random.randrange(0,3)]
    
a = News()
b = iter(a)

for i in range(7):
    print(next(b))
    
print("-------------")

class Week:
    
    def __init__(self):
        self.bin = -1

    def __iter__(self):
        self.bin = -1
        return self

    def __next__(self):
        if self.bin == 6:
            self.bin = 0
            return self.bin
        else:
            self.bin += 1
            return self.bin
        
a = Week()
b = iter(a)

for i in range(7):
    print(next(b))