
line = "To jest napis wielowyrazowy - moj ulubiony typ napisu"

# dzielimy line na pojedyncze wyrazy
words = line.split(" ")

# wyliczamy ilosc wyrazow 
assert_resoult = len(words)
expected_resoult = 9

# porownujemy z wartoscia oczekiwana
print(assert_resoult == expected_resoult)
