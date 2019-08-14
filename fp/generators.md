---
layout: standard
---
# Generators

## Problem Statement

Let's go back to our `AverageMenAge` example:

```csharp
int AverageMenAge(List<Person> people)
{
    var total;

    for ( var person in people )
    {
        if ( person.Male )
        {
            total += person.Age;
        }

        return int total / people.Count;
    }
}
```

As explained earlier, this code does three things:

* It selects the men from `people`.
* It retrieves their `age`s.
* It computes the average of the ages.

In the code above, these three "subalgorithms" are interwoven,
which prevents reuse. To remedy this,
we disentangled them as follows:

```csharp
int AverageMenAge(List<Person> people)
{
    var males = Select(people, p => p.Male);
    var maleAges = Map(males, p => p.Age);
    return Average(maleAges);
}
```

The three subalgorithms have become calls `Select`, `Map` and `Average`,
three separate functions that can be reused in entirely different contexts.

However, we neglected to mention that this new approach suffers from
a severe drawback: it consumes a lot more memory.
Let's compare how much memory is required for both approaches.
Say the `List<Person>` contains a million objects, half of which represent males.

* The imperative version receives this `List<Person>` a iterates over it.
  The only extra memory needed is for some local variables:s `person` and `total`.
* The functional version receives the `List<Person>`. Next, it builds a new
  `List<Person>` consisting exclusively of "male objects." Then it creates yet another large list,
  a `List<int>`.

We conclude that in this case, the functional approach requires twice as much
memory. It gets only worse as the algorithms becomes more complicated:
at each step a new list of intermediary results needs to be build.
We can find consolation in the fact that this memory consumption is temporary:
once `AverageMenAge` has computed its result, all these lists are ready
to be garbage collected, i.e., there's only a temporary spike in memory consumption.
But still...

Fortunately, there's a solution to this problem.

## Prime Sets

Let's consider an entirely different example for a moment: the set of primes.
What if we tasked you with implementing the set of all primes? How would you go about it?
Feel free to think about this for a while.

```csharp
ISet<int> CreatePrimeSet()
{
    // ???
}
```

The most straightforward way to implement this function would be to simply create a `HashSet<int>` and fill it
with prime numbers:

```csharp
ISet<int> CreatePrimeSet()
{
    var primes = new HashSet<int>();

    for ( int i = 2; i > 0; ++i )
    {
        if ( IsPrime(i) )
        {
            primes.Add(i);
        }
    }

    return primes;
}
```

This approach has some flaws:

* It takes a long while to build. Granted, there are more efficient ways to fill the set,
  but even then, you still need to compute a large number of values (105,097,565 to be exact.)
  That's bound to take some time.
* The set consumes a lot of memory: at least 400MB.

Once the set is constructed, you can rely it
to very quickly determine whether an `int` is prime or not:

```csharp
var primes = CreatePrimeeSet(); // Takes a long time

primes.Contains(15485863); // Immediate response
```

An alternative implementation would be

```csharp
class PrimeSet : ISet<int>
{
    public bool Contains(int n)
    {
        return IsPrime(n);
    }

    public void Add(int n)
    {
        throw new InvalidOperationException("PrimeSet is readonly");
    }

    // Other ISet methods, throw exceptions in all mutating methods
}

ISet<int> CreatePrimeSet()
{
    return new PrimeSet();
}
```

* Constructing the `PrimeSet` is immediate: we simply create an object, but there are no
  computations involved.
* Memory usage is minimal: no data is stored, so only the code needs to be stored in RAM.

The drawback, however, is that asking whether a number is prime is a bit slower:

```csharp
var primes = CreatePrimeeSet(); // Really fast

primes.Contains(15485863); // Takes a bit of time
```

