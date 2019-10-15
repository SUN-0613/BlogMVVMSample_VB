Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>Hello World!.ViewModel</summary>
    Public Class TextBoxViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>TextBoxに表示する文字列のプロパティ</summary>
        Public Property Text As String
            Get

                ' 内部変数の値を戻す
                Return _Text

            End Get
            Set(value As String)

                ' 内部変数に入力内容を反映
                _Text = value

                ' プロパティ変更イベントを発生させViewに通知
                CallPropertyChanged()

            End Set
        End Property

        ''' <summary>ボタンクリック処理コマンドプロパティ</summary>
        Public ReadOnly Property ButtonClickCommand As DelegateCommand

#End Region

        ''' <summary>TextBoxに表示する文字列</summary>
        Private _Text As String

        ''' <summary>TextBoxに表示する文字列のプロパティ</summary>
        Public Sub New()

            ButtonClickCommand = New DelegateCommand(
            Sub()       ' 実行メソッド
                Text = "Hello World!"
            End Sub,
            Function()  ' 実行メソッド許可
                Return True
            End Function)

        End Sub

    End Class

End Namespace