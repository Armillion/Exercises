# iteracyjnie
# def odwracanie(L: list, left: int, right: int):
#    a = 0
#    for i,j in zip(range(left,right+1),range(right,left-1,-1)):
#        if i >= j:
#            break
#        a = L[i]
#        L[i] = L[j]
#        L[j] = a
        
# rekurencyjnie
def odwracanie(L: list, left: int, right: int):
    if left >= right:
        return
    a = L[left]
    L[left] = L[right]
    L[right] = a
    odwracanie(L,left+1, right-1)
    
      
lista = ["Moja","lista","do","odwrocenia","i","hej"]  
odwracanie(lista,3,5)
print(lista)