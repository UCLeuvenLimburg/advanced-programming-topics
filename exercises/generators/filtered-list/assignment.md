# Assignment

Create a class `Exercise.FilteredView<T>` that implements `IList<T>`
and represents a filtered view of a list.

A `FilteredView<T>` object takes

* An `IList<T>`: the input elements.
* A `Func<T, bool>`: a predicate determining whether a `T` belongs in the final result or not.

**Important** `FilteredView<T>` should have all its methods compute their results on the spot.
You should not filter the list in the constructor ahead of time. This way,
the `FilteredView<T>` remains up to date with respect to the original list.

## Example

```csharp
var originalList = new List<int> { 1, 2, 3, 4, 5 };
var FilteredView = new FilteredView<int>(originalList, isPrime);

// FilteredView == { 2, 3, 5 }

originalList.Add(7);

// FilteredView == { 2, 3, 5, 7 }
```