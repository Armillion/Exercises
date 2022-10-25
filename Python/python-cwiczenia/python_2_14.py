line = "Wyrazy dluugie, ale i nie tylko"
words = line.split(" ")
words.sort(key=len)
print("Najdluzszy wyraz to " + words[-1]) 
print("Ma dlugosc" , len(words[-1]))