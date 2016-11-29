VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "CCRC32"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"No"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"

' Class       : CCRC32
' Description : This class calculates the 32-bit CRC of a file or string.
' Source      : Total VB SourceBook 6

' Events
' This event is raised during file encryption. The parameter sngPercentage is
' a number between 0 and 1 representing the percentage of the file processed
Public Event Progress(sngPercentage As Single)
Private fso As Scripting.FileSystemObject
' Local variables to hold property values
Private m_strInputFileName As String

' Private class-specific variables
' The table of CRC Values
Private malngCRC32(256) As Long
Dim intLookup As Integer
Public Property Get InputFileName() As String
  ' Returns: the input file name
  ' Source: Total VB SourceBook 6

  InputFileName = m_strInputFileName

End Property

Public Property Let InputFileName(ByVal strValue As String)
  ' strValue: Set the input file name
  ' Source: Total VB SourceBook 6

  m_strInputFileName = strValue

End Property
Private Function ReadFile(ByVal intFile As Integer, ByRef abytBuffer() As Byte, ByVal lngNumberOfBytes As Long) As Long
  ' Comments  : Reads the specified number of bytes from the file.
  ' Parameters: intFile - The file to read from
  '             abytBuffer - The buffer to read the bytes into
  '             lngNumberOfBytes - The number of bytes to read
  ' Returns   : The actual number of bytes read.
  ' Source    : Total VB SourceBook 6
  '
  Dim lngLen As Long
  Dim lngActualBytesRead As Long
  Dim lngStart As Long
    
  'On Error GoTo PROC_ERR
    
  ' Get the starting position of the next read
  lngStart = Loc(intFile) + 1
  ' Get the length of the file
  lngLen = LOF(intFile)

  ' Check to see if there is more data to read from the file
  If lngStart < lngLen Then
    ' Check to see if we are attempting to read past the end of the file
    If lngStart + lngNumberOfBytes < lngLen Then
      lngActualBytesRead = lngNumberOfBytes
    Else
      ' If we are attempting to read more data than is left in the file,
      ' calculate how much data we should read
      lngActualBytesRead = lngLen - (lngStart - 1)
    End If
    
    ' Create the buffer to hold the data
    'ReDim abytBuffer(lngActualBytesRead - 1) As Byte
    ' Do the read
    Get intFile, lngStart, abytBuffer
  Else
    ' If we attempted to read past the end of file, return zero bytes read
    lngActualBytesRead = 0
  End If
  
  ' Return the number of bytes read
  ReadFile = lngActualBytesRead
  
PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ReadFile"
  Resume PROC_EXIT
  
End Function

Private Function UpdateCRC32(ByVal lngCRC As Long, ByVal bytByte As Byte) As Long
  ' Comments  : This procedure calculates the new CRC based on the current CRC
  '             and the byte value
  ' Parameters: lngCRC - The current CRC value
  '             bytByte - The byte value to lookup
  ' Returns   : The calculated cumulative CRC value
  ' Source    : Total VB SourceBook 6
  '
  
  
  'On Error GoTo PROC_ERR
  
  ' Calculate the lookup value
  intLookup = (lngCRC Xor bytByte) And &HFF
  ' Calculate and return the new CRC value
  UpdateCRC32 = (Int(lngCRC / 256) And &HFFFFFF) Xor malngCRC32(intLookup)
  
PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "UpdateCRC32"
  Resume PROC_EXIT
  
