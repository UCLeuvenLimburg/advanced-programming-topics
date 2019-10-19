# Assignment

## Context

Any commit can be reverted: it does not have to be the last in line.
The given repository is structured as follows:

* A 1st commit introduced `a.txt`.
* A 2nd commit introduced `b.txt`.
* A 3rd commit introduced `c.txt`.
* A 4th commit introduced `d.txt`.

Reverting the third commit would lead to a fifth commit
in which `c.txt` has been removed, i.e., effectively
undoing the work done by the third commit.

## Task

Revert the third commit.
