//
// Created by simonm on 3/18/23.
//

#ifndef ASYNCTEST1_DECODER_H
#define ASYNCTEST1_DECODER_H

#include <iostream>
#include <vector>
//make a class that does decoding

struct vector3d
{
    int x;
    int y;
    int z;
    void print()
    {
        std::cout << "Vector Components are:: x: " << x << " y: " << y << " z: " << z << std::endl;
    }
};



class Decoder
{
public:
    Decoder() {}
    ~Decoder() {}

    vector3d decode(int i, int j, int k)
    {

        std::cout << "Decoding" << std::endl;
        //add vector3d
        m_decoded.push_back(vector3d{i, j, k});
        return vector3d{i, j, k};
    }

    int count()
    {
        return m_decoded.size();
    }

private:
    //vector of vector3d
    std::vector<vector3d> m_decoded;
};
#endif //ASYNCTEST1_DECODER_H
