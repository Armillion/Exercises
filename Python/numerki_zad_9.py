from cProfile import label
from turtle import color
import numpy as np 
import matplotlib.pyplot as plt
import math 
import scipy.linalg as sp

x = np.array([-7/8, -5/8, -3/8 , -1/8 , 1/8, 3/8, 5/8, 7/8],dtype=float)
f_X = lambda x : 1/(1+(5*(x*x)))
scho = np.zeros((6,6))
h = 2/8

def getB():
    b = np.array([],dtype=float)
    for i in range( x.shape[0] - 2):
        val = f_X(x[i]) - 2*f_X(x[i+1]) + f_X(x[i+2])
        val *= 6/(h*h)
        b = np.append(b,val)

    return b

B = getB()

def cubicSpline(i,j):
    a = (x[j+1] - i)/h
    b = (i - x[j])/h
    c = 1/6 * (a*a*a - a)*h*h
    d = 1/6 * (b*b*b - b)*h*h

    y = a*f_X(x[j]) + b*f_X(x[j+1]) + c*sigm[j] + d*sigm[j+1]
    return y

def thomas(a,b,c,d):
    beta, gamma = [], []
    n = len(d)

    beta.append(c[0]/b[0])
    gamma.append(d[0]/b[0])

    for i in range (1, n):
        beta.append(c[i] / (b[i] - a[i]*beta[i-1]))
        gamma.append((d[i] - a[i] * gamma[i-1]) / (b[i] - a[i] * beta[i-1]))
    
    x = np.zeros(n)

    x[-1] = gamma[-1]
    for i in range(n-2, -1, -1):
        x[i] =  gamma[i] - beta[i] * x[i+1]

    return x

a = [0, 1, 1, 1, 1, 1]
b = [4 for i in range(6)]
c = a[::-1]
sigm = thomas(a,b,c,B)
sigm = np.concatenate(([0],sigm,[0]))   
print(sigm)
f_x_calculated = np.array([],dtype=float)
x_tmp = np.linspace(-7/8,7/8,14000)

for i in range(x.size - 1):
    for j in np.linspace(x[i],x[i+1],2000):
        f_x_calculated = np.append(f_x_calculated,cubicSpline(j,i))


plt.scatter(x,f_X(x),label="Więzły")
plt.plot(x_tmp,f_x_calculated,label="splajn",color="red")
plt.plot(x_tmp,f_X(x_tmp),label="funkcja teoretyczna",color="green")
plt.legend()
plt.show()
