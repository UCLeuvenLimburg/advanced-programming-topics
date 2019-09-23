using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Mapper1()
        {
            var xs = Enumerable.Range( 1, 10000 );
            var expected = xs.Select( MappingFunction ).ToList();
            var actual = new Mapper<int, int>( xs, MappingFunction );

            Check( actual, expected );


            int MappingFunction( int x)
            {
                return x * x;
            }
        }

        [Fact]
        public void Mapper2()
        {
            var xs = Enumerable.Range( 1, 10000 );
            var expected = xs.Select( MappingFunction ).ToList();
            var actual = new Mapper<int, int>( xs, MappingFunction );

            Check( actual, expected );


            int MappingFunction( int x )
            {
                return 2 * x;
            }
        }

        [Fact]
        public void Mapper3()
        {
            var xs = Enumerable.Range( 1000, 10000 );
            var expected = xs.Select( MappingFunction ).ToList();
            var actual = new Mapper<int, int>( xs, MappingFunction );

            Check( actual, expected );


            int MappingFunction( int x )
            {
                return -x;
            }
        }

        [Fact]
        public void Filter1()
        {
            var xs = Enumerable.Range( 1, 10000 );
            var expected = xs.Where( Predicate ).ToList();
            var actual = new Filter<int>( xs, Predicate );

            Check( actual, expected );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void Filter2()
        {
            var xs = Enumerable.Range( 100, 10000 );
            var expected = xs.Where( Predicate ).ToList();
            var actual = new Filter<int>( xs, Predicate );

            Check( actual, expected );


            bool Predicate( int x )
            {
                return x % 2 != 0;
            }
        }

        [Fact]
        public void Filter3()
        {
            var xs = Enumerable.Range( 100, 10000 );
            var expected = xs.Where( Predicate ).ToList();
            var actual = new Filter<int>( xs, Predicate );

            Check( actual, expected );


            bool Predicate( int x )
            {
                return x % 13 < 7;
            }
        }

        private void Check<T>( IEnumerable<T> actual, IList<T> expected )
        {
            var actualList = actual.Take( expected.Count ).ToList();

            Assert.Equal( expected, actualList );
        }
    }
}
