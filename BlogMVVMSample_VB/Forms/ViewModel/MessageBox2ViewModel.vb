Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System.Windows

Namespace Forms.ViewModel

    ''' <summary>メッセージボックス表示.ViewModel</summary>
    Public Class MessageBox2ViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>メッセージ表示コマンド</summary>
        Public ReadOnly Property MessageCommand As DelegateCommand

        ''' <summary>メッセージボックス表示内容</summary>
        Public Property MessageInfo As MessageBoxInfo
            Get
                Return _MessageInfo
            End Get
            Set(value As MessageBoxInfo)

                _MessageInfo = value
                CallPropertyChanged()

            End Set
        End Property

        ''' <summary>メッセージボックスの結果を表示</summary>
        Public Property MessageBoxResult As String

#End Region

        ''' <summary>メッセージボックス表示内容</summary>
        Private _MessageInfo As MessageBoxInfo

        ''' <summary>メッセージボックス表示.ViewModel</summary>
        Public Sub New()

            ' メッセージボックスを表示するためのプロパティ変更イベントを実行
            MessageCommand = New DelegateCommand(
                Sub()

                    MessageInfo = New MessageBoxInfo With
                    {
                        .Message = "Hello World!",
                        .Title = "MessageBoxView",
                        .Button = MessageBoxButton.YesNo,
                        .Image = MessageBoxImage.Information
                    }

                    MessageBoxResult = MessageInfo.Result.ToString()
                    CallPropertyChanged(NameOf(MessageBoxResult))

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

    End Class

End Namespace