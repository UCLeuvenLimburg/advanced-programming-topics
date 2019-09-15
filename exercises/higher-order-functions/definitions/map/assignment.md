# Assignment

Write an extension method `Map<R>(this IEnumerable<T> xs, Func<T, R> function)` that
returns a `List<R>` that contains the results of applying `function` to each element of `xs`.

```csharp
new List<int>() { 1, 2, 3 }.Map(x => 2 * x); // returns { 2, 4, 6 }
```
