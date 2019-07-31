---
layout: standard
---
# Encapsulation

You might wonder why strings have been made stateless. Clearly
creating new strings consumes way more memory!
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
set the `String` object to `""`, we could then write

```java
Person person = new Person("Sophie");
person.getName().clear();
```

Due to the fact that `getName()` gives the caller direct access to the `Person`'s `name`,
he would be able to change it, `Person` being none the wiser. The only
safeguard against this would be to copy the string. Let's pretend `String` offers
a `copy()` method, so that we can correct our code:

```diff
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
-         return name;
+         return name.copy();
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

```diff
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

-         this.name = name;
+         this.name = name.copy();
      }
  }
```

It might seem that as long as you don't act
as if you want to break things on purpose, everything will be fine.
However, this is a naive mindset: we can assure you it's all too easy
to accidentally make a mistake, especially if you
come back to your code after a couple of weeks or months.
Before you know it, two unrelated parts of your codebase
share the same object. As soon as one part modifies this object,
it would make the other part misbehave.
This kind of bug is infuriatingly hard to find.
(For this reason, debuggers often allow you to [tag objects with an "identity"]((https://blogs.msdn.microsoft.com/zainnab/2010/03/04/make-object-id/)), so
that you can see if the same object appears at multiple locations.)

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

```diff
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
+         name = name.copy();

          if ( name == null || this.name.length == 0 )
          {
              throw new IllegalArgumentException();
          }

-         this.name = name.copy();
+         this.name = name;
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
