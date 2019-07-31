---
layout: standard
---
# Logic Programming

Disclaimer 1: this section is fully optional, only meant
to be read by the curious reader.

Disclaimer 2: Logic programming is rather exotic.
My knowledge of logic programming is quite limited:
Prolog is the only logic programming language I have any experience with,
so the explanation that follows may be biased towards Prolog.

## Inverting Functions

Let's take a closer look at functions. A function takes
input (in the form of parameters) and produces a result (its return value).
There is a clear direction here: given input, you get output.
Quite obvious really. But what if we could turn this around?

Let's take the function `AddTaxes`:

```csharp
double AddTaxes(double price)
{
    return price * 1.21; // Assuming 21% taxes
}
```

If we only have the price without taxes,
we can use this function to calculate the price with taxes:

```csharp
var priceWithTaxes = AddTaxes(priceWithoutTaxes);
```

But what if we have the price with taxes and want
to subtract taxes from it? We can't simply write

```csharp
500 = AddTaxes(var priceWithoutTaxes); // ???
```

Theoretically, the definition of `AddTaxes` contains enough information
to derive the inverse function from it. It's just that, in general, computer languages do not
have any support for inverting functions. The only way
to "go backward" is to define a new function `RemoveTaxes` that
performs the inverse computation.

But here comes Prolog...

## Predicates

Let's create a tabular overview of the inputs and outputs of `AddTaxes`.

|Equality|
|-|-|
|121 = AddTaxes(100)|
|242 = AddTaxes(200)|
|363 = AddTaxes(300)|
|484 = AddTaxes(400)|
|605 = AddTaxes(500)|

We reorganize this table as

|Input|Output|
|-|-|
|100|121|
|200|242|
|300|363|
|400|484|
|500|605|

We can see `AddTaxes` as a mapping
that associates `100` with `121`,
`200` with `242`, etc.
Instead of writing `121 = AddTaxes(100)`,
let's change the syntax to `AddTaxes(100, 121)`,
or more generally `AddTaxes(withoutTaxes, withTaxes)`,
meaning "`withoutTaxes` and `withTaxes` are related according to `AddTaxes`."
We are basically moving the return value
to the end of the parameter list.

But how would we use this "function"?
Say we want to calculate `AddTaxes(100)` and store it in a variable `result`,
how would we write this? Simple: `AddTaxes(100, result)` would
cause `121` to be assigned to `result`.

Let's now go crazy: `AddTaxes(result, 100)`.
The return value is specified, but the input is omitted!
In Prolog, this code would compute a value so that adding 21%
to it yields `100`. In other words, `result` gets set to `82.64`.

So there are no more return values, just a bunch of parameters
that must be related in some way. When calling
a "function", you pass along concrete values and "holes",
and the "function" will fill the holes based on the concrete values.
Using the name "function" is misleading in this context;
instead, Prolog uses the name *predicate*,
which it borrowed from the world of mathematical logic.

## Multifunctional String Concatenation

Let's apply this weirdness to string concatenation.
First, the straightforward way:

```prolog
concat("abc", "def", X).
X = "abcdef"
```

Now let's move the "hole" to the second position:

```prolog
concat("+32", X, "+32479132456")
X = "479132456"
```

In other words, this lets us get rid of a prefix.
We can also check if a string has a certain prefix:

```prolog
concat("https://", _, "http://youtu.be/s7AXskSxxMk")
false
```

As you can see, a single predicate can be used in many different ways.

## Nondeterminism

Take the `sqr(X, Y)` predicate that relates a number and its square:
`sqr(1, 1)`, `sqr(2, 4)`, `sqr(3, 9)`, etc. We can use it to square a
number as follows:

```prolog
sqr(5, X).
X = 25
```

Let's now turn it into a square root:

```prolog
sqr(X, 25).
```

What should `X` receive as value, given that both `5` and `-5` are valid solutions.
What happens is that the universe splits in two:
one in which `X` equals 5 and the other where it equals `-5`.
And by "universe" we of course mean "the universe within the Prolog system."

It is possible to blow up a universe: this is where `false` comes into play.
If you encounter `false`, i.e., if you pass values to a predicate
that do not belong together such as `sqr(1, 100)`, the current universe will collapse.

For example, if you are only interested in the positive square root,
you'd write

```prolog
sqr(X, 25),
X >= 0.
```

The `sqr` line splits the universe in two, one where `X = 5`, one with `X = -5`.
In both universes `X >= 0` is checked. The first universe survives, the second collapses.
In the end, you get a single result: `X = 5`.

