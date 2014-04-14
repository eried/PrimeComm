\ Note 1: Text after a backslash is a comment until end-of-line.
 \ Note 2: Text within parentheses like "( n -- )" is also a comment.
 \ Note 3: To be strictly ANSI compliant, the code below is in UPPERCASE.
 \	 Most PC Forth implementations are (optionally) case insensitive.

 : STAR	 ( -- ) \ Print a single star
   42 EMIT ;	  \ 42 is the ASCII code for *

 : STARS	( n -- ) \ Print n stars
   0 DO STAR LOOP ;	\ Loop n times (0 up to n-1) and execute STAR

 : SQUARE	( n -- ) \ Print an n-line square of stars
   DUP 0 DO		\ Loop n times, keeping (DUP-licating) n on the stack
   DUP STARS CR	\ Each time, print n stars then print CR
   LOOP DROP ;	\ After loop is done, drop the n from the stack

 : TRIANGLE	( n -- ) \ Print an n-line triangle
   1 + 1 DO		\ Loop n times from 1 to n (instead of 0 to n-1)
   I STARS CR	\ This time use the inner loop index I
   LOOP ;

 : TOWER	( n -- ) \ Print a "tower" with an base of size n
   DUP		\ DUP-licate n (since it is used twice below)
   1 - TRIANGLE	\ Print a triangle 1 size smaller than n
   SQUARE ;		\ Print a square base of size n

