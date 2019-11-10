(defun parse-hexadecimal (str)
  (reduce (lambda (acc x)
	    (+ (* 16 acc) (position x "0123456789ABCDEF")))
	  str
	  :initial-value 0))

(set-macro-character #\$
		     (lambda (stream char)
		       (declare (ignore char))
		       (parse-hexadecimal (format nil "~A" (read stream)))))
