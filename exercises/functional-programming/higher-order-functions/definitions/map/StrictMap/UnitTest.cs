using System;
using System.Collections.Generic;
using Xunit;

namespace StrictMap
{
    public class UnitTest
    {
        [Fact]
        public void OnEmptyList()
        {
            Check(Integers(), x => x, Integers());
        }

        [Fact]
        public void IdentityFunction()
        {
            Check(Integers(1, 2, 3), x => x, Integers(1, 2, 3));
        }

        [Fact]
        public void DoublingIntegers()
        {
            Check(Integers(1, 2, 3), x => 2 * x, Integers(2, 4, 6));
        }

        [Fact]
        public void SquaringIntegers()
        {
            Check(Integers(1, 2, 3, 4), x => x * x, Integers(1, 4, 9, 16));
        }

        [Fact]
        public void StringLengths()
        {
            Check(Strings("", "a", "xyz", "12345"), s => s.Length, Integers(0, 1, 3, 5));
        }

        private static void Check<T, R>(List<T> input, Func<T, R> f, List<R> expected)
        {
            var actual = Solution.Map<T, R>(input, f);

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