(We can also combine both approaches, yielding an implementation that combines
the advantages of both. We won't discuss it here, as it would distract us from the topic at hand.)

The first implementation can be said to be *eager*: it computes everything beforehand.
The second implementation is called *lazy*: you postpone the computations to the last possible moment.
This way, you only perform computations that are actually necessary.

The point of this example is to make you realize a set is not necessarily a
data structure with all data readily stored somewhere in memory.
If I give you a set, whatever I give you only needs to behave as if it was a set.
A class can pull all the shenanigans it wants internally as long as
it observable behavior satisfies expectations.

## IEnumerable

Let's go back to our `AverageMenAge` example and see how we can apply our new insights
to this case. Earlier, we were complaining about the fact that the functional
style required more memory to store intermediary lists, but the prime set example
taught us that what seems to be a list in memory doesn't really have to actually be a list in memory.

First, a quick disclaimer: the goal is to reach a specific solution *in an incremental fashion*,
which enables you to better understand the final product. The problem is that our road towards this destination
is a bit bumpy, and at this point we're reaching a rather large bump: we'll go through a phase
where we present a rather intimidating solution that if we were to actually
implement it, might count hundreds of rather complex lines of code.
However, immediately after, we'll be able to drastically reduce the amount of code we need,
after which we further simplify it by relying on one of C#'s features.
Eventually, we'll end up with a solution that counts around 2 lines of very simple code.
So, please keep in mind that there is indeed a light at the end of the tunnel.

Okay, let's begin. As a reminder, this is `AverageMenAge`'s implementation:

```csharp
int AverageMenAge(List<Person> people)
{
    var males = Select(people, p => p.Male);
    var maleAges = Map(males, p => p.Age);
    return Average(maleAges);
}

List<R> Map<T, R>(List<T> xs, Func<T, R> fetcher)
{
    var result = new List<R>();

    foreach ( var x in xs )
    {
        result.Add( fetcher(x) );
    }

    return result;
}
```

Both `Select` and `Map` return "true lists", i.e., lists whose contents
are actually present in memory, which is exactly what we intend to avoid.
We need to find a way to turn them both lazy.

Below, we'll only examine how to deal with the second function, `Map`.
The same tricks can be applied to `Select`, but it involves a lot more unnecessary details.

Make sure you understand what `Map` does: given a list of N `Person`s,
it returns a list of `N` integers, which correspond to the `Person`'s ages.
There is a clear 1-to-1 relation between the list of `Person`s and the list of `int`s.

Consider now the class below:

```csharp
class PersonAgeList : IList<int>
{
    private readonly List<Person> people;

    public PersonAgeList(List<Person> people)
    {
        this.people = people;
    }

    public int this[int index] => people[index].age;

    public int Count => people.Count;

    public void Add(Person person)
    {
        throw new InvalidOperationException();
    }

    // Other IList<int> members
}
```

Here, we have implemented a new `IList<int>` class:

* Internally, it keeps a reference to the `List<Person>` whose ages it must contain.
* The `int this[int index]` member implements the indexing operation. For example, `maleAges[5]` invokes this
  member with `index` set to `5`, which in turn fetches the `Person` with index `5` and returns its age.
* `PersonAgeList` doesn't allow modifications: it throws an `InvalidOperationException` at you whenever you try to change it,

Note how `PersonAgeList` consumes almost no memory. Earlier, if we had a list of half a million male `Person`s,
`Map` would build a list of half a million ages, because all ages were *copied* into a new list.
Now, `PersonAgeList` simply keeps a link back to the `List<Person>` and knows how to extract its data from there.

We can generalize this class:

```csharp
class MapList<T, R> : IList<R>
{
    private readonly IList<T> originalData;

    private readonly Func<T, R> mappingFunction;

    public PersonAgeList(IList<T> originalData, Func<T, R> mappingFunction)
    {
        this.originalData = originalData;
        this.mappingFunction = mappingFunction;
    }

    public R this[int index] => mappingFunction(originalData[index]);

    public int Count => originalData.Count;

    public void Add(T item)
    {
        throw new InvalidOperationException();
    }

    // Other IList<int> members
}
```

Our new `Map` function thus becomes:

```csharp
IList<R> Map<T, R>(IList<T> xs, Func<T, R> fetcher)
{
    return new MapList<T, R>(xs, fetcher);
}
```

Take your time to understand this code and the types involved: `T` denotes
the "original data" (e.g. `Person`), while `U` corresponds to the output type (e.g. `int`).

Similarly, we could implement a `SelectList<T>` class that filters "on demand".
It's a bit more complex to implement, since there is no predictable relation
between the indices of the `originalData` and the `SelectList<T>` itself.
Motivated readers can feel free to implement it. (TODO: link to exercise)

Now it looks as if every operation like `Select` and `Map`
needs its own specialized `IList<T>` implementation. This is certainly a viable
approach and has certain advantages, but it's also a lot of work. Perhaps we can simplify things a bit.

`IList<T>` is a relatively large interface: it counts 3 properties and 10 methods, all of
which need to be implemented by subtypes. But do we really need all this functionality?
Enter `IEnumerable<T>`: this interface models a list with minimal functionality.
It only has [a single member `GetEnumerator()`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=netframework-4.8),
which allows us to ask for the list's items one by one. This is typically done using a `foreach` loop:

```csharp
IEnumerable<T> xs;

foreach ( var x in xs ) { ... } // Uses `IEnumerable<T>.GetEnumerator()` internally
```

If we reimplement `Select` and `Map` to return an `IEnumerable<T>` instead of an `IList<T>`,
the `MapList` and `SelectList` classes would be much quicker to write, as
they would need only to contain a single method, i.e., `GetEnumerator()`.
We leave the implementation of these classes as an exercise (TODO: link to exercise).

Unfortunately, we are still being burdened with having to write an entire new class per function.
While `GetEnumerator()` is not not particularly difficult to implement,
it's *work*, and we're in the business of being lazy. So let's put some extra effort in finding a quicker solution.

## Yield

To reiterate: we want to write a function that returns an `IEnumerable<T>` that
works lazily, i.e., it does not store all items elements in memory at once,
but instead is able to generate them on demand.

While it might seem overkill to examine such a specific case so thoroughly,
this pattern is actually quite common. So common, in fact, that
many languages (such as C#, Python and JavaScript) offer specialized features specifically for these situations.

C# provides a special kind of return, named `yield return`. A quick little demo:

```csharp
IEnumerable<int> Foo()
{
    var result = new List<int>();

    result.Add(1);
    result.Add(2);
    result.Add(3);

    return result;
}
```

This code is rather straightforward: it creates a list and returns it. Nothing spectacular about it.
Note that it is *eager*: it uses `List`, which actually stores the `1`, `2` and `3` in memory.
If `Foo` were to add all numbers till one million, the list would consume 4MB of memory.

We now rewrite this code making use of our brand new toy:

```csharp
IEnumerable<int> Bar()
{
    yield return 1;
    yield return 2;
    yield return 3;
}
```

Here, `Bar` also constructs a list containing `1`, `2`, `3`, albeit with a different syntax.
Note that, contrary to `return`, the `yield return` statements do not end the function:
execution goes until the very end of the function's body.

We can use `Bar` in conjunction with a `foreach` loop:

```csharp
foreach ( var x in Bar() )
{
    Console.WriteLine(x);
}
```

This will print out `1`, `2`, `3` on separate lines.
So, right now, `yield return` appears to merely be a slightly more concise syntax for returning lists.
But there's more to it than that. It is actually *lazy*. To prove this, we add print instructions as follows:

```csharp
IEnumerable<int> Bar()
{
    Console.WriteLine("A");
    yield return 1;
    Console.WriteLine("B");
    yield return 2;
    Console.WriteLine("C");
    yield return 3;
    Console.WriteLine("D");
}

var xs = Bar();
Console.WriteLine("Looping");
foreach ( var x in xs )
{
    Console.WriteLine(x);
}
```

If `Bar` were eager, like `Foo`, the following output would be generated:

```text
A
B
C
D
Looping
1
2
3
```

TODO: Link to sample
But this is not the output you receive. Instead, you get

```text
Looping
A
1
B
2
C
3
D
```

How could this happen? To understand this, keep in mind that `Bar()` is being lazy, meaning
it will do the absolute minimum amount of effort needed. Execution thus proceeds as follows:

* First, `Bar` is called. It is supposed to construct a list with the three elements `1`, `2`, `3`,
  but instead, it returns a kind of "debt object" that indicates that it owes you a list.
  Since at that point in execution you haven't looked at the elements of the list,
  there's no reason to compute them. In other words, *none* of the code of `Bar` has been executed.
* `Looping` is printed out.
* The `foreach` loop is initiated. Its purpose is to consecutively fetch each item of `xs`,
  so it starts by asking `xs` for its first element.
* The one in charge of `xs`'s elements is `Bar`, so execution continues in `Bar`.
* The first line of `Bar` is executed and `A` is printed.
* We still haven't got our first element, so we proceed in `Bar`. The next statement is `yield return 1`.
  Aha! We got our element. That's all we need. Execution jumps back to the `foreach` loop.
* `x` becomes 1 and the loop body is executed: `1` is printed out.
* `foreach` requests the second element. Again we must jump back to `Bar`.
* `Bar` remembers where it stopped last time and continues at that point, i.e., it prints `B`.
* Next in line is `yield return 2`. We have our second element, `Bar` can go back to sleep.
* Back in the loop, `x` is set to `2`, which is subsequently printed.
* Third iteration: back to `Bar` where we left off. `C` is printed out, and `yield return 3` generates
  the third element.
* The loop sets `x` to `3`, writes it to the console.
* The loop now asks for the next element.
* Back to `Bar`. `D` is outputted.
* We reach the end of `Bar`: this signals the end of the list.
* The `foreach` loop is being told that `xs`'s end has been reached. The loop ends; there is no fourth iteration.

In short, `yield return` returns the next element in the list and suspends the function.
When the next element in the list is requested, execution goes on just after the `yield return` until
either the next `yield return` or until the function runs out of statements.

Let's go a step further:

```csharp
public IEnumerable<int> Qux()
{
    int i = 0;
    while ( true )
    {
        yield return i;
        ++i;
    }
}
```

Before reading further, try to find out what this does.

`Qux` has a `yield return` sitting inside a loop. The first iteration yield returns `0`, the next `1`, etc.
This results in `Qux` producing all integers one by one, so basically, it returns an infinite list.
If you were to `foreach` it, the loop would never end. In practice, it will reach `Int.MaxValue`,
wraps around to `Int.MinValue`, so it would go from `0` to 2 billion, fall down to -2 billion, go up to 2 billion, fall back down to
-2 billion, etc. The sample `infinite-list` shows this in action applied on `sbyte`s, which are limited to the range `-128` - `127`.

To summarize, `yield return` can be used to implement functions that return an `IEnumerable<T>` and lazily generate its elements.
This is a memory efficient approach to working with large lists.

## Back to Select and Map

We let our new-found powers loose on `Select` and `Map`:

```csharp
IEnumerable<T> Select<T>(IEnumerable<T> xs, Func<T, bool> predicate)
{
    foreach ( var x of xs )
    {
        if ( predicate(x) )
        {
            yield return x;
        }
    }
}
```

```csharp
IEnumerable<R> Map<T, R>(IEnumerable<T> xs, Func<T, R> mappingFunction)
{
    foreach ( var x of xs )
    {
        yield return mappingFunction(x);
    }
}
```

We reevaluate our functional implementation of `AverageMenAge`:

```csharp
int AverageMenAge(List<Person> people)
{
    var males = Select(people, p => p.Male);
    var maleAges = Map(males, p => p.Age);
    return Average(maleAges);
}
```

Before we started using `yield return`, `males` and `maleAges` were large lists,
which consumed a lot of memory, making the functional approach less appealing.
Thanks to the laziness introduced by relying on `yield return`,
the memory consumption is cut down to approximately the same level of the imperative solution.
There is still overhead, but the advantages (reusability, readability) outweigh this small cost.

## Link With Functional Programming

Lazy list generation is safe to use in stateless parts of your program,
but it becomes more unpredictable in imperative settings.

When you generate a list eagerly (i.e. no `yield return` but a regular `List`),
the entire process is uninterrupted: there are no external interferences.
With lazy generation, your function is, as it were, cut in pieces, each
piece being executed at different times. It is possible that in between
such partial executions the world has changed, making your algorithm fail.

For example, consider the `Range` class below which you
can use to enumerate `int`s between an lower and upper bound.

```csharp
class Range
{
    public Range(int lower, int upper)
    {
        this.LowerBound = lower;
        this.UpperBound = upper;
    }

    public int LowerBound { get; set; }

    public int UpperBound { get; set; }

    public IEnumerable<int> EagerEnumerate()
    {
        var result = new List<int>();

        for ( var i = LowerBound; i <= UpperBound; ++i )
        {
            result.Add(i);
        }

        return result;
    }

    public IEnumerable<int> LazyEnumerate()
    {
        for ( var i = LowerBound; i <= UpperBound; ++i )
        {
            yield return i;
        }
    }
}

//
// Usage
///
var range = new Range(10, 20);

// Eager
foreach ( var i in ange.EagerEnumerate() )
{
    Console.WriteLine(i);
}

// Lazy
foreach ( var i in range.LazyEnumerate() )
{
    Console.WriteLine(i);
}
```

Both use cases produce the exact same result. However, the range is mutable, i.e.,
the `LowerBound` and `UpperBound` properties are settable. Let's see what happens
if they are modified.

```csharp
var range = new Range(10, 20);

// Eager
foreach ( var i in range.EagerEnumerate() )
{
    Console.WriteLine(i);
    range.UpperBound++;
}

// Lazy
foreach ( var i in range.LazyEnumerate() )
{
    Console.WriteLine(i);
    range.UpperBound++;
}
```

The eager version constructs the entire list of `int`s when `range.EagerEnumerate()` is called.
Once it is constructed, the `foreach` loop proceeds to iterate over each element. Whatever
happens inside the loop body, it cannot impact the list constructed by `EagerEnumerate()`.
In other words, the eager version prints the values from `10` to `20`.

The lazy version, however, never ends. At each iteration, the `UpperBound` moves up,
causing `LazyEnumerate`'s `i` never to reach `UpperBound`. In this example,
the problem is a bit flagrant and forced, but remember that in practice,
a loop can be much more complicated, involving calls to objects that call other objects,
and before you know it, somewhere in the loop body someone changes your `range` or whatever
thing you are iterating over. This leads to bugs that can be quite difficult to find.

To safeguard against such eventualities, you can introduce more statelessness:

* You can make `LowerBound` and `UpperBound` readonly by omitting their setters.
* You can have `LazyEnumerate` make a local copy of `UpperBound`'s value.
  `i` will then move from `LowerBound` to the *original* value of `UpperBound`.

## Generators in Python

Python calls functions that lazily generate lists *generators*.

```python
def range(a, b):
    while a < b:
      yield a
      a += 1

for x in range(1, 10):
    print(x)
```

prints all integers from `1` to `10` (exclusive). `range` is actually already built in, so there's
no need to define it yourself.

## Generators in JavaScript

In the same vein, JavaScript supports [generators](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/function*).

```javascript
function* range(a, b)
{
  while ( a < b )
  {
    yield a;
    a += 1;
  }
}

for ( const x of foo() )
{
    console.log(x);
}
```

Note the asterisk: `yield` can only be used in `function*`s.

Generators were introduced in ES2015. My guess the weird asterisk in `function*`
was necessary to maintain backward compatibility:
adding a new keyword such as `yield` is always risky, since it's possible
some existing code uses `yield` as a variable/function name.
Since it is generally forbidden to use keywords as function names (e.g. you cannot
name a method `class` in Java), code using `yield` as a variable name would
suddenly become rejected due to syntax errors.

To avoid breaking legacy code, `yield` is only a keyword when used inside
`function*`s. Outside these, `yield` can be used as a variable name.

```javascript
function foo()
{
    let yield = 1; // ok
}

function* bar()
{
    let yield = 1; // syntax error
}
```

## Streams in Java

Java provides no language support. Instead, it "fakes" it using `Stream` objects which provide
methods to construct lazy lists. In general, this means that sacrifices have to be made syntax-wise.

```java
Stream<Integer> range(int a, int b)
{
    return Stream.iterate(a, (Integer k) -> k + 1).limit(Math.max(0, b - a));
}
```

Disclaimer: there may be a simpler way to implement `range`; you're welcome to let me know and I'll update it correspondingly.

The implementation above first constructs an infinite stream containing `a`, `a+1`, `a+2`, ... Next, it is cut off after
`b - a` elements. The `max` is necessary to deal with cases where `b - a < 0`.
