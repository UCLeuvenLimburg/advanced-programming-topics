using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static T Maximum<T>(this IEnumerable<T> xs) where T : IComparable<T>
        {
            return Maximum<T>(xs, (x, y) => x.CompareTo(y) < 0);
        }

        public static T Minimum<T>(this IEnumerable<T> xs) where T : IComparable<T>
        {
            return Minimum<T>(xs, (x, y) => x.CompareTo(y) < 0);
        }

        public static T Maximum<T>(this IEnumerable<T> xs, Func<T, T, bool> lessThan)
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

        public static T Minimum<T>(this IEnumerable<T> xs, Func<T, T, bool> lessThan)
        {
            return Maximum(xs, (x, y) => lessThan(y, x));
        }

        public static T Maximum<T, K>(this IEnumerable<T> xs, Func<T, K> keyFunction) where K : IComparable<K>
        {
            return Maximum<T>(xs, (x, y) => keyFunction(x).CompareTo(keyFunction(y)) < 0);
        }

        public static T Minimum<T, K>(this IEnumerable<T> xs, Func<T, K> keyFunction) where K : IComparable<K>
        {
            return Minimum<T>(xs, (x, y) => keyFunction(x).CompareTo(keyFunction(y)) < 0);
        }
    }
}
