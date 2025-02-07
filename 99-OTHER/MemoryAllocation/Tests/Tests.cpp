#include <iostream>
#include <ostream>

struct A
{
    int a;
    bool b;
    bool c;
    bool d;
};
int main(int argc, char* argv[])
{
    std::cout << sizeof(A) << std::endl;
    return 0;
}
