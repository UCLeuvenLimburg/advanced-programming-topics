# Assignment

Write an extension method with signature

```csharp
IEnumerable<T> TakeN<T>(this IEnumerable<T> xs, int n)
```

that takes the `n` first elements of the potentially infinite sequence `xs`.
