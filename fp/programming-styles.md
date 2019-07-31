---
layout: standard
---
# Programming Styles

When you write a programming in, say, JavaScript,
you are probably mixing different
styles of programming without realizing it.
Not that there's anything wrong with using different styles,
everyone does it. It's also impractical
to write code purely in a single style, given
that each style has distinct advantages and disadvantages.

However, being aware of programming styles,
and knowing which style to use in which circumstances,
might help you become a better programmer.

Before we start examining the different styles:
you should not expect clear cut definitions that
will allow you to label any piece of code as being
100% written in a particular style. There's a lot of vagueness
and impurities involved. To those who find this frustrating:
do not despair. What's important is what actual concepts
you use to build up your program, not how you label the final product.

Here's a short overview:

* Imperative programming
  * Procedural
  * Object-oriented
* Declarative programming
  * Functional
  * Logic

The imperative style focuses on telling the computer
*how* to produce a result. Typically, an imperative program
consists of a succession of instructions that have to be
executed in order. Writing in assembly is probably
the purest form of imperative programming.

The declarative style, however, describes what the final result
should look like and prefers not preoccupy itself with
how to get there.

To make this distinction clearer, let's apply these ideas
to a simple example.

## Example: Solving Sudokus

We assume you know what Sudoku puzzles are; if
you are not, please [familiarize yourself with them](https://en.wikipedia.org/wiki/Sudoku).

Imperative code would describe how to solve them.
For example, the following rules could be implemented:

* If a row only misses one number, add all present numbers together, subtract
  the total from 45: that's your missing number. Same for columns and for 3&times;3 block.
* For each square, keep a list of candidates 1-9. If a number appears in the same
  row, column or square, remove it from the list of candidates. Once there's
  only one candidate left, you know that must be the number that belongs in that square.

Let's now solve a Sudoku puzzle using a declarative style. As mentioned
before, we do not need to tell *how* to solve it, only to define
what it means for a puzzle to be solved. Our code would contain the following rules:

* There are 9&times;9 square.
* Each square contains a number between 1 and 9.
* No two squares in the same row, column or block should contain the same number.

Given only these rules, it's up to the computer to find the solution.
To give an actual concrete example, here's a simplified Prolog program that solves Sudokus:

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

While the above code works, Prolog does allow for more elegant solutions
than a hard-coded enumeration of constraints. We chose to favor readability;
a better implementation would be less understandable due
to Prolog's idiosyncratic syntax.

The code above makes Prolog look for values for the 81 variables
`Xij` (representing the squares of the Sudoku puzzle) so that
all constraints are satisfied. To solve a Sudoku puzzle, we can write:

```prolog
solve([[ 5, 3, _, _, 7, _, _, _, _ ],
       [ 6, _, _, 1, 9, 5, _, _, _ ],
       [ _, 9, 8, _, _, _, _, 6, _ ],
       [ 8, _, _, _, 6, _, _, _, 3 ],
       [ 4, _, _, 8, _, 3, _, _, 1 ],
       [ 7, _, _, _, 2, _, _, _, 6 ],
       [ _, 6, _, _, _, _, 2, 8, _ ],
       [ _, _, _, 4, 1, 9, _, _, 5 ],
       [ _, _, _, _, 8, _, _, 7, 9 ]]).
```

Admittedly, if you were to run this code in current
Prolog implementations, you'll probably
have to wait a very long time before you get your answer:
the algorithm first fills all empty squares with ones
and checks if all constraints are satisfied. If not, it
removes the last 1 and replaces it by a 2, and rechecks the constraints.
It goes on like this, trying out every possibility,
until it finds one that is a valid Sudoku solution.

One could reasonably say that the fact that it takes
forever to generate a result makes it useless.
This shortcoming is not inherent to Prolog itself, but to
Prolog compilers/interpreters: as of yet, they are
simply not smart enough to run it efficiently.
However, given the fact that the Sudoku problem
has been fully specified, it is theoretically possible
to write a compiler that is able to derive a smart
solving algorithm for it. It's just a matter of time
until we get there.

This idea is not that far fetched: remember that when
you first encountered Sudoku puzzles, the only
information you received is the same as what is encoded in the
above code. You were not given specific instructions of how
to solve the puzzle. Still you were able to devise
a solving algorithm on your own. If a human can do it,
so can a machine.

## Imperative Programming

When you're writing code, you're probably writing it
mostly in an imperative style. We distinguish two
"substyles":

* Procedural
* Object-Oriented

Imperative programming is characterized by the
fact that programs are long series of instructions
that need to be executed in the given order.
The way these instructions are organized is
what distinguished procedural from object-oriented programming.

### Procedural Programming

Procedural programming is quite old,
which often means it involves only basic concepts.

* Code is organized as a bunch of *procedures*, which are essentially the same
  thing as what you call functions.
* Related data is bundled in *records*, which are basically
  Java/C#/C++ objects containing public fields exclusively.

```c
// Example in C-like language

// Fraction record
struct Fraction
{
    int numerator;
    int denominator;
};

// Procedure for creating fractions
Fraction create_fraction(int numerator, int denominator)
{
    Fraction f;

    f.numerator = numerator;
    f.denominator = denominator;

    return f;
}

// Procedure to multiply fractions
Fraction multiply(Fraction a, Fraction b)
{
    Fraction f;

    f.numerator = a.numerator * b.numerator;
    f.denominator = a.denominator * b.denominator;

    return f;
}

// Usage
Fraction a = create_fraction(1, 2);
Fraction b = create_fraction(3, 4);
Fraction p = multiply(a, b);
```

### Object-Oriented Programming

The second "imperative substyle" is object-oriented
programming, which is a more
advanced form of procedural programming: functions
and the data are grouped into *objects*.

```c#
// Example in C#
class Fraction
{
    public Fraction(int numerator, int denominator)
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction Multiply(Fraction that)
    {
        var numerator = this.Numerator * that.Numerator;
        var denominator = this.Denominator * that.Denominator;

        return new Fraction(numerator, denominator);
    }

    public static Fraction operator *(Fraction left, Fraction right)
    {
        return left.Multiply(right);
    }
};

// Usage
Fraction a = new Fraction(1, 2);
Fraction b = new Fraction(3, 4);
Fraction p = a * b;
```

The goal is to provide better abstraction:
the data is hidden inside the object;
access to it must be mediated by the object's functions
(generally called methods in the OO world.)

Object-oriented programming is quite a large topic:

* Class based versus prototype based
* Inheritance vs composition
* Encapsulation

Fortunately, you should already be quite at ease with OO-programming,
so we need not delve into this particular programming style.

## Declarative Programming

As a quick reminder of the overall structure, we copy the overview from above:

* Imperative programming
  * Procedural
  * Object-oriented
* Declarative programming
  * Functional
  * Logic

In the declarative world, we distinguish two substyles: functional and logic programming.

### Logic Programming

Logic programming is quite different from what you're used to,
so different even that discussing it would lead us too far away
from our original goal, namely providing you with a context
in which to place functional programming.

A [short explanation](logic-programming.md) is included in a
separate file for those interested
in having a peek at a fundamentally different programming paradigm,
but it can be skipped; we will not refer to it in any way.

### Functional Programming

We could say that functional programming consists
of organizing your code as a bunch of functions,
but that wouldn't be very helpful, since
it is not clear how it would differ from procedural programming.

Since our goal is to examine functional programming in depth
and this text has grown large already,
we continue on a [fresh page](functional-programming).
