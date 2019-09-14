# Assignment

Write an extension method `Any(this IEnumerable<T> xs, Func<T, bool> predicate)` that
checks whether there exists a value of `xs` that satisfies the predicate.

```csharp
// Checks whether numbers contains a prime
numbers.Any( IsPrime );
```
