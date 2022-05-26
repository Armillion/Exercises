import numpy as np
import random
import lmfit as lm
import matplotlib.cm as cm
import matplotlib.pyplot as plt
import scipy.optimize as sp

pkty = random.randrange(3,20)
zakresx = 10
zakresy = 100
tolerancja = 0.00000001
randompts = lm.Parameters()
kroki = []
randoms = []

fig = plt.figure()
subplt = fig.add_subplot(111, projection='3d')
X = np.linspace(-zakresx, zakresx, 1000)
Y = np.linspace(-zakresy, zakresy, 1000)
X, Y = np.meshgrid(X, Y)
surf = subplt.plot_surface(X, Y, sp.rosen((X,Y)), cmap=cm.RdYlBu)

def fun_rosenbrock(params):
    return np.array([10 * (params['y'] - params['x'] * params['x']), (1 - params['x'])])

def callback(params,iter,resid):
    kroki.append((params['x'].value,params['y'].value))

for i in range(pkty):
    randoms.append((random.uniform(-zakresx, zakresx),random.uniform(-zakresy, zakresy)))

for a in randoms:
    kroki.append(a)
    randompts.add('x',value=a[0])
    randompts.add('y',value=a[1])
    print("wylosowanio punkt (", a, ")")
    f = lm.minimize(fun_rosenbrock,randompts,iter_cb=callback)
    val = sp.rosen(kroki[-1])
    print("minimum (", kroki[-1] ,")", "wartosc :", val,
            "iteracji: ", f.nfev)
    parx = []
    pary = []
    parz = []
    for x in kroki:
        parx.append(x[0])
        pary.append(x[1])
        parz.append(sp.rosen(x))
    subplt.plot3D(parx, pary, parz, linewidth=1.5, linestyle='dashed', markersize=10, color="green",zorder=3)
    randompts.clear()
    kroki.clear()

plt.show()
