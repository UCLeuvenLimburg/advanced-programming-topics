
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void EmptyList()
        {
            var list = new List<int> { };
            var expected = 1;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void SingleItem()
        {
            var list = new List<int> { 1 };
            var expected = 1;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void TwoIncreasingItems()
        {
            var list = new List<int> { 1, 2 };
            var expected = 1;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void TwoDecreasingItems()
        {
            var list = new List<int> { 5, 3 };
            var expected = 2;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void TwoEqualItems()
        {
            var list = new List<int> { 4, 4 };
            var expected = 1;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void ThreeItems()
        {
            var list = new List<int> { 1, 2, 3 };
            var expected = 1;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void ThreeItems2()
        {
            var list = new List<int> { 1, 2, 2 };
            var expected = 1;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void ThreeItems3()
        {
            var list = new List<int> { 1, 2, 1 };
            var expected = 2;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void FourItems()
        {
            var list = new List<int> { 1, 2, 1, 2 };
            var expected = 2;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void ManyItems()
        {
            var list = new List<int> { 1, 2, 1, 2, 3, 4, 5 };
            var expected = 2;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void ManyItems2()
        {
            var list = new List<int> { 1, 5, 2, 6, 3, 7 };
            var expected = 3;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }

        [Fact]
        public void ManyItems4()
        {
            var list = new List<int> { 5, 4, 3, 2, 1 };
            var expected = 5;

            Assert.Equal(expected, list.CountIncreasingSubsequences());
        }
    }
}
