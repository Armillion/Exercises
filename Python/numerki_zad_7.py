from cProfile import label
import math
import numpy as np
import matplotlib.pyplot as plt

X = np.array([0.062500 , 0.187500 , 0.312500 , 0.437500 , 0.562500 , 0.687500 , 0.812500 , 0.937500],dtype=float)
f = np.array([0.687959 , 0.073443 , -0.517558 , -1.077264 , -1.600455 , -2.080815 , -2.507266 , -2.860307],dtype=float)

def lagrange(i,x):
    x_tmp = np.concatenate((X[:i],X[i+1:]),dtype=float)
    l = 1
    for node in np.nditer(x_tmp):
        l *= (x - node)/(X[i] - node)
    return l

def interpolate(x):
    l = 0
    for i in range(len(X)):
        l += lagrange(i,x) * f[i]
    return l

coef = np.zeros(8)
val = np.copy(f)
for i in range(len(coef)):
    for j in range(len(coef)):
        coef[i] += lagrange(j,0) * val[j]
    
    for k in range(len(coef)):
        val[k] -= coef[i]
        val[k] /= X[k]
        
print("Wspułczynniki wielomiau:",coef)

x_interpolated = np.linspace(-1,1,1000,endpoint=True)
f_interpolated = np.around(np.array([interpolate(x) for x in x_interpolated]),4)
plt.scatter(X,f,label="Węzły")
plt.plot(x_interpolated,f_interpolated,label="Interpolacja",color="red")
plt.legend()
plt.show()

