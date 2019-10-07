
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
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void SingleItem()
        {
            var list = new List<int> { 1 };
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void TwoIncreasingItems()
        {
            var list = new List<int> { 1, 2 };
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void TwoDecreasingItems()
        {
            var list = new List<int> { 4, 2 };
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void TwoEqualItems()
        {
            var list = new List<int> { 1, 1 };
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ThreeIncreasingItems()
        {
            var list = new List<int> { 1, 2, 3 };
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ThreeDecreasingItems()
        {
            var list = new List<int> { 4, 2, 1 };
            var expected = 0;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void UpAndDown()
        {
            var list = new List<int> { 1, 2, 1 };
            var expected = 1;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void DownAndUp()
        {
            var list = new List<int> { 4, 2, 3 };
            var expected = 1;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ManyItems()
        {
            var list = new List<int> { 1, 2, 1, 2 };
            var expected = 2;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ManyItems2()
        {
            var list = new List<int> { 1, 2, 1, 2, 1 };
            var expected = 3;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ManyItems3()
        {
            var list = new List<int> { 1, 2, 3, 2, 1};
            var expected = 1;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ManyItems4()
        {
            var list = new List<int> { 1, 2, 3, 2, 1, 2, 3 };
            var expected = 2;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ManyItems5()
        {
            var list = new List<int> { 1, 3, 4, 6, 8, 5, 1 };
            var expected = 1;

            Assert.Equal(expected, list.CountTurns());
        }

        [Fact]
        public void ManyItems6()
        {
            var list = new List<int> { 6, 4, 1, 2, 3, 5, 7, 5, 4, 2, 1, 2, 4, 5, 6, 7, 5, 1, 2, 6 };
            var expected = 5;

            Assert.Equal(expected, list.CountTurns());
        }
    }
}
