Imports BlogMVVMSample_VB.Behaviors
Imports System.Windows

Namespace Behaviors

    ''' <summary>パスのドラッグ＆ドロップ処理を行うビヘイビア</summary>
    Public Class PathsDragAndDropBehavior
        Inherits BehaviorBase(Of FrameworkElement)

#Region "DependencyProperty"

        ''' <summary>ドロップされたパス一覧依存プロパティ</summary>
        Public Shared ReadOnly DropPathsProperty As DependencyProperty _
            = DependencyProperty.Register(NameOf(DropPaths),
                                          GetType(IList),
                                          GetType(PathsDragAndDropBehavior),
                                          New PropertyMetadata(Nothing))

#End Region

#Region "Property"

        ''' <summary>ドロップされたパス一覧プロパティ</summary>
        Public Property DropPaths As IList
            Get
                Return DirectCast(GetValue(DropPathsProperty), IList)
            End Get
            Set(value As IList)
                SetValue(DropPathsProperty, value)
            End Set
        End Property

#End Region

        ''' <summary>イベント登録</summary>
        Protected Overrides Sub OnAttached()

            MyBase.OnAttached()

            ' 対象コントロールでドラッグ＆ドロップイベントを許可
            AssociatedObject.AllowDrop = True

            ' ドラッグ＆ドロップイベントにメソッド処理を追加
            AddHandler AssociatedObject.PreViewDragOver, AddressOf OnPreViewDragOver
            AddHandler AssociatedObject.Drop, AddressOf OnDrop

        End Sub

        ''' <summary>イベント解除</summary>
        Protected Overrides Sub OnDetaching()

            MyBase.OnDetaching()

            ' ドラッグ＆ドロップイベントからメソッド処理を解除
            RemoveHandler AssociatedObject.PreViewDragOver, AddressOf OnPreViewDragOver
            RemoveHandler AssociatedObject.Drop, AddressOf OnDrop

        End Sub

        ''' <summary>パスドラッグイベント</summary>
        ''' <param name="sender">FrameworkElement</param>
        ''' <param name="e">ドラッグ内容データ</param>
        Private Sub OnPreViewDragOver(sender As Object, e As DragEventArgs)

            ' ドラッグデータがファイルフォーマットかチェック
            If e.Data.GetDataPresent(DataFormats.FileDrop, True) Then

                ' ファイル・フォルダならコピー形式でドロップ
                e.Effects = DragDropEffects.Copy

            Else

                ' ドロップ処理のキャンセル
                e.Effects = DragDropEffects.None

            End If

            ' ドラッグ操作のキャンセル
            e.Handled = True

        End Sub

        ''' <summary>パス ドロップイベント</summary>
        ''' <param name="sender">FrameworkElement</param>
        ''' <param name="e">ドロップ内容データ</param>
        Private Sub OnDrop(sender As Object, e As DragEventArgs)

            ' ドロップ情報をIListに変換
            DropPaths = TryCast(e.Data.GetData(DataFormats.FileDrop), IList)

        End Sub

    End Class

End Namespace