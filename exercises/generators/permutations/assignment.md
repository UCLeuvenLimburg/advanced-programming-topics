# Assignment

Write an extension method with signature

```csharp
IEnumerable<List<T>> Permutations<T>(this IEnumerable<T> items)
```

that returns all permutations of `items`. A permutation
of a list `xs` is another list `ys` that contains the same
elements as `xs`, but not necessarily in the same order.
For example, the permutations of `1 2 3` are

```text
1 2 3
1 3 2
2 1 3
2 3 1
3 1 2
3 2 1
```

You are free to return the permutations in any order you want.