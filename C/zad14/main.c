#include <stdio.h>
#include <string.h>
#include <math.h>
#define STOS_MAX 100

double stos[STOS_MAX];
int wielkosc_stosu = 0;

void push(double na_stos)
{
    /* odkladamy na stos */
    if(wielkosc_stosu == STOS_MAX )
        printf("Stos jest pelen\n");
    else
    {
        stos[wielkosc_stosu] = na_stos;
        wielkosc_stosu++;
    }
}

double pop(void)
{
    /*zabieramy ze stosu */
    if(wielkosc_stosu == 0)
    {
        printf("Stos jest pusty\n");
        return 0;
    }
    else
    {
        wielkosc_stosu--;
        return stos[wielkosc_stosu];
    }
}

int main()
{
    char dzialanie_w_ONP[10];
    int i,j = 0;
    double x = 0,y = 0;

    printf("Podaj dzialanie w ONP:\n");
    scanf("%s",&dzialanie_w_ONP);

    while(strncmp(dzialanie_w_ONP,"=",1))
    {
        i = strlen(dzialanie_w_ONP);

        /*  decydujemy co zrobic
        w zaleznosci od tego
        jaki znak przeczytamy */

        if(isdigit(dzialanie_w_ONP[0]))
        {
            /*jesli mamy liczbe dodaj ja na stos */
            x = 0;
            for(j = 0; j < i ; j++)
            {
                x += (dzialanie_w_ONP[j] - '0') * pow(10,i - j - 1);
            }
            push(x);
        }
        else
        {
            if(!strcmp(dzialanie_w_ONP,"+"))
            {
                x = pop();
                y = pop();
                push(x + y);
            }
            else if(!strcmp(dzialanie_w_ONP,"-"))
            {
                x = pop();
                y = pop();
                push(y - x);
            }
            else if(!strcmp(dzialanie_w_ONP,"*"))
            {
                x = pop();
                y = pop();
                push(y * x);
            }
            else if(!strcmp(dzialanie_w_ONP,"/"))
            {
                x = pop();
                y = pop();
                push(y/x);
            }
            else if(!strcmp(dzialanie_w_ONP,"^"))
            {
                x = pop();
                y = pop();
                push(pow( y , x ));
            }
            else if(!strcmp(dzialanie_w_ONP,"sqrt"))
            {
                x = pop();
                push(sqrt(x));
            }
            else if(!strcmp(dzialanie_w_ONP,"ln"))
            {
                x = pop();
                push(log(x));
            }
            else if(!strcmp(dzialanie_w_ONP,"log"))
            {
                x = pop();
                push(log10(x));
            }
            else if(!strcmp(dzialanie_w_ONP,"sin"))
            {
                x = pop();
                push(sin(x));
            }
            else if(!strcmp(dzialanie_w_ONP,"cos"))
            {
                x = pop();
                push(cos(x));
            }

        }

        scanf("%s",&dzialanie_w_ONP);
    }


    printf("%f\n",stos[wielkosc_stosu - 1]);
    return 0;
}
