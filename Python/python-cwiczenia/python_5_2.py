def add_frac(frac1, frac2):             # frac1 + frac2
    if frac1[1] == frac2[1]:
        return [frac1[0] + frac2[0],frac2[1]]
    
    nww = (frac1[1]*frac2[1])/euklides(frac2[1],frac1[1])
    
    return [frac1[0] * (nww / frac1[1]) + frac2[0] * (nww / frac2[1]),nww]
    
modul = lambda x : -x if x < 0 else x
def euklides(denom1,denom2):            #aby znelesc nwd, konieczne do wyliczenia nww
    a = modul(denom1)
    b = modul(denom2)
    while(a != b):
        if a > b:
            a -= b
        else: 
            b -= a
    return a

def sub_frac(frac1, frac2):             # frac1 - frac2
    return add_frac(frac1,[-frac2[0],frac2[1]])

def mul_frac(frac1, frac2):             # frac1 * frac2
    return [frac2[0] * frac1[0],frac1[1] * frac2[1]]

def div_frac(frac1, frac2):             # frac1 / frac2
    return mul_frac(frac1,[frac2[1],frac2[0]])

def is_positive(frac):                  # bool, czy dodatni
    return (frac[0] > 0 and frac[1] > 0) or (frac[0] < 0 and frac[1] < 0)

def is_zero(frac):                      # bool, typu [0, x]
    return frac[0] == 0

def cmp_frac(frac1, frac2):             # -1 | 0 | +1
    if frac1[0]/frac1[1] > frac2[0]/frac2[1]:
        return 1
    elif frac1[0]/frac1[1] == frac2[0]/frac2[1]:
        return 0
    else:
        return -1

def frac2float(frac):                   # konwersja do float
    return frac[0]/frac[1]

# f1 = [-1, 2]      # -1/2
# f2 = [1, -2]      # -1/2 (niejednoznaczność)
# f3 = [0, 1]       # zero
# f4 = [0, 2]       # zero (niejednoznaczność)
# f5 = [3, 1]       # 3
# f6 = [6, 2]       # 3 (niejednoznaczność)

import unittest

class TestFractions(unittest.TestCase):

    def setUp(self):
        self.zero = [0, 1]

    def test_add_frac(self):
        self.assertEqual(add_frac([1, 2], [1, 3]), [5, 6])
        self.assertEqual(add_frac([1, 9], [4, 9]), [5, 9])
        self.assertEqual(add_frac([2, 5], [1, 10]), [5, 10])

    def test_sub_frac(self): 
        self.assertEqual(sub_frac([1, 2], [1, 4]), [1, 4])
        self.assertEqual(sub_frac([1, 3], [2, 7]), [1, 21])
        self.assertEqual(sub_frac([3, 5], [2, 5]), [1, 5])

    def test_mul_frac(self):
        self.assertEqual(mul_frac([1, 5], [3, 7]), [3, 35])
        self.assertEqual(mul_frac([3, 2], [5, 6]), [15, 12])
        self.assertEqual(mul_frac([2, 2], [1, 6]), [2, 12])

    def test_div_frac(self): 
        self.assertEqual(div_frac([1, 2], [1, 2]), [2, 2])
        self.assertEqual(div_frac([1, 7], [5, 8]), [8, 35])
        self.assertEqual(div_frac([3, 1], [1, 2]), [6, 1])

    def test_is_positive(self): 
        self.assertEqual(is_positive([-1, 2]), False)
        self.assertEqual(is_positive([1, 2]), True)
        self.assertEqual(is_positive([-1, -2]), True)

    def test_is_zero(self):
        self.assertEqual(is_zero([0, 2137]), True)
        self.assertEqual(is_zero([1, 2]), False)
        self.assertEqual(is_zero([0, 3]), True)

    def test_cmp_frac(self):
        self.assertEqual(cmp_frac([1, 2], [1, 4]), 1)
        self.assertEqual(cmp_frac([1, 2], [2, 4]), 0)
        self.assertEqual(cmp_frac([1, 2], [4, 4]), -1)

    def test_frac2float(self):
        self.assertEqual(frac2float([1, 2]),0.5)
        self.assertEqual(frac2float([1, 5]),0.2)
        self.assertEqual(frac2float([1, 100]),0.01)

    def tearDown(self): pass

if __name__ == '__main__':
    unittest.main()     # uruchamia wszystkie testy
