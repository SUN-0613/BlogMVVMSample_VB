Imports System.Windows
Imports System.Windows.Interactivity

Namespace Behaviors

    ''' <summary>初期化／終了処理を行うビヘイビアベースクラス</summary>
    Public MustInherit Class BehaviorBase(Of T As FrameworkElement)
        Inherits Behavior(Of T)

        ''' <summary>OnDetaching()実行終了FLG</summary>
        Private _IsDetaching As Boolean = False

        ''' <summary>イベント登録</summary>
        Protected Overrides Sub OnAttached()

            MyBase.OnAttached()

            ' UnloadedイベントにOnUnloaded()を登録
            AddHandler AssociatedObject.Unloaded, AddressOf OnUnloaded

        End Sub

        ''' <summary>イベント解除</summary>
        Protected Overrides Sub OnDetaching()

            MyBase.OnDetaching()

            ' UnloadedイベントからOnUnloaded()を解除
            RemoveHandler AssociatedObject.Unloaded, AddressOf OnUnloaded

            ' FLG更新
            _IsDetaching = True

        End Sub

        ''' <summary>Unloadedイベント</summary>
        ''' <param name="sender">対象コントロール</param>
        ''' <param name="e">イベントデータ</param>
        Private Sub OnUnloaded(sender As Object, e As RoutedEventArgs)

            ' OnDetaching()が未実行であるならイベントを強制実行
            If Not _IsDetaching Then
                OnDetaching()
            End If

        End Sub

    End Class

End Namespace