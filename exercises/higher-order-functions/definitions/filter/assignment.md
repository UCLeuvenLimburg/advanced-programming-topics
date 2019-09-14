# Assignment

Write an extension method `Filter(this IEnumerable<T> xs, Func<T, bool> predicate)` that
returns a new list containing only those values of `xs` that satisfy `predicate`.

```csharp
// Retrieves the primes for numbers
new List<int>() { 1, 2, 3, 4, 5 }.Filter( IsPrime ); // { 2, 3, 5 }
```
