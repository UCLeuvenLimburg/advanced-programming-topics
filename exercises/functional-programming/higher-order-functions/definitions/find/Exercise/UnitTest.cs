using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Tested = Exercise.Student;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void FindFirstGeq5()
        {
            Assert.Equal(5, Tested.FindFirst(Enumerable.Range(0, int.MaxValue), k => k >= 5));
        }

        [Fact]
        public void FindFirstNonemptyString()
        {
            IEnumerable<string> strings = new string[] { "", "", "ab", "" };

            Assert.Equal("ab", Tested.FindFirst(strings, s => s.Length > 0));
        }

        [Fact]
        public void FindFirstPositive()
        {
            IEnumerable<int> ns = new int[] { -1, 4, -2, 5, -4, 9, -1 };

            Assert.Equal(4, Tested.FindFirst(ns, n => n > 0));
        }

        [Fact]
        public void FindLastPositive()
        {
            IEnumerable<int> ns = new int[] { -1, 4, -2, 5, -4, 9, -1 };

            Assert.Equal(9, Tested.FindLast(ns, n => n > 0));
        }

        [Fact]
        public void FindLastOdd()
        {
            IEnumerable<int> ns = new int[] { -1, 4, -2, 5, -4, 9, -3 };

            Assert.Equal(-3, Tested.FindLast(ns, n => n % 2 != 0));
        }

        [Fact]
        public void IndexOfEven()
        {
            IEnumerable<int> ns = new int[] { -1, 4, -2, 5, -4, 9, -3 };

            Assert.Equal(1, Tested.IndexOf(ns, n => n % 2 == 0));
        }

        [Fact]
        public void IndexOfAllCaps()
        {
            IEnumerable<string> strings = new string[] { "abc", "", "QJFJKLp", "FJLKJLA", "qio" };

            Assert.Equal(3, Tested.IndexOf(strings, s => s.Length > 0 && s.ToUpper() == s));
        }

        [Fact]
        public void FindFirst_Missing()
        {
            IEnumerable<int> ns = new int[] { 1, 2, 3, 4, 5, 6 };

            Assert.Throws<InvalidOperationException>(() => Tested.FindFirst(ns, n => n < 0));
        }

        [Fact]
        public void IndexOf_Missing()
        {
            IEnumerable<int> ns = new int[] { 1, 2, 3, 4, 5, 6 };

            Assert.Throws<InvalidOperationException>(() => Tested.IndexOf(ns, n => n < 0));
        }
    }
}
