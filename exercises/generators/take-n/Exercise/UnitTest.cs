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
        public void Take5FromEmpty()
        {
            IEnumerable<int> xs = new List<int> { };
            var expected = new List<int> { };
            var actual = xs.TakeN(5);

            Check(actual, expected);
        }

        [Fact]
        public void Take0()
        {
            IEnumerable<int> xs = Enumerable.Range(1, 10);
            var expected = Enumerable.Empty<int>().ToList();
            var actual = xs.TakeN(0);

            Check(actual, expected);
        }

        [Fact]
        public void Take1()
        {
            IEnumerable<int> xs = Enumerable.Range(1, 7);
            var expected = new List<int> { 1 };
            var actual = xs.TakeN(1);

            Check(actual, expected);
        }

        [Fact]
        public void Take10()
        {
            IEnumerable<int> xs = Enumerable.Range(-20, 1000);
            var expected = Enumerable.Range(-20, 10).ToList();
            var actual = xs.TakeN(10);

            Check(actual, expected);
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
