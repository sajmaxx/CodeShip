cmake_minimum_required(VERSION 3.23)
project(Qt6Try1)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_AUTOUIC ON)


find_package(Qt6 COMPONENTS
        Core
        REQUIRED)

add_executable(Qt6Try1 main.cpp)
target_link_libraries(Qt6Try1
        Qt::Core
        )

