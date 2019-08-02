---
layout: standard
mathjax: true
---
# Evaluation Order

Although this section might appear rather theoretical,
it shouldn't be hard to understand. Also know
that the matter discussed here will be very important
in order to understand later topics, such as generators
and concurrency.

## Order in Imperative Settings

Imperative programming consists of writing down
a series of instructions. These are expected
to be executed in the given order:
it's (more or less) a promise the language makes:
if you specify three instructions, they will
be executed in that order. (This is technically
not 100% true, we'll come back to this in another topic.)

However, there are cases in which rearranging
the instructions in a different order
will result in more efficient execution
without changing the ultimate outcome.
For example,

```csharp
void Foo(int x, int y)
{
    x++;
    y *= 2;
    Console.WriteLine($"x={x}, y={y}");
}
```

Now imagine that, for some reason, it'd be faster to perform
the multiplication first and then the incrementation.
It can be proven that the end result will remain the same,
so an optimizing compiler would be free to swap these instructions around:

```csharp
void Foo(int x, int y)
{
    y *= 2;
    x++;
    Console.WriteLine($"x={x}, y={y}");
}
```

Let's change the function a bit:

```csharp
void Foo(int[] x, int[] y)
{
    x[0]++;
    y[0] *= 2;
    Console.WriteLine($"x={x[0]}, y={y[0]}");
}
```

Though this may seem a bit artificial, realize
that this is no different than a situation where `x` and `y`
were part of any other object instead of of arrays.
The sole reason for using arrays is to avoid
having to burden the example with an extra class definition.

In this version, it is not safe anymore to
exchange the first two lines due to
the possibility that `x` and `y` might refer to the
same array:

```csharp
int[] x = new int[] { 5 };
Foo(x, x);
```

The relevance of order follows from the stateful nature of imperative programming:
because variables can change values, the time at which a variable is looked at matters.
If an instruction is postponed to a later moment, the variables on which it operates
might have changed by then, causing different results to be produced.

## Order in a Functional Setting

Contrary to the imperative style, functional programming has no state.
A logical consequence of this is that evaluation order does not matter.
There are a few nuances to this claim and we want to make sure
that there are no misunderstandings.

Evaluation order has *nothing* to do with operator precedence.
For example, `5 + 3 * 2` is purely functional,
but it still requires you to perform the multiplication first and
the addition next. Operator precedence is nothing
more than a syntactic trick to avoid having to write
parentheses all over: `5 + 3 * 2` is merely
a shorthand notation for `5 + (3 * 2)`.

So, where does this free to choose evaluation order come into play.
Consider the following:

$$
  \frac{1 + 2}{3 + 4}
$$

This expression consists of three operations:

* O1: The addition $1 + 2$
* O2: The addition $3 + 4$
* O3: The division of the results of the additions

Of course, not every evaluation order is possible: O3 (the division) can only
be computed *after* having evaluated both O1 and O2. You can only perform
an operation if all necessary data is available.
However, the order in which you evaluate O1 and O2 does not matter.

We can generalize this to the evaluation of function arguments:

```csharp
Foo( Bar(x + 1, y / 2), Qux(z * 8, t - 5) );
```

In an imperative setting, the order in which the arguments are evaluated matters.
Some languages guarantee a left-to-right evaluation order,
but others make no such guarantees and pick any order that seems most
efficient to the compiler. C++ is an extreme case: the language
expects that *you* guarantee that the order does not matter
so as to give the compiler total freedom in evaluation order.
If you happen to write a function call where argument evaluation
matters, you end up with undefined behavior (i.e., unpredictable results.)
No such problems occur in functional code: no order needs to be specified since
the order has no bearing on the final result, giving the compiler
total freedom to optimize your code.

We can generalize this further: loops can be reversed,
calls can be postponed or omitted altogether, etc.

## Consequences

We give a quick overview of the consequences of not having a strict evaluation order to adhere to.
Most of these topics will be examined in more detail later.

### Laziness

If evaluation order does not matter, it means we can postpone evaluation
indefinitely. In fact, we can defer it until the result of an evaluation is actually needed.
This is known as *lazy evaluation*.

```csharp
var a = Foo();
var b = Bar();
var c = Qux();

Console.WriteLine($"b = {b}, a = {a}");
```

In normal circumstances, the evaluation order would be

* Invoke `Foo()` and assign the result to `a`.
* Invoke `Bar()` and assign the result to `b`.
* Invoke `Qux()` and assign the result to `c`.
* Build the string and have `Console.WriteLine` print it.

When applying lazy evaluation, the order becomes

* First comes a call to `Foo()`, but why would we go to the trouble? Let's take a mental note that if we need `a`, we'll call `Foo()`.
* Now `Bar()`. Again we just skip it, but were we to ever need its value, `Bar()` is where it's at.
* Same for `Qux()`.
* Oh, we need to show the user something. Apparently he wants to see `b` and `a`, so let's call `Bar()` and then `Foo()`. We put the results in the string and print it out. User happy.

Note how the evaluation order is purely determined by the last line. `Qux()` is never even invoked since there is no need to have its result.
Skipping `Qux()` is only safe if we know it has no side effects (e.g. changing some internal variable's value), which is always the case in a purely functional setting.

Since laziness is only safe to use in a purely functional context, languages do not apply it by default.
Instead, laziness is often offered as part of a library. For example,
it is part of [C#'s standard library](https://docs.microsoft.com/en-us/dotnet/api/system.lazy-1?view=netframework-4.8).

### Generators

Imagine you have a file containing millions of bank transactions
which you need to process, e.g., compute the total amount of money transferred.
The code could look like this:

```csharp
List<Transaction> transactions = ReadTransactions();
var total = 0;

foreach ( var transaction in transactions )
{
    total += transaction.Amount;
}
```

This code causes all the transactions to be read in at once and stored in memory as a `List<Transaction>`.
Next, this list is iterated over: each `Transaction` is processed in sequential order.

In the case of very large lists, keeping it entirely in memory might cause problems.
Can we somehow avoid this? Do we truly need to have all data in memory at once/

The code above only needs one `Transaction` at once. It does not need to jump around the list,
or go back one item. We can use this fact to dramatically decrease the amount of memory needed.

It would make more sense to have the algorithm above proceed as follows:

* Read on `Transaction`.
* Process `Transaction`.
* Throw `Transaction` away.
* Repeat till end of list.

Implementing `ReadTransactions()` so that it returns a list-like object
that is able to return one `Transaction` at a time is certainly possible and not very hard,
but it can get quite complex in more advanced situations. To aid you in such cases,
some languages (C#, Python, JavaScript) provide *generators*:
these are special functions that produce a list of values, but can be paused and resumed at will.

### Memoization (not memorization)

Without state, all functions are deterministic: giving the same arguments will lead to the same result each time.

Say you have a computationally expensive function which you happen to call frequently.
It might make sense to store results in a data structure to prevent the same results
from being computed multiple times.

### Multithreading

If you are spreading execution across multiple threads, functional programming can considerably simplify your life.

In an imperative setting, the value of a variable changes over time:
depending on the moment you choose to read a variable, you can get a different result.

Threads need to communicate with each other somehow. This can be achieved by relying
on what is called *shared state*: variables that both threads
can read and write to. For example, one thread can inform another of its progress
by updating a shared `int` variable indicating how much percent of the work is done.
The other thread can then wait till this variable reaches `100` before proceeding:

```csharp
// Shared state
int progress = 0;

// Thread 1
for ( int i = 0; i != 100; ++i )
{
    PerformWork();
    progress++;
}

// Thread 2 (e.g. GUI)
while ( progress < 100 )
{
    ShowProgress();
}
```

(Note: do *not* write code like shown above as it will not work correctly.)

In order to obtain correct results,
it is important that threads access this shared state in a disciplined manner.
For example, we might want to prohibit threads from
writing to the same variable at once, lest we obtain incorrect results.
In other words, correct timing is of paramount importance.

Matters are greatly complicated by the unfortunate fact
that threads are scheduled to run at completely unpredictable times.
We are supposed to make sure each thread performs
each task at the right time without knowing when each thread runs.
Quite a predicament.

One way to solve this problem is to
employ synchronization primitives such
as semaphores, locks, monitors, etc. to
put constraints on when each thread can execute
which instructions.
Unfortunately, this is very hard to do reliably
and mistakes are very difficult to detect.

Another solution is to get rid of mutable state altogether:
purely functional code requires no synchronization whatsoever
and is thread-safe by default.
