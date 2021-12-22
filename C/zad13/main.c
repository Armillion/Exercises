#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define NMAX 10

int main(int argc, char *Argv[])
{
    FILE *file1, *file2;
    char znak;
    char haslo[NMAX];
    int j = 0, dlugosc_hasla;

    scanf("%s", haslo);

    if (NULL == (file1 = fopen(Argv[1], "rb")))
        return 2;

    if (NULL == (file2 = fopen("tymczasowy", "wb")))
        return 1;

    znak = getc(file1);
    dlugosc_hasla = strlen(haslo);

    while (znak != EOF)
    {
        znak ^= haslo[j % (dlugosc_hasla)];
        putc(znak, file2);
        znak = getc(file1);
        j++;
    }

    fclose(file1);
    fclose(file2);
    unlink(Argv[1]);
    rename("Tymczasowy", Argv[1]);
    return 0;
}
