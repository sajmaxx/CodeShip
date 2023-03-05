#include <iostream>
#include <vector>
#include <bitset>
#include <iterator>
#include <algorithm>
#include <variant>
int main() {
    std::cout << "Hello, World!" << std::endl;

    std::vector<int> v1{1, 2, 3, 4, 5, 6, 7, 8 };

    int arrayo[] = {7, 88, 99, 99};

    std::vector<int> babadoo(arrayo, arrayo + 4);

    std::cout << "v1 length is " << v1.size() << std::endl;

    std::cout << "babadoo contents is " << babadoo.size() << std::endl;

    babadoo.swap(v1);

    std::cout << "v1 length is " << v1.size() << std::endl;

    std::cout << "babadoo contents size is " << babadoo.size() << " and capacity is " << babadoo.capacity() << std::endl;

    std::bitset<8> blastbit {1010101};

    std::cout << " blasta bit set stuff is " << blastbit << std::endl;


    std::bitset<4> blastbitstr {"1001"};

    std::cout << " blasta bit set stuff is " << blastbitstr << std::endl;


    //FINDING WITHIN A RANGE IN A VECTOR USING ITERATOR~!!

    std::vector<int> wildmap = {20, 1, 3, 44, 66, 76, 4, 6, 23, 365, 23, 876};
    auto ita = std::find_if(wildmap.begin(), wildmap.end(),[](int const n){ return n > 10;});
    if(ita != wildmap.end())
    {
        std::cout << *ita << std::endl;
    }

    auto searchit = std::binary_search(wildmap.begin(), wildmap.end(), 23);
    if(searchit)
    {
        std::cout << " found the 23 item at " << std::endl;
    }


    //SET OPERATIONS USING ALGORITHM
    std::vector<int> setsmall {2, 4, 5, 3};
    std::vector<int> setmed { 4, 2, 45, 6, 7, 8, 3};
    std::vector<int> unityset { 3};

    std::vector<int> vmaxx {999};

    std::set_union(setsmall.cbegin(), setsmall.cend(),
                   setmed.cbegin(), setmed.cend(), std::back_inserter(vmaxx));


    for(auto bindy = 0; bindy < vmaxx.size(); bindy++)
    {
        std::cout << "bindy value is " << vmaxx[bindy] << std::endl;
    }


    struct babaloo
    {
        int valvoline = 33;
        double malmadine = 3.14;
    };

    babaloo bab1{44, 3.444};
    std::variant<int, babaloo> canstandya = 44;

   auto daresult =  std::get<int>(canstandya);
    std::cout << " Well the variant has what now:: " << daresult << std::endl;

    canstandya = bab1;

    babaloo strucator = std::get<babaloo>(canstandya);

    std::cout << " well now we got the strucator " << strucator.malmadine << std::endl;

    return 0;

}