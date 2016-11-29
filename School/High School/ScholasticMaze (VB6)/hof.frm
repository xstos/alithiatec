VERSION 5.00
Begin VB.Form hof 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "ScholasticMaze Hall of Fame"
   ClientHeight    =   6456
   ClientLeft      =   36
   ClientTop       =   264
   ClientWidth     =   8268
   LinkTopic       =   "Form3"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Picture         =   "hof.frx":0000
   ScaleHeight     =   6456
   ScaleWidth      =   8268
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command3 
      Caption         =   "Clear"
      Height          =   432
      Left            =   3780
      TabIndex        =   8
      Top             =   5580
      Width           =   1092
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Close"
      Height          =   432
      Left            =   4980
      TabIndex        =   7
      Top             =   5580
      Width           =   1092
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Reset"
      Height          =   432
      Left            =   2580
      TabIndex        =   6
      Top             =   5580
      Width           =   1092
   End
   Begin VB.TextBox Text3 
      Height          =   252
      Index           =   0
      Left            =   5040
      Locked          =   -1  'True
      MaxLength       =   70
      TabIndex        =   2
      ToolTipText     =   "Comment"
      Top             =   420
      Width           =   3252
   End
   Begin VB.TextBox Text2 
      Height          =   252
      Index           =   0
      Left            =   2640
      Locked          =   -1  'True
      TabIndex        =   1
      ToolTipText     =   "Name"
      Top             =   420
      Width           =   1872
   End
   Begin VB.TextBox Text1 
      BackColor       =   &H8000000F&
      Height          =   252
      Index           =   0
      Left            =   120
      Locked          =   -1  'True
      TabIndex        =   0
      ToolTipText     =   "Score"
      Top             =   420
      Width           =   1092
   End
   Begin VB.Label Label3 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Comment"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   13.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   400
      Left            =   5040
      TabIndex        =   5
      Top             =   120
      Width           =   2412
   End
   Begin VB.Label Label2 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Warrior Name"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   13.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   396
      Left            =   2640
      TabIndex        =   4
      Top             =   60
      Width           =   1872
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Score"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   13.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   396
      Left            =   180
      TabIndex        =   3
      Top             =   60
      Width           =   1032
   End
End
Attribute VB_Name = "hof"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Dim a%
a% = MsgBox("Reset Hall of Fame?", vbYesNo, "Reset Hall of Fame")
If a% = vbYes Then
FileCopy CurDir + "\hof.1st", CurDir + "\hof.dat"
gethof
hof.Show
hof.Refresh
End If
End Sub

Private Sub Command2_Click()
hof.Hide
End Sub

Private Sub Command3_Click()
Dim a%
a% = MsgBox("Clear Hall of Fame?", vbYesNo, "Clear Hall of Fame")
If a% = vbYes Then
FileCopy CurDir + "\emptyhof.dat", CurDir + "\hof.dat"
gethof
hof.Show
hof.Refresh
End If
End Sub

Private Sub Form_Load()
hof.Width = Screen.TwipsPerPixelX * 800
hof.Height = Screen.TwipsPerPixelY * 600
Text1(0).Left = 10 * Screen.TwipsPerPixelX
Text1(0).Top = Label1.Top + Label1.Height + 5 * Screen.TwipsPerPixelX
Text2(0).Left = Text1(0).Left + Text1(0).Width + 10 * Screen.TwipsPerPixelX
Text2(0).Top = Text1(0).Top
Text3(0).Left = Text2(0).Left + Text2(0).Width + 10 * Screen.TwipsPerPixelX
Text3(0).Top = Text1(0).Top
Text3(0).Width = hof.ScaleWidth - Text3(0).Left - 10 * Screen.TwipsPerPixelX
Label1.Width = Text1(0).Width
Label2.Width = Text2(0).Width
Label3.Width = Text3(0).Width
Label1.Top = 0
Label2.Top = 0
Label3.Top = 0
Label1.Left = Text1(0).Left
Label2.Left = Text2(0).Left
Label3.Left = Text3(0).Left
Command1.Top = hof.ScaleHeight - Command1.Height - 3 * Screen.TwipsPerPixelY
Command2.Top = Command1.Top
Command3.Top = Command1.Top
Command1.Left = (hof.ScaleWidth / 2) - Int(1.5 * Command1.Width) - 6 * Screen.TwipsPerPixelX
Command3.Left = Command1.Left + Command1.Width + 3 * Screen.TwipsPerPixelX
Command2.Left = Command3.Left + Command1.Width + 3 * Screen.TwipsPerPixelX
End Sub

Private Sub Form_Unload(Cancel As Integer)
Cancel = 1
hof.Hide
End Sub
