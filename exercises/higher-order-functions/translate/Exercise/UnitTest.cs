
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
        public void F1()
        {
            Check(new List<Movie> {
                new Movie() { Genres = new HashSet<Genre> { Genre.Action } },
            });

            Check(new List<Movie> {
                new Movie() { Genres = new HashSet<Genre> { Genre.Documentary } },
            });

            Check(new List<Movie> {
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
            });


            void Check(IEnumerable<Movie> movies)
            {
                var expected = I.F1(movies);
                var actual = F.F1(movies);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void F2()
        {
            var scorsese = "Martin Scorsese";
            var leone = "Sergio Leone";
            var pta = "Paul Thomas Anderson";
            var kubrick = "Stanley Kubrick";

            Check(new List<Movie> {
                new Movie() { Director=scorsese, Runtime = 165 }
            }, scorsese);

            Check(new List<Movie> {
                new Movie() { Director=scorsese, Runtime = 100 },
                new Movie() { Director=scorsese, Runtime = 200 },
            }, scorsese);

            Check(new List<Movie> {
                new Movie() { Director=scorsese, Runtime = 100 },
                new Movie() { Director=leone, Runtime = 240 },
            }, scorsese);

            Check(new List<Movie> {
                new Movie() { Director=scorsese, Runtime = 100 },
                new Movie() { Director=leone, Runtime = 240 },
            }, leone);

            CheckMulti(new List<Movie> {
                new Movie() { Director=leone, Runtime = 200 },
                new Movie() { Director=scorsese, Runtime = 150 },
                new Movie() { Director=pta, Runtime = 90 },
                new Movie() { Director=pta, Runtime = 200 },
                new Movie() { Director=kubrick, Runtime = 120 },
                new Movie() { Director=leone, Runtime = 180 },
                new Movie() { Director=kubrick, Runtime = 140 },
                new Movie() { Director=scorsese, Runtime = 100 },
                new Movie() { Director=kubrick, Runtime = 200 },
                new Movie() { Director=pta, Runtime = 180 },
                new Movie() { Director=scorsese, Runtime = 60 },
                new Movie() { Director=pta, Runtime = 150 },
                new Movie() { Director=scorsese, Runtime = 200 },
            }, new List<string> { leone, scorsese, pta, kubrick });


            void Check(IEnumerable<Movie> movies, string director)
            {
                var expected = I.F2(movies, director);
                var actual = F.F2(movies, director);

                Assert.Equal(expected, actual);
            }

            void CheckMulti(IEnumerable<Movie> movies, IEnumerable<string> directors)
            {
                foreach ( var director in directors )
                {
                    Check(movies, director);
                }
            }
        }
    }
}
