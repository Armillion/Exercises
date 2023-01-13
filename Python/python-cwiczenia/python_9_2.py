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
            a = self.head.data
            del self.head
            return a
        else:
            a = self.head
            while a.next != self.tail:
                a = a.next
            b = self.tail.data
            self.tail = a
            del a.next
            return b

    def join(self, other):   # klasy O(1)
        # Węzły z listy other są przepinane do listy self na jej koniec.
        # Po zakończeniu operacji lista other ma być pusta.
        if self.head == None:
            self.head = other.head
        elif other.head == None:
            return
        else:
            self.tail.next = other.head
            self.tail = other.tail

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

        while a != None or a.data != data:
            a = a.next
        return a

    def find_min(self):   # klasy O(n)
        # Zwraca łącze do węzła z najmniejszym kluczem lub None dla pustej listy.
        a = self.head
        minimal = a
        while a != None and a.next != None:
            a = a.next
            if a.data < minimal.data:
                minimal = a
        return a

    def find_max(self):   # klasy O(n)
        # Zwraca łącze do węzła z największym kluczem lub None dla pustej listy.
        a = self.head
        maximal = a
        while a != None:
            a = a.next
            if a.data > maximal.data:
                maximal = a
        return a

    def reverse(self):   # klasy O(n)
        # Odwracanie kolejności węzłów na liście.
        a = None
        b = self.head
        while b != None:
            next = b.next
            b.next = a
            a = b
            b = next
        self.head = a