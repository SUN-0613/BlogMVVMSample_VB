Imports System

Namespace Data

    ''' <summary>学生クラス</summary>
    Public Class Student

#Region "Property"

        ''' <summary>出席番号</summary>
        Public Property No As Integer

        ''' <summary>名前</summary>
        Public Property Name As String

        ''' <summary>生年月日</summary>
        Public Property Birthday As DateTime
            Get
                Return _Birthday
            End Get
            Set(value As DateTime)

                ' 値セット後、年齢を計算
                _Birthday = value
                Age = CalcAge()

            End Set
        End Property

        ''' <summary>年齢</summary>
        Public Property Age As Integer
            Get
                Return _Age
            End Get
            Private Set(value As Integer)
                _Age = value
            End Set
        End Property

        ''' <summary>性別</summary>
        Public Property Gender As Gender

        ''' <summary>進路は就職か</summary>
        Public Property IsWorkNext As Boolean

        ''' <summary>メールアドレス</summary>
        Public Property MailAddress As String

#End Region

        ''' <summary>生年月日</summary>
        Private _Birthday As DateTime

        ''' <summary>年齢</summary>
        Private _Age As Integer

        ''' <summary>生年月日から年齢計算</summary>
        Private Function CalcAge() As Integer

            ' 今年と生まれた年の差を求める
            Dim age As Integer = DateTime.Today.Year - Birthday.Year

            ' 今年の誕生日が過ぎてなければ1歳減らす
            If New DateTime(DateTime.Today.Year, Birthday.Month, Birthday.Day) > DateTime.Today Then
                age -= 1
            End If

            Return age

        End Function

    End Class

End Namespace

