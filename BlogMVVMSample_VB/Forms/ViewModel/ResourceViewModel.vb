Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System.Globalization
Imports System.Threading

Namespace Forms.ViewModel

    ''' <summary>リソースファイルによる表示言語切替.ViewModel</summary>
    Public Class ResourceViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>選択している言語</summary>
        Private _SelectedLanguage As Languages

        ''' <summary>選択している言語</summary>
        Public Property SelectedLanguage As Languages
            Get
                Return _SelectedLanguage
            End Get
            Set(value As Languages)

                _SelectedLanguage = value
                CallPropertyChanged()

                ' 言語切替
                Select Case _SelectedLanguage

                    Case Languages.English
                        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")

                    Case Languages.Japanese
                        Thread.CurrentThread.CurrentUICulture = New CultureInfo("ja-JP")

                End Select

            End Set
        End Property

        ''' <summary>メッセージボックス表示内容</summary>
        Public Property MessageInfo As MessageBoxInfo

        ''' <summary>メッセージボックス表示コマンド</summary>
        Public Property MessageBoxCommand As DelegateCommand

#End Region

        ''' <summary>リソースファイルによる表示言語切替.ViewModel</summary>
        Public Sub New()

            ' 初期値取得
            Select Case Thread.CurrentThread.CurrentUICulture.Name

                Case "en-US"
                    SelectedLanguage = Languages.English

                Case "ja-JP"
                    SelectedLanguage = Languages.Japanese

            End Select

            MessageBoxCommand = New DelegateCommand(
                Sub()

                    ' リソースファイルより表示内容を取得
                    MessageInfo = New MessageBoxInfo() With
                    {
                        .Message = My.Resources.LanguageSample.Message,
                        .Title = My.Resources.LanguageSample.Title
                    }

                    CallPropertyChanged(NameOf(MessageInfo))

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

    End Class

End Namespace