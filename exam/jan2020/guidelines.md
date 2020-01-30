# Guidelines

Solve all the exercises in a functional way:

* No state allowed! Do not overwrite variables, do not use loops.
* Do not use recursion, but rely on higher order functions such as map, reduce, filter, ... or however they're called in your language of choice.
* You are free to define auxiliary functions. It should be obvious that these also need to be written in functional style.
* If you want to focus on a single exercise, you can deactivate tests by commenting them out in the list of tests that appears just below your solutions.

## C#

Open the file `Program.cs` and write your solutions in the class `Solutions`.

There are two ways to run the tests:

* Command line: run `dotnet run` under `csharp/Tests`.
* Visual Studio: run it like a regular application (do NOT use the Test Explorer - I didn't make use of a testing library).

Use `IEnumerable` extension methods to solve the exercises. You can also rely on Linq. A couple of examples:

* `xs.Select(x => x * 2)`
* `from x in xs select x * 2`
* `xs.Where(x => x >= 0)`

Some hints:

* When working with dictionaries, know that you can retrieve a list (`IEnumerable`) of keys using `Keys`.
  Similarly, `Values` returns a list of `Values`.
* `HashSet`s can help you remove duplicates if the need arises.
* Use `OrderBy` to sort. If you need to sort the element themselves (and not by some property), use `OrderBy(x => x)`.

## Python

Open the file `tests.py` and write your solutions in the designated area at the top of the file.

To run the tests: `python tests.py`. I have used version 3.7.4, but I assume it will also work on Python 3.6.

You can use comprehensions as well as the typical `map`, `reduce`, ... functions. You might need to import `functools`. Only rely on the standard library.

Examples:

* `[ n ** 2 for n in range(k) ]`
* `map(lambda x: x ** 2, range(k))`
* `[ n for n in ns if n >= 0 ]`

Some hints:

* Use `set(xs)` to remove duplicates if need be.
* You can use `(key, val) in dictionary.items()` to iterate over `(key, value)` pairs.
* Do not rely on `sort` as it is stateful. Use `sorted` instead.
* Use `dictionary.get(key, default)` for an easy way to deal with missing keys.
* Use `//` for integer division.

## Ruby

Open the file `tests.rb` and write your solutions in the designated area at the top of the file.

To run the tests: `ruby tests.rb`. I have made use of Ruby 2.6.4, but it should work on older versions.

## JavaScript

Open the file `tests.js` and write your solutions in the designated area at the top of the file.

To run the tests: `node tests.js`. I have made use of NodeJS 12.8.0, but it should work with on older versions.

Some hints:

* `Object.keys(o)` returns a list of the keys of the object `o`.
* `Object.entries(o)` returns a list of `[key, value]` pairs in `o`.
* To remove duplicates from a list `xs`, you can use `nodup(xs)`.
* If you need to sort an array `xs`, you cannot use `xs.sort()` since that would be stateful. JavaScript doesn't come with a built-in functional sort function, so I've provided an alternative: use `sort(xs)`.
* To find the minimum of an array `xs`, use `Math.min(...xs)`.
* Use the provided function `maxBy(xs, key)` to find the `x` of `xs` for which `key` returns the greatest value.
