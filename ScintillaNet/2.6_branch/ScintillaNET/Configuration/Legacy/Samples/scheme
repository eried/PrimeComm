/*****************************************************************/
 /*           S A S   S A M P L E   L I B R A R Y                 */
 /*                                                               */
 /*     NAME: IMPRTSCH                                            */
 /*    TITLE: Import a scheme file from DataFlux' dfPower .SCH    */
 /*              file format                                      */
 /*  PRODUCT: SAS Data Quality - Cleanse                          */
 /*   SYSTEM: Windows, UNIX                                       */
 /*     KEYS: import scheme .sch dataflux dfpower                 */
 /*    PROCS:                                                     */
 /*     DATA: EXTERNAL                                            */
 /*                                                               */
 /*   UPDATE: 22MAY2001                                           */
 /*      REF:                                                     */
 /*                                                               */
 /*     MISC: dfPower 4.0 and earlier stores schemes in .SCH      */
 /*           files in the Scheme Vault, which by default is      */
 /*           located at:                                         */
 /*        C:\Program Files\DataFlux\dfPower Studio\vault\Schemes */
 /*                                                               */
 /*           SAS Data Quality - Cleanse stores schemes in SAS    */
 /*           data sets.                                          */
 /*                                                               */
 /*           This code defines a macro, IMPRTSCH, which allows   */
 /*           you to import a .SCH file into a SAS data set of    */
 /*           the form needed by SAS Data Quality - Cleanse.      */
 /*                                                               */
 /*    USAGE: The IMPRTSCH macro has 3 parameters:                */
 /*                                                               */
 /*           1) The first parameter is a positional parameter    */
 /*              named SCHEMENAME.  This parameter represents the */
 /*              name of the scheme file that you want to import  */
 /*              (omit the .SCH extension).  This parameter is    */
 /*              required.                                        */
 /*                                                               */
 /*           2) The second parameter is a keyword parameter      */
 /*              named SCHEMEVAULT.  This parameter represents    */
 /*              the directory in which the scheme file can be    */
 /*              found (omit the trailing slash/backslash).  If   */
 /*              not specified, this will default to the          */
 /*              default Scheme Vault directory at:               */
 /*       C:\Program Files\DataFlux\dfPower Studio\vault\Schemes  */
 /*                                                               */
 /*           3) The third parameter is a keyword parameter       */
 /*              named LIBREF.  This parameter represents the     */
 /*              SAS library in which you want the SAS scheme     */
 /*              data set stored.  It must be a libref that is    */
 /*              already allocated.  If not specified, this will  */
 /*              default to WORK.  The name of the SAS scheme data*/
 /*              set is not specified by the user, as it will     */
 /*              be the same as that of the original scheme file, */
 /*              assuming that it obeys the rules for SAS data    */
 /*              set names.  If not, the macro attempts to        */
 /*              transform it to a valid SAS data set name.  The  */
 /*              name of the new SAS scheme data set, after any   */
 /*              name changes, will be generated in a note to the */
 /*              SAS Log.                                         */
 /*                                                               */
 /* EXAMPLES: To import the Fortune1000 scheme from the dfPower   */
 /*           (default) scheme vault into the WORK library, you   */
 /*           would invoke the macro as follows:                  */
 /*               %IMPRTSCH(Fortune1000)                          */
 /*                                                               */
 /*           To import the Fortune1000 scheme from the default   */
 /*           scheme vault into the SASUSER library, you would    */
 /*           invoke the macro as follows:                        */
 /*               %IMPRTSCH(Fortune1000, libref=SASUSER)          */
 /*                                                               */
 /*           To import the Fortune1000 scheme from the           */
 /*           C:\MySchemes directory into the SASUSER library,    */
 /*           you would invoke the macro as follows:              */
 /*               %IMPRTSCH(Fortune1000,                          */
 /*                         schemevault=C:\MySchemes,             */
 /*                         libref=SASUSER)                       */
 /*****************************************************************/

%macro imprtsch(
   schemename,
   schemevault=C:\Program Files\dataflux\dfPower Studio\vault\Schemes,
   libref=WORK);

/* Check to make sure that the schemename was specified. */
%if %length(&schemename) eq 0 %then %do;
   %put;
   %put ERROR: You must specify the name of a scheme file;
   %put ERROR: as the first parameter.  IMPRTSCH macro terminating.;
   %put;
   %goto FINE;
%end;

/* If the supplied SCHEMEVAULT has a slash at the end, remove it. */
%if %verify(%substr(&schemevault, %length(&schemevault)),/\) eq 0 %then
   %let schemevault=%substr(&schemevault, 1, %length(&schemevault)-1);

/* If the supplied SCHEMENAME has a .SCH extension at the end,
   remove it. */
%if %upcase(
       %substr(&schemename, %length(&schemename)-3)) eq .SCH %then
   %let schemename=%substr(&schemename, 1, %length(&schemename)-4);

/* Allocate the scheme file to import. */
filename schfile "&schemevault/&schemename..sch";

/* Verify that it was allocated. */
%if &SYSFILRC ne 0 %then %do;
   %put;
   %put ERROR: The specified scheme file:;
   %put ERROR:    "&schemevault\&schemename..sch";
   %put ERROR: could not be allocated.  IMPRTSCH macro terminating.;
   %put;
   %goto FINE;
%end;


/*---------------------------------------------------------------*/
/* Since the name of the .SCH file is also going to be used for  */
/*    the SAS data set name, we need to do some verification to  */
/*    see if it is a valid SAS data set name.  If not, translate */
/*    it to a data set name that is valid.                       */
/*---------------------------------------------------------------*/
%let alphas=ABCDEFGHIJKLMNOPQRSTUVWXYZ;
%let nums=1234567890;
%let underscore=_;
%let sasscheme=%upcase(&schemename);
%let libref=%upcase(&libref);

/* Check each character in the scheme file name to see that it
   is alpha, numeric or an underscore.  If not, convert that
   character to an underscore. */
%do %while (%verify(&sasscheme, &alphas&nums&underscore) ne 0);
   %let pos=%verify(&sasscheme, &alphas&nums&underscore);
   %let sasscheme=
        %substr(&sasscheme, 1, &pos-1)_%substr(&sasscheme, &pos+1);
%end;

/* Check to see that the first character is alpha or underscore.
      If not, add an underscore to the front. */
%if %verify(%substr(&sasscheme, 1, 1), &alphas&underscore) ne 0 %then
   %let sasscheme=_&sasscheme;

/* Place NOTEs in the log. */
%put;
%put NOTE: Beginning to import the DataFlux Scheme file:;
%put NOTE:     "&schemevault\&schemename..sch";
%put NOTE: to create SAS Scheme data set &libref..&sasscheme..;
%put;

/* Actually do the import. */
data &libref..&sasscheme;
   length data standard $255;
   infile schfile  firstobs=3 truncover;

   input data $char255.;
   input standard $char255.;
run;

/* Check to see if it worked. */
%if &SYSERR ne 0 %then %do;
   %put;
   %put ERROR: An error occurred when importing the scheme file.;
   %put ERROR: The exact error message can be found in the SAS Log.;
   %put ERROR: IMPRTSCH macro terminating.;
   %put;
   %goto FINE;
%end;

%FINE: %mend;
