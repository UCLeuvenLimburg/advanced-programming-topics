
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
        public void Empty()
        {
            var input = new List<int> { };
            var expected = new List<int> { };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Single()
        {
            var input = new List<int> { 1 };
            var expected = new List<int> { };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoElements()
        {
            var input = new List<int> { 1, 2 };
            var expected = new List<int> { 1 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoElements2()
        {
            var input = new List<int> { 1, 1 };
            var expected = new List<int> { 0 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoElements3()
        {
            var input = new List<int> { 2, 1 };
            var expected = new List<int> { -1 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeElements()
        {
            var input = new List<int> { 1, 3, 5 };
            var expected = new List<int> { 2, 2 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeElements2()
        {
            var input = new List<int> { 4, 3, 1 };
            var expected = new List<int> { -1, -2 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeElements3()
        {
            var input = new List<int> { 4, 4, 4 };
            var expected = new List<int> { 0, 0 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ManyElements()
        {
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> { 1, 1, 1, 1 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ManyElements2()
        {
            var input = new List<int> { 1, 2, 1, 2, 1 };
            var expected = new List<int> { 1, -1, 1, -1 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ManyElements3()
        {
            var input = new List<int> { 1, 1, 2, 4, 7 };
            var expected = new List<int> { 0, 1, 2, 3 };
            var actual = input.Deltas();

            Assert.Equal(expected, actual);
        }
    }
}
