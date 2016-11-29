VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.1#0"; "COMCTL32.OCX"
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.0#0"; "COMCT232.OCX"
Begin VB.Form Form1 
   Caption         =   "Da Bouncin' Window!"
   ClientHeight    =   2115
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   4650
   FillColor       =   &H00FFFFFF&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2115
   ScaleWidth      =   4650
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   1
      Left            =   2640
      Top             =   840
   End
   Begin ComctlLib.StatusBar StatusBar1 
      Align           =   2  'Align Bottom
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   1860
      Width           =   4650
      _ExtentX        =   8202
      _ExtentY        =   450
      Style           =   1
      SimpleText      =   ""
      _Version        =   327680
      BeginProperty Panels {0713E89E-850A-101B-AFC0-4210102A8DA7} 
         NumPanels       =   1
         BeginProperty Panel1 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            TextSave        =   ""
            Object.Tag             =   ""
         EndProperty
      EndProperty
   End
   Begin ComCtl2.UpDown UpDown1 
      Height          =   735
      Left            =   360
      TabIndex        =   1
      Top             =   120
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   1296
      _Version        =   327680
      Value           =   50
      Increment       =   10
      Max             =   100
      Enabled         =   -1  'True
   End
   Begin ComCtl2.UpDown UpDown2 
      Height          =   735
      Left            =   1320
      TabIndex        =   2
      Top             =   120
      Width           =   240
      _ExtentX        =   423
      _ExtentY        =   1296
      _Version        =   327680
      Value           =   50
      Increment       =   10
      Max             =   100
      Enabled         =   -1  'True
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "X"
      Height          =   195
      Left            =   120
      TabIndex        =   4
      Top             =   360
      Width           =   105
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "Y"
      Height          =   195
      Left            =   960
      TabIndex        =   3
      Top             =   360
      Width           =   105
   End
   Begin VB.Menu mbFile 
      Caption         =   "File"
      Begin VB.Menu mbQuit 
         Caption         =   "Quit"
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim x, y, signx, signy As Integer

Private Sub Form_Click()
If Timer1.Enabled Then
    Timer1.Enabled = False
Else
    Timer1.Enabled = True
End If
End Sub

Private Sub Form_Load()
signx = 1
signy = 1
x = UpDown1.Value * signx
y = UpDown2.Value * signy
End Sub

Private Sub mbQuit_Click()
End
End Sub

Private Sub Timer1_Timer()
If Form1.Left > Screen.Width - Form1.Width Then
    Form1.Left = Screen.Width - Form1.Width - UpDown1.Value '- 100
    signx = signx * (-1)
End If
If Form1.Left < 0 Then
    Form1.Left = 0 + UpDown1.Value '+ 100
    signx = signx * (-1)
End If
If Form1.Top > Screen.Height - Form1.Height Then
    Form1.Top = Screen.Height - Form1.Height - UpDown2.Value '- 100
    signy = signy * (-1)
End If
If Form1.Top < 0 Then
    Form1.Top = 0 + UpDown2.Value '+ 100
    signy = signy * (-1)
End If
x = UpDown1.Value * signx
y = UpDown2.Value * signy
Form1.Left = Form1.Left + x
Form1.Top = Form1.Top + y
For i = 1 To 100
Form1.Refresh
Next i
End Sub
