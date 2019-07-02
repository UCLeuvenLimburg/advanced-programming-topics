using System;
using System.Diagnostics;
using System.Linq;

namespace Count
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 200000;

            Benchmark("Sequential counting, sequential prime checking", () => CountPrimes(n, false, false));
            Benchmark("Sequential counting, parallel prime checking", () => CountPrimes(n, false, true));
            Benchmark("Parallel counting, sequential prime checking", () => CountPrimes(n, true, false));
            Benchmark("Parallel counting, parallel prime checking", () => CountPrimes(n, true, true));
        }

        private static void Benchmark(string label, Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine($"{label}: {stopwatch.Elapsed.TotalSeconds}s");
        }

        private static int CountPrimes(int max, bool countParallel, bool checkPrimeParallel)
        {
            if ( countParallel )
            {
                return Enumerable.Range(1, max).AsParallel().Count(n => IsPrime(n, checkPrimeParallel));
            }
            else
            {
                return Enumerable.Range(1, max).Count(n => IsPrime(n, checkPrimeParallel));
            }
        }

        private static bool IsPrime(int n, bool parallel)
        {
            if ( n < 2 ) return false;

            if ( parallel )
            {
                return Enumerable.Range(2, n - 2).AsParallel().All( k => n % k != 0 );
            }
            else
            {
                return Enumerable.Range(2, n - 2).All( k => n % k != 0 );
            }
        }
    }
}
