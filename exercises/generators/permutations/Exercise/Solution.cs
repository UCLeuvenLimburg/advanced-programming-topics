using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Solution
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<List<T>> Permutations<T>(this IEnumerable<T> items)
        {
            return Aux(items.ToList());


            IEnumerable<List<T>> Aux(IList<T> xs)
            {
                if ( xs.Count > 0 )
                {
                    for ( var i = 0; i != xs.Count; ++i )
                    {
                        var x = xs[i];
                        xs.RemoveAt(i);

                        foreach ( var ys in Aux(xs) )
                        {
                            var copy = ys.ToList();
                            copy.Insert(0, x);
                            yield return copy;
                        }

                        xs.Insert(i, x);
                    }
                }
                else
                {
                    yield return new List<T>();
                }
            }
        }
    }
}
