using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Functional.Solution
{
    public static class Functions
    {
        public static int F1(IEnumerable<Movie> movies)
        {
            return movies.Count(m => m.Genres.Contains(Genre.Documentary));
        }

        public static double F2(IEnumerable<Movie> movies, string director)
        {
            return movies.Where(m => m.Director == director).Select(m => m.Runtime).Average();
        }

        public static IDictionary<string, List<Movie>> F3(IEnumerable<Movie> movies)
        {
            return movies.GroupBy(m => m.Director).ToDictionary(group => group.Key, group => group.OrderBy(m => m.Title).ToList());
        }

        public static IDictionary<int, int> F4(IEnumerable<Movie> movies)
        {
            return movies.GroupBy(m => m.Year).ToDictionary(group => group.Key, group => group.Count());
        }
    }
}