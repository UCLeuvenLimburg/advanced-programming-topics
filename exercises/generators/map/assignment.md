# Assignment

Write an extension method with signature

```csharp
IEnumerable<R> Map<T, R>(this IEnumerable<T> xs, Func<T, R> f)
```

that implements the same functionality as the built-in `Select`:
it applies `f` to each element of `xs` in turn and returns
the results as a new list.
