(defun print-x ()
  (print x))


(let ((x "a"))
  (print-x)          ;; prints a
  (let ((x "b"))
    (print-x))       ;; prints b
  (print-x))         ;; x is restored to a, prints a
