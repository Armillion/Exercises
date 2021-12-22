#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Podaj liczby naturalne m i n gdzie m => n \n");
    int m,n,reszta;
    scanf("%d",&m);
    scanf("%d",&n);

    while(n != 0)
    {
        reszta = m%n;
        m = n;
        n = reszta;
    }

    printf("NWD = %d\n" , m);
    return 0;
}
