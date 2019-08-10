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
    }
}