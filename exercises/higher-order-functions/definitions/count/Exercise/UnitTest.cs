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
        public void OnEmptyList()
        {
            Check(Integers(), x => true, 0);
        }

        [Fact]
        public void CountPositiveIntegers()
        {
            Check(Integers(2, -5, 3, 1, -2), x => x >= 0, 3);
        }

        [Fact]
        public void CountOddIntegers()
        {
            Check(Integers(2, -5, 3, 1, -2, 8, 4), x => x % 2 != 0, 3);
        }

        [Fact]
        public void CountEmptyStrings()
        {
            Check(Strings("", "x", "6q", ""), s => s.Length == 0, 2);
        }

        private static void Check<T>(IEnumerable<T> input, Func<T, bool> predicate, int expected)
        {
            var actual = Tested.Count<T>(input, predicate);

            Assert.Equal(expected, actual);
        }

        private static List<T> Values<T>(params T[] items)
        {
            return new List<T>(items);
        }

        private static List<int> Integers(params int[] items)
        {
            return Values<int>(items);
        }

        private static List<string> Strings(params string[] items)
        {
            return Values<string>(items);
        }
    }
}
