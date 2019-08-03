using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static IEnumerable<R> Map<T, R>(IEnumerable<T> xs, Func<T, R> f)
        {
            foreach (var x in xs)
            {
                yield return f(x);
            }
        }
    }
}
