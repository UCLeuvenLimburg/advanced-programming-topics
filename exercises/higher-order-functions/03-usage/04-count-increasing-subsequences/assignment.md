# Assigment

Write an extension method

```csharp
int CountIncreasingSubsequences(this IEnumerable<int> ns)
```

that counts the number of increasing subsequences of `ns`.

## Examples

* `1 2 3 4` consists of a single increasing subsequence.
* `1 2 3 1 2 3` consists of two increasing subsequences.
* `1 2 1 2 1 2` consists of three increasing subsequences.
* `5 6 4 5 2 3` consists of three increasing subsequences (`5 6`, `4 5` and `2 3`).
* `5 4 3 2 1` consists of five increasing subsequences, all of length one.
* `1` consists of a single increasing subsequence.
* The empty sequence is also considered as a single increasing subsequence.
