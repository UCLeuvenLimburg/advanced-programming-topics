# Assignment

Write an extension method `Count(this IEnumerable<T> xs, Func<T, bool> predicate)` that
checks how many elements of `xs` satisfy `predicate`.

```csharp
// Counts how many numbers are prime
numbers.Count( IsPrime );
```
