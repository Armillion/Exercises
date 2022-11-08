def make_grid(rows: int, cols: int):
    kwadrat = ""
    for i in range(rows):
        kwadrat += "+"
        for i in range(cols):
            kwadrat += "---+"
        kwadrat += "\n|"
        for i in range(cols):
            kwadrat += "   |"
        kwadrat += "\n"
    kwadrat += "+"
    for i in range(cols):
        kwadrat += "---+"
    return kwadrat

def make_ruler(n: int):
    miarka = "|"
    dlugosc = n

    for i in range(dlugosc):
        miarka += "....|"

    miarka += "\n"

    for i in range(dlugosc+1):
        miarka += str(i)
        miarka += "    "
        
    return miarka

print(make_grid(3,4))
print(make_ruler(5))