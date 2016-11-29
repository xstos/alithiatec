Attribute VB_Name = "Module1"
Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Long, ByVal lpstrBuffer As String, ByVal uLength As Long) As Long
Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long
Private Function SendMCIString(cmd As String, fShowError As Boolean) As Boolean
Static rc As Long
Static errStr As String * 200

rc = mciSendString(cmd, 0, 0, hWnd)
If (fShowError And rc <> 0) Then
    mciGetErrorString rc, errStr, Len(errStr)
    MsgBox errStr
End If
SendMCIString = (rc = 0)
If cmd = "set cd door closed" Then
Start = Timer   ' Set start time.
    Do While Timer < Start + 0.1
            ' Yield to other processes.
    Loop
End If
End Function
Sub Main()
If (SendMCIString("open cdaudio alias cd wait shareable", True) = False) Then
    End
End If
SendMCIString "set cd time format tmsf wait", True
SendMCIString "set cd door closed", True
SendMCIString "close all", True
End Sub
'SendMCIString "set cd door open", True
