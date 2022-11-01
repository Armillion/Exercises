miarka = "|"
dlugosc = int(input("Podaj dlugosc: "))

for i in range(dlugosc):
    miarka += "....|"

miarka += "\n"

for i in range(dlugosc+1):
    miarka += str(i)
    miarka += "    "
    
print(miarka)