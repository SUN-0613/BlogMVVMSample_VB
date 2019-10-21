Imports System
Imports IO = System.IO
Imports System.Windows

Namespace Data

    ''' <summary>ファイル情報</summary>
    Public Class FileInfo

#Region "Property"

        ''' <summary>ファイル名</summary>
        Public Property Name As String

        ''' <summary>ファイルサイズ</summary>
        Public Property Size As Long

        ''' <summary>作成日時</summary>
        Public Property CreationTime As DateTime

#End Region

        ''' <summary>フルパス</summary>
        Private _FullPath As String

        ''' <summary>ファイル情報</summary>
        ''' <param name="fullPath">フルパス</param>
        Public Sub New(fullPath As String)

            _FullPath = fullPath

            If IO.File.Exists(fullPath) Then

                Dim fileInfo As IO.FileInfo = New IO.FileInfo(fullPath)

                Name = fileInfo.Name
                Size = fileInfo.Length
                CreationTime = fileInfo.CreationTime

            End If

        End Sub

    End Class

End Namespace