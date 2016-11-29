Attribute VB_Name = "Module1"
Option Explicit

Sub Main()
Call Shell("explorer.exe /n," & Left(Command, InStrRev(Command, "\")), vbNormalFocus)
End Sub
