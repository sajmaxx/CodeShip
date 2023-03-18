cmake_minimum_required(VERSION 3.24)
project(AsyncTester)

set(CMAKE_CXX_STANDARD 23)

add_executable(AsyncTester main.cpp DecoderLib/Decoder.h)
