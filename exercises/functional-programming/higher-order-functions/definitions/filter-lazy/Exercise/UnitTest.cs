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
            Check(Integers(), x => true, Integers());
        }

        [Fact]
        public void OnFiniteList()
        {
            Check(Integers(1, 2, 3, 4, 5), x => x > 2, Integers(3, 4, 5));
        }

        [Fact]
        public void TrueOnInfiniteList()
        {
            CheckInfinite(AllIntegers, x => true, Integers(0, 1, 2, 3, 4, 5, 6));
        }

        [Fact]
        public void AllOddIntegers()
        {
            CheckInfinite(AllIntegers, x => x % 2 != 0, Integers(1, 3, 5, 7, 9, 11, 13, 15));
        }

        [Fact]
        public void AllEvenIntegers()
        {
            CheckInfinite(AllIntegers, x => x % 2 == 0, Integers(0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20));
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

        private static void Check<T>(IEnumerable<T> input, Func<T, bool> predicate, IEnumerable<T> expected)
        {
            var actual = Tested.Filter<T>(input, predicate);

            Assert.Equal(expected, actual);
        }

        private static void CheckInfinite<T>(IEnumerable<T> input, Func<T, bool> predicate, List<T> expected)
        {
            var actual = Tested.Filter<T>(input, predicate).Take(expected.Count);

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
