using System;
using System.Collections.Generic;
using System.Linq;
using Exercise;

namespace Exercise.Solution
{
    public static class Queries
    {
        public static IEnumerable<int> Ages(this IEnumerable<Person> people)
        {
            return people.Select(p => p.Age);
        }

        public static IEnumerable<Person> Women(this IEnumerable<Person> people)
        {
            return people.Where(p => !p.IsMale);
        }

        public static int CountMen(this IEnumerable<Person> people)
        {
            return people.Count(p => p.IsMale);
        }

        public static Person OldestMan(this IEnumerable<Person> people)
        {
            return people.Where(p => p.IsMale).MaximumBy(p => p.Age);
        }

        public static bool PersonWithAgeBetweenExists(this IEnumerable<Person> people, int min, int max)
        {
            return people.Any(p => min <= p.Age && p.Age <= max);
        }

        public static T Maximum<T>(this IEnumerable<T> xs, Func<T, T, bool> lessThan)
        {
            var isFirst = true;
            var result = default(T);

            foreach ( var x in xs )
            {
                if ( isFirst )
                {
                    result = x;
                    isFirst = false;
                }
                else if ( lessThan(result, x) )
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
