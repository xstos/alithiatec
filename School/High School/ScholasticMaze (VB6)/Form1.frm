VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.1#0"; "COMCT232.OCX"
Object = "{C1A8AF28-1257-101B-8FB0-0020AF039CA3}#1.1#0"; "MCI32.OCX"
Begin VB.Form Form1 
   AutoRedraw      =   -1  'True
   BackColor       =   &H00000000&
   BorderStyle     =   0  'None
   Caption         =   "ScholasticMaze"
   ClientHeight    =   8355
   ClientLeft      =   30
   ClientTop       =   495
   ClientWidth     =   10515
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   Moveable        =   0   'False
   ScaleHeight     =   8355
   ScaleWidth      =   10515
   StartUpPosition =   2  'CenterScreen
   Visible         =   0   'False
   Begin MCI.MMControl MMControl1 
      Height          =   330
      Left            =   720
      TabIndex        =   29
      Top             =   7920
      Visible         =   0   'False
      Width           =   3540
      _ExtentX        =   6244
      _ExtentY        =   582
      _Version        =   393216
      DeviceType      =   ""
      FileName        =   ""
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   2220
      Top             =   1140
      _ExtentX        =   688
      _ExtentY        =   688
      _Version        =   393216
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   7380
      Top             =   6000
   End
   Begin VB.Frame Frame1 
      Caption         =   "Options:"
      Height          =   3084
      Left            =   1944
      TabIndex        =   11
      Top             =   4632
      Visible         =   0   'False
      Width           =   3060
      Begin ComctlLib.Slider Slider1 
         Height          =   1236
         Left            =   168
         TabIndex        =   19
         ToolTipText     =   "Difficulty Settings"
         Top             =   1296
         Width           =   348
         _ExtentX        =   609
         _ExtentY        =   2196
         _Version        =   327682
         Orientation     =   1
         LargeChange     =   1
         Max             =   3
      End
      Begin VB.TextBox Text1 
         Height          =   240
         Left            =   144
         MaxLength       =   20
         TabIndex        =   14
         Text            =   "Sausage"
         Top             =   576
         Width           =   2652
      End
      Begin VB.CommandButton Command2 
         Caption         =   "OK"
         Height          =   252
         Left            =   384
         TabIndex        =   13
         Top             =   2688
         Width           =   1092
      End
      Begin VB.CommandButton Command3 
         Caption         =   "Cancel"
         Height          =   252
         Left            =   1632
         TabIndex        =   12
         Top             =   2688
         Width           =   1092
      End
      Begin VB.Label Label12 
         Caption         =   "Please Enter Your Name:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   228
         Left            =   144
         TabIndex        =   25
         Top             =   288
         Width           =   2172
      End
      Begin VB.Label Label11 
         Caption         =   "Select Your Quest:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   228
         Left            =   144
         TabIndex        =   24
         Top             =   1032
         Width           =   3180
      End
      Begin VB.Label Label10 
         Caption         =   "Peasant"
         Height          =   228
         Left            =   576
         TabIndex        =   23
         Top             =   1368
         Width           =   684
      End
      Begin VB.Label Label9 
         Caption         =   "Footpad"
         Height          =   228
         Left            =   576
         TabIndex        =   22
         Top             =   1680
         Width           =   660
      End
      Begin VB.Label Label8 
         Caption         =   "Royal Knight"
         Height          =   228
         Left            =   576
         TabIndex        =   21
         Top             =   1992
         Width           =   972
      End
      Begin VB.Label Label6 
         Caption         =   "ScholasticMaze Designers Only!"
         Height          =   228
         Left            =   576
         TabIndex        =   20
         Top             =   2304
         Width           =   2388
      End
   End
   Begin VB.PictureBox Picture5 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   5880
      Left            =   2940
      ScaleHeight     =   5880
      ScaleWidth      =   10020
      TabIndex        =   0
      Top             =   1980
      Visible         =   0   'False
      Width           =   10020
      Begin VB.TextBox Text3 
         BackColor       =   &H8000000F&
         Height          =   612
         Left            =   3840
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   28
         TabStop         =   0   'False
         ToolTipText     =   "Answer Box"
         Top             =   4380
         Width           =   3132
      End
      Begin VB.TextBox Text2 
         BackColor       =   &H8000000F&
         Height          =   612
         Left            =   660
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   27
         TabStop         =   0   'False
         ToolTipText     =   "Question Box"
         Top             =   4380
         Width           =   3132
      End
      Begin VB.Timer Timer2 
         Enabled         =   0   'False
         Interval        =   20
         Left            =   8304
         Top             =   2736
      End
      Begin VB.PictureBox Picture2 
         AutoRedraw      =   -1  'True
         Height          =   4128
         Left            =   684
         ScaleHeight     =   4065
         ScaleWidth      =   6975
         TabIndex        =   15
         Top             =   120
         Width           =   7032
         Begin VB.PictureBox Picture4 
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   0  'None
            ForeColor       =   &H80000008&
            Height          =   2712
            Left            =   2100
            ScaleHeight     =   2715
            ScaleWidth      =   3375
            TabIndex        =   16
            Top             =   480
            Width           =   3372
            Begin VB.Image tile 
               Appearance      =   0  'Flat
               Height          =   552
               Index           =   600
               Left            =   360
               Top             =   600
               Width           =   552
            End
            Begin VB.Image Image1 
               Height          =   2112
               Left            =   1200
               Top             =   1440
               Width           =   3012
            End
         End
      End
      Begin VB.PictureBox Picture1 
         AutoSize        =   -1  'True
         BorderStyle     =   0  'None
         Enabled         =   0   'False
         Height          =   600
         Left            =   324
         Picture         =   "Form1.frx":0442
         ScaleHeight     =   600
         ScaleWidth      =   11925
         TabIndex        =   1
         Top             =   5112
         Width           =   11925
         Begin VB.PictureBox Picture3 
            Appearance      =   0  'Flat
            AutoSize        =   -1  'True
            BackColor       =   &H000000C0&
            Enabled         =   0   'False
            ForeColor       =   &H80000008&
            Height          =   324
            Left            =   4140
            ScaleHeight     =   300
            ScaleWidth      =   2280
            TabIndex        =   2
            Top             =   72
            Width           =   2316
            Begin VB.CommandButton Command1 
               Caption         =   "OK"
               Height          =   216
               Left            =   1656
               TabIndex        =   10
               Top             =   48
               Width           =   552
            End
            Begin VB.OptionButton Option1 
               BackColor       =   &H000000C0&
               Caption         =   "A"
               ForeColor       =   &H00FFFFFF&
               Height          =   252
               Left            =   36
               TabIndex        =   6
               Top             =   36
               Width           =   372
            End
            Begin VB.OptionButton Option2 
               BackColor       =   &H000000C0&
               Caption         =   "B"
               ForeColor       =   &H00FFFFFF&
               Height          =   252
               Left            =   432
               TabIndex        =   5
               Top             =   36
               Width           =   372
            End
            Begin VB.OptionButton Option3 
               BackColor       =   &H000000C0&
               Caption         =   "C"
               ForeColor       =   &H00FFFFFF&
               Height          =   252
               Left            =   816
               TabIndex        =   4
               Top             =   36
               Width           =   372
            End
            Begin VB.OptionButton Option4 
               BackColor       =   &H000000C0&
               Caption         =   "D"
               ForeColor       =   &H00FFFFFF&
               Height          =   252
               Left            =   1200
               MaskColor       =   &H8000000F&
               TabIndex        =   3
               Top             =   36
               Width           =   372
            End
         End
         Begin ComCtl2.Animation Animation1 
            Height          =   444
            Left            =   1296
            TabIndex        =   7
            Top             =   144
            Width           =   468
            _ExtentX        =   847
            _ExtentY        =   767
            _Version        =   327681
            Enabled         =   0   'False
            FullWidth       =   32
            FullHeight      =   29
         End
         Begin VB.Label Label5 
            BackStyle       =   0  'Transparent
            Caption         =   "(s) left"
            BeginProperty Font 
               Name            =   "Arial Black"
               Size            =   10.5
               Charset         =   0
               Weight          =   900
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000000&
            Height          =   264
            Left            =   7680
            TabIndex        =   18
            Top             =   120
            Width           =   960
         End
         Begin VB.Label Label1 
            BackStyle       =   0  'Transparent
            Caption         =   "00"
            BeginProperty Font 
               Name            =   "Arial Black"
               Size            =   10.5
               Charset         =   0
               Weight          =   900
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000000&
            Height          =   288
            Left            =   7296
            TabIndex        =   17
            Top             =   144
            Width           =   408
         End
         Begin VB.Label label2 
            BackStyle       =   0  'Transparent
            Caption         =   "100/100"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FFFFFF&
            Height          =   300
            Left            =   1740
            TabIndex        =   9
            Top             =   60
            Width           =   936
         End
         Begin VB.Label label7 
            BackStyle       =   0  'Transparent
            Caption         =   "1000"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   13.5
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FFFF80&
            Height          =   276
            Left            =   6552
            TabIndex        =   8
            Top             =   192
            Width           =   828
         End
      End
   End
   Begin VB.OLE OLE1 
      Appearance      =   0  'Flat
      AutoActivate    =   0  'Manual
      AutoVerbMenu    =   0   'False
      BackColor       =   &H00000000&
      BorderStyle     =   0  'None
      Class           =   "AVIFile"
      Enabled         =   0   'False
      Height          =   5676
      Left            =   456
      OLETypeAllowed  =   1  'Embedded
      SourceDoc       =   "intro.avi"
      TabIndex        =   26
      Top             =   264
      Width           =   7716
   End
   Begin VB.Menu gamemenu 
      Caption         =   "&Game"
      Begin VB.Menu newmenu 
         Caption         =   "New..."
         Shortcut        =   {F2}
      End
      Begin VB.Menu closemenu 
         Caption         =   "Close"
         Enabled         =   0   'False
         Shortcut        =   {F3}
      End
      Begin VB.Menu exitmenu 
         Caption         =   "Exit"
         Shortcut        =   ^X
      End
   End
   Begin VB.Menu optionsmenu 
      Caption         =   "&Options"
      Begin VB.Menu gameplaymenu 
         Caption         =   "Gameplay..."
         Shortcut        =   ^G
      End
      Begin VB.Menu viewhalloffamemenu 
         Caption         =   "View Hall of Fame..."
         Shortcut        =   ^H
      End
      Begin VB.Menu bosskeymenu 
         Caption         =   "Boss-Key"
         Shortcut        =   ^B
      End
   End
   Begin VB.Menu soundmenu 
      Caption         =   "&Sound"
      Begin VB.Menu musicmenu 
         Caption         =   "Music"
         Begin VB.Menu trackmenu 
            Caption         =   "Disabled"
            Index           =   0
         End
         Begin VB.Menu trackmenu 
            Caption         =   "- - - - - - - - - -"
            Enabled         =   0   'False
            Index           =   1
         End
         Begin VB.Menu trackmenu 
            Caption         =   "The Battle Begins"
            Index           =   5
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Resurrection"
            Index           =   6
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Song of Seclusion"
            Index           =   7
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Goblin"
            Index           =   8
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Boneyard"
            Index           =   9
         End
         Begin VB.Menu trackmenu 
            Caption         =   "March of Courage"
            Index           =   10
         End
         Begin VB.Menu trackmenu 
            Caption         =   "The Marketplace"
            Index           =   11
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Classical"
            Index           =   12
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Doom's Gate"
            Index           =   13
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Solemn"
            Index           =   14
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Medieval 1"
            Index           =   15
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Medieval 2"
            Index           =   16
         End
         Begin VB.Menu trackmenu 
            Caption         =   "Happy"
            Index           =   17
         End
      End
      Begin VB.Menu Effectsmenu 
         Caption         =   "Effects"
         Checked         =   -1  'True
         Shortcut        =   {F4}
      End
   End
   Begin VB.Menu helpmenu 
      Caption         =   "&Help"
      Begin VB.Menu instructionsmenu 
         Caption         =   "Instructions..."
         HelpContextID   =   1
         Shortcut        =   {F1}
      End
      Begin VB.Menu aboutmenu 
         Caption         =   "About..."
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim fastForwardSpeed As Long    ' seconds to seek for ff/rew
Dim fPlaying As Boolean         ' true if CD is currently playing
Dim fCDLoaded As Boolean        ' true if CD is the the player
Dim numTracks As Integer        ' number of tracks on audio CD
Dim trackLength() As String     ' array containing length of each track
Dim track As Integer            ' current track
Dim min As Integer              ' current minute on track
Dim sec As Integer              ' current second on track
Dim cmd As String               ' string to hold mci command strings
Dim cdaudio As Boolean
Dim rnum!
Const numrows% = 17
Const numcols% = 31
Const tilesize% = 24
Const walltex = 0
Const floortex = 1
Const monstertex = 2    '4-mainchar 6-person 7-?
Const healthtex = 3     '0-wall 1-ground 2-monster 3-health 5-finish
Const stairstex = 5
Const questiontex = 7
Const monsternum = 22
Const L1BONUS = 5
Const L2BONUS = 10
Const L3BONUS = 20
Const L4BONUS = 35
Const L5BONUS = 55
Const L6BONUS = 80
Const L1TIME = 10
Const L2TIME = 12
Const L3TIME = 15
Const L4TIME = 17
Const L5TIME = 20
Const L6TIME = 40
Const L1MONBEAT = 10
Const L2MONBEAT = 15
Const L3MONBEAT = 25
Const L4MONBEAT = 40
Const L5MONBEAT = 60
Const L6MONBEAT = 85
Const L1COMP = 20
Const L2COMP = 50
Const L3COMP = 90
Const L4COMP = 140
Const L5COMP = 200
Const L6HEALTHLOSS = 30
Dim i%
Dim tileimgindex(0 To numrows%, 0 To numcols%) As Byte
Dim tilepassable(0 To numrows%, 0 To numcols%) As Boolean
Dim tilenumber(0 To numrows%, 0 To numcols%) As Integer
Dim posr%, posc%, newposr%, newposc%, twx%, twy%, levelnumber%, score%
Dim tilepic(0 To 10) As Variant
Dim questiontime%
Dim health%, maxhealth%, nextmonster%
Dim question$(1 To 18)
Dim answa$(1 To 18)
Dim answb$(1 To 18)         '$-string %-integer
Dim answc$(1 To 18)         '!-single &-long
Dim answd$(1 To 18)
Dim startfight!, endfight!
Dim currentrightanswer%
Dim correctans%(1 To 18)
Dim questionsused(1 To 18) As Boolean
Dim optionclicked As Boolean
Dim keyboardbuffer$, currentname$
Dim sfxstate As Boolean, ingame As Boolean, prevframe As Boolean, fightmonster As Boolean, prevdir As Boolean
Dim musrun As Boolean, optionclick As Boolean
Dim playtime!
Dim monsterpic(1 To 6) As Variant
Dim difficulty As Byte
Dim mp3tracks(2 To 18)


Private Sub Form_Load()
'ChDir "c:\scholasticmaze"
CommonDialog1.HelpFile = CurDir + "\help.hlp"
CommonDialog1.HelpCommand = cdlHelpIndex
cdaudio = False
Label1.Caption = "00"
musicmenu.Enabled = False
' If we're already running, then quit
If (App.PrevInstance = True) Then
    End
End If
fastForwardSpeed = 5
fCDLoaded = False
'''If (SendMCIString("open cdaudio alias cd wait shareable", True) = False) Then
'''    MsgBox ("CD being used or no CD loaded. CD audio disabled")
'''    cdaudio = False
'''End If
Update
'''SendMCIString "set cd time format tmsf wait", True
'Timer1.Enabled = True
Update
Randomize
playtime = Timer 'find out starting time of game
currentname$ = "Sausage"
Text1.Text = currentname$
'If CurDir = "C:\Program Files\DevStudio\VB" Then
'End If
On Error GoTo 0
Animation1.Open (CurDir + "\heart.avi")
OLE1.CreateEmbed CurDir + "\intro.avi"
OLE1.Width = Screen.TwipsPerPixelX * 640
OLE1.Height = Screen.TwipsPerPixelY * 480
initvars
loadgraphics
formatgamescreen
OLE1.Left = (Form1.ScaleWidth / 2) - (OLE1.Width / 2)
OLE1.Top = (Form1.ScaleHeight / 2) - (OLE1.Height / 2)
pcd (2)
OLE1.DoVerb
End Sub
Private Sub pcd(trck As Integer)
If trackmenu(0).Checked = False Then
track = trck
fPlaying = True
'playClick
SendMCIString "pause cd", True
cmd = "play cd from " & track
SendMCIString cmd, True
Dim tracktoplay
tracktoplay = App.Path & "\music\track" & Format(trck, "00") & ".mp3"
With MMControl1
    .Command = "close"
    .Command = "Stop"
    .FileName = tracktoplay   ' Set the file to be played
    .Command = "Open"                       ' Open the file
    .Command = "Play"                       ' Play the file
    Debug.Print "Open "; MMControl1.Error; " "; MMControl1.ErrorMessage
End With
End If
End Sub

Private Sub initvars()
fightmonster = False
musrun = False
Text1.Enabled = False
Picture3.Enabled = False
optionclicked = False
sfxstate = True
levelnumber% = 1
ingame = False
Num_Devs
End Sub

Private Sub Command1_Click()
If fightmonster = True And optionclicked = True Then
    optionclicked = False
    evaluateansw
End If
End Sub

Private Sub dostuff()
If fightmonster = True Then
    optionclicked = True
End If
End Sub


Private Sub gameplaymenu_Click()
If OLE1.Visible = True Then
OLE1.Close
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
Frame1.Visible = True
Text1.Enabled = True
Text1.SetFocus
Text1.SelStart = 0
Text1.SelLength = 20
optionclick = True
End Sub

Private Sub OLE1_Updated(Code As Integer)
If Code = 2 Then
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
End Sub

Private Sub Slider1_Click()
difficulty = Slider1.Value
End Sub

Private Sub Timer2_Timer()
If Picture1.BackColor = vbRed Then
Picture1.BackColor = vbButtonFace
Animation1.BackColor = vbButtonFace
Else
Picture1.BackColor = vbRed
Animation1.BackColor = vbRed
End If
i% = i% + 1
If i% = 10 Then
Timer2.Enabled = False
End If
End Sub

Private Sub trackmenu_Click(Index As Integer)
track = Index

If Not Index = 0 Then
fPlaying = True
'playClick
SendMCIString "pause cd", True
cmd = "play cd from " & track
SendMCIString cmd, True
trackmenu(0).Checked = False
ElseIf Index = 0 Then
track = 1
stopbtnClick
fPlaying = False
If trackmenu(0).Checked = True Then
trackmenu(0).Checked = False
ElseIf trackmenu(0).Checked = False Then
trackmenu(0).Checked = True
End If
End If
End Sub

Private Sub Form_activate()
hof.Visible = False
End Sub


Private Sub Option1_Click()
dostuff
End Sub

Private Sub Option2_Click()
dostuff
End Sub

Private Sub Option3_Click()
dostuff
End Sub

Private Sub Option4_Click()
dostuff
End Sub
'start textbox start textbox start textbox start textbox start textbox
Private Sub Text1_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then '{enter}
    frameaccept
ElseIf KeyAscii = 27 Then '{esc}
    framecancel
End If
End Sub
Private Sub frameaccept()

currentname$ = Text1.Text
Frame1.Visible = False
Text1.Enabled = False
If ingame = False And optionclick = False Then
gamestart 'gamestart
pcd (5)
End If
optionclick = False
End Sub
Private Sub framecancel()
Frame1.Visible = False
Text1.Text = currentname$
Text1.Enabled = False
newmenu.Enabled = True
optionclick = False
End Sub
Private Sub Command2_Click()
frameaccept
End Sub
Private Sub Command3_Click()
framecancel
End Sub
'end textbox end textbox end textbox end textbox end textbox end textbox
Private Sub newmenu_Click()
If OLE1.Visible = True Then
OLE1.Close
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
newmenu.Enabled = False
Text1.Enabled = True
Frame1.Visible = True
Text1.SetFocus
Text1.SelStart = 0
Text1.SelLength = 20
End Sub
Private Sub closemenu_Click()
Dim a%
a% = MsgBox("End Current Game?", vbOKCancel, "Abort Game")
If a% = vbOK Then
Timer1.Enabled = False
questiontime% = 0
Picture5.Visible = False
closemenu.Enabled = False
Form1.Caption = "ScholasticMaze"
newmenu.Enabled = True
ingame = False
Form1.KeyPreview = False
pcd (2)
End If
End Sub
Private Sub Effectsmenu_Click()
If Effectsmenu.Checked = True Then
    Effectsmenu.Checked = False
    sfxstate = False
Else:
    Effectsmenu.Checked = True
    sfxstate = True
End If
End Sub
Private Sub checkhof()
Dim a%, b%
For a% = 9 To 1 Step -1
    If score% >= CInt(Val(hofscore$(a%))) And score% <= CInt(Val(hofscore$(a% - 1))) Or score% >= CInt(Val(hofscore$(0))) Then
        hofcomment$(9) = InputBox("You have been accepted into the Hall of Fame. Please enter a comment:", "Hall of Fame info - Score: " + Trim(Str(score%)) + " Name: " + currentname$)
        hofname$(9) = currentname$
        hofscore$(9) = Trim(Str(score%))
        hof.Show
        Exit For
    End If
Next a%
End Sub
Private Sub loadmap(mapnum As Integer)
Dim rowcount%, colcount%, mapletter$
rnum! = Rnd
Select Case rnum!
Case Is <= (1 / 3)
mapletter$ = "a"
Case Is <= (2 / 3)
mapletter$ = "b"
Case Is <= 1
mapletter$ = "c"
End Select
Open CurDir + "\m" + Trim(Str(mapnum)) + mapletter$ + ".dat" For Input Access Read As #1
For rowcount% = 0 To numrows%
    For colcount% = 0 To numcols%
        Input #1, tileimgindex(rowcount%, colcount%)
        If tileimgindex(rowcount%, colcount%) = 0 Or tileimgindex(rowcount%, colcount%) = 5 Then 'impassable criteria
        tilepassable(rowcount%, colcount%) = False
        Else
        tilepassable(rowcount%, colcount%) = True
        End If
    Next colcount%
Next rowcount%
Input #1, posr%
Input #1, posc%
Close #1
Form1.Caption = "ScholasticMaze - Level " + Trim(Str(mapnum))
End Sub
Private Sub paintmap(cheat As Boolean)
Dim rowcount%, colcount%
For rowcount% = 0 To numrows%
    For colcount% = 0 To numcols%
        If cheat = True Then
        tile(tilenumber(rowcount%, colcount%)).Picture = tilepic(tileimgindex(rowcount%, colcount%))
        Else
        tile(tilenumber(rowcount%, colcount%)).Picture = tilepic(7)
        End If
    Next colcount%
Next rowcount%
newposr% = posr%
newposc% = posc%
refreshpos
End Sub
Private Sub getquestions(levelnum As Integer)
Dim count%
Open CurDir + "\m" + Trim(Str(levelnum)) + ".qid" For Input As #1
For count% = 1 To 18
    Line Input #1, question$(count%)
    Line Input #1, answa$(count%)
    Line Input #1, answb$(count%)
    Line Input #1, answc$(count%)
    Line Input #1, answd$(count%)
    Input #1, correctans%(count%)
Next count%
Close #1
End Sub
Private Sub meetmonster()
Dim randchoice%, randchoice2%, questionchoice%
nextmonster% = nextmonster% + 1
Image1.Picture = monsterpic(nextmonster%)
Picture1.BackColor = vbButtonFace
Animation1.BackColor = vbButtonFace
Form1.Refresh
If nextmonster% = 6 And Not levelnumber% = 6 Then
nextmonster% = 0
End If
startfight! = Timer
Timer1.Enabled = True
Select Case levelnumber%
Case 1
questiontime% = L1TIME
Case 2
questiontime% = L2TIME
Case 3
questiontime% = L3TIME
Case 4
questiontime% = L4TIME
Case 5
questiontime% = L5TIME
Case 6
questiontime% = L6TIME
End Select
Do
randchoice% = Int(6 * Rnd)
randchoice2% = Int((3 * Rnd) + 1)
questionchoice% = randchoice% * 3 + randchoice2%
Loop Until (questionsused(questionchoice%) = False)
questionsused(randchoice% * 3 + 1) = True
questionsused(randchoice% * 3 + 2) = True
questionsused(randchoice% * 3 + 3) = True
Text2.Text = question$(questionchoice%)
Text3.Text = answa$(questionchoice%) & vbCr & vbLf & answb$(questionchoice%) & vbCr & vbLf & answc$(questionchoice%) & vbCr & vbLf & answd$(questionchoice%)
currentrightanswer% = correctans%(questionchoice%)
Picture3.Enabled = True
Picture1.Enabled = True
End Sub
Private Sub evaluateansw()
Dim key As Integer, a%
If Option1.Value = True Then
    key = 1
ElseIf Option2.Value = True Then
    key = 2
ElseIf Option3.Value = True Then
    key = 3
ElseIf Option4.Value = True Then
    key = 4
End If
endfight! = Timer
Timer1.Enabled = False
Form1.Caption = "ScholasticMaze - Level " + Trim(Str(levelnumber%))
If currentrightanswer% = key Then
    MsgBox "RIGHT!", , "Answer is:"
    Select Case levelnumber%
    Case 1
    score% = score% + L1MONBEAT * (difficulty + 1)
    Case 2
    score% = score% + L2MONBEAT * (difficulty + 1)
    Case 3
    score% = score% + L3MONBEAT * (difficulty + 1)
    Case 4
    score% = score% + L4MONBEAT * (difficulty + 1)
    Case 5
    score% = score% + L5MONBEAT * (difficulty + 1)
    Case 6
    score% = score% + L6MONBEAT * (difficulty + 1)
    End Select
    If questiontime% > 0 Then
    Select Case levelnumber%
    Case 1
    score% = score% + (L1BONUS * difficulty) + 2
    Case 2
    score% = score% + (L2BONUS * difficulty) + 2
    Case 3
    score% = score% + (L3BONUS * difficulty) + 2
    Case 4
    score% = score% + (L4BONUS * difficulty) + 2
    Case 5
    score% = score% + (L5BONUS * difficulty) + 2
    Case 6
    score% = score% + (L6BONUS * difficulty) + 2
    End Select
    End If
    label7.Caption = Trim(Str(score%))
    questiontime% = 0
    rnum! = Rnd
    Select Case rnum!
    Case Is <= 0.15
    PlayWav ("win.wav")
    Case Is <= 0.3
    PlayWav ("win1.wav")
    Case Is <= 0.45
    PlayWav ("win5.wav")
    Case Is <= 0.6
    PlayWav ("win3.wav")
    Case Is <= 0.75
    PlayWav ("win4.wav")
    Case Else
    PlayWav ("win2.wav")
    End Select
ElseIf Not currentrightanswer% = key Then
    MsgBox "WRONG!", , "Answer is:"
    Timer2.Enabled = True
    i% = 0
    If Not levelnumber% = 6 Then
    health% = health% - Int(((Rnd * 3) + 3) * levelnumber% * (difficulty + 1))
    ElseIf levelnumber% = 6 Then
    health% = health% - L6HEALTHLOSS - (10 * difficulty)
    Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
    Label2.Refresh
    End If
    If health% <= 0 Then
    pcd (4)
    health% = 0
    PlayWav ("slain.wav")
    a% = MsgBox(currentname$ + ", thanks for playing ScholasticMaze.  If you try harder next time, you might even beat level " + Trim(Str(levelnumber%)) + ".", vbOKOnly, "Monster Chow")
    Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
    label7.Caption = Trim(Str(score%))
    Label2.Refresh
    label7.Refresh
    checkhof
    sorthofvars
    writehof
    gethof
    health% = 0
    Timer1.Enabled = False
questiontime% = 0
Picture5.Visible = False
closemenu.Enabled = False
Form1.Caption = "ScholasticMaze"
newmenu.Enabled = True
ingame = False
Form1.KeyPreview = False
pcd (2)
Exit Sub
    End If
    Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
    rnum! = Rnd
    Select Case rnum!
    Case Is <= 0.2
    PlayWav ("pain.wav")
    Case Is <= 0.4
    PlayWav ("pain2.wav")
    Case Is <= 0.6
    PlayWav ("pain3.wav")
    Case Is <= 0.8
    PlayWav ("pain4.wav")
    Case Else
    PlayWav ("pain5.wav")
    End Select
End If
Image1.Picture = LoadPicture()
fightmonster = False
tileimgindex(posr%, posc%) = floortex
'Picture1.SetFocus
resetoptions
Picture3.Enabled = False
Picture1.Enabled = False
Label1.Caption = "00"
Text2.Text = ""
Text3.Text = ""
End Sub
Private Sub resetoptions()
Option1.Value = False
Option2.Value = False
Option3.Value = False
Option4.Value = False
End Sub
Private Sub resetquestionsused()
Dim count%
For count% = 1 To 18
questionsused(count%) = False
Next count%
End Sub
Private Sub checkifmonster()
Dim a%
If tileimgindex(newposr%, newposc%) = monstertex And Not (nextmonster% = 6 And levelnumber% = 6) Then
    rnum! = Rnd
    Select Case rnum!
    Case Is >= 0.5
    PlayWav ("monster.wav")
    Case Is >= 0
    PlayWav ("monster2.wav")
    End Select
    meetmonster
    fightmonster = True
    resetoptions
ElseIf nextmonster% = 6 And levelnumber% = 6 Then
pcd (3)
score% = score% + 300 * (difficulty + 1)
Image1.Picture = LoadPicture(CurDir + "\happycastle.jpg")
PlayWav ("gurgle.wav")
a% = MsgBox(currentname$ + ", congratulations, the monster infestation is over. After proving your worth using your undoubtable intelligence and wit the rest of the hellspawn turned tail and ran. You now retire to a comfortable cup of tea and crumpets within your newly-purged castle.  Hopefully, they won't come back.", vbOKOnly, "The ScholasticMaze has been conquered!")
    checkhof
    sorthofvars
    writehof
    gethof
    health% = 0
    Timer1.Enabled = False
questiontime% = 0
Picture5.Visible = False
closemenu.Enabled = False
Form1.Caption = "ScholasticMaze"
newmenu.Enabled = True
ingame = False
Form1.KeyPreview = False
pcd (2)
End If
End Sub
Private Sub checkifhealth()
If tilepassable(newposr%, newposc%) = True And tileimgindex(newposr%, newposc%) = healthtex Then
health% = health% + Int(11 * Rnd + 15)
If health% > maxhealth% Then
health% = maxhealth%
End If
Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
tileimgindex(posr%, posc%) = floortex
PlayWav ("health.wav")
End If
End Sub
Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
updatepos
label7.Caption = Trim(Str(score%))
Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
If ingame = True And fightmonster = False Then '-----------------------------------
Select Case KeyCode
Case 37 'left
    newposr% = posr%
    newposc% = posc% - 1
    If tilepassable(newposr%, newposc%) = False And Not tileimgindex(newposr%, newposc%) = stairstex Then
        PlayWav ("hitwall.wav")
        Exit Sub
    ElseIf tilepassable(newposr%, newposc%) = False And tileimgindex(newposr%, newposc%) = stairstex Then
    nextmap
    End If
    checkifmonster
    prevdir = False
    refreshpos
    checkifhealth
    Exit Sub
    
Case 38 'up
    newposr% = posr% - 1
    newposc% = posc%
    If tilepassable(newposr%, newposc%) = False And Not tileimgindex(newposr%, newposc%) = stairstex Then
        PlayWav ("hitwall.wav")
        Exit Sub
    ElseIf tilepassable(newposr%, newposc%) = False And tileimgindex(newposr%, newposc%) = stairstex Then
    nextmap
    End If
    checkifmonster
    refreshpos
    checkifhealth
    Exit Sub

Case 39 'right
    newposr% = posr%
    newposc% = posc% + 1
    If tilepassable(newposr%, newposc%) = False And Not tileimgindex(newposr%, newposc%) = stairstex Then
        PlayWav ("hitwall.wav")
        Exit Sub
    ElseIf tilepassable(newposr%, newposc%) = False And tileimgindex(newposr%, newposc%) = stairstex Then
    nextmap
    End If
    checkifmonster
    prevdir = True
    refreshpos
    checkifhealth
    Exit Sub

Case 40 'down
    newposr% = posr% + 1
    newposc% = posc%
    If tilepassable(newposr%, newposc%) = False And Not tileimgindex(newposr%, newposc%) = stairstex Then
        PlayWav ("hitwall.wav")
        Exit Sub
    ElseIf tilepassable(newposr%, newposc%) = False And tileimgindex(newposr%, newposc%) = stairstex Then
    nextmap
    End If
    checkifmonster
    refreshpos
    checkifhealth
    Exit Sub
Case Else
    keyboardbuffer$ = keyboardbuffer$ + Chr(KeyCode)
    If Len(keyboardbuffer$) > 200 Then
        keyboardbuffer$ = ""
    End If
    If InStr(1, keyboardbuffer$, "showusyerboobs", vbTextCompare) > 0 Then
        paintmap (True)
        keyboardbuffer$ = ""
    ElseIf InStr(1, keyboardbuffer$, "giversomeyamee", vbTextCompare) > 0 And Not levelnumber% = 6 Then
        nextmap
        keyboardbuffer$ = ""
    ElseIf InStr(1, keyboardbuffer$, "upwego", vbTextCompare) > 0 Then
        health% = maxhealth%
        keyboardbuffer$ = ""
    End If
End Select
End If
'------------------------------------------------
If ingame = True And fightmonster = True Then
Select Case KeyCode
Case vbKeyA
    Option1.Value = True
    optionclicked = True
Case vbKeyB
    Option2.Value = True
    optionclicked = True
Case vbKeyC
    Option3.Value = True
    optionclicked = True
Case vbKeyD
    Option4.Value = True
    optionclicked = True
Case Is = vbKeyReturn And optionclicked = True
    optionclicked = False
    evaluateansw
End Select
End If
End Sub

Private Sub refreshpos()
Dim rowrefresh%, colrefresh%
For rowrefresh% = -1 To 1
    For colrefresh% = -1 To 1
        tile(tilenumber(newposr% + rowrefresh%, newposc% + colrefresh%)) = tilepic(tileimgindex(newposr% + rowrefresh%, newposc% + colrefresh%))
    Next colrefresh%
Next rowrefresh%
If prevdir = True Then
    If prevframe = False Then
    tile(tilenumber(newposr%, newposc%)) = tilepic(4)
    prevframe = True
    Else
    tile(tilenumber(newposr%, newposc%)) = tilepic(6)
    prevframe = False
    End If
ElseIf prevdir = False Then
    If prevframe = False Then
    tile(tilenumber(newposr%, newposc%)) = tilepic(8)
    prevframe = True
    Else
    tile(tilenumber(newposr%, newposc%)) = tilepic(9)
    prevframe = False
    End If
End If
posr% = newposr%
posc% = newposc%
End Sub

Private Sub gamestart()
resetquestionsused
levelnumber% = 0
maxhealth% = 80
health% = 80
Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
label7.Caption = Trim(Str(score%))
score% = 0
nextmap
Picture5.Visible = True
fightmonster = False
Animation1.AutoPlay = True
Form1.KeyPreview = True
ingame = True
closemenu.Enabled = True
optionclicked = False
Image1.Picture = LoadPicture()
resetoptions
Picture3.Enabled = False
Picture1.Enabled = False
Text2.Text = ""
Text3.Text = ""
End Sub
Private Sub nextmap()
Dim monstersused(1 To monsternum) As Boolean, temp%
Dim a%
Picture1.BackColor = vbButtonFace
Animation1.BackColor = vbButtonFace
nextmonster% = 0
resetquestionsused
levelnumber% = levelnumber% + 1
maxhealth% = maxhealth% + 20
health% = health% + 20
loadmap (levelnumber%)
getquestions (levelnumber%)
paintmap (False)
fightmonster = False
optionclicked = False
Image1.Picture = LoadPicture()
resetoptions
Picture3.Enabled = False
Text2.Text = ""
Text3.Text = ""
If levelnumber% = 2 Then
a% = MsgBox("Congratulations " + currentname$ + ", you have achieved the formidable task of reaching level 2. Many monsters still lurk ahead, so beware!", vbOKOnly, "Level One Complete")
score% = score% + (L1COMP * (difficulty + 1))
ElseIf levelnumber% = 3 Then
a% = MsgBox("Wow " + currentname$ + ", level 3 already, keep it up!", vbOKOnly, "Level 2 Complete")
score% = score% + (L2COMP * (difficulty + 1))
ElseIf levelnumber% = 4 Then
a% = MsgBox("Impressive " + currentname$ + ", you have accomplished the elusive task of reaching level 4.", vbOKOnly, "Level Three Complete")
score% = score% + (L3COMP * (difficulty + 1))
ElseIf levelnumber% = 5 Then
a% = MsgBox("Very impressive " + currentname$ + ", you have entered among the ranks of the elite.", vbOKOnly, "Level Four Complete")
score% = score% + (L4COMP * (difficulty + 1))
ElseIf levelnumber% = 6 Then
a% = MsgBox("The worst is yet to come " + currentname$ + ".  Let us see whether you can survive the upcoming test of true bravery!", vbOKOnly, "Level Five Complete")
score% = score% + (L5COMP * (difficulty + 1))
End If
If Not levelnumber% = 6 Then
For a% = 1 To 6
    Do
        temp% = Int(Rnd * monsternum + 1)
    Loop While monstersused(temp%) = True
    monstersused(temp%) = True
    Set monsterpic(a%) = LoadPicture(CurDir + "\m" + Trim(Str(temp%)) + ".jpg")
Next a%
Else
For a% = 1 To 6
Set monsterpic(a%) = LoadPicture(CurDir + "\azinhoth.jpg")
Next a%
End If
Label2.Caption = Trim(Str(health%)) + "/" + Trim(Str(maxhealth%))
label7.Caption = Trim(Str(score%))
label7.Refresh
Label2.Refresh
End Sub
' raw procedures raw procedures raw procedures raw procedures raw procedures raw procedures raw procedures
Private Sub formatgamescreen()
Dim tilecount%, rowcount%, colcount%, counts%
Load hof
For counts% = 0 To 575
Load tile(counts%)
tile(counts%).Visible = True
Next counts%
tile(600).Enabled = False
tile(600).Visible = False
twx% = Screen.TwipsPerPixelX
twy% = Screen.TwipsPerPixelY
Form1.Width = twx% * 800
Form1.Height = twy% * 600
Picture5.Width = Form1.ScaleWidth
Picture5.Height = Form1.ScaleHeight
Picture2.Width = Picture5.ScaleWidth
Picture2.Height = (twy% * (numrows% + 1) * tilesize%) + (10 * twy%)
Picture4.Width = twx% * (numcols% + 1) * tilesize%
Picture4.Height = twy% * (numrows% + 1) * tilesize%
Picture1.Width = Picture5.ScaleWidth
Picture1.Height = 40 * twy%
Text2.Width = CInt(Picture2.Width * 0.55)
Text2.Height = Picture5.ScaleHeight - Picture2.Height - Picture1.Height
Text3.Width = CInt(Picture2.Width * 0.45)
Text3.Height = Picture5.ScaleHeight - Picture2.Height - Picture1.Height
Picture5.Left = 0
Picture5.Top = 0
Picture2.Left = 0
Picture2.Top = 0
Picture4.Left = CInt((Picture2.ScaleWidth / 2) - (Picture4.Width / 2))
Picture4.Top = CInt((Picture2.ScaleHeight / 2) - (Picture4.Height / 2))
Text2.Left = 0
Text2.Top = Picture2.Height
Text3.Left = Text2.Width
Text3.Top = Picture2.Height
Text2.Text = ""
Text3.Text = ""
Picture1.Left = 0
Picture1.Top = Picture2.Height + Text2.Height
Animation1.Width = 38 * twx%
Animation1.Height = 38 * twy%
Animation1.Left = twx%
Animation1.Top = 3 * twy%
Label2.Left = twx% * 145
Label2.Top = twy% * 6
Picture3.Left = 343 * twx%
Picture3.Top = CInt((Picture1.ScaleHeight / 2) - (Picture3.Height / 2))
label7.Left = 550 * twx%
label7.Top = 17 * twy%
Label1.Left = twx% * 635
Label1.Top = twy% * 16
Label5.Height = Label1.Height
Label5.Top = Label1.Top
Label5.Left = Label1.Left + Label1.Width
Frame1.Left = CInt((ScaleWidth / 2) - (Frame1.Width / 2))
Frame1.Top = CInt((ScaleHeight / 2) - (Frame1.Height / 2))
tilecount% = 0
For rowcount% = 0 To numrows%
    For colcount% = 0 To numcols%
        tile(tilecount%).Left = colcount% * tilesize% * twx%
        tile(tilecount%).Top = rowcount% * tilesize% * twy%
        tile(tilecount%).Stretch = True
        tile(tilecount%).Width = tilesize% * twx%
        tile(tilecount%).Height = tilesize% * twy%
        tilenumber(rowcount%, colcount%) = tilecount%
        tilecount% = tilecount% + 1
    Next colcount%
Next rowcount%
Image1.Left = 0
Image1.Top = 0
Image1.Width = twx% * (numcols% + 1) * tilesize%
Image1.Height = twy% * (numrows% + 1) * tilesize%
Image1.Stretch = True
hofbuildform
gethof
End Sub
Private Sub loadgraphics()
Set tilepic(walltex) = LoadPicture(CurDir + "\wall.bmp")
Set tilepic(floortex) = LoadPicture(CurDir + "\floor.bmp")
Set tilepic(monstertex) = LoadPicture(CurDir + "\monster.bmp")
Set tilepic(healthtex) = LoadPicture(CurDir + "\health.bmp")
Set tilepic(4) = LoadPicture(CurDir + "\person.bmp")
Set tilepic(stairstex) = LoadPicture(CurDir + "\stairs.bmp")
Set tilepic(6) = LoadPicture(CurDir + "\person2.bmp")
Set tilepic(questiontex) = LoadPicture(CurDir + "\qmark.bmp")
Set tilepic(8) = LoadPicture(CurDir + "\person3.bmp")
Set tilepic(9) = LoadPicture(CurDir + "\person4.bmp")
End Sub
Private Sub PlayWav(sFilename As String)
Dim X&
If sfxstate = True Then
X& = sndPlaySound(sFilename, 1)
End If
End Sub

Sub Num_Devs()
    Dim i As Long
    i = waveOutGetNumDevs()
    If i > 0 Then         ' There is at least one device.
    Else
    Effectsmenu.Checked = False
    sfxstate = False
    Effectsmenu.Enabled = False
    End If
End Sub

Private Sub aboutmenu_Click()
Dim a%
If OLE1.Visible = True Then
OLE1.Close
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
a% = MsgBox("   ScholasticMaze version 1.0" + Chr(vbKeyReturn) + "by Andrew Kittmer, Avery Yuen," + Chr(vbKeyReturn) + "      and Chris Christodoulou", vbExclamation, "About this program...")
End Sub

Private Sub bosskeymenu_Click()
Dim totalsecs!, numhours%, nummins%, numseconds&
Dim a%, b%, c%
If OLE1.Visible = True Then
OLE1.Close
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
Form2.Show
Form1.Hide
totalsecs! = Timer - playtime!
numhours% = totalsecs! \ 3600
nummins% = (totalsecs! - (numhours% * 3600)) \ 60
numseconds& = (totalsecs! - (numhours% * 3600) - (nummins% * 60)) \ 1
b% = MsgBox("Oh.  We get it.  You don't want your boss to know that you've been playing ScholasticMaze.", , "")
a% = MsgBox("In fact, you don't want your boss to know that you've been playing ScholasticMaze for " _
+ Str(numhours%) + " hour(s) " _
+ Str(nummins%) + " minute(s) and " + Str(numseconds&) _
+ " second(s).", , "")
c% = MsgBox("That's a good idea, but doesn't cheating like that induce feelings of guilt?  Have a nice day!", , "")
End Sub
Private Sub instructionsmenu_Click()
If OLE1.Visible = True Then
OLE1.Close
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
CommonDialog1.ShowHelp
End Sub
Sub Form_Unload(Cancel As Integer)
Dim a%
a% = MsgBox("Exit ScholasticMaze?", vbOKCancel, "Quit Program")
If a% = vbCancel Then
Cancel = 1
Else
'Close all MCI devices opened by this program
If musicmenu.Enabled = True Then
stopbtnClick
SendMCIString "close all", False
End If
End
End If
End Sub
Sub exitmenu_Click()
Dim a%
a% = MsgBox("Exit ScholasticMaze?", vbOKCancel, "Quit Program")
If a% = vbOK Then
If musicmenu.Enabled = True Then
stopbtnClick
SendMCIString "close all", False
End If
End
End If
End Sub

Private Sub quickexitmenu_Click()
End
End Sub

Private Sub Timer1_Timer()
questiontime% = questiontime% - 1
If questiontime% <= -1 Then
Timer1.Enabled = False
Label1.Caption = "00"
Exit Sub
End If
Label1.Caption = Trim(Str(questiontime%))
PlayWav ("counter.wav")
End Sub


Private Sub viewhalloffamemenu_Click()
If OLE1.Visible = True Then
OLE1.Close
'OLE1.Visible = False
Form1.BackColor = vbApplicationWorkspace
End If
hof.Show
End Sub
' Send a MCI command string
' If fShowError is true, display a message box on error
Private Function SendMCIString(cmd As String, fShowError As Boolean) As Boolean
Static rc As Long
Static errStr As String * 200
If cdaudio Then
rc = mciSendString(cmd, 0, 0, hWnd)
If (fShowError And rc <> 0) Then
    mciGetErrorString rc, errStr, Len(errStr)
    MsgBox errStr
End If
SendMCIString = (rc = 0)
End If
End Function

' Play the CD
Private Sub playClick()
SendMCIString "play cd", True
fPlaying = True
End Sub
' Stop the CD play
Private Sub stopbtnClick()
SendMCIString "stop cd wait", True
cmd = "seek cd to " & track
SendMCIString cmd, True
fPlaying = False
Update
End Sub
' Pause the CD
Private Sub pauseClick()
SendMCIString "pause cd", True
fPlaying = False
Update
End Sub
' Eject the CD
Private Sub ejectClick()
SendMCIString "set cd door open", True
Update
End Sub
' Fast forward
Private Sub ffClick()
Dim s As String * 40

SendMCIString "set cd time format milliseconds", True
mciSendString "status cd position wait", s, Len(s), 0
If (fPlaying) Then
    cmd = "play cd from " & CStr(CLng(s) + fastForwardSpeed * 1000)
Else
    cmd = "seek cd to " & CStr(CLng(s) + fastForwardSpeed * 1000)
End If
mciSendString cmd, 0, 0, 0
SendMCIString "set cd time format tmsf", True
Update
End Sub
' Rewind the CD
Private Sub rewClick()
Dim s As String * 40

SendMCIString "set cd time format milliseconds", True
mciSendString "status cd position wait", s, Len(s), 0
If (fPlaying) Then
    cmd = "play cd from " & CStr(CLng(s) - fastForwardSpeed * 1000)
Else
    cmd = "seek cd to " & CStr(CLng(s) - fastForwardSpeed * 1000)
End If
mciSendString cmd, 0, 0, 0
SendMCIString "set cd time format tmsf", True
Update
End Sub
' Forward track
Private Sub ftrackClick()
If (track < numTracks) Then
    If (fPlaying) Then
        cmd = "play cd from " & track + 1
        SendMCIString cmd, True
    Else
        cmd = "seek cd to " & track + 1
        SendMCIString cmd, True
    End If
Else
    SendMCIString "seek cd to 1", True
End If
Update
End Sub
' Go to previous track
Private Sub btrackClick()
Dim from As String
If (min = 0 And sec = 0) Then
    If (track > 1) Then
        from = CStr(track - 1)
    Else
        from = CStr(numTracks)
    End If
Else
    from = CStr(track)
End If
If (fPlaying) Then
    cmd = "play cd from " & from
    SendMCIString cmd, True
Else
    cmd = "seek cd to " & from
    SendMCIString cmd, True
End If
Update
End Sub
Private Sub updatepos()
On Error Resume Next
Static s As String * 30
    If trackmenu(0).Checked = False Then
    mciSendString "status cd position", s, Len(s), 0
    track = CInt(Mid$(s, 1, 2))
If track = 18 And ingame = True Then
pcd (5)
End If
End If
End Sub
' Update the display and state variables
Private Sub Update()
Static s As String * 30

' Check if CD is in the player
If cdaudio Then
mciSendString "status cd media present", s, Len(s), 0
If (CBool(s)) Then
    cdaudio = True
    musicmenu.Enabled = True
    ' Enable all the controls, get CD information
    If (fCDLoaded = False) Then
        mciSendString "status cd number of tracks wait", s, Len(s), 0
        numTracks = CInt(Mid$(s, 1, 2))
        'eject.Enabled = True
        
        ' If CD only has 1 track, then it's probably a data CD
        If (numTracks = 1) Then
            Exit Sub
        End If
        
        mciSendString "status cd length wait", s, Len(s), 0
        'totalplay.Caption = "Tracks: " & numTracks & "  Total time: " & s
        ReDim trackLength(1 To numTracks)
        Dim i As Integer
        For i = 1 To numTracks
            cmd = "status cd length track " & i
            mciSendString cmd, s, Len(s), 0
            trackLength(i) = s
        Next
        'Play.Enabled = True
        'pause.Enabled = True
        'ff.Enabled = True
        'rew.Enabled = True
        'ftrack.Enabled = True
        'btrack.Enabled = True
        'stopbtn.Enabled = True
        'fCDLoaded = True
        SendMCIString "seek cd to 1", True
    End If

    ' Update the track time display
    mciSendString "status cd position", s, Len(s), 0
    track = CInt(Mid$(s, 1, 2))
    min = CInt(Mid$(s, 4, 2))
    sec = CInt(Mid$(s, 7, 2))
    'timeWindow.Text = "[" & Format(track, "00") & "] " & Format(min, "00") _
    '        & ":" & Format(sec, "00")
    'tracktime.Caption = "Track time: " & trackLength(track)
    
    ' Check if CD is playing
    mciSendString "status cd mode", s, Len(s), 0
    fPlaying = (Mid$(s, 1, 7) = "playing")
Else
    cdaudio = False
    'eject.Enabled = False
    ' Disable all the controls, clear the display
    'If (fCDLoaded = True) Then
     '   Play.Enabled = False
      '  pause.Enabled = False
       ' ff.Enabled = False
 '       rew.Enabled = False
  '      ftrack.Enabled = False
   '     btrack.Enabled = False
    '    stopbtn.Enabled = False
     '   fCDLoaded = False
      '  fPlaying = False
   '     totalplay.Caption = ""
    '    tracktime.Caption = ""
     '   timeWindow.Text = ""
    'End If
End If
End If
End Sub
' Set the fast-forward speed
Private Sub ffspeedClick()
Dim s As String
s = InputBox("Enter the new speed in seconds", "Fast Forward Speed", CStr(fastForwardSpeed))
If IsNumeric(s) Then
    fastForwardSpeed = CLng(s)
End If
End Sub
