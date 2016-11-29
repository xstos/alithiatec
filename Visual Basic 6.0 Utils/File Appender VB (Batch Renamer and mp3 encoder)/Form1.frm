VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Multi-FileName Manipulator by ChrisC"
   ClientHeight    =   6000
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   9825
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   6000
   ScaleWidth      =   9825
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame5 
      BorderStyle     =   0  'None
      Height          =   432
      Left            =   36
      TabIndex        =   25
      Top             =   0
      Width           =   9804
      Begin VB.Label Label4 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Label4"
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   432
         Left            =   720
         TabIndex        =   27
         Top             =   0
         Width           =   9048
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         AutoSize        =   -1  'True
         Caption         =   "Current Path:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   390
         Left            =   0
         TabIndex        =   26
         Top             =   0
         Width           =   720
         WordWrap        =   -1  'True
      End
   End
   Begin VB.Frame Frame2 
      BorderStyle     =   0  'None
      Height          =   792
      Left            =   60
      TabIndex        =   10
      Top             =   5280
      Width           =   5232
      Begin VB.Frame Frame3 
         BorderStyle     =   0  'None
         Height          =   372
         Left            =   0
         TabIndex        =   14
         Top             =   360
         Width           =   5232
         Begin VB.CommandButton Command5 
            Caption         =   "<-"
            Enabled         =   0   'False
            Height          =   315
            Left            =   4860
            TabIndex        =   16
            ToolTipText     =   "Sets the string to the currently selected file in the file list"
            Top             =   0
            Width           =   315
         End
         Begin VB.TextBox Text3 
            BeginProperty Font 
               Name            =   "Courier New"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   315
            Left            =   1260
            TabIndex        =   15
            Text            =   "More Stuff"
            ToolTipText     =   "The string with which to replace the specified string"
            Top             =   0
            Width           =   3555
         End
         Begin VB.Label Label6 
            AutoSize        =   -1  'True
            Caption         =   "Replace with:"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Left            =   0
            TabIndex        =   17
            Top             =   60
            Width           =   1185
         End
      End
      Begin VB.TextBox Text2 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   1260
         TabIndex        =   12
         Text            =   "Stuff"
         ToolTipText     =   "Depending on the action selected this will either be the insert string or the one to find for replacement"
         Top             =   0
         Width           =   3555
      End
      Begin VB.CommandButton Command4 
         Caption         =   "<-"
         Enabled         =   0   'False
         Height          =   315
         Left            =   4860
         TabIndex        =   11
         ToolTipText     =   "Sets the string to the currently selected file in the file list"
         Top             =   0
         Width           =   315
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         Caption         =   "Specify string:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   0
         TabIndex        =   13
         Top             =   60
         Width           =   1230
      End
   End
   Begin VB.Frame Frame1 
      BorderStyle     =   0  'None
      Height          =   732
      Left            =   60
      TabIndex        =   5
      Top             =   5280
      Width           =   5232
      Begin VB.TextBox Text5 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   7.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   264
         Left            =   780
         TabIndex        =   9
         Text            =   "--abr 192 -m j -q 0"
         Top             =   300
         Width           =   4392
      End
      Begin VB.CommandButton Command7 
         Caption         =   "..."
         Height          =   252
         Left            =   4860
         TabIndex        =   6
         Top             =   0
         Width           =   312
      End
      Begin VB.TextBox Text4 
         BackColor       =   &H8000000F&
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   7.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Left            =   0
         Locked          =   -1  'True
         TabIndex        =   7
         Text            =   "Select Lame Executable Location"
         Top             =   0
         Width           =   4812
      End
      Begin VB.Label Label8 
         Caption         =   "Switches:"
         Height          =   192
         Left            =   0
         TabIndex        =   8
         Top             =   300
         Width           =   732
      End
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   8640
      Top             =   7020
      _ExtentX        =   688
      _ExtentY        =   688
      _Version        =   393216
   End
   Begin VB.ComboBox Combo1 
      Height          =   315
      ItemData        =   "Form1.frx":0442
      Left            =   5400
      List            =   "Form1.frx":0444
      Style           =   2  'Dropdown List
      TabIndex        =   2
      Top             =   5580
      Width           =   3015
   End
   Begin VB.DriveListBox Drive1 
      Height          =   315
      Left            =   60
      TabIndex        =   0
      Top             =   480
      Width           =   2835
   End
   Begin VB.DirListBox Dir1 
      Height          =   4365
      Left            =   60
      TabIndex        =   1
      Top             =   840
      Width           =   2805
   End
   Begin VB.CommandButton Command1 
      Caption         =   "GO!"
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   8580
      TabIndex        =   3
      ToolTipText     =   "Perform the chosen action on the highlighted files above"
      Top             =   5400
      Width           =   1095
   End
   Begin VB.Frame Frame4 
      Appearance      =   0  'Flat
      ForeColor       =   &H80000008&
      Height          =   4872
      Left            =   2940
      TabIndex        =   18
      Top             =   360
      Width           =   6864
      Begin VB.CommandButton Command3 
         Caption         =   "Select None"
         Height          =   276
         Left            =   5760
         TabIndex        =   19
         Top             =   4536
         Width           =   1032
      End
      Begin VB.CommandButton Command10 
         Caption         =   "Refresh"
         Height          =   228
         Left            =   5976
         TabIndex        =   31
         Top             =   144
         Width           =   840
      End
      Begin VB.CommandButton Command9 
         Caption         =   "*.mp3"
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   7.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   264
         Left            =   3888
         TabIndex        =   30
         Top             =   4536
         Width           =   624
      End
      Begin VB.CommandButton Command8 
         Caption         =   "*.wav"
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   7.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   264
         Left            =   3240
         TabIndex        =   29
         Top             =   4536
         Width           =   624
      End
      Begin VB.CommandButton Command6 
         Caption         =   "*.*"
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   7.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   264
         Left            =   2808
         TabIndex        =   28
         Top             =   4536
         Width           =   408
      End
      Begin VB.TextBox Text1 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   276
         Left            =   1728
         TabIndex        =   22
         Text            =   "*.*"
         Top             =   4536
         Width           =   1020
      End
      Begin VB.FileListBox File1 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   4080
         Hidden          =   -1  'True
         Left            =   36
         MultiSelect     =   2  'Extended
         System          =   -1  'True
         TabIndex        =   21
         Top             =   360
         Width           =   6792
      End
      Begin VB.CommandButton Command2 
         Caption         =   "Select All"
         Height          =   276
         Left            =   4824
         TabIndex        =   20
         Top             =   4536
         Width           =   852
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "View Files of Type:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   192
         Left            =   108
         TabIndex        =   24
         Top             =   4572
         Width           =   1632
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         Caption         =   "Highlight (multi-select) files to process:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   192
         Left            =   108
         TabIndex        =   23
         Top             =   144
         Width           =   3312
      End
   End
   Begin VB.Label Label7 
      AutoSize        =   -1  'True
      Caption         =   "Action to perform on selected files..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   5400
      TabIndex        =   4
      Top             =   5340
      Width           =   3105
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Type STARTUPINFO
    cb As Long
    lpReserved As String
    lpDesktop As String
    lpTitle As String
    dwX As Long
    dwY As Long
    dwXSize As Long
    dwYSize As Long
    dwXCountChars As Long
    dwYCountChars As Long
    dwFillAttribute As Long
    dwFlags As Long
    wShowWindow As Integer
    cbReserved2 As Integer
    lpReserved2 As Byte
    hStdInput As Long
    hStdOutput As Long
    hStdError As Long
