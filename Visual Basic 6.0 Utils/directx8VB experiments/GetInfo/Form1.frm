VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "GetInfo"
   ClientHeight    =   4935
   ClientLeft      =   555
   ClientTop       =   675
   ClientWidth     =   6120
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   329
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   408
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox Text1 
      Height          =   4815
      Left            =   60
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   0
      Top             =   60
      Width           =   5955
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'======================================================================
' Visual Basic Game Programming With DirectX
' Chapter 6 : Supercharging Visual Basic With DirectX
' GetInfo Program Source Code
'======================================================================

Option Explicit
Option Base 0

'DirectX object
Dim DX As DirectX7

'DirectDraw object
Dim DD As DirectDraw7

'surface description type
Dim ddsd As DDSURFACEDESC2

'DirectDraw identification object
Dim ddi As DirectDrawIdentifier

'DirectDraw device enumeration object
Dim DDEnum As DirectDrawEnum

'DirectDraw capabilities structure
Dim ddsCaps As DDSCAPS2

'global variables
Dim r1 As RECT
Dim n As Long

'======================================================================
' Form_Load
' Main startup routine for the program
'======================================================================
Private Sub Form_Load()
    On Error GoTo error1

    'create the DirectX object
    Set DX = New DirectX7

    'create the DirectDraw object
    Set DD = DX.DirectDrawCreate("")

    'normal windowed program with current display settings
    DD.SetCooperativeLevel Me.hWnd, DDSCL_NORMAL

    'retrieve video card driver information
    Set ddi = DD.GetDeviceIdentifier(DDGDI_DEFAULT)
    PrintText "Video card : " & ddi.GetDescription
    PrintText "Driver : " & ddi.GetDriver
    PrintText "Major version : " & ddi.GetDriverVersion
    PrintText "Minor version : " & ddi.GetDriverSubVersion
    Set ddi = Nothing
    
    'retrieve the first display device
    Set DDEnum = DX.GetDDEnum()
    PrintText "Display device = " & DDEnum.GetDescription(1)
    Set DDEnum = Nothing

    'display amount of free video memory
    PrintText "Video memory = " & DD.GetFreeMem(ddsCaps)
    
    'retrieve information about the display mode
    DD.GetDisplayMode ddsd
    PrintText "Resolution : " & ddsd.lWidth & "x" & ddsd.lHeight
    PrintText "Color depth : " & ddsd.ddpfPixelFormat.lRGBBitCount
    PrintText "Pitch : " & ddsd.lPitch
    
    'delete some objects
    Set DD = Nothing
    Set DX = Nothing
    
    Exit Sub
error1:
    MsgBox "Error " & Err.Number & ": " & Err.Description, _
        vbOKOnly + vbExclamation, "GetInfo"
End Sub

'======================================================================
' PrintText
' Add a line of text to the next line of the TextBox
'======================================================================
Private Sub PrintText(ByVal msg As String)
    Text1.Text = Text1.Text & msg & vbCrLf
End Sub


