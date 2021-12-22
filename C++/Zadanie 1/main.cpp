#include <iostream>
#include <string>
#include <cmath>

using namespace std;

class Konwerter
{
private:
    size_t rozmiar;
public:
    Konwerter() : rozmiar(0) {}
    ~Konwerter() {}

    void operator=(const char& a)
    {
        rozmiar = a;
    }

    void operator=(char* a)
    {
        int i = 0;
        rozmiar = 0;
        while(a[i] != '\0')
        {
            rozmiar += a[i];
            i++;
        }
    }

    void operator=(const string& a)
    {
        rozmiar = 0;
        for(int i = 0; i < a.length(); i++)
        {
            rozmiar += a[i];
        }
    }

    friend ostream& operator<<(ostream& stream,const Konwerter& a)
    {
        return stream << a.rozmiar;
    }

    friend istream& operator>>(istream& stream,Konwerter& a)
    {
        string b;
        int czy_liczba = 0;
        stream >> b;
        a.rozmiar = 0;
        for(int i = 0; i < b.length(); i++)
        {
            if(isdigit(b[i]))
            {
                czy_liczba++;
            }
            a.rozmiar += b[i];
        }
        if(czy_liczba == b.length())
        {
            a.rozmiar = stoi(b.c_str());
        }
        return stream;
    }
};

int main()
{
    Konwerter konw;
    konw = 'a';
    cout << konw << endl;
    konw = (string)"abc";
    cout << konw << endl;
    konw = (char*)"abc";
    cout << konw << endl;
    cin >> konw;
    cout << konw << endl;
    return 0;
}
