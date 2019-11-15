Imports System
Imports System.Collections.ObjectModel
Imports System.Diagnostics

Namespace Forms.Model

    ''' <summary>Callbackサンプル.Model</summary>
    Public Class CallbackModel

#Region "Delegate"

        ''' <summary>カウントダウン更新用コールバック</summary>
        ''' <param name="sec">秒数</param>
        Public Delegate Sub UpdateCountdownCallback(sec As Integer)

#End Region

        ''' <summary>乱数を取得して一覧を作成する</summary>
        ''' <param name="callback">カウントダウン更新用コールバック</param>
        ''' <returns>乱数一覧</returns>
        Public Function MakeCollection(countdownCallback As UpdateCountdownCallback) As ObservableCollection(Of Integer)

            Const countdownMax As Integer = 5

            Dim values As New ObservableCollection(Of Integer)
            Dim random As New Random()
            Dim stopwatch As New Stopwatch()
            Dim countdown As Integer = -1

            stopwatch.Start()

            ' 5秒間、乱数を生成して一覧に追加
            While countdown < countdownMax

                values.Add(random.Next())

                ' 秒毎にカウントダウンコールバックを呼び出す
                If Not countdown.Equals(stopwatch.Elapsed.Seconds) Then

                    countdown = stopwatch.Elapsed.Seconds
                    countdownCallback(countdownMax - countdown)

                End If

            End While

            countdownCallback(0)
            stopwatch.Stop()

            Return values

        End Function

    End Class

End Namespace