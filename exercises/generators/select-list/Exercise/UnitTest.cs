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
        public void Count1()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var expected = xs.Where( Predicate ).Count();
            var actual = new SelectList<int>( xs, Predicate ).Count;

            Assert.Equal( actual, expected );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void Count2()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var expected = xs.Where( Predicate ).Count();
            var actual = new SelectList<int>( xs, Predicate ).Count;

            Assert.Equal( actual, expected );


            bool Predicate( int x )
            {
                return x % 17 < 7;
            }
        }

        [Fact]
        public void Indexing1()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var expected = xs.Where( Predicate ).ToList();
            var actual = new SelectList<int>( xs, Predicate );

            Assert.Equal( Copy( actual ), expected );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void Indexing2()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var expected = xs.Where( Predicate ).ToList();
            var actual = new SelectList<int>( xs, Predicate );

            Assert.Equal( Copy( actual ), expected );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void Add()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var actual = new SelectList<int>( xs, Predicate );

            Assert.Throws<InvalidOperationException>( () => actual.Add(1) );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void Clear()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var actual = new SelectList<int>( xs, Predicate );

            Assert.Throws<InvalidOperationException>( () => actual.Clear() );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void Remove()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var actual = new SelectList<int>( xs, Predicate );

            Assert.Throws<InvalidOperationException>( () => actual.Remove( 0 ) );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void RemoveAt()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var actual = new SelectList<int>( xs, Predicate );

            Assert.Throws<InvalidOperationException>( () => actual.RemoveAt( 0 ) );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void CopyTo()
        {
            var xs = Enumerable.Range( 0, 10000 ).ToList();
            var expected = xs.Where( Predicate ).ToArray();
            var actual = new int[expected.Length];
            new SelectList<int>( xs, Predicate ).CopyTo( actual, 0 );

            Assert.Equal( expected, actual );


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        [Fact]
        public void IndexOf()
        {
            var ints = Enumerable.Range( 0, 10000 ).ToList();
            var xs = ints.Where( Predicate ).ToList();
            var ys = new SelectList<int>( ints, Predicate );

            for ( int i = 0; i != 10000; ++i )
            {
                var expected = xs.IndexOf( i );
                var actual = ys.IndexOf( i );

                Assert.Equal( expected, actual );
            }


            bool Predicate( int x )
            {
                return x % 2 == 0;
            }
        }

        private IList<T> Copy<T>( IList<T> xs )
        {
            return Enumerable.Range( 0, xs.Count ).Select( i => xs[i] ).ToList();
        }
    }
}
