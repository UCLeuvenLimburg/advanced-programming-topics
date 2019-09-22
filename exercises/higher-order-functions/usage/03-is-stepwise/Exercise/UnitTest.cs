
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void EmptyList()
        {
            var list = new List<int> { };

            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void SingleItem()
        {
            var list = new List<int> { 1 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void TwoStepwiseIncreasingItems()
        {
            var list = new List<int> { 1, 2 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void TwoNonstepwiseIncreasingItems()
        {
            var list = new List<int> { 1, 3 };
            Assert.False(list.IsStepwise());
        }

        [Fact]
        public void TwoStepwiseDecreasingItems()
        {
            var list = new List<int> { 2, 1 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void TwoNonstepwiseDecreasingItems()
        {
            var list = new List<int> { 2, 0 };
            Assert.False(list.IsStepwise());
        }

        [Fact]
        public void TwoEqualItems()
        {
            var list = new List<int> { 5, 5 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void LongStepwiseIncreasing()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void LongStepwiseDecreasing()
        {
            var list = new List<int> { 6, 5, 4, 3, 2, 1 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void LongStepwiseUpAndDown()
        {
            var list = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2 };
            Assert.True(list.IsStepwise());
        }

        [Fact]
        public void LongNonStepwise()
        {
            var list = new List<int> { 1, 2, 3, 3, 5, 6 };
            Assert.False(list.IsStepwise());
        }
    }
}
