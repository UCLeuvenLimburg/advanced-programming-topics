# Assignment

## Context

* A file `password.txt` was created with a very important password in it.
* It was accidentally copied to the staging area.

```text
--------------------
    password.txt      STAGING
--------------------
    password.txt      WORKING
--------------------
```

## Task

Remove `password.txt` from the staging area without removing it
from the working area.

```text
--------------------
                      STAGING
--------------------
    password.txt      WORKING
--------------------
```
