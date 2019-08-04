using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static T FindFirst<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            foreach ( var x in xs )
            {
                if ( predicate(x) )
                {
                    return x;
                }
            }

            throw new InvalidOperationException();
        }

        public static T FindLast<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            return FindFirst(xs.Reverse(), predicate);
        }

        public static int IndexOf<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            return FindFirst(Enumerable.Range(0, int.MaxValue).Zip(xs, Tuple.Create), tuple => predicate(tuple.Item2)).Item1;
        }
    }
}