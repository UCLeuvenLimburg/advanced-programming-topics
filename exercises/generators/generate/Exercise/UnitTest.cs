using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Tested = Exercise.Student;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void GenerateRange()
        {
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = Tested.Generate(1, i => i + 1);

            Check(actual, expected);
        }

        [Fact]
        public void GenerateOddNumbers()
        {
            var expected = new List<int> { 1, 3, 5, 7, 9, 11, 13 };
            var actual = Tested.Generate(1, i => i + 2);

            Check(actual, expected);
        }

        [Fact]
        public void GenerateAlternatingBools()
        {
            var expected = new List<bool> { true, false, true, false, true, false, true, false };
            var actual = Tested.Generate(true, b => !b);

            Check(actual, expected);
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
