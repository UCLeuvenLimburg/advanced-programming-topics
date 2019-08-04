using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> xs)
        {
            while ( true )
            {
                foreach ( var x in xs )
                {
                    yield return x;
                }
            }
        }
    }
}
