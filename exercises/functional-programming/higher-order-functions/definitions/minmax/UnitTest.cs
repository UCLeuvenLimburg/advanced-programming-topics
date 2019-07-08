using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using static MinMax.Solution;

namespace Count
{
    public class UnitTest
    {
        [Fact]
        public void MinimumOfComparable()
        {
            Assert.Equal(1, Minimum(Integers(4, 1, 6, 5, 3, 7, 5)));
            Assert.Equal(3, Minimum(Integers(4, 6, 5, 3, 7, 5)));
        }

        [Fact]
        public void MaximumOfComparable()
        {
            Assert.Equal(7, Maximum(Integers(4, 1, 6, 5, 3, 7, 5)));
            Assert.Equal(6, Maximum(Integers(4, 6, 1, 5, 3, 5)));
        }

        [Fact]
        public void MinimumWithLambda()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(d, Minimum(Values<Foo>(a, b, c, d), (x, y) => x.X < y.X));
            Assert.Same(a, Minimum(Values<Foo>(a, b, c, d), (x, y) => x.Y < y.Y));
            Assert.Same(b, Minimum(Values<Foo>(a, b, c, d), (x, y) => x.Z < y.Z));
        }

        [Fact]
        public void MaximumWithLambda()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(b, Maximum(Values<Foo>(a, b, c, d), (x, y) => x.X < y.X));
            Assert.Same(c, Maximum(Values<Foo>(a, b, c, d), (x, y) => x.Y < y.Y));
            Assert.Same(d, Maximum(Values<Foo>(a, b, c, d), (x, y) => x.Z < y.Z));
        }

        [Fact]
        public void MinimumWithKey()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(d, Minimum(Values<Foo>(a, b, c, d), x => x.X));
            Assert.Same(a, Minimum(Values<Foo>(a, b, c, d), x => x.Y));
            Assert.Same(b, Minimum(Values<Foo>(a, b, c, d), x => x.Z));
        }

        [Fact]
        public void MaximumWithKey()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(b, Maximum(Values<Foo>(a, b, c, d), x => x.X));
            Assert.Same(c, Maximum(Values<Foo>(a, b, c, d), x => x.Y));
            Assert.Same(d, Maximum(Values<Foo>(a, b, c, d), x => x.Z));
        }

        private static List<T> Values<T>(params T[] items)
        {
            return new List<T>(items);
        }

        private static List<int> Integers(params int[] items)
        {
            return Values<int>(items);
        }

        private static List<string> Strings(params string[] items)
        {
            return Values<string>(items);
        }
    }

    public class Foo
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }
}
