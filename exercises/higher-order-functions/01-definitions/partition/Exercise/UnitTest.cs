using System;
using System.Collections.Generic;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void PartitionEvenAndOdd()
        {
            IEnumerable<int> ns = new int[] { 3, 6, 4, 1, 0, 9, 5 };
            var expectedLeft = new int[] { 6, 4, 0 };
            var expectedRight = new int[] { 3, 1, 9, 5 };
            var actual = ns.Partition(x => x % 2 == 0);
            var actualLeft = actual.Item1;
            var actualRight = actual.Item2;

            Assert.Equal(expectedLeft, actualLeft);
            Assert.Equal(expectedRight, actualRight);
        }

        [Fact]
        public void PartitionPositiveAndNegative()
        {
            IEnumerable<int> ns = new int[] { 1, -2, 3, 4, -5 };
            var expectedLeft = new int[] { 1, 3, 4 };
            var expectedRight = new int[] { -2, -5 };
            var actual = ns.Partition(x => x >= 0);
            var actualLeft = actual.Item1;
            var actualRight = actual.Item2;

            Assert.Equal(expectedLeft, actualLeft);
            Assert.Equal(expectedRight, actualRight);
        }

        [Fact]
        public void PartitionFourLong()
        {
            IEnumerable<string> strings = new string[] { "123", "abcd", "xyz", "ppppp", "4567" };
            var expectedLeft = new string[] { "abcd", "4567" };
            var expectedRight = new string[] { "123", "xyz", "ppppp"};
            var actual = strings.Partition(s => s.Length == 4);
            var actualLeft = actual.Item1;
            var actualRight = actual.Item2;

            Assert.Equal(expectedLeft, actualLeft);
            Assert.Equal(expectedRight, actualRight);
        }
    }
}
