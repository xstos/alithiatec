VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Folder Compare Program"
   ClientHeight    =   8280
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10725
   LinkTopic       =   "Form1"
   ScaleHeight     =   8280
   ScaleWidth      =   10725
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Smilarities"
      Height          =   375
      Index           =   1
      Left            =   5880
      TabIndex        =   15
      Top             =   7560
      Width           =   1095
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Differences"
      Height          =   375
      Index           =   1
      Left            =   7080
      TabIndex        =   14
      Top             =   7560
      Width           =   1095
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Delete Selected Files"
      Height          =   375
      Index           =   1
      Left            =   8280
      TabIndex        =   13
      Top             =   7560
      Width           =   1815
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Delete Selected Files"
      Height          =   375
      Index           =   0
      Left            =   2640
      TabIndex        =   12
      Top             =   7560
      Width           =   1815
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Differences"
      Height          =   375
      Index           =   0
      Left            =   1440
      TabIndex        =   11
      Top             =   7560
      Width           =   1095
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Smilarities"
      Height          =   375
      Index           =   0
      Left            =   240
      TabIndex        =   10
      Top             =   7560
      Width           =   1095
   End
   Begin VB.Frame Frame2 
      Height          =   7455
      Left            =   5400
      TabIndex        =   5
      Top             =   0
      Width           =   5295
      Begin VB.FileListBox File1 
         Height          =   6720
         Hidden          =   -1  'True
         Index           =   1
         Left            =   2280
         MultiSelect     =   2  'Extended
         System          =   -1  'True
         TabIndex        =   8
         ToolTipText     =   "Files"
         Top             =   600
         Width           =   2895
      End
      Begin VB.DriveListBox Drive1 
         Height          =   315
         Index           =   1
         Left            =   120
         TabIndex        =   7
         ToolTipText     =   "Drive"
         Top             =   600
         Width           =   2055
      End
      Begin VB.DirListBox Dir1 
         Height          =   6390
         Index           =   1
         Left            =   120
         TabIndex        =   6
         ToolTipText     =   "Folder"
         Top             =   960
         Width           =   2055
      End
      Begin VB.Label Label1 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   9
         ToolTipText     =   "Current Path"
         Top             =   240
         Width           =   5055
      End
   End
   Begin VB.Frame Frame1 
      Height          =   7455
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   5295
      Begin VB.DirListBox Dir1 
         Height          =   6390
         Index           =   0
         Left            =   120
         TabIndex        =   3
         ToolTipText     =   "Folder"
         Top             =   960
         Width           =   2055
      End
      Begin VB.DriveListBox Drive1 
         Height          =   315
         Index           =   0
         Left            =   120
         TabIndex        =   2
         ToolTipText     =   "Drive"
         Top             =   600
         Width           =   2055
      End
      Begin VB.FileListBox File1 
         Height          =   6720
         Hidden          =   -1  'True
         Index           =   0
         Left            =   2280
         MultiSelect     =   2  'Extended
         System          =   -1  'True
         TabIndex        =   1
         ToolTipText     =   "Files"
         Top             =   600
         Width           =   2895
      End
      Begin VB.Label Label1 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   4
         ToolTipText     =   "Current Path"
         Top             =   240
         Width           =   5055
      End
   End
   Begin VB.Menu pop1 
      Caption         =   "pop1"
      Visible         =   0   'False
      Begin VB.Menu refresh 
         Caption         =   "Refresh"
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim refreshtarget As Object
Private Sub Command1_Click(Index As Integer)
ClearLB (Index)
If File1(Index).ListCount > 0 Then
    If Index = 0 Then
        targ = 1
    Else
        targ = 0
    End If
    With File1(targ)
    For i = 0 To File1(Index).ListCount - 1
        listitemstr = File1(Index).List(i)
        For j = 0 To .ListCount - 1
            If listitemstr = .List(j) Then
                File1(Index).Selected(i) = True
                Exit For
            End If
        Next j
    Next i
    End With
End If
With File1(Index)
For i = 0 To .ListCount - 1
    If .Selected(i) Then
        .Selected(i) = False
    Else
        .Selected(i) = True
    End If
Next i
End With
End Sub

Private Sub Command2_Click(Index As Integer)
ClearLB (Index)
If File1(Index).ListCount > 0 Then
    If Index = 0 Then
        targ = 1
    Else
        targ = 0
    End If
    With File1(targ)
    For i = 0 To File1(Index).ListCount - 1
        listitemstr = File1(Index).List(i)
        For j = 0 To .ListCount - 1
            If listitemstr = .List(j) Then
                File1(Index).Selected(i) = True
                Exit For
            End If
        Next j
    Next i
    End With
End If
End Sub

Private Sub Command3_Click(Index As Integer)
ChDrive (Drive1(Index))
ChDir (Dir1(Index))
Label1(Index) = Dir1(Index)
If File1(Index).ListCount > 0 Then
numdeleted = 0
result = MsgBox("Are You Sure?", vbYesNo, "Really Delete Selected Files?")
If result = 6 Then
With File1(Index)
For i = 0 To .ListCount - 1
    If .Selected(i) = True Then
        numdeleted = numdeleted + 1
        Kill (.List(i))
    End If
Next i
MsgBox numdeleted & " Files Deleted"
End With
File1(Index).refresh
End If
End If
End Sub

Private Sub Dir1_Change(Index As Integer)
File1(Index).Path = Dir1(Index)
ChDir (Dir1(Index))
Label1(Index) = Dir1(Index)
End Sub

Private Sub Dir1_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
If Button = 2 Then
Set refreshtarget = Dir1(Index)
PopupMenu pop1
End If
End Sub

Private Sub Drive1_Change(Index As Integer)
On Error Resume Next
Dir1(Index).Path = Drive1(Index).Drive
If Err = 76 Then
MsgBox "Previous folder path moved or removed, quitting..."
End
End If
File1(Index).Path = Drive1(Index)
ChDrive (Drive1(Index))
ChDir (Dir1(Index))
Label1(Index) = Dir1(Index)
End Sub

Private Sub File1_Click(Index As Integer)
Label1(Index) = Dir1(Index)
End Sub

Private Sub File1_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
If Button = 2 Then
Set refreshtarget = File1(Index)
PopupMenu pop1
End If
End Sub

Private Sub Form_Load()
On Error Resume Next
End Sub
Private Sub ClearLB(Index As Integer)
With File1(Index)
If .ListCount > 0 Then
For i = 0 To .ListCount - 1
    .Selected(i) = False
Next i
End If
End With
End Sub

Private Sub refresh_Click()
refreshtarget.refresh
End Sub
