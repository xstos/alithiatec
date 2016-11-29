VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Vertices"
   ClientHeight    =   3195
   ClientLeft      =   15675
   ClientTop       =   3525
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'-
Private Type typUDVertex
    x As Single 'x (according to the screen)
    y As Single 'y (according to the screen)
    z As Single 'normalized z
    rhw As Single 'normalized z rhw (Reciprocol of Homogenous W (whatever that is...))
    color As Long 'vertex's colour
End Type
'-

Dim objDX As DirectX8
Dim objDG As Direct3D8
Dim devDG As Direct3DDevice8

'-
'this stores a list of vertices
Dim bufVertex As Direct3DVertexBuffer8
'-

Dim DGInited As Boolean
Dim ProgramExiting As Boolean

'-
'This constant aids directGraphics in telling what members the Vertex type has
Const fvfUDVertex = (D3DFVF_XYZRHW Or D3DFVF_DIFFUSE)
'-


'---
'Form_Load:
'Loads when the program starts, the purpose of this subroutine
'is to call the initialisation commands and control the rendering
'loop.
'---
Private Sub Form_Load()
    '-
    'We use this variable to get the size of just one instance of a vertex
    Dim tempVertex As typUDVertex
    'This variable is where we'll store the lengs of it.
    Dim VertexSize As Long
    
    'and this is where we actually do the calculation
    VertexSize = Len(tempVertex)
    '-
    
    Me.Show
    Me.Caption = "Vertices: Initialising"
    Set objDX = New DirectX8
    
    DGInited = D3DInit()
    If DGInited = False Then
        MsgBox ("Critical Failure initialising DirectXGraphics")
        End
    End If
    
    '-
    'Call the Vertex Buffer init function and store it's success in a boolean
    DGInited = VBInit()
    'If the initialisation failed, then end the program with an error message
    If DGInited = False Then
        MsgBox ("Critical Failure initialising Vertex Buffer")
        End
    End If
    '-
    
    Me.Caption = "Vertices"
    
    Do
        Call devDG.Clear(0, ByVal 0, D3DCLEAR_TARGET, &HFF000020, 1#, 0)

        devDG.BeginScene
            '-
            'Tells the DG Device where it's going to get it's vertex data from
            Call devDG.SetStreamSource(0, bufVertex, VertexSize)
            'Tells the DirectXGraphics device how the vertex type is structured according
            'to the constrant we defined above
            Call devDG.SetVertexShader(fvfUDVertex)
            'Renders the vertex buffer as a triangle list to the backbuffer
            Call devDG.DrawPrimitive(D3DPT_TRIANGLELIST, 0, 1)
            '-
        devDG.EndScene
        
        Call devDG.Present(ByVal 0, ByVal 0, 0, ByVal 0)
        
        DoEvents
    Loop Until ProgramExiting = True
    End
End Sub

'---
'D3DInit:
'Initialises DirectGraphics
'---
Function D3DInit() As Boolean
    Dim udtCurrentMode As D3DDISPLAYMODE
    Dim udtPParam As D3DPRESENT_PARAMETERS
    On Error GoTo ErrorCheck

    Set objDG = objDX.Direct3DCreate

    Call objDG.GetAdapterDisplayMode(D3DADAPTER_DEFAULT, udtCurrentMode)

    With udtPParam
        .Windowed = 1
        .SwapEffect = D3DSWAPEFFECT_COPY_VSYNC
        .BackBufferFormat = udtCurrentMode.Format
    End With
    
    Set devDG = objDG.CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hWnd, D3DCREATE_SOFTWARE_VERTEXPROCESSING, udtPParam)
    If devDG Is Nothing Then GoTo ErrorCheck

    D3DInit = True
    Exit Function

ErrorCheck:
    D3DInit = False
End Function

'-
Function VBInit()
    'if an error occurs, go to the ErrorCheck and report an Init failure
    On Error GoTo ErrorCheck
    'A user defined type which will store our vertices until they're placed in the
    'vertex buffer
    Dim Vertices(2) As typUDVertex
    'A temporary variable to store the size of the vertex list
    Dim VertexSize As Long
    
    'Caculates the size of the entire array in bytes
    VertexSize = Len(Vertices(0))
    
    'creates a vertex at 150, 50, halfway between the foreground and background, with a
    'normal pointing towards you and colour Blue
    Vertices(0) = CreateVertex(150, 50, 0.5, 1, &HFF0000FF)
    'creates a vertex at 250, 250, halfway between the foreground and background, with a
    'normal pointing towards you and colour Pink
    Vertices(1) = CreateVertex(250, 250, 0.5, 1, &H80FF8080)
    'creates a triangle at 50, 250, halfway between the foreground and background, with a
    'normal pointing towards you and colour Green
    Vertices(2) = CreateVertex(50, 250, 0.5, 1, &HFF00FF00)
    
    'creates the vertex buffer, giving it the format of the flexible vertex format using
    'default memory allocation
    Set bufVertex = devDG.CreateVertexBuffer(VertexSize * 3, 0, fvfUDVertex, D3DPOOL_DEFAULT)
    
    'places the vertices into the Vertex Buffer (bufVertex)
    Call D3DVertexBuffer8SetData(bufVertex, 0, VertexSize * 3, 0, Vertices(0))
    
    'if no errors have occures thus far, then set the function to true (Success)
    VBInit = True
    'and exit the function
    Exit Function

ErrorCheck:
    'if the program reaches here, then something stuffed up, so set the function to
    'false (Failure) and exit
    VBInit = False
End Function
'-

'-
'---
'CreateVertex
'this function just simplifies putting the information
'into a vertex. I find this better than using a long with statement
'---

Private Function CreateVertex(x, y, z, rhw, colour) As typUDVertex
    'place all the corresponding values into their correct placeholders
    With CreateVertex
        .x = x
        .y = y
        .z = z
        .rhw = rhw
        .color = colour
    End With
End Function
'-

'---
'Form_Unload:
'Destroys objects to avoid memory leaks
'---
Private Sub Form_Unload(Cancel As Integer)
    '-
    'destroy the vertex buffer
    Set bufVertex = Nothing
    '-
    Set devDG = Nothing
    Set objDG = Nothing
    ProgramExiting = True
End Sub

