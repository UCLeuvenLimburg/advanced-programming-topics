using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static List<T> Filter<T>(this IList<T> xs, Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var x in xs)
            {
                if (predicate(x))
                {
                    result.Add(x);
                }
            }

            return result;
        }
    }
}
