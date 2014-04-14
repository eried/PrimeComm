
% Global registers for global display
disp1	GREG 0
disp2	GREG 0
disp3	GREG 0
disp4	GREG 0
disp5	GREG 0
disp6	GREG 0
disp7	GREG 0
disp8	GREG 0
disp9	GREG 0
disp10	GREG 0

% Global registers for general temporary computations
temp1	GREG 0
temp2	GREG 0
temp3	GREG 0
temp4	GREG 0
temp5	GREG 0
temp6	GREG 0
temp7	GREG 0
temp8	GREG 0
temp9	GREG 0
temp10	GREG 0

% Frame & stack pointers
fp	GREG 0
sp	GREG 0

	LOC Data_Segment

	GREG @
FBuffer	LOC @+5
FArg0	OCTA 0,0,0,0,0,0,0,0,0,0
FArg1	OCTA FBuffer,1,FBuffer+1,1,FBuffer+2,1,FBuffer+3,1,FBuffer+4,1
Buffer	LOC @+1
BufArg	OCTA Buffer,1
Printn	BYTE 13,10,0
Frame	OCTA 0,0
STACK	LOC @+50000

	LOC #200

str2int	GET $12,rJ
	SET $13,disp2
	SET $14,fp
	SET fp,sp
	ADDU sp,sp,24
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,8
R2	LDT temp1,fp,8
	ADDU $1,$0,temp1
	SETL temp1,0
	SET $2,temp1
	LDB $1,$1,0
	SUB $3,$1,$2
	ZSNZ $3,$3,1
	LDT temp1,fp,8
	ADDU $1,$0,temp1
	LDB $1,$1,0
	SETL temp2,45
	SUB $2,$1,temp2
	ZSNZ $2,$2,1
	AND $1,$3,$2
	LDT temp1,fp,8
	ADDU $2,$0,temp1
	LDB $2,$2,0
	SETL temp2,48
	SUB $4,$2,temp2
	ZSN $4,$4,1
	LDT temp1,fp,8
	ADDU $2,$0,temp1
	LDB $2,$2,0
	SETL temp2,57
	SUB $5,$2,temp2
	ZSP $5,$5,1
	OR $2,$4,$5
	AND $5,$1,$2
	BZ $5,R3
	LDT temp1,fp,8
	SETL temp2,1
	ADD $2,temp1,temp2
	STT $2,fp,8
	JMP R2
R3	LDT temp1,fp,8
	ADDU $6,$0,temp1
	LDB $6,$6,0
	SETL temp2,45
	SUB $7,$6,temp2
	ZSZ $7,$7,1
	BZ $7,R4
	SETL temp1,1
	STB temp1,fp,16
	LDT temp1,fp,8
	SETL temp2,1
	ADD $6,temp1,temp2
	STT $6,fp,8
	JMP R5
R4	SETL temp1,0
	STB temp1,fp,16
R5	SETL temp1,0
	STT temp1,fp,0
R6	LDT temp1,fp,8
	ADDU $5,$0,temp1
	LDB $5,$5,0
	SETL temp2,48
	SUB $6,$5,temp2
	ZSNN $6,$6,1
	LDT temp1,fp,8
	ADDU $5,$0,temp1
	LDB $5,$5,0
	SETL temp2,57
	SUB $7,$5,temp2
	ZSNP $7,$7,1
	AND $5,$6,$7
	BZ $5,R7
	SETL temp1,10
	LDT temp2,fp,0
	MUL $5,temp1,temp2
	LDT temp1,fp,8
	ADDU $7,$0,temp1
	LDB $7,$7,0
	SET $8,$7
	SETL temp2,48
	SUB $9,$8,temp2
	ADD $10,$5,$9
	STT $10,fp,0
	LDT temp1,fp,8
	SETL temp2,1
	ADD $9,temp1,temp2
	STT $9,fp,8
	JMP R6
R7	LDB temp1,fp,16
	BZ temp1,R8
	LDT temp1,fp,0
	NEG $11,0,temp1
	STT $11,fp,0
R8	LDT $0,fp,0
	SET sp,fp
	SET fp,$14
	SET disp2,$13
	PUT rJ,$12
	POP 1,0
int2str	GET $7,rJ
	SET $8,disp2
	SET $9,fp
	SET fp,sp
	ADDU sp,sp,40
	SET disp2,fp
	STT $0,fp,0
	SETL temp1,0
	STB temp1,fp,32
	SETL temp1,1000000&#ffff
	ORML temp1,1000000>>16
	STT temp1,fp,24
	LDT temp1,fp,0
	SETL temp2,0
	SUB $3,temp1,temp2
	ZSN $3,$3,1
	BZ $3,R10
	SETL temp1,0
	ADDU $3,$1,temp1
	SETL temp1,45
	STB temp1,$3,0
	LDT temp1,fp,0
	NEG $3,0,temp1
	STT $3,fp,0
	SETL temp1,1
	STT temp1,fp,16
	JMP R11
R10	SETL temp1,0
	STT temp1,fp,16
R11	LDT temp1,fp,24
	SETL temp2,1
	SUB $2,temp1,temp2
	ZSP $2,$2,1
	BZ $2,R13
	SETL temp1,48
	STT temp1,fp,8
R14	LDT temp1,fp,0
	LDT temp2,fp,24
	SUB $2,temp1,temp2
	ZSNN $2,$2,1
	BZ $2,R15
	LDT temp1,fp,8
	SETL temp2,1
	ADD $2,temp1,temp2
	STT $2,fp,8
	LDT temp1,fp,0
	LDT temp2,fp,24
	SUB $2,temp1,temp2
	STT $2,fp,0
	JMP R14
R15	LDT temp1,fp,8
	SETL temp2,48
	SUB $4,temp1,temp2
	ZSP $4,$4,1
	LDB temp1,fp,32
	OR $5,temp1,$4
	BZ $5,R16
	LDT temp1,fp,16
	ADDU $4,$1,temp1
	LDT temp1,fp,8
	SET $5,temp1
	STB $5,$4,0
	SETL temp1,1
	STB temp1,fp,32
	LDT temp1,fp,16
	SETL temp2,1
	ADD $4,temp1,temp2
	STT $4,fp,16
R16	LDT temp1,fp,24
	SETL temp2,10
	DIV $3,temp1,temp2
	STT $3,fp,24
	JMP R11
R13	LDT temp1,fp,16
	ADDU $4,$1,temp1
	LDT temp1,fp,0
	SETL temp2,48
	ADD $5,temp1,temp2
	SET $6,$5
	STB $6,$4,0
	LDT temp1,fp,16
	SETL temp2,1
	ADD $4,temp1,temp2
	ADDU $6,$1,$4
	SETL temp1,0
	SET $4,temp1
	STB $4,$6,0
	SET sp,fp
	SET fp,$9
	SET disp2,$8
	PUT rJ,$7
	POP 1,0
	POP 0,0
