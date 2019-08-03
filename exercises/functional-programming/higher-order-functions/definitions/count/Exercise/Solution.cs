using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static int Count<T>(IEnumerable<T> xs, Func<T, bool> predicate)
        {
            int count = 0;

            foreach (var x in xs)
            {
                if (predicate(x))
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
