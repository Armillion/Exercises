import random

class RandomQueue:
    
    def __init__(self): 
        self.items = []

    def insert(self, item):    # wstawia element w czasie O(1)
        self.items.append(item)

    def remove(self):   # zwraca losowy element w czasie O(1)
        return self.items.pop(random.randrange(0,len(self.items)))

    def is_empty(self): return not self.items

    def is_full(self): return False # lista nie ma limitu miejsc

    def clear(self):   # czyszczenie listy
        del self.items