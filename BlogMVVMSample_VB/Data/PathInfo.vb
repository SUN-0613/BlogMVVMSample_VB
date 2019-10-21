Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Threading.Tasks

Namespace Data

    ''' <summary>パス情報</summary>
    Public Class PathInfo

#Region "Property"

        ''' <summary>フルパス</summary>
        Public Property FullPath As String

        ''' <summary>パス名</summary>
        Public Property Name As String

        ''' <summary>子階層</summary>
        Public Property Children As ObservableCollection(Of PathInfo)

#End Region

        ''' <summary>パス情報</summary>
        ''' <param name="fullPath">フルパス</param>
        Public Sub New(fullPath As String)

            Me.FullPath = fullPath

            ' パス名取得
            Name = Path.GetFileName(fullPath)

            ' ドライブ名は上記で取得できないので再設定
            If Name.Length.Equals(0) Then
                Name = fullPath
            End If

            MakeChildren()

        End Sub

        ''' <summary>子階層のパス一覧を取得</summary>
        Private Async Sub MakeChildren()

            Children = New ObservableCollection(Of PathInfo)

            Await Task.Run(
            Sub()

                Try

                    If Directory.Exists(FullPath) Then

                        ' 下位のフォルダ一覧を取得
                        For Each path As String In Directory.EnumerateDirectories(FullPath, "*", SearchOption.TopDirectoryOnly)
                            Children.Add(New PathInfo(path))
                        Next

                        ' 下位のファイル一覧を取得
                        For Each file As String In Directory.EnumerateFiles(FullPath, "*", SearchOption.TopDirectoryOnly)
                            Children.Add(New PathInfo(file))
                        Next

                    End If

                Catch ex As Exception

                End Try

            End Sub)

        End Sub

    End Class

End Namespace