End Type

Private Type PROCESS_INFORMATION
    hProcess As Long
    hThread As Long
    dwProcessID As Long
    dwThreadID As Long
End Type

Private Const NORMAL_PRIORITY_CLASS = &H20&
Private Const INFINITE = -1&
Private Const CREATE_NEW_CONSOLE = &H10
Private Const CREATE_NEW_PROCESS_GROUP = &H200
Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Long, ByVal dwMilliseconds As Long) As Long
Private Declare Function CreateProcessA Lib "kernel32" (ByVal lpApplicationName As Long, ByVal lpCommandLine As String, ByVal lpProcessAttributes As Long, ByVal lpThreadAttributes As Long, ByVal bInheritHandles As Long, ByVal dwCreationFlags As Long, ByVal lpEnvironment As Long, ByVal lpCurrentDirectory As Long, lpStartupInfo As STARTUPINFO, lpProcessInformation As PROCESS_INFORMATION) As Long
Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Long) As Long


Dim Path As String

'Private Enum eOp
'  fnmAppend2Start = 0
'  fnmInsertB4Ext = 1
'  fnmReplace = 2
'End Enum

Private Sub ExecCmd(CmdLine As String)

Dim proc As PROCESS_INFORMATION
Dim start As STARTUPINFO
Dim ret&

' Initialize the STARTUPINFO structure:
start.cb = Len(start)
' Start the shelled application:
ret& = CreateProcessA(0&, CmdLine, 0&, 0&, 1&, BELOW_NORMAL_PRIORITY_CLASS Or CREATE_NEW_CONSOLE Or CREATE_NEW_PROCESS_GROUP, 0&, 0&, start, proc)
' Wait for the shelled application to finish:
ret& = WaitForSingleObject(proc.hProcess, INFINITE)
ret& = CloseHandle(proc.hProcess)
End Sub

Public Sub Vis(State As Boolean)
Label6.Visible = State
Text3.Visible = State
End Sub

Private Sub Command10_Click()
File1.Refresh
End Sub

Private Sub Command6_Click()
Text1.Text = "*.*"
Text1.SetFocus
End Sub

Private Sub Command8_Click()
Text1.Text = "*.wav"
Text1.SetFocus
End Sub

Private Sub Command9_Click()
Text1.Text = "*.mp3"
Text1.SetFocus
End Sub

Private Sub Form_Load()
Upd
With Combo1
.AddItem "Append to start of filenames"
.ItemData(.NewIndex) = 0
.AddItem "Append before filename extensions"
.ItemData(.NewIndex) = 1
.AddItem "Replace string with another"
.ItemData(.NewIndex) = 2
.AddItem "Compress as mp3s with LAME"
.ItemData(.NewIndex) = 3
.ListIndex = 2
End With
Text4.Text = Label4.Caption & "\lame.exe"
End Sub

