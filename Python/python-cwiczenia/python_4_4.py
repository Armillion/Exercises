def fibbonacci(n):
    a = 1
    b = 1
    for i in range(n-1):
        a = a + b
        b = a - b
    return a

print(fibbonacci(6))