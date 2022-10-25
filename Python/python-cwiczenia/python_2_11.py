word = "word"
wordUnderscored = ""

for a in word:
    if(a != word[0] and a != word[-0]):
        wordUnderscored += "_"
    wordUnderscored += a
    
expected_resoult = "w_o_r_d"
print(wordUnderscored == expected_resoult)