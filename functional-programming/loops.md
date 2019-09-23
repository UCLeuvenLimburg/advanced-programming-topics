---
layout: standard
---
# Loops

## Loops Are Important

Loops are an important construct: they allow us to repeat
certain instructions an "compile-time unknown" number of times.
Perhaps this needs some clarification.

Say you need some action repeated exactly 5 times.
You don't need loops for this:

```csharp
Action();
Action();
Action();
Action();
Action();
```

If `Action` needs to be repeated a 100 times, we would simply call it a 100 times.
Of course, we could rely on loops: it would make the code a lot more readable:

```csharp
for ( int i = 0; i != 100; ++i )
{
    Action();
}
```

Loops increase readability: from this code, it is immediately clear that `Action` will be repeated 100 times; no need
to manually count the number of calls. However, loops are not strictly *necessary* in this case as we can implement the 100 calls
without them.

Consider the following code:

```csharp
int n = AskUserForPositiveNumber();

for ( int i = 0; i != n; ++i )
{
    Action();
}
```

Here, the number of repetitions `n` is unknown at compile time. Only when the program is actually
run will `n` be known. An attempt to implement this without loop could look like this:

```csharp
int n = AskUserForPositiveNumber();

if ( n >= 1 ) Action();
if ( n >= 2 ) Action();
if ( n >= 3 ) Action();
if ( n >= 4 ) Action();
if ( n >= 5 ) Action();
...
```

To those trying to be clever and point out you only need to go till 2<sup>31</sup>, making it technically possible
to solve this without loop:

* What about big decimals that allow arbitrarily large values?
* What about infinite loops, needed for example to implement a server.
* What about Gödel's incompleteness theorem?

## The Trouble With Loops

Loops (e.g., `while`, `for`, `foreach`) as implemented by Java, C# and C++ all depend on state, which
is a bit problematic in a functional setting. For example, take the `while` loop:

```csharp
while ( cond )
{
    body;
}
```

Without state, `cond` will always evaluate to the same value: either is stays `false` or it stays `true`.
In case of the latter, we end up with an infinite loop.

This means we need to abandon loops if we are to adopt a functional style.
But we showed that loops are necessary. Does this mean that functional programming is inherently incomplete?

## Recursion To The Rescue

Fortunately, there is an alternative to loops: recursion. Every loop can be rewritten as recursion and vice versa,
meaning that one is not "more powerful" than the other.

