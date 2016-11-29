VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5760
   ClientLeft      =   60
   ClientTop       =   315
   ClientWidth     =   9300
   LinkTopic       =   "Form1"
   ScaleHeight     =   5760
   ScaleWidth      =   9300
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   375
      Left            =   720
      TabIndex        =   1
      Top             =   360
      Width           =   1095
   End
   Begin VB.ComboBox Combo1 
      Height          =   3495
      Left            =   1080
      Style           =   1  'Simple Combo
      TabIndex        =   0
      Text            =   "Combo1"
      Top             =   1140
      Width           =   5355
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Const NL = 70000
Private Function GenRandomStr(maxlen&) As String
Dim i&, rsng!
For i = 1 To 1 + CLng(Rnd * maxlen)
  rsng = Rnd
  If rsng < 0.3333 Then
  GenRandomStr = GenRandomStr & Chr(65 + CLng(25 * Rnd)) 'capital
  ElseIf rsng < 0.6666 Then
  GenRandomStr = GenRandomStr & Chr(97 + CLng(25 * Rnd)) 'lowercase
  Else
  GenRandomStr = GenRandomStr & Chr(48 + CLng(9 * Rnd)) 'number
  End If
Next i
End Function
Private Sub Command1_Click()
Dim i&, myarr$(), myix&()
ReDim myarr(0 To NL)
ReDim myix(0 To NL)
Randomize
With Combo1
Me.Caption = "filling"
For i = 0 To NL
  myarr(i) = GenRandomStr(10)
  myix(i) = i
    If i Mod 10000 = 0 Then
    Me.Caption = i
    DoEvents
  End If

Next i
Me.Caption = "sorting"
Call QuickSortVariantArray(myarr, myix, 0, NL)
.Visible = False
Me.Caption = "adding"
For i = 0 To NL
  Call .AddItem(myarr(i))
  If i Mod 10000 = 0 Then
    Me.Caption = i
    DoEvents
  End If
Next i
Me.Caption = ""
.Visible = True
End With
End Sub

Public Sub QuickSortVariantArray(avarIn$(), indexarr&(), ByVal intLowBound&, ByVal intHighBound&)
  Dim intX&
  Dim intY&
  Dim varMidBound$
  Dim varTmp$
  Dim varTmp2&
  On Error GoTo PROC_ERR
  ' If there is data to sort
  If intHighBound > intLowBound Then
    ' Calculate the value of the middle array element
    varMidBound = avarIn((intLowBound + intHighBound) \ 2)
    intX = intLowBound
    intY = intHighBound
    ' Split the array into halves
    Do While intX <= intY
      If avarIn(intX) >= varMidBound And avarIn(intY) <= varMidBound Then
        varTmp = avarIn(intX)
        varTmp2 = indexarr(intX)
        avarIn(intX) = avarIn(intY)
        indexarr(intX) = indexarr(intY)
        avarIn(intY) = varTmp
        indexarr(intY) = varTmp2
        intX = intX + 1
        intY = intY - 1
      Else
        If avarIn(intX) < varMidBound Then
          intX = intX + 1
        End If
        If avarIn(intY) > varMidBound Then
          intY = intY - 1
        End If
      End If
    Loop
    ' Sort the lower half of the array
    Call QuickSortVariantArray(avarIn(), indexarr(), intLowBound, intY)
    'Sort the upper half of the array
    Call QuickSortVariantArray(avarIn(), indexarr(), intX, intHighBound)
  End If
  
PROC_EXIT:
  Exit Sub

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "QuickSortVariantArray"
  Resume PROC_EXIT
End Sub


