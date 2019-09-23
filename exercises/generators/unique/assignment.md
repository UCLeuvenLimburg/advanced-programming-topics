# Assignment

Write an extension method with signature

```csharp
IEnumerable<T> Unique<T>(this IEnumerable<T> xs)
```

that returns `xs` without duplicates. Only the first
occurrence of each element should remain.

## Example

```csharp
var ns = new List<int> { 1, 2, 3, 2, 3, 4, 3, 2, 1 };
var result = ns.Unique(); // { 1, 2, 3, 4 }
```
