; Copyright (C) 2002 - Alexander Popov 
; http://www.emu8086.com

; This program inputs a decimal number
; and prints out its binary equivalent.

; Convertion is done by CONVERT_TO_BIN
; procedure, all other stuff is just
; for input/output.


; for COM file:
#make_COM#  
ORG 100h

; skipt data area:
JMP start

; The string to hold 8 bits
; of binary equivalent, reversed:
Result db 8 dup('X')

start:

; Print the message:
CALL PTHIS
db "Supported values from -127 to 255", 13, 10
db "Enter the number: ", 0

; Get the number:
CALL SCAN_NUM

; Go to new line:
CALL PTHIS
db 13, 10, 0

CALL CONVERT_TO_BIN

; Print the message:
CALL PTHIS
db "Converted to binary:", 13, 10, 0

; Print the Result string backwards:
LEA SI, Result
ADD SI, 7 ; point to end of the string.
MOV AH, 0Eh ; teletype function of BIOS.
MOV CX, 8
print_me:
	MOV AL, [SI]
	INT 10h ; print in teletype mode.
	DEC SI
LOOP print_me

RET ; return to OS.

; Procedure to convert number in CX
; to its binary equivalent. Result is
; store in "Result" string.
CONVERT_TO_BIN PROC NEAR

PUSH AX
PUSH DI

LEA DI, Result

MOV AX, CX
MOV AH, 0   ; high byte ignored!

next_step:

	; AL = AX / 2  
	; AH = remainder (can be 1 or 0)!
	DIV CS:two
	
	MOV [DI], AH
	ADD [DI], 30h ; convert to ASCII.
	
	INC DI
	
	; we don't need remainder any more:
	MOV AH, 0    
	
CMP AX, 0
JNE next_step ; continue until result is zero.

; Reset all prefix bits:
do_reset:
	CMP DI, OFFSET Result + 8
	JAE done
	MOV [DI], '0'
	INC DI
	JMP do_reset
done:

POP DI
POP AX

RET

two DB 2

CONVERT_TO_BIN ENDP

; This macro prints a
; char in AL and advances
; the current cursor
; position:
PUTC    MACRO   char
        PUSH    AX
        MOV     AL, char
        MOV     AH, 0Eh
        INT     10h     
        POP     AX
ENDM

; This procedure gets the multi-digit
; SIGNED number from the keyboard,
; and stores the result in CX register:
SCAN_NUM        PROC    NEAR
        PUSH    DX
        PUSH    AX
        PUSH    SI
        
        MOV     CX, 0

        ; reset flag:
        MOV     CS:make_minus, 0

next_digit:

        ; get char from keyboard
        ; into AL:
        MOV     AH, 00h
        INT     16h
        ; and print it:
        MOV     AH, 0Eh
        INT     10h

        ; check for MINUS:
        CMP     AL, '-'
        JE      set_minus

        ; check for ENTER key:
        CMP     AL, 13  ; carriage return?
        JNE     not_cr
        JMP     stop_input
not_cr:


        CMP     AL, 8                   ; 'BACKSPACE' pressed?
        JNE     backspace_checked
        MOV     DX, 0                   ; remove last digit by
        MOV     AX, CX                  ; division:
        DIV     CS:ten                  ; AX = DX:AX / 10 (DX-rem).
        MOV     CX, AX
        PUTC    ' '                     ; clear position.
        PUTC    8                       ; backspace again.
        JMP     next_digit
backspace_checked:


        ; allow only digits:
        CMP     AL, '0'
        JAE     ok_AE_0
        JMP     remove_not_digit
ok_AE_0:        
        CMP     AL, '9'
        JBE     ok_digit
remove_not_digit:       
        PUTC    8       ; backspace.
        PUTC    ' '     ; clear last entered not digit.
        PUTC    8       ; backspace again.        
        JMP     next_digit ; wait for next input.       
ok_digit:


        ; multiply CX by 10 (first time the result is zero)
        PUSH    AX
        MOV     AX, CX
        MUL     CS:ten                  ; DX:AX = AX*10
        MOV     CX, AX
        POP     AX

        ; check if the number is too big
        ; (result should be 16 bits)
        CMP     DX, 0
        JNE     too_big

        ; convert from ASCII code:
        SUB     AL, 30h

        ; add AL to CX:
        MOV     AH, 0
        MOV     DX, CX      ; backup, in case the result will be too big.
        ADD     CX, AX
        JC      too_big2    ; jump if the number is too big.

        JMP     next_digit

set_minus:
        MOV     CS:make_minus, 1
        JMP     next_digit

too_big2:
        MOV     CX, DX      ; restore the backuped value before add.
        MOV     DX, 0       ; DX was zero before backup!
too_big:
        MOV     AX, CX
        DIV     CS:ten  ; reverse last DX:AX = AX*10, make AX = DX:AX / 10
        MOV     CX, AX
        PUTC    8       ; backspace.
        PUTC    ' '     ; clear last entered digit.
        PUTC    8       ; backspace again.        
        JMP     next_digit ; wait for Enter/Backspace.
        
        
stop_input:
        ; check flag:
        CMP     CS:make_minus, 0
        JE      not_minus
        NEG     CX
not_minus:

        POP     SI
        POP     AX
        POP     DX
        RET
make_minus      DB      ?       ; used as a flag.
ten             DW      10      ; used as multiplier.
SCAN_NUM        ENDP


;***************************************************************
; This procedure prints a null terminated
; string at current cursor position.
; The ZERO TERMINATED string should be defined just after
; the CALL. For example:
;
; CALL PTHIS
; db 'Hello World!', 0
;
; Address of string is stored in the Stack as return address.
; Procedure updates value in the Stack to make return
; after string definition.
PTHIS PROC NEAR

MOV     CS:temp1, SI  ; re-store SI register.

POP     SI            ; get return address (IP).

PUSH    AX            ; store AX register.

next_char:      
        MOV     AL, CS:[SI]
        INC     SI            ; next byte.
        CMP     AL, 0
        JZ      printed        
        MOV     AH, 0Eh       ; teletype function.
        INT     10h
        JMP     next_char     ; loop.
printed:

POP     AX            ; re-store AX register.

; SI should point to next command after
; the CALL instruction and string definition:
PUSH    SI            ; save new return address into the Stack.

MOV     SI, CS:temp1  ; re-store SI register.

RET
temp1  DW  ?    ; variable to store original value of SI register.
PTHIS ENDP



; Copyright (C) 2002 - Alexander Popov 
; http://www.emu8086.com