printi	GET $2,rJ
	SET $3,disp2
	SET $4,fp
	SET fp,sp
	SETL $255,256
	ADDU sp,sp,$255
	SET disp2,fp
	SET $9,$0
	SET temp1,fp
	SET $10,temp1
	PUSHJ $8,int2str
	SET $255,fp
	TRAP 0,Fputs,StdOut
	SET sp,fp
	SET fp,$4
	SET disp2,$3
	PUT rJ,$2
	POP 1,0
	POP 0,0
printf	GET $23,rJ
	SET $24,disp2
	SET $25,fp
	NEG temp4,0,8
	LDO temp4,sp,temp4
	SUB temp4,sp,temp4
	SET fp,temp4
	LDO temp5,temp4,0
	ADD temp4,temp4,8
	SETL $22,0
LL8	LDB temp3,temp5,$22
	SUB $3,temp3,0
	ZSNZ $3,$3,1
	BZ $3,LL9
	SUB $5,temp3,'%'
	ZSZ $5,$5,1
	BZ $5,LL10
	ADD $22,$22,1
	LDB temp3,temp5,$22
	SUB $7,temp3,'c'
	ZSZ $7,$7,1
	BZ $7,LL11
	LDO temp1,temp4,0
	ADD temp4,temp4,8	
	LDA $255,Buffer
	STB temp1,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,StdOut
	JMP LL12
LL11	LDB temp3,temp5,$22
	SUB $9,temp3,'i'
	ZSZ $9,$9,1
	BZ $9,LL13
	LDO $32,temp4,0
	ADD temp4,temp4,8	
	PUSHJ $31,printi
	JMP LL12
LL13	LDB temp3,temp5,$22
	SUB $11,temp3,'s'
	ZSZ $11,$11,1
	BZ $11,LL14
	LDO $255,temp4,0
	ADD temp4,temp4,8	
	TRAP 0,Fputs,StdOut
	JMP LL12
LL14	LDA $255,Buffer
	SETL temp1,'%'
	STB temp1,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,StdOut
LL12	ADD $22,$22,1
	JMP LL15
LL10	LDB temp3,temp5,$22
	SUB $14,temp3,'\'
	ZSZ $14,$14,1
	BZ $14,LL16
	ADD $22,$22,1
	LDB temp3,temp5,$22
	SUB $16,temp3,'t'
	ZSZ $16,$16,1
	BZ $16,LL17
	LDA $255,Buffer
	SETL temp1,9
	STB temp1,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,StdOut
	JMP LL18
LL17	LDB temp3,temp5,$22
	SUB $18,temp3,'n'
	ZSZ $18,$18,1
	BZ $18,LL18
	LDA $255,Printn
	TRAP 0,Fputs,StdOut
LL18	ADD $22,$22,1
	JMP LL15
LL16	LDB temp3,temp5,$22
	LDA $255,Buffer
	STB temp3,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,StdOut
	ADD $22,$22,1
LL15	JMP LL8
LL9	SET sp,fp
	SET fp,$25
	SET disp2,$24
	PUT rJ,$23
	POP 0,0
fprinti	GET $2,rJ
	SET $3,disp2
	SET $4,fp
	SET fp,sp
	SETL $255,256
	ADDU sp,sp,$255
	SET disp2,fp
	SET $9,$0
	SET temp1,fp
	SET $10,temp1
	PUSHJ $8,int2str
	SET $255,fp
	TRAP 0,Fputs,7
	SET sp,fp
	SET fp,$4
	SET disp2,$3
	PUT rJ,$2
	POP 1,0
	POP 0,0
fprintf	GET $23,rJ
	SET $24,disp2
	SET $25,fp
	NEG temp4,0,8
	LDO temp4,sp,temp4
	SUB temp4,sp,temp4
	SET fp,temp4
	LDO temp5,temp4,0
	ADD temp4,temp4,8
	SETL $22,0
LLL8	LDB temp3,temp5,$22
	SUB $3,temp3,0
	ZSNZ $3,$3,1
	BZ $3,LLL9
	SUB $5,temp3,'%'
	ZSZ $5,$5,1
	BZ $5,LLL10
	ADD $22,$22,1
	LDB temp3,temp5,$22
	SUB $7,temp3,'c'
	ZSZ $7,$7,1
	BZ $7,LLL11
	LDO temp1,temp4,0
	ADD temp4,temp4,8	
	LDA $255,Buffer
	STB temp1,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,7
	JMP LLL12
LLL11	LDB temp3,temp5,$22
	SUB $9,temp3,'i'
	ZSZ $9,$9,1
	BZ $9,LLL13
	LDO $32,temp4,0
	ADD temp4,temp4,8	
	PUSHJ $31,fprinti
	JMP LLL12
LLL13	LDB temp3,temp5,$22
	SUB $11,temp3,'s'
	ZSZ $11,$11,1
	BZ $11,LLL14
	LDO $255,temp4,0
	ADD temp4,temp4,8	
	TRAP 0,Fputs,7
	JMP LLL12
LLL14	LDA $255,Buffer
	SETL temp1,'%'
	STB temp1,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,7
LLL12	ADD $22,$22,1
	JMP LLL15
LLL10	LDB temp3,temp5,$22
	SUB $14,temp3,'\'
	ZSZ $14,$14,1
	BZ $14,LLL16
	ADD $22,$22,1
	LDB temp3,temp5,$22
	SUB $16,temp3,'t'
	ZSZ $16,$16,1
	BZ $16,LLL17
	LDA $255,Buffer
	SETL temp1,9
	STB temp1,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,7
	JMP LLL18
LLL17	LDB temp3,temp5,$22
	SUB $18,temp3,'n'
	ZSZ $18,$18,1
	BZ $18,LLL18
	LDA $255,Printn
	TRAP 0,Fputs,7
LLL18	ADD $22,$22,1
	JMP LLL15
LLL16	LDB temp3,temp5,$22
	LDA $255,Buffer
	STB temp3,$255,0
	LDA $255,BufArg
	TRAP 0,Fwrite,7
	ADD $22,$22,1
LLL15	JMP LLL8
LLL9	SET sp,fp
	SET fp,$25
	SET disp2,$24
	PUT rJ,$23
	POP 0,0


