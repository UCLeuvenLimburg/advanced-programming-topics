using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static bool Any<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            foreach (var x in xs)
            {
                if (predicate(x))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
