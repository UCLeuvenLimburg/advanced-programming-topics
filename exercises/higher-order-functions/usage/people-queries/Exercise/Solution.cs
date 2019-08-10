using System;
using System.Collections.Generic;
using System.Linq;
using Exercise;

namespace Exercise.Solution
{
    public static class Queries
    {
        public static IEnumerable<int> Ages(IEnumerable<Person> people)
        {
            return people.Select(p => p.Age);
        }

        public static IEnumerable<Person> Women(IEnumerable<Person> people)
        {
            return people.Where(p => !p.IsMale);
        }

        public static int CountMen(IEnumerable<Person> people)
        {
            return people.Count(p => p.IsMale);
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

        public static Person OldestMan(IEnumerable<Person> people)
        {
            return people.Where(p => p.IsMale).MaximumBy(p => p.Age);
        }
    }
}
