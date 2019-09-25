using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static bool All<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            foreach (var x in xs)
            {
                if (!predicate(x))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