End Function
Public Function GetCRCFromFile() As Long
  ' Comments  : This procedure generates a CRC for the file specified in the
  '             InputFile property
  ' Parameters: None
  ' Returns   : The calculated CRC value
  ' Source    : Total VB SourceBook 6
  '
  Dim lngCRC As Long
  Dim abytBuffer() As Byte
  Dim lngCounter As Long
  Dim lngBytesRead As Long
  Dim lngFileLength As Long
  Dim lngTotalBytesRead As Long
  Dim intInputFile As Integer
  Const clngBufferSize As Long = 524288 '&HFFFFFF
  
  On Error GoTo PROC_ERR
    
  ' Construct the CRC table
  'ConstructCRCTable
  
  ' Get the next free file id
  intInputFile = FreeFile
  ' Open the input file
  If Not fso.FileExists(m_strInputFileName) Then Exit Function
  Open m_strInputFileName For Binary Access Read As intInputFile
  ' Get the length of the input file
  lngFileLength = LOF(intInputFile)
  
  lngCRC = &HFFFFFFFF
  
  ' Raise the progress event, none of the file has been processed, so we pass
  ' zero
  RaiseEvent Progress(0)
  ' Read data from the file
  ReDim abytBuffer(clngBufferSize)
  lngBytesRead = ReadFile(intInputFile, abytBuffer, clngBufferSize)
  ' While there is still data in the file
  Do While lngBytesRead > 0
    ' For each byte read
    For lngCounter = 0 To lngBytesRead - 1
      ' Update the CRC
      lngCRC = UpdateCRC32(lngCRC, abytBuffer(lngCounter))
    Next lngCounter
    
    ' Get the total amount of the file that has been processed
    lngTotalBytesRead = lngTotalBytesRead + lngBytesRead
    ' Raise the progress, passing the percentage of the file processed
    RaiseEvent Progress(lngTotalBytesRead / lngFileLength)
    ' Read the next chunk of data from the file
    lngBytesRead = ReadFile(intInputFile, abytBuffer, clngBufferSize)
  Loop
  
  ' Close the input file
  Close intInputFile
  
  ' Return the CRC
  GetCRCFromFile = Not lngCRC

PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetCRCFromFile"
  Resume PROC_EXIT

End Function

Public Function GetCRCFromString(strInput As String) As Long
  ' Comments  : This procedure generates a CRC for the string specified in the
  '             strInput parameter
  ' Parameters: strInput - The string to checksum
  ' Returns   : The calculated CRC value
  ' Source    : Total VB SourceBook 6
  '
  Dim lngCRC As Long
  Dim abytInput() As Byte
  Dim lngCounter As Long
  Dim lngInputLength As Long
  Const cintUpdateBytes As Integer = 4096
  
  On Error GoTo PROC_ERR
  
  abytInput = strInput
  lngInputLength = UBound(abytInput)
  
  ' Construct the CRC table
  'ConstructCRCTable
  
  lngCRC = &HFFFFFFFF
  
  ' Raise the progress event, none of the file has been processed, so we pass
  ' zero
  RaiseEvent Progress(0)
  
  For lngCounter = 0 To lngInputLength
    ' Update the CRC
    lngCRC = UpdateCRC32(lngCRC, abytInput(lngCounter))
    ' Raise the progress event
    If lngCounter Mod cintUpdateBytes Then
      RaiseEvent Progress(lngCounter / lngInputLength)
    End If
  Next lngCounter
  
  ' The string is done being processed
  RaiseEvent Progress(1)
  
  ' Return the CRC
  GetCRCFromString = Not lngCRC

PROC_EXIT:
  Exit Function

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "GetCRCFromString"
  Resume PROC_EXIT

End Function

