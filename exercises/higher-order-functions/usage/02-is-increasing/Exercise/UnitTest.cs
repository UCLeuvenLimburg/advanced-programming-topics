
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
//using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void EmptyList()
        {
            var list = new List<int> { };

            Assert.True(list.IsIncreasing());
        }

        [Fact]
        public void SingleItem()
        {
            var list = new List<int> { 1 };
            Assert.True(list.IsIncreasing());
        }

        [Fact]
        public void TwoIncreasingItems()
        {
            var list = new List<int> { 1, 2 };
            Assert.True(list.IsIncreasing());
        }

        [Fact]
        public void TwoDecreasingItems()
        {
            var list = new List<int> { 2, 1 };
            Assert.False(list.IsIncreasing());
        }

        [Fact]
        public void TwoEqualItems()
        {
            var list = new List<int> { 5, 5 };
            Assert.True(list.IsIncreasing());
        }

        [Fact]
        public void LongStrictlyIncreasing()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Assert.True(list.IsIncreasing());
        }

        [Fact]
        public void LongIncreasingWithEquals()
        {
            var list = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            Assert.True(list.IsIncreasing());
        }

        [Fact]
        public void LongNonIncreasing()
        {
            var list = new List<int> { 1, 2, 3, 4, 3, 4, 5 };
            Assert.False(list.IsIncreasing());
        }

        [Fact]
        public void LongNonIncreasing2()
        {
            var list = new List<int> { 5, 4, 3, 2, 1 };
            Assert.False(list.IsIncreasing());
        }

        [Fact]
        public void ManyEqualItems()
        {
            var list = new List<int> { 3, 3, 3, 3, 3, 3, 3, 3 };
            Assert.True(list.IsIncreasing());
        }
    }
}
