import numpy as np

precison = 0.00000001

macierz = np.array([
    [19/12, 13/12, 5/6, 5/6, 13/12, -17/12],
    [13/12, 13/12, 5/6, 5/6, -11/12, 13/12],
    [5/6, 5/6, 5/6, -1/6, 5/6, 5/6],
    [5/6, 5/6, -1/6, 5/6, 5/6, 5/6],
    [13/12, -11/12, 5/6, 5/6, 13/12, 13/12],
    [-17/12, 13/12, 5/6, 5/6, 13/12, 19/12],
],dtype=float)

Q = np.zeros(macierz.shape)
np.fill_diagonal(Q, 1.0)

def householder():

    n = macierz.shape[0]
    v = np.zeros(n, dtype=float)
    u = np.zeros(n, dtype=float)
    z = np.zeros(n, dtype=float)

    for k in range(n - 2):

        if np.isclose(macierz[k + 1, k], 0.0):
            a = -np.sqrt(np.sum(macierz[(k + 1) :, k] * macierz[(k + 1) :, k]))
        else:
            a = -np.sign(macierz[k + 1, k]) * np.sqrt(np.sum(macierz[(k + 1) :, k] * macierz[(k + 1) :, k]))

        r = a * a - a * macierz[k + 1, k]
        v[k] = 0.0
        v[k + 1] = macierz[k + 1, k] - a
        v[(k + 2) :] = macierz[(k + 2) :, k]
        u[k:] = 1.0 / r * np.dot(macierz[k:, (k + 1) :], v[(k + 1) :])
        z[k:] = u[k:] - np.dot(u, v) / (2.0 * r) * v[k:]

        for l in range(k + 1, n - 1):

            macierz[(l + 1) :, l] = (macierz[(l + 1) :, l] - v[l] * z[(l + 1) :] - v[(l + 1) :] * z[l])
            macierz[l, (l + 1) :] = macierz[(l + 1) :, l]
            macierz[l, l] = macierz[l, l] - 2 * v[l] * z[l]

        macierz[-1, -1] = macierz[-1, -1] - 2 * v[-1] * z[-1]
        macierz[k, (k + 2) :] = 0.0
        macierz[(k + 2) :, k] = 0.0

        macierz[k + 1, k] = macierz[k + 1, k] - v[k + 1] * z[k]
        macierz[k, k + 1] = macierz[k + 1, k]

def givens():
    global macierz,Q
    Q = np.zeros(macierz.shape)
    np.fill_diagonal(Q, 1.0)
    for i in range(len(macierz) - 1):
        G = np.zeros(macierz.shape)
        np.fill_diagonal(G, 1.0)

        norm = np.sqrt(macierz[i][i]*macierz[i][i] + macierz[i + 1][i]*macierz[i+1][i])
        c = macierz[i][i] / norm
        s = macierz[i + 1][i] / norm

        G[i][i] = c
        G[i][i + 1] = s
        G[i + 1][i] = -s
        G[i + 1][i + 1] = c

        macierz = np.matmul(G, macierz)
        Q = np.matmul(Q, G.transpose())

def qr():
    global macierz
    tmp = np.zeros(macierz.shape)
    tmp[0][0] = 1000000
    while abs(abs(tmp[0][0]) - abs(macierz[0][0])) >= precison:
        tmp = macierz
        givens()
        macierz = np.matmul(macierz, Q)

householder()
print(np.around(macierz))
qr()
print(np.around(macierz))
