﻿Imports System.IO
Imports System.Net

Module Func

    Public Function getMD5Hash(ByVal B As Byte()) As String
        B = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(B)
        Dim str2 As String = ""
        Dim num As Byte
        For Each num In B
            str2 = (str2 & num.ToString("x2"))
        Next
        Return str2
    End Function

    Public Function GetExternalAddress() As String
        Try
            Dim response As WebResponse = WebRequest.Create("http://checkip.dyndns.org/").GetResponse()
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim Str As String = reader.ReadToEnd()
            reader.Dispose()
            response.Close()
            Dim startIndex As Integer = str.IndexOf("Address: ") + 9
            Dim num2 As Integer = str.LastIndexOf("</body>")
            Return str.Substring(startIndex, num2 - startIndex)
        Catch ex As Exception
            Return " "
        End Try
    End Function

    Public Function siz(ByVal Size As String) As String
        If (Size.ToString.Length < 4) Then
            Return (CInt(Size) & " Bytes")
        End If
        Dim str As String = String.Empty
        Dim num As Double = CDbl(Size) / 1024
        If (num < 1024) Then
            str = " KB"
        Else
            num = (num / 1024)
            If (num < 1024) Then
                str = " MB"
            Else
                num = (num / 1024)
                str = " GB"
            End If
        End If
        Return (num.ToString(".0") & str)
    End Function

    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function

    Function fx(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
        Dim a As New List(Of Byte())
        Dim M As New IO.MemoryStream
        Dim MM As New IO.MemoryStream
        Dim T As String() = Split(BS(b), WRD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function

    Function uFolder(ByVal BotID As String, ByVal file As String)
        If Not IO.Directory.Exists("Users" + "\" + BotID.ToString) Then
            IO.Directory.CreateDirectory("Users" + "\" + BotID.ToString)
        End If
        Return "Users" + "\" + BotID.ToString + "\" + file
    End Function

End Module