Private Sub ConstructCRCTable()
  ' Comments  : This procedure fills the CRC table with precalculated Values.
  '             This is more efficient than calculating CRC's on the fly
  ' Parameters: None
  ' Returns   : Nothing
  ' Source    : Total VB SourceBook 6
  '
  On Error GoTo PROC_ERR
    
  ' Fill the table with the precalculate CRC Values.
  malngCRC32(0) = &H0
  malngCRC32(1) = &H77073096
  malngCRC32(2) = &HEE0E612C
  malngCRC32(3) = &H990951BA
  malngCRC32(4) = &H76DC419
  malngCRC32(5) = &H706AF48F
  malngCRC32(6) = &HE963A535
  malngCRC32(7) = &H9E6495A3
  malngCRC32(8) = &HEDB8832
  malngCRC32(9) = &H79DCB8A4
  malngCRC32(10) = &HE0D5E91E
  malngCRC32(11) = &H97D2D988
  malngCRC32(12) = &H9B64C2B
  malngCRC32(13) = &H7EB17CBD
  malngCRC32(14) = &HE7B82D07
  malngCRC32(15) = &H90BF1D91
  malngCRC32(16) = &H1DB71064
  malngCRC32(17) = &H6AB020F2
  malngCRC32(18) = &HF3B97148
  malngCRC32(19) = &H84BE41DE
  malngCRC32(20) = &H1ADAD47D
  malngCRC32(21) = &H6DDDE4EB
  malngCRC32(22) = &HF4D4B551
  malngCRC32(23) = &H83D385C7
  malngCRC32(24) = &H136C9856
  malngCRC32(25) = &H646BA8C0
  malngCRC32(26) = &HFD62F97A
  malngCRC32(27) = &H8A65C9EC
  malngCRC32(28) = &H14015C4F
  malngCRC32(29) = &H63066CD9
  malngCRC32(30) = &HFA0F3D63
  malngCRC32(31) = &H8D080DF5
  malngCRC32(32) = &H3B6E20C8
  malngCRC32(33) = &H4C69105E
  malngCRC32(34) = &HD56041E4
  malngCRC32(35) = &HA2677172
  malngCRC32(36) = &H3C03E4D1
  malngCRC32(37) = &H4B04D447
  malngCRC32(38) = &HD20D85FD
  malngCRC32(39) = &HA50AB56B
  malngCRC32(40) = &H35B5A8FA
  malngCRC32(41) = &H42B2986C
  malngCRC32(42) = &HDBBBC9D6
  malngCRC32(43) = &HACBCF940
  malngCRC32(44) = &H32D86CE3
  malngCRC32(45) = &H45DF5C75
  malngCRC32(46) = &HDCD60DCF
  malngCRC32(47) = &HABD13D59
  malngCRC32(48) = &H26D930AC
  malngCRC32(49) = &H51DE003A
  malngCRC32(50) = &HC8D75180
  malngCRC32(51) = &HBFD06116
  malngCRC32(52) = &H21B4F4B5
  malngCRC32(53) = &H56B3C423
  malngCRC32(54) = &HCFBA9599
  malngCRC32(55) = &HB8BDA50F
  malngCRC32(56) = &H2802B89E
  malngCRC32(57) = &H5F058808
  malngCRC32(58) = &HC60CD9B2
  malngCRC32(59) = &HB10BE924
  malngCRC32(60) = &H2F6F7C87
  malngCRC32(61) = &H58684C11
  malngCRC32(62) = &HC1611DAB
  malngCRC32(63) = &HB6662D3D
  malngCRC32(64) = &H76DC4190
  malngCRC32(65) = &H1DB7106
  malngCRC32(66) = &H98D220BC
  malngCRC32(67) = &HEFD5102A
  malngCRC32(68) = &H71B18589
  malngCRC32(69) = &H6B6B51F
  malngCRC32(70) = &H9FBFE4A5
  malngCRC32(71) = &HE8B8D433
  malngCRC32(72) = &H7807C9A2
  malngCRC32(73) = &HF00F934
  malngCRC32(74) = &H9609A88E
  malngCRC32(75) = &HE10E9818
  malngCRC32(76) = &H7F6A0DBB
  malngCRC32(77) = &H86D3D2D
  malngCRC32(78) = &H91646C97
  malngCRC32(79) = &HE6635C01
  malngCRC32(80) = &H6B6B51F4
  malngCRC32(81) = &H1C6C6162
  malngCRC32(82) = &H856530D8
  malngCRC32(83) = &HF262004E
  malngCRC32(84) = &H6C0695ED
  malngCRC32(85) = &H1B01A57B
  malngCRC32(86) = &H8208F4C1
  malngCRC32(87) = &HF50FC457
  malngCRC32(88) = &H65B0D9C6
  malngCRC32(89) = &H12B7E950
  malngCRC32(90) = &H8BBEB8EA
  malngCRC32(91) = &HFCB9887C
  malngCRC32(92) = &H62DD1DDF
  malngCRC32(93) = &H15DA2D49
  malngCRC32(94) = &H8CD37CF3
  malngCRC32(95) = &HFBD44C65
  malngCRC32(96) = &H4DB26158
  malngCRC32(97) = &H3AB551CE
  malngCRC32(98) = &HA3BC0074
  malngCRC32(99) = &HD4BB30E2
  malngCRC32(100) = &H4ADFA541
  malngCRC32(101) = &H3DD895D7
  malngCRC32(102) = &HA4D1C46D
  malngCRC32(103) = &HD3D6F4FB
  malngCRC32(104) = &H4369E96A
  malngCRC32(105) = &H346ED9FC
  malngCRC32(106) = &HAD678846
  malngCRC32(107) = &HDA60B8D0
  malngCRC32(108) = &H44042D73
  malngCRC32(109) = &H33031DE5
  malngCRC32(110) = &HAA0A4C5F
  malngCRC32(111) = &HDD0D7CC9
  malngCRC32(112) = &H5005713C
  malngCRC32(113) = &H270241AA
  malngCRC32(114) = &HBE0B1010
  malngCRC32(115) = &HC90C2086
  malngCRC32(116) = &H5768B525
  malngCRC32(117) = &H206F85B3
  malngCRC32(118) = &HB966D409
  malngCRC32(119) = &HCE61E49F
  malngCRC32(120) = &H5EDEF90E
  malngCRC32(121) = &H29D9C998
  malngCRC32(122) = &HB0D09822
  malngCRC32(123) = &HC7D7A8B4
  malngCRC32(124) = &H59B33D17
  malngCRC32(125) = &H2EB40D81
  malngCRC32(126) = &HB7BD5C3B
  malngCRC32(127) = &HC0BA6CAD
  malngCRC32(128) = &HEDB88320
  malngCRC32(129) = &H9ABFB3B6
  malngCRC32(130) = &H3B6E20C
  malngCRC32(131) = &H74B1D29A
  malngCRC32(132) = &HEAD54739
  malngCRC32(133) = &H9DD277AF
  malngCRC32(134) = &H4DB2615
  malngCRC32(135) = &H73DC1683
  malngCRC32(136) = &HE3630B12
  malngCRC32(137) = &H94643B84
  malngCRC32(138) = &HD6D6A3E
  malngCRC32(139) = &H7A6A5AA8
  malngCRC32(140) = &HE40ECF0B
  malngCRC32(141) = &H9309FF9D
  malngCRC32(142) = &HA00AE27
  malngCRC32(143) = &H7D079EB1
  malngCRC32(144) = &HF00F9344
  malngCRC32(145) = &H8708A3D2
  malngCRC32(146) = &H1E01F268
  malngCRC32(147) = &H6906C2FE
  malngCRC32(148) = &HF762575D
  malngCRC32(149) = &H806567CB
  malngCRC32(150) = &H196C3671
  malngCRC32(151) = &H6E6B06E7
  malngCRC32(152) = &HFED41B76
  malngCRC32(153) = &H89D32BE0
  malngCRC32(154) = &H10DA7A5A
  malngCRC32(155) = &H67DD4ACC
  malngCRC32(156) = &HF9B9DF6F
  malngCRC32(157) = &H8EBEEFF9
  malngCRC32(158) = &H17B7BE43
  malngCRC32(159) = &H60B08ED5
  malngCRC32(160) = &HD6D6A3E8
  malngCRC32(161) = &HA1D1937E
  malngCRC32(162) = &H38D8C2C4
  malngCRC32(163) = &H4FDFF252
  malngCRC32(164) = &HD1BB67F1
  malngCRC32(165) = &HA6BC5767
  malngCRC32(166) = &H3FB506DD
  malngCRC32(167) = &H48B2364B
  malngCRC32(168) = &HD80D2BDA
  malngCRC32(169) = &HAF0A1B4C
  malngCRC32(170) = &H36034AF6
  malngCRC32(171) = &H41047A60
  malngCRC32(172) = &HDF60EFC3
  malngCRC32(173) = &HA867DF55
  malngCRC32(174) = &H316E8EEF
  malngCRC32(175) = &H4669BE79
  malngCRC32(176) = &HCB61B38C
  malngCRC32(177) = &HBC66831A
  malngCRC32(178) = &H256FD2A0
  malngCRC32(179) = &H5268E236
  malngCRC32(180) = &HCC0C7795
  malngCRC32(181) = &HBB0B4703
  malngCRC32(182) = &H220216B9
  malngCRC32(183) = &H5505262F
  malngCRC32(184) = &HC5BA3BBE
  malngCRC32(185) = &HB2BD0B28
  malngCRC32(186) = &H2BB45A92
  malngCRC32(187) = &H5CB36A04
  malngCRC32(188) = &HC2D7FFA7
  malngCRC32(189) = &HB5D0CF31
  malngCRC32(190) = &H2CD99E8B
  malngCRC32(191) = &H5BDEAE1D
  malngCRC32(192) = &H9B64C2B0
  malngCRC32(193) = &HEC63F226
  malngCRC32(194) = &H756AA39C
  malngCRC32(195) = &H26D930A
  malngCRC32(196) = &H9C0906A9
  malngCRC32(197) = &HEB0E363F
  malngCRC32(198) = &H72076785
  malngCRC32(199) = &H5005713
  malngCRC32(200) = &H95BF4A82
  malngCRC32(201) = &HE2B87A14
  malngCRC32(202) = &H7BB12BAE
  malngCRC32(203) = &HCB61B38
  malngCRC32(204) = &H92D28E9B
  malngCRC32(205) = &HE5D5BE0D
  malngCRC32(206) = &H7CDCEFB7
  malngCRC32(207) = &HBDBDF21
  malngCRC32(208) = &H86D3D2D4
  malngCRC32(209) = &HF1D4E242
  malngCRC32(210) = &H68DDB3F8
  malngCRC32(211) = &H1FDA836E
  malngCRC32(212) = &H81BE16CD
  malngCRC32(213) = &HF6B9265B
  malngCRC32(214) = &H6FB077E1
  malngCRC32(215) = &H18B74777
  malngCRC32(216) = &H88085AE6
  malngCRC32(217) = &HFF0F6A70
  malngCRC32(218) = &H66063BCA
  malngCRC32(219) = &H11010B5C
  malngCRC32(220) = &H8F659EFF
  malngCRC32(221) = &HF862AE69
  malngCRC32(222) = &H616BFFD3
  malngCRC32(223) = &H166CCF45
  malngCRC32(224) = &HA00AE278
  malngCRC32(225) = &HD70DD2EE
  malngCRC32(226) = &H4E048354
  malngCRC32(227) = &H3903B3C2
  malngCRC32(228) = &HA7672661
  malngCRC32(229) = &HD06016F7
  malngCRC32(230) = &H4969474D
  malngCRC32(231) = &H3E6E77DB
  malngCRC32(232) = &HAED16A4A
  malngCRC32(233) = &HD9D65ADC
  malngCRC32(234) = &H40DF0B66
  malngCRC32(235) = &H37D83BF0
  malngCRC32(236) = &HA9BCAE53
  malngCRC32(237) = &HDEBB9EC5
  malngCRC32(238) = &H47B2CF7F
  malngCRC32(239) = &H30B5FFE9
  malngCRC32(240) = &HBDBDF21C
  malngCRC32(241) = &HCABAC28A
  malngCRC32(242) = &H53B39330
  malngCRC32(243) = &H24B4A3A6
  malngCRC32(244) = &HBAD03605
  malngCRC32(245) = &HCDD70693
  malngCRC32(246) = &H54DE5729
  malngCRC32(247) = &H23D967BF
  malngCRC32(248) = &HB3667A2E
  malngCRC32(249) = &HC4614AB8
  malngCRC32(250) = &H5D681B02
  malngCRC32(251) = &H2A6F2B94
  malngCRC32(252) = &HB40BBE37
  malngCRC32(253) = &HC30C8EA1
  malngCRC32(254) = &H5A05DF1B
  malngCRC32(255) = &H2D02EF8D

PROC_EXIT:
  Exit Sub

PROC_ERR:
  MsgBox "Error: " & Err.Number & ". " & Err.Description, , _
    "ConstructCRCTable"
  Resume PROC_EXIT

End Sub



Private Sub Class_Initialize()
ConstructCRCTable
Set fso = New Scripting.FileSystemObject
End Sub
