# Assignment

Write an extension method `Count(this IEnumerable<T> xs, Func<T, bool> predicate)` that
checks how many elements of `xs` satisfy `predicate`.

```csharp
// Counts how many numbers are prime
new List<int>() { 1, 2, 3, 4, 5 }.Count( IsPrime ); // 3
```
