# Assigment

Write an extension method

```csharp
IEnumerable<int> Deltas(this IEnumerable<int> ns)
```

that returns a list of the difference between the consecutive elements of `ns`.

## Example

Take the list

```csharp
var list = new List<int> { 0, 0, 1, 3, 6, 10 };
```

`Deltas` must compute the following values and return them as a list:

```csharp
var result = new List<int>();

result.Add( list[1] - list[0] );
result.Add( list[2] - list[1] );
result.Add( list[3] - list[2] );
result.Add( list[4] - list[3] );
result.Add( list[5] - list[4] );

// result == { 0, 1, 2, 3, 4 }
```
