Attribute VB_Name = "Module1"
Option Explicit

Public FilePathArray$(), FileNameArray$(), IndexArray&()
Public NumFilesStored&, Granularity&, GranuleNumber&
Public colDriveType As Collection
Public fso As Scripting.FileSystemObject
Public Declare Function GetDesktopWindow Lib "user32" () As Long

Public Declare Function ShellExecute Lib "shell32" _
    Alias "ShellExecuteA" _
   (ByVal hwnd As Long, _
    ByVal lpOperation As String, _
    ByVal lpFile As String, _
    ByVal lpParameters As String, _
    ByVal lpDirectory As String, _
    ByVal nShowCmd As Long) As Long
    
Public Const SW_SHOWNORMAL As Long = 1
Public Const SW_SHOWMAXIMIZED As Long = 3
Public Const SW_SHOWDEFAULT As Long = 10
Public Const SE_ERR_NOASSOC As Long = 31

Public Sub EnumerateFolders(path$, EnumerateSubFolders As Boolean)
'On Error Resume Next
Dim myfolder As Scripting.Folder

For Each myfolder In fso.GetFolder(path).SubFolders
    With myfolder
    If EnumerateSubFolders Then
        Call EnumerateFolders(.path & "\", EnumerateSubFolders)
    End If
    Call EnumerateFiles(.path)
    End With
Next
End Sub
Public Sub EnumerateFiles(path$)
Dim myfile As Scripting.File
For Each myfile In fso.GetFolder(path).Files
    With myfile
    Call AddFile(Left$(.path, InStr(1, .path, .Name, vbTextCompare) - 1), .Name)
    End With
Next
End Sub
Public Sub AddFile(fPath$, fName$)
NumFilesStored = NumFilesStored + 1
FilePathArray(NumFilesStored - 1) = UCase$(fPath)
FileNameArray(NumFilesStored - 1) = UCase$(fName)
If NumFilesStored = Granularity * GranuleNumber Then
    GranuleNumber = GranuleNumber + 1
    ReDim Preserve FilePathArray(GranuleNumber * Granularity - 1)
    ReDim Preserve FileNameArray(GranuleNumber * Granularity - 1)
End If
End Sub
Sub Main()
Set fso = New Scripting.FileSystemObject
Granularity = 100000
GranuleNumber = 1
NumFilesStored = 0
ReDim FilePathArray(GranuleNumber * Granularity - 1)
ReDim FileNameArray(GranuleNumber * Granularity - 1)
Form1.Show
End Sub
Public Sub QuickSortVariantArray(avarIn$(), indexarr&(), ByVal intLowBound&, ByVal intHighBound&)
  Dim intX&
  Dim intY&
  Dim varMidBound$
  Dim varTmp$
  Dim varTmp2&
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
    Call QuickSortVariantArray(avarIn(), indexarr(), intLowBound, intY)
    'Sort the upper half of the array
    Call QuickSortVariantArray(avarIn(), indexarr(), intX, intHighBound)
  End If
  
PROC_EXIT:
  Exit Sub

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "QuickSortVariantArray"
  Resume PROC_EXIT
End Sub
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Copyright ©1996-2003 VBnet, Randy Birch, All Rights Reserved.
' Some pages may also contain other copyrights by the author.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Distribution: You can freely use this code in your own
'               applications, but you may not reproduce
'               or publish this code on any web site,
'               online service, or distribute as source
'               on any media without express permission.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Sub RunShellExecute(sTopic As String, _
                           sFile As Variant, _
                           sParams As Variant, _
                           sDirectory As Variant, _
                           nShowCmd As Long)

   Dim hWndDesk As Long
   Dim success As Long
  
  'the desktop will be the
  'default for error messages
   hWndDesk = GetDesktopWindow()
  
  'execute the passed operation
   success = ShellExecute(hWndDesk, sTopic, sFile, sParams, sDirectory, nShowCmd)

  'This is optional. Uncomment the three lines
  'below to have the "Open With.." dialog appear
  'when the ShellExecute API call fails
  If success = SE_ERR_NOASSOC Then
     Call Shell("rundll32.exe shell32.dll,OpenAs_RunDLL " & sFile, vbNormalFocus)
  End If
   
End Sub


