line = "Hej to znowu ja - wasz ulubiony typ napisu"
words = line.split(" ")

# wyraz z pierwszych znakow
assert_resoult = ""
for a in words:
    assert_resoult += a[0]

expected_resoult = "Htzj-wutn"
print(assert_resoult == expected_resoult)

# wyraz z ostatnich znakow
assert_resoult = ""
for a in words:
    assert_resoult += a[-1]
    
expected_resoult = "joua-zypu"
print(assert_resoult == expected_resoult)