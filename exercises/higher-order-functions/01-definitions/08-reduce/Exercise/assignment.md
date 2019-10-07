# Assignment

Write an extension method with signature

```csharp
R Reduce<T, R>(this IEnumerable<T> xs, R acc, Func<T, R, R> f)
```

This function operates as follows:

* It starts with `acc`.
* It combines the first element of `xs` with `acc` using `f`, which yields a new value for `acc`.
* It combines the second element of `xs` with `acc` using `f`, which yields a new value for `acc`.
* ...
* It combines the last element of `xs` with `acc` using `f`, which yields the final value for `acc`.
* It returns `acc`.
