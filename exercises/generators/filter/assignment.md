# Assignment

Write an extension method with signature

```csharp
IEnumerable<T> Filter<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
```

that returns a new sequence that only contains those elements of `xs` that satisfy `predicate`.
In other words, it does the same as the built-in function `Where`.
