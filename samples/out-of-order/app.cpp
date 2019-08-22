#include <iostream>
#include <atomic>
#include <thread>

int x, y, a, b;
std::atomic<int> k;
int count, total;

int main()
{
    count = total = 0;

    for ( int i = 0; i != 10000; ++i )
    {
        x = y = a = b = 0;
        k = 0;

        std::thread t1([](){
            k++;

            while ( k < 2 );

            x = 1;
            a = y;
        });

        std::thread t2([](){
            k++;

            while ( k < 2 );

            y = 1;
            b = x;
        });

        t1.join();
        t2.join();

        ++total;

        if ( a == 0 && b == 0 )
        {
            ++count;
        }

        std::cout << count << " out of " << total << std::endl;
    }
}