using System;
using System.Collections.Generic;
using Shared;

namespace Imperative
{
    public static class Functions
    {
        public static int F1(IEnumerable<Movie> movies)
        {
            var total = 0;

            foreach ( var movie in movies )
            {
                if ( movie.Genres.Contains(Genre.Documentary) )
                {
                    ++total;
                }
            }

            return total;
        }
    }
}