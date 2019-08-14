using System;
using System.Collections.Generic;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach ( var x in InfiniteRange() )
            {
                Console.WriteLine(x);
            }
        }

        static IEnumerable<sbyte> InfiniteRange()
        {
            sbyte k = 0;

            while ( true )
            {
                yield return k;
                k++;
            }
        }
    }
}
