# Assignment

In the class `Student`, write a static method with signature

```csharp
IEnumerable<T> Generate<T>(T initial, Func<T, T> successor)
```

that generates the infinite sequence where
the Nth element equals the Nth application of `successor` to `initial`.

## Example

Say `successor = x => x * 2` and `initial = 1`, `Generate` then returns

```text
1 2 4 8 16 32 64
```

In other words, each element equals `successor(previousElement)`.
