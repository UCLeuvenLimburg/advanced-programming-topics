using System;
using System.Collections.Generic;
using Xunit;
using Tested = Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void GroupByLastDigit()
        {
            IEnumerable<int> ns = new int[] { 1, 52, 751, 652, 15, 95, 81 };
            var expected = new Dictionary<int, List<int>> {
                { 1, new List<int> { 1, 751, 81 } },
                { 2, new List<int> { 52, 652 } },
                { 5, new List<int> { 15, 95 } }
            };
            var actual = Tested.Group(ns, n => n % 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GroupByLength()
        {
            IEnumerable<string> strings = new string[] { "a", "bb", "x", "abc", "pp", "" };
            var expected = new Dictionary<int, List<string>> {
                { 0, new List<string> { "" } },
                { 1, new List<string> { "a", "x" } },
                { 2, new List<string> { "bb", "pp" } },
                { 3, new List<string> { "abc" } }
            };
            var actual = Tested.Group(strings, s => s.Length);

            Assert.Equal(expected, actual);
        }
    }
}
