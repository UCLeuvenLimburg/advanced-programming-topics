using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public class FilteredList<T> : IList<T>
    {
        private readonly IList<T> originalData;

        private readonly Func<T, bool> predicate;

        public FilteredList(IList<T> originalData, Func<T, bool> predicate)
        {
            this.originalData = originalData;
            this.predicate = predicate;
        }

        public T this[int index]
        {
            get
            {
                foreach ( var x in originalData )
                {
                    if ( predicate(x) )
                    {
                        if ( index == 0 )
                        {
                            return x;
                        }
                        else
                        {
                            index--;
                        }
                    }
                }

                throw new IndexOutOfRangeException();
            }
            set => throw new InvalidOperationException();
        }

        public int Count
        {
            get
            {
                var count = 0;

                foreach ( var x in originalData )
                {
                    if ( predicate(x) )
                    {
                        ++count;
                    }
                }

                return count;
            }
        }

        public bool IsReadOnly => true;

        public void Add( T item )
        {
            throw new InvalidOperationException();
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains( T item )
        {
            return originalData.Contains( item ) && predicate( item );
        }

        public void CopyTo( T[] array, int arrayIndex )
        {
            foreach ( var x in originalData )
            {
                if ( predicate(x) )
                {
                    array[arrayIndex] = x;
                    ++arrayIndex;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf( T item )
        {
            int index = 0;

            foreach ( var x in originalData )
            {
                if ( predicate( x ) )
                {
                    if ( x.Equals( item ) )
                    {
                        return index;
                    }

                    index++;
                }
            }

            return -1;
        }

        public void Insert( int index, T item )
        {
            throw new InvalidOperationException();
        }

        public bool Remove( T item )
        {
            throw new InvalidOperationException();
        }

        public void RemoveAt( int index )
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
