# Assignment

The given repository is structured as follows:

* A 1st commit introduced `a.txt`.
* A 2nd commit introduced `b.txt`.
* A 3rd commit introduced `c.txt`.
* A 4th commit introduced `d.txt`.

## Task

Erase the 4th commit from history, i.e., we want the repository
back to how it was just after the third commit. However,
we do not want to lose `d.txt`: it should be removed from
the staging area, but not from the working area.

Hint: `git reset`.
