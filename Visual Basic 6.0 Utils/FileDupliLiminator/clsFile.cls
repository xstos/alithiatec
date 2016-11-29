VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsFile"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Private FilePathArray$(), FileNameArray$(), SizeArray&()
Private NumFilesStored&
Private GranuleNumber&, Granularity&
Private ExitNow As Boolean
Private fso As Scripting.FileSystemObject
Public Event FolderChange(FolderPath$)
Public Event FileChange(FilePath$)
Public Sub Abort()
ExitNow = True
End Sub
Public Property Get FileCount() As Long
FileCount = NumFilesStored
End Property
Public Property Get FilePaths() As String()
  FilePaths = FilePathArray
End Property
Public Property Get FileNames() As String()
  FileNames = FileNameArray
End Property
Public Property Get FileSizes() As Long()
  FileSizes = SizeArray
End Property
Public Sub Reset()
Granularity = 100000
GranuleNumber = 1
NumFilesStored = 0
ReDim FilePathArray(GranuleNumber * Granularity - 1)
ReDim FileNameArray(GranuleNumber * Granularity - 1)
ReDim SizeArray(GranuleNumber * Granularity - 1)
End Sub
Public Sub EnumerateFolders(path$, EnumerateSubFolders As Boolean)
'On Error Resume Next
Dim myfolder As Scripting.Folder
If ExitNow Then Exit Sub
For Each myfolder In fso.GetFolder(path).SubFolders
    If ExitNow Then Exit Sub
    With myfolder
    RaiseEvent FolderChange(.path)
    If EnumerateSubFolders Then
        Call EnumerateFolders(.path & "\", EnumerateSubFolders)
    End If
    Call EnumerateFiles(.path)
    End With
Next
End Sub
Public Sub EndEnumeration()
ReDim Preserve FilePathArray(NumFilesStored - 1)
ReDim Preserve FileNameArray(NumFilesStored - 1)
ReDim Preserve SizeArray(NumFilesStored - 1)
End Sub
Public Sub EnumerateFiles(path$)
Dim myfile As Scripting.File
If ExitNow Then Exit Sub
For Each myfile In fso.GetFolder(path).Files
    If ExitNow Then Exit Sub
    With myfile
    RaiseEvent FileChange(.Name)
    Call AddFile(path, .Name, .size) 'fpath used to = Left$(.path, InStr(1, .path, .Name, vbTextCompare) - 1)
    End With
Next
End Sub
Public Sub AddFile(fPath$, fName$, size&)
If ExitNow Then Exit Sub
NumFilesStored = NumFilesStored + 1
FilePathArray(NumFilesStored - 1) = fPath
FileNameArray(NumFilesStored - 1) = fName
SizeArray(NumFilesStored - 1) = size
'CRC.InputFileName = fPath & fName
'CRCArray(NumFilesStored - 1) = CRC.GetCRCFromFile
'Form1.Caption = fPath & fName
If NumFilesStored = Granularity * GranuleNumber Then
    GranuleNumber = GranuleNumber + 1
    ReDim Preserve FilePathArray(GranuleNumber * Granularity - 1)
    ReDim Preserve FileNameArray(GranuleNumber * Granularity - 1)
    ReDim Preserve SizeArray(GranuleNumber * Granularity - 1)
End If
End Sub

Private Sub Class_Initialize()
Reset
Set fso = New Scripting.FileSystemObject
End Sub

Private Sub Class_Terminate()
Erase FilePathArray
Erase FileNameArray
Erase SizeArray
End Sub
