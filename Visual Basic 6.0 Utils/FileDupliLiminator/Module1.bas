Attribute VB_Name = "Module1"
Option Explicit


'Public Sub EnumerateDrives(DriveType As eDriveType)
'Dim mydrive As Drive
'With fso
'For Each mydrive In .Drives
'    If mydrive.DriveType = DriveType Then
'        Call EnumerateFolders(.path & "\", True)
'    End If
'    If ExitNow Then Exit Sub
'Next
'End With
'End Sub


'Public Sub WriteDupes()
'Dim i&
'Open App.path & "\out.txt" For Output Access Write As #1
'For i = 0 To NumFilesStored - 1
'    If FileNameArray(i) <> "" Then
'    Print #1, FileNameArray(i) & vbTab & FilePathArray(IndexArray(i))
'    End If
'Next i
'Close #1
'End Sub

Sub Main()

End Sub
Public Sub QuickSortVariantArray(avarIn, indexarr&(), ByVal intLowBound&, ByVal intHighBound&)
  Dim intX&
  Dim intY&
  Dim varMidBound
  Dim varTmp
  Dim varTmp2
  On Error GoTo PROC_ERR
  ' If there is data to sort
  If intHighBound > intLowBound Then
    ' Calculate the value of the middle array element
    varMidBound = avarIn((intLowBound + intHighBound) \ 2)
    intX = intLowBound
    intY = intHighBound
    ' Split the array into halves
    Do While intX <= intY
      If avarIn(intX) >= varMidBound And avarIn(intY) <= varMidBound Then
        varTmp = avarIn(intX)
        varTmp2 = indexarr(intX)
        avarIn(intX) = avarIn(intY)
        indexarr(intX) = indexarr(intY)
        avarIn(intY) = varTmp
        indexarr(intY) = varTmp2
        intX = intX + 1
        intY = intY - 1
      Else
        If avarIn(intX) < varMidBound Then
          intX = intX + 1
        End If
        If avarIn(intY) > varMidBound Then
          intY = intY - 1
        End If
      End If
    Loop
    ' Sort the lower half of the array
    Call QuickSortVariantArray(avarIn, indexarr(), intLowBound, intY)
    'Sort the upper half of the array
    Call QuickSortVariantArray(avarIn, indexarr(), intX, intHighBound)
  End If
  
PROC_EXIT:
  Exit Sub

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "QuickSortVariantArray"
  Resume PROC_EXIT
End Sub


