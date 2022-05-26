import numpy as np

macierz = np.array([
    [19/12, 13/12, 5/6, 5/6, 13/12, -17/12],
    [13/12, 13/12, 5/6, 5/6, -11/12, 13/12],
    [5/6, 5/6, 5/6, -1/6, 5/6, 5/6],
    [5/6, 5/6, -1/6, 5/6, 5/6, 5/6],
    [13/12, -11/12, 5/6, 5/6, 13/12, 13/12],
    [-17/12, 13/12, 5/6, 5/6, 13/12, 19/12],
],dtype=float)

precision = 0.00000001

def wWlasna(czyPierwsza: bool, poprzedniaWWasna: float):
    y = np.array([1.0, 0.0, 0.0, 0.0, 0.0, 0.0],dtype=float)
    yPrim = 0.0
    while True:
        zk = np.matmul(macierz,y)

        if(czyPierwsza):
            zk = ortogonalizacja(zk,poprzedniaWWasna)

        zk_norm = np.linalg.norm(zk)
        
        yPrim = np.zeros(len(zk))
        for i in range(len(yPrim)):
            yPrim[i] += zk[i]/zk_norm

        if abs(abs(y[0]) - abs(yPrim[0])) < precision:
            print("wektor wlasny:", yPrim)
            print("wartosc wlasna:", zk_norm)
            break

        y = yPrim

    return yPrim

def ortogonalizacja(zk, e):
    a = 0
    for i in range(len(zk)):
        a += zk[i] * e[i] 

    for i in range(len(zk)):
        zk[i] -= e[i] * a

    return zk

wwlasna1 = wWlasna(False,0.0)
wwlasna2 = wWlasna(True, wwlasna1)
numpyWlasna = np.linalg.eig(macierz)
print("wartosci wlasne numpy:", numpyWlasna[0])