L2	GET $5,rJ
	SET $6,disp2
	SET $7,fp
	SET fp,sp
	SET disp2,fp
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SETL $255,2576
	ADDU temp1,disp1,$255
	SETL $255,264
	ADDU $2,temp1,$255
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $3,temp1
	GETA temp1,STRINGS
	STOU temp1,sp,0
	SET temp1,$1
	STOU temp1,sp,8
	SET temp1,$2
	STOU temp1,sp,16
	LDT temp1,$3,0
	STOU temp1,sp,24
	SET temp1,$0
	STOU temp1,sp,32
	SET temp1,48
	STOU temp1,sp,40
	ADD sp,sp,48
	PUSHJ $11,printf
	TRAP 0,Fclose,3
	SET $1,$255
	TRAP 0,Fclose,7
	SET $1,$255
	TRAP 0,Halt,0
	SET sp,fp
	SET fp,$7
	SET disp2,$6
	PUT rJ,$5
	POP 0,0

L3	GET $1,rJ
	SET $2,disp2
	SET $3,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	LDA temp2,FArg1
	16ADDU temp2,temp1,temp2
	SET $255,temp2
	TRAP 0,Fread,3
	LDA temp3,FBuffer
	LDBU $0,temp3,temp1
	CSN $0,$255,0
	SET temp1,$0
	STB temp1,fp,0
	LDB $0,fp,0
	SET sp,fp
	SET fp,$3
	SET disp2,$2
	PUT rJ,$1
	POP 1,0

L4	GET $7,rJ
	SET $8,disp2
	SET $9,fp
	SET fp,sp
	ADDU sp,sp,40
	SET disp2,fp
	SET temp1,$0
	STT temp1,fp,0
	SETL temp1,0
	STB temp1,fp,32
	SETL temp1,1000000&#ffff
	ORML temp1,1000000>>16
	STT temp1,fp,24
	LDT temp1,fp,0
	SETL temp2,0
	SUB $3,temp1,temp2
	ZSN $3,$3,1
	SET temp1,$3
	BZ temp1,L5
	SETL temp1,0
	SET temp2,$1
	ADDU $3,temp2,temp1
	SETL temp1,45
	STB temp1,$3,0
	LDT temp1,fp,0
	NEG $3,0,temp1
	SET temp1,$3
	STT temp1,fp,0
	SETL temp1,1
	STT temp1,fp,16
	JMP L6
L5	SETL temp1,0
	STT temp1,fp,16
L6	LDT temp1,fp,24
	SETL temp2,1
	SUB $2,temp1,temp2
	ZSP $2,$2,1
	SET temp1,$2
	BZ temp1,L8
	SETL temp1,48
	STT temp1,fp,8
L9	LDT temp1,fp,0
	LDT temp2,fp,24
	SUB $2,temp1,temp2
	ZSNN $2,$2,1
	SET temp1,$2
	BZ temp1,L10
	LDT temp1,fp,8
	SETL temp2,1
	ADD $2,temp1,temp2
	SET temp1,$2
	STT temp1,fp,8
	LDT temp1,fp,0
	LDT temp2,fp,24
	SUB $2,temp1,temp2
	SET temp1,$2
	STT temp1,fp,0
	JMP L9
L10	LDT temp1,fp,8
	SETL temp2,48
	SUB $4,temp1,temp2
	ZSP $4,$4,1
	LDB temp1,fp,32
	SET temp2,$4
	OR $5,temp1,temp2
	SET temp1,$5
	BZ temp1,L11
	LDT temp1,fp,16
	SET temp2,$1
	ADDU $4,temp2,temp1
	LDT temp1,fp,8
	SET $5,temp1
	SET temp1,$5
	STB temp1,$4,0
	SETL temp1,1
	STB temp1,fp,32
	LDT temp1,fp,16
	SETL temp2,1
	ADD $4,temp1,temp2
	SET temp1,$4
	STT temp1,fp,16
L11	LDT temp1,fp,24
	SETL temp2,10
	DIV $3,temp1,temp2
	SET temp1,$3
	STT temp1,fp,24
	JMP L6
L8	LDT temp1,fp,16
	SET temp2,$1
	ADDU $4,temp2,temp1
	LDT temp1,fp,0
	SETL temp2,48
	ADD $5,temp1,temp2
	SET temp1,$5
	SET $6,temp1
	SET temp1,$6
	STB temp1,$4,0
	LDT temp1,fp,16
	SETL temp2,1
	ADD $4,temp1,temp2
	SET temp1,$4
	SET temp2,$1
	ADDU $6,temp2,temp1
	SETL temp1,0
	SET $4,temp1
	SET temp1,$4
	STB temp1,$6,0
	SET sp,fp
	SET fp,$9
	SET disp2,$8
	PUT rJ,$7
	POP 0,0

L12	GET $5,rJ
	SET $6,disp2
	SET $7,fp
	SET fp,sp
	SET disp2,fp
	SETL temp1,0
	SET temp2,$0
	ADDU $1,temp2,temp1
	LDB temp1,$1,0
	SETL temp2,45
	SUB $2,temp1,temp2
	ZSZ $2,$2,1
	SETL temp1,0
	SET temp2,$0
	ADDU $1,temp2,temp1
	LDB temp1,$1,0
	SETL temp2,48
	SUB $3,temp1,temp2
	ZSNN $3,$3,1
	SETL temp1,0
	SET temp2,$0
	ADDU $1,temp2,temp1
	LDB temp1,$1,0
	SETL temp2,57
	SUB $4,temp1,temp2
	ZSNP $4,$4,1
	SET temp1,$3
	SET temp2,$4
	AND $1,temp1,temp2
	SET temp1,$2
	SET temp2,$1
	OR $4,temp1,temp2
	SET $0,$4
	SET sp,fp
	SET fp,$7
	SET disp2,$6
	PUT rJ,$5
	POP 1,0

L13	GET $8,rJ
	SET $9,disp2
	SET $10,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,0
L14	LDT temp1,fp,0
	SETL temp2,256
	SUB $2,temp1,temp2
	ZSN $2,$2,1
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	SETL temp1,0
	SET $4,temp1
	LDB temp1,$3,0
	SET temp2,$4
	SUB $5,temp1,temp2
	ZSNZ $5,$5,1
	SET temp1,$2
	SET temp2,$5
	AND $3,temp1,temp2
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $4,temp2,temp1
	SETL temp1,0
	SET $5,temp1
	LDB temp1,$4,0
	SET temp2,$5
	SUB $6,temp1,temp2
	ZSNZ $6,$6,1
	SET temp1,$3
	SET temp2,$6
	AND $4,temp1,temp2
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $5,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $6,temp2,temp1
	LDB temp1,$5,0
	LDB temp2,$6,0
	SUB $7,temp1,temp2
	ZSZ $7,$7,1
	SET temp1,$4
	SET temp2,$7
	AND $5,temp1,temp2
	SET temp1,$5
	BZ temp1,L15
	LDT temp1,fp,0
	SETL temp2,1
	ADD $5,temp1,temp2
	SET temp1,$5
	STT temp1,fp,0
	JMP L14
