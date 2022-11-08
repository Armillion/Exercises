# rekurencyjnie
def sum_seq(sequence):
    suma = 0
    for i in sequence:
        if isinstance(i,(list,tuple)):
            suma += sum_seq(i)
        else:
            suma += i
    return suma

seq = [[],[(1,2),(3,6)],(1),[2,35,4]]
# oczekiwany wynik = 54
print(sum_seq(seq))