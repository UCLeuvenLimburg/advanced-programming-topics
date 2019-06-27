# The Expression Problem

As you should know, software should be built
such that it is possible to extend it safely, meaning
without breaking the existing codebase.
Ideally, an extension should not require any changes to existing code:
it works and any changes made to it might "damage" it.
Also, it sometimes simply is not possible
to change existing code, for example due to their being
part of some library you don't have the source code of.

Programming language designers endeavor to provide
the necessary building blocks to enable you
to write extensible code without too much effort.
Object oriented programming is a nice example of this.
However, there are multiple ways of extending code,
and OO tends to assume changes are made
one particular way.
Functional programming also
has extensibility in mind, but it focuses on extension
in a different "direction" than OO. In this section,
we'll show you a couple of examples of how OO and FP
are in "orthogonal" to each other, how they focus
on different aspects of extensibility.

## Working Example

Let's take our trusty old friend out of our example drawer: the shape hierarchy.
We consider the following types of shape:

* Circle
* Square
* Triangle

The following operations can be performed on shapes:

* Compute surface
* Compute area
* Check if point is inside shape

## The Wrong Way

Let's first implement this shape functionality the wrong way.
Coming from a OO background, you probably heard of `instanceof` (Java),
`is` (C#), `typeid` (C++), `type` (Python), etc. They each
make it possible to determine the type of an object at runtime.
You probably also heard how you should avoid them,
that they're bad. It's basically taboo to rely on them.
Almost as bad as `goto`!

So, let's indulge in a bit of guilty pleasure and use it anyway.
For now, we only implement `Circumference` and `Area` for `Circle` and `Square`.
We keep it straightforward and don't bother with encapsulation and stuff:

```c#
// C#
public abstract class Shape
{
    public double Circumference
    {
        get
        {
            if ( this is Circle )
                // Deal with circles
            else
                // Deal with squares
        }
    }

    public double Area
    {
        get
        {
            if ( this is Circle )
                // Deal with circles
            else
                // Deal with squares
        }
    }
}

public class Circle : Shape
{
    public Point2D Center;
    public double Radius;
}

public class Square : Shape
{
    public Point2D UpperLeftCorner;
    public double Side;
}
```

Please excuse me while I go scrub my hands.

The above code certainly works. For now. Say we introduce the `Triangle`
class, but nothing else:

```c#
public class Triangle : Shape
{
    public Point2D[] Vertices;
}
```

After this addition, the code will still compile. However, say we write the following:

```c#
var triangle = new Triangle();
var surface = triangle.Surface;
```

Running this will throw a `InvalidCastException` in your face.
The `if` checks whether `shape` it is a `Circle`, and if it is not,
the code simply assumes it is a `Square`, causing the crash.
Note that the `InvalidCastException` is not particularly useful
to the user: only if he understands the internal implementation
of `Shape` can he understand the reason for the exception.

We fix the code so that `Circumference` and `Surface` work correctly for `Triangle`s.

```c#
public abstract class Shape
{
    public double Circumference
    {
        get
        {
            if ( this is Circle )
                // Deal with circles
            else if ( this is Square )
                // Deal with squares
            else if ( this is Triangle )
                // Deal with triangles
            else
                throw new NotSupportedException();
        }
    }

    public double Area
    {
        get
        {
            if ( this is Circle )
                // Deal with circles
            else if ( this is Square )
                // Deal with squares
            else if ( this is Triangle )
                // Deal with triangles
            else
                throw new NotSupportedException();
        }
    }
}

public class Circle : Shape
{
    public Point2D Center;
    public double Radius;
}

public class Square : Shape
{
    public Point2D UpperLeftCorner;
    public double Side;
}
```

Note the following:

* We've added support for `Triangle`s in `Circumference` and `Area`.
  This required us to break open existing code and modify it.
* The code now throws `NotSupportedException` in case it does
  not recognize the shape's type. This is much more informative
  and certainly an improvement.

The issue with this approach (i.e., using `is`/`instanceof`)
is that the compiler does not help us at all: when adding
a new type of shape, it still happily compiles our code.
In this example, finding the pieces of code that require
an update is simple, but imagine you have dozens such
methods relying on `is`/`instanceof`, you'd have to find
them all in order to have a working application.
Unfortunately, an oversight so easily happens in these situations.

What we want is a pedantic compiler that checks that
we did indeed made all the necessary additions to our
code. When adding a new type, we want to simply recompile the code
and have the compiler give us a series of "Missed a spot!" errors,
pointing out all locations that require our attention.

In other words, let the compiler do the work. Be lazy.

## Object Oriented Solution

Let's now fix this code using sound OO principles.

```c#
public abstract class Shape
{
    public abstract double Circumference { get; }
    public abstract double Area { get; }
}

public class Circle : Shape
{
    public Point2D Center;
    public double Radius;

    public override double Circumference => /* compute circumference */;
    public override double Area => /* compute area */;
}

public class Square : Shape
{
    public Point2D UpperLeftCorner;
    public double Side;

    public override double Circumference => /* compute circumference */;
    public override double Area => /* compute area */;
}
```

Now the `Shape` superclass only contains abstract properties.
Subclasses each override them with their own implementation.
This is rather standard stuff, but let's examine *why* it's standard stuff.

Say we add `Triangle` as follows:

```c#
public class Triangle
{
    public Point2D[] Vertices;
}
```

* If we call `Area` directly on `Triangle`, the compiler will
  complain about a nonexisting property.
* If we intend to call `Area` indirectly through `Shape`,
  we'll get an error at the location where we pretend
  a `Triangle` is a `Shape`, e.g. when passing a
  `Triangle` object to a method expecting a `Shape`.

In each of these cases, the compiler points out that we made a mistake.

Let's "fix" our code by merely inheriting from `Shape`:

```c#
public class Triangle : Shape
{
    public Point2D[] Vertices;
}
```

The previous errors will disappear: calling `Area` on a `Triangle` object
is valid, as is upcasting a `Triangle` to `Shape`. However,
another kind of compiler error pops up: `Triangle` is missing
implementations for `Circumference` and `Area`.

We could solve the problem by making `Triangle` abstract,
which again makes all previous complaints disappear and make
place for a new kind of error: all occurrences of `new Triangle()`
will be flagged as forbidden, since you are not allowed to
instantiate abstract classes.

As you can see, by making your intents known,
the compiler can check for mistakes.
From a technical point, much code is not really necessary
for a functioning program:

* Python, Ruby and JavaScript have no concept of abstract methods.
  A subclass can simply add new methods, and if a method
  with the same signature exists in the superclass, it will be overridden.
  However, those languages are not able to warn
  you if you forgot to implement certain mandatory methods, or
  if you misspelled the method name.
* C++ has no way to mark a class as abstract. It is simply inferred
  from whether all methods are implemented or not.
  An error only appears after you try to instantiate the "de facto abstract class".
  It would be more helpful if a compiler would immediately
  recognize your class as incomplete.
* Java originally did not have an `@Override` annotation.
  If you accidentally miswrote a method's name,
  you'd get unexpected results at runtime. The `@Override`
  lets you convey your intent, which allows the compiler
  to identify typos for you.

All these language features (`override`, `abstract`, etc.) exist
to help you find your mistakes as quickly as possible.

So, to conclude:

* OO language allow you to easily add new types without
  having to modify existing code. All additions
  are grouped together in a separate class.
* Statically checked languages (C#, Java, C++) perform all kinds
  of checks to ensure that your new class fits well into the hierarchy.

But where do OO languages go wrong, then?

## Limitations of OO

In the previous section we showed how we could
introduce a new type (`Triangle`) to an existing
hierarchy without touching existing code.
What happens though if we try to add extra functionality,
such as `IsInside`? It would involve adding an
abstract method to `Shape` and override it in all subclasses.
In other words, existing classes need to be modified.

So, OO allows us to easily add new types, but
adding new operations is not as simple.

## The Functional Way

Whereas using `is`/`instanceof`/... or whatever
means to determine the type of an object at runtime
is often taught as bad practice in OO languages, it is
actually the standard modus operandi in functional programming
languages. This proves how rules are very context dependent
and shows why it is important to know the reasoning
behind each rule you follow. In this section, we show
why this "controversial" approach is safe to use in
functional programming languages.

First, you need to know how hierarchies such as `Shape`
are typically defined in typical functional languages (Haskell, O'Caml, F#, ...)
The concept has many names (tagged union, discriminated union,
sum type, inductive type...) but at its core the idea is very simple:

```haskell
data Shape = Circle Point2D Float
           | Square Point2D Float
```

This should be interpreted as follows:

* We define a new data type `Shape`.
  This corresponds to OO's supertype.
* There are two possible shapes: `Circle` and `Square`.
  These correspond to OO's subclasses.
* A `Circle` has a `Point2D` (the center) and a `Float` part (the radius).
  These correspond to the fields of the OO `Circle` subclass.
* Similarly, a `Square` has a `Point2D` and a `Float`, designating
  the upper left corner and the size of the square.

In other words, `Shape` is some kind of smart enum.

Let's now define the operations on shapes:

```haskell
area (Circle center radius) = ...
area (Square corner side)   = ...

circumference (Circle center radius) = ...
circumference (Square corner side)   = ...
```

As you see, the functions `area` and `circumference`
are defined as some kind of `switch` over possible shapes:
the first line defines `area` for `Circle`, next
comes the `area` for `Square`. This is basically
the same thing as a chain of `is`/`instanceof`s.

Adding extra functionality is simply a matter
of defining a new function:

```haskell
isInside (Circle center radius) pt = ...
isInside (Square center radius) pt = ...
```

As you can see, contrary to OO, this does not
require any changes to existing code. However,
if we were in the mood for an extra shape,
we'd have to update the definition of `Shape` as well
as all functions operating on shapes:

```diff
  data Shape = Circle Point2D Float
             | Square Point2D Float
+            | Triangle [Point2D]

  area (Circle center radius) = ...
  area (Square corner side)   = ...
+ area (Triangle vertices)    = ...

  circumference (Circle center radius) = ...
  circumference (Square corner side)   = ...
+ circumference (Triangle vertices)    = ...
```

In summary:

* OO groups code related to the same data together, allowing to add new types easily.
* FP groups code related to the same functionality together, allowing to add new functions easily.

## Solutions to the Expression Problem



* `dynamic` in C#
* visitor design pattern