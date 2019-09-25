
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
        public void Intersection1()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { 1, 3, 5 };
            var actual = xs.Intersect(ys);
            var expected = new List<int> { 1, 3, 5 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Intersection2()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { 1, 3, 5, 7, 9 };
            var actual = xs.Intersect(ys);
            var expected = new List<int> { 1, 3, 5 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Intersection3()
        {
            IEnumerable<int> xs = new List<int> { };
            IEnumerable<int> ys = new List<int> { 1, 2, 3 };
            var actual = xs.Intersect(ys);
            var expected = new List<int> { };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Intersection4()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3 };
            IEnumerable<int> ys = new List<int> { };
            var actual = xs.Intersect(ys);
            var expected = new List<int> { };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Intersection5()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { 3, 4, 5, 6, 7 };
            var actual = xs.Intersect(ys);
            var expected = new List<int> { 3, 4, 5 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Difference1()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { 1, 3, 5 };
            var actual = xs.Difference(ys);
            var expected = new List<int> { 2, 4 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Difference2()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { };
            var actual = xs.Difference(ys);
            var expected = new List<int> { 1, 2, 3, 4, 5 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Difference3()
        {
            IEnumerable<int> xs = new List<int> { };
            IEnumerable<int> ys = new List<int> { 1, 3, 5 };
            var actual = xs.Difference(ys);
            var expected = new List<int> { };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Difference4()
        {
            IEnumerable<int> xs = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> ys = new List<int> { 3, 4, 5, 6, 7 };
            var actual = xs.Difference(ys);
            var expected = new List<int> { 1, 2 };

            Assert.Equal(expected, actual);
        }
    }
}
