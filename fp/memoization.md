---
layout: standard
---
# Memoization

In this section we discuss how stateless programming
allow us to easily speed up functions.

## Deterministic Functions

Consider the following code:

```c
int counter = 0;

int next()
{
    counter++;
    return counter;
}
```

Let's play with it:

```c
next();  => 1
next();  => 2
next();  => 3
```

These results should come as no surprise.
What's noteworthy about this function
is that each time it's called, it returns
a different result. This means
it relies on state: in this case, the state
is embodied by the variable `counter`.

In a functional world, such functions don't exist,
as there is no state. A function's result
will only depend on the parameter values.
Call the function twice with the same parameters,
get the same result.
Functions that exhibit this behavior,
are said to be *deterministic*.

A few example:

|Deterministic|Nondeterministic|
|-|-|
| `Math.Sqrt(x)` | `GetCurrentTime()` |
| `Sort(xs)` (returns new list) | `RandomInteger()` |
| `SolveSudoku(puzzle)` | `ReadFile(filename)`

## Remembering Values

Say you have a deterministic function that also
happens to take a relatively long time to compute its result:

```python
# Python
def is_prime(n):
    return n > 1 and all( n % k != 0 for k in range(2, n) )
```

Once it's been established whether a certain
integer `k` is a prime or not, it makes
little sense to perform the same computation again
later. We can optimize this algorithm by it
having remember its prior results:

```python
prime_table = {}

def is_prime(n):
    if n not in prime_table:
        prime_table[n] = n > 1 and all( n % k != 0 for k in range(2, n) )
    return prime_table[n]
```

A possible execution goes as follows:

* We call `is_prime(97)`.
* `is_prime` checks if `prime_table` contains an entry for `97`.
* It does not. The `if`'s body computes if `97` is a prime number and stores it in `prime_table`.
* `is_prime` returns `prime_table[97]`. We know for certain `97` is a valid key.
* Some time passes.
* We call `is_prime(97)` again.
* `is_prime` checks if `prime_table` contains an entry for `97`.
* It does, so the `if`-body can skipped.
* `is_prime` returns `prime_table[97]`, whose value has been computed the first time `is_prime(97)` was called.