L15	LDT temp1,fp,0
	SET temp2,$0
	ADDU $5,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $6,temp2,temp1
	LDB temp1,$5,0
	LDB temp2,$6,0
	SUB $7,temp1,temp2
	ZSZ $7,$7,1
	SET $0,$7
	SET sp,fp
	SET fp,$10
	SET disp2,$9
	PUT rJ,$8
	POP 1,0

L16	GET $4,rJ
	SET $5,disp2
	SET $6,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,0
L17	LDT temp1,fp,0
	SET temp2,$0
	ADDU $1,temp2,temp1
	SETL temp1,0
	SET $2,temp1
	LDB temp1,$1,0
	SET temp2,$2
	SUB $3,temp1,temp2
	ZSNZ $3,$3,1
	SET temp1,$3
	BZ temp1,L18
	LDT temp1,fp,0
	SETL temp2,1
	ADD $1,temp1,temp2
	SET temp1,$1
	STT temp1,fp,0
	JMP L17
L18	LDT $0,fp,0
	SET sp,fp
	SET fp,$6
	SET disp2,$5
	PUT rJ,$4
	POP 1,0

L19	GET $7,rJ
	SET $8,disp2
	SET $9,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,0
L20	LDT temp1,fp,0
	SETL temp2,256
	SUB $1,temp1,temp2
	ZSN $1,$1,1
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $2,temp2,temp1
	SETL temp1,0
	SET $3,temp1
	LDB temp1,$2,0
	SET temp2,$3
	SUB $4,temp1,temp2
	ZSNZ $4,$4,1
	SET temp1,$1
	SET temp2,$4
	AND $2,temp1,temp2
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	LDB temp1,$3,0
	SETL temp2,65
	SUB $4,temp1,temp2
	ZSNN $4,$4,1
	SET temp1,$2
	SET temp2,$4
	AND $3,temp1,temp2
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $4,temp2,temp1
	LDB temp1,$4,0
	SETL temp2,90
	SUB $5,temp1,temp2
	ZSNP $5,$5,1
	SET temp1,$3
	SET temp2,$5
	AND $4,temp1,temp2
	SET temp1,$4
	BZ temp1,L21
	LDT temp1,fp,0
	SETL temp2,1
	ADD $4,temp1,temp2
	SET temp1,$4
	STT temp1,fp,0
	JMP L20
L21	LDT temp1,fp,0
	SET temp2,$0
	ADDU $4,temp2,temp1
	SETL temp1,0
	SET $5,temp1
	LDB temp1,$4,0
	SET temp2,$5
	SUB $6,temp1,temp2
	ZSZ $6,$6,1
	SET $0,$6
	SET sp,fp
	SET fp,$9
	SET disp2,$8
	PUT rJ,$7
	POP 1,0

L22	GET $7,rJ
	SET $8,disp2
	SET $9,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SET temp1,$2
	STT temp1,fp,0
L23	LDT temp1,fp,0
	SETL temp2,256
	SUB $3,temp1,temp2
	ZSN $3,$3,1
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $4,temp2,temp1
	SETL temp1,0
	SET $5,temp1
	LDB temp1,$4,0
	SET temp2,$5
	SUB $6,temp1,temp2
	ZSNZ $6,$6,1
	SET temp1,$3
	SET temp2,$6
	AND $4,temp1,temp2
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $5,temp2,temp1
	LDB temp1,$5,0
	SET temp2,$1
	SUB $6,temp1,temp2
	ZSNZ $6,$6,1
	SET temp1,$4
	SET temp2,$6
	AND $5,temp1,temp2
	SET temp1,$5
	BZ temp1,L24
	LDT temp1,fp,0
	SETL temp2,1
	ADD $5,temp1,temp2
	SET temp1,$5
	STT temp1,fp,0
	JMP L23
L24	LDT $0,fp,0
	SET sp,fp
	SET fp,$9
	SET disp2,$8
	PUT rJ,$7
	POP 1,0

L25	GET $8,rJ
	SET $9,disp2
	SET $10,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,0
L26	LDT temp1,fp,0
	SETL temp2,256
	SUB $2,temp1,temp2
	ZSN $2,$2,1
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	SETL temp1,0
	SET $4,temp1
	LDB temp1,$3,0
	SET temp2,$4
	SUB $5,temp1,temp2
	ZSNZ $5,$5,1
	SET temp1,$2
	SET temp2,$5
	AND $3,temp1,temp2
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $4,temp2,temp1
	LDB temp1,$4,0
	SET temp2,$1
	SUB $5,temp1,temp2
	ZSNZ $5,$5,1
	SET temp1,$3
	SET temp2,$5
	AND $4,temp1,temp2
	SET temp1,$4
	BZ temp1,L27
	LDT temp1,fp,0
	SETL temp2,1
	ADD $4,temp1,temp2
	SET temp1,$4
	STT temp1,fp,0
	JMP L26
L27	LDT temp1,fp,0
	SET temp2,$0
	ADDU $5,temp2,temp1
	SETL temp1,0
	SET $6,temp1
	LDB temp1,$5,0
	SET temp2,$6
	SUB $7,temp1,temp2
	ZSNZ $7,$7,1
	SET $0,$7
	SET sp,fp
	SET fp,$10
	SET disp2,$9
	PUT rJ,$8
	POP 1,0

L28	GET $6,rJ
	SET $7,disp2
	SET $8,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,0
L29	LDT temp1,fp,0
	SETL temp2,256
	SUB $2,temp1,temp2
	ZSN $2,$2,1
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $3,temp2,temp1
	SETL temp1,0
	SET $4,temp1
	LDB temp1,$3,0
	SET temp2,$4
	SUB $5,temp1,temp2
	ZSNZ $5,$5,1
	SET temp1,$2
	SET temp2,$5
	AND $3,temp1,temp2
	SET temp1,$3
	BZ temp1,L30
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $4,temp2,temp1
	LDB temp1,$4,0
	STB temp1,$3,0
	LDT temp1,fp,0
	SETL temp2,1
	ADD $3,temp1,temp2
	SET temp1,$3
	STT temp1,fp,0
	JMP L29
L30	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $4,temp2,temp1
	LDB temp1,$4,0
	STB temp1,$3,0
	SET sp,fp
	SET fp,$8
	SET disp2,$7
	PUT rJ,$6
	POP 0,0

L31	GET $7,rJ
	SET $8,disp2
	SET $9,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SETL temp1,0
	STT temp1,fp,0
