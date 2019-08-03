using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static List<T> Filter<T>(IList<T> xs, Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var x in xs)
            {
                if (predicate(x))
                {
                    result.Add(x);
                }
            }

            return result;
        }
    }
}
