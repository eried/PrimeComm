CREATE TABLE employee
(empno     CHARACTER (00006)    NOT NULL
,firstnme  VARCHAR   (00012)    NOT NULL
,midinit   CHARACTER (00001)    NOT NULL
,lastname  VARCHAR   (00015)    NOT NULL
,workdept  CHARACTER (00003)
,phoneno   CHARACTER (00004)
,hiredate  DATE
,job       CHARACTER (00008)
,edlevel   SMALLINT             NOT NULL
,SEX       CHARACTER (00001)
,birthdate DATE
,salary    DECIMAL   (00009,02)
,bonus     DECIMAL   (00009,02)
,comm      DECIMAL   (00009,02)
 )     
 DATA CAPTURE NONE;
Figure 17, DB2 sample table - EMPLOYEE






CREATE VIEW employee_view AS
SELECT   a.empno, a.firstnme, a.salary, a.workdept
FROM     employee a
WHERE    a.salary >=
        (SELECT AVG(b.salary)
         FROM   employee b
         WHERE  a.workdept = b.workdept);
Figure 18, DB2 sample view - EMPLOYEE_VIEW

