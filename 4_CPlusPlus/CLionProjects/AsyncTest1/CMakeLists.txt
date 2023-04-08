cmake_minimum_required(VERSION 3.24)
project(AsyncTest1)

set(CMAKE_CXX_STANDARD 23)

set(GTEST_DIR ~/dev/googletest/googletest)
include_directories(${GTEST_DIR}/include)
link_directories(${GTEST_DIR}/build/lib)


add_executable(AsyncTest1 main.cpp DecodeLib/Decoder.h)
