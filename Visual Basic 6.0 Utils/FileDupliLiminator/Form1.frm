VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{0ECD9B60-23AA-11D0-B351-00A0C9055D8E}#6.0#0"; "MSHFLXGD.OCX"
Begin VB.Form Form1 
   AutoRedraw      =   -1  'True
   ClientHeight    =   6705
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11940
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6705
   ScaleWidth      =   11940
   StartUpPosition =   3  'Windows Default
   Begin VB.PictureBox Picture2 
      Align           =   1  'Align Top
      Height          =   3015
      Left            =   0
      ScaleHeight     =   2955
      ScaleWidth      =   11880
      TabIndex        =   1
      Top             =   0
      Width           =   11940
      Begin VB.CommandButton Command7 
         Caption         =   "Copy"
         Height          =   375
         Left            =   8220
         TabIndex        =   16
         Top             =   930
         Width           =   1365
      End
      Begin MSComctlLib.ProgressBar pg1 
         Height          =   315
         Left            =   7410
         TabIndex        =   14
         Top             =   360
         Width           =   3945
         _ExtentX        =   6959
         _ExtentY        =   556
         _Version        =   393216
         Appearance      =   1
      End
      Begin VB.CommandButton Command6 
         Caption         =   "Browse"
         Height          =   375
         Left            =   5880
         TabIndex        =   12
         Top             =   0
         Width           =   975
      End
      Begin MSComDlg.CommonDialog cd1 
         Left            =   9660
         Top             =   1800
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.CommandButton Command5 
         Caption         =   "Shell to folder"
         Height          =   495
         Left            =   5880
         TabIndex        =   11
         Top             =   1680
         Width           =   1335
      End
      Begin VB.CommandButton Command4 
         Caption         =   "Cancel"
         Enabled         =   0   'False
         Height          =   555
         Left            =   5880
         TabIndex        =   10
         Top             =   1080
         Width           =   1335
      End
      Begin VB.CommandButton Command3 
         Caption         =   "Search for Duplicates"
         Height          =   555
         Left            =   5880
         TabIndex        =   8
         Top             =   420
         Width           =   1335
      End
      Begin VB.ListBox List1 
         Height          =   2205
         ItemData        =   "Form1.frx":058A
         Left            =   3900
         List            =   "Form1.frx":058C
         Sorted          =   -1  'True
         TabIndex        =   7
         ToolTipText     =   "Double click to remove highlighted item"
         Top             =   360
         Width           =   1935
      End
      Begin VB.CommandButton Command2 
         Caption         =   "<= Clear List"
         Height          =   315
         Left            =   5880
         TabIndex        =   6
         Top             =   2220
         Width           =   1095
      End
      Begin VB.CommandButton Command1 
         Caption         =   "Add >"
         Height          =   495
         Left            =   3360
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   1260
         Width           =   495
      End
      Begin MSComctlLib.ListView lv2 
         Height          =   2235
         Left            =   120
         TabIndex        =   3
         ToolTipText     =   "Double Click to add drive or press the 'Add >'  button"
         Top             =   360
         Width           =   3195
         _ExtentX        =   5636
         _ExtentY        =   3942
         View            =   3
         LabelEdit       =   1
         MultiSelect     =   -1  'True
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   0
      End
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         Caption         =   "CRC"
         Height          =   195
         Left            =   7410
         TabIndex        =   15
         Top             =   120
         Width           =   330
      End
      Begin VB.Label Label2 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         ForeColor       =   &H80000008&
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   2640
         Width           =   11655
         WordWrap        =   -1  'True
      End
      Begin VB.Label Label3 
         AutoSize        =   -1  'True
         Caption         =   "Media to Include in Search:"
         Height          =   195
         Left            =   3900
         TabIndex        =   5
         Top             =   120
         Width           =   1950
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "Storage Media Available:"
         Height          =   195
         Left            =   120
         TabIndex        =   2
         Top             =   120
         Width           =   1770
      End
   End
   Begin VB.PictureBox Picture1 
      Align           =   2  'Align Bottom
      BorderStyle     =   0  'None
      Height          =   3495
      Left            =   0
      ScaleHeight     =   3495
      ScaleWidth      =   11940
      TabIndex        =   0
      Top             =   3210
      Width           =   11940
      Begin MSHierarchicalFlexGridLib.MSHFlexGrid hfg1 
         Height          =   2895
         Left            =   0
         TabIndex        =   13
         Top             =   0
         Width           =   10965
         _ExtentX        =   19341
         _ExtentY        =   5106
         _Version        =   393216
         Rows            =   0
         Cols            =   4
         FixedRows       =   0
         FixedCols       =   0
         GridColor       =   12632256
         ScrollTrack     =   -1  'True
         AllowUserResizing=   1
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Tahoma"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         _NumberOfBands  =   1
         _Band(0).Cols   =   4
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'Public g As CCLibGlobals
Public colDriveType As Collection
Private fso As Scripting.FileSystemObject
Public ExitNow As Boolean
Public AppTitle$
Public WithEvents x As clsFile
Attribute x.VB_VarHelpID = -1
Public WithEvents CRC As CCRC32
Attribute CRC.VB_VarHelpID = -1
Public Enum eDriveType
Unknown = 0
Removable = 1
Fixed = 2
Network = 3
CDRom = 4
RamDisk = 5
End Enum
Public Function SearchListBox(lb As ListBox, mystr$) As Boolean
Dim i&
For i = 0 To lb.ListCount - 1
  If lb.List(i) = mystr Then
    SearchListBox = True
    Exit For
  End If
