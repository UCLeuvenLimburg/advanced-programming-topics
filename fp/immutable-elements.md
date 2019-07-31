---
layout: standard
---
# Data Structure Efficiency

Data structures define a way to organize your data. Each data structure
focuses on making specific operations efficient. In this section,
we take a quick look at how many data structures
rely on the statelessness of the values stored inside them.

As a working example, we'll use sets. As a reminder:

* Sets are containers in which you can store values.
* A value can occur at most once in a set. Adding an element a second time has no effect.
* A set specializes in checking whether it contains an element or not. This is the operation it optimizes for speed.

## Naive Implementation

We start with a very simple implementation: we store everything in a simple list.

```python
# Python
class SlowSet:
    def __init__(self):
        self.elts = []

    def add(self, x):
        'Adds x to set'
        if x not in self:
            self.elts.append(x)

    def __contains__(self, x):
        'Membership check'
        for elt in self.elts:
            if x == elt:
                return True
        return False

    def __len__(self):
        return len(self.elts)

# Usage
s = SlowSet()
s.add(4)

4 in s    # True
5 in s    # False
```

New elements are simply added to the back of the list, i.e.
the items appear in order of insertion. However, this
order does not help us in `__contains__`: we have
to iterate over the entire list to check whether
some `x` is an element of the set or not.
Given a set of 2,000,000 elements, it would
take on average 1,000,000 steps to determine
whether a value is included in the set.

## Improved Implementation

Because a set does not have to be able to remember the insertion order,
it is free to choose the order in which it stores its elements in the list.
To speed up finding elements, it would help to sort the list.

```python
# Python
class FastSet:
    def __init__(self):
        self.elts = []

    def add(self, x):
        'Adds x to set'
        if x not in self:
            self.elts.append(x)
            self.elts.sort()

    def __contains__(self, x):
        'Membership check'
        i = 0
        j = len(self.elts)
        while i < j:
            middle = (i + j) // 2
            y = self.elts[middle]
            if y < x:
                i = middle + 1
            elif y == x:
                return True
            else:
                j = middle
        return False

    def __len__(self):
        return len(self.elts)
```

Given a set of 2,000,000 elements, it would only take 21 steps
on average to determine membership.

## Breaking `FastSet`

Let's create a slow set and a fast set and populate them with the same 4 elements:

```python
slow = SlowSet()
fast = FastSet()
i1 = [1]
i2 = [2]
i3 = [3]
i4 = [4]

slow.add(i1)
slow.add(i2)
slow.add(i3)
slow.add(i4)

fast.add(i1)
fast.add(i2)
fast.add(i3)
fast.add(i4)
```

It might appear strange to add lists to a set, but any mutable value will do.
Now, we modify one of the items.

```python
i3[0] = 0
```

Let's ask both sets if they still contain all their elements:

```python
print(i1 in slow) # => True
print(i2 in slow) # => True
print(i3 in slow) # => True
print(i4 in slow) # => True

print(i1 in fast) # => False
print(i2 in fast) # => False
print(i3 in fast) # => True
print(i4 in fast) # => True
```

Apparently, `fast` lost two if its members. Let's check:

```python
print(len(slow)) # => 4
print(len(fast)) # => 4
```

The bug is due to `FastSet`'s assumption that its internal list of items is sorted.
At first, this is the case, but as soon as we modify the element, this property ceases to hold:

```python
fast = FastSet()
i1 = [1]
i2 = [2]
i3 = [3]
i4 = [4]

fast.add(i1)
fast.add(i2)
fast.add(i3)
fast.add(i4)

print(fast.elts) # => [[1], [2], [3], [4]]

i3[0] = 0

print(fast.elts) # => [[1], [2], [0], [4]]
```

`elts` not being sorted causes `__contains__` to misbehave and return erroneous values.

So, how could we solve this?

* We could resort `elts` each time `__contains__` is called. This, however,
  defeats the purpose of `FastSet`: sorting each time would make it slower than `SlowSet`.
* We could rely on the Observer design pattern: `FastSet` could demand
  that all items are observable, i.e., that they emit some kind of signal when
  they change. Then, whenever an item changes value, `FastSet` could react to this by resorting its elements.
  However, this opens a whole new can of worms, which leads to extra complexity and overhead.
* `FastSet` could simply demand that items do not change.

## What Happens in Practice

In practice, sets tend not to be implemented using sorted lists, but with hash tables, which are even more efficient.
However, they have the exact same weakness as the examples above: once an element's hash code changes
(which generally happens whenever a change is made to any of the object's fields),
the set breaks down and cannot be trusted anymore.

The same limitations apply to most other data structures, such as for example dictionaries (hash maps), where keys
should not be modified (values are allowed to change.) This rule, however, is seldom enforced: Java, C#, C++, Ruby,
etc. don't do anything to prevent you from making mistakes.

Python does provide a little help. Consider lists: these are mutable. However, they lack a
hash function:

```python
# Try creeating a set with an empty list in it
xs = { [1, 2] }
# => TypeError: unhashable type: 'list'
```

If you want to have a set of lists (or use lists as keys in a dictionary), you need
to convert it to a tuple. A tuple is in essence a readonly list. Contrary to lists, it is hashable:

```python
xs = { (1, 2) }
```

Likewise, sets are mutable and also have an immutable twin, called `frozenset`.
As with lists, the mutable version is not hashable and can therefore not be added to a set.
Instead, turn a set into `frozenset` first if you need to use it in sets or dictionaries.
