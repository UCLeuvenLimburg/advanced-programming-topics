# Explanation

This sample demonstrates the nonatomicity of integer incrementation.

Two threads increment the same two variables called `atomic` and `nonatomic`.
`nonatomic` is incremented in the usual way, i.e., using the `++` operator.
`atomic` is incremented using `Interlocked.Increment`, which, in cooperation with the CPU,
causes the incrementation to occur atomically.

The expectation is that `atomic` will be incremented a number `2 * NITERATIONS` of times,
i.e., each increment takes place successfully, whereas `nonatomic` can
be any number between `NITERATIONS` and `1 * NITERATIONS` due to a
certain percentage of increments failing.

## Usage

```bash
$ dotnet build
$ dotnet bin/Debug/netcoreapp2.0/Sample.dll
Nonatomic: 1290206
Atomic: 2000000
```
