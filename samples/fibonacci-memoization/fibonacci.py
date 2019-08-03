from timeit import timeit


def slow(k):
    if k < 2:
        return k
    else:
        return slow(k-1) + slow(k-2)


def create_fast():
    table = { 0: 0, 1: 1 }

    def fast(k):
        nonlocal table
        if k not in table:
            table[k] = fast(k-1) + fast(k-2)
        return table[k]

    return fast

fast = create_fast()

k = 10
print(f"slow({k}) takes {timeit(f'slow({k})', globals=globals())} seconds")
print(f"fast({k}) takes {timeit(f'fast({k})', globals=globals())} seconds")