#include <stdio.h>

int konwersja_bez_operacji_biotwych(unsigned n, char *bin)
{
    int i = 0;
    unsigned a = n;
    while(a > 0)
    {
        bin[i] = a % 2;
        a = a / 2;
        i++;
    }

    return i;
}

int konwersja_z_operatorami_bitowymi(unsigned n, char* bin)
{
    int j = 0;
    while(n > 0)
    {
        if(n&1)
            bin[j] = 1;
        else
            bin[j] = 0;

        n=n>>1;
        j++;
    }

    return j;
}

int main()
{
    unsigned n;
    int i;
    char bin[16];

    scanf("%d", &n);

    konwersja_bez_operacji_biotwych(n, bin);
    i = konwersja_bez_operacji_biotwych(n, bin);
    printf("Ta liczba w postaci binarnej, obliczonej sposobem bez operacji bitowych, to: \n");
    for (i = i - 1; i >= 0; i--)
    {
        printf("%d", bin[i]);
    }
    printf("\n");

    printf("Ta liczba w postaci binarnej, obliczonej sposobem z operacjami bitowymi, to: \n");
    konwersja_z_operatorami_bitowymi(n,bin);
    for (i = konwersja_z_operatorami_bitowymi(n,bin) - 1; i >= 0; i--)
    {
        printf("%d", bin[i]);
    }

    return 0;
}
