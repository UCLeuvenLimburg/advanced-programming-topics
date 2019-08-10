using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Intersection<T>(this IEnumerable<T> xs, IEnumerable<T> ys)
        {
            return xs.Where(x => ys.Contains(x));
        }

        public static IEnumerable<T> Difference<T>(this IEnumerable<T> xs, IEnumerable<T> ys)
        {
            return xs.Where(x => !ys.Contains(x));
        }
    }
}
