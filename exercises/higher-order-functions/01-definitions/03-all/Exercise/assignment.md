# Assignment

Write an extension method `All(this IEnumerable<T> xs, Func<T, bool> predicate)` that
checks whether each value of `xs` satisfies the predicate.

```csharp
// Checks whether all numbers are prime
new List<int>() { 2, 3, 5, 7 }.All( IsPrime ); // true
new List<int>() { 2, 4, 3, 5, 7 }.All( IsPrime ); // false: 4 is not prime
```
