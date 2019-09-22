# Assigment

Write an extension method

```csharp
bool IsIncreasing(this IEnumerable<int> ns)
```

that determines whether `ns` is a sequence of increasing numbers,
that is, for each consecutive pair of numbers `i` and `j`,
`i` must not be greater than `j`. Note that `1 2 2 3` is considered
increasing: equal consecutive elements are allowed.
