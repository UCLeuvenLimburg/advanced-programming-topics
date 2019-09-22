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

        public static bool IsIncreasing(this IEnumerable<int> ns)
        {
            return ns.Deltas().All(delta => delta >= 0);
        }
    }
}
