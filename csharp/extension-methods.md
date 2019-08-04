---
layout: standard
---
# Extension Methods

The goal of this course is to teach you non-language specific
concepts. Extension methods, however, are not a particularly interesting
topic. To the best of my knowledge, only [C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
and [Kotlin](https://kotlinlang.org/docs/reference/extensions.html) support them.
The reason we take a look at them anyway is simply because
they make your code so much more readable
and simplify writing functional code.

## Problem Statement

The [`IEnumerable<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=netframework-4.8)
type appears often in C# code: it is a list of `T` objects, but it is very limited in its functionality: it only allows you to iterate
over it. There is no indexing, adding, removing, no counting elements, etc.
(Cake question: what's the point of having such a limited interface?)
Given an `IEnumerable<T>`, your only choice would essentially be to let a `foreach` loop loose on it:

```csharp
void Foo(IEnmumerable<int> ns)
{
    foreach ( var n in ns )
    {
        // ...
    }
}
```

At some point in time (around 2007), some people decided
that `IEnumerable<T>` could use more functionality.
These is plenty of useful things you could do with an `IEnumerable<T>`:

* Count the number of elements.
* Selecting elements satisfying a certain condition.
* Dropping the n first elements.
* Checking if all elements satisfy a certain condition.
* ...

Where to put all this functionality?

Given that it concerns functionality operating
on an `IEnumerable<T>`, it would make sense
to add it as methods to `IEnumerable<T>`.
However, this is quite problematic:

* All existing classes implementing `IEnumerable<T>` would
  not compile anymore, since they lack the newly added methods.
* Every subtype of `IEnumerable<T>` would be forced to
  define an implementation for the new methods,
  but the exact same implementation can be reused.

As a result, developers would essentially be expected
to start copy pasting the same code all over the place
to make everything compile again.

For example, consider size: an `IEnumerable<T>`
has no method or property that lets you ask
how many elements in has. We can easily implement it:

```csharp
int Count<T>(IEnumerable<T> xs)
{
    var count = 0;

    foreach ( var x in xs )
    {
        count++;
    }

    return count;
}
```

This implementation is valid for all subtypes of `IEnumerable<T>`;
it makes no sense to repeat this code for `List`s, `Set`s, `Dictionary`s, etc.

So, our only solution would be to define `Count` as a static method in a separate class:

```csharp
public class Util
{
    public int Count<T>(IEnumerable<T> xs)  { ... }
}
```

`Util` could be a haven for all "missing functionality":
`string` lacks some method you'd like? Dump it in `Util`!

While this approach works, it has its deficiencies. For example,
the OO-syntax is particularly IDE-friendly: when you type
`obj.`, the IDE knows the type of `obj` (thanks to static typing),
is able look up its members and present them to you in a list.
Working with a separate `Util` class prevents this:
you'd first type `obj.`, look through the list, conclude
that some method is not there, erase `obj` and type `Util`,
get a long list of methods, most of whom have nothing to do with `obj`, etc.

## Java's Solution

Java's solution is to add [default methods](https://docs.oracle.com/javase/tutorial/java/IandI/defaultmethods.html) to the language:
interface methods *can* have bodies since version 8,
which act as the default implementation for that method.
A class can opt to override it. Basically,
an interface has become more like an abstract class
(but fields are still not allowed).

Java's default method allowed the designers
to add extra methods to existing interfaces without
breaking existing code. Unfortunately,
this still does not allow *us* to add more functionality.

## C#'s Solution

C# allows to define static methods in a class and declare them to be
*extension methods* of a certain type. The static methods
will then appear to be members of that type.

For example, say we want to add `Count()` to `IEnumerable<T>`.
This is achieved with the following code:

```csharp
public static class Util
{
    public static int Count<T>(this IEnumerable<T> xs)
    {
        var count = 0;

        foreach ( var x in xs )
        {
            count++;
        }

        return count;
    }
}
```

Take note of the following details:

* The class itself is static. A static class is simply a class with only static members. Extension methods must reside in a static class.
* The extension method itself must be static.
* The first parameter has `this` in front of it. This indicates which type should be extended.
* The static class can have any name you want.

You can add new methods to any type you wish. You can even
target specific type parameters if you wish. For example, a `Sum()` method only makes
sense of addable types, e.g., `int` and `double`. You cannot define `Sum()` on
`IEnumerable<T>`: you would have to be able to apply `Sum` on any `T`, such as `bool`s.
What you can do is define `Sum()` specifically on `IEnumerate<int>` and `IEnumerate<double>`:

```csharp
public static class Util
{
    public static int Sum(this IEnumerable<Tint> ns)
    {
        return ns.Aggregate(0, (x, y) => x + y);
    }

    public static double Sum(this IEnumerable<double> ns)
    {
        return ns.Aggregate(0, (x, y) => x + y);
    }
}
```

## Limitations

Extension methods have some limitations, all of which are a consequence
of the fact that extension methods are merely static methods in disguise:

* An extension method cannot access nonpublic members. This makes sense, since otherwise extension methods
  could be used to get clandestine access to private data.
* Extension methods cannot be overridden.
* Whether or not an extension method is available is dependent on the static type. For example, say you
  extend `string` with a method `Foo`, and you have a variable `object x = "abc"`.
  While `x`'s dynamic type is a `string`, this is not taken into account: only the static type matters,
  which in this case is `object`, so `Foo` will not be available.