L32	LDT temp1,fp,0
	SET temp2,$2
	ADD $3,temp1,temp2
	SET temp1,$3
	SETL temp2,256
	SUB $4,temp1,temp2
	ZSN $4,$4,1
	LDT temp1,fp,0
	SET temp2,$2
	ADD $3,temp1,temp2
	SET temp1,$3
	SET temp2,$1
	ADDU $5,temp2,temp1
	SETL temp1,0
	SET $3,temp1
	LDB temp1,$5,0
	SET temp2,$3
	SUB $6,temp1,temp2
	ZSNZ $6,$6,1
	SET temp1,$4
	SET temp2,$6
	AND $3,temp1,temp2
	SET temp1,$3
	BZ temp1,L33
	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$2
	ADD $5,temp1,temp2
	SET temp1,$5
	SET temp2,$1
	ADDU $6,temp2,temp1
	LDB temp1,$6,0
	STB temp1,$3,0
	LDT temp1,fp,0
	SETL temp2,1
	ADD $3,temp1,temp2
	SET temp1,$3
	STT temp1,fp,0
	JMP L32
L33	LDT temp1,fp,0
	SET temp2,$0
	ADDU $3,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$2
	ADD $5,temp1,temp2
	SET temp1,$5
	SET temp2,$1
	ADDU $6,temp2,temp1
	LDB temp1,$6,0
	STB temp1,$3,0
	SET sp,fp
	SET fp,$9
	SET disp2,$8
	PUT rJ,$7
	POP 0,0

L34	GET $7,rJ
	SET $8,disp2
	SET $9,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SET temp1,$2
	STT temp1,fp,0
L35	LDT temp1,fp,0
	SETL temp2,256
	SUB $4,temp1,temp2
	ZSN $4,$4,1
	LDT temp1,fp,0
	SET temp2,$3
	SUB $5,temp1,temp2
	ZSNP $5,$5,1
	SET temp1,$4
	SET temp2,$5
	AND $6,temp1,temp2
	SET temp1,$6
	BZ temp1,L36
	LDT temp1,fp,0
	SET temp2,$2
	SUB $5,temp1,temp2
	SET temp1,$5
	SET temp2,$0
	ADDU $6,temp2,temp1
	LDT temp1,fp,0
	SET temp2,$1
	ADDU $5,temp2,temp1
	LDB temp1,$5,0
	STB temp1,$6,0
	LDT temp1,fp,0
	SETL temp2,1
	ADD $5,temp1,temp2
	SET temp1,$5
	STT temp1,fp,0
	JMP L35
L36	LDT temp1,fp,0
	SET temp2,$2
	SUB $5,temp1,temp2
	SET temp1,$5
	SET temp2,$0
	ADDU $6,temp2,temp1
	SETL temp1,0
	SET $5,temp1
	SET temp1,$5
	STB temp1,$6,0
	SET sp,fp
	SET fp,$9
	SET disp2,$8
	PUT rJ,$7
	POP 0,0

L37	GET $8,rJ
	SET $9,disp2
	SET $10,fp
	SET fp,sp
	SETL $255,528
	ADDU sp,sp,$255
	SET disp2,fp
	SETL temp1,0
	SETL temp10,256
	STT temp1,fp,temp10
	SETL temp1,0
	SETL temp10,264
	STT temp1,fp,temp10
L38	SETL temp10,256
	LDT temp1,fp,temp10
	SETL temp2,256
	SUB $3,temp1,temp2
	ZSN $3,$3,1
	SETL temp10,256
	LDT temp1,fp,temp10
	SET temp2,$1
	ADDU $4,temp2,temp1
	SETL temp1,0
	SET $5,temp1
	LDB temp1,$4,0
	SET temp2,$5
	SUB $6,temp1,temp2
	ZSNZ $6,$6,1
	SET temp1,$3
	SET temp2,$6
	AND $4,temp1,temp2
	SET temp1,$4
	BZ temp1,L39
	SETL temp10,264
	LDT temp1,fp,temp10
	SET temp2,fp
	ADDU $4,temp2,temp1
	SETL temp10,256
	LDT temp1,fp,temp10
	SET temp2,$1
	ADDU $5,temp2,temp1
	LDB temp1,$5,0
	STB temp1,$4,0
	SETL temp10,256
	LDT temp1,fp,temp10
	SETL temp2,1
	ADD $4,temp1,temp2
	SET temp1,$4
	SETL temp10,256
	STT temp1,fp,temp10
	SETL temp10,264
	LDT temp1,fp,temp10
	SETL temp2,1
	ADD $4,temp1,temp2
	SET temp1,$4
	SETL temp10,264
	STT temp1,fp,temp10
	JMP L38
L39	SETL temp1,0
	SETL temp10,256
	STT temp1,fp,temp10
L40	SETL temp10,256
	LDT temp1,fp,temp10
	SETL temp2,256
	SUB $4,temp1,temp2
	ZSN $4,$4,1
	SETL temp10,256
	LDT temp1,fp,temp10
	SET temp2,$2
	ADDU $5,temp2,temp1
	SETL temp1,0
	SET $6,temp1
	LDB temp1,$5,0
	SET temp2,$6
	SUB $7,temp1,temp2
	ZSNZ $7,$7,1
	SET temp1,$4
	SET temp2,$7
	AND $5,temp1,temp2
	SET temp1,$5
	BZ temp1,L41
	SETL temp10,264
	LDT temp1,fp,temp10
	SET temp2,fp
	ADDU $5,temp2,temp1
	SETL temp10,256
	LDT temp1,fp,temp10
	SET temp2,$2
	ADDU $6,temp2,temp1
	LDB temp1,$6,0
	STB temp1,$5,0
	SETL temp10,256
	LDT temp1,fp,temp10
	SETL temp2,1
	ADD $5,temp1,temp2
	SET temp1,$5
	SETL temp10,256
	STT temp1,fp,temp10
	SETL temp10,264
	LDT temp1,fp,temp10
	SETL temp2,1
	ADD $5,temp1,temp2
	SET temp1,$5
	SETL temp10,264
	STT temp1,fp,temp10
	JMP L40
L41	SETL temp10,264
	LDT temp1,fp,temp10
	SET temp2,fp
	ADDU $5,temp2,temp1
	SETL temp1,0
	SET $6,temp1
	SET temp1,$6
	STB temp1,$5,0
	SET temp1,$0
	SET $15,temp1
	SETL temp4,256
	SETL temp5,0
	SET temp1,fp
	SETL $255,272
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,272
	ADDU temp1,fp,$255
	SET $16,temp1
	PUSHJ $14,L28
	SET sp,fp
	SET fp,$10
	SET disp2,$9
	PUT rJ,$8
	POP 0,0

