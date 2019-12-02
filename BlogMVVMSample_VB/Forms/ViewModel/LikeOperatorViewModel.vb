Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>文字列の曖昧検索サンプル.ViewModel</summary>
    Public Class LikeOperatorViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>文字列の曖昧検索サンプル.Model</summary>
        Private _Model As New Model.LikeOperatorModel()

#End Region

#Region "Property"

        ''' <summary>検索元文章</summary>
        Public Property Source As String = "Hello World!"

        ''' <summary>検索する文字列</summary>
        Public Property Pattern As String = "*W*"

        ''' <summary>検索結果</summary>
        Public Property Answer As String

        ''' <summary>検索コマンド</summary>
        Private _SearchCommand As DelegateCommand

        ''' <summary>検索コマンド</summary>
        Public Property SearchCommand As DelegateCommand
            Get
                Return _SearchCommand
            End Get
            Private Set(value As DelegateCommand)
                _SearchCommand = value
            End Set
        End Property

#End Region

        ''' <summary>文字列の曖昧検索サンプル.ViewModel</summary>
        Public Sub New()

            SearchCommand = New DelegateCommand(
                Sub()

                    If _Model.Contains(Source, Pattern) Then
                        Answer = "見つかりました"
                    Else
                        Answer = "見つかりません"
                    End If

                    CallPropertyChanged(NameOf(Answer))

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

    End Class

End Namespace