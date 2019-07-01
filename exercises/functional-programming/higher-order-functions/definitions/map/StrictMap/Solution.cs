using System;
using System.Collections.Generic;

namespace StrictMap
{
    public class Solution
    {
        public static List<R> Map<T, R>(IList<T> xs, Func<T, R> f)
        {
            var result = new List<R>();

            foreach (var x in xs)
            {
                result.Add(f(x));
            }

            return result;
        }
    }
}
