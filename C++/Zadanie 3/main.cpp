#include <iostream>
#include <list>

using namespace std;

enum Wyksztalcenie {Podstawowe,Srednie,Licencjat,Magister,Doktor};
enum Wydzial {FAIS, MiI, Chemia};

class TOsoba
{
private:
    string imie;
    string nazwisko;
public:
    TOsoba(const string& a,const string& b) : imie(a),nazwisko(b) {};
    TOsoba() : imie("Jan"),nazwisko("Kowalski") {};
    ~TOsoba() {};

    void NazywamSie() const
    {
        cout << "Nazywam sie " << imie << " " << nazwisko << endl;
    }
};

class MozeBycStudentem
{
protected:
    list<string> Kursy;
    Wydzial EWydzial;
    Wyksztalcenie EWyksztalcenie;
public:
    MozeBycStudentem(Wydzial a,Wyksztalcenie b) : EWydzial(a),EWyksztalcenie(b) {};
    MozeBycStudentem() : EWydzial(FAIS),EWyksztalcenie(Srednie) {};
    ~MozeBycStudentem() {};
    virtual void DodajKurs(const string& a) = 0;
    virtual void UsunZKursu(const string& a) = 0;
    virtual void PokazKursy() = 0;
    virtual Wyksztalcenie GetWyksztalcenie() const = 0;
    virtual Wydzial GetWydzial() const = 0;
};

class MozeNauczac
{
protected:
    list<string> Przedmioty;
public:
    MozeNauczac() {};
    ~MozeNauczac() {};
    virtual void DodajPrzedmiot(const string& a) = 0;
    virtual void UsunPrzedniot(const string& a) = 0;
    virtual void PokazPrzedmioty() const = 0;
};

class MozeWykBadania
{
protected:
    string NazwaBadania;
public:
    MozeWykBadania(const string& a) : NazwaBadania(a) {};
    MozeWykBadania() : NazwaBadania("") {};
    virtual string GetNazwaBadania() const = 0;
};

class TStudent : virtual public TOsoba, public MozeBycStudentem
{
public:
    TStudent(const string& a, const string& b, const Wydzial& c, const Wyksztalcenie& d)
            : TOsoba(a,b),MozeBycStudentem(c,d) {};
    TStudent() : TOsoba(),MozeBycStudentem() {};
    ~TStudent() {};
    void DodajKurs(const string& a) override
    {
        Kursy.push_back(a);
    }
    void UsunZKursu(const string& a) override
    {
        for(auto i : Kursy)
        {
            if(i == a)
            {
                Kursy.remove(i);
            }
        }
    }
    void PokazKursy() override
    {
        for(auto i : Kursy)
        {
            cout << i << endl;
        }
    }
    Wyksztalcenie GetWyksztalcenie() const override
    {
        return EWyksztalcenie;
    }
    Wydzial GetWydzial() const override
    {
        return EWydzial;
    }
};

class AsystentBadan : virtual public TOsoba, public MozeWykBadania
{
public:
    AsystentBadan(const string& a,const string& b, const string& c)
                    : TOsoba(a,b), MozeWykBadania(c) {};
    AsystentBadan() : TOsoba(),MozeWykBadania() {};
    ~AsystentBadan() {};
    string GetNazwaBadania() const override
    {
        return NazwaBadania;
    }

};

class Nauczyciel :virtual public TOsoba, public MozeNauczac
{
public:
    Nauczyciel(const string& a,const string& b) : TOsoba(a,b),MozeNauczac() {};
    Nauczyciel() : TOsoba(),MozeNauczac() {};
    ~Nauczyciel() {};
    void DodajPrzedmiot(const string& a) override
    {
        Przedmioty.push_back(a);
    }
    void UsunPrzedniot(const string& a) override
    {
        for(auto i : Przedmioty)
        {
            if(i == a)
            {
                Przedmioty.remove(i);
            }
        }
    }
    void PokazPrzedmioty() const override
    {
        for(auto i : Przedmioty)
        {
            cout << i << endl;
        }
    }
};

class Doktorant : public TStudent
{
public:
    Doktorant(const string& a, const string& b, const Wydzial& c, const Wyksztalcenie& d):
        TStudent(a,b,c,d) {};
    Doktorant() : TStudent() {};
    ~Doktorant() {};

};

class DoktorantBadacz : public Doktorant, public AsystentBadan
{
public:
    DoktorantBadacz(const string& a, const string& b, const Wydzial& c, const Wyksztalcenie& d,const string& e)
                        : Doktorant(a,b,c,d), AsystentBadan(a,b,e) {};
    DoktorantBadacz() : Doktorant(),AsystentBadan() {};
    ~DoktorantBadacz() {};

};

class DoktorantNaucz : public Doktorant, public Nauczyciel
{
public:
    DoktorantNaucz(const string& a, const string& b, const Wydzial& c, const Wyksztalcenie& d) :
                    Doktorant(a,b,c,d), Nauczyciel(a,b) {};
    DoktorantNaucz() : Doktorant(),Nauczyciel() {};
    ~DoktorantNaucz() {};
};

int main()
{
    DoktorantBadacz dokBad1("Michal","Watroba",FAIS,Doktor,"Teoria Gier");
    DoktorantNaucz dokNaucz1("Andrzej","Zbedny",MiI,Doktor);
    dokBad1.TOsoba::NazywamSie();
    cout << dokBad1.GetNazwaBadania() << endl << dokBad1.GetWydzial() << endl << dokBad1.GetWyksztalcenie() << endl;
    dokBad1.DodajKurs("Mechanika kwantowa");
    dokBad1.DodajKurs("Fizyka Jadrowa");
    cout << "Ucze sie: " << endl;
    dokBad1.PokazKursy();
    dokNaucz1.NazywamSie();
    cout << dokNaucz1.GetWydzial() << endl << dokNaucz1.GetWyksztalcenie() << endl;
    dokNaucz1.DodajKurs("Mechanika Jadrowa");
    dokNaucz1.DodajKurs("Fizyka Kwantowa");
    cout << "Ucze sie: " << endl;
    dokNaucz1.PokazKursy();
    dokNaucz1.DodajPrzedmiot("Analiza Matematyczna");
    dokNaucz1.DodajPrzedmiot("Logika i teoria mnogosci");
    cout << "Nauczam: " << endl;
    dokNaucz1.PokazPrzedmioty();
    return 0;
}
