kwadrat = ""
wymiary = 3, 4

for i in range(wymiary[0]):
    kwadrat += "+"
    for i in range(wymiary[1]):
        kwadrat += "---+"
    kwadrat += "\n|"
    for i in range(wymiary[1]):
        kwadrat += "   |"
    kwadrat += "\n"
kwadrat += "+"
for i in range(wymiary[1]):
    kwadrat += "---+"

print(kwadrat)