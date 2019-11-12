Imports System
Imports System.Threading
Imports System.Threading.Tasks

Namespace Forms.Model

    ''' <summary>進捗バー.Model</summary>
    Public Class ProgressBarModel

#Region "ViewModel.Property"

        ''' <summary>入力許可</summary>
        Public IsEnabled As Boolean = True

        ''' <summary>進捗値</summary>
        Public Value As Double = 0D

        ''' <summary>進捗最小値</summary>
        Public Minimum As Double = 0D

        ''' <summary>最大値</summary>
        Public Maximum As Double = 100D

        ''' <summary>進捗メッセージ</summary>
        Public Message As String = ""

#End Region

        ''' <summary>何かしらの処理</summary>
        ''' <param name="runtime">処理時間</param>
        ''' <param name="callPropertyChanged">ViewModelのプロパティ変更イベント呼び出しメソッド</param>
        Public Async Sub RunMethodASync(runtime As Double, callPropertyChanged As Action(Of String))

            ' 初期値設定
            IsEnabled = False
            Value = 0D
            Minimum = 0D
            Maximum = runtime

            Message = "何か重たい処理を続行中..."

            ' ViewModelでプロパティ変更イベントを実行
            callPropertyChanged(NameOf(IsEnabled))
            callPropertyChanged(NameOf(Value))
            callPropertyChanged(NameOf(Minimum))
            callPropertyChanged(NameOf(Maximum))
            callPropertyChanged(NameOf(Message))

            ' 何か時間がかかる処理
            Await Task.Run(
                Sub()

                    While Value < Maximum

                        Thread.Sleep(100)
                        Value += 0.1
                        callPropertyChanged(NameOf(Value))

                    End While

                End Sub)

            ' 終了メッセージ表示
            Value = Maximum
            Message = "終了しました"
            IsEnabled = True

            ' ViewModelでプロパティ変更イベントを実行
            callPropertyChanged(NameOf(Value))
            callPropertyChanged(NameOf(Message))
            callPropertyChanged(NameOf(IsEnabled))

        End Sub

    End Class

End Namespace