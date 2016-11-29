VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Form1"
   ClientHeight    =   3045
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4260
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3045
   ScaleWidth      =   4260
   StartUpPosition =   2  'CenterScreen
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'----------------------------------------------------------------------
' Visual Basic Game Programming With DirectX
' Chapter 14 : DirectX Graphics and Direct3D
' Triangle3D Source Code File
'----------------------------------------------------------------------

Option Explicit
Option Base 0

'Windows API functions and structures
Private Declare Function GetTickCount Lib "kernel32" () As Long

'colors
Const C_WHITE As Long = &HFFFFFF
Const C_GRAY As Long = &H111111
Const C_RED As Long = &HFF0000
Const C_GREEN As Long = &H1FF00
Const C_BLUE As Long = &H1FF
Const C_BLACK As Long = &H0

'custom flexible vertex format for textured polygons
Const D3DFVF_MYVERTEX = (D3DFVF_XYZ Or D3DFVF_DIFFUSE)

Const PI = 3.141592654

'custom vertex type representing a point on the screen
Private Type VERTEX_TYPE
    x As Single
    y As Single
    z  As Single
    Color As Long
End Type

Private Type TRIANGLE_TYPE
    v1 As VERTEX_TYPE
    v2 As VERTEX_TYPE
    v3 As VERTEX_TYPE
End Type

Dim bRunning As Boolean
Dim lFrameRate As Long
Dim sFrameRate As String

Dim dx As New DirectX8
Dim d3d As Direct3D8
Dim d3dDevice As Direct3DDevice8

Dim d3dx As D3DX8

Dim poly1 As TRIANGLE_TYPE
Dim poly1_vb As Direct3DVertexBuffer8

Dim matProj As D3DMATRIX
Dim matWorld As D3DMATRIX
Dim matView As D3DMATRIX
Dim vecCameraSource As D3DVECTOR
Dim vecCameraTarget As D3DVECTOR

Dim matRotateX As D3DMATRIX
Dim matRotateY As D3DMATRIX
Dim fRotateX As Single
Dim fRotateY As Single


Private Sub Form_Load()
    Static lStartTime As Long
    Static lCounter As Long
    Static lNewTime As Long
    
    'set up the main form
    Form1.Caption = "Triangle3D"
    Form1.AutoRedraw = False
    Form1.BorderStyle = 1
    Form1.ClipControls = False
    Form1.KeyPreview = True
    Form1.ScaleMode = 3
    Form1.Width = Screen.TwipsPerPixelX * 652
    Form1.Height = Screen.TwipsPerPixelY * 510
    Form1.Show
    
    ' Initialize D3D and D3DDevice
    If Not InitD3D(Me.hWnd) Then
        MsgBox "Error initializing Direct3D"
        Shutdown
    End If
    
    ' Initialize Vertex Buffer
    If Not SetupScene() Then
        MsgBox "Error initializing vertex buffer"
        Shutdown
    End If
    
    bRunning = True
    lFrameRate = 60
    
    'main game loop
    Do While bRunning
        lCounter = GetTickCount() - lStartTime
        If lCounter > lNewTime Then
            RenderScene lCounter
            lNewTime = lCounter + 1000 / lFrameRate
        End If
        DoEvents
    Loop
    
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print KeyCode
    Select Case KeyCode
        Case 38
            vecCameraSource.z = vecCameraSource.z - 1
            D3DXMatrixLookAtLH matView, vecCameraSource, _
                vecCameraTarget, CreateVector(0, 1, 0)
            d3dDevice.SetTransform D3DTS_VIEW, matView
        Case 40
            vecCameraSource.z = vecCameraSource.z + 1
            D3DXMatrixLookAtLH matView, vecCameraSource, _
                vecCameraTarget, CreateVector(0, 1, 0)
            d3dDevice.SetTransform D3DTS_VIEW, matView
        Case 27
            Shutdown
    End Select
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Shutdown
End Sub

Private Sub Shutdown()
    Set poly1_vb = Nothing
    Set d3dx = Nothing
    Set d3dDevice = Nothing
    Set d3d = Nothing
    Set dx = Nothing
    End
End Sub