Since loops are abundant in imperative code, does that mean that we will have to rely on recursion just as frequently instead?
For those who tremble at the prospect of having to write recursive functions all over the place, we can offer reassurance:
even in the most gung-ho functional languages, recursion is seen as a low level solution, something preferably avoided.
Not because recursion is difficult (because it's not - really!), but because there are better options.
Truth be told, recursion will not even be necessary at all. Sorry for scaring you like that.

Let's take a look at different ways to use a loop and how to translate them to a functional style.

## Splitting Up Loops

Consider the following code:

```csharp
int AverageMenAge(List<Person> people)
{
    var total;

    for ( var person in people )
    {
        if ( person.Male )
        {
            total += person.Age;
        }

        return int total / people.Count;
    }
}
```

This code is rather monolithic: it's one big chunk that has no reusable parts.
The need might arise to implement a variation of this algorithm, such as

* **Maximum** age of men in the list.
* Average **weight** of men in the list.
* Average age of **women** in the list.

Many would simply copy paste the code above and make the necessary changes.
This, of course, is a bad idea.

The algorithm above has three aspects:

* Who do make select from the list? (males/females)
* Which property do we look at? (age/weight)
* What do we do with these values? (average/maximum)

These three aspects are threaded throughout the code above. Let's separate them:

```csharp
int AverageMenAge(List<Person> people)
{
    var men = SelectMen(people);
    var ages = GetAges(men);
    return Average(ages);

    // Or, in a single line
    return Average(GetAges(SelectMen(people)));
}

List<Person> SelectMen(List<Person> people)
{
    var result = new List<Person>();

    foreach ( var person in people )
    {
        if ( person.Male )
        {
            result.Add(person);
        }
    }

    return result;
}

List<int> GetAges(List<Person> people)
{
    var result = new List<int>();

    foreach ( var person in people )
    {
        result.Add(person.Age);
    }

    return result;
}

int Average(List<int> ns)
{
    return Sum(ns) / ns.Count;
}

int Sum(List<int> ns)
{
    var total = 0;

    foreach ( var n in ns )
    {
        total += n;
    }

    return total;
}
```

It's definitely more code, but most functions are reusable.
For example:

```csharp
int AverageWomenAge(List<Person> people)
{
    return Average(GetAges(SelectWomen(people)));
}
```

Thanks to splitting code up in functions, `AverageWomenAge` is able to reuse two thirds
of `AverageMenAge`'s implementation. We can do much better, though.

## Generalizing Filtering

Let's take a closer look at the first step, where we pick out `Person`s based on gender.

```csharp
List<Person> SelectMen(List<Person> people)
{
    var result = new List<Person>();

    foreach ( var person in people )
    {
        if ( person.Male )
        {
            result.Add(person);
        }
    }

    return result;
}

List<Person> SelectWomen(List<Person> people)
{
    var result = new List<Person>();

    foreach ( var person in people )
    {
        if ( !person.Male )
        {
            result.Add(person);
        }
    }

    return result;
}
```

These two functions are identical, except for one character: the `!` in the `if` condition.
Surely there is room for improvement.

Both functions *filter*: given a list, they look for elements that satisfy a condition
and put these in a list, which is ultimately returned. There are many things we could filter on:
`Person`s who are younger than 18, heavier than 100kg, who are blonde, etc.
It'd be nice if we could specify the condition as an extra parameter.

```csharp
List<Person> Select(List<Person> people, Condition condition)
{
    var result = new List<Person>();

    foreach ( var person in people )
    {
        // Pseudocode
        if ( condition is true for person )
        {
            result.Add(person);
        }
    }

    return result;
}
```

What would this `Condition` thing be? To determine this, we need to look
at how it is used. There is only one way `condition` is used: the `if` asks it "are you true for this `Person`?"
From this observation, we can derive an interface:

```csharp
interface IPersonCondition
{
    bool Satisfies(Person person);
}
```

We then write two classes implementing this interface:

```csharp
class IsMale : IPersonCondition
{
    public bool Satisfies(Person person)
    {
        return person.Male;
    }
}

class IsFemale : IPersonCondition
{
    public bool Satisfies(Person person)
    {
        return !person.Male;
    }
}
```

We modify `Select` so as to make use of it:

```csharp
List<Person> Select(List<Person> people, IPersonCondition condition)
{
    var result = new List<Person>();

    foreach ( var person in people )
    {
        if ( condition.Satisfies(person) )
        {
            result.Add(person);
        }
    }

    return result;
}
```

Let's make use of this in our original function:

```csharp
int AverageMenAge(List<Person> people)
{
    var men = Select(people, new IsMale()); // <---
    var ages = GetAges(men);
    return Average(ages);

    // Or, in a single line
    return Average(GetAges(SelectMen(people)));
}
```

## Generic Filtering

Right now, we have defined `Select` in such a way that it can only
operate on lists of `Person`. This is quite limiting. We can easily
imagine having to sort other kinds of objects. Let's try to make
`Select` more broadly applicable.

First, we need to examine what `Select` actually needs.
Right now, it needs a list of `Person`s. Not `string`s,
not `int`s, but `Person`s. Is this inherent to filtering?
Certainly not. So in a first step, we can reduce
our demands from `Person` to simply `object`.
We can make the same change to the interface `IPersonCondition`.
This gives us

```csharp
interface ICondition
{
    bool Satisfies(object o);
}

List<object> Select(List<object> xs, ICondition condition)
{
    var result = new List<object>();

    foreach ( var x in xs )
    {
        if ( condition.Satisfies(x) )
        {
            result.Add(x);
        }
    }

    return result;
}
```

Sadly, this won't do:

* First of all, a `List<Person>` cannot be cast to a `List<object>`, so `Select` has become useless to us.
* Secondly, even if we could make use of `Select`, it would throw typing information away.
  We give it a `List<Person>` but we get a `List<object>` back. We'd prefer the result to be a `List<Person>`.

Both these problems are solved if we make `Select` and `ICondition` generic:

```csharp
interface ICondition<T>
{
    bool Satisfies(T o);
}

List<T> Select<T>(List<T> xs, ICondition<T> condition)
{
    var result = new List<object>();

    foreach ( var x in xs )
    {
        if ( condition.Satisfies(x) )
        {
            result.Add(x);
        }
    }

    return result;
}
```

We now have a `Select` function that can be used to select objects of any type
based on any condition you need.

## First Class Functions

Our current implementation requires us to define a whole new class
for every different condition:

```csharp
class IsMale : ICondition<Person>
{
    public bool Satisfies(Person person)
    {
        return person.Male;
    }
}

class IsFemale : ICondition<Person>
{
    public bool Satisfies(Person person)
    {
        return !person.Male;
    }
}

class IsMinor : ICondition<Person>
{
    public bool Satisfies(Person person)
    {
        return person.Age < 18;
    }
}
```

This is a lot of typing, especially if taking into account
that a condition is actually just a single expression
(`person.Male`, `!person.Male` or `person.Age < 18` in the examples above.)
Right now, the `ICondition<T>` object act as a mere
vehicle for a single method. Perhaps we can forego the object part
and work directly with the method.

Many languages allow this: functions/methods are entities in their own right.
They have a type and can be assigned to variables.
Let's go straight to an example in C#:

```csharp
bool IsMale(Person p) { return p.Male; }

var males = Select(people, IsMale);
```

In other words, there is no need for a separate class definition.
We can "pick up" a function/method and pass it to `Select`.
This raises some question, such as what is the type of `IsMale`,
and how does one use a "function value"?

C# provides the generic type `Func<T1, T2, ..., R>`.
The type parameters `T1`, `T2`, etc. correspond
to the function's parameter types, while `R` denotes
the return type. In our case, `IsMale` takes a `Person` and
returns a `bool`, which makes its type `Func<Person, bool>`.

Once you got a function in your hands, you can
interact with it the way you always did:
you can call the function using the `()` operators:

```csharp
Person somePerson;
Func<Person, bool> cond;

var result = cond(somePerson);
```

We update `Select` to make use of `Func`:

```csharp
List<T> Select<T>(List<T> xs, Func<T, bool> condition)
{
    var result = new List<object>();

    foreach ( var x in xs )
    {
        if ( condition(x) )
        {
            result.Add(x);
        }
    }

    return result;
}
```

You have to make sure you understand the difference between the following
bits of code:

```csharp
int Foo() { return 7; }

var x = Foo;
var y = Foo();
```

Here, `x` will be assigned the function `Foo` itself and `x`'s type is `Func<int>`.
Adding `()` will invoke the function, i.e., execute its body.
This means `y` is assigned `7` in the above code.

## Lambdas

Being able to directly pass a function instead of wrapping it in an object
is great: it saves us much typing. However, we still feel like we're doing too much work:
we need to first define a function, find a name for it, define
its type parameters and return value, ... urgh, I'm getting tired of enumerating all this.

First, let's take a closer look at literals. When we are introducing an `int`-variable, we can write

```csharp
int i = 5;
```

We can do the same for many other types:

```csharp
bool b = true;
double x = 1.3;
string s = "abc";
int[] x = new int[] { 1, 2, 3 };
```

Here, `5`, `true`, `1.3`, `"abc"` and `new int[] { 1, 2, 3 };` are called *literals*:
it is a special notation, built into the language, that allow
us to succinctly refer to a specific value of that type.
Yet when we want to define a function, we need an entirely different syntax:

```csharp
int Foo(bool b, double x) { body; }
```

In reality, it is possible to write a function definition the same
way as for other types:

```csharp
Func<bool, double, int> foo = (b, x) => { body; };
```

Here, `(b, x) => { ... }` denotes a function taking a parameters `b` and `x`
and having `body` as body. While allowed, `b` and `x` need no type annotation:
the compiler can infer it from the context.

The same trick is possible in other languages:

```javascript
// JavaScript
function foo(x, y) { body; }
// or
const foo = (x, y) => { body; };
```

```python
# Python
def foo(x, y):
    return x + y
# or
foo = lambda x, y: x + y
```

Back to C#: `(params) => { body }` is called an anonymous function,
due to it denoting a function which has no name. It's only
after you assign it to a variable that you could say the function has
received a name. Anonymous functions are also called *lambdas*.

Lambdas allow us to further simplify our code:

```csharp
int AverageMenAge(List<Person> people)
{
    return Average(GetAges(Select(people, p => p.Male)));
}
```

To conclude: `Select` effectively can serve as a substitute
for filtering loops. Let's see what other loops we can replace.

## Mapping

In the previous sections, we focused on improving `Select` so as
to make it reusable on all types and for all selection criteria.
It's time to shift our attention to `GetAges`.

As with the original `SelectMen`, `GetAges` is in dire need
of generalization:

* It only works on `Person` objects.
* It can only fetch a `Person`'s `Age` property.

A first step towards a better `GetAges` would be to
return any property it wants. We could do this using reflection,
something like

```csharp
List<object> GetPropertyOf(List<Person> people, string propertyName)
{
    var property = typeof( Person ).GetProperty( propertyName );
    var result = new List<object>();

    foreach ( var person in people )
    {
        result.Add( property.GetValue( person ) );
    }

    return result;
}
```

This works, but it's rather dirty:

* It relies on reflection, which (probably) incurs a performace hit.
* It subverts the typing system: you're stuck with `object`s.
* It is limited to fetching property values. Perhaps we want to get other values, such as `ToString()`'s result.

So, we need a way to tell `Get` what part of the `Person` we are interested in.
This sounds like a job for a function: we pass along a function that takes
a `Person`, retrieves and returns whatever data we are interested in:

```csharp
List<R> Get<R>(List<Person> people, Func<Person, R> fetcher)
{
    var result = new List<R>();

    foreach ( var person in people )
    {
        result.Add( fetcher(person) );
    }

    return result;
}
```

We can use it to extract data from a list of `Person`s as follows:

```csharp
var ages = Get(people, person => person.Age);
var weights = Get(people, person => person.Weight);
var strings = Get(people, person => person.ToString());
```

This operation is generally called `Map` instead of `Get`. It is one
of the most frequently used "loop replacing functions", so
take your time to understand it: the given function is applied to each `Person` in the list
and the results are put into a new list. Thus from a list of `Person`s
a list of ages, weights or string representation is produced.

Next, we make it independent of `Person`: there is no reason
this function be limited to `Person`s. This can be achieved
by introducing an extra type parameter:

```csharp
List<R> Map<T, R>(List<T> xs, Func<T, R> fetcher)
{
    var result = new List<R>();

    foreach ( var x in xs )
    {
        result.Add( fetcher(x) );
    }

    return result;
}
```

Here, `T` denotes the "input type", i.e. the type of the original items whereas `R` is the output type.
A `List<T>` is transformed into a `List<R>`.

This function can be used in many situations:

```csharp
// Square a list of numbers
var squares = Map(numbers, n => n * n);

// Given list of urls, download each
var data = Map(urls, url => Download(url));
```

Applying it to our working examples gives:

```csharp
int AverageMenAge(List<Person> people)
{
    return Average(Map(Select(people, p => p.Male), p => p.Age));
}
```

Admittedly, things are getting confusing. There are two lambdas in there
and it takes some effort to find out which operations
are parameterized with which lambda and what the order is.
Languages often offer special syntax to make things more readable again, but
we postpoone this to a later section. For now, we'll simply spread
the logic over multiple lines:

```csharp
int AverageMenAge(List<Person> people)
{
    var males = Select(people, p => p.Male);
    var maleAges = Map(males, p => p.Age);
    return Average(maleAges);
}
```

## Reducing

`AverageMenAge` was built out of three steps, two of which we already dealt with.
The last one is `Average`, or, more specifically, `Sum`:

```csharp
int Average(List<int> ns)
{
    return Sum(ns) / ns.Count;
}

int Sum(List<int> ns)
{
    var total = 0;

    foreach ( var n in ns )
    {
        total += n;
    }

    return total;
}
```

One could say that `Sum` is already perfectly reusable.
While true, we can still improve upon it. Be warned though:
while filtering and mapping should be relatively easy to understand,
the next one is somewhat more abstract and hence more difficult to get a grasp on.
In the functional world, it is known as both folding (Haskell, Erlang, Rust) and reducing (JavaScript, Java, Python, Ruby, Elixir).
We'll use the term "reduce" because it better reflects the fact that it reduces a list to a single result.

Let's start with multiple examples that hide a reduce operation, so that
you can see a pattern emerge:

```csharp
int Sum(List<int> ns)
{
    var result = 0;

    foreach ( var n in ns )
    {
        result += n;
    }

    return result;
}

int Product(List<int> ns)
{
    var result = 1;

    foreach ( var n in ns )
    {
        result *= n;
    }

    return result;
}

int Maximum(List<int> ns)
{
    var result = int.MinValue;

    foreach ( var n in ns )
    {
        if ( n > result )
        {
            result = n;
        }
    }

    return result;
}
```

The following pattern emerge:

* A `result` variable holds the final result.
* Its initial value varies (`0` for `Sum`, `1` for `Product`, -&infin; for `Maximum`), meaning we'll have to specify it as a parameter later for our generalized algorithm.
* Every element in turn is "combined" with `result`. This combination also differs between operations. This too will have to be passed as parameter.

Let's try to build a general algorithm based on the above ones:

```csharp
T Reduce<T>(T initial, List<T> xs, Func<T, T, T> combine)
{
    T result = initial;

    foreach ( var x in xs )
    {
        result = combine(result, x);
    }

    return result;
}
```

You can see `Reduce` as a way of upgrading a binary operation to an n-ary operation.
`+` and `*` are binary operators: they operate on two operands at a time. If, however,
you've got a whole list of numbers you wish to add or multiply, you need to apply
the `+` or `*` repeatedly. This is exactly what `Reduce` does. Similarly,
the `if` in `Maximum` can be seen as a small function that can compute the maximum of two values (`result` and `n`).
`Reduce` then upgrades it so as to work on entire lists.

Implementing `Sum`, `Product` and `Maximum` in terms of `Reduce` gives

```csharp
int Sum(List<int> ns)
{
    return Reduce(0, ns, (x, y) => x + y);
}

int Product(List<int> ns)
{
    return Reduce(1, ns, (x, y) => x * y);
}

int Maximum(List<int> ns)
{
    return Reduce(int.MinValue, ns, (x, y) => x > y ? x : y);
}
```

We can go one step further though:

```csharp
R Reduce<R, T>(R initial, List<T> xs, Func<R, T, R> combine)
{
    R result = initial;

    foreach ( var x in xs )
    {
        result = combine(result, x);
    }

    return result;
}
```

This more generalized version is a bit harder to understand: we can't simply view it
as turning a binary operation to an n-ary one, due to the typing being all wrong.

One way to interpret this version of `Reduce` is to view it as a "stepwise combinator":

* You start off with `result` set to the initial value (type `R`).
* Next, you take the first element from the list (type `T`).
* The `combine` function takes an `R` and a `T` and combines them into an `R` value. This is our new `result`.
* The second element is taken for the list.
* It is again combined with `result`, yielding a new value for `result`.
* This process is repeated until all elements of the list have been combined with `result`.

For example, consider a function that takes the decimal notation of a number and
turns it into an `int`. Written using a loop, we get:

```csharp
int Parse(string str)
{
    int result = 0;

    for ( var c in str )
    {
        var digit = c - '0';
        result = result * 10 + digit;
    }

    return result;
}
```

The loop does two things at once: it converts `char`s into digits (type `int`),
and combines the digits into one number. We can divide this loop into its components: a `Map` followed by a `Reduce`.

```csharp
int Parse(string str)
{
    var digits = Map(str, c => c - '0');

    return Reduce(0, digits, (acc, digit) => acc * 10 + digit);
}
```

Or, making use of C#'s built-in functions instead of our own:

```csharp
int Parse(string str)
{
    return str.Select(c => c - '0').Aggregate(0, (acc, digit) => acc * 10 + digit);
}
```

## Final Version

The final version of `AverageMenAge` looks as follows:

```csharp
int AverageMenAge(List<Person> people)
{
    var males = Select(people, p => p.Male);
    var maleAges = Map(males, p => p.Age);
    return Average(maleAges);
}

int Average(List<int> ns)
{
    return Sum(ns) / ns.Count;
}

int Sum(List<int> ns)
{
    return Reduce(0, ns, (x, y) => x + y);
}
```

As you can see, no loops were necessary to implement it.  This is how functional code looks like:
no loops, no recursion, just making use of the right function.

## Syntactic Support

Many algorithms can be written as a single line containing a sequence of function calls:

```csharp
int AverageMenAge(List<Person> people)
{
    return Average(Map(Select(people, p => p.Male), p => p.Age));
}
```

As noted above, this quickly becomes unreadable. For this reason,
languages often offer a way to write it as a chain of functions
without sacrificing readability.

For example, in Ruby the above code would look as follows:

```ruby
# Ruby
def average_men_age(people)
  people.select do |p|
    p.male?
  end.map do |p|
    p.age
  end.reduce do |x, y|
    x + y
  end / people.size
end

# or, shorter

def average_men_age(people)
  people.select(&:male?).map(&:age).reduce(0, &:+) / people.size
end
```

The nice thing about Ruby's approach is that nothing is hardcoded in the language:
you can leverage the same syntax for your own functions, not only those built-in.

Python supports list comprehensions: while readable, it only supports mapping and filtering.

```python
# Python
def average_men_age(people):
    return sum(p.age for p in people if p.male) // len(people)
```

C# includes LINQ, which has been made to resemble SQL:

```csharp
// C#
int AverageMenAge(List<Person> people)
{
    return (from p in persons
            where p.Male
            select p.Age).Sum() / people.Count;
}
```

Unfortunately, LINQ is not extensible with your own functions.
C# also has an alternative syntax, while less readable it
has the advantage of being extensible:

```csharp
// C#
int AverageMenAge(List<Person> people)
{
    return people.Where(p => p.Male).Select(p => p.Age).Sum() / people.Count;
}
```

Java (8+) sports approximately the same syntax as C#, without the extensibility.

```java
int averageMenAge(List<Person> people)
{
    return people.stream().filter(p -> p.isMale()).map(p -> p.getAge()).reduce(0, (x, y) -> x + y) / people.size();
}
```

## Link With Bash Scripting

For those of you who like writing one-liners on Bash,
these "loop-functions" should be very recognizable.
For example, `xargs` corresponds to `Map`:

```bash
$ find -name "*.cs" | xargs cat | grep -e '^\s*//' | wc -l
```

* We start off by producing a list of filenames.
* Next, `xargs cat`, the equivalent of `Map`, "transforms" each filename into its corresponding file contents.
* Next comes `grep -e '^\s*//'`, which selects those lines starting with `//`. In other words, this is a `Select` operation.
* Lastly, `wc -l` counts the number of lines that made it through the `grep`. Counting is a `Reduce` operation.

## Recursion

What about the recursion we talked about above? Surely you haven't forgotten about that.

In order to use `Map`, `Select` and `Reduce`, they of course need to be defined first.
To define them using a functional style, it's been established we need recursion.
Fortunately for you, in most languages, these functions are part of the library, as well as many similar ones.
No need to implement them yourselves.

However, even if they were not already available, there's actually no real need to make their implementation functional.
What matters is that, from the outside, they *appear* to be functional,
meaning that if the implementation relies on state, this fact must
remain hidden.

Consider Haskell which enforces a purely functional style: you cannot
cheat and hide some imperative stuff in your implementations,
as there are no imperative building blocks whatsoever.  Yet, internally, Haskell must compile
to machine code, which is imperative at its core. The point is
that Haskell builds an abstraction layer above the machine level,
one in which everything *appears* to be functional.
