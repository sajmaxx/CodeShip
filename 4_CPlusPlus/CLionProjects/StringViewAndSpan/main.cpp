#include <iostream>
#include <string_view>
#include <span>


void DoDaPrint(std::string_view strata)
{
    std::cout << " Testing Prints  " << strata;
}

int main() {
    //Usage and Explanation of std::string_view
    std::string_view shasha {"babba jagga no real"};
    DoDaPrint(shasha);

    //Usage of std::span
    int maharay[] = {2,3,4,5,6,7,8,23,645,44,66,44,777};
    std::span<int> spanint{maharay};

    std::cout << " Span data . First Value is  " << spanint.front() << " and last value is " << spanint.back() << std::endl;
    auto funfun  = spanint.size();
    funfun = spanint.size();

    std::span<int> subspanner = spanint.subspan(3,3);

     for(auto vala :subspanner)
    {
        std::cout << " subspanner val is " << vala << std::endl;
    }

     int funfunu = spanint[4];
     std::cout << " funfunu " << funfunu << std::endl;
    return 0;
}