Let's apply this principle to a few examples.

## Maximum

```prolog
maximum(Xs, R) :-
    member(R, Xs),
    forall(member(X, Xs), R >= X).
```

The first line of `maximum`'s body will bind `R` nondeterministally
to all elements of `Xs`, i.e., for each element of `Xs`,
a parallel universe is created in which `R` is equal to that element.
Next, we check that `R` is greater than all members of `Xs`. If this
is not the case, the current universe is destroyed.

## Sudoku

```prolog
solve( [ [ X11, X21, X31, X41, X51, X61, X71, X81, X91 ],
         [ X12, X22, X32, X42, X52, X62, X72, X82, X92 ],
         [ X13, X23, X33, X43, X53, X63, X73, X83, X93 ],
         [ X14, X24, X34, X44, X54, X64, X74, X84, X94 ],
         [ X15, X25, X35, X45, X55, X65, X75, X85, X95 ],
         [ X16, X26, X36, X46, X56, X66, X76, X86, X96 ],
         [ X17, X27, X37, X47, X57, X67, X77, X87, X97 ],
         [ X18, X28, X38, X48, X58, X68, X78, X88, X98 ],
         [ X19, X29, X39, X49, X59, X69, X79, X89, X99 ] ]) :-
    between(1, 9, X11),
    between(1, 9, X21),
    between(1, 9, X31),
    ...
    between(1, 9, X99),
    X11 =\= X21,
    X11 =\= X31,
    X11 =\= X41,
    ...
    X89 =\= X99.
```

First, `X11`, the variable corresponding to the upper left
square, is nondeterministically set to values from `1` to `9`,
i.e. 9 parallel universes come into existence.

Next, the same is done for `X21`, so we get 9&times;9 universes.
This is repeated for all squares. You can probably guess
this generates a gigantic amount of universes
(1966270504755529136180759085269121162831034509442147669273154155379663\
91196809 to be exact.) Next, the Sudoku constraints are verified.
Only those universes with valid solutions remain in existence.

By binding some `Xij` variables before calling solve, you
can force those squares to contain certain values.
Say `X11` is set to `5`, then `between(1, 9, X11)` will simply
check that `X11` is indeed between `1` and `9`, which is the case.

Of course, it is possible to rewrite the program in a way
that avoids such an exponential explosion of universes.
The most straightforward way would be to insert the constraints checking
in between the binding parts:

```prolog
solve( [ [ X11, X21, X31, X41, X51, X61, X71, X81, X91 ],
         [ X12, X22, X32, X42, X52, X62, X72, X82, X92 ],
         [ X13, X23, X33, X43, X53, X63, X73, X83, X93 ],
         [ X14, X24, X34, X44, X54, X64, X74, X84, X94 ],
         [ X15, X25, X35, X45, X55, X65, X75, X85, X95 ],
         [ X16, X26, X36, X46, X56, X66, X76, X86, X96 ],
         [ X17, X27, X37, X47, X57, X67, X77, X87, X97 ],
         [ X18, X28, X38, X48, X58, X68, X78, X88, X98 ],
         [ X19, X29, X39, X49, X59, X69, X79, X89, X99 ] ]) :-
    between(1, 9, X11),
    between(1, 9, X21),
    X11 =\= X21,
    between(1, 9, X31),
    X11 =\= X31,
    X21 =\= X31,
    ...
```

We can go on improving the code.
In the end we could get (taken from [here](https://michal.muskala.eu/2017/01/25/sudoku-solver-in-prolog.html)):

```prolog
:- use_module(library(clpfd)).

sudoku(Puzzle) :-
    flatten(Puzzle, Tmp), Tmp ins 1..9,
    Rows = Puzzle,
    transpose(Rows, Columns),
    blocks(Rows, Blocks),
    maplist(all_distinct, Rows),
    maplist(all_distinct, Columns),
    maplist(all_distinct, Blocks),
    maplist(label, Rows).

blocks([A,B,C,D,E,F,G,H,I], Blocks) :-
    blocks(A,B,C,Block1), blocks(D,E,F,Block2), blocks(G,H,I,Block3),
    append([Block1, Block2, Block3], Blocks).

blocks([], [], [], []).
blocks([A,B,C|Bs1],[D,E,F|Bs2],[G,H,I|Bs3], [Block|Blocks]) :-
    Block = [A,B,C,D,E,F,G,H,I],
    blocks(Bs1, Bs2, Bs3, Blocks).
```
