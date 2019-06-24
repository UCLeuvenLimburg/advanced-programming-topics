# Stateful and Stateless

## Algorithm Comparison

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
    if ( xs.length === 0 ) { return []; }
    else {
        const [ first, ...rest ] = xs;
        return [ ...reverse(rest), first ];
    }
}

// or, shorter

const reverse2 = ([x, ...xs]) => x ? [...reverse2(xs), x] : [];
```

One obvious difference between both approaches is
the iterative nature of `reverse1`, i.e., it relies on loops,
whereas `reverse2` is recursive. But that is not what we want to focus on.

Another difference, one that matters more to the subject at hand,
is that both algorithm actually perform slightly different tasks:

* `reverse1` takes a list `xs` and *modifies* it.
  It is hence written in an imperative style.
* `reverse2` leaves its parameter unchanged and returns a *new* list.
  This makes it a functional algorithm.

## Stateless: Where Have I Seen It Before

During your prior programming adventures, you've encountered
both stateful and stateless styles, perhaps without realizing it.

For example, in most programming languages
(e.g. Python, Java, C#, JavaScript, Ruby, ...), strings are stateless,
or immutable, which means that there is no way of modifying a string object.
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
`s`, it simply returns a new string `"hello world"`.
A correct version of the code above would be

```python
# Python
s = "Hello World"
s = s.lower()
print(s) # Prints "hello world"
```

## But Why Stateless

You might wonder why strings have been made stateless. Clearly
it consumes more memory!
A stateful implementation would be much more memory efficient... right?

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

A `Person` has a `name` which must not be empty, as enforced by `setName`.
It is therefore `Person`'s responsibility to "protect" `name`
to ensure it stays valid.

The code above is only correct if strings are immutable.
Imagine that `String` had a `clear()` method that would
set the `String` object to `""`. We could then write

```java
Person person = new Person("Sophie");
person.getName().clear();
```

Due to the fact that `getName()` gives the caller direct access to the `Person`'s `name`,
he would be able to change it, `Person` being none the wiser. The only
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
come back to this code after a couple of weeks or months.
Before you know it, two unrelated parts of your codebase
share the same object. As soon as one part modifies this object,
it would make the other part misbehave.
This kind of bug is infuriatingly hard to find and fix,
since the code that exhibits the faulty behavior might actually be correct.

Now that we've rewritten `Person` so as to make copies of `name` everywhere,
surely there is no way to surreptitiously change the `Person`'s name to
an invalid value? Sorry to disappoint you...

```java
String name = "Martin";
new Thread(() -> { name.clear() }).start();
Person person = new Person(name);
```

If the timing is exactly right, it is possible that `name` is cleared
between the moment it is checked and the moment it is copied.
Run the code in `samples/person-race-condition` to see it in action.

We can fix this as follows:

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
but keep in mind that in some situations, `Person` could be a security sensitive class
and that the user could be maliciously attempting to subvert the system's integrity.

The above examples should convince you (at least a little bit) that immutable
strings do simplify your life: you do not need to make sure you copy them everywhere
at the right times, lest you want hard to track bugs to pop up. Also note
that immutable strings actually lead to more efficient code, since
instead of having to copy them out of safety concerns, it is safe to reuse them.


* Reusing same
* No sync
* Hash keys