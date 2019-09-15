# Assignment

This exercise consists of six functions, each
corresponding to a variation of min/max.
Instead of implementing the same algorithm six times,
we urge you to implement the actual algorithm
only in one single function and have
the other five call it with the appropriate arguments.

First, read which variations of min/max are expected of
you. Then decide which one is the most general one
and implement it. All other five functions
should then consist of a single call to this first function.

## IComparable

Write an extension method with signature

```csharp
T Maximum<T>(this IEnumerable<T> xs) where T : IComparable<T>
```

The `where T : IComparable<T>` means that `Maximum` should only
work on `T`s that implement `IComparable<T>`. In other words,
the `CompareTo` method is available on each element of `xs`.

Similarly, write

```csharp
T Minimum<T>(this IEnumerable<T> xs) where T : IComparable<T>
```

## Comparator Function

Relying on `IComparable<T>` is quite limiting: a type can only
implement it once. For example, there are many ways strings can be ordered:

* Alphabetically or by length.
* In increasing or decreasing order.
* Case sensitive vs case insensitive.
* Ignoring whitespace or not.

Since `string` can only implement `IComparable<string>` once,
only one order can be supported. For this reason,
the concept of using an "external comparer" is introduced:

```csharp
Func<string, string, bool> comparer
```

`comparer` is a function that takes two functions and
returns `true` if the first string is to be considered "smaller" than the second string.
For example, to order strings in order of increasing length, you can use

```csharp
bool CompareByLength(string s1, string s2)
{
    return s1.Length < s2.Length;
}
```

Using `Maximum` using `CompareByLength` would return the longest string.

Write methods

```csharp
T Maximum<T>(this IEnumerable<T> xs, Func<T, T, bool> lessThan) { ... }
T Minimum<T>(this IEnumerable<T> xs, Func<T, T, bool> lessThan) { ... }
```

that return the greatest and least elements of `xs`, respectively,
where the order is determined by `lessThan`.

## By Key

This is a slightly different take than using a comparer function.
Relying on a comparer function is very flexible, but is could be slightly cumbersome.
For example, say you have a `List<Person>` from which you want to retrieve the tallest `Person`.
This can be done with

```csharp
var tallestPerson = people.Maximum( (p1, p2) => p1.Height < p2.Height );
```

This expresses "find the maximum where `p1` is 'less than' `p2` if `p1.Height < p2.Height`".
This is quite unnatural. Instead, it'd be more intuitive to say
"find the `Person` whose `Height` is largest". This is the idea behind using a key function:

```csharp
var tallestPerson = people.Maximum( p => p.Height );
```

Here, the `Maximum` function takes a function `keyFunction`.
To determine which `Person` `p1` or `p2` is largest,
it applies the `keyFunction` on both and compares values.
In our example, `keyFunction(p)` returns the height of `p`,
so the `Person` with the greatest height "wins."

`Maximum`'s signature is

```csharp
T Maximum<T, K>(this IEnumerable<T> xs, Func<T, K> keyFunction) where K : IComparable<K>
```

Take some time to understand it:

* It starts off with a list of `T`s. In our example, `T = Person`.
* `keyFunction` is a function that takes one of those `T`s and returns a "part" of it, with type `K`.
  For our example, `keyFunction` returns the `Height`, so `K = int`. If it were to return the name,
  `K` would be `string`.
* `K` itself must be comparable with other `K`s. For example, heights (`int`s) and names (`string`s) can be compared,
  but if `keyFunction` were to return a `Person`'s mother, we'd be in trouble, since `Person`s are not comparable.
  What would it mean to find the `Person` with the maximum mother?

Do the same for `Minimum`.