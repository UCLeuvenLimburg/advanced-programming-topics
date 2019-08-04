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
        public void CycleSingletonList()
        {
            IEnumerable<int> lst = new List<int> { 1 };
            var actual = Tested.Cycle(lst);
            var expected = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        [Fact]
        public void CycleListOf2()
        {
            IEnumerable<int> lst = new List<int> { 1, 2 };
            var actual = Tested.Cycle(lst);
            var expected = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
        }

        [Fact]
        public void CycleListOf3()
        {
            IEnumerable<string> lst = new List<string> { "a", "b", "c" };
            var actual = Tested.Cycle(lst);
            var expected = new List<string> { "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c" };
        }

        [Fact]
        public void CycleVeryLarge()
        {
            IEnumerable<int> lst = Enumerable.Range(0, int.MaxValue);
            var actual = Tested.Cycle(lst);
            var expected = lst.Take(100).ToList();
        }

        private void Check<T>(IEnumerable<T> actual, IList<T> expected)
        {
            var actualList = actual.Take(expected.Count).ToList();

            Assert.Equal(expected, actualList);
        }
    }
}
