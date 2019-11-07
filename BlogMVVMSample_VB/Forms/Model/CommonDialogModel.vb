Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.IO

Namespace Forms.Model

    ''' <summary>WindowsAPICodePackダイアログ表示.Model</summary>
    Public Class CommonDialogModel

        ''' <summary>ダイアログで取得したファイル一覧をObservableCollection()にセット</summary>
        ''' <param name="files">ダイアログで取得したファイル一覧</param>
        ''' <returns>ObservableCollection()にセットしたファイル一覧</returns>
        Public Function GetFiles(files As IEnumerable(Of String)) As ObservableCollection(Of String)

            Dim values As New ObservableCollection(Of String)

            For Each file In files
                values.Add(file)
            Next

            Return values

        End Function

        ''' <summary>ダイアログで取得したフォルダ直下のファイル一覧をObservableCollection()にセット</summary>
        ''' <param name="folder">ダイアログで取得したフォルダ</param>
        ''' <returns>ObservableCollection()にセットしたファイル一覧</returns>
        Public Function GetFiles(folder As String) As ObservableCollection(Of String)

            Dim values As New ObservableCollection(Of String)

            If Directory.Exists(folder) Then

                Try

                    For Each file In Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly)
                        values.Add(file)
                    Next

                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try

            End If

            Return values

        End Function

        ''' <summary>ダイアログで指定したファイルを空データで作成</summary>
        ''' <param name="filePath">ダイアログで指定したファイル</param>
        Public Sub SaveFile(filePath As String)

            Using fs As FileStream = File.Create(filePath)

            End Using

        End Sub

    End Class

End Namespace