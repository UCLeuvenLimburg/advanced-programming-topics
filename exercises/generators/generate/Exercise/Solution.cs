using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static IEnumerable<T> Generate<T>(T initial, Func<T, T> successor)
        {
            var current = initial;

            while ( true )
            {
                yield return current;
                current = successor(current);
            }
        }
    }
}
