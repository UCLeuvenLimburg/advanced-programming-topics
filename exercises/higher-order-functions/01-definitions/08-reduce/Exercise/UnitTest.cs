using System;
using System.Collections.Generic;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Summation1()
        {
            IEnumerable<int> ns = new int[] { };
            var expected = 0;
            var actual = ns.Reduce(0, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Summation2()
        {
            IEnumerable<int> ns = new int[] { 1 };
            var expected = 1;
            var actual = ns.Reduce(0, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Summation3()
        {
            IEnumerable<int> ns = new int[] { 2 };
            var expected = 2;
            var actual = ns.Reduce(0, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Summation4()
        {
            IEnumerable<int> ns = new int[] { 1, 2 };
            var expected = 3;
            var actual = ns.Reduce(0, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Summation5()
        {
            IEnumerable<int> ns = new int[] { 1, 2, 3 };
            var expected = 6;
            var actual = ns.Reduce(0, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Summation6()
        {
            IEnumerable<int> ns = new int[] { 1, 1, 1 };
            var expected = 3;
            var actual = ns.Reduce(0, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Summation7()
        {
            IEnumerable<int> ns = new int[] { 1, 1, 1 };
            var expected = 8;
            var actual = ns.Reduce(5, (x, y) => x + y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product()
        {
            IEnumerable<int> ns = new int[] { };
            var expected = 1;
            var actual = ns.Reduce(1, (x, y) => x * y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product2()
        {
            IEnumerable<int> ns = new int[] { 1 };
            var expected = 1;
            var actual = ns.Reduce(1, (x, y) => x * y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product3()
        {
            IEnumerable<int> ns = new int[] { 2 };
            var expected = 2;
            var actual = ns.Reduce(1, (x, y) => x * y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product4()
        {
            IEnumerable<int> ns = new int[] { 2, 3 };
            var expected = 6;
            var actual = ns.Reduce(1, (x, y) => x * y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product5()
        {
            IEnumerable<int> ns = new int[] { 1, 2, 3, 4, 5 };
            var expected = 1 * 2 * 3 * 4 * 5;
            var actual = ns.Reduce(1, (x, y) => x * y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtraction()
        {
            IEnumerable<int> ns = new int[] { 1, 2 };
            var expected = -3;
            var actual = ns.Reduce(0, (x, acc) => acc - x);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtraction2()
        {
            IEnumerable<int> ns = new int[] { 1, 2, 3 };
            var expected = -6;
            var actual = ns.Reduce(0, (x, acc) => acc - x);

            Assert.Equal(expected, actual);
        }

         [Fact]
        public void Subtraction3()
        {
            IEnumerable<int> ns = new int[] { 1, 2, 3 };
            var expected = 0;
            var actual = ns.Reduce(6, (x, acc) => acc - x);

            Assert.Equal(expected, actual);
        }
    }
}
