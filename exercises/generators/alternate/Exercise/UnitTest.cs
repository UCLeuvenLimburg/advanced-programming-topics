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
        public void AlternateEmpty()
        {
            IEnumerable<int> xs = new List<int> { };
            IEnumerable<int> ys = new List<int> { };
            var expected = new List<int> { };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        [Fact]
        public void AlternateOneAndTwo()
        {
            IEnumerable<int> xs = new List<int> { 1 };
            IEnumerable<int> ys = new List<int> { 2 };
            var expected = new List<int> { 1, 2 };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        [Fact]
        public void AlternateOnesAndTwos()
        {
            IEnumerable<int> xs = new List<int> { 1, 1, 1 };
            IEnumerable<int> ys = new List<int> { 2, 2, 2 };
            var expected = new List<int> { 1, 2, 1, 2, 1, 2 };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        [Fact]
        public void AlternateOddsAndEvens()
        {
            IEnumerable<int> xs = new List<int> { 1, 3, 5, 7 };
            IEnumerable<int> ys = new List<int> { 2, 4, 6, 8 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        [Fact]
        public void AlternateUnequalLength1()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { };
            var expected = new List<int> {  };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        [Fact]
        public void AlternateUnequalLength2()
        {
            IEnumerable<int> xs = new List<int> { };
            IEnumerable<int> ys = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> {  };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        [Fact]
        public void AlternateUnequalLength3()
        {
            IEnumerable<int> xs = new List<int> { 1, 3, 5, 7 };
            IEnumerable<int> ys = new List<int> { 2, 4, 6 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6 };
            var actual = xs.Alternate(ys);

            Check(actual, expected);
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
