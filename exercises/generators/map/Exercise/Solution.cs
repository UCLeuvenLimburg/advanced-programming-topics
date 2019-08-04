using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> xs, Func<T, R> f)
        {
            foreach (var x in xs)
            {
                yield return f(x);
            }
        }
    }
}
