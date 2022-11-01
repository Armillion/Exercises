def roman2int(nr: str):
    wynik = 0
    #slownik
    roman = {'I':1,'V':5,'X':10,'L':50,'C':100,'D':500,'M':1000,'IV':4,'IX':9,'XL':40,'XC':90,'CD':400,'CM':900}
    i = 0
    while i < len(nr):
         if i+1 < len(nr) and nr[i:i+2] in roman:
            wynik += roman[nr[i:i+2]]
            i += 2
         else:
            wynik += roman[nr[i]]
            i += 1
    return wynik

print(roman2int("CDXXX"))
print(roman2int("CCCLIV"))
                