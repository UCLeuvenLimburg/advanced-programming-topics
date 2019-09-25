using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IDictionary<U, List<T>> Group<T, U>(this IEnumerable<T> xs, Func<T, U> f)
        {
            var result = new Dictionary<U, List<T>>();

            foreach ( var x in xs )
            {
                var y = f(x);

                if ( !result.ContainsKey(y) )
                {
                    result[y] = new List<T>();
                }

                result[y].Add(x);
            }

            return result;
        }
    }
}
