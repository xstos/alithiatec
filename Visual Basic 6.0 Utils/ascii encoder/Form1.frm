VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Super Duper Top Secret Encryption Program"
   ClientHeight    =   3240
   ClientLeft      =   60
   ClientTop       =   300
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3240
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Encode"
      Height          =   375
      Left            =   0
      TabIndex        =   3
      Top             =   0
      Width           =   1155
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Decode"
      Height          =   375
      Left            =   1170
      TabIndex        =   2
      Top             =   0
      Width           =   1155
   End
   Begin VB.TextBox Text2 
      BackColor       =   &H80000004&
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      Left            =   210
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   1
      Text            =   "Form1.frx":0000
      Top             =   1260
      Width           =   4185
   End
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      Left            =   270
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   0
      Text            =   "Form1.frx":0006
      Top             =   330
      Width           =   4155
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Command1_Click()
Dim x$, l&, i&, s$
x = UCase(Text1.Text)
l = Len(x) \ 2
s = String(l, "X")
For i = 1 To l
  Mid(s, i, 1) = Chr(HexStr2Dec(Mid(x, i * 2 - 1, 2)))
Next
Text2.Text = s
End Sub

Private Sub Command2_Click()
Dim i&, b$, l&, a$, x, n$
a = Text1.Text
l = Len(Text1.Text)
b = String(l * 2, "X")
For i = 1 To l
  n = Hex(Asc(Mid(a, i, 1)))
  If LenB(n) = 2 Then n = "0" & n
  Mid(b, i * 2 - 1, 2) = n
Next
Text2.Text = b
End Sub

Private Sub Form_Load()
Command2_Click
End Sub

Private Sub Form_Resize()
On Error Resume Next
Text1.Move 0, Command2.Height, Me.ScaleWidth, (Me.ScaleHeight - Command2.Height) \ 2
Text2.Move 0, (Me.ScaleHeight - Command2.Height) \ 2 + Command2.Height, Me.ScaleWidth, Me.ScaleHeight - (Me.ScaleHeight + Command2.Height) \ 2
End Sub

Private Function HexStr2Dec(mystring$) As Long
On Error Resume Next
HexStr2Dec = CLng("&h" & mystring)
End Function
