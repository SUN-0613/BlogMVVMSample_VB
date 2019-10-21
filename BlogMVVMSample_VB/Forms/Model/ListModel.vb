Imports BlogMVVMSample_VB.Data
Imports System
Imports System.Collections.ObjectModel
Imports System.Threading.Tasks

Namespace Forms.Model

    ''' <summary>一覧表示Controlsサンプル.Model</summary>
    Public Class ListModel

#Region "ViewModel.Property"

        ''' <summary>パス一覧</summary>
        Public Paths As ObservableCollection(Of PathInfo)

#End Region

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

    End Class

End Namespace