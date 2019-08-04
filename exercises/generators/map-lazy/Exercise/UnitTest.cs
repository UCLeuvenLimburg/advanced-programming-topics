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
            Check(Integers(), x => x, Integers());
        }

        [Fact]
        public void IdentityFunctionOnFiniteList()
        {
            Check(Integers(1, 2, 3), x => x, Integers(1, 2, 3));
        }

        [Fact]
        public void IdentityFunctionOnInfiniteList()
        {
            CheckInfinite(AllIntegers, x => x, Integers(0, 1, 2, 3, 4, 5, 6));
        }

        [Fact]
        public void DoublingIntegers()
        {
            CheckInfinite(AllIntegers, x => 2 * x, Integers(0, 2, 4, 6, 8, 10));
        }

        [Fact]
        public void SquaringIntegers()
        {
            CheckInfinite(AllIntegers, x => x * x, Integers(0, 1, 4, 9, 16));
        }

        [Fact]
        public void StringLengths()
        {
            Check(Strings("", "a", "xyz", "12345"), s => s.Length, Integers(0, 1, 3, 5));
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

        private static void Check<T, R>(IEnumerable<T> input, Func<T, R> f, IEnumerable<R> expected)
        {
            var actual = Tested.Map<T, R>(input, f);

            Assert.Equal(expected, actual);
        }

        private static void CheckInfinite<T, R>(IEnumerable<T> input, Func<T, R> f, List<R> expected)
        {
            var actual = Tested.Map<T, R>(input, f).Take(expected.Count);

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
