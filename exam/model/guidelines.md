# Guidelines

Solve all the exercises in a functional way:

* No state allowed (don't overwrite variables)
* Do not use recursion, but rely on higher order functions such as map, reduce, filter, ... or however they're called in your language of choice.

## C#

Open the file `Program.cs` and write your solutions in the class `Solutions`.

There are two ways to run the tests:

* Command line: run `dotnet run` under `csharp/Tests`.
* Visual Studio: run it like a regular application (do NOT use the Test Explorer - I didn't make use of a testing library).

Use `IEnumerable` extension methods to solve the exercises. You can also rely on Linq. A couple of examples:

* `xs.Select(x => x * 2)`
* `from x in xs select x * 2`
* `xs.Where(x => x >= 0)`

.NET can be picky when it comes to versions. You can either install the exact same version as I have,
or you can modify the version yourself (e.g. by directly modifying the `Tests.csproj` file.)

## Python

Open the file `tests.py` and write your solutions in the designated area at the top of the file.

To run the tests: `python tests.py`. I have used version 3.7.4, but I assume it will also work on Python 3.6.

You can use comprehensions as well as the typical `map`, `reduce`, ... functions. You might need to import `functools`. Only rely on the standard library.

Examples:

* `[ n ** 2 for n in range(k) ]`
* `map(lambda x: x ** 2, range(k))`
* `[ n for n in ns if n >= 0 ]`

## Ruby

Open the file `tests.rb` and write your solutions in the designated area at the top of the file.

To run the tests: `ruby tests.rb`. I have made use of Ruby 2.6.4, but it should work on older versions.

## JavaScript

Open the file `tests.js` and write your solutions in the designated area at the top of the file.

To run the tests: `node tests.js`. I have made use of NodeJS 12.8.0, but it should work with on older versions.
