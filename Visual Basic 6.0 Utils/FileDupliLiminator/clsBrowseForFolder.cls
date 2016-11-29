VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsBrowseForFolder"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Copyright ©1996-2004 VBnet, Randy Birch, All Rights Reserved.
' Some pages may also contain other copyrights by the author.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Distribution: You can freely use this code in your own
'               applications, but you may not reproduce
'               or publish this code on any web site,
'               online service, or distribute as source
'               on any media without express permission.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Type BROWSEINFO
   hOwner           As Long
   pidlRoot         As Long
   pszDisplayName   As String
   lpszTitle        As String
   ulFlags          As Long
   lpfn             As Long
   lParam           As Long
   iImage           As Long
End Type

Private Const BIF_RETURNONLYFSDIRS = &H1
Private Const BIF_DONTGOBELOWDOMAIN = &H2
Private Const BIF_STATUSTEXT = &H4
Private Const BIF_RETURNFSANCESTORS = &H8
Private Const BIF_BROWSEFORCOMPUTER = &H1000
Private Const BIF_BROWSEFORPRINTER = &H2000
Private Const MAX_PATH = 260

Private Declare Function SHGetPathFromIDList Lib "shell32" _
   Alias "SHGetPathFromIDListA" _
  (ByVal pidl As Long, _
   ByVal pszPath As String) As Long

Private Declare Function SHBrowseForFolder Lib "shell32" _
   Alias "SHBrowseForFolderA" _
  (lpBrowseInfo As BROWSEINFO) As Long

Private Declare Sub CoTaskMemFree Lib "ole32" _
   (ByVal pv As Long)


Public FilePath As String
Public Sub ShowBrowser(hWnd&, Title$)

  Dim bi As BROWSEINFO
  Dim pidl As Long
  Dim path As String
  Dim pos As Long

 'Fill the BROWSEINFO structure with the
 'needed data. To accommodate comments, the
 'With/End With syntax has not been used, though
 'it should be your 'final' version.

   With bi
      
     'hwnd of the window that receives messages
     'from the call. Can be your application
     'or the handle from GetDesktopWindow()
      .hOwner = hWnd

     'pointer to the item identifier list specifying
     'the location of the "root" folder to browse from.
     'If NULL, the desktop folder is used.
     .pidlRoot = 0&

     'message to be displayed in the Browse dialog
     .lpszTitle = Title

     'the type of folder to return.
      .ulFlags = BIF_RETURNONLYFSDIRS
   End With
    
  'show the browse for folders dialog
   pidl = SHBrowseForFolder(bi)
 
  'the dialog has closed, so parse & display the
  'user's returned folder selection contained in pidl
   path = Space$(MAX_PATH)
    
   If SHGetPathFromIDList(ByVal pidl, ByVal path) Then
      pos = InStr(path, Chr$(0))
      FilePath = Left(path, pos - 1)
   End If

   Call CoTaskMemFree(pidl)
  
End Sub




