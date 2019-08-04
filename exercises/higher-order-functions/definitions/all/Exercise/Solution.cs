using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static bool All<T>(IEnumerable<T> xs, Func<T, bool> predicate)
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