L42	GET $4,rJ
	SET $5,disp2
	SET $6,fp
	SET fp,sp
	SETL $255,256
	ADDU sp,sp,$255
	SET disp2,fp
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $2,temp1
	SET temp1,$0
	STT temp1,$2,0
	SETL $255,2576
	ADDU temp1,disp1,$255
	SETL $255,264
	ADDU $2,temp1,$255
	SET temp1,$2
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	SET temp1,$1
	SET temp2,fp
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SET temp1,fp
	SET $12,temp1
	PUSHJ $10,L28
	SETL $255,2576
	ADDU temp1,disp1,$255
	SETL $255,520
	ADDU $2,temp1,$255
	SETL temp10,3120
	LDT temp1,disp1,temp10
	STT temp1,$2,0
	SET sp,fp
	SET fp,$6
	SET disp2,$5
	PUT rJ,$4
	POP 0,0

L43	GET $3,rJ
	SET $4,disp2
	SET $5,fp
	SET fp,sp
	SETL $255,19456
	ADDU sp,sp,$255
	SET disp2,fp
	SETL $255,2576
	ADDU temp1,disp1,$255
	SETL $255,264
	ADDU $0,temp1,$255
	SET temp1,$0
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,48
	SET temp2,fp
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SET temp1,fp
	SET $11,temp1
	PUSHJ $9,L28
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$1
	SETL $255,256
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,256
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,72
	SETL $255,512
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,512
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $2,$9
	SET temp1,$2
	BZ temp1,L44
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $1,temp1
	SETL temp1,257
	STT temp1,$1,0
	JMP L45
L44	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,768
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,768
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,88
	SETL $255,1024
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1024
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L46
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,258
	STT temp1,$0,0
	JMP L45
L46	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,1280
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1280
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,104
	SETL $255,1536
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1536
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L47
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,259
	STT temp1,$0,0
	JMP L45
L47	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,1792
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1792
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,120
	SETL $255,2048
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2048
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L48
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,261
	STT temp1,$0,0
	JMP L45
L48	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,2304
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2304
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,136
	SETL $255,2560
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2560
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L49
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,262
	STT temp1,$0,0
	JMP L45
L49	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,2816
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2816
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,152
	SETL $255,3072
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3072
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L50
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,263
	STT temp1,$0,0
	JMP L45
L50	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,3328
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3328
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,168
	SETL $255,3584
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3584
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L51
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,299
	STT temp1,$0,0
	JMP L45
L51	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,3840
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3840
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,184
	SETL $255,4096
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4096
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L52
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,298
	STT temp1,$0,0
	JMP L45
L52	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,4352
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4352
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,200
	SETL $255,4608
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4608
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L53
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,297
	STT temp1,$0,0
	JMP L45
L53	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,4864
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4864
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,216
	SETL $255,5120
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5120
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L54
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,295
	STT temp1,$0,0
	JMP L45
L54	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,5376
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5376
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,232
	SETL $255,5632
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5632
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L55
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,297
	STT temp1,$0,0
	JMP L45
L55	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,5888
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5888
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	ADDU temp1,temp1,248
	SETL $255,6144
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6144
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L56
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,295
	STT temp1,$0,0
	JMP L45
L56	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,6400
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6400
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,264
	ADDU temp1,temp1,$255
	SETL $255,6656
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6656
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L57
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,303
	STT temp1,$0,0
	JMP L45
L57	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,6912
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6912
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,280
	ADDU temp1,temp1,$255
	SETL $255,7168
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,7168
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L58
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,304
	STT temp1,$0,0
	JMP L45
L58	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,7424
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,7424
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,296
	ADDU temp1,temp1,$255
	SETL $255,7680
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,7680
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L59
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,305
	STT temp1,$0,0
	JMP L45
L59	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,7936
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,7936
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,312
	ADDU temp1,temp1,$255
	SETL $255,8192
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,8192
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L60
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,268
	STT temp1,$0,0
	JMP L45
L60	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,8448
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,8448
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,328
	ADDU temp1,temp1,$255
	SETL $255,8704
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,8704
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L61
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,269
	STT temp1,$0,0
	JMP L45
L61	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,8960
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,8960
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,344
	ADDU temp1,temp1,$255
	SETL $255,9216
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,9216
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L62
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,270
	STT temp1,$0,0
	JMP L45
L62	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,9472
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,9472
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,360
	ADDU temp1,temp1,$255
	SETL $255,9728
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,9728
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L63
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,271
	STT temp1,$0,0
	JMP L45
L63	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,9984
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,9984
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,376
	ADDU temp1,temp1,$255
	SETL $255,10240
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,10240
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L64
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,272
	STT temp1,$0,0
	JMP L45
L64	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,10496
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,10496
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,392
	ADDU temp1,temp1,$255
	SETL $255,10752
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,10752
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L65
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,273
	STT temp1,$0,0
	JMP L45
L65	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,11008
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,11008
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,408
	ADDU temp1,temp1,$255
	SETL $255,11264
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,11264
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L66
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,274
	STT temp1,$0,0
	JMP L45
L66	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,11520
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,11520
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,424
	ADDU temp1,temp1,$255
	SETL $255,11776
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,11776
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L67
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,275
	STT temp1,$0,0
	JMP L45
L67	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,12032
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,12032
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,440
	ADDU temp1,temp1,$255
	SETL $255,12288
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,12288
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L68
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,276
	STT temp1,$0,0
	JMP L45
L68	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,12544
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,12544
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,456
	ADDU temp1,temp1,$255
	SETL $255,12800
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,12800
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L69
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,277
	STT temp1,$0,0
	JMP L45
L69	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,13056
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,13056
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,472
	ADDU temp1,temp1,$255
	SETL $255,13312
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,13312
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L70
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,278
	STT temp1,$0,0
	JMP L45
L70	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,13568
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,13568
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,488
	ADDU temp1,temp1,$255
	SETL $255,13824
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,13824
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L71
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,279
	STT temp1,$0,0
	JMP L45
L71	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,14080
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,14080
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,504
	ADDU temp1,temp1,$255
	SETL $255,14336
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,14336
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L72
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,280
	STT temp1,$0,0
	JMP L45
L72	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,14592
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,14592
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,520
	ADDU temp1,temp1,$255
	SETL $255,14848
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,14848
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L73
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,281
	STT temp1,$0,0
	JMP L45
L73	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,15104
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,15104
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,536
	ADDU temp1,temp1,$255
	SETL $255,15360
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,15360
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L74
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,286
	STT temp1,$0,0
	JMP L45
L74	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,15616
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,15616
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,552
	ADDU temp1,temp1,$255
	SETL $255,15872
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,15872
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L75
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,291
	STT temp1,$0,0
	JMP L45
L75	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,16128
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,16128
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,568
	ADDU temp1,temp1,$255
	SETL $255,16384
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,16384
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L76
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,267
	STT temp1,$0,0
	JMP L45
