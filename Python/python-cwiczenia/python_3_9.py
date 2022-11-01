sekwencje = [[5,22],[],(8,2),[-2,4,123,5,82],(2,3,-5),(1)]
wyniki = []

for i in sekwencje:
    try:
        wyniki.append(sum(i))
    except:
        if type(i) is int or float:
            wyniki.append(i)
        else:
            print("Blad, ciag ma zawierac tylko liczby")
    
print(wyniki)