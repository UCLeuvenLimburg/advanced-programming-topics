using System;
using System.Collections.Generic;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void OnEmptyList()
        {
            Check(Integers(), x => true, Integers());
        }

        [Fact]
        public void PositiveIntegers()
        {
            Check(Integers(1, -1, 2, -2, 3, -3), x => x >= 0, Integers(1, 2, 3));
        }

        [Fact]
        public void OddIntegers()
        {
            Check(Integers(1, -1, 2, -2, 3, -3), x => x % 2 != 0, Integers(1, -1, 3, -3));
        }

        [Fact]
        public void LongStrings()
        {
            Check(Strings("", "a", "abcd", "abcde", "11111111"), x => x.Length > 3, Strings("abcd", "abcde", "11111111"));
        }

        [Fact]
        public void SelectNone()
        {
            Check(Strings("", "a", "abcd", "abcde", "11111111"), x => false, Strings());
        }

        [Fact]
        public void SelectAll()
        {
            Check(Strings("", "a", "abcd", "abcde", "11111111"), x => true, Strings("", "a", "abcd", "abcde", "11111111"));
        }

        private static void Check<T>(List<T> input, Func<T, bool> predicate, List<T> expected)
        {
            var actual = input.Filter<T>(predicate);

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
