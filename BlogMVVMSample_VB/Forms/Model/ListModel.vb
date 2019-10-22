Imports BlogMVVMSample_VB.Data
Imports System
Imports System.Collections.ObjectModel
Imports IO = System.IO
Imports System.Threading.Tasks

Namespace Forms.Model

    ''' <summary>一覧表示Controlsサンプル.Model</summary>
    Public Class ListModel

#Region "ViewModel.Property"

        ''' <summary>パス一覧</summary>
        Public Paths As ObservableCollection(Of PathInfo)

        ''' <summary>パス一覧で選択したパス</summary>
        Public Property SelectedPath As PathInfo
            Get
                Return _SelectedPath
            End Get
            Set(value As PathInfo)
                _SelectedPath = value
                MakeFiles()
            End Set
        End Property

        ''' <summary>選択パス直下のファイル一覧</summary>
        Public Files As ObservableCollection(Of FileInfo)

        ''' <summary>ファイル一覧で選択したファイル</summary>
        Public SelectedFile As FileInfo

#End Region

        ''' <summary>選択したパス</summary>
        Private _SelectedPath As PathInfo

        ''' <summary>一覧表示Controlsサンプル.Model</summary>
        Public Sub New()
            MakeDriveList()
        End Sub

        ''' <summary>ドライブ一覧取得</summary>
        Private Sub MakeDriveList()

            Paths = New ObservableCollection(Of PathInfo)

            Try

                For Each drive As String In Environment.GetLogicalDrives()
                    Paths.Add(New PathInfo(drive))
                Next

            Catch ex As Exception

            End Try

        End Sub

        ''' <summary>選択パス直下のファイル一覧を取得</summary>
        Private Sub MakeFiles()

            If IsNothing(Files) Then
                Files = New ObservableCollection(Of FileInfo)
            Else
                Files.Clear()
            End If

            If IO.Directory.Exists(SelectedPath.FullPath) Then

                Try

                    For Each filePath As String In IO.Directory.EnumerateFiles(SelectedPath.FullPath, "*", System.IO.SearchOption.TopDirectoryOnly)
                        Files.Add(New FileInfo(filePath))
                    Next

                Catch ex As Exception

                End Try

            End If

        End Sub

    End Class

End Namespace