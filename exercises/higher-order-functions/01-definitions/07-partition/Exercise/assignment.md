# Assignment

Write an extension method with signature

```csharp
Tuple<List<T>, List<T>> Partition<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
```

The function returns two lists:

* A list of items of `xs` for which `predicate` returns `true`.
* A list of items of `xs` for which `predicate` returns `false`.

## Example

```csharp
var tuple = people.Partition(p => p.IsMale);
```

This divides the list `people` into a list of men and a list of women.
