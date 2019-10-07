# Assignment

Write an extension method `Group<R>(this IEnumerable<T> xs, Func<T, R> categorizer)` that
returns a `IDictionary<R, List<T>>` that cate the elements of `xs` by the value return by `categorizer`.

## Example

```csharp
class Movie
{
    public string Director { get; set; }

    public string Title { get; set; }
}

var myMovieCollection = new List<Movie>() {
    new Movie() { Director = "Sergio Leone", Title = "The Good, The Bad and The Ugly" },
    new Movie() { Director = "James Cmaeron", Title = "Avatar" },
    new Movie() { Director = "Sergio Leone", Title = "Once Upon a Time in the America" },
    new Movie() { Director = "James Cmaeron", Title = "Terminator 2" },
    new Movie() { Director = "Sergio Leone", Title = "Duck You Sucker" },
    new Movie() { Director = "Paul Thomas Anderson", Title = "There Will Be Blood" },
    new Movie() { Director = "James Cmaeron", Title = "True Lies" },
    new Movie() { Director = "Paul Thomas Anderson", Title = "The Master" },
    new Movie() { Director = "James Cmaeron", Title = "Titanic" },
    new Movie() { Director = "Sergio Leone", Title = "Once Upon a Time in the West" },
    new Movie() { Director = "Paul Thomas Anderson", Title = "Magnolia" },
};

var groupedByDirector = myMovieCollection.GroupBy(movie => movie.Director);

groupedByDirector["Sergio Leone"] // returns all movies by Sergio Leone
groupedByDirector["Paul Thomas Anderson"] // returns all movies by Paul Thomas Anderson
```
