X = ""
while(True):
    X = input("Podaj argument")
    if X == "stop":
        break
    else:
        try:
            print(X,pow(float(X),3))
        except:
            print("Blad, podaj liczbe")