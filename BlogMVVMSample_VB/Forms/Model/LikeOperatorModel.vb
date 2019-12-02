Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace Forms.Model

    ''' <summary>文字列の曖昧検索サンプル.Model</summary>
    Public Class LikeOperatorModel

        ''' <summary>検索対象の文章と検索する文字列が一致するかチェック</summary>
        ''' <param name="source">検索対象の文章</param>
        ''' <param name="pattern">検索する文字列</param>
        Public Function Contains(source As String, pattern As String) As Boolean

            ' 大文字⇔小文字、全角⇔半角、ひらがな⇔カタカナを区別する場合、CompareMethod.Binaryを使用
            Return LikeOperator.LikeString(source, pattern, CompareMethod.Text)

        End Function

    End Class

End Namespace