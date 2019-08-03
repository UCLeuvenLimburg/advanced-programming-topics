using System;
using System.Collections.Generic;

namespace Exercise
{
    public static class Solution
    {
        public static IEnumerable<T> Cycle<T>(IEnumerable<T> xs)
        {
            while ( true )
            {
                foreach ( var x in xs )
                {
                    yield return x;
                }
            }
        }
    }
}
