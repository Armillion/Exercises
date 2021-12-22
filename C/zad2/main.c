#include <stdio.h>
#include <math.h>

int main()
{
    printf("ax^2 + bx + c = 0 \n");
    int wspolczynnik1 = 1,wspolczynnik2 = 1,wspolczynnik3 = 1;

    do
    {
        printf("Podaj wspulczynnik przy x^2 (nie moze byc 0) \n");
        scanf("%d",&wspolczynnik1);
    }while(wspolczynnik1 == 0);

    printf("Podaj wspulczynnik przy x \n");
    scanf("%d",&wspolczynnik2);

    printf("Podaj wyraz wolny \n");
    scanf("%d",&wspolczynnik3);

    int delta = (wspolczynnik2*wspolczynnik2) - (4 * wspolczynnik1 * wspolczynnik3);

    if( delta > 0)
    {
        printf("x1 = %f\n" ,((-1 * wspolczynnik2) - sqrt(delta))/(2*wspolczynnik1) );
        printf("x2 = %f\n" ,((-1 * wspolczynnik2) + sqrt(delta))/(2*wspolczynnik1) );
    }else if(delta == 0)
    {
        printf("x = %d\n", (-1 * wspolczynnik2)/(2 * wspolczynnik1));
    }else
    printf("R0wnanie nie ma rozwiazan :C \n");

    return 0;
}
