using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static bool IsIncreasing(this IList<int> ns)
        {
            return ns.Zip(ns.Skip(1), (x, y) => x <= y).All(x => x);
        }
    }
}