L76	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,16640
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,16640
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,584
	ADDU temp1,temp1,$255
	SETL $255,16896
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,16896
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L77
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,266
	STT temp1,$0,0
	JMP L45
L77	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,17152
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,17152
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,600
	ADDU temp1,temp1,$255
	SETL $255,17408
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,17408
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L78
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,282
	STT temp1,$0,0
	JMP L45
L78	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,17664
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,17664
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,616
	ADDU temp1,temp1,$255
	SETL $255,17920
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,17920
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L79
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,283
	STT temp1,$0,0
	JMP L45
L79	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,18176
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,18176
	ADDU temp1,fp,$255
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,632
	ADDU temp1,temp1,$255
	SETL $255,18432
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,18432
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L13
	SET $1,$9
	SET temp1,$1
	BZ temp1,L80
	SETL $255,2576
	ADDU temp1,disp1,$255
	SET $0,temp1
	SETL temp1,284
	STT temp1,$0,0
	JMP L45
L80	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SETL temp4,256
	SETL temp5,0
	SET temp1,$0
	SETL $255,18688
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,18688
	ADDU temp1,fp,$255
	SET $10,temp1
	PUSHJ $9,L19
	SET $1,$9
	SET temp1,$1
	BZ temp1,L81
	SETL temp1,292
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,648
	ADDU temp1,temp1,$255
	SETL $255,18944
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,18944
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L42
	JMP L45
L81	SETL temp1,287
	SET $10,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,664
	ADDU temp1,temp1,$255
	SETL $255,19200
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,19200
	ADDU temp1,fp,$255
	SET $11,temp1
	PUSHJ $9,L42
L45	SET sp,fp
	SET fp,$5
	SET disp2,$4
	PUT rJ,$3
	POP 0,0

L82	GET $18,rJ
	SET $19,disp2
	SET $20,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SET temp1,$0
	SETL temp2,40
	SUB $2,temp1,temp2
	ZSZ $2,$2,1
	SET temp1,$0
	SETL temp2,41
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$2
	SET temp2,$3
	OR $4,temp1,temp2
	SET temp1,$0
	SETL temp2,91
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$4
	SET temp2,$3
	OR $5,temp1,temp2
	SET temp1,$0
	SETL temp2,93
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$5
	SET temp2,$3
	OR $6,temp1,temp2
	SET temp1,$0
	SETL temp2,58
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$6
	SET temp2,$3
	OR $7,temp1,temp2
	SET temp1,$0
	SETL temp2,59
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$7
	SET temp2,$3
	OR $8,temp1,temp2
	SET temp1,$0
	SETL temp2,44
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$8
	SET temp2,$3
	OR $9,temp1,temp2
	SET temp1,$0
	SETL temp2,42
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$9
	SET temp2,$3
	OR $10,temp1,temp2
	SET temp1,$0
	SETL temp2,43
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$10
	SET temp2,$3
	OR $11,temp1,temp2
	SET temp1,$0
	SETL temp2,45
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$11
	SET temp2,$3
	OR $12,temp1,temp2
	SET temp1,$0
	SETL temp2,61
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$12
	SET temp2,$3
	OR $13,temp1,temp2
	SET temp1,$0
	SETL temp2,47
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$13
	SET temp2,$3
	OR $14,temp1,temp2
	SET temp1,$0
	SETL temp2,62
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$14
	SET temp2,$3
	OR $15,temp1,temp2
	SET temp1,$0
	SETL temp2,60
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$15
	SET temp2,$3
	OR $16,temp1,temp2
	SET temp1,$0
	SETL temp2,124
	SUB $3,temp1,temp2
	ZSZ $3,$3,1
	SET temp1,$16
	SET temp2,$3
	OR $17,temp1,temp2
	SET temp1,$17
	BZ temp1,L83
	SETL temp1,1
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
	JMP L84
L83	SETL temp1,0
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
L84	LDB $0,fp,0
	SET sp,fp
	SET fp,$20
	SET disp2,$19
	PUT rJ,$18
	POP 1,0

L85	GET $5,rJ
	SET $6,disp2
	SET $7,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SET temp1,$0
	SETL temp2,32
	SUB $2,temp1,temp2
	ZSNP $2,$2,1
	SETL temp1,0
	SET $3,temp1
	SET temp1,$0
	SET temp2,$3
	SUB $4,temp1,temp2
	ZSNZ $4,$4,1
	SET temp1,$2
	SET temp2,$4
	AND $3,temp1,temp2
	SET temp1,$3
	BZ temp1,L86
	SETL temp1,1
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
	JMP L87
L86	SETL temp1,0
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
L87	LDB $0,fp,0
	SET sp,fp
	SET fp,$7
	SET disp2,$6
	PUT rJ,$5
	POP 1,0

L88	GET $5,rJ
	SET $6,disp2
	SET $7,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SET temp1,$0
	SETL temp2,48
	SUB $2,temp1,temp2
	ZSNN $2,$2,1
	SET temp1,$0
	SETL temp2,57
	SUB $3,temp1,temp2
	ZSNP $3,$3,1
	SET temp1,$2
	SET temp2,$3
	AND $4,temp1,temp2
	SET temp1,$4
	BZ temp1,L89
	SETL temp1,1
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
	JMP L90
L89	SETL temp1,0
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
L90	LDB $0,fp,0
	SET sp,fp
	SET fp,$7
	SET disp2,$6
	PUT rJ,$5
	POP 1,0

L91	GET $9,rJ
	SET $10,disp2
	SET $11,fp
	SET fp,sp
	ADDU sp,sp,8
	SET disp2,fp
	SET temp1,$0
	SETL temp2,65
	SUB $2,temp1,temp2
	ZSNN $2,$2,1
	SET temp1,$0
	SETL temp2,90
	SUB $3,temp1,temp2
	ZSNP $3,$3,1
	SET temp1,$2
	SET temp2,$3
	AND $4,temp1,temp2
	SET temp1,$0
	SETL temp2,97
	SUB $3,temp1,temp2
	ZSNN $3,$3,1
	SET temp1,$0
	SETL temp2,122
	SUB $5,temp1,temp2
	ZSNP $5,$5,1
	SET temp1,$3
	SET temp2,$5
	AND $6,temp1,temp2
	SET temp1,$4
	SET temp2,$6
	OR $5,temp1,temp2
	SET temp1,$0
	SET $16,temp1
	PUSHJ $15,L88
	SET $6,$15
	SET temp1,$5
	SET temp2,$6
	OR $7,temp1,temp2
	SET temp1,$0
	SETL temp2,95
	SUB $6,temp1,temp2
	ZSZ $6,$6,1
	SET temp1,$7
	SET temp2,$6
	OR $8,temp1,temp2
	SET temp1,$8
	BZ temp1,L92
	SETL temp1,1
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
	JMP L93
