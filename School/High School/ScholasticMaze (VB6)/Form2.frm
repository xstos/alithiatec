VERSION 5.00
Begin VB.Form Form2 
   BorderStyle     =   0  'None
   Caption         =   "Form2"
   ClientHeight    =   2556
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   3744
   LinkTopic       =   "Form2"
   ScaleHeight     =   2556
   ScaleWidth      =   3744
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Image Image1 
      Height          =   7200
      Left            =   780
      Picture         =   "Form2.frx":0000
      Stretch         =   -1  'True
      Top             =   360
      Width           =   9600
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Click()
Form1.Show
Form2.Hide
End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)
Form1.Show
Form2.Hide
End Sub
Private Sub Form_Load()
Form2.Left = 0
Form2.Top = 0
Form2.Width = Screen.Width
Form2.Height = Screen.Height
Image1.Width = Form2.ScaleWidth
Image1.Height = Form2.ScaleHeight
Image1.Left = 0
Image1.Top = 0
End Sub

Private Sub Image1_Click()
Form1.Show
Form2.Hide
End Sub
