using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Functional.Solution
{
    public static class Functions
    {
        public static int Query1(IEnumerable<Movie> movies)
        {
            return movies.Max(m => m.Runtime);
        }

        public static int Query2(IEnumerable<Movie> movies)
        {
            return movies.Min(m => m.Runtime);
        }

        public static double Query3(IEnumerable<Movie> movies)
        {
            return movies.Max(m => m.Rating);
        }

        public static Movie Query4(IEnumerable<Movie> movies)
        {
            return movies.MaximumBy(m => m.Rating);
        }

        public static IEnumerable<string> Query5(IEnumerable<Movie> movies)
        {
            return movies.Select(m => m.Director).Distinct().OrderBy(x => x);
        }

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

        public static IEnumerable<string> F5(IEnumerable<Movie> movies, int n)
        {
            return movies.GroupBy(m => m.Director).Where(p => p.Count() >= n).Select(p => p.Key).OrderBy(x => x);
        }

        public static IDictionary<string, Movie> F6(IEnumerable<Movie> movies)
        {
            return movies.GroupBy(m => m.Director).ToDictionary(group => group.Key, group => group.MaximumBy(m => m.Rating));
        }

        public static IEnumerable<string> F7(IEnumerable<Movie> movies, double n)
        {
            return movies.Select(m => m.Director).Distinct().Where(d => movies.Where(m => m.Director == d).All(m => m.Rating >= n)).OrderBy(x => x);
        }
    }


    public static class Extensions
    {
        public static T Maximum<T>(this IEnumerable<T> xs, Func<T, T, bool> lessThan)
        {
            var isFirst = true;
            var result = default(T);

            foreach (var x in xs)
            {
                if (isFirst)
                {
                    result = x;
                    isFirst = false;
                }
                else if (lessThan(result, x))
                {
                    result = x;
                }
            }

            return result;
        }

        public static T MaximumBy<T, K>(this IEnumerable<T> xs, Func<T, K> keyFunction) where K : IComparable<K>
        {
            return Maximum<T>(xs, (x, y) => keyFunction(x).CompareTo(keyFunction(y)) < 0);
        }
    }
}