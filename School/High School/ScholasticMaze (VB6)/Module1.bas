Attribute VB_Name = "Module1"
Option Explicit
Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Long, ByVal lpstrBuffer As String, ByVal uLength As Long) As Long
Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long
Declare Function sndPlaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal lpszSoundName As String, ByVal uFlags As Long) As Long
Declare Function waveOutGetNumDevs Lib "winmm" () As Long
Public hofscore$(0 To 9), hofname$(0 To 9), hofcomment$(0 To 9)
Public Sub gethof()
Open CurDir + "\hof.dat" For Input Access Read As #1
Dim a%
For a% = 0 To 9
Line Input #1, hofscore$(a%)
hof.Text1(a%).Text = hofscore$(a%)
Line Input #1, hofname$(a%)
hof.Text2(a%).Text = hofname$(a%)
Line Input #1, hofcomment$(a%)
hof.Text3(a%).Text = hofcomment$(a%)
Next a%
Close #1
End Sub
Public Sub hofbuildform()
Dim a%
For a% = 1 To 9
Load hof.Text1(a%)
hof.Text1(a%).Visible = True
hof.Text1(a%).Left = hof.Text1(0).Left
hof.Text1(a%).Top = hof.Text1(0).Top + a% * hof.Text1(0).Height + 5 * Screen.TwipsPerPixelY * a%
Load hof.Text2(a%)
hof.Text2(a%).Visible = True
hof.Text2(a%).Left = hof.Text2(0).Left
hof.Text2(a%).Top = hof.Text2(0).Top + a% * hof.Text2(0).Height + 5 * Screen.TwipsPerPixelY * a%
Load hof.Text3(a%)
hof.Text3(a%).Visible = True
hof.Text3(a%).Left = hof.Text3(0).Left
hof.Text3(a%).Top = hof.Text3(0).Top + a% * hof.Text3(0).Height + 5 * Screen.TwipsPerPixelY * a%
Next a%

End Sub
Public Sub writehof()
Open CurDir + "\hof.dat" For Output Access Write As #1
Dim a%
For a% = 0 To 9
Print #1, hofscore$(a%)
hof.Text1(a%).Text = hofscore$(a%)
Print #1, hofname$(a%)
hof.Text2(a%).Text = hofname$(a%)
Print #1, hofcomment$(a%)
hof.Text3(a%).Text = hofcomment$(a%)
Next a%
Close #1
End Sub
Public Sub sorthofvars()
Dim a%, bindex%, b%, hstemp$(0 To 9), hntemp$(0 To 9), hctemp$(0 To 9)
bindex% = 0
For b% = 0 To 9
    For a% = 0 To 9
        If CInt(hofscore$(a%)) >= CInt(hofscore$(bindex%)) Then
            bindex% = a%
        End If
    Next a%
    hstemp$(b%) = hofscore$(bindex%)
    hntemp$(b%) = hofname$(bindex%)
    hctemp$(b%) = hofcomment$(bindex%)
    hofscore$(bindex%) = "0"
    hofname$(bindex%) = ""
    hofcomment$(bindex%) = ""
Next b%
For b% = 0 To 9
hofscore$(b%) = hstemp$(b%)
hofname$(b%) = hntemp$(b%)
hofcomment$(b%) = hctemp$(b%)
Next b%
End Sub


Public Sub main()
Form1.Show
End Sub