Next i
End Function

Private Sub Command1_Click()
Dim ListItem As ListItem
For Each ListItem In lv2.ListItems
  If ListItem.Selected = True Then
    If Not SearchListBox(List1, ListItem.Text) Then
      List1.AddItem ListItem.Text
    End If
  End If
Next
End Sub

Private Sub Command2_Click()
List1.Clear
End Sub

Private Sub Command3_Click()
Dim i&, j&, dupefound As Boolean, IndexArray&(), li As ListItem, FileNameArray$(), FilePathArray$(), SizeArray&()
If List1.ListCount = 0 Then
  MsgBox "Add a drive to the search list first", vbExclamation, "Oops!"
  Exit Sub
End If
ExitNow = False
hfg1.Clear
hfg1.Rows = 0
Command3.Enabled = False
Command4.Enabled = True
Me.Caption = AppTitle & " - Searching for files"
Me.Refresh
x.Reset
For i = 0 To List1.ListCount - 1
  x.EnumerateFiles List1.List(i)
  x.EnumerateFolders List1.List(i), True
Next
x.EndEnumeration
If ExitNow Then
  Exit Sub
End If
Label2.Caption = x.FileCount & " Files Found;"
Label2.Refresh

ReDim IndexArray(0 To x.FileCount - 1)
For i = 0 To x.FileCount - 1
    IndexArray(i) = i
Next i
If ExitNow Then
  Exit Sub
End If
Me.Caption = AppTitle & " - Sorting Files"
Me.Refresh
SizeArray = x.FileSizes
FilePathArray = x.FilePaths
FileNameArray = x.FileNames
Call QuickSortVariantArray(SizeArray, IndexArray, 0, x.FileCount - 1)
If ExitNow Then
  Exit Sub
End If
Me.Caption = AppTitle & " - Eliminating Duplicates"
Me.Refresh
dupefound = False
For i = x.FileCount - 2 To 0 Step -1
    If (SizeArray(i) = SizeArray(i + 1)) = False Then
        If dupefound = False Then
            SizeArray(i + 1) = 0
        Else
            dupefound = False
        End If
    Else
        dupefound = True
    End If
    If ExitNow Then
      Exit Sub
    End If
Next i
If SizeArray(0) <> SizeArray(1) Then
  SizeArray(0) = 0
