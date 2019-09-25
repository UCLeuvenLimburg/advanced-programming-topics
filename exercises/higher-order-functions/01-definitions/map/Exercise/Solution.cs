using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static List<R> Map<T, R>(this IEnumerable<T> xs, Func<T, R> f)
        {
            var result = new List<R>();

            foreach (var x in xs)
            {
                result.Add(f(x));
            }

            return result;
        }
    }
}
