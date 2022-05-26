import cmath
from re import A
import numpy.polynomial.laguerre as lag
import numpy as np
from typing import Callable


P0_arr = np.array([243,-486,783,-990,558,-28,72,16])
P1_arr = np.array([1,1,3,2,-1,-3,-11,-8,-12,-4,4])
P2_arr = np.array([ 1,(0+1j),-1,(0+1j),1])
P0 = np.poly1d(P0_arr)
P0_cpy = P0
P1 = np.poly1d(P1_arr)
P1_cpy = P1
P2 = np.poly1d(P2_arr)
P2_cpy = P2
P0_der1 = np.polyder(P0)
P1_der1 = np.polyder(P1)
P2_der1 = np.polyder(P2)
P0_der2 = np.polyder(P0_der1)
P1_der2 = np.polyder(P1_der1)
P2_der2 = np.polyder(P2_der1)


def laguerre_method(wielomian :np.poly1d , pochodna1: np.poly1d , pochodna2: np.poly1d  , x0: int ,precision: int = 8):
    
    n = wielomian.order 
    xk = x0
    
    while np.round(wielomian(xk),precision) != 0 + 0j :
        a = n*wielomian(xk)
        b = cmath.sqrt((n-1)*((n-1)*(pochodna1(xk)*pochodna1(xk)) - n*wielomian(xk)*pochodna2(xk)))
        d = max([pochodna1(xk) + b, pochodna1(xk) - b], key=abs)
        x = a/d
        xk -= x

    return xk

roots = np.array([])
der = P0_der1
der2 = P0_der2
a = 0 + 0j
while(P0.order != 0):
    a = laguerre_method(P0,P0_der1,P0_der2,a)
    roots = np.append(roots,laguerre_method(P0_cpy,der,der2,a))
    poly1 = np.poly1d([1,-a])
    P0,b = np.polydiv(P0,poly1)
    P0_der1 = np.polyder(P0)
    P0_der2 = np.polyder(P0_der1)

print("Pierwiastki z dokladnoscia do 7 miejsc po przecinku: ",roots)
print("Wartosci dla owych pierwiastkow",np.round(P0_cpy(roots),7))

roots = np.array([])
der = P1_der1
der2 = P1_der2
a = 1 + 0j
while(P1.order != 0):
    a = laguerre_method(P1,P1_der1,P1_der2,a)
    roots = np.append(roots,laguerre_method(P1_cpy,der,der2,a))
    poly1 = np.poly1d([1,-a])
    P1,b = np.polydiv(P1,poly1)
    P1_der1 = np.polyder(P1)
    P1_der2 = np.polyder(P1_der1)

print("Pierwiastki z dokladnoscia do 7 miejsc po przecinku: ",roots)
print("Wartosci dla owych pierwiastkow",np.round(P1_cpy(roots),7))

roots = np.array([])
der = P2_der1
der2 = P2_der2
a = 1 + 0j
while(P2.order != 0):
    a = laguerre_method(P2,P2_der1,P2_der2,a)
    roots = np.append(roots,laguerre_method(P2_cpy,der,der2,a))
    poly1 = np.poly1d([1,-a])
    P2,b = np.polydiv(P2,poly1)
    P2_der1 = np.polyder(P2)
    P2_der2 = np.polyder(P2_der1)

print("Pierwiastki z dokladnoscia do 7 miejsc po przecinku: ",roots)
print("Wartosci dla owych pierwiastkow",np.round(P2_cpy(roots),7))