Private Sub Combo1_Click()
Dim cv%
cv = Combo1.ItemData(Combo1.ListIndex)
If cv = 2 Then
  Frame3.Visible = True
Else
  Frame3.Visible = False
End If
If cv = 3 Then
  Frame1.Visible = True
  Frame2.Visible = False
Else
  Frame1.Visible = False
  Frame2.Visible = True
End If
End Sub

Private Sub Command1_Click()
Dim i%, p%, l%, st1$, st2$, comboval As Integer

i = MsgBox("Are you sure?", vbYesNo, "Process current directory?")
If i = vbYes Then
With Combo1
  comboval = .ItemData(.ListIndex)
End With
For i = 0 To File1.ListCount - 1
  If File1.Selected(i) Then
    If comboval = 0 Then
      Name File1.Path & "\" & File1.List(i) As File1.Path & "\" & Text2.Text & File1.List(i)
    ElseIf comboval = 1 Then
      p = InStrRev(File1.List(i), ".", , vbTextCompare)
      l = Len(File1.List(i))
      If p = 0 Then
        Name File1.Path & "\" & File1.List(i) As File1.Path & "\" & File1.List(i) & Text2.Text
      Else
        st1 = Left(File1.List(i), p - 1)
        st2 = Right(File1.List(i), l - p)
        Name File1.Path & "\" & File1.List(i) As File1.Path & "\" & st1 & Text2.Text & "." & st2
      End If
    ElseIf comboval = 2 Then
      Name File1.Path & "\" & File1.List(i) As File1.Path & "\" & Replace(File1.List(i), Text2.Text, Text3.Text, 1, , vbTextCompare)
    ElseIf comboval = 3 Then
      Me.Hide
      st1 = Text4.Text & " " & Text5.Text & " """ & File1.Path & "\" & File1.List(i) & """"
      ExecCmd st1
      Me.Refresh
      Me.Show
    End If
  End If
Next i
File1.Refresh
EnableCheck
End If
End Sub
Private Function NoneSelected() As Boolean
Dim i As Integer
NoneSelected = False
With File1
  For i = 0 To .ListCount - 1
    If .Selected(i) Then
      Exit Function
    End If
  Next i
End With
NoneSelected = True
End Function
Private Sub SelAllNone(State As Boolean)
Dim i%
For i = 0 To File1.ListCount - 1
  File1.Selected(i) = State
Next i
End Sub
Private Sub Command2_Click()
SelAllNone True
End Sub

Private Sub Command3_Click()
SelAllNone False
End Sub

Private Sub Command4_Click()
  Text2.Text = File1.List(File1.ListIndex)
End Sub

Private Sub Command5_Click()
  Text3.Text = File1.List(File1.ListIndex)
End Sub

Private Sub Command7_Click()
  ' Set CancelError is True
  CommonDialog1.CancelError = True
  On Error GoTo ErrHandler
  ' Set flags
  CommonDialog1.Flags = cdlOFNHideReadOnly
  ' Set filters
  CommonDialog1.Filter = "All Files (*.*)|*.*|Executable Files (*.exe)|*.exe"
  ' Specify default filter
  CommonDialog1.FilterIndex = 1
  ' Display the Open dialog box
  CommonDialog1.ShowOpen
  ' Display name of selected file
  Text4.Text = CommonDialog1.FileName
  Exit Sub
ErrHandler:
  'User pressed the Cancel button
  Exit Sub
End Sub

Private Sub Dir1_Change()
File1.Path = Dir1.Path
File1.Pattern = Text1.Text
Upd
End Sub

Private Sub Drive1_Change()
On Error Resume Next
Dir1.Path = Drive1.Drive
Upd
End Sub

Private Sub File1_Click()
EnableCheck
End Sub
Private Sub EnableCheck()
If NoneSelected Then
  Command1.Enabled = False
  Command4.Enabled = False
  Command5.Enabled = False
Else
  Command1.Enabled = True
  Command4.Enabled = True
  Command5.Enabled = True
End If
End Sub
Private Sub File1_PathChange()
EnableCheck
End Sub

Private Sub File1_PatternChange()
EnableCheck
End Sub


Private Sub Text1_Change()
File1.Pattern = Text1.Text
End Sub

Private Sub Upd()
Label4.Caption = Dir1.Path
End Sub
'Private Sub Text1_GotFocus()
'Text1.SelStart = 0
'Text1.SelLength = Len(Text1.Text)
'End Sub
'
'Private Sub Text2_GotFocus()
'Text2.SelStart = 0
'Text2.SelLength = Len(Text2.Text)
'End Sub
'Private Sub Text3_GotFocus()
'Text3.SelStart = 0
'Text3.SelLength = Len(Text3.Text)
'End Sub

'Private Sub Text2_KeyPress(KeyAscii As Integer)
'If KeyAscii = 13 Then Command1_Click
'End Sub

