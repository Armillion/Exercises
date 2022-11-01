# x = 2; y = 3;
# if (x > y):
#    result = x;
# else:
#    result = y;
#
# Ten kod jest poprawny.
#-------------------------------------------------------
# for i in "axby": if ord(i) < 100: print (i)
# Ten kod jest niepoprawny, brakuje indentacji, 
# poprawiona wersja wygladalaby tak:
# for i in "axby": 
#    if ord(i) < 100: print (i)
#--------------------------------------------------------
# for i in "axby": print (ord(i) if ord(i) < 100 else i)
# Ten kod jest poprawny
