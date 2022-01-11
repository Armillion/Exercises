[READ ME]

Autor: Partyk Wałaszek

Zawiera krótki opis metod w mojej implementacji klasy AVLTREE, wraz z ich przewidywną złożonością.
n - obecna ilość elementów w drzewku

		//T max(T a, T b)//
Funkcja pomocnicza zwracająca element o największej wartości.
Złożoność: O(1)

		//int height(Node* N)//
Funkcja pomocnicza zwracająca wysokość na jakiej znajduje sie N. Wykożystuje ją zamiast N->height 
by uniknąć problemów z rzutowaniem wskaźników.
Złożoność: O(1)

		//int Balance(Node* N)//
Funkcja pomagająca ustalić czy poddrzewko o korzeniu N jest drzewkiem AVL. Jeśli tak zwraca ona 
liczbe w przedziale {-1;1}, w przeciwnym wypadku znak zwruconej liczby decyduje w którą strone 
obrucić poddrzewko.
Złożoność: O(1)

		//void recalculateRoot(Node* currentRoot)//
Funkcja służąca do przypisania krzeniowi odpowiedniej wartości, np. po obracaniu drzewka.
Działa rekurencyjnie.
Złożoność: Funkcja wykonuje dokładnie tyle razy jaką wysokość ma pierwszy podany currentRoot,
	   jeśli wienc jakimś cudem poprzez serie rotacji nasz korzeń stanie się liściem
	   to funkcja będzie miała 1.44*log2(n) operacji dominujących, co daje złożoność O(log2(n)).

		//Node* lRotate(Node* x) i Node* rRotate(Node* y)//
Rotacja poddrzewkiem o korzeniu odpowiednio x i y, w lewo oraz w prawo.
Złożoność: Same funkcje mają złośoność O(1), wywołują one jednak funkcje recalculateRoot() co 
	   powoduje że przejumją one jego złożoność O(log2(n)).

		//Node* insertNode(Node* node, const T& data)//
Funkcja pozwala wstawić do drzewka element data. Działa ona rekurencyjnie - najpierw przechodzi po 
istniejących już elementach drzewka porównując ich wartości z data, a następnie, gdy dojdzie do 
pustego miejsca w drzewku wstawia tam nowy element o wartości data, następnie przechodzi ponownie
po wszystkich poprzednich elementach i sprawdza ich balans, wykonując rotacje w przyadku jego zachwiania
Złożoność: Sama funkcja zawsze wykonuje sie dla 1.44*log2(n) elementów (wysokość drzewka), ale teoretycznie
	   Wystąpić może sytuacja gdzie dla każdego elementu wykonana zostaje rotacja, zwiększając ilość
	   operacji do 2,0736*log2^2(n) i złożoność na O(log2^2(n))

		//void destroyTree(Node* node)//
Funkcja wykożystywana w destruktorze, niszczy poddrzewko o korzeniu node.
Złożoność: Wykonuje sie dla każdego elementu drzewka - O(n).

		//Node* find(Node* node, T element)//
Funkcja zwracająca element o wartości element.
Złożoność: Jeśli szukany przez nas element jest liściem funkcja wykona się 1.44*log2(n) razy co daje O(log2(n)).

		//T findMin(Node* node, T currMin) i T findMax(node* node, T element)//
Zwraca wartość odpowiednio najmniejszego i największego elementu w drzewku.
Złożoność: Szukany przez nas element jest liściem, więc funkcje wykonają się 1.44*log2(n) razy co daje O(log2(n)).

		//Node* findMinNode(Node* node, Node* currMin)//
Funkcja pomocnicza działająca na tej samej zasadzie co findMin, jednak zwracająca sam element, a nie jego wartość.
Złożoność: Szukany przez nas element jest liściem, więc funkcja wykona się 1.44*log2(n) razy co daje O(log2(n)).

		//Node* deleteNode(Node* node, T data)//
Usuwa element o wartości data. Działa rekurencyjnie: Najpierw szuka określonego elementu, następnie jeśli
jest on liściem, lub ma tylko 1 dziecko, zostaje on usunięty, a dziecko wpada na jego miejsce, gdy ma on 2
dzieci zaś, znajdujemy z pomocą FindMinNode() najmniejszy element na prawo od wybranego do usunięcia, po czym 
zamnieniamy je wartościami i usuwamy najmniejszy element z prawej. Na koniec funkcja sprawdza balans całego drzewka.
Złożoność: Sama funkcja zawsze wykonuje sie dla 1.44*log2(n) elementów (wysokość drzewka), ale teoretycznie
	   Wystąpić może sytuacja gdzie dla każdego elementu wykonana zostaje rotacja, zwiększając ilość
	   operacji do 2,0736*log2^2(n) i złożoność na O(log2^2(n))

		//int getSize(Node* node)//
Zwraca ilość elementów w drzewku. Robi to przechodząc prze wszystie elementy i licząc je.
Złożoność: Z racji na konieczność przejścia przez wszystie elementy fukcja odtworzy sie n razy co daje O(n).

		//Node* getParent(Node* node)//
Zwraca rodzica podanego node.
Złoźoność: O(1).

		//Node* getChildern(Node* node)//
Zwraca dzieci podanego node.
Złoźoność: O(1).

		//Node* getSibling(Node* node)//
Zwraca potencjalne rodzeństwo podanego node.
Złoźoność: O(1).

		//bool insert(const T& data)//
Pozwala wstawić do drzewka nowy element o wartosci data. Działa Wywołując insterNode(root,data).
Złożoność: Przez wywołanie insertNode() funkcja przejmuje jego złożoność O(log2(n)).

		//void PreOrder(Node* node)//
Wypisuje wszystkie elementy drzewka o kożeniu node w kolejności najpierw lewo potem prawo.
Złożoność: Z racji na konieczność przejścia przez wszystie elementy fukcja odtworzy sie n razy co daje O(n).

		//Node* getRoot()//
Zwraca kożeń drzewka.
Złożoność: O(1)

		//bool isFull()//
Zwraca true jeśli każdy element (oprucz liści) w drzewku a równą liczbe dzieci.
Złoźoność: Z racji na konieczność przejścia przez wszystie elementy fukcja odtworzy sie n razy co daje O(n).

		//int depth(Node* node)//
Zwraca rużnice wysokoście node i root.
Złożoność: O(1)

		//bool isLeaf(Node* node)//
Sprawdza czy podany node jest liściem.
Złożoność: O(1)

		//bool isEmpty()//
Sprawdza czy drzewko jest puste.
Złożoność: O(1)

		//bool search(T element)//
Sprawdza czy istnieje element o wartości element.
Złożoność: Funkcja wywołuje find co sprawia że ma złożoność O(log2(n)).

		//T minimum() i T maximum()//
Zwraca odpowiednio najmniejszy i najwiekszy element w drzewku.
Złożoność: Funkcje wywołują findMin oraz findMax co sprawia że mają złożoność O(log2(n)).

		//bool remove(T element)//
Usuwa element o wartości element za pomocą funkcji removeNode().
Złożoność: Funkcja wywołuje removeNOde co sprawia że ma złożoność O(log2^2(n)).