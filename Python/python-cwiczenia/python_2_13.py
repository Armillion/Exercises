line = "Dom dla kota"
words = line.split(" ")
assert_resoult = sum(len(a) for a in words)
expected_resoult = 10
print(assert_resoult == expected_resoult)