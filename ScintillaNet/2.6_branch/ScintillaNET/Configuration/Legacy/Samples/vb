
'This example program was provided by:
' SoftCircuits Programming
' http://www.softcircuits.com
' P.O. Box 16262
' Irvine, CA 92623
Option Explicit

Private Const NIM_ADD = &H0
Private Const NIM_MODIFY = &H1
Private Const NIM_DELETE = &H2

Private Const NIF_MESSAGE = &H1
Private Const NIF_ICON = &H2
Private Const NIF_TIP = &H4

Private Const WM_LBUTTONDOWN = &H201
Private Const WM_LBUTTONDBLCLK = &H203
Private Const WM_RBUTTONDOWN = &H204
Private Const WM_USER = &H400

Private Const VER_PLATFORM_WIN32s = 0
Private Const VER_PLATFORM_WIN32_WINDOWS = 1
Private Const VER_PLATFORM_WIN32_NT = 2

Private Type NOTIFYICONDATA
    cbSize As Long
    hwnd As Long
    uID As Long
    uFlags As Long
    uCallbackMessage As Long
    hIcon As Long
    szTip As String * 64
End Type
   
Private Type OSVERSIONINFO
    dwOSVersionInfoSize As Long
    dwMajorVersion As Long
    dwMinorVersion As Long
    dwBuildNumber As Long
    dwPlatformId As Long
    szCSDVersion As String * 128
End Type

Private Type MEMORYSTATUS
    dwLength As Long
    dwMemoryLoad As Long
    dwTotalPhys As Long
    dwAvailPhys As Long
    dwTotalPageFile As Long
    dwAvailPageFile As Long
    dwTotalVirtual As Long
    dwAvailVirtual As Long
End Type

Private Declare Function ShellNotifyIcon Lib "shell32.dll" Alias "Shell_NotifyIconA" (ByVal dwMessage As Long, lpData As NOTIFYICONDATA) As Long
Private Declare Function GetVersionEx Lib "Kernel32" Alias "GetVersionExA" (lpVersionInformation As OSVERSIONINFO) As Long
Private Declare Sub GlobalMemoryStatus Lib "Kernel32" (lpBuffer As MEMORYSTATUS)

Const WM_ICONNOTIFY = WM_USER + 100
Const ID_TASKBARICON = 100

'Initial form load
Private Sub Form_Load()
    Dim os As OSVERSIONINFO
    'Form is hidden initially
    Visible = False
    'Ensure valid operating system
    os.dwOSVersionInfoSize = Len(os)
    GetVersionEx os
    If os.dwMajorVersion < 4 Then
        MsgBox "This program requires Windows 95 or later, or Windows NT 4.0 or later."
        End
    End If
    'Setup Subclass
    Subclass1.hwnd = hwnd
    Subclass1.Messages(WM_ICONNOTIFY) = True
    'Setup icon notification from shell
    UpdateIcon NIM_ADD
End Sub

'Hide form
Private Sub mnuFileClose_Click()
    Visible = False
End Sub

'Show about box
Private Sub mnuFileAbout_Click()
    frmAbout.Show vbModal
End Sub

'Exit by unloading one and only form
Private Sub mnuFileExit_Click()
    Unload Me
End Sub

'Process tray notification messages
Private Sub Subclass1_WndProc(Msg As Long, wParam As Long, lParam As Long, Result As Long)
    If wParam = ID_TASKBARICON Then     'Is this for us?
        Select Case lParam
            Case WM_LBUTTONDOWN
            Case WM_LBUTTONDBLCLK
                'Display main window
                DisplayForm
            Case WM_RBUTTONDOWN
                'Display popup menu
                'Note: There is a potential problem here
                'as described in Microsoft knowledgebase
                'article Q135788. However, we were unable
                'to duplicate the documented problem here
                PopupMenu mnuPopup, , , , mnuPopupOpen
        End Select
    End If
End Sub

'Update memory status
Private Sub Timer1_Timer()
    UpdateIcon NIM_MODIFY
End Sub

'Just hide form if user presses Close button
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    If UnloadMode = vbFormControlMenu Then
        Me.Visible = False
        Cancel = True
    End If
End Sub

'Clean-up on unload
Private Sub Form_Unload(Cancel As Integer)
    'Remove icon from system tray
    UpdateIcon NIM_DELETE
End Sub

'Popup menu: show main form
Private Sub mnuPopupOpen_Click()
    DisplayForm
End Sub

'Popup menu: Show about box
Private Sub mnuPopupAbout_Click()
    mnuFileAbout_Click
End Sub

'Popup menu: unload program
Private Sub mnuPopupExit_Click()
    mnuFileExit_Click
End Sub

'Updates the tray icon data
Private Sub UpdateIcon(nAction As Integer)
    Dim nid As NOTIFYICONDATA
    Dim mem As MEMORYSTATUS

    'Get current memory status
    mem.dwLength = Len(mem)
    GlobalMemoryStatus mem
    'Update form if visible
    If Visible Then
        lblMemoryLoad = CStr(mem.dwMemoryLoad) & "%"
        lblTotalPhys = Format$(mem.dwTotalPhys, "#,##0") & " bytes"
        lblAvailPhys = Format$(mem.dwAvailPhys, "#,##0") & " bytes"
        lblTotalPageFile = Format$(mem.dwTotalPageFile, "#,##0") & " bytes"
        lblAvailPageFile = Format$(mem.dwAvailPageFile, "#,##0") & " bytes"
        lblTotalVirtual = Format$(mem.dwTotalVirtual, "#,##0") & " bytes"
        lblAvailVirtual = Format$(mem.dwAvailVirtual, "#,##0") & " bytes"
    End If
    'Update tray icon data
    nid.cbSize = LenB(nid)
    nid.hwnd = hwnd
    nid.uID = ID_TASKBARICON
    nid.uFlags = NIF_MESSAGE Or NIF_TIP Or NIF_ICON
    nid.uCallbackMessage = WM_ICONNOTIFY
    nid.hIcon = imgIcon(mem.dwMemoryLoad \ 25)
    nid.szTip = "Memory Load: " & CStr(mem.dwMemoryLoad) & "%" & Chr$(0)
    ShellNotifyIcon nAction, nid
End Sub

'Center, display and activate main form
Private Sub DisplayForm()
    If Visible = False Then
        'Display form
        Visible = True
        'Force update of memory status
        Timer1_Timer
    End If
    'This appears necessary
    SetFocus
End Sub

