Imports BlogMVVMSample_VB.CustomClass
Imports BlogMVVMSample_VB.Data
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Diagnostics

Namespace Forms.Model

    ''' <summary>SQL Serverクラス使用サンプル.Model</summary>
    Public Class SqlServerModel

        ''' <summary>データベース情報一覧の取得</summary>
        ''' <returns>データベース情報一覧</returns>
        Public Function GetDataBaseInfo() As ObservableCollection(Of DataBaseInfo)

            Try

                ' 戻り値の宣言
                Dim values = New ObservableCollection(Of DataBaseInfo)

                ' Windows認証でDB接続
                Using sqlServer As New SqlServer(MySettings.Default.ServerName, MySettings.Default.DbName)

                    ' 接続エラー確認
                    If sqlServer.IsError Then
                        Throw New Exception(sqlServer.ExceptionMessage)
                    End If

                    ' クエリを保存するStringBuilderの宣言
                    Using query As New DisposableStringBuilder()

                        ' データベース一覧取得クエリの作成
                        query.Append("SELECT name FROM sys.databases ORDER BY database_id")

                        ' クエリを実行してSystem.Data.SqlClient.SqlDataReaderで取得
                        Using dataReader = sqlServer.ExecuteQuery(query.ToString())

                            ' 実行エラー確認
                            If sqlServer.IsError Then
                                Throw New Exception(sqlServer.ExceptionMessage)
                            End If

                            ' データ呼び出し
                            While dataReader.Read()
                                values.Add(New DataBaseInfo() With {.Name = dataReader.GetString(0)})
                            End While

                        End Using

                        ' パラメータの宣言
                        Dim parameter As New Dictionary(Of String, Object) From
                        {
                            {"@Type", "U"}
                        }

                        ' データベース毎にテーブル一覧を取得
                        For i As Integer = 0 To values.Count - 1

                            ' テーブル一覧を取得するクエリの作成
                            ' ユーザテーブルのみを対象とする
                            query.Clear()
                            query.Append("USE ").Append(values(i).Name)
                            query.Append(" SELECT name FROM sys.objects WHERE type = @Type")

                            ' クエリを実行してSystem.Data.SqlClient.SqlDataReaderで取得
                            Using dataReader = sqlServer.ExecuteQuery(query.ToString(), parameter)

                                ' 実行エラー確認
                                If sqlServer.IsError Then
                                    Throw New Exception(sqlServer.ExceptionMessage)
                                End If

                                ' データ呼び出し
                                While dataReader.Read()

                                    values(i).Tables.Add(New DataBaseInfo() With
                                                         {
                                                            .Name = dataReader.GetString(0),
                                                            .ParentName = values(i).Name
                                                         })

                                End While

                            End Using

                        Next

                        Return values

                    End Using

                End Using

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

            Return Nothing

        End Function

        ''' <summary>指定テーブルのレコードを取得</summary>
        ''' <param name="tableInfo">テーブル情報</param>
        ''' <returns>テーブルレコード</returns>
        Public Function GetTableRecord(tableInfo As DataBaseInfo) As DataTable

            ' データベース選択時はNothingを戻す
            If String.IsNullOrEmpty(tableInfo.ParentName) Then
                Return Nothing
            End If

            Try

                ' SQL Server認証でDB接続
                Using sqlServer = New SqlServer(MySettings.Default.ServerName, MySettings.Default.DbName,
                                                MySettings.Default.UserName, MySettings.Default.Password)

                    ' 接続エラー確認
                    If sqlServer.IsError Then
                        Throw New Exception(sqlServer.ExceptionMessage)
                    End If

                    ' クエリを保存するStringBuilderの宣言
                    Using query = New DisposableStringBuilder()

                        ' データベース名＋テーブル名の取得
                        Dim tableName = tableInfo.ParentName & ".dbo." & tableInfo.Name

                        ' レコード取得クエリ作成
                        query.Append("SELECT * FROM ").Append(tableName)

                        ' クエリを実行してDataTableを取得
                        Return sqlServer.ExecuteQueryToDataTable(query.ToString())

                    End Using

                End Using

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

            Return Nothing

        End Function

    End Class

End Namespace