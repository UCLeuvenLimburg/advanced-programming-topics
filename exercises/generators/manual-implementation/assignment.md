# Assignment

For this exercise, you'll have to manually implement generators.

## Mapper

Say you have a `List<Person>` and wish to get a `List<string>` containing
all of the `Person`s' names. Normally, you would achieve this using the `Select` method,
but as an exercise, you'll have to implement it yourself as a class.

Usage:

```csharp
IEnumerable<Person> people = GetPeople();
IEnumerable<string> peopleNames = new Mapper<Person, string>(people, p => p.Name);
```

`peopleNames` should now be a list of the `Person`s' names.

Write a class `Mapper<T, U>` where

* `T` is the type of the input elements (e.g. `Person`)
* `U` is the type of the output elements (e.g. `string`)

The class should represent a list of `U`s, meaning it should implement `IEnumerable<U>`.

An object is initialized with

* An `IEnumerable<T>`, i.e., a list of input elements.
* A `Func<T, U>`, i.e., a function that translates a `T` to a `U`.

You'll have to start by finding out which members you need
to add to implement `IEnumerable<T>` and what they do.
Hint: you'll need to create a helper class that implements `IEnumerator<U>`.

## Filter

Write the class `Filter<T>` that implements `IEnumerable<T>`
and whose objects take

* a sequence `IEnumerable<T>` that contains the input elements
* a predicate `Func<T, bool>` that returns either `true` of `false` for each element.

A `Filter<T>` object should contain all elements from the original
sequence for which the predicate returns `true`.
