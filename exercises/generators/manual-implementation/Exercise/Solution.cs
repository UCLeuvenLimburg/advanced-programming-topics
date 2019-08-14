using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public class Mapper<T, U> : IEnumerable<U>
    {
        private readonly IEnumerable<T> originalData;

        private readonly Func<T, U> mapper;

        public Mapper(IEnumerable<T> originalData, Func<T, U> mapper)
        {
            this.originalData = originalData;
            this.mapper = mapper;
        }

        public IEnumerator<U> GetEnumerator()
        {
            return new Enumerator( this.originalData.GetEnumerator(), this.mapper );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<U>
        {
            private readonly IEnumerator<T> enumerator;

            private readonly Func<T, U> mapper;

            public Enumerator(IEnumerator<T> enumerator, Func<T, U> mapper)
            {
                this.enumerator = enumerator;
                this.mapper = mapper;
            }

            public U Current => mapper( enumerator.Current );

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                enumerator.Dispose();
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            public void Reset()
            {
                enumerator.Reset();
            }
        }
    }

    public class Selector<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> originalData;

        private readonly Func<T, bool> predicate;

        public Selector( IEnumerable<T> originalData, Func<T, bool> predicate )
        {
            this.originalData = originalData;
            this.predicate = predicate;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator( this.originalData.GetEnumerator(), this.predicate );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly IEnumerator<T> enumerator;

            private readonly Func<T, bool> predicate;

            public Enumerator( IEnumerator<T> enumerator, Func<T, bool> predicate )
            {
                this.enumerator = enumerator;
                this.predicate = predicate;                
            }

            public T Current => enumerator.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                enumerator.Dispose();
            }

            public bool MoveNext()
            {
                do
                {
                    if ( !enumerator.MoveNext() )
                    {
                        return false;
                    }
                } while ( !predicate( enumerator.Current ) );

                return true;
            }

            public void Reset()
            {
                enumerator.Reset();
            }
        }
    }
}
