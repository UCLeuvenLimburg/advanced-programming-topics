using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Unique<T>(this IEnumerable<T> xs)
        {
            var set = new HashSet<T>();

            foreach ( var x in xs )
            {
                if ( !set.Contains(x) )
                {
                    set.Add(x);
                    yield return x;
                }
            }
        }
    }
}
