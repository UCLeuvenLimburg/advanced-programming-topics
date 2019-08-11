using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Drop5FromEmpty()
        {
            IEnumerable<int> xs = new List<int> { };
            var expected = new List<int> { };
            var actual = xs.DropN(5);

            Check(actual, expected);
        }

        [Fact]
        public void Drop0()
        {
            IEnumerable<int> xs = Enumerable.Range(1, 10);
            var expected = Enumerable.Range(1, 10).ToList();
            var actual = xs.DropN(0);

            Check(actual, expected);
        }

        [Fact]
        public void Drop1()
        {
            IEnumerable<int> xs = Enumerable.Range(1, 7);
            var expected = Enumerable.Range(2, 6).ToList();
            var actual = xs.DropN(1);

            Check(actual, expected);
        }

        [Fact]
        public void Drop10()
        {
            IEnumerable<int> xs = Enumerable.Range(-20, 1000);
            var expected = Enumerable.Range(-10, 50).ToList();
            var actual = xs.DropN(10);

            Check(actual, expected);
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
