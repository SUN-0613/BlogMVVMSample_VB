Imports BlogMVVMSample_VB.Data

Namespace Forms.Model

    ''' <summary>ComboBox表示サンプルその２.Model</summary>
    Public Class ComboBox2Model

        ''' <summary>現在の進捗を文章にして取得</summary>
        ''' <param name="status">現在の進捗</param>
        ''' <returns>文章</returns>
        Public Function GetMessage(status As JobStatus) As String

            Select Case status

                Case JobStatus.NotOrdered
                    Return "この仕事はまだ受注していません。"

                Case JobStatus.Ordered
                    Return "この仕事は受注しました。開発中です。"

                Case JobStatus.Delivery
                    Return "この仕事は納品しました。請求中です。"

                Case JobStatus.Finished
                    Return "この仕事は全行程完了しました。"

                Case Else
                    Return ""

            End Select

        End Function

    End Class

End Namespace

