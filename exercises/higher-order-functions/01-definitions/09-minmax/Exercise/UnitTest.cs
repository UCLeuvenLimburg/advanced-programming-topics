using System;
using System.Collections.Generic;
using Xunit;
// using Exercise.Solution;

namespace Count
{
    public class UnitTest
    {
        [Fact]
        public void MinimumOfIntegers()
        {
            IEnumerable<int> ns = new int[] { 4, 1, 6, 5, 3, 7, 5 };
            var expected = 1;
            var actual = ns.Minimum();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaximumOfIntegers()
        {
            IEnumerable<int> ns = new int[] { 4, 1, 6, 5, 3, 7, 5 };
            var expected = 7;
            var actual = ns.Maximum();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinimumWithLambda()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(d, new Foo[] { a, b, c, d }.Minimum((x, y) => x.X < y.X));
            Assert.Same(a, new Foo[] { b, c, a, d }.Minimum((x, y) => x.Y < y.Y));
            Assert.Same(b, new Foo[] { d, a, c, b }.Minimum((x, y) => x.Z < y.Z));
        }

        [Fact]
        public void MaximumWithLambda()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(b, new Foo[] { a, c, b, d }.Maximum((x, y) => x.X < y.X));
            Assert.Same(c, new Foo[] { d, c, a, b }.Maximum((x, y) => x.Y < y.Y));
            Assert.Same(d, new Foo[] { a, b, c, d }.Maximum((x, y) => x.Z < y.Z));
        }

        [Fact]
        public void MinimumWithKey()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(d, new Foo [] { a, b, c, d }.Minimum(x => x.X));
            Assert.Same(a, new Foo [] { a, b, c, d }.Minimum(x => x.Y));
            Assert.Same(b, new Foo [] { a, b, c, d }.Minimum(x => x.Z));
        }

        [Fact]
        public void MaximumWithKey()
        {
            var a = new Foo() { X = 4, Y = 1, Z = 3 };
            var b = new Foo() { X = 8, Y = 2, Z = 1 };
            var c = new Foo() { X = 5, Y = 5, Z = 2 };
            var d = new Foo() { X = 2, Y = 4, Z = 9 };

            Assert.Same(b, new Foo[] { a, b, c, d }.Maximum(x => x.X));
            Assert.Same(c, new Foo[] { a, b, c, d }.Maximum(x => x.Y));
            Assert.Same(d, new Foo[] { a, b, c, d }.Maximum(x => x.Z));
        }
    }

    public class Foo
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }
}
