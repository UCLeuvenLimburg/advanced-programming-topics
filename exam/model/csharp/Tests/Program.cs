using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public static class Solutions
    {
        public static int CountOdd(IEnumerable<int> ns)
        {
            // return ns.Count(n => n % 2 != 0);
            return (from n in ns
                    where n % 2 != 0
                    select n).Count();
        }
    }

    abstract class Tests
    {
        private StreamReader reader;

        public string Read()
        {
            string line;

            while ( (line = reader.ReadLine()).StartsWith("#") );

            return line.TrimEnd();
        }

        public int ReadInt()
        {
            return int.Parse(Read());
        }

        private string FindFile(string filename)
        {
            try
            {
                var directory = Directory.GetCurrentDirectory();

                while (!File.Exists(Path.Combine(directory, filename)))
                {
                    directory = Directory.GetParent(directory).FullName;
                }

                return Path.Combine(directory, filename);
            }
            catch ( Exception e )
            {
                Console.WriteLine($"Error while looking for file {filename}");
                throw e;
            }
        }

        private StreamReader OpenTestFile()
        {
            return File.OpenText(FindFile(this.FileName));
        }

        public void RunTests()
        {
            Console.WriteLine($"Running tests for {Description}");
            using (var reader = OpenTestFile())
            {
                this.reader = reader;
                string line = Read();

                while (line == "testcase")
                {
                    PerformTest();
                    line = Read();
                }
            }
        }

        public bool ReadBool()
        {
            return Read() == "true";
        }

        public IList<string> ReadStrings()
        {
            var n = ReadInt();

            return Enumerable.Range(0, n).Select(_ => Read()).ToList();
        }

        public string ShowList<T>(IEnumerable<T> xs)
        {
            return "[" + string.Join(", ", xs.Select(x => x.ToString())) + "]";
        }

        public abstract string Description { get; }

        public abstract string FileName { get; }

        public abstract void PerformTest();
    }

    class CountOddTests : Tests
    {
        public override string Description => "CountOdd";

        public override string FileName => "count-odd.txt";

        public override void PerformTest()
        {
            var ns = ReadStrings().Select(int.Parse);
            var expected = ReadInt();
            var actual = Solutions.CountOdd(ns);

            if (  actual == expected )
            {
                Console.WriteLine("PASS");
            }
            else
            {
                Console.WriteLine("FAIL");
                Console.WriteLine($"ns = {ShowList(ns)}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Actual: {actual}");
            }
        }
    }

    class App
    {
        static void Main(string[] args)
        {
            new CountOddTests().RunTests();
        }
    }
}
