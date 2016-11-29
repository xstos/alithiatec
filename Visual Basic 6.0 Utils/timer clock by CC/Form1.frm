VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Timer by CC"
   ClientHeight    =   4608
   ClientLeft      =   48
   ClientTop       =   276
   ClientWidth     =   8916
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   4608
   ScaleWidth      =   8916
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer Timer2 
      Interval        =   1
      Left            =   3540
      Top             =   2580
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   5700
      Top             =   1380
   End
   Begin VB.Line Line2 
      BorderColor     =   &H80000012&
      X1              =   3000
      X2              =   3000
      Y1              =   0
      Y2              =   180
   End
   Begin VB.Label Label6 
      Caption         =   "Current Date:"
      Height          =   192
      Left            =   60
      TabIndex        =   5
      Top             =   0
      Width           =   948
   End
   Begin VB.Label Label5 
      Caption         =   "Elapsed Time:"
      Height          =   192
      Left            =   3180
      TabIndex        =   4
      Top             =   0
      Width           =   1056
   End
   Begin VB.Label Label4 
      Caption         =   "0000/00/00 00:00:00 AM"
      Height          =   192
      Left            =   1140
      TabIndex        =   3
      Top             =   0
      Width           =   1704
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      AutoSize        =   -1  'True
      Caption         =   "000 hour(s)"
      Height          =   192
      Left            =   4320
      TabIndex        =   2
      Top             =   0
      Width           =   780
   End
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      AutoSize        =   -1  'True
      Caption         =   "00 min(s)"
      Height          =   192
      Left            =   5160
      TabIndex        =   1
      Top             =   0
      Width           =   636
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      AutoSize        =   -1  'True
      Caption         =   "00 sec(s)"
      Height          =   192
      Left            =   5880
      TabIndex        =   0
      Top             =   0
      Width           =   648
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim secs%, mins%, hrs%, mydate As Variant
Private Sub Form_Load()
secs% = 0
mins% = 0
hrs% = 0
Form1.Width = 556 * Screen.TwipsPerPixelX
Form1.Height = 42 * Screen.TwipsPerPixelY
mydate = Now
End Sub

Private Sub Form_Resize()
If WindowState = 0 Then
Form1.Caption = "Timer by CC - Started: " + Str(mydate)
End If
End Sub

Private Sub Timer1_Timer()
secs% = secs% + 1
If secs% = 60 Then
mins% = mins% + 1
secs% = 0
End If
If mins% = 60 Then
hrs% = hrs% + 1
mins% = 0
End If
If WindowState = 0 Then
Label1.Caption = Str(secs%) + " sec(s)"
Label2.Caption = Str(mins%) + " min(s)"
Label3.Caption = Str(hrs%) + " hour(s)"
Label4.Caption = Now
ElseIf WindowState = 1 Then
Form1.Caption = Str(hrs%) + " hr " + Str(mins%) + " min " + Str(secs%) + " s"
End If
End Sub

Private Sub Timer2_Timer()
If Form1.Left < 20 * Screen.TwipsPerPixelX Then
Form1.Left = 0
End If
End Sub
