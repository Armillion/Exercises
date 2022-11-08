def factorial(n):
    silnia = 1
    for i in range(n + 1):
        if i != 0:
            silnia *= i
    return silnia

print(factorial(4))