using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
// using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Permutations1()
        {
            var xs = new List<int> { };
            var actual = xs.Permutations();
            var expected = new List<List<int>> {
                new List<int> { }
            };

            Check(expected, actual);
        }

        [Fact]
        public void Permutations2()
        {
            var xs = new List<int> { 1 };
            var actual = xs.Permutations();
            var expected = new List<List<int>> {
                new List<int> { 1 }
            };

            Check(expected, actual);
        }

        [Fact]
        public void Permutations3()
        {
            var xs = new List<int> { 1, 2 };
            var actual = xs.Permutations();
            var expected = new List<List<int>> {
                new List<int> { 1, 2 },
                new List<int> { 2, 1 },
            };

            Check(expected, actual);
        }

        [Fact]
        public void Permutations4()
        {
            var xs = new List<int> { 1, 2, 3 };
            var actual = xs.Permutations();
            var expected = new List<List<int>> {
                new List<int> { 1, 2, 3 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 1, 2 },
                new List<int> { 3, 2, 1 },
            };

            Check(expected, actual);
        }

        [Fact]
        public void Permutations5()
        {
            var xs = new List<string> { "a", "b", "c" };
            var actual = xs.Permutations();
            var expected = new List<List<string>> {
                new List<string> { "a", "b", "c" },
                new List<string> { "b", "a", "c" },
                new List<string> { "b", "a", "c" },
                new List<string> { "b", "c", "a" },
                new List<string> { "c", "a", "b" },
                new List<string> { "c", "b", "a" },
            };

            Check(expected, actual);
        }

        private void Check<T>(List<List<T>> expected, IEnumerable<List<T>> actual)
        {
            var actualList = actual.ToList();

            Assert.Equal( expected.Count, actualList.Count );

            foreach ( var x in expected )
            {
                Assert.Contains( x, actualList );
            }
        }
    }
}
