using System;
using System.Collections.Generic;
using Shared;

namespace Imperative
{
    public static class Functions
    {
        public static int F1(IEnumerable<Movie> movies)
        {
            var result = 0;

            foreach ( var movie in movies )
            {
                if ( movie.Genres.Contains(Genre.Documentary) )
                {
                    ++result;
                }
            }

            return result;
        }

        public static double F2(IEnumerable<Movie> movies, string director)
        {
            double result = 0;
            var count = 0;

            foreach ( var movie in movies )
            {
                if ( movie.Director == director )
                {
                    result += movie.Runtime;
                    count++;
                }
            }

            return result / count;
        }
    }
}