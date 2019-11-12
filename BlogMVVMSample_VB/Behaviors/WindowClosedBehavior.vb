Imports System
Imports System.Windows

Namespace Behaviors

    Public Class WindowClosedBehavior
        Inherits BehaviorBase(Of Window)

        ''' <summary>イベント登録</summary>
        Protected Overrides Sub OnAttached()

            MyBase.OnAttached()

            ' Windowが閉じられた時の処理イベントにOnClosed()を追加
            AddHandler AssociatedObject.Closed, AddressOf OnClosed

        End Sub

        ''' <summary>イベント解除</summary>
        Protected Overrides Sub OnDetaching()

            MyBase.OnDetaching()

            ' Windowが閉じられた時の処理イベントからOnClosed()を削除
            RemoveHandler AssociatedObject.Closed, AddressOf OnClosed

        End Sub

        ''' <summary>Windowが閉じられた時の処理イベント</summary>
        ''' <param name="sender">Window</param>
        ''' <param name="e">イベントデータ</param>
        Private Sub OnClosed(sender As Object, e As EventArgs)

            Dim disposable As IDisposable = TryCast(AssociatedObject.DataContext, IDisposable)

            If Not IsNothing(disposable) Then
                disposable.Dispose()
            End If

        End Sub

    End Class

End Namespace