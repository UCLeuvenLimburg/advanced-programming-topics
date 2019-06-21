---
layout: standard
mathjax: true
---

# Functional Programming

Normally, this would be the place to provide you with
a clear definition of what functional programming entails.
Well, to be perfectly honest, we're not really sure such a definition exists.
In our experience, it seems that different people mean
different things by it, but luckily,
their different definitions do tend to revolve around
the same core principles, which are

* Stateless programming
* Higher order functions

## Stateful and Stateless

Consider for example the two pieces of JavaScript code below,
both of which reverse a list:

```javascript
function reverse1(xs)
{
    for ( let i = 0; i < xs.length / 2; ++i )
    {
        const j = xs.length - i - 1;
        const x = xs[i];
        xs[i] = xs[j]
        xs[j] = x;
    }
}
```

```javascript
function reverse2(xs)
{
    if ( xs.length === 0 ) return [];
    else
    {
        const [ first, ...rest ] = xs;
        return [ ...reverse(rest), first ];
    }
}
```

One obvious difference between both approaches is that
`reverse1` is an iterative algorithm, i.e., it relies on loops,
whereas `reverse2` is recursive. But that is not what we want to focus on.

Another difference, one that matters more to the subject at hand,
is that both algorithm actually perform slightly different tasks:

* `reverse1` takes a list `xs` and *modifies* it.
* `reverse2` leaves its parameter unchanged and returns a *new* list.

A *stateful* algorithm is one that performs modifications.
Conversely, a *stateless* approach leaves everything untouched but instead returns a new
value.

## Stateless: Where Have I Seen It Before

During your previous programming adventures, you've encountered
both stateful and stateless styles, perhaps without realizing it.

For example, in most programming languages
(e.g. Python, Java, C#, JavaScript, Ruby, ...), strings are stateless, or,
if you prefer other terminology, strings are immutable, or unmodifiable.
In essence, it simply means that strings cannot be modified in any way.
If you don't believe us, feel free to check out the documentation:

* [Python](https://docs.python.org/3/library/stdtypes.html#string-methods)
* [Java](https://docs.oracle.com/javase/9/docs/api/java/lang/String.html)
* [C#](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.8#methods)
* [JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String)

Take the Python's `string.lower()` method, which transforms all letters
to lowercase. A typical mistake is to write

```python
# Python
s = "Hello World"
s.lower()
print(s)
```

This code prints `"Hello World"`. This is because `lower()` does not modify
`s`, it simply returns a new string `"hello world"`. A correct version of the code above
would be

```python
# Python
s = "Hello World"
s = s.lower()
print(s) # Prints "hello world"
```

## But Why Stateless

You might wonder why strings have been made stateless. Clearly
it consumes more memory! A stateful implementation would be much more memory efficient... right?

There are actually multiple situations where creating new strings is more efficient.
Consider the following code:

```java
// Java
class Person
{
    private String name;

    public Person(String name)
    {
        setName(name);
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        if ( name == null || this.name.length == 0 )
        {
            throw new IllegalArgumentException();
        }

        this.name = name;
    }
}
```

A `Person` has a `name`, which must not be empty, as enforced by `setName`.
It is therefore `Person`s responsibility to "protect" `name`
to ensure `name` stays valid.

The code above is only correct is strings are immutable.
Imagine that `String` had a `clear()` method that would
set the `String` object to `""`. We could then write

```java
Person person = new Person("Sophie");
person.getName().clear();
```

Due to the fact that `getName()` gives the caller direct access to the `Person`'s `name`,
he would be able to change it, while `Person` being none the wiser. The only
safeguard against this would be to copy the string. Let's pretend `String` offers
a `copy()` method, so that we can correct our code:

```java
// Java
class Person
{
    private String name;

    public Person(String name)
    {
        setName(name);
    }

    public String getName()
    {
        return name.copy();
    }

    public void setName(String name)
    {
        if ( name == null || this.name.length == 0 )
        {
            throw new IllegalArgumentException();
        }

        this.name = name;
    }
}
```

This, however, is not enough to keep the `Person`'s `name` safe:

```java
String name = "Kevin";
Person person = new Person(name);
name.clear();
```

We need to perform some more copies:

```java
// Java
class Person
{
    private String name;

    public Person(String name)
    {
        setName(name);
    }

    public String getName()
    {
        return name.copy();
    }

    public void setName(String name)
    {
        if ( name == null || this.name.length == 0 )
        {
            throw new IllegalArgumentException();
        }

        this.name = name.copy();
    }
}
```

It might seem that as long as you don't act
as if you want to break things on purpose, everything will be fine.
However, this is a naive mindset: we can assure you it's all too easy
to accidentally make a mistake, especially if you
come back to some code you've written weeks or months ago.
Before you know it, some part of your code modifies
an object that's also being used by another, completely unrelated piece of code,
leading it to misbehave. This kind of bug is infuriatingly hard to find and fix.

Now that we've rewritten `Person` so as to make copies of `name` everywhere,
surely there is no way to surreptitiously change the `Person`'s name to
an invalid value. Sorry to disappoint you...

```java
String name = "Martin";
new Thread(() -> { name.clear() }).start();
Person person = new Person(name);
```

If the timing is exactly right, it is possible that `name` is cleared
between the moment it is checked and the moment it is copied.
We fix this as follows:

```java
// Java
class Person
{
    private String name;

    public Person(String name)
    {
        setName(name);
    }

    public String getName()
    {
        return name.copy();
    }

    public void setName(String name)
    {
        name = name.copy();

        if ( name == null || this.name.length == 0 )
        {
            throw new IllegalArgumentException();
        }

        this.name = name;
    }
}
```

You might think this is a bit far fetched and that the user is clearly asking for trouble,
but keep in mind that in other situations, `Person` could be a more security related class
and that the user could be maliciously attempting to subvert the system's integrity.

The above examples should convince you (at least a little bit) that immutable
strings do simplify your life: you do not need to make sure you copy them everywhere
at the right times, lest you want hard to track bugs to show up. Also note
that immutable strings actually lead to more efficient code, since
you do not need to constantly copy them.

There's one more reason why stateless objects can be more efficient: it allows for object reuse.
Say, for example, that you have a large string S from which you want to extract substrings.
If strings were mutable/stateful, taking a substring would consist of copying the relevant
part of S. However, the immutability of strings makes it possible to avoid this copying:
instead, the substring object can simply keep a reference to S, together with
the start and end index.

```java
class String
{
    private ImmutableStringData data;
    private int startIndex;
    private int endIndex;

    private String(ImmutableStringData data, int startIndex, int endIndex)
    {
        this.data = data;
        this.startIndex = startIndex;
        this.endIndex = endIndex;
    }

    public String substring(int start, int end)
    {
        return new String(data, startIndex + start, startIndex + end);
    }
}
```

**TODO** Visualization

* Safer: no copies needed
* Reusing same
* No sync
