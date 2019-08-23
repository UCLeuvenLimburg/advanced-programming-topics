using System;
using System.Threading;

namespace Sample
{
    class Program
    {
        public const int NITERATIONS = 1_000_000;

        public static int atomic;

        public static int nonatomic;

        static void Main(string[] args)
        {
            var thread1 = new Thread(ThreadProcedure);
            var thread2 = new Thread(ThreadProcedure);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Nonatomic: {nonatomic}\nAtomic: {atomic}");
        }

        static void ThreadProcedure()
        {
            for ( var i = 0; i != NITERATIONS; ++i )
            {
                ++nonatomic;
                Interlocked.Increment(ref atomic);
            }
        }
    }
}
