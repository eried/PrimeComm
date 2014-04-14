<!--VB ADO Constants file.  Needed for the ad... constants we use-->
<!-- #include file="adovbs.inc" -->
<%
' BEGIN USER CONSTANTS
Dim CONN_STRING
Dim CONN_USER
Dim CONN_PASS

' I'm using a DSN-less connection.
' To use a DSN, the format is shown on the next line:
'CONN_STRING = "DSN=DSNName;"

CONN_STRING = "DBQ=" & Server.MapPath("database.mdb") & ";"
CONN_STRING = CONN_STRING & "Driver={Microsoft Access Driver (*.mdb)};"

' This DB is unsecured, o/w you'd need to specify something here
CONN_USER = ""
CONN_PASS = ""

' Our SQL code - overriding values we just set
' Comment out to use Access
CONN_STRING = "Provider=SQLOLEDB;Data Source=10.2.1.214;" _
	& "Initial Catalog=samples;Connect Timeout=15;" _
	& "Network Library=dbmssocn;"
CONN_USER = "samples"
CONN_PASS = "password"
' END USER CONSTANTS


' BEGIN RUNTIME CODE
' Declare our vars
Dim iPageSize       'How big our pages are
Dim iPageCount      'The number of pages we get back
Dim iPageCurrent    'The page we want to show
Dim strOrderBy      'A fake parameter used to illustrate passing them
Dim strSQL          'SQL command to execute
Dim objPagingConn   'The ADODB connection object
Dim objPagingRS     'The ADODB recordset object
Dim iRecordsShown   'Loop controller for displaying just iPageSize records
Dim I               'Standard looping var

' Get parameters
iPageSize = 10 ' You could easily allow users to change this

' Retrieve page to show or default to 1
If Request.QueryString("page") = "" Then
	iPageCurrent = 1
Else
	iPageCurrent = CInt(Request.QueryString("page"))
End If

' If you're doing this script with a search or something
' you'll need to pass the sql from page to page.  I'm just
' paging through the entire table so I just hard coded it.
' What you show is irrelevant to the point of the sample.
'strSQL = "SELECT * FROM sample ORDER BY id;"

' Sept 30, 1999: Code Change
' Based on the non stop questions about how to pass parameters
' from page to page, I'm implementing it so I can stop answering
' the question of how to do it.  I personally think this should
' be done based on the specific situation and is clearer if done
' in the same method on all pages, but it's really up to you.
' I'm going to be passing the ORDER BY parameter for illustration.

' This is where you read in parameters you'll need for your query.
' Read in order or default to id
'If Request.QueryString("order") = "" Then
'	strOrderBy = "id"
'Else
'	strOrderBy = Replace(Request.QueryString("order"), "'", "''")
'End If

' Make sure the input is one of our fields.
strOrderBy = LCase(Request.QueryString("order"))
Select Case strOrderBy
	Case "last_name", "first_name", "sales"
		' A little pointless, but...
		strOrderBy = strOrderBy
	Case Else
		strOrderBy = "id"
End Select

' Build our SQL String using the parameters we just got.
strSQL = "SELECT * FROM sample ORDER BY " & strOrderBy & ";"

' Some lines I used while writing to debug... uh "test", yeah that's it!
' Left them FYI.
'strSQL = "SELECT * FROM sample WHERE id=1234 ORDER BY id;"
'strSQL = "SELECT * FROM sample;"
'Response.Write "SQL Query: " &  strSQL & "<BR>" & vbCrLf


' Now we finally get to the DB work...
' Create and open our connection
Set objPagingConn = Server.CreateObject("ADODB.Connection")
objPagingConn.Open CONN_STRING, CONN_USER, CONN_PASS

' Create recordset and set the page size
Set objPagingRS = Server.CreateObject("ADODB.Recordset")
objPagingRS.PageSize = iPageSize

' You can change other settings as with any RS
'objPagingRS.CursorLocation = adUseClient
objPagingRS.CacheSize = iPageSize

' Open RS
objPagingRS.Open strSQL, objPagingConn, adOpenStatic, adLockReadOnly, adCmdText

' Get the count of the pages using the given page size
iPageCount = objPagingRS.PageCount

' If the request page falls outside the acceptable range,
' give them the closest match (1 or max)
If iPageCurrent > iPageCount Then iPageCurrent = iPageCount
If iPageCurrent < 1 Then iPageCurrent = 1

' Check page count to prevent bombing when zero results are returned!
If iPageCount = 0 Then
	Response.Write "No records found!"
Else
	' Move to the selected page
	objPagingRS.AbsolutePage = iPageCurrent

	' Start output with a page x of n line
	%>
	<p>
	<font size="+1">Page <strong><%= iPageCurrent %></strong>
	of <strong><%= iPageCount %></strong></font>
	</p>
	<%
	' Spacing
	Response.Write vbCrLf

	' Continue with a title row in our table
	Response.Write "<table border=""1"">" & vbCrLf

	' Show field names in the top row
	Response.Write vbTab & "<tr>" & vbCrLf
	For I = 0 To objPagingRS.Fields.Count - 1
	    Response.Write vbTab & vbTab & "<th>"
	    Response.Write objPagingRS.Fields(I).Name
	    Response.Write "</th>" & vbCrLf
	Next 'I
	Response.Write vbTab & "</tr>" & vbCrLf

	' Loop through our records and ouput 1 row per record
	iRecordsShown = 0
	Do While iRecordsShown < iPageSize And Not objPagingRS.EOF
		Response.Write vbTab & "<tr>" & vbCrLf
		For I = 0 To objPagingRS.Fields.Count - 1
		    Response.Write vbTab & vbTab & "<td>"
		    Response.Write objPagingRS.Fields(I)
		    Response.Write "</td>" & vbCrLf
		Next 'I
		Response.Write vbTab & "</tr>" & vbCrLf

		' Increment the number of records we've shown
		iRecordsShown = iRecordsShown + 1
		' Can't forget to move to the next record!
		objPagingRS.MoveNext
	Loop

	' All done - close table
	Response.Write "</table>" & vbCrLf
End If

' Close DB objects and free variables
objPagingRS.Close
Set objPagingRS = Nothing
objPagingConn.Close
Set objPagingConn = Nothing


' Show "previous" and "next" page links which pass the page to view
' and any parameters needed to rebuild the query.  You could just as
' easily use a form but you'll need to change the lines that read
' the info back in at the top of the script.
If iPageCurrent > 1 Then
	%>
	<a href="db_paging.asp?page=<%= iPageCurrent - 1 %>&order=<%= Server.URLEncode(strOrderBy) %>">[&lt;&lt; Prev]</a>
	<%
End If

' You can also show page numbers:
For I = 1 To iPageCount
	If I = iPageCurrent Then
		%>
		<%= I %>
		<%
	Else
		%>
		<a href="db_paging.asp?page=<%= I %>&order=<%= Server.URLEncode(strOrderBy) %>"><%= I %></a>
		<%
	End If
Next 'I

If iPageCurrent < iPageCount Then
	%>
	<a href="db_paging.asp?page=<%= iPageCurrent + 1 %>&order=<%= Server.URLEncode(strOrderBy) %>">[Next &gt;&gt;]</a>
	<%
End If

' END RUNTIME CODE
%>

