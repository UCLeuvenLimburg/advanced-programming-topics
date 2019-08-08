using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> DropN<T>(this IEnumerable<T> xs, int n)
        {
            foreach (var x in xs)
            {
                if ( n > 0 )
                {
                    --n;
                }
                else
                {
                    yield return x;
                }
            }
        }
    }
}
