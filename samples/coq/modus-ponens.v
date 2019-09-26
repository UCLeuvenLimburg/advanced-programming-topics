Axiom P Q : Prop.

Axiom P_true : P.

Axiom P_then_Q : P -> Q.

Theorem Q_true : Q.
Proof.
  apply P_then_Q.
  apply P_true.
Qed.