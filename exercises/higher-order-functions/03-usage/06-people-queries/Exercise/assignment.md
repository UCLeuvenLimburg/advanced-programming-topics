# Assignment

Implement the functionality listed below. The functions rely on the `Person` class defined in `Person.cs`.
Make sure you split the algorithm up in as many as reusable parts. Rely as much as possible on `IEnumerable` extension methods (such as `Where`, `Select`, ...)
Define helper methods if necessary.

* `IEnumerable<int> Ages(this IEnumerable<Person> people)` should return the ages of the given `people`.
* `IEnumerable<Person> Women(this IEnumerable<Person> people)` should return only the women in `people`.
* `int CountMen(this IEnumerable<Person> people)` should return the number of men in `people`.
* `Person OldestMan(this IEnumerable<Person> people)` should return the oldest man in `people`.
* `bool PersonWithAgeBetweenExists(this IEnumerable<Person> people, int min, int max)` should check if there's a person whose age lies between `min` and `max` (inclusive).
