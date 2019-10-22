Imports System
Imports System.Drawing  ' 参照にSystem.Drawingを追加
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

        ''' <summary>更新日時</summary>
        Public Property LastWriteTime As DateTime

        ''' <summary>ファイルアイコン画像イメージ</summary>
        Public Property BitmapImage As Bitmap

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
                LastWriteTime = fileInfo.LastWriteTime

                Dim icon As Icon = Icon.ExtractAssociatedIcon(fullPath)
                BitmapImage = icon.ToBitmap()

            End If

        End Sub

    End Class

End Namespace