using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> xs, IEnumerable<T> ys)
        {
            foreach ( var pair in xs.Zip(ys, (x, y) => Tuple.Create(x, y)) )
            {
                yield return pair.Item1;
                yield return pair.Item2;
            }
        }
    }
}
