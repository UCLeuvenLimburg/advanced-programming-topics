using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<Item>();

            var i1 = new Item { HashCode = 1 };
            var i2 = new Item { HashCode = 2 };
            var i3 = new Item { HashCode = 3 };
            var i4 = new Item { HashCode = 4 };

            set.Add(i1);
            set.Add(i2);
            set.Add(i3);
            set.Add(i4);

            i3.HashCode = 0;

            Console.WriteLine(set.Contains(i1));
            Console.WriteLine(set.Contains(i2));
            Console.WriteLine(set.Contains(i3));
            Console.WriteLine(set.Contains(i4));
        }
    }

    class Item
    {
        public int HashCode { get; set; }

        public override int GetHashCode()
        {
            return HashCode;
        }
    }
}
