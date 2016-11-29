VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Jump"
   ClientHeight    =   3255
   ClientLeft      =   45
   ClientTop       =   285
   ClientWidth     =   11520
   Icon            =   "Form1.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3255
   ScaleWidth      =   11520
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2220
      IntegralHeight  =   0   'False
      ItemData        =   "Form1.frx":000C
      Left            =   0
      List            =   "Form1.frx":000E
      TabIndex        =   1
      ToolTipText     =   "Right Click for Options"
      Top             =   360
      Width           =   6615
   End
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   6615
   End
   Begin VB.Menu mnupu 
      Caption         =   "pu"
      Visible         =   0   'False
      Begin VB.Menu mnuFilenamesOnly 
         Caption         =   "Show &Filenames Only"
      End
      Begin VB.Menu mnuPathsAndFilenames 
         Caption         =   "Show &Paths && Filenames"
         Checked         =   -1  'True
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public MyCommand$
Dim FilenamesOnly As Boolean

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
With List1
If .ListCount > 0 Then
  If KeyCode = vbKeyDown Then
    .Selected(LBBoundsCheck(List1, .ListIndex + 1)) = True
    Exit Sub
  End If
  If KeyCode = vbKeyUp Then
    .Selected(LBBoundsCheck(List1, .ListIndex - 1)) = True
    Exit Sub
  End If
  If .ListCount > 0 Then
    If KeyCode = vbKeyReturn Then
      List1_KeyDown vbKeyReturn, 0
    End If
  End If
End If
End With
End Sub

Private Sub Form_Load()
MyCommand = Command
InitStuff
Me.Caption = Me.Caption & ": " & MyCommand
If MyCommand = "" Then
  MyCommand = CurDir
  Call EnumerateFiles(MyCommand)
  Call EnumerateFolders(MyCommand, True)
ElseIf Right(MyCommand, 3) = "jmp" Then
  Open MyCommand For Input As #1
  Do While Not EOF(1)
    Line Input #1, MyCommand
    Call EnumerateFiles(MyCommand)
    Call EnumerateFolders(MyCommand, True)
  Loop
  Close #1
Else
  Call EnumerateFiles(MyCommand)
  Call EnumerateFolders(MyCommand, True)
End If
DoIT
End Sub

Private Sub Form_Resize()
Text1.Left = 0
Text1.Width = Me.ScaleWidth
List1.Left = 0
List1.Top = Text1.Height
List1.Height = Me.ScaleHeight - Text1.Height
List1.Width = Me.ScaleWidth
End Sub
Private Sub InitStuff()
ReDim FilePathArray(GranuleNumber * Granularity - 1)
ReDim FileNameArray(GranuleNumber * Granularity - 1)
NumFilesStored = 0
End Sub
Private Sub DoIT()
Dim i&, j&
ReDim Preserve FilePathArray(NumFilesStored - 1)
ReDim Preserve FileNameArray(NumFilesStored - 1)
ReDim IndexArray(0 To NumFilesStored - 1)
For i = 0 To NumFilesStored - 1
    IndexArray(i) = i
Next i
Call QuickSortVariantArray(FileNameArray, IndexArray, 0, NumFilesStored - 1)
With List1
For i = 0 To NumFilesStored - 1
    .AddItem FilePathArray(IndexArray(i)) & FileNameArray(i)
Next i
End With
End Sub
Private Sub dumplist(srchtxt$)
Dim i&, test As Boolean
With List1
.Clear
For i = 0 To NumFilesStored - 1
  If InStr(1, FileNameArray(i), srchtxt, vbTextCompare) Then
    If FilenamesOnly Then
    .AddItem FileNameArray(i)
    Else
    .AddItem FilePathArray(IndexArray(i)) & FileNameArray(i)
    End If
    .ItemData(.NewIndex) = i
  End If
Next i
End With
End Sub

Private Sub List1_DblClick()
List1_KeyDown vbKeyReturn, 0
End Sub

Private Sub List1_KeyDown(KeyCode As Integer, Shift As Integer)
If KeyCode = vbKeyUp And List1.Selected(0) = True Then
  Text1.SetFocus
ElseIf KeyCode = vbKeyReturn Then
  Dim sTopic As String
  Dim sFile As String
  Dim sParams As Variant
  Dim sDirectory As Variant
  sTopic = "Open"
  With List1
    sFile = FilePathArray(IndexArray(.ItemData(.ListIndex))) & FileNameArray(.ItemData(.ListIndex))
    sParams = 0&
    sDirectory = 0&
  Call RunShellExecute(sTopic, sFile, sParams, sDirectory, SW_SHOWNORMAL)
  End With
  End
End If
End Sub

Private Sub List1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
If Button = 2 Then
  PopupMenu mnupu
  dumplist (UCase(Text1.Text))
End If
End Sub

Private Sub mnuFilenamesOnly_Click()
FilenamesOnly = True
mnuFilenamesOnly.Checked = True
mnuPathsAndFilenames.Checked = False
End Sub

Private Sub mnuPathsAndFilenames_Click()
FilenamesOnly = False
mnuFilenamesOnly.Checked = False
mnuPathsAndFilenames.Checked = True
End Sub

Private Sub Text1_Change()
dumplist (UCase(Text1.Text))
With List1
If .ListCount > 0 Then
  .Selected(0) = True
End If
End With
End Sub

Private Function LBBoundsCheck(lb As ListBox, DesiredIndex As Integer) As Long
With lb
  If DesiredIndex < 0 Then
    LBBoundsCheck = 0
    Exit Function
  End If
  If DesiredIndex > .ListCount - 1 Then
    LBBoundsCheck = .ListCount - 1
    Exit Function
  End If
  LBBoundsCheck = DesiredIndex
End With
End Function

Private Sub Text1_KeyDown(KeyCode As Integer, Shift As Integer)
If (KeyCode = vbKeyUp) Or (KeyCode = vbKeyDown) Then
  KeyCode = 0
End If
End Sub
