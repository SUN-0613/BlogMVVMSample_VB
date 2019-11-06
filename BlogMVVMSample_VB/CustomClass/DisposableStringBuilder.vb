Imports System
Imports System.Text

Namespace CustomClass

    ''' <summary>StringBuilder()にリソース解放処理</summary>
    Public Class DisposableStringBuilder
        Implements IDisposable

        ''' <summary>StringBuilder</summary>
        Private _StringBuilder As StringBuilder

        ''' <summary>StringBuilder()にリソース解放処理</summary>
        Public Sub New()
            _StringBuilder = New StringBuilder()
        End Sub

        ''' <summary>StringBuilder()にリソース解放処理</summary>
        ''' <param name="capacity">推奨開始サイズ</param>
        Public Sub New(capacity As Integer)
            _StringBuilder = New StringBuilder(capacity)
        End Sub

        ''' <summary>解放処理</summary>
        Public Sub Dispose() Implements IDisposable.Dispose

            _StringBuilder.Clear()
            _StringBuilder = Nothing

        End Sub

        ''' <summary>文字列の長さを取得、設定</summary>
        Public Property Length As Integer
            Get
                Return _StringBuilder.Length
            End Get
            Set(value As Integer)
                _StringBuilder.Length = value
            End Set
        End Property

        ''' <summary>文字列追加</summary>
        ''' <param name="value">追加文字列</param>
        ''' <returns>StringBuilder</returns>
        Public Function Append(value As String) As StringBuilder
            Return _StringBuilder.Append(value)
        End Function

        ''' <summary>末尾に改行コードを追加</summary>
        ''' <returns>StringBuilder</returns>
        Public Function AppendLine() As StringBuilder
            Return _StringBuilder.AppendLine()
        End Function

        ''' <summary>文字列追加:末尾に改行コードを追加</summary>
        ''' <param name="value">追加文字列</param>
        ''' <returns>StringBuilder</returns>
        Public Function AppendLine(value As String) As StringBuilder
            Return _StringBuilder.AppendLine(value)
        End Function

        ''' <summary>引数のオブジェクトが自身と同一のものかチェック</summary>
        ''' <param name="obj">引数のオブジェクト</param>
        ''' <returns>
        ''' true:同一である
        ''' false:同一でない
        ''' </returns>
        Public Overrides Function Equals(obj As Object) As Boolean

            Dim stringBuilder As StringBuilder = TryCast(obj, StringBuilder)

            If Not IsNothing(stringBuilder) Then
                Return _StringBuilder.Equals(stringBuilder)
            Else
                Return False
            End If

        End Function

        ''' <summary>指定した文字位置に文字列を挿入</summary>
        ''' <param name="index">指定した文字位置</param>
        ''' <param name="value">挿入文字列</param>
        ''' <returns>StringBuilder</returns>
        Public Function Insert(index As Integer, value As String) As StringBuilder
            Return _StringBuilder.Insert(index, value)
        End Function

        ''' <summary>StringBuilderの持つ文字列をString型に変換</summary>
        ''' <returns>文字列</returns>
        Public Overrides Function ToString() As String
            Return _StringBuilder.ToString()
        End Function

        ''' <summary>StringBuilderの持つ文字列をString型に変換</summary>
        ''' <param name="startIndex">開始位置</param>
        ''' <param name="length">文字数</param>
        ''' <returns>文字列</returns>
        Public Overloads Function ToString(startIndex As Integer, length As Integer) As String
            Return _StringBuilder.ToString(startIndex, length)
        End Function

    End Class

End Namespace