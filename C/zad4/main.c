#include <stdio.h>
#include <math.h>

int main()
{
    int n;
    scanf( "%d" , &n );
    int liczby_pierwsze[n-1];
    int licznik ,licznik2 = 0;

    for(licznik = 2; licznik <= n ; licznik++)
    {
        liczby_pierwsze[licznik-2] = licznik;
    }


    for(licznik = 2 ; licznik < sqrt(n) ; licznik++)
    {
        for(licznik2 = 0; licznik2 < n-1 ; licznik2++)
        {
            if(liczby_pierwsze[licznik2] % licznik == 0 &&
               liczby_pierwsze[licznik2] != licznik)
            {
                liczby_pierwsze[licznik2] = 0;
            }
        }
    }

    for(licznik2 = 0 ; licznik2 < n-1 ; licznik2++)
    {
        if(liczby_pierwsze[licznik2] != 0)
            printf("%d\n", liczby_pierwsze[licznik2]);
    }
    return 0;
}
