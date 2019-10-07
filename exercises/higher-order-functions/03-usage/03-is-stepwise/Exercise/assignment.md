# Assigment

Write an extension method

```csharp
bool IsStepwise(this IEnumerable<int> ns)
```

that checks whether consecutive elements in `ns`
differ at most by one. For example, `1 2 3` is
stepwise, because there are no "jumps".
Conversely, `1 2 4 5` contains a jump between `2` and `4`.
