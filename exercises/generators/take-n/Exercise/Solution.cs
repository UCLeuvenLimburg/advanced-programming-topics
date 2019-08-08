using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> TakeN<T>(this IEnumerable<T> xs, int n)
        {
            foreach (var x in xs)
            {
                if ( n <= 0 )
                {
                    yield break;
                }
                else
                {
                    n--;
                    yield return x;
                }
            }
        }
    }
}
