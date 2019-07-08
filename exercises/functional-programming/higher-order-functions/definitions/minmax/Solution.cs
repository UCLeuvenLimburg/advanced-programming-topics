using System;
using System.Collections.Generic;

namespace MinMax
{
    public static class Solution
    {
        public static T Maximum<T>(IEnumerable<T> xs) where T : IComparable<T>
        {
            return Maximum<T>(xs, (x, y) => x.CompareTo(y) < 0);
        }

        public static T Minimum<T>(IEnumerable<T> xs) where T : IComparable<T>
        {
            return Minimum<T>(xs, (x, y) => x.CompareTo(y) < 0);
        }

        public static T Maximum<T>(IEnumerable<T> xs, Func<T, T, bool> lessThan)
        {
            var isFirst = true;
            var result = default(T);

            foreach ( var x in xs )
            {
                if ( isFirst )
                {
                    result = x;
                    isFirst = false;
                }
                else if ( lessThan(result, x) )
                {
                    result = x;
                }
            }

            return result;
        }

        public static T Minimum<T>(IEnumerable<T> xs, Func<T, T, bool> lessThan)
        {
            return Maximum(xs, (x, y) => lessThan(y, x));
        }

        public static T Maximum<T, K>(IEnumerable<T> xs, Func<T, K> keyFunction) where K : IComparable<K>
        {
            return Maximum<T>(xs, (x, y) => keyFunction(x).CompareTo(keyFunction(y)) < 0);
        }

        public static T Minimum<T, K>(IEnumerable<T> xs, Func<T, K> keyFunction) where K : IComparable<K>
        {
            return Minimum<T>(xs, (x, y) => keyFunction(x).CompareTo(keyFunction(y)) < 0);
        }
    }
}
