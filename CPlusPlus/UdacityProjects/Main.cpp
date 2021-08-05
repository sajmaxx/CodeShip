
#include <iostream>
#include <vector>
#include <string>

using std::vector;
using std::iostream;
using std::string;

 enum SquareState  {ssEmpty, ssOccupied};

string StateToStringer(SquareState value)
{
    if (value == ssEmpty)
     return " Empty ";
    if (value == ssOccupied)
        return " Occupied ";

        return "";
}


int main()
{
    vector<vector<int>> map = {{0,0,1,0,0,0}, {0,0,1,0,0,0}};
    
 
    std::cout << " value in map[0][2] is " << map[0][2]; 
    for (vector<int> row : map)
    {
        for (auto val : row)
        { 
           string curretTarget;
           curretTarget =  StateToStringer(SquareState(val));  
           std::cout << curretTarget;     
        }
        std::cout << "\n";
    }
    return 0;
}