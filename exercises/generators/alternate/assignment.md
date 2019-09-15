# Assignment

Write an extension method with signature

```csharp
IEnumerable<T> Alternate<T>(this IEnumerable<T> xs, IEnumerable<T> ys)
```

It returns a list whose elements are alternatively taken from `xs` and `ys`.
The method must rely on `yield return` to produce its results.

Assume both lists `xs` and `ys` have the same number of elements.

## Example

```csharp
var xs = new List<int>() { 1, 1, 1, 1, 1 };
var ys = new List<int>() { 2, 2, 2, 2, 2 };

xs.Alternate(ys) // { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }
```