L92	SETL temp1,0
	STB temp1,fp,0
	SET temp1,fp
	SET $1,temp1
L93	LDB $0,fp,0
	SET sp,fp
	SET fp,$11
	SET disp2,$10
	PUT rJ,$9
	POP 1,0

L94	GET $4,rJ
	SET $5,disp2
	SET $6,fp
	SET fp,sp
	SETL $255,10240
	ADDU sp,sp,$255
	SET disp2,fp
	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,58
	SUB $1,temp1,temp2
	ZSZ $1,$1,1
	SET temp1,$1
	BZ temp1,L95
	PUSHJ $10,L3
	SET $1,$10
	SET temp1,$1
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,61
	SUB $2,temp1,temp2
	ZSZ $2,$2,1
	SET temp1,$2
	BZ temp1,L96
	SETL temp1,293
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,688
	ADDU temp1,temp1,$255
	SET temp2,fp
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SET temp1,fp
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $2,temp1,8
	SET temp1,$2
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,704
	ADDU temp1,temp1,$255
	SETL $255,256
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,256
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	PUSHJ $10,L3
	SET $2,$10
	SET temp1,$2
	SETL temp10,3112
	STB temp1,disp1,temp10
	JMP L97
L96	SETL temp1,58
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,720
	ADDU temp1,temp1,$255
	SETL $255,512
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,512
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SET temp1,$1
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,736
	ADDU temp1,temp1,$255
	SETL $255,768
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,768
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
L97	JMP L98
L95	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,60
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L99
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,61
	SUB $1,temp1,temp2
	ZSZ $1,$1,1
	SET temp1,$1
	BZ temp1,L100
	SETL temp1,302
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,752
	ADDU temp1,temp1,$255
	SETL $255,1024
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1024
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SET temp1,$1
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,768
	ADDU temp1,temp1,$255
	SETL $255,1280
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1280
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	PUSHJ $10,L3
	SET $1,$10
	SET temp1,$1
	SETL temp10,3112
	STB temp1,disp1,temp10
	JMP L101
L100	SETL temp1,60
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,784
	ADDU temp1,temp1,$255
	SETL $255,1536
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1536
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,800
	ADDU temp1,temp1,$255
	SETL $255,1792
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,1792
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
L101	JMP L98
L99	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,62
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L102
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,61
	SUB $1,temp1,temp2
	ZSZ $1,$1,1
	SET temp1,$1
	BZ temp1,L103
	SETL temp1,301
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,816
	ADDU temp1,temp1,$255
	SETL $255,2048
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2048
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SET temp1,$1
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,832
	ADDU temp1,temp1,$255
	SETL $255,2304
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2304
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	PUSHJ $10,L3
	SET $1,$10
	SET temp1,$1
	SETL temp10,3112
	STB temp1,disp1,temp10
	JMP L104
L103	SETL temp1,62
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,848
	ADDU temp1,temp1,$255
	SETL $255,2560
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2560
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,864
	ADDU temp1,temp1,$255
	SETL $255,2816
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,2816
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
L104	JMP L98
L102	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,47
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L105
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,61
	SUB $1,temp1,temp2
	ZSZ $1,$1,1
	SET temp1,$1
	BZ temp1,L106
	SETL temp1,300
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,880
	ADDU temp1,temp1,$255
	SETL $255,3072
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3072
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SET temp1,$1
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,896
	ADDU temp1,temp1,$255
	SETL $255,3328
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3328
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	PUSHJ $10,L3
	SET $1,$10
	SET temp1,$1
	SETL temp10,3112
	STB temp1,disp1,temp10
	JMP L107
L106	SETL temp1,47
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,912
	ADDU temp1,temp1,$255
	SETL $255,3584
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3584
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,928
	ADDU temp1,temp1,$255
	SETL $255,3840
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,3840
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
L107	JMP L98
L105	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,61
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L108
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp1,61
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,944
	ADDU temp1,temp1,$255
	SETL $255,4096
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4096
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,960
	ADDU temp1,temp1,$255
	SETL $255,4352
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4352
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	JMP L98
L108	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,42
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L109
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,42
	SUB $1,temp1,temp2
	ZSZ $1,$1,1
	SET temp1,$1
	BZ temp1,L110
	SETL temp1,265
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,976
	ADDU temp1,temp1,$255
	SETL $255,4608
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4608
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $1,temp1,8
	SET temp1,$1
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,992
	ADDU temp1,temp1,$255
	SETL $255,4864
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,4864
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	PUSHJ $10,L3
	SET $1,$10
	SET temp1,$1
	SETL temp10,3112
	STB temp1,disp1,temp10
	JMP L111
L110	SETL temp1,42
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1008
	ADDU temp1,temp1,$255
	SETL $255,5120
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5120
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1024
	ADDU temp1,temp1,$255
	SETL $255,5376
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5376
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
L111	JMP L98
L109	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,43
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L112
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp1,43
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1040
	ADDU temp1,temp1,$255
	SETL $255,5632
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5632
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1056
	ADDU temp1,temp1,$255
	SETL $255,5888
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,5888
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	JMP L98
L112	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,45
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L113
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp1,45
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1072
	ADDU temp1,temp1,$255
	SETL $255,6144
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6144
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1088
	ADDU temp1,temp1,$255
	SETL $255,6400
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6400
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	JMP L98
L113	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,124
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L114
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp1,124
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1104
	ADDU temp1,temp1,$255
	SETL $255,6656
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6656
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L42
	SETL $255,2576
	ADDU temp1,disp1,$255
	ADDU $0,temp1,8
	SET temp1,$0
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1120
	ADDU temp1,temp1,$255
	SETL $255,6912
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B
2H	SET $255,$255
	SETL $255,6912
	ADDU temp1,fp,$255
	SET $12,temp1
	PUSHJ $10,L28
	JMP L98
L114	SETL temp10,3112
	LDB temp1,disp1,temp10
	SETL temp2,91
	SUB $0,temp1,temp2
	ZSZ $0,$0,1
	SET temp1,$0
	BZ temp1,L115
	PUSHJ $10,L3
	SET $0,$10
	SET temp1,$0
	SETL temp10,3112
	STB temp1,disp1,temp10
	SETL temp1,91
	SET $11,temp1
	SETL temp4,256
	SETL temp5,0
	GETA temp1,STRINGS
	SETL $255,1136
	ADDU temp1,temp1,$255
	SETL $255,7168
	ADDU temp2,fp,$255
1H	LDOU temp3,temp1,temp5
	STOU temp3,temp2,temp5
	BZ temp3,2F
	ADD temp5,temp5,8
	SUB temp4,temp4,8
	PBNZ temp4,1B