Imports BlogMVVMSample_VB.Data
Imports ClosedXML.Excel
Imports System
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.IO

Namespace Forms.Model

    ''' <summary>Excel読込.Model</summary>
    Public Class ExcelModel

        ''' <summary>選択されたファイル一覧からExcelファイルを取得</summary>
        ''' <param name="selectedPaths">選択されたファイル一覧</param>
        ''' <returns>Excelファイルパス</returns>
        Public Function GetExcelFile(selectedPaths As IList) As String

            For Each obj In selectedPaths

                Dim selectedPath As String = TryCast(obj, String)

                If Not IsNothing(selectedPath) Then

                    Select Case Path.GetExtension(selectedPath).ToUpper()

                        Case ".XLSX", ".XLSM"
                            Return selectedPath

                    End Select

                End If

            Next

            ' 該当なし
            Return ""

        End Function

        ''' <summary>Excelファイル読み込み</summary>
        ''' <param name="fullPath">Excelファイルのフルパス</param>
        ''' <returns>住所一覧</returns>
        ''' <remarks>
        ''' Copyright(c) 2016 ClosedXML
        ''' Released under the MIT license
        ''' https://github.com/ClosedXML/ClosedXML/blob/master/LICENSE
        ''' </remarks>
        Public Function ReadExcelFile(fullPath As String) As ObservableCollection(Of Address)

            Dim collection As New ObservableCollection(Of Address)

            Try

                ' 引数のパスにファイルが存在するか
                If Not File.Exists(fullPath) Then
                    Throw New Exception("ファイルが見つかりません")
                End If

                ' Excelファイルオープン
                Using workbook = New XLWorkbook(fullPath)

                    ' Excelの先頭ワークシートを指定
                    Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                    ' 該当ワークシート内でデータが入力されている最終行
                    Dim lastRow As Integer = worksheet.LastRowUsed().RowNumber()

                    ' 該当ワークシート内でデータが入力されている最終列
                    Dim lastColumn As Integer = worksheet.LastColumnUsed().ColumnNumber()

                    ' 列数が足りているか
                    If lastColumn >= 4 Then

                        ' 最終行まで繰り返す
                        For i As Integer = 1 To lastRow

                            ' 住所一覧に登録
                            ' セル2Aを参照する時はCell(2, 1)と指定
                            collection.Add(New Address() With
                                           {
                                                .PostalCode = worksheet.Cell(i, 1).Value.ToString(),
                                                .Prefectures = worksheet.Cell(i, 2).Value.ToString(),
                                                .City = worksheet.Cell(i, 3).Value.ToString(),
                                                .Place = worksheet.Cell(i, 4).Value.ToString()
                                           })


                        Next

                    End If

                End Using

            Catch ex As Exception

                ' エラー内容を出力
                Debug.WriteLine(ex.Message)

            End Try

            Return collection

        End Function

    End Class

End Namespace