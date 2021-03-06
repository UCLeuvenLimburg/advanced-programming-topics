using System;
using System.Collections.Generic;
using Shared;

namespace Imperative
{
    public static class Functions
    {
        public static int Query1(IEnumerable<Movie> movies)
        {
            var result = int.MinValue;

            foreach ( var movie in movies )
            {
                if ( movie.Runtime > result )
                {
                    result = movie.Runtime;
                }
            }

            return result;
        }

        public static int Query2(IEnumerable<Movie> movies)
        {
            var result = int.MaxValue;

            foreach ( var movie in movies )
            {
                if ( movie.Runtime < result )
                {
                    result = movie.Runtime;
                }
            }

            return result;
        }

        public static double Query3(IEnumerable<Movie> movies)
        {
            var result = double.NegativeInfinity;

            foreach ( var movie in movies )
            {
                if ( movie.Rating > result )
                {
                    result = movie.Rating;
                }
            }

            return result;
        }

        public static Movie Query4(IEnumerable<Movie> movies)
        {
            Movie result = null;

            foreach ( var movie in movies )
            {
                if ( result == null || movie.Rating > result.Rating )
                {
                    result = movie;
                }
            }

            return result;
        }

        public static IEnumerable<string> Query5(IEnumerable<Movie> movies)
        {
            var directors = new HashSet<string>();

            foreach ( var movie in movies )
            {
                directors.Add(movie.Director);
            }

            var result = new List<string>();

            foreach ( var director in directors )
            {
                result.Add(director);
            }

            result.Sort();

            return result;
        }

        public static int Query6(IEnumerable<Movie> movies)
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

        public static double Query7(IEnumerable<Movie> movies, string director)
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

        public static IDictionary<string, List<Movie>> Query8(IEnumerable<Movie> movies)
        {
            var result = new Dictionary<string, List<Movie>>();

            foreach ( var movie in movies )
            {
                if ( !result.ContainsKey(movie.Director) )
                {
                    result[movie.Director] = new List<Movie>();
                }

                result[movie.Director].Add(movie);
            }

            foreach ( var pair in result )
            {
                pair.Value.Sort((m1, m2) => m1.Title.CompareTo(m2.Title));
            }

            return result;
        }

        public static IDictionary<int, int> Query9(IEnumerable<Movie> movies)
        {
            var result = new Dictionary<int, int>();

            foreach ( var movie in movies )
            {
                if ( !result.ContainsKey(movie.Year) )
                {
                    result[movie.Year] = 1;
                }
                else
                {
                    result[movie.Year] += 1;
                }
            }

            return result;
        }

        public static IEnumerable<string> Query10(IEnumerable<Movie> movies, int n)
        {
            var table = new Dictionary<string, int>();

            foreach ( var movie in movies )
            {
                if ( !table.ContainsKey(movie.Director))
                {
                    table[movie.Director] = 1;
                }
                else
                {
                    table[movie.Director] += 1;
                }
            }

            var result = new List<string>();
            foreach ( var pair in table )
            {
                if ( pair.Value >= n )
                {
                    result.Add(pair.Key);
                }
            }

            result.Sort();

            return result;
        }

        public static IDictionary<string, Movie> Query11(IEnumerable<Movie> movies)
        {
            var result = new Dictionary<string, Movie>();

            foreach ( var movie in movies )
            {
                if ( !result.ContainsKey(movie.Director))
                {
                    result[movie.Director] = movie;
                }
                else if ( result[movie.Director].Rating < movie.Rating )
                {
                    result[movie.Director] = movie;
                }
            }

            return result;
        }

        public static IEnumerable<string> Query12(IEnumerable<Movie> movies, double n)
        {
            var directors = new HashSet<string>();

            foreach ( var movie in movies )
            {
                directors.Add(movie.Director);
            }

            var result = new List<string>();
            foreach ( var director in directors )
            {
                bool b = true;

                foreach ( var movie in movies )
                {
                    if ( movie.Director == director && movie.Rating < n )
                    {
                        b = false;
                    }
                }

                if ( b )
                {
                    result.Add(director);
                }
            }

            result.Sort();

            return result;
        }
    }
}