# Assignment

Write an extension method with signature

```csharp
IEnumerable<T> Cycle<T>(this IEnumerable<T> xs)
```

It returns an infinite list consisting of endless repetitions of `xs`.

## Example

```csharp
var xs = new List<int> { 1, 2, 3 };
var cycle = xs.Cycle(); // { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, ... }
```
