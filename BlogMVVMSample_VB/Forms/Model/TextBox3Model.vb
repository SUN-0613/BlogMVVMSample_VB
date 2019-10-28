Namespace Forms.Model

    ''' <summary>配列のBindingサンプル.Model</summary>
    Public Class TextBox3Model

        ''' <summary>表示Noに指定値を加算</summary>
        ''' <param name="numbers">表示No</param>
        ''' <param name="addValue">指定値</param>
        Public Sub AddNumbers(ByRef numbers As Integer(), addValue As Integer)

            For i As Integer = 0 To numbers.Length - 1
                numbers(i) += addValue
            Next

        End Sub

    End Class

End Namespace