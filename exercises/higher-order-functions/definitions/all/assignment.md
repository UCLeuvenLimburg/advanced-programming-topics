# Assignment

Write an extension method `All(this IEnumerable<T> xs, Func<T, bool> predicate)` that
checks whether each value of `xs` satisfies the predicate.

```csharp
// Checks whether all numbers are prime
numbers.All( IsPrime );
```
