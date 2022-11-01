sekwencja_1 = "124adgaaa23gs"
sekwencja_2 = "mzbaida345add"

print("Podpunkt a)")
a = list(set(sekwencja_1)&set(sekwencja_2))

for i in a:
    print(i)

print("-----")
print("Podpunkt b)")
a = list(set(sekwencja_1)|set(sekwencja_2))

for i in a:
    print(i)