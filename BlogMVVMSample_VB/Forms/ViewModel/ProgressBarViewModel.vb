Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>進捗バー.ViewModel</summary>
    Public Class ProgressBarViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>進捗バー.Model</summary>
        Public _Model As New Model.ProgressBarModel()

#End Region

#Region "Property"

        ''' <summary>入力許可</summary>
        Public ReadOnly Property IsEnabled As Boolean
            Get
                Return _Model.IsEnabled
            End Get
        End Property

        ''' <summary>処理時間</summary>
        Public Property Runtime As Double = 10D

        ''' <summary>処理開始コマンド</summary>
        Public Property RunCommand As DelegateCommand
            Get
                Return _RunCommand
            End Get
            Private Set(value As DelegateCommand)
                _RunCommand = value
            End Set
        End Property

        ''' <summary>進捗値</summary>
        Public ReadOnly Property Value As Double
            Get
                Return _Model.Value
            End Get
        End Property

        ''' <summary>進捗最小値</summary>
        Public ReadOnly Property Minimum As Double
            Get
                Return _Model.Minimum
            End Get
        End Property

        ''' <summary>進捗最大値</summary>
        Public ReadOnly Property Maximum As Double
            Get
                Return _Model.Maximum
            End Get
        End Property

        ''' <summary>進捗メッセージ</summary>
        Public ReadOnly Property Message As String
            Get
                Return _Model.Message
            End Get
        End Property

#End Region

        ''' <summary>処理開始コマンド</summary>
        Private _RunCommand As DelegateCommand

        ''' <summary>進捗バー.ViewModel</summary>
        Public Sub New()

            _Model = New Model.ProgressBarModel()

            RunCommand = New DelegateCommand(
            Sub()
                _Model.RunMethodASync(Runtime, AddressOf CallPropertyChanged)
            End Sub,
            Function()
                Return True
            End Function)

        End Sub

    End Class

End Namespace