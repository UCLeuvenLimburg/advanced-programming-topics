using System;
using System.Collections.Generic;

namespace Exercise.Solution
{
    public static class Util
    {
        public static IEnumerable<T> Repeat<T>(T x)
        {
            while ( true )
            {
                yield return x;
            }
        }
    }
}
