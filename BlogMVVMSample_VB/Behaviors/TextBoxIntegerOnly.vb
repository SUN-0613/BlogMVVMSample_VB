Imports System.Windows.Controls
Imports System.Windows.Input

Namespace Behaviors

    ''' <summary>TextBox：整数値のみを入力許可</summary>
    Public Class TextBoxIntegerOnly
        Inherits BehaviorBase(Of TextBox)

        ''' <summary>イベント登録</summary>
        Protected Overrides Sub OnAttached()

            MyBase.OnAttached()

            ' テキスト取得時の処理イベントの追加
            AddHandler AssociatedObject.PreViewTextInput, AddressOf OnPreViewTextInput

            ' PreViewTextInputにスペースをスルーしないようにする
            AssociatedObject.InputBindings.Add(New KeyBinding(ApplicationCommands.NotACommand, Key.Space, ModifierKeys.None))
            AssociatedObject.InputBindings.Add(New KeyBinding(ApplicationCommands.NotACommand, Key.Space, ModifierKeys.Shift))

            ' IMEモードを無効化
            InputMethod.SetIsInputMethodEnabled(AssociatedObject, False)

            ' クリップボード処理
            AssociatedObject.CommandBindings.Add(New CommandBinding(ApplicationCommands.Paste, AddressOf OnPasteCommand))

            ' コンテキストメニュー無効化
            AssociatedObject.ContextMenu = Nothing

        End Sub

        ''' <summary>イベント解除</summary>
        Protected Overrides Sub OnDetaching()

            MyBase.OnDetaching()

            ' テキスト取得時の処理イベントの解除
            RemoveHandler AssociatedObject.PreViewTextInput, AddressOf OnPreViewTextInput

            ' 入力Bindingの初期化
            AssociatedObject.InputBindings.Clear()

            ' クリップボード処理の初期化
            AssociatedObject.CommandBindings.Clear()

        End Sub

        ''' <summary>テキスト取得時の処理イベント</summary>
        ''' <param name="sender">TextBox</param>
        ''' <param name="e">入力内容データ</param>
        Private Sub OnPreViewTextInput(sender As Object, e As TextCompositionEventArgs)

            ' 整数値に変換できない場合は処理をキャンセル
            e.Handled = Not CheckTextInput(sender, e.Text)

        End Sub

        ''' <summary>クリップボード貼り付け時の処理イベント</summary>
        ''' <param name="sender">TextBox</param>
        ''' <param name="e">実行イベントデータ</param>
        Private Sub OnPasteCommand(sender As Object, e As ExecutedRoutedEventArgs)

            ' 整数値に変換できる場合は貼り付け処理を実行
            If CheckTextInput(sender, Clipboard.GetText()) Then
                AssociatedObject.Paste()
            End If

        End Sub

        ''' <summary>入力した内容で数値となるかチェック</summary>
        ''' <param name="sender">TextBox</param>
        ''' <param name="addText">追加文字</param>
        ''' <returns></returns>
        Private Function CheckTextInput(sender As Object, addText As String) As Boolean

            Dim textBox As TextBox = TryCast(sender, TextBox)

            If Not IsNothing(textBox) Then

                ' カーソル位置より前の文字列
                Dim part1 As String = If(textBox.SelectionStart.Equals(0), "", textBox.Text.Substring(0, textBox.SelectionStart))

                ' カーソル位置+選択文字より後の文字列
                Dim part2 As String = textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength)

                ' part1とpart2の間に入力された文字を追加
                Dim text As String = part1 & addText & part2

                ' 作成した文字列が整数に変換できるか
                Dim returnValue As Integer
                Return Integer.TryParse(text, returnValue)

            Else
                Return False
            End If

        End Function

    End Class

End Namespace