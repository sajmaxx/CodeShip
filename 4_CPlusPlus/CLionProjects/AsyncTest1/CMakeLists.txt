cmake_minimum_required(VERSION 3.24)
project(AsyncTest1)

set(CMAKE_CXX_STANDARD 23)

add_executable(AsyncTest1 main.cpp DecodeLib/Decoder.h)
