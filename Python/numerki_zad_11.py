import numpy as np
import scipy as sp
import math

def findA():
    A = 1
    while pow(math.e,-A) >= pow(10,-7):
        A += 1
    return A

A = findA()
B = int(0)

n = 0
k = 0
#metoda trapezów
def f_X(x): 
    a = np.pi*((1 + np.sqrt(x))/(1 + x*x))
    a = np.sin(a)
    return a*pow(np.e,-x)

def getH(k):
        return (A-B)/(pow(2,k))

h = getH(k)

def trapezy(n,k):
    calka = f_X(B)
    x = B
    for i in range(1,k):
        x = x + h
        calka += 2*f_X(x)


    calka = (calka + f_X(A))*h*(0.5)

    return calka

#metoda ramberga
def ramberg(p):
    currCal = 1
    prevCal = 0
    I = np.zeros((p,p))
    for k in range(0, p):
        prevCal = currCal
        I[k, 0] = trapezy(n,pow(2,k)) 
        currCal = round(I[k,0],7)        

        if(currCal == prevCal) and k > 1:
            return currcal

        for j in range(0, k):
            I[k, j+1] = (4**(j+1) * I[k, j] - I[k-1, j]) / (4**(j+1) - 1) 
            currCal = round(I[k,j+1],7)     
            if(currCal == prevCal) and k > 1:
                return currcal
            prevCal = currcal

    return currCal

k = 0
prevCal = 0
currcal = 10000
while (currcal != prevCal):
    prevCal = currcal
    currcal = trapezy(n,pow(2,k))
    currcal = round(currcal,7)
    k += 1
    h = getH(k)

print("Calka z metody trapezow: ",currcal)
print("Ilosc iteracji:",k)

k = 0
prevCal = 0
currcal = 10000
while prevCal != currcal:
    prevCal = currcal
    currcal = ramberg(k)
    currcal = round(currcal,7)
    k += 1
    h = getH(k)

print("Calka z metody ramberga",currcal)
print("Ilosc iteracji",k)



