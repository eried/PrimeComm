' NewTextEC.vbs
' Sample VBScript to write to a file. With added error-correcting
' Author Guy Thomas http://computerperformance.co.uk/
' Version 1.5 - August 2005
' ---------------------------------------------------------------' 

Option Explicit
Dim objFSO, objFolder, objShell, objTextFile, objFile
Dim strDirectory, strFile, strText
strDirectory = "e:\logs3"
strFile = "\Summer.txt"
strText = "Book Another Holiday"

' Create the File System Object
Set objFSO = CreateObject("Scripting.FileSystemObject")

' Check that the strDirectory folder exists
If objFSO.FolderExists(strDirectory) Then
   Set objFolder = objFSO.GetFolder(strDirectory)
Else
   Set objFolder = objFSO.CreateFolder(strDirectory)
   WScript.Echo "Just created " & strDirectory
End If

If objFSO.FileExists(strDirectory & strFile) Then
   Set objFolder = objFSO.GetFolder(strDirectory)
Else
   Set objFile = objFSO.CreateTextFile(strDirectory & strFile)
   Wscript.Echo "Just created " & strDirectory & strFile
End If 

set objFile = nothing
set objFolder = nothing
' OpenTextFile Method needs a Const value
' ForAppending = 8 ForReading = 1, ForWriting = 2
Const ForAppending = 8

Set objTextFile = objFSO.OpenTextFile _
(strDirectory & strFile, ForAppending, True)

' Writes strText every time you run this VBScript
objTextFile.WriteLine(strText)
objTextFile.Close

' Bonus or cosmetic section to launch explorer to check file
If err.number = vbEmpty then
   Set objShell = CreateObject("WScript.Shell")
   objShell.run ("Explorer" &" " & strDirectory & "\" )
Else WScript.echo "VBScript Error: " & err.number
End If

WScript.Quit

' End of VBScript to write to a file with error-correcting Code
