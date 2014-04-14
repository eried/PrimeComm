function WinMsgBox(msg, type, title)
{
/*	Script adapted by: 	Tjip Zigterman on March 25, 2003; Taken from bits and pieces off MSDN; Trial&Error on Sieb7.5.2.211
**	
**	What it does:		The script invokes the Windows Message Box 
**					(similar to Siebel v6 and earlier) 
**					For the Types of boxes the v6 values can be used (see below)
**					The Return Values are also identiacl to Siebel v6
**			Why:	This way MessageBoxes can be invoked from ServerScript.
**				
**			==> Best put in as an ApplicationScript.
**			
**	What's the catch? !!I have not tested against the Web Client!!
**
**	Change history: 2003-03-25; Created by TjZ
**		
**		
**		----Type Parameters 			----// Return Values 	-----
**		MB_OK                = 0		// Clicking "OK" 	returns: 1
**		MB_OKCANCEL          = 1		// Clicking "Cancel"	returns: 2
**		MB_ABORTRETRYIGNORE  = 2		// Clicking "Abort" 	returns: 3
**		MB_YESNOCANCEL       = 3		// Clicking "Retry" 	returns: 4
**		MB_YESNO             = 4		// Clicking "Ignore" 	returns: 5
**		MB_RETRYCANCEL       = 5		// Clicking "Yes" 	returns: 6
**		------------------------		// Clicking "No" 	returns: 7
**		MB_ICONSTOP          = 16	
**		MB_ICONQUESTION      = 32
**		MB_ICONEXCLAMATION   = 48
**		MB_ICONINFORMATION   = 64
**		------------------------
**		MB_DEFBUTTON1        = 0
**		MB_DEFBUTTON2        = 256
**		MB_DEFBUTTON3        = 512
**		------------------------
**		MB_APPLMODAL         = 0
**		MB_SYSTEMMODAL       = 4096
**		MB_TASKMODAL         = 8192	
**		
*/

try  
{
	// When no type is given, the Box gets confused sometimes.
	if(!type) {type = 0} 
	
	// Setting Your Title
	if(title)  {title = "YourAppTitle - " + title}
	if(!title) {title = "YourAppTitle"}
	
	// Important:
	// There is no semi-colon at the end of the SElib statement.   
	//
 	var retcode = SElib.dynamicLink("User32", "MessageBoxExA", STDCALL, 0, msg, title, type, 0x0407)
	return(retcode)
} 
catch(e) 
{
	TheApplication().RaiseErrorText("Error =" + e.toString() );
}

}
