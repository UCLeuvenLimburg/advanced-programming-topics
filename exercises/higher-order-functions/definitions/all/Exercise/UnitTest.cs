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
            Check(Integers(), x => true, true);
        }

        [Fact]
        public void FalsePredicateOnInfiniteList()
        {
            Check(AllIntegers, x => false, false);
        }

        [Fact]
        public void IsPositiveOnFiniteListOfPositiveIntegers()
        {
            Check(Integers(1, 5, 3, 2, 0, 6, 3), x => x >= 0, true);
        }

        [Fact]
        public void IsPositiveOnFiniteListOfIntegers()
        {
            Check(Integers(1, 5, 3, 2, 0, -1, 6, 3), x => x >= 0, false);
        }

        [Fact]
        public void IsNegativeOnInfiniteListOfIntegers()
        {
            Check(AllIntegers, x => x < 0, false);
        }

        [Fact]
        public void AllStringsEmpty()
        {
            Check(Strings("", "", "", ""), s => s.Length == 0, true);
        }

        [Fact]
        public void NotAllStringsEmpty()
        {
            Check(Strings("", "x", "", ""), s => s.Length == 0, false);
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
            var actual = Tested.All<T>(input, predicate);

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
