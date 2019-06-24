---
layout: default
---
# Functional Programming in Java

Since version 8, Java provides some support for functional programming
by the introduction of

* Lambdas
* Interface default methods, enabling the addition of functional methods to existing types.

However, due to dubious choices made in the past, functional
programming in Java is somewhat clunkier than it should be.
Therefore, to be able to better explain how functional
programming works in Java, we first take a quick look
at the technical details behind Java's generics.

## Type Erasure

Let's first start with a quick explanation of how generics
work in Java. This will explain some of the stranger things
that we will encounter along the way.

Generics were added in Java 5. Before that,
`ArrayList<T>` was just `ArrayList` and similarly
for all other generic classes you might now.
Instead of being able to specify a type `T`,
everything would simply be an `Object`. In other
words, all typing information was lost:
once you put something in an `ArrayList`,
its type would be "forgotten".
When retrieving it, you would get an `Object`,
which you had to subsequently cast to the correct type.

For example, consider the code below.

```java
// Java 5
ArrayList<Integer> numbers = new ArrayList<>();
numbers.add(5);
int value = numbers.get(0);
```

Prior to the addition of generics to Java, you
would have to write

```java
ArrayList numbers = new ArrayList();

// No autoboxing: you had to explicitly create an Integer object
numbers.add( new Integer(5) );

int value = ((Integer) numbers.get(0)).intValue();
```

The addition of generics allowed programmers
to write more robust programs: types would
be preserved and the compiler would be able
to better check your code for bugs.

Adding generics to the Java language would normally
mean that the JVM would also need an update.
However, Sun (the company behind Java, which has since
then been taken over by Oracle) chose not to do this
in order to preserve backward compatibility.
Instead, they chose to implement generics
with a technique known as *type erasure*.

Java's generics only exist in your code. The Java compiler
understands them, checks them, but then removes them:
it replaces the `T`s with `Object`s and add casts everywhere.
In essence, the compiler rewrites your Java 5+ code
to Java 4 code, which then gets translated to bytecode,
which in its turn can be understood by the JVM.

## Consequences of Type Erasure

While type erasure has the advantage of being backward compatible
with non-generic code, it suffers from many limitations.
We will discuss only those relevant to functional programming.

A first limitation of Java generics is that they
can only be used with reference types.
Creating an `ArrayList<int>` is impossible:
`int` would be replaced by `Object`,
and `int` and `Object` are not compatible.
Instead, you need to use `ArrayList<Integer>`.

A second limitation is that you can't reuse
the same class name, but with different number
of type parameters. For example,
say you want to define tuples, i.e.,
an object that can hold multiple other
objects of different types:

```java
class Tuple2<T1, T2>
{
    public T1 t1;
    public T2 t2;
}

class Tuple3<T1, T2, T3>
{
    public T1 t1;
    public T2 t2;
    public T3 t3;
}
```

Here, we've defined `Tuple2<T1, T2>` to hold two elements
and `Tuple3<T1, T2, T3>` to hold three. It would
make more sense to simply reuse the same name `Tuple`,
e.g., `Tuple<T1, T2>` and `Tuple<T1, T2, T3>`,
and have the number of type parameters determine
which size the tuple has.

The fact that you need to use slightly different names
might seem like a minor inconvenience, but
later we'll show how these limitations
will work together to make your life significantly more difficult.

## Functions

In order to better understand how functions work in Java 8+,
let's first examine how equivalent functionality
could be coded in Java 7-. This will come in handy,
since Java 8 applies the same trick as for generics:
the compiler translates Java 8 code to Java 7 code,
thereby preserving backward compatibility.

Say you have a list whose elements you wish to square:

```python
# Python
def square_elements(ns):
    return map(lambda x: x**2, ns)
```

How would we model the `lambda x: x**2` in Java?
Since (almost) everything is an object in Java,
we need to see a function as an object.
An object is defined by what operations/methods
are defined upon it. So, the new question becomes,
what are the ways we can interact with a function?

In essence, a function only allows a single operation
to be performed: it can be *called*. In Python syntax:

```python
# Python
func = lambda x: x**2

func(4) # Evaluates to 16
```

Let's translate this into Java:

```java
class SquaringFunction
{
    public int call(int x) { return x * x; }
}
```

We've now hardcoded a specific function. We can easily imagine other functions:

```java
class IncrementingFunction
{
    public int call(int x) { return x + 1; }
}

class DoublingFunction
{
    public int call(int x) { return x * 2; }
}

// and so on
```

We can define a common interface for these functions. Let's call it
a `IntegerFunction`, by lack of inspiration.

```java
class IncrementingFunction implements IntegerFunction
{
    public int call(int x) { return x + 1; }
}

class DoublingFunction implements IntegerFunction
{
    public int call(int x) { return x * 2; }
}

class SquaringFunction implements IntegerFunction
{
    public int call(int x) { return x * x; }
}
```

TODO


## Lambda Syntax

Java Lambdas have the following syntax:

```java
(T1 arg1, T2 arg2) -> { body }
```

Depending on the whether the context allows the parameter types
to be inferred, this can be simplified to

```java
(arg1, arg2) -> { body }
```

If the body consists of a single `return expression;` statement,
it can further be simplified to

```java
(arg1, arg2) -> expression
```

If there only a single argument, the parentheses can be omitted:

```java
arg -> expression
```

## Function Objects

When writing down a lambda, Java translates it to full-fledged object for you.






* Type erasure
* `java.util.functional`
* Lambdas, functional interfaces, effectively final
* Wonky closures
* Streams
* Checked exceptions