Function InitD3D(hWnd As Long) As Boolean
    On Local Error Resume Next

    ' Create the D3D object
    Set d3d = dx.Direct3DCreate()
    If d3d Is Nothing Then Exit Function

    Set d3dx = New D3DX8
    If d3dx Is Nothing Then Exit Function

    ' Get the current display mode
    Dim mode As D3DDISPLAYMODE
    d3d.GetAdapterDisplayMode D3DADAPTER_DEFAULT, mode

    ' Fill in the type structure used to create the device
    Dim d3dpp As D3DPRESENT_PARAMETERS
    d3dpp.hDeviceWindow = Form1.hWnd
    d3dpp.Windowed = 1
    d3dpp.BackBufferWidth = Form1.ScaleWidth
    d3dpp.BackBufferHeight = Form1.ScaleHeight
    d3dpp.BackBufferFormat = mode.Format
    d3dpp.BackBufferCount = 1
    d3dpp.SwapEffect = D3DSWAPEFFECT_COPY_VSYNC
    d3dpp.MultiSampleType = D3DMULTISAMPLE_NONE
    d3dpp.AutoDepthStencilFormat = D3DFMT_D32

    Set d3dDevice = d3d.CreateDevice(D3DADAPTER_DEFAULT, _
        D3DDEVTYPE_HAL, Form1.hWnd, _
        D3DCREATE_SOFTWARE_VERTEXPROCESSING, d3dpp)
    If d3dDevice Is Nothing Then
        MsgBox "Error creating Direct3D device"
        Shutdown
    End If

    'turn on ambient lighting
    d3dDevice.SetRenderState D3DRS_AMBIENT, True
    'turn off z-buffering
    d3dDevice.SetRenderState D3DRS_ZENABLE, False
    'turn off backface removal
    d3dDevice.SetRenderState D3DRS_CULLMODE, D3DCULL_NONE
    'turn off hardware lighting
    d3dDevice.SetRenderState D3DRS_LIGHTING, False

    InitD3D = True
End Function

Function SetupScene() As Boolean
    vecCameraSource.x = 0
    vecCameraSource.y = 0
    vecCameraSource.z = 5
    
    vecCameraTarget.x = 0
    vecCameraTarget.y = 0
    vecCameraTarget.z = 0
    
    'set up the camera view matrix
    D3DXMatrixLookAtLH matView, vecCameraSource, vecCameraTarget, _
        CreateVector(0, 1, 0)
    'use the camera view for the viewport
    d3dDevice.SetTransform D3DTS_VIEW, matView
    
    'set up the projection matrix (pi/4 = radians)
    D3DXMatrixPerspectiveFovLH matProj, PI / 4, 1, 1, 100
    'tell device to use the projection matrix
    d3dDevice.SetTransform D3DTS_PROJECTION, matProj
    'set vertex shader
    d3dDevice.SetVertexShader D3DFVF_MYVERTEX
    
    'set up poly1
    poly1.v1 = CreateVertex(-1, -1, 0, C_BLUE)
    poly1.v2 = CreateVertex(1, -1, 0, C_GREEN)
    poly1.v3 = CreateVertex(-1, 1, 0, C_GREEN)
    
    'create vertex buffer for poly1
    Set poly1_vb = d3dDevice.CreateVertexBuffer(Len(poly1), 0, _
        D3DFVF_MYVERTEX, D3DPOOL_DEFAULT)
    If poly1_vb Is Nothing Then Exit Function
    D3DVertexBuffer8SetData poly1_vb, 0, Len(poly1), 0, poly1
    
    SetupScene = True
End Function

Public Sub RenderScene(ByVal MS As Long)
    Static lTimer As Long
    Static lStart As Long
    Static lCounter As Long
    Static fTheta As Single

    'start counting milliseconds
    lStart = GetTickCount
    If d3dDevice Is Nothing Then Exit Sub

    'clear the back buffer
    d3dDevice.Clear 0, ByVal 0, D3DCLEAR_TARGET, C_BLACK, 1#, 0
    
    'begin rendering
    d3dDevice.BeginScene
    
    'rotate the triangle
    fTheta = fTheta + PI / 40
    D3DXMatrixRotationX matRotateX, fTheta / 2
    D3DXMatrixRotationY matRotateY, fTheta
    D3DXMatrixMultiply matWorld, matRotateX, matRotateY
    d3dDevice.SetTransform D3DTS_WORLD, matWorld
    
    'set source vertex buffer and draw the triangle
    d3dDevice.SetStreamSource 0, poly1_vb, Len(poly1.v1)
    d3dDevice.DrawPrimitive D3DPT_TRIANGLELIST, 0, 1
    
    'stop rendering
    d3dDevice.EndScene
    
    'copy the back buffer to the screen
    d3dDevice.Present ByVal 0, ByVal 0, 0, ByVal 0
    
    'count the frames per second
    If MS > lTimer + 1000 Then
        lStart = GetTickCount - lStart
        sFrameRate = "FPS = " & lCounter & ", MS = " & lStart
        Debug.Print sFrameRate
        lTimer = MS
        lCounter = 0
    Else
        lCounter = lCounter + 1
    End If
End Sub

Private Function CreateVertex(ByVal x As Single, _
    ByVal y As Single, ByVal z As Single, _
    ByVal Color As Long) As VERTEX_TYPE
    CreateVertex.x = x
    CreateVertex.y = y
    CreateVertex.z = z
    CreateVertex.Color = Color
End Function

Function CreateVector(x As Single, y As Single, z As Single) As D3DVECTOR
    CreateVector.x = x
    CreateVector.y = y
    CreateVector.z = z
End Function


