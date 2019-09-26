Require Import Nat.
Require Import Arith.


Definition minimum (x y : nat) : { z : nat | (z = x \/ z = y) /\ z >= x /\ z >= y }.
  destruct (le_lt_dec x y).
  - exists y.
    split.
    right; reflexivity.
    split.
    auto.
    auto.
  - exists x.
    split.
    left; reflexivity.
    split; auto with arith.
Defined.

Print minimum.