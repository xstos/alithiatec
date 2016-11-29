VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Chrispad 
   Caption         =   "Form1"
   ClientHeight    =   7215
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   9825
   LinkTopic       =   "Form1"
   ScaleHeight     =   7215
   ScaleWidth      =   9825
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "Fixedsys"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3495
      Left            =   1080
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   0
      ToolTipText     =   "Type Stuff Here"
      Top             =   720
      Width           =   4455
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   7680
      Top             =   4920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Menu mFile 
      Caption         =   "File"
      Begin VB.Menu mOpen 
         Caption         =   "Open"
      End
      Begin VB.Menu mSave 
         Caption         =   "Save"
      End
      Begin VB.Menu mSaveAs 
         Caption         =   "SaveAs"
      End
      Begin VB.Menu mClose 
         Caption         =   "Close"
      End
      Begin VB.Menu mQuit 
         Caption         =   "Quit"
      End
   End
   Begin VB.Menu mEdit 
      Caption         =   "Edit"
      Begin VB.Menu mFont 
         Caption         =   "Font"
      End
   End
End
Attribute VB_Name = "Chrispad"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim currentfile As String

Private Sub Form_Resize()
Text1.Top = Me.ScaleTop
Text1.Left = Me.ScaleLeft
Text1.Width = Me.ScaleWidth
Text1.Height = Me.ScaleHeight
End Sub

Private Sub mClose_Click()
Text1.Text = ""
End Sub

Private Sub mFont_Click()
    ' Set Cancel to True
    CommonDialog1.CancelError = True
    On Error GoTo ErrHandler
    ' Set the Flags property
    CommonDialog1.Flags = cdlCFEffects Or cdlCFBoth
    ' Display the Font dialog box
    CommonDialog1.ShowFont
    Text1.Font.Name = CommonDialog1.FontName
    Text1.Font.Size = CommonDialog1.FontSize
    Text1.Font.Bold = CommonDialog1.FontBold
    Text1.Font.Italic = CommonDialog1.FontItalic
    Text1.Font.Underline = CommonDialog1.FontUnderline

    Text1.FontStrikethru = CommonDialog1.FontStrikethru
    Text1.ForeColor = CommonDialog1.Color
    Exit Sub
ErrHandler:
    ' User pressed the Cancel button
    Exit Sub

End Sub

Private Sub mOpen_Click()
    ' Set CancelError is True
    CommonDialog1.CancelError = True
    On Error GoTo ErrHandler
    ' Set flags
    CommonDialog1.Flags = cdlOFNHideReadOnly
    ' Set filters
    CommonDialog1.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt|Batch Files (*.bat)|*.bat"
    ' Specify default filter
    CommonDialog1.FilterIndex = 0
    ' Display the Open dialog box
    CommonDialog1.ShowOpen
    ' Display name of selected file
    currentfile = CommonDialog1.FileName
    Open CommonDialog1.FileName For Input Access Read As #1
    Do
    Line Input #1, a
    Text1.Text = Text1.Text & a & Chr(13) & Chr(10)
    Loop Until EOF(1)
    Close #1
    Exit Sub
    
ErrHandler:
    'User pressed the Cancel button
    Exit Sub

End Sub

Private Sub mSave_Click()
Open currentfile For Output Access Write Lock Write As #1
Print #1, Text1.Text
Close #1
End Sub

Private Sub mSaveAs_Click()
    ' Set CancelError is True
    CommonDialog1.CancelError = True
    On Error GoTo ErrHandler
    ' Set flags
    CommonDialog1.Flags = cdlOFNHideReadOnly
    ' Set filters
    CommonDialog1.Filter = "All Files (*.*)|*.*|"
    ' Specify default filter
    CommonDialog1.FilterIndex = 0
    ' Display the Open dialog box
    CommonDialog1.ShowSave
    ' Display name of selected file
    Open CommonDialog1.FileName For Output Access Write Lock Write As #1
    Print #1, Text1.Text
    Close #1
    Exit Sub
    
ErrHandler:
    'User pressed the Cancel button
    Exit Sub


End Sub
