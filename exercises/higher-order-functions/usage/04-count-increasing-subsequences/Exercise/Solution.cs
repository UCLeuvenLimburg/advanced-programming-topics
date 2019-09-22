using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<int> Deltas(this IEnumerable<int> ns)
        {
            return ns.Zip(ns.Skip(1), (x, y) => y - x);
        }

        public static int CountIncreasingSubsequences(this IEnumerable<int> ns)
        {
            return ns.Deltas().Where(dx => dx < 0).Count() + 1;
        }        
    }
}
