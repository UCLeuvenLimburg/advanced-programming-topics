using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static bool Any<T>(IEnumerable<T> xs, Func<T, bool> predicate)
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
