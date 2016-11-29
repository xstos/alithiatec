VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "ScholasticMaze CD"
   ClientHeight    =   888
   ClientLeft      =   36
   ClientTop       =   264
   ClientWidth     =   2316
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   888
   ScaleWidth      =   2316
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command3 
      Caption         =   "Close"
      Height          =   372
      Left            =   60
      TabIndex        =   1
      Top             =   480
      Width           =   2232
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Install ScholasticMaze"
      Height          =   372
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   2232
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
a = Shell("setup.exe", vbNormalFocus)
Unload Me
End Sub

Private Sub Command3_Click()
Unload Me
End Sub

Private Sub Form_Load()
Form1.Width = Command1.Width + Screen.TwipsPerPixelX * 15
Form1.Height = (Command1.Height * 2) + Screen.TwipsPerPixelY * 15 + Form1.Height - Form1.ScaleHeight
End Sub
