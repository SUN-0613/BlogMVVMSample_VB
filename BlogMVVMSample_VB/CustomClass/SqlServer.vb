Imports System
Imports System.Data.SqlClient

Namespace CustomClass

    ''' <summary>SQL Server 接続管理</summary>
    Public Class SqlServer

#Region "ErrorProperty"

        ''' <summary>エラーメッセージ</summary>
        Public Property ExceptionMessage
            Get
                Return _ExceptionMessage
            End Get
            Private Set(value)
                _ExceptionMessage = value
            End Set
        End Property

        ''' <summary>エラーメッセージ</summary>
        Private _ExceptionMessage = String.Empty

        ''' <summary>エラーが発生したか</summary>
        Public ReadOnly Property IsError As Boolean
            Get
                Return Not String.IsNullOrEmpty(ExceptionMessage)
            End Get
        End Property

#End Region

#Region "SQL Server 接続情報"

        ''' <summary>接続インスタンス</summary>
        Private _SqlConnection As SqlConnection

        ''' <summary>接続FLG</summary>
        Private _IsConnect As Boolean = False

#End Region

#Region "新規作成、解放処理"

        ''' <summary>
        ''' SQL Server 操作管理
        ''' SQL Server認証による接続
        ''' </summary>
        ''' <param name="serverName">接続するサーバ名</param>
        ''' <param name="dbName">データベース名称</param>
        ''' <param name="userName">ユーザ名</param>
        ''' <param name="password">パスワード</param>
        ''' <param name="timeOut">タイムアウト(秒)</param>
        Public Sub New(serverName As String, dbName As String, userName As String, password As String, Optional timeOut As Integer = 30)

            ' SQL Serverに接続するための文字列作成
            Using connectionString As New DisposableStringBuilder(256)

                connectionString.Append("Data Source = ").Append(serverName).Append(";")
                connectionString.Append("Initial Catalog = ").Append(dbName).Append(";")
                connectionString.Append("User ID = ").Append(userName).Append(";")
                connectionString.Append("Password = ").Append(password).Append(";")
                connectionString.Append("MultipleActiveResultSets = True;")
                connectionString.Append("Connection Timeout = ").Append(timeOut.ToString())

                ' 接続開始
                Open(connectionString.ToString())

            End Using

        End Sub

        ''' <summary>
        ''' SQL Server 操作管理
        ''' Windows認証による接続
        ''' </summary>
        ''' <param name="serverName">接続するサーバ名</param>
        ''' <param name="dbName">データベース名称</param>
        ''' <param name="timeOut">タイムアウト(秒)</param>
        Public Sub New(serverName As String, dbName As String, Optional timeOut As Integer = 30)

            ' SQL Serverに接続するための文字列作成
            Using connectionString As New DisposableStringBuilder(256)

                connectionString.Append("Data Source = ").Append(serverName).Append(";")
                connectionString.Append("Initial Catalog = ").Append(dbName).Append(";")
                connectionString.Append("Integrated Security = True;")
                connectionString.Append("MultipleActiveResultSets = True;")
                connectionString.Append("Connection Timeout = ").Append(timeOut.ToString())

                ' 接続開始
                Open(connectionString.ToString())

            End Using

        End Sub

        ''' <summary>エラー情報の初期化</summary>
        Private Sub InitializeException()

            If Not String.IsNullOrEmpty(ExceptionMessage) Then
                ExceptionMessage = String.Empty
            End If

        End Sub

#End Region

#Region "接続、切断"

        ''' <summary>SQL Server接続</summary>
        ''' <param name="connectionString">接続するためのパラメータ</param>
        Private Sub Open(connectionString As String)

            Try

                ' インスタンス生成
                _SqlConnection = New SqlConnection(connectionString)

                ' SQL Server 接続
                _SqlConnection.Open()
                _IsConnect = True

            Catch ex As Exception

                ExceptionMessage = ex.Message

            End Try

        End Sub

        ''' <summary>切断</summary>
        Private Sub Close()

            Try

                InitializeException()

                ' 切断
                If _IsConnect Then

                    _SqlConnection.Close()
                    _IsConnect = False

                End If

                ' メモリ解放
                If Not IsNothing(_SqlConnection) Then

                    _SqlConnection.Dispose()
                    _SqlConnection = Nothing

                End If

            Catch ex As Exception

                ExceptionMessage = ex.Message

            End Try

        End Sub

#End Region

    End Class

End Namespace