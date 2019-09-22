---
layout: default
---
# Topics

Here's a list of topics that we can discuss during this course.

## Git

* Internal structure of the Git repository
* Using Git through shell
* Single user
  * `init`
  * `clone`
  * `config` (author, email, credentials helper)
  * `add`
  * `commit`
  * `rm`
  * `status`
  * `log`
  * `diff`
  * `checkout`
  * `reset`
  * `.gitignore`
  * gitignore.io
* Multiple users
  * `push`
  * `pull`
  * `blame`
  * Resolving merge conflicts
* Remotes
  * Add remote
  * Set url
  * Remove remote
* Branches
  * Create branch
  * Switch branch
  * Merge branch
  * Tags
* GitHub
  * Releases
  * Projects
  * Issues
* Advanced
  * `rebase`
  * `stash`
  * `tag`

## Advanced Design Principles

* How to judge a design
* Design metrics
  * Efficiency
  * Static analysis
  * Extensibility
* Language agnostic design
  * Think in concepts, not language features
  * Project concepts on language at hand
  * Each language is a source of concepts
* Type polymorphism
* Subtype polymorphism
  * Inheritance vs composition
  * Interfaces
* Critiqueing design
  * Old Min/Max inheritance, preLoop, loop, postLoop
  * Activity stuff

## Coq

Coq is a language whose type system is so powerful that
if your code compiles, it is actually 100% correct.

* What are type systems?
* What are they used for?
* New trend: unsound type systems (TypeScript, Python, ...)
* Taking a look at standard type systems and a peek at "extreme" type systems, such as Coq's.
* Software verification

## Common Lisp

Common Lisp is an extensible language: you can change its syntax and add any feature you want.

* Domain Specific Languages

## Prolog

A very high level language that is quite different from 'regular' languages.
The idea behind it is to simply write down the constraints and have
the machine find a solution, thereby avoiding the need to write down an algorithm.
It is far from perfect, but it'd be nice if programming could actually be done like this.

## Rust and Go

Rust is a low level language developed by Mozilla and used for the development of Firefox.
It has enjoyed great popularity the last couple of years.
The language rivals C++ in speed without sharing the sheer complexity of the C++ beast.

Likewise, Go (by Google) is also a low level language favoring speed.
It is a bit slower than Rust, but much easier to use.

## Haskell

Purely functional non-strict language. It's built on top of a strong mathematical
foundation, making it very elegant. Tim Sweeney (main developer of the
Unreal Engine) described his own idea of the "next mainstream programming language"
as a variant on Haskell.

## Theoretical Underpinnings

Short discussion about a couple of theoretical concepts.

* P vs NP
* Undecidability
* Turing Completeness

## Garbage Collection

How does garbage collection work exactly?

* Basic concepts
  * Root set
  * Reachability
* Garbage collection techniques
  * Reference counting
  * Mark and sweep
  * Copying
  * Compacting
  * Generational
* Memory leaks are still possible
* Dealing with cycles
* C++ garbage collection (Boehm)
* Different kinds of references

## Concurrency

* Memory model
* Standard locking
* Futures/Dataflow variables
* Actor model
* STM (Clojure)
* Continuations/async
