Imports System.Windows.Controls
Imports System.Windows.Input

Namespace Behaviors

    ''' <summary>TextBox：Enterやカーソルキーでフォーカス移動するビヘイビア</summary>
    Public Class TextBoxMoveFocus
        Inherits BehaviorBase(Of TextBox)

        ''' <summary>イベント登録</summary>
        Protected Overrides Sub OnAttached()

            MyBase.OnAttached()

            ' TextBoxのキーダウンイベントにOnPreViewKeyDownを登録
            AddHandler AssociatedObject.PreViewKeyDown, AddressOf OnPreViewKeyDown

        End Sub

        ''' <summary>イベント解除</summary>
        Protected Overrides Sub OnDetaching()

            MyBase.OnDetaching()

            ' TextBoxのキーダウンイベントからOnPreViewKeyDownを解除
            RemoveHandler AssociatedObject.PreViewKeyDown, AddressOf OnPreViewKeyDown

        End Sub

        ''' <summary>キー押下イベント</summary>
        ''' <param name="sender">TextBox</param>
        ''' <param name="e">キーイベントデータ</param>
        Private Sub OnPreViewKeyDown(sender As Object, e As KeyEventArgs)

            Dim textBox As TextBox = TryCast(sender, TextBox)

            If Not IsNothing(textBox) Then

                ' フォーカス移動要求
                Dim request As TraversalRequest = Nothing

                Select Case e.Key

                    Case Key.Enter

                        ' 単数行入力のみEnterでフォーカス移動を行う
                        If Not textBox.AcceptsReturn Then

                            ' Shiftキーが押されているか
                            Dim isShift As Boolean = Keyboard.Modifiers.Equals(ModifierKeys.Shift)

                            ' 通常は次フォーカスへ移動
                            ' Shiftキー押下時は前フォーカスへ移動
                            request = New TraversalRequest(If(isShift, FocusNavigationDirection.Previous, FocusNavigationDirection.Next))

                        End If

                    Case Key.Left

                        ' キャレットの位置が先頭にある場合にフォーカス移動を行う
                        If textBox.SelectionStart.Equals(0) Then
                            request = New TraversalRequest(FocusNavigationDirection.Left)
                        End If

                    Case Key.Right

                        ' キャレットの位置が末尾にある場合にフォーカス移動を行う
                        If textBox.SelectionStart.Equals(textBox.Text.Length) Then
                            request = New TraversalRequest(FocusNavigationDirection.Right)
                        End If

                    Case Key.Up

                        ' キャレットの位置が先頭行にあるか判断
                        Dim isTop As Boolean = False

                        ' TextBoxが単数行入力 = 先頭行にある
                        If Not textBox.AcceptsReturn Then

                            isTop = True

                        ElseIf textBox.SelectionStart.Equals(0) Then

                            ' キャレットの位置が先頭にある = 先頭行にある
                            isTop = True

                        Else

                            ' 文頭からキャレットの位置までに改行コードがない = 先頭行にある
                            isTop = IsCheckCrLf(textBox.Text.Substring(0, textBox.SelectionStart))

                        End If

                        ' キャレットの位置が先頭行にある場合にフォーカス移動を行う
                        If isTop Then
                            request = New TraversalRequest(FocusNavigationDirection.Up)
                        End If

                    Case Key.Down

                        ' キャレットの位置が最終行にあるか判断
                        Dim isBottom As Boolean = False

                        ' TextBoxが単数行入力 = 最終行にある
                        If Not textBox.AcceptsReturn Then

                            isBottom = True

                        ElseIf textBox.SelectionStart.Equals(textBox.Text.Length) Then

                            ' キャレットの位置が末尾にある = 最終行にある
                            isBottom = True

                        Else

                            ' キャレットの位置から末尾までに改行コードがない = 最終行にある
                            isBottom = IsCheckCrLf(textBox.Text.Substring(textBox.SelectionStart))

                        End If

                        ' キャレットの位置が最終行にある場合にフォーカス移動を行う
                        If isBottom Then
                            request = New TraversalRequest(FocusNavigationDirection.Down)
                        End If

                    Case Else
                        Exit Select

                End Select

                ' フォーカス移動を実行
                If Not IsNothing(request) Then
                    textBox.MoveFocus(request)
                End If

            End If

        End Sub

        ''' <summary>指定文字列に改行コードが含まれているかチェック</summary>
        ''' <param name="text">指定文字列</param>
        ''' <returns>
        ''' True : 改行コード有
        ''' False: 改行コード無
        ''' </returns>
        Private Function IsCheckCrLf(text As String) As Boolean

            Return Not text.Contains(vbCr) AndAlso Not text.Contains(vbLf)

        End Function

    End Class

End Namespace