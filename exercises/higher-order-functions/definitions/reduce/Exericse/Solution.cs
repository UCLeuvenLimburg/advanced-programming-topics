using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static R Reduce<T, R>(this IEnumerable<T> xs, R acc, Func<T, R, R> f)
        {
            foreach ( var x in xs )
            {
                acc = f(x, acc);
            }

            return acc;
        }
    }
}
