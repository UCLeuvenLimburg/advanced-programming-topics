using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Unique1()
        {
            IEnumerable<int> xs = new List<int> { };
            var expected = new List<int> { };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        [Fact]
        public void Unique2()
        {
            IEnumerable<int> xs = new List<int> { 1 };
            var expected = new List<int> { 1 };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        [Fact]
        public void Unique3()
        {
            IEnumerable<int> xs = new List<int> { 1, 1 };
            var expected = new List<int> { 1 };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        [Fact]
        public void Unique4()
        {
            IEnumerable<int> xs = new List<int> { 1, 2 };
            var expected = new List<int> { 1, 2 };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        [Fact]
        public void Unique5()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 1 };
            var expected = new List<int> { 1, 2 };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        [Fact]
        public void Unique6()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        [Fact]
        public void Unique7()
        {
            IEnumerable<int> xs = new List<int> { 1, 1, 2, 2, 3, 4, 4, 4, 5, 1, 2, 3, 4, 5 };
            var expected = new List<int> { 1, 2, 3, 4, 5 };
            var actual = xs.Unique();

            Check(actual, expected);
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
