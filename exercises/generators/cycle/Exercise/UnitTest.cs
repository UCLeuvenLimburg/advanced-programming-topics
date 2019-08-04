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
        public void CycleSingletonList()
        {
            IEnumerable<int> lst = new List<int> { 1 };
            var actual = lst.Cycle();
            var expected = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        [Fact]
        public void CycleListOf2()
        {
            IEnumerable<int> lst = new List<int> { 1, 2 };
            var actual = lst.Cycle();
            var expected = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
        }

        [Fact]
        public void CycleListOf3()
        {
            IEnumerable<string> lst = new List<string> { "a", "b", "c" };
            var actual = lst.Cycle();
            var expected = new List<string> { "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c" };
        }

        [Fact]
        public void CycleVeryLarge()
        {
            IEnumerable<int> lst = Enumerable.Range(0, int.MaxValue);
            var actual = lst.Cycle();
            var expected = lst.Take(100).ToList();
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
