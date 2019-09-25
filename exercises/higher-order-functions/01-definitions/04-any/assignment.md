# Assignment

Write an extension method `Any(this IEnumerable<T> xs, Func<T, bool> predicate)` that
checks whether there exists a value of `xs` that satisfies the predicate.

```csharp
// Checks whether list contains a prime
new List<int>() { 1, 2, 3, 4 }.Any( IsPrime ); // true
new List<int>() { 4, 8 }.Any( IsPrime ); // false
```
