Attribute VB_Name = "Module1"
Option Explicit
Public Declare Function QPC Lib "kernel32" Alias "QueryPerformanceCounter" (lpPerformanceCount@) As Long
Public Declare Function QPF Lib "kernel32" Alias "QueryPerformanceFrequency" (lpFrequency@) As Long

Public fMainForm As frmMain
Public startsecs!
Sub Main()
  startsecs = Timer
  Set fMainForm = New frmMain
  fMainForm.Show
  
End Sub

Public Function SuperTimer#(ByVal Start As Boolean)
  'a really hi res timer with .001 ms resolution average
  Static F@, A@: Dim B@
  If Start Then
    QPF F                                         'CDbl(f) * 10000=ticks per second
    QPC A
  Else
    QPC B
    SuperTimer = Round(((CDbl(B) - CDbl(A)) / CDbl(F)) * 1000, 3)
    F = 0
    A = 0
  End If
End Function
