Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>ComboBox表示サンプルその２.ViewModel</summary>
    Public Class ComboBox2ViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>ComboBox表示サンプルその２.Model</summary>
        Private _Model As Model.ComboBox2Model = New Model.ComboBox2Model()

#End Region

#Region "Property"

        ''' <summary>仕事の進捗</summary>
        Public Property SelectedStatus As JobStatus
            Get
                Return _SelectedStatus
            End Get
            Set(value As JobStatus)

                _SelectedStatus = value

                ' 選択した内容に沿った文章を表示
                CallPropertyChanged(NameOf(Message))

            End Set
        End Property

        ''' <summary>文章</summary>
        Public ReadOnly Property Message
            Get
                Return _Model?.GetMessage(SelectedStatus)
            End Get
        End Property

#End Region

        ''' <summary>仕事の進捗</summary>
        Private _SelectedStatus As JobStatus

    End Class

End Namespace
