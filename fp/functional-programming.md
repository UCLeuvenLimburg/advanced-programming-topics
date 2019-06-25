---
layout: standard
mathjax: true
---

# Functional Programming

* Not a panacea, we do not advocate pure functional programming

## Theoretical Definition

If we ask [Wikipedia](https://en.wikipedia.org/wiki/Functional_programming)
what functional programming is, it answers us that
it is a programming paradigm that
treats computation as the evaluation of mathematical functions.
While technically true, it may be a bit too theoretical
for our purposes. Before delving into actual pragmatic
explanations of what functional programming actually entails,
we'll try to give you a general feeling about
what the above definition actually means.

Consider the recipe below:

```text
Take 250g of dark chocolate
Heat it up au bain marie.
Meanwhile, in a separate bowl, place 75g of flour.
Add 125g of sugar.
Add 5 eggs (white and yolk), one by one so as to prevent clumps from formimg.
Wait until chocolate is melted.
Off the fire, add 175g butter to chocolate.
Mix until butter is dissolved.
Add chocolate/butter mixture to flour/sugar/egg mixture. Mix.
Pour into ramekin.
Bake in over at 200 degrees Celsius for around 9 minutes.
```

This recipe is written in an *imperative* style, which
is more or less what you're used to: it is a series of instructions
which have to be performed sequentially.

If we rewrite this recipe in functional style, we'd get

```text
Bake the mixture of 250g of dark chocolate melted au bain marie
and 175g butter with the mixture of 75g flour,
125g sugar and 5 eggs for 9 minutes at 200 degrees Celsius.
```

Functional programming does not specify a clear sequential order,
but focuses on how to combine "values" to achieve a certain goal.

## A More Pragmatic Definition

At its very core, functional programming consists of getting rid of *state*.
It something exhibits state, it means it is able to be *changed*. Consider the code below:

```python
# Python
x = 5
x = 6
```

A variable named `x` is initialized to `5`. On the next line, it is being
*overwritten* with `6`. `x` has *changed* from `5` to `6`.
Because of a variable's ability to change, it is *stateful*.

Another example:

```python
# Python
xs = [1, 2, 3]
xs.append(4)
```

First, `xs` is set to the list `[1, 2, 3]`. Next, this list is *changed* by
adding an extra element `4` at the end. So, that also makes lists *stateful*.

Functional programming means that changing things is prohibited:
variables cannot be reassigned values, lists or any other data structure cannot be
modified in any way, etc.

A synonym for stateful is *mutable*, i.e., changeable. Stateless
is then also known as *immutable*. We'll use these terms interchangeably.

## Functional vs Imperative

You might wonder what good it does to voluntarily limit
ourselves to this functional way of programming. Let us give
answers to questions you might have.

**Is functional programming still as "powerful" as imperative (stateful) programming?
Can we still write every program in it?**

Yes. Every imperative program can be translated into a functional program and vice versa.

**Is functional programming as efficient?**

As with many design decision, it depends on the situation.
Sometimes it's better, sometimes it's worse.

**It looks harder. Is it worth the extra effort?**

Whether it's truly harder is a matter of debate. It certainly is less familiar,
but that's only temporary.
