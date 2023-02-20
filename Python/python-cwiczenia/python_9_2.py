class Node:
    def __init__(self,data) -> None:
        self.next = None
        self.data = data


class SingleList:
    def add(self,data):
        if self.head == None:
            self.head = Node(data)
            self.tail = self.head
        else:
            self.tail.next = Node(data)
            self.tail = self.tail.next
            
    def iterate(self):
        a = self.head
        while a != None:
            print(a.data)
            a = a.next
    
    def __init__(self) -> None:
        self.head = None
        self.tail = None

    def remove_tail(self):   # klasy O(n)
        # Zwraca cały węzeł, skraca listę.
        # Dla pustej listy rzuca wyjątek ValueError.
        if self.head == None:
            raise ValueError("List is empty!")
        elif self.head == self.tail:
            a = self.head
            self.head = self.tail = None
            return a
        else:
            a = self.head
            while a.next != self.tail:
                a = a.next
            b = self.tail
            self.tail = a
            a.next = None
            return b

    def join(self, other):   # klasy O(1)
        # Węzły z listy other są przepinane do listy self na jej koniec.
        # Po zakończeniu operacji lista other ma być pusta.
        if self.head == None:
            self.head = other.head
            self.tail = other.tail
        elif other.head == None:
            return
        else:
            self.tail.next = other.head
            self.tail = other.tail
        other.head = None
        other.tail = None

    def clear(self):   # czyszczenie listy
        a = self.head
        while a != None:
            b = a
            a = a.next
            del b

    def search(self, data):   # klasy O(n)
        # Zwraca łącze do węzła o podanym kluczu lub None.
        a = self.head
        if a == None:
            return a

        while a != None:
            if a.data == data:
                return a
            
            a = a.next
        return a

    def find_min(self):   # klasy O(n)
        # Zwraca łącze do węzła z najmniejszym kluczem lub None dla pustej listy.
        a = self.head
        minimal = self.head
        while a != None and a.next != None:
            a = a.next
            if a.data < minimal.data:
                minimal = a
        return minimal

    def find_max(self):   # klasy O(n)
        # Zwraca łącze do węzła z największym kluczem lub None dla pustej listy.
        a = self.head
        maximal = a
        while a != None:
            if a.data > maximal.data:
                maximal = a
            a = a.next
        return maximal

    def reverse(self):   # klasy O(n)
        # Odwracanie kolejności węzłów na liście.
        prev = None
        current = self.head
        while(current is not None):
            next = current.next
            current.next = prev
            prev = current
            current = next
        self.tail = self.head
        self.head = prev