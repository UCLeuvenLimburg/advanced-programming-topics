;; Prints x, but x is defined nowhere
(defun foo ()
  (format x))

;; bar's parameter is called x
(defun bar (x)
  (foo))


;; This prints "hello"
;; Due to dynamic scoping, foo "sees" the x inside bar
(bar "hello")
