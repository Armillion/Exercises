#include <iostream>
#include <memory>

using namespace std;

class DisplayDrv
{
public:
    virtual void wykonaj() const = 0;
};

class PrintDrv
{
public:
    virtual void wykonaj() const = 0;
};

class HighResDisplayDriver : public DisplayDrv
{
public:
    void wykonaj() const override
    {
        cout << "Wyswietlam w wysokiej jakosci" << endl;
    }
};

class LowResDisplayDriver : public DisplayDrv
{
public:
    void wykonaj() const override
    {
        cout << "Wyswietlam w niskiej jakosci" << endl;
    }
};

class HighResPrintDriver : public PrintDrv
{
public:
    void wykonaj() const override
    {
        cout << "Drukuje w wysokiej jakosci" << endl;
    }
};

class LowResPrintDriver : public PrintDrv
{
public:
    void wykonaj() const override
    {
        cout << "Drukuje w niskiej jakosci" << endl;
    }
};

class ResFactory
{
public:
    virtual unique_ptr<DisplayDrv> getDispDrv() = 0;
    virtual unique_ptr<PrintDrv> getPrintDrv() = 0;
    void reset(ResFactory& a)
    {
        *this = a;
    }
};

class LowResFactory : public ResFactory
{
public:
    unique_ptr<DisplayDrv> getDispDrv() override
    {
        return unique_ptr<DisplayDrv>(new LowResDisplayDriver);
    }

    unique_ptr<PrintDrv> getPrintDrv() override
    {
        return unique_ptr<PrintDrv>(new LowResPrintDriver);
    }
};

class HighResFactory : public ResFactory
{
public:
    unique_ptr<DisplayDrv> getDispDrv() override
    {
        return unique_ptr<DisplayDrv>(new HighResDisplayDriver);
    }

    unique_ptr<PrintDrv> getPrintDrv() override
    {
        return unique_ptr<PrintDrv>(new HighResPrintDriver);
    }
};

int main() {
 unique_ptr<ResFactory> fabryka(new LowResFactory);
 unique_ptr<DisplayDrv> ddrv = fabryka->getDispDrv();
 unique_ptr<PrintDrv> pdrv = fabryka->getPrintDrv();
 ddrv->wykonaj();
 pdrv->wykonaj();

 fabryka.reset(new HighResFactory);
 ddrv = fabryka->getDispDrv();
 pdrv = fabryka->getPrintDrv();
 ddrv->wykonaj();
 pdrv->wykonaj();
}
