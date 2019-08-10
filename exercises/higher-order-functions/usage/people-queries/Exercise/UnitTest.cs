
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Ages()
        {
            IEnumerable<Person> people = new List<Person> {
                new Person() { Age = 15 },
                new Person() { Age = 29 },
                new Person() { Age = 18 },
                new Person() { Age = 38 },
                new Person() { Age = 41 },
            };

            var expected = new List<int> { 15, 29, 18, 38, 41 };
            var actual = Exercise.Solution.Queries.Ages(people);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Women()
        {
            IList<Person> people = new List<Person> {
                new Person() { IsMale = true },
                new Person() { IsMale = false },
                new Person() { IsMale = true },
                new Person() { IsMale = true },
                new Person() { IsMale = false },
                new Person() { IsMale = true },
                new Person() { IsMale = false },
            };

            var expected = new List<Person> { people[1], people[4], people[6] };
            var actual = Exercise.Solution.Queries.Women(people);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountMen()
        {
            IEnumerable<Person> people = new List<Person> {
                new Person() { IsMale = true },
                new Person() { IsMale = false },
                new Person() { IsMale = true },
                new Person() { IsMale = true },
                new Person() { IsMale = false },
                new Person() { IsMale = true },
                new Person() { IsMale = false },
            };

            var expected = 4;
            var actual = Exercise.Solution.Queries.CountMen(people);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OldestMan()
        {
            var expected = new Person() { IsMale = true, Age = 70 };

            IEnumerable<Person> people = new List<Person> {
                new Person() { IsMale = true, Age = 41 },
                new Person() { IsMale = false, Age = 99 },
                expected,
                new Person() { IsMale = true, Age = 5 },
                new Person() { IsMale = false, Age = 12 },
                new Person() { IsMale = true, Age = 25 },
                new Person() { IsMale = false, Age = 54 },
            };

            var actual = Exercise.Solution.Queries.OldestMan(people);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PersonWithAgeBetweenExists1()
        {
            IEnumerable<Person> people = new List<Person> {
                new Person() { IsMale = true, Age = 41 },
                new Person() { IsMale = false, Age = 99 },
                new Person() { IsMale = true, Age = 5 },
                new Person() { IsMale = false, Age = 12 },
                new Person() { IsMale = true, Age = 25 },
                new Person() { IsMale = false, Age = 54 },
            };

            var actual = Exercise.Solution.Queries.PersonWithAgeBetweenExists(people, 10, 15);
            var expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PersonWithAgeBetweenExists2()
        {
            IEnumerable<Person> people = new List<Person> {
                new Person() { IsMale = true, Age = 41 },
                new Person() { IsMale = false, Age = 99 },
                new Person() { IsMale = true, Age = 5 },
                new Person() { IsMale = false, Age = 12 },
                new Person() { IsMale = true, Age = 25 },
                new Person() { IsMale = false, Age = 54 },
            };

            var actual = Exercise.Solution.Queries.PersonWithAgeBetweenExists(people, 20, 50);
            var expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PersonWithAgeBetweenExists3()
        {
            IEnumerable<Person> people = new List<Person> {
                new Person() { IsMale = true, Age = 41 },
                new Person() { IsMale = false, Age = 99 },
                new Person() { IsMale = true, Age = 5 },
                new Person() { IsMale = false, Age = 12 },
                new Person() { IsMale = true, Age = 25 },
                new Person() { IsMale = false, Age = 54 },
            };

            var actual = Exercise.Solution.Queries.PersonWithAgeBetweenExists(people, 30, 40);
            var expected = false;

            Assert.Equal(expected, actual);
        }
    }
}
