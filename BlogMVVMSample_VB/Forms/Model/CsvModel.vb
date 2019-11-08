Imports BlogMVVMSample_VB.CustomClass
Imports BlogMVVMSample_VB.Data
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Namespace Forms.Model

    ''' <summary>CSVを読み込みDataGridに表示.Model</summary>
    Public Class CsvModel

        ''' <summary>選択されたファイル一覧からCSVファイルを取得</summary>
        ''' <param name="selectedPaths">選択されたファイル一覧</param>
        ''' <returns>CSVファイルパス</returns>
        Public Function GetCsvFile(selectedPaths As IList) As String

            For Each obj In selectedPaths

                Dim selectedPath As String = TryCast(obj, String)

                If Not IsNothing(selectedPath) _
                    AndAlso Path.GetExtension(selectedPath).ToUpper().Equals(".CSV") Then

                    Return selectedPath

                End If

            Next

            Return ""

        End Function

        ''' <summary>CSVファイル読み込み</summary>
        ''' <param name="fullPath">CSVファイルのフルパス</param>
        ''' <returns>住所一覧</returns>
        Public Function ReadCsvFile(fullPath As String) As ObservableCollection(Of Address)

            Dim collection As New ObservableCollection(Of Address)

            Try

                ' 引数のパスにファイルが存在すうｒか
                If Not File.Exists(fullPath) Then
                    Throw New FileNotFoundException("ファイルが見つかりません")
                End If

                ' 行データをカンマ区切りで分割するようにファイルオープン
                Using parser As New TextFieldParser(fullPath, Encoding.Default) With {.Delimiters = New String() {","}}

                    ' 最終行まで繰り返す
                    While Not parser.EndOfData

                        ' 文字列中の前後スペースを削除しない
                        parser.TrimWhiteSpace = False

                        ' カンマで分割した文字列の配列を取得
                        Dim cells As String() = parser.ReadFields()

                        ' 住所一覧に登録
                        collection.Add(New Address() With
                                       {
                                            .PostalCode = cells(0),
                                            .Prefectures = cells(1),
                                            .City = cells(2),
                                            .Place = cells(3)
                                       })

                    End While

                End Using

            Catch ex As Exception

                ' エラー内容を出力
                Debug.WriteLine(ex.Message)

            End Try

            Return collection

        End Function

        ''' <summary>住所一覧をCSVファイルに保存</summary>
        ''' <param name="fullPath">保存するCSVファイルパス</param>
        ''' <param name="addresses">住所一覧</param>
        Public Sub SaveCsvFile(fullPath As String, addresses As ObservableCollection(Of Address))

            ' 指定パスのファイルを上書保存
            Using writer As New StreamWriter(fullPath, False, Encoding.Default)

                ' 作成したDispose()を実装したStringBuilderを使用
                Using row As New DisposableStringBuilder(128)

                    For Each address In addresses

                        With address

                            ' 出力する行データの作成
                            row.Clear() _
                            .Append(AddDoubleQuotation(.PostalCode)).Append(",") _
                            .Append(AddDoubleQuotation(.Prefectures)).Append(",") _
                            .Append(AddDoubleQuotation(.City)).Append(",") _
                            .Append(AddDoubleQuotation(.Place))

                            ' 行データをCSVファイルに出力
                            writer.WriteLine(row.ToString())

                        End With

                    Next

                End Using

            End Using

        End Sub

        ''' <summary>文字列をダブルクオーテーションで囲む</summary>
        ''' <param name="value">文字列</param>
        ''' <returns>ダブルクオーテーションで囲んだ文字列</returns>
        Private Function AddDoubleQuotation(value As String) As String
            Return """" & value & """"
        End Function

    End Class

End Namespace