using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static Tuple<List<T>, List<T>> Partition<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            var left = new List<T>();
            var right = new List<T>();

            foreach ( var x in xs )
            {
                (predicate(x) ? left : right).Add(x);
            }

            return Tuple.Create(left, right);
        }
    }
}
