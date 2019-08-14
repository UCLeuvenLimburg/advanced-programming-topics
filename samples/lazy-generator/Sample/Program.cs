using System;
using System.Collections.Generic;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var xs = Bar();
            Console.WriteLine("Looping");
            foreach (var x in xs)
            {
                Console.WriteLine(x);
            }
        }

        static IEnumerable<int> Bar()
        {
            Console.WriteLine("A");
            yield return 1;
            Console.WriteLine("B");
            yield return 2;
            Console.WriteLine("C");
            yield return 3;
            Console.WriteLine("D");
        }
    }
}
