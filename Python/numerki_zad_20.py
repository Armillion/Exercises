import numpy as np

x = []
y = []
nrOfDegs = 15
wielomiany = []

with open("C:\\Users\\User\\Desktop\\Studia\\Jezyk C\\Zadania\\python\\w.txt", "r") as file1:
    for line in file1.readlines():
        f_list = [float(i) for i in line.split("\t")]
        x.append(f_list[0])
        y.append(f_list[1])

nrOfPoints = len(x)

def calculateAICScore():
    for i in range(1, nrOfDegs):
        Q = 0
        comp = np.poly1d(np.polyfit(x, y, i))
        for j in range(nrOfPoints):
            Q = Q + pow((comp(x[j]) - y[j]),2)
        aic = np.log(Q) + 2 * i / nrOfPoints
        wielomiany.append(aic)
    
calculateAICScore()

print("Wyniki wyliczen AIC")
print(wielomiany)
n = wielomiany.index(min(wielomiany)) + 1
print("Wybieram stopien :", n )
poly = np.polyfit(x, y, n)
polyAsPoly1d = np.poly1d(poly)

def sigma():
    wynik = 0
    for i in range(nrOfPoints):
        wynik += pow(y[i] - polyAsPoly1d(x[i]),2) 
    wynik = wynik / nrOfPoints
    return wynik

wariancja = sigma()

def generateBaseMatrix():
    M = np.zeros((nrOfPoints, len(poly)))
    for i in range(nrOfPoints):
        M[i][2] = pow(x[i],2) * poly[0]
        M[i][1] = x[i] * poly[1]
        M[i][0] = poly[2]
    return M

baseMatrix = np.array(generateBaseMatrix())
Cp = np.matmul(baseMatrix.transpose(), baseMatrix)
Cp = np.linalg.inv(Cp)
Cp = Cp * wariancja**2

print("Macierz kowariancji:", "\n", Cp)