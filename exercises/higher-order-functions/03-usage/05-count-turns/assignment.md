# Assigment

Write an extension method

```csharp
int CountTurns(this IEnumerable<int> ns)
```

that counts the number of "turns" the sequence `ns` takes.
A turn is a point where an increasing subsequence turns
into a decreasing subsequence or vice versa.


## Examples

* `1 2 3 4` consists of a single increasing subsequence: zero turns.
* `1 2 3 2 1` first increasing, then decreases: 1 turn.
* `1 2 1 2` goes up, down and up again: 2 turns.
* `1 5 7 4 2 3 9 0 1 0 4` consists of the following monotonous 7 subsequences, meaning there are 6 turns:
  * `1 5 7`
  * `7 4 2`
  * `2 3 9`
  * `9 0`
  * `0 1`
  * `1 0`
  * `0 4`
