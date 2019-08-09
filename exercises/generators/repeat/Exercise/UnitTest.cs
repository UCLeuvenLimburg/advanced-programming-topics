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
        public void Repeat1()
        {
            var expected = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 };
            var actual = Util.Repeat(1);

            Check(actual, expected);
        }

        [Fact]
        public void RepeatTrue()
        {
            var expected = new List<bool> { true, true, true, true, true };
            var actual = Util.Repeat(true);

            Check(actual, expected);
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
