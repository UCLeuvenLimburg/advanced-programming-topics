---
layout: standard
---
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

Another difference, one that matters more to the matter at hand,
is that both algorithms actually perform slightly different tasks:

* `reverse1` takes a list `xs` and *modifies* it.
* `reverse2` leaves its parameter unchanged and returns a *new* list.

`reverse1` is typical for imperative style, whereas `reverse2` is functional in nature.
It is important to be aware of this distinction:

* Ruby often offers both styles. As a visual help, Ruby has introduced
  the convention that imperative methods should end on `!`. For example,
  `xs.sort()` returns a new list, whereas `xs.sort!()` modifies `xs`.
* Python offers two ways of sorting: `xs.sort()` sorts in place (i.e., imperative style),
  while `sorted(xs)` returns a new list (functional). Note how the syntax
  mirrors the programming styles: the OO-syntax vs the function application syntax.
* In O'Caml, it is a mistake not to make use of a function's return value, meaning
  you can't accidentally throw away the result. If you are truly not interested
  in a function's return value, you need to ignore it explicitly using `ignore (function call)`.
* In most other cases, you'll have to check the documentation or type signature to make sure.

## Stateless: Where Have I Seen It Before

During your past programming adventures, you've encountered
both stateful and stateless styles, perhaps without realizing it.

For example, in many imperative programming languages
(e.g. Python, Java, C#, JavaScript, ...), strings are stateless/immutable,
which means that there is no way of modifying a string object.
Feel free to check out the documentation:
[Python](https://docs.python.org/3/library/stdtypes.html#string-methods),
[Java](https://docs.oracle.com/javase/9/docs/api/java/lang/String.html),
[C#](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.8#methods),
[JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String).

Take the Python's `string.lower()` method, which transforms all letters
to lowercase. A typical mistake is to write

```python
# Python
s = "Hello World"
s.lower()
print(s) # Prints "Hello World"
```

The "unexpected" result is a consequence of `lower()` not modifying
`s`, but instead returning a new string `"hello world"`.
A correct version of the code above would be

```python
# Python
s = "Hello World"
s = s.lower()
print(s) # Prints "hello world"
```