End If
'If (StrComp(CRCArray(0), CRCArray(1), vbTextCompare) = 0) = False Then
'    CRCArray(0) = ""
'End If
Me.Caption = AppTitle & " - Populating List"
Me.Refresh
With hfg1
.Redraw = False
.Rows = x.FileCount + 1
j = 0
.FixedRows = 1
.TextMatrix(0, 0) = "File Path"
.TextMatrix(0, 1) = "Filename"
.TextMatrix(0, 2) = "File Size"
.TextMatrix(0, 3) = "CRC32"
.ColWidth(0) = .Width * 0.4
.ColWidth(1) = .Width * 0.4
.ColWidth(2) = .Width * 0.1
.ColWidth(3) = .Width * 0.1
For i = 0 To x.FileCount - 1
    If SizeArray(i) <> 0 Then
        j = j + 1
        .TextMatrix(j, 0) = FilePathArray(IndexArray(i))
        .TextMatrix(j, 1) = FileNameArray(IndexArray(i))
        .TextMatrix(j, 2) = SizeArray(i)
    End If
    If ExitNow Then
      Exit Sub
    End If
Next i
.Rows = j + 1
.Redraw = True
With hfg1
For i = 1 To .Rows - 1
  If .RowIsVisible(i) = False Then .TopRow = i
  CRC.InputFileName = .TextMatrix(i, 0) & "\" & .TextMatrix(i, 1)
  Label2.Caption = CRC.InputFileName
  DoEvents
  If ExitNow Then Exit Sub
  .TextMatrix(i, 3) = Hex(CRC.GetCRCFromFile)
Next
End With
Label2.Caption = Label2.Caption & " " & j & " Duplicates Found"
Me.Caption = AppTitle & " - Job Done"
Me.Refresh
End With
Command3.Enabled = True
Command4.Enabled = False
End Sub




Private Sub Command4_Click()
Command4.Enabled = False
Command3.Enabled = True
ExitNow = True
x.Abort
Label2.Caption = ""
Me.Caption = AppTitle & " - Cancelled"
End Sub

Private Sub Command5_Click()
'lv1_DblClick
End Sub

Private Sub Command6_Click()
Dim x As New clsBrowseForFolder
x.ShowBrowser Me.hWnd, "Select a folder"
If x.FilePath = "" Then Exit Sub
List1.AddItem x.FilePath
End Sub

Private Sub Command7_Click()
Clipboard.Clear
Clipboard.SetText hfg1.Clip

End Sub

Private Sub CRC_Progress(sngPercentage As Single)
pg1.Value = CLng(sngPercentage * 100)
pg1.Refresh
End Sub

Private Sub Form_Load()
Dim mydrive As Drive, li As ListItem
'Set g = New CCLibGlobals
'g.SetInternals g
Set x = New clsFile
Set fso = New Scripting.FileSystemObject
Set CRC = New CCRC32
Set colDriveType = New Collection
With colDriveType
 .Add "Unknown", "0"
 .Add "Removable", "1"
 .Add "Fixed", "2"
 .Add "Network", "3"
 .Add "CDRom", "4"
 .Add "RamDisk", "5"
End With

AppTitle = "Duplicate File Finder v1.0 Beta by CC"
With fso
lv2.ColumnHeaders.Add , , "Drive Path"
lv2.ColumnHeaders.Add , , "Drive Type"
For Each mydrive In .Drives
    With mydrive
    Set li = lv2.ListItems.Add(, , .path & "\")
    li.SubItems(1) = colDriveType(CStr(.DriveType))
    End With
    
    If ExitNow Then Exit Sub
Next
End With
Me.Caption = AppTitle
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
If Command4.Enabled Then
Command4_Click
End If
End Sub

Private Sub Form_Resize()
On Error Resume Next
Picture1.Height = Me.ScaleHeight - Picture2.Height
Label2.Width = Picture2.ScaleWidth - 2 * (Label2.Left)
End Sub

Private Sub hfg1_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
If Button = 1 Then
  Clipboard.SetText hfg1.Clip
End If
End Sub

Private Sub List1_DblClick()
If List1.ListIndex > -1 Then
  List1.RemoveItem (List1.ListIndex)
End If
End Sub

Private Sub hfg1_DblClick()
'If hfg1.Rows > 0 Then Call Shell("explorer " & , vbNormalFocus)
End Sub

Private Sub lv2_DblClick()
Command1_Click
End Sub

Private Sub Picture1_Resize()
With Picture1
Call hfg1.Move(.ScaleLeft, .ScaleTop, .ScaleWidth, .ScaleHeight)
End With
End Sub

Private Sub x_FolderChange(FolderPath As String)
Label2.Caption = "Searching " & FolderPath & "\*.*"
DoEvents
End Sub
