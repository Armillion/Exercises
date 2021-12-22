#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define N_MAX 100
#define MAX_W_LINI 50

char *Text[N_MAX];

int main()
{
    int i = 0,j,k;
    char *temp;
    Text[i] = (char*)malloc(MAX_W_LINI);

    while(i < N_MAX && fgets(Text[i],MAX_W_LINI,stdin) != NULL )
    {
        if(strcmp(Text[i],"\n") != 0 ) /*sprawdzenie czy wiersz jest pusty */
        {
            i++;
            Text[i] = (char*)malloc(MAX_W_LINI);
        }
    }

    for(j=0; j<i; j++)
    {
        for(k=j+1; k<i; k++)
        {
            if(strcmp(Text[j], Text[k]) > 0)
            {
                temp = Text[j];
                Text[j] = Text[k];
                Text[k] = temp;
            }
        }
    }

    for(j=0; j<i; j++)
    {
        printf("%s\n",Text[j]);
    }

    return 0;
}
