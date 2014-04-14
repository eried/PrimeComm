(*
 *  Calculates the letter mark from the user's entered
 *  numeric mark.
 *
 *  THIS IS JUST AN EXAMPLE. The 215 marks will be
 *  calculated using a different scheme!
 *
 *  Demonstrates nested if-the-else
 *  
 *
 *  Author: Jalal Kawash
 *  Date  : February 2nd, 2001
 *  
 *  *)

program LetterMark (input, output);


var NumericMark :  integer; (* The user's mark *)
    LetterMark : char; (* Corresponding letter Mark, such as A, B, C ... *)

begin (* program *)

   writeln;
   writeln('--------------------------');
   writeln;
   writeln('Please Enter your mark:');
   readln(NumericMark);

   if (NumericMark > 100) or (NumericMark < 0) then
      (* mark entered is invalid *)
      writeln('Invalid mark; good bye')
   else
      (* mark between 0 and 100 *)
      if NumericMark >= 90 then (* mark between 90 and 100 *)
	 LetterMark := 'A' (* you get an A *)
      else (* mark less than 90 *)
	 if NumericMark >= 80 then (* mark between 80 and 89 *)
	    LetterMark := 'B'
	 else (* mark less than 80 *)
	    if  NumericMark >= 70 then (* mark between 70 and 79 *)
	       LetterMark := 'C'
	    else (* mark less than 70 *)
	       if NumericMark >= 60 then (* mark between 60 and 69 *)
		  Lettermark := 'D'
	       else (* mark less than 60 *)
		  LetterMark := 'F';

   if (NumericMark <= 100) and (NumericMark >= 0) then
      begin
	 writeln('You got ', LetterMark);
	 writeln('This is a tough grading scheme!');
	 writeln('It will be easier in 215.');
      end;
end. (* program *)
