using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Any
{
    public class UnitTest
    {
        [Fact]
        public void OnEmptyList()
        {
            Check(Integers(), x => true, false);
        }

        [Fact]
        public void TruePredicateOnInfiniteList()
        {
            Check(AllIntegers, x => true, true);
        }

        [Fact]
        public void IsPositiveOnFiniteListOfPositiveIntegers()
        {
            Check(Integers(1, 5, 3, 2, 0, 6, 3), x => x >= 0, true);
        }

        [Fact]
        public void IsNegativeOnFiniteListOfPositiveIntegers()
        {
            Check(Integers(1, 5, 3, 2, 0, 6, 3), x => x < 0, false);
        }

        [Fact]
        public void IsPositiveOnFiniteListOfIntegers()
        {
            Check(Integers(1, 5, 3, 2, 0, -1, 6, 3), x => x >= 0, true);
        }

        [Fact]
        public void IsNegativeOnFiniteListOfIntegers()
        {
            Check(Integers(1, 5, 3, 2, 0, -1, 6, 3), x => x >= 0, true);
        }

        [Fact]
        public void IsEqualTo5OnInfiniteListOfIntegers()
        {
            Check(AllIntegers, x => x == 5, true);
        }

        [Fact]
        public void AnyStringsEmpty()
        {
            Check(Strings("", "", "", ""), s => s.Length == 0, true);
        }

        [Fact]
        public void NotAllStringsEmpty()
        {
            Check(Strings("q", "x4", "", "f"), s => s.Length == 0, true);
        }

        [Fact]
        public void NoStringsEmpty()
        {
            Check(Strings("q", "x4", "qko", "f"), s => s.Length == 0, false);
        }

        private static IEnumerable<int> AllIntegers
        {
            get
            {
                int i = 0;

                while (true)
                {
                    yield return i++;
                }
            }
        }

        private static void Check<T>(IEnumerable<T> input, Func<T, bool> predicate, bool expected)
        {
            var actual = Solution.Any<T>(input, predicate);

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
