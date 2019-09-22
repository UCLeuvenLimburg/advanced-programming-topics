# Assignment

Write an extension method with signature

```csharp
IEnumerable<T> DropN<T>(this IEnumerable<T> xs, int n)
```

that drops the `n` first elements of the potentially infinite sequence `xs`.
