#include <stdio.h>
#include <ctype.h>
#include <math.h>


int main()
{
    int licznik = 0;
    int czy_arab = 0,czy_rzym = 0;
    char liczba[20];
    scanf("%s" , &liczba);
    int rozmiar_liczby = 0;

    while( liczba[rozmiar_liczby] != '\0' )
    {
        rozmiar_liczby++;
    }

    for(licznik = 0 ; licznik < rozmiar_liczby ; licznik++)
    {
        if(!isdigit(liczba[licznik]))
            break;
        if(licznik == rozmiar_liczby - 1 )
            czy_arab = 1;
    }
    if(czy_arab != 1)
    {
        for(licznik = 0 ; licznik < rozmiar_liczby ; licznik++)
        {
            if(!isalpha(liczba[licznik]))
                break;
            if(licznik == rozmiar_liczby - 1)
                czy_rzym = 1;
        }
    }

    if(czy_arab != 1 && czy_rzym != 1)
    {
        printf("Niepoprawny/e znak/i\n");
    }
    else if(czy_arab)
    {
        int liczba_jako_int = 0 ;
        for(licznik = 0 ; licznik < rozmiar_liczby ; licznik++)
        {
            liczba_jako_int += (liczba[licznik] - '0' ) * pow(10,rozmiar_liczby - licznik - 1);
        }

        while(liczba_jako_int != 0)
        {

            if (liczba_jako_int >= 1000)
            {
                printf("m");
                liczba_jako_int -= 1000;
            }

            else if (liczba_jako_int >= 900)
            {
                printf("cm");
                liczba_jako_int -= 900;
            }

            else if (liczba_jako_int >= 500)
            {
                printf("d");
                liczba_jako_int -= 500;
            }

            else if (liczba_jako_int >= 400)
            {
                printf("cd");
                liczba_jako_int -= 400;
            }

            else if (liczba_jako_int >= 100)
            {
                printf("c");
                liczba_jako_int -= 100;
            }

            else if (liczba_jako_int >= 90)
            {
                printf("xc");
                liczba_jako_int -= 90;
            }

            else if (liczba_jako_int >= 50)
            {
                printf("l");
                liczba_jako_int -= 50;
            }

            else if (liczba_jako_int >= 40)
            {
                printf("xl");
                liczba_jako_int -= 40;
            }

            else if (liczba_jako_int >= 10)
            {
                printf("x");
                liczba_jako_int -= 10;
            }

            else if (liczba_jako_int >= 9)
            {
                printf("ix");
                liczba_jako_int -= 9;
            }

            else if (liczba_jako_int >= 5)
            {
                printf("v");
                liczba_jako_int -= 5;
            }

            else if (liczba_jako_int >= 4)
            {
                printf("iv");
                liczba_jako_int -= 4;
            }

            else if (liczba_jako_int >= 1)
            {
                printf("i");
                liczba_jako_int -= 1;
            }

        }

    }else if(czy_rzym)
    {
        int arabska = 0,dodaj = 0, ostation_dodana = 0;
        for(licznik = 0 ; licznik < rozmiar_liczby ; licznik++)
        {
            switch(liczba[licznik])
            {
            case 'M':
            dodaj = 1000;
            break;
            case 'D':
            dodaj = 500;
            break;
            case 'C':
            dodaj = 100;
            break;
            case 'L':
            dodaj = 50;
            break;
            case 'X':
            dodaj = 10;
            break;
            case 'V':
            dodaj = 5;
            break;
            case 'I':
            dodaj = 1;
            break;
            }

            if(dodaj > ostation_dodana)
            arabska = arabska + dodaj - 2 * ostation_dodana;
        else
            arabska += dodaj;
            ostation_dodana = dodaj;
            dodaj = 0;
        }

        printf("%d\n",arabska);

    }

    return 0;
}
