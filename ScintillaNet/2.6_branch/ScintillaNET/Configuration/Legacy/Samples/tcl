#!/usr/bin/wish -f
wm title . "gui_quads"
label .msg -text "Solution of a x^2 + b x + c = 0"
pack .msg -padx 5 -pady 3 -ipadx 5 -ipady 5 -fill x
frame .f
pack .f -padx 5 -ipadx 5


#
entry .f.a   -relief sunken 
label .f.x2  -text "x^2 + "
entry .f.b   -relief sunken 
label .f.x   -text " x + "
entry .f.c   -relief sunken
label .f.rhs -text " = 0"

pack .f.a .f.x2 .f.b .f.x .f.c .f.rhs -in .f -side left -padx 3 -pady 3 -ipadx 2 -ipady 2

frame .zeros
pack .zeros
frame .zeros.base1 -bg red
frame .zeros.base2 -bg pink
pack .zeros.base1 -in .zeros -padx 5 -pady 5 -side top
pack .zeros.base2 -in .zeros -padx 5 -pady 5 -side top
label .zeros.x1 -text "x1 = "
label .zeros.x1val -bg yellow
label .zeros.x2 -text "x2 = "
label .zeros.x2val -bg yellow
pack .zeros.x1 .zeros.x1val -side left -in .zeros.base1 -padx 5 -pady 5
pack .zeros.x2 .zeros.x2val -side left -in .zeros.base2 -padx 5 -pady 5

# 
frame .info
pack .info
frame .info.dum
pack .info.dum -side left 
set w .info.dum

label $w.disc 
label $w.type
pack $w.disc -padx 5 -pady 5 
pack $w.type -padx 5 -pady 5
#

#

#
# buttons
#
frame .bf
pack .bf -padx 5 -pady 5 -ipadx 4 -ipady 4 -fill x
button .bf.quit -text Quit -command {exit}
button .bf.clear -text Clear -command clearEntries
button .bf.solve -text Solve -command invokeQuads
pack .bf.quit .bf.clear .bf.solve -side right \
     -padx 5 -pady 5 -ipadx 3 -ipady 3

focus .f.a


proc invokeQuads { } {
    set f [open |quads r+]
        foreach e {.f.a .f.b .f.c} {
        set entry [$e get]
	   if { [string compare $entry ""] == 0 } {
		puts stdout "Some entry(ies) are null .... enter them Now \n"
				close $f
				return
		  } else {
			puts $f $entry
		}
	 }


    flush $f       ;# you can only flush after you have written to the pipe
    gets $f in_prompt  ;# Input the coefficients a,b,c
    gets $f disc       ;# DISC :     1.0000000000000
    gets $f iflag      ;# IFLAG =   0
    gets $f aux_msg    ;# ROOTS ARE REAL or ... Complex ...
    gets $f roots      ;# x1 =     2.0000000000000  x2 =     1.0000000000000
    close $f           ;# now you can close
	 set w .info.dum    ;# a quick fix 
    if { [regexp {(COMPLEX|complex)} $aux_msg cmplx] == 1 } {
		  .zeros.x1 configure -text "Real Part"
        .zeros.x2 configure -text "Imaginary Part"
        $w.type config -text $aux_msg
    } else {
        .zeros.x1 configure -text x1
        .zeros.x2 configure -text x2
        $w.type config -text $aux_msg
	 }
    regexp {(x1 = [ ]*[+|-]*[0-9]*\.[0-9]*)} $roots val1
    regexp {(x2 = [ ]*[+|-]*[0-9]*\.[0-9]*)} $roots val2
    .zeros.x1val configure -text $val1
    .zeros.x2val configure -text $val2
    $w.disc configure -text $disc
}

proc clearEntries { } {
	 foreach e {.f.a .f.b .f.c} {
		  $e delete 0 end
	 }
}




