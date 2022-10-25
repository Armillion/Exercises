line = "sortowanie alfabetyczne to proste zadanie"
words = line.split(" ")

# alfabetycznie
words.sort()
print(words)

# po długosci
words.sort(key=len)
print(words)
