VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Class1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
'-----------------------------------------------------------------------------------------
' Copyright ©1996-2004 VBnet, Randy Birch. All Rights Reserved Worldwide.
'        Terms of use http://vbnet.mvps.org/terms/pages/terms.htm
'-----------------------------------------------------------------------------------------

Private Type SHFILEOPSTRUCT
   hWnd        As Long
   wFunc       As Long
   pFrom       As String
   pTo         As String
   fFlags      As Integer
   fAborted    As Boolean
   hNameMaps   As Long
   sProgress   As String
 End Type
  
'File Operations
Private Const FO_MOVE As Long = &H1
Private Const FO_COPY As Long = &H2
Private Const FO_DELETE As Long = &H3
Private Const FO_RENAME As Long = &H4

'File Operation Flags
Private Const FOF_MULTIDESTFILES As Long = &H1
Private Const FOF_CONFIRMMOUSE As Long = &H2
Private Const FOF_SILENT As Long = &H4              'don't create progress/report
Private Const FOF_RENAMEONCOLLISION As Long = &H8
Private Const FOF_NOCONFIRMATION As Long = &H10     'don't prompt the user.
Private Const FOF_WANTMAPPINGHANDLE As Long = &H20  'Fill in SHFILEOPSTRUCT.hNameMappings
                                                    'Must be freed using SHFreeNameMappings
Private Const FOF_ALLOWUNDO As Long = &H40
Private Const FOF_FILESONLY As Long = &H80          'on *.*, do only files
Private Const FOF_SIMPLEPROGRESS As Long = &H100    'don't show names of files
Private Const FOF_NOCONFIRMMKDIR As Long = &H200    'don't confirm making any needed dirs
Private Const FOF_NOERRORUI As Long = &H400         'don't put up error UI
Private Const FOF_NORECURSION As Long = &H1000      'don't recurse into directories
Private Const FOF_NOCOPYSECURITYATTRIBS As Long = &H800  'don't copy NT file Security Attributes
Private Const FOF_NO_CONNECTED_ELEMENTS As Long = &H2000 'Shell v5+: don't operate on connected file elements
Private Const FOF_WANTNUKEWARNING As Long = &H4000       'Shell v5+: during delete operation, warn if
                                                         'nuking instead of recycling (partially
                                                         'overrides FOF_NOCONFIRMATION)
Private Const FOF_NORECURSEREPARSE As Long = &H8000&  'Shell v5.1+: treat reparse points as
                                                      'objects, not containers
                                                   
Private Declare Function GetTempPath Lib "kernel32" Alias "GetTempPathA" (ByVal nSize As Long, ByVal lpBuffer As String) As Long

Private Declare Function SHFileOperation Lib "shell32" Alias "SHFileOperationA" (lpFileOp As SHFILEOPSTRUCT) As Long

'FO_FUNC is determined by the
'type of SHFileOperation action chosen
'(move/delete/rename/copy)
Dim FO_FUNC As Long
  
'FOF_FLAGS is determined by the
'both the SHFileOperation Actions/Method
'frame and the SHFileOperation Options
'frame choices(delete/recycle/simple
'progress/no confirm etc.)
Dim FOF_FLAGS As Long

'for ease of reading, substitute constants
'for numbers in code SHFileOperationAction
'option button constants
Const FileMove As Long = 1
Const FileCopy As Long = 2
Const FileDelete As Long = 3



Private Sub Option2_Click(Index As Integer)
 
   FO_FUNC = CLng(Index)

End Sub


Private Function GetOptionFlags() As Long
 
  'Iterate through the options,
  'and build the flag variable
  'according to the user selection.
 
  'can only have one of these, so ..
  ' If Option1(0).Value Then GetOptionFlags = FOF_ALLOWUNDO
 
  'these can be multiple
  ' If Check1.Value Then GetOptionFlags = GetOptionFlags Or FOF_SILENT
  ' If Check2.Value Then GetOptionFlags = GetOptionFlags Or FOF_SIMPLEPROGRESS
  ' If Check3.Value Then GetOptionFlags = GetOptionFlags Or FOF_NOCONFIRMATION

End Function




Private Function TrimNull(item As String)

   Dim pos As Long
   
  'double check that there is a
  'vbNullChar (Chr$(0)) in the string
   pos = InStr(item, vbNullChar)
   If pos Then
      TrimNull = Left$(item, pos - 1)
   Else
      TrimNull = item
   End If
  
End Function


Private Sub ShellDelete(sFileArray() As String, sDestination As String)
 
  'Note: sDestination (the pTo member of
  'the SHFILEOPSTRUCT) is ignored for deletion.
  '
  'In addition, a DWORD-alignment problem exists
  'in the shf Type. This means you can not
  'use the shf hNameMaps or sProgress
  'members without significant code changes to
  'assure DWORD alignment is corrected. See the
  'MS KB for information. If you attempt to use
  'these members without following the KB and GPF,
  'this alignment issue is probably the cause.
 
  'working variables
   Dim cnt As Long
   Dim sFiles As String
   Dim shf As SHFILEOPSTRUCT
 
  'create a single string of files from the
  'passed file array, each separated by nulls
   For cnt = LBound(sFileArray) To UBound(sFileArray)
      sFiles = sFiles & sFileArray(cnt) & vbNullChar
   Next

  'add a final null to double-null
  'terminate the string
   sFiles = sFiles & vbNullChar

  'determine the user's options selected
   FOF_FLAGS = GetOptionFlags()
 
  'set up the options
   With shf
     .wFunc = FO_FUNC    'action to take place
     .pFrom = sFiles     'the files to act on
     .pTo = sDestination 'the destination, if not recycle
     .fFlags = FOF_FLAGS 'special flags (FOF_*)
   End With
 
  'and perform the chosen operation
   Call SHFileOperation(shf)

End Sub



