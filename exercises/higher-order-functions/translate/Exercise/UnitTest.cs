
using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using Xunit;
using I = Imperative.Functions;
using F = Functional.Solution.Functions;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Ages()
        {
            IEnumerable<Movie> movies = new List<Movie> {
                new Movie() { Genres = new HashSet<Genre> { Genre.Action } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Documentary } },
                new Movie() { Genres = new HashSet<Genre> { Genre.SciFi } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.SciFi } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Documentary } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Documentary } },
                new Movie() { Genres = new HashSet<Genre> { Genre.SciFi } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Thriller } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Thriller } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Drama } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Thriller } },
                new Movie() { Genres = new HashSet<Genre> { Genre.Thriller } },
            };

            var expected = I.F1(movies);
            var actual = F.F1(movies);

            Assert.Equal(expected, actual);
        }
    }
}
