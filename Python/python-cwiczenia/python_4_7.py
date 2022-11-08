def flatten(sequence):
    L = []
    for i in sequence:
        if isinstance(i,(list,tuple)):
            for x in flatten(i):
                L.append(x)
        else:
            L.append(i)
    return L

seq = [[],[(1,2),(3,6)],(1),[2,35,4]]
# oczekiwany wynik = [1,2,3,6,1,2,35,4]
print(flatten(seq))