cmake_minimum_required(VERSION 3.11.3)

set(CMAKE_CXX_STANDARD 17)


project(Membot)

find_package(wxWidgets REQUIRED COMPONENTS core base)
include(${wxWidgets_USE_FILE})

file(GLOB project_SRCS src/*.cpp)

add_executable(membot ${project_SRCS})

set(wxWidgets_LIBRARIES "C:/wxWidgets-3.1.5/lib/vc142_x64_dll")
set(wxWidgets_INCLUDE_DIRS "C:/wxWidgets-3.1.5/include")

target_link_libraries(membot ${wxWidgets_LIBRARIES})
target_include_directories(membot PRIVATE ${wxWidgets_INCLUDE_DIRS})
