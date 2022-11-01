# L = [3, 5, 4] ; L = L.sort()
# list.sort() zwraca none, by uzyskać posortowane L:
L = [3, 5, 4] ; L.sort()
#---------------------------------------------------
# x, y = 1, 2, 3
# Jedna liczba za duzo lub jedna zmieenna za malo.
#---------------------------------------------------
# X = 1, 2, 3 ; X[1] = 4
# Krotki nie pozwalaja nam przypisywac wartosci.
#---------------------------------------------------
# X = [1, 2, 3] ; X[3] = 4
# X[3] nie istnieje, wienc nie mozemy przypisac 
# do niego wartosci, by dodac do tablicy 4:
X = [1, 2, 3] ; X.append(4)
#----------------------------------------------------
# X = "abc" ; X.append("d")
# String nie jest tablica wienc nie ma metody append
X = "abc" ; X += "d"
#----------------------------------------------------
# L = list(map(pow, range(8)))
# Brakuje 2 argumentu funkcji pow