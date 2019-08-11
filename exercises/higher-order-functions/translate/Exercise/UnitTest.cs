
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
        public const string Scorsese = "Martin Scorsese";

        public const string Leone = "Sergio Leone";

        public const string PTA = "Paul Thomas Anderson";

        public const string Kubrick = "Stanley Kubrick";

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
            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Runtime = 165 }
            }, Scorsese);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Runtime = 100 },
                new Movie() { Director=Scorsese, Runtime = 200 },
            }, Scorsese);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Runtime = 100 },
                new Movie() { Director=Leone, Runtime = 240 },
            }, Scorsese);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Runtime = 100 },
                new Movie() { Director=Leone, Runtime = 240 },
            }, Leone);

            CheckMulti(new List<Movie> {
                new Movie() { Director=Leone, Runtime = 200 },
                new Movie() { Director=Scorsese, Runtime = 150 },
                new Movie() { Director=PTA, Runtime = 90 },
                new Movie() { Director=PTA, Runtime = 200 },
                new Movie() { Director=Kubrick, Runtime = 120 },
                new Movie() { Director=Leone, Runtime = 180 },
                new Movie() { Director=Kubrick, Runtime = 140 },
                new Movie() { Director=Scorsese, Runtime = 100 },
                new Movie() { Director=Kubrick, Runtime = 200 },
                new Movie() { Director=PTA, Runtime = 180 },
                new Movie() { Director=Scorsese, Runtime = 60 },
                new Movie() { Director=PTA, Runtime = 150 },
                new Movie() { Director=Scorsese, Runtime = 200 },
            }, new List<string> { Leone, Scorsese, PTA, Kubrick });


            void Check(IEnumerable<Movie> movies, string director)
            {
                var expected = I.F2(movies, director);
                var actual = F.F2(movies, director);

                Assert.Equal(expected, actual);
            }

            void CheckMulti(IEnumerable<Movie> movies, IEnumerable<string> directors)
            {
                foreach (var director in directors)
                {
                    Check(movies, director);
                }
            }
        }

        [Fact]
        public void F3()
        {
            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Casino" }
            });

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Goodfellas" },
                new Movie() { Director=Scorsese, Title="Silence" },
            });

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="The Departed" },
                new Movie() { Director=Leone, Title="Once Upon A Time In America" },
            });

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="The Last Temptation Of Christ" },
                new Movie() { Director=Leone, Title="The Good, The Bad and The Ugly" },
            });

            Check(new List<Movie> {
                new Movie() { Director=Leone, Title="For A Fistful Of Dollars" },
                new Movie() { Director=Scorsese, Title="Hugo" },
                new Movie() { Director=PTA, Title="Punch Drunk Love" },
                new Movie() { Director=PTA, Title="Magnolia" },
                new Movie() { Director=Kubrick, Title="The Shining" },
                new Movie() { Director=Leone, Title="For A Few Dollars More" },
                new Movie() { Director=Kubrick, Title="2001 A Space Odyssey" },
                new Movie() { Director=Scorsese, Title="Taxi Driver" },
                new Movie() { Director=Kubrick, Title="Full Metal Jacket" },
                new Movie() { Director=PTA, Title="There Will Be Blood" },
                new Movie() { Director=Scorsese, Title="The Aviator" },
                new Movie() { Director=PTA, Title="Phantom Thread" },
                new Movie() { Director=Scorsese, Title="Shutter Island" },
            });


            void Check(IEnumerable<Movie> movies)
            {
                var expected = I.F3(movies);
                var actual = F.F3(movies);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void F4()
        {
            Check(new List<Movie>
            {
            });

            Check(new List<Movie> {
                new Movie() { Year = 1999 },
            });

            Check(new List<Movie> {
                new Movie() { Year = 2000 },
                new Movie() { Year = 2000 },
            });

            Check(new List<Movie> {
                new Movie() { Year = 2000 },
                new Movie() { Year = 2001 },
            });

            Check(new List<Movie> {
                new Movie() { Year = 1968 },
                new Movie() { Year = 1999 },
                new Movie() { Year = 2010 },
                new Movie() { Year = 1999 },
                new Movie() { Year = 2011 },
                new Movie() { Year = 1999 },
                new Movie() { Year = 1968 },
                new Movie() { Year = 1985 },
                new Movie() { Year = 1968 },
                new Movie() { Year = 1985 },
            });

            void Check(IEnumerable<Movie> movies)
            {
                var expected = I.F4(movies);
                var actual = F.F4(movies);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void F5()
        {
            Check(new List<Movie>
            {
            }, 0);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Casino" }
            }, 0);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Casino" }
            }, 1);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Casino" }
            }, 2);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Goodfellas" },
                new Movie() { Director=Scorsese, Title="Silence" },
            }, 0);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Goodfellas" },
                new Movie() { Director=Scorsese, Title="Silence" },
            }, 1);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Goodfellas" },
                new Movie() { Director=Scorsese, Title="Silence" },
            }, 2);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="Goodfellas" },
                new Movie() { Director=Scorsese, Title="Silence" },
            }, 3);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="The Departed" },
                new Movie() { Director=Leone, Title="Once Upon A Time In America" },
            }, 0);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="The Departed" },
                new Movie() { Director=Leone, Title="Once Upon A Time In America" },
            }, 1);

            Check(new List<Movie> {
                new Movie() { Director=Scorsese, Title="The Departed" },
                new Movie() { Director=Leone, Title="Once Upon A Time In America" },
            }, 2);

            Check(new List<Movie> {
                new Movie() { Director=Leone, Title="For A Fistful Of Dollars" },
                new Movie() { Director=Scorsese, Title="Hugo" },
                new Movie() { Director=PTA, Title="Punch Drunk Love" },
                new Movie() { Director=PTA, Title="Magnolia" },
                new Movie() { Director=Kubrick, Title="The Shining" },
                new Movie() { Director=Leone, Title="For A Few Dollars More" },
                new Movie() { Director=Kubrick, Title="2001 A Space Odyssey" },
                new Movie() { Director=Scorsese, Title="Taxi Driver" },
                new Movie() { Director=Kubrick, Title="Full Metal Jacket" },
                new Movie() { Director=PTA, Title="There Will Be Blood" },
                new Movie() { Director=Scorsese, Title="The Aviator" },
                new Movie() { Director=PTA, Title="Phantom Thread" },
                new Movie() { Director=Scorsese, Title="Shutter Island" },
            }, 0);

            Check(new List<Movie> {
                new Movie() { Director=Leone, Title="For A Fistful Of Dollars" },
                new Movie() { Director=Scorsese, Title="Hugo" },
                new Movie() { Director=PTA, Title="Punch Drunk Love" },
                new Movie() { Director=PTA, Title="Magnolia" },
                new Movie() { Director=Kubrick, Title="The Shining" },
                new Movie() { Director=Leone, Title="For A Few Dollars More" },
                new Movie() { Director=Kubrick, Title="2001 A Space Odyssey" },
                new Movie() { Director=Scorsese, Title="Taxi Driver" },
                new Movie() { Director=Kubrick, Title="Full Metal Jacket" },
                new Movie() { Director=PTA, Title="There Will Be Blood" },
                new Movie() { Director=Scorsese, Title="The Aviator" },
                new Movie() { Director=PTA, Title="Phantom Thread" },
                new Movie() { Director=Scorsese, Title="Shutter Island" },
            }, 1);

            Check(new List<Movie> {
                new Movie() { Director=Leone, Title="For A Fistful Of Dollars" },
                new Movie() { Director=Scorsese, Title="Hugo" },
                new Movie() { Director=PTA, Title="Punch Drunk Love" },
                new Movie() { Director=PTA, Title="Magnolia" },
                new Movie() { Director=Kubrick, Title="The Shining" },
                new Movie() { Director=Leone, Title="For A Few Dollars More" },
                new Movie() { Director=Kubrick, Title="2001 A Space Odyssey" },
                new Movie() { Director=Scorsese, Title="Taxi Driver" },
                new Movie() { Director=Kubrick, Title="Full Metal Jacket" },
                new Movie() { Director=PTA, Title="There Will Be Blood" },
                new Movie() { Director=Scorsese, Title="The Aviator" },
                new Movie() { Director=PTA, Title="Phantom Thread" },
                new Movie() { Director=Scorsese, Title="Shutter Island" },
            }, 2);

            Check(new List<Movie> {
                new Movie() { Director=Leone, Title="For A Fistful Of Dollars" },
                new Movie() { Director=Scorsese, Title="Hugo" },
                new Movie() { Director=PTA, Title="Punch Drunk Love" },
                new Movie() { Director=PTA, Title="Magnolia" },
                new Movie() { Director=Kubrick, Title="The Shining" },
                new Movie() { Director=Leone, Title="For A Few Dollars More" },
                new Movie() { Director=Kubrick, Title="2001 A Space Odyssey" },
                new Movie() { Director=Scorsese, Title="Taxi Driver" },
                new Movie() { Director=Kubrick, Title="Full Metal Jacket" },
                new Movie() { Director=PTA, Title="There Will Be Blood" },
                new Movie() { Director=Scorsese, Title="The Aviator" },
                new Movie() { Director=PTA, Title="Phantom Thread" },
                new Movie() { Director=Scorsese, Title="Shutter Island" },
            }, 3);

            void Check(IEnumerable<Movie> movies, int n)
            {
                var expected = I.F5(movies, n);
                var actual = F.F5(movies, n);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void F6()
        {
            Check(new List<Movie> { });

            Check(new List<Movie>
            {
                new Movie() { Director = Scorsese, Rating=8.1 }
            });

            Check(new List<Movie>
            {
                new Movie() { Director = Scorsese, Rating=8.1 },
                new Movie() { Director = Scorsese, Rating=9.2 },
            });

            Check(new List<Movie>
            {
                new Movie() { Director = Scorsese, Rating=9.2 },
                new Movie() { Director = Scorsese, Rating=8.1 },
            });

            Check(new List<Movie>
            {
                new Movie() { Director = Scorsese, Rating=9.2 },
                new Movie() { Director = Leone, Rating=9.5 },
            });

            Check(new List<Movie>
            {
                new Movie() { Director = Scorsese, Rating=9.2 },
                new Movie() { Director = Leone, Rating=9.9 },
                new Movie() { Director = Scorsese, Rating=8.7 },
                new Movie() { Director = Leone, Rating=9.5 },
            });

            Check(new List<Movie>
            {
                new Movie() { Director = Scorsese, Rating=9.2 },
                new Movie() { Director = Leone, Rating=9.9 },
                new Movie() { Director = Kubrick, Rating=7.1 },
                new Movie() { Director = Scorsese, Rating=8.7 },
                new Movie() { Director = Leone, Rating=9.5 },
                new Movie() { Director = PTA, Rating=9.8 },
            });

            void Check(IEnumerable<Movie> movies)
            {
                var expected = I.F6(movies);
                var actual = F.F6(movies);

                Assert.Equal(expected, actual);
            }
        }
    }
}
