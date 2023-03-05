#include <iostream>
#include <tuple>


enum class TowerType
{
    normal,
    tall,
    supertall
};
struct Tower
{
    Tower()
    {
        std::cout << " Tower " << "\n";
    }

    Tower(const int aba)
    {
        std::cout << " Tower aba is " << aba << "\n";
    }

    Tower(std::initializer_list<int> lisd)
    {
        std::cout << " We are going int std::initializer_list<> mode of constructore!!" << std::endl;
        //std::cout << lisd << std::endl;
    }

    const int DefHeight = 1000;
    const int DefWidth = 500;
    TowerType typeIs = TowerType::normal;
};

std::tuple<int, bool, double> find()
{
    return std::make_tuple(1, false, 777.77);
};

enum class CarTye : unsigned int
{
    Fiat,
    Ferrari,
    AlfaRomeo,
    Lambhorgini
};


enum struct AeroplaneType : short
{
    SingleEngineProp,
    DualEngineProp,
    TurboJet,
    Jet,
    TwinJet
};


int main() {

    std::tuple<int, bool, double> theCode{1, true, 777.77};

    //theCode.insert({1, false, 177.77});
    //auto latestval = theCode.insert({1, false, 777.77});

    std::cout << "Latest tuple value is " << get<0>(theCode) << " " << get<2>(theCode)  << " fin " << std::endl;

    auto wawa = find();

    std::cout << "Hello, World!" << std::endl;

    Tower t1;
    Tower t2{};
    Tower t3(33);
    Tower t4 = 44;
    //t4 = t3;
    Tower t5{55};
    Tower t7{55,77,88};

    return 0;
}

