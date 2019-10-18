Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>CheckBoxサンプル.ViewModel</summary>
    Public Class CheckBoxViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>TextBoxに入力可能か</summary>
        Public Property IsEditing As Boolean
            Get
                Return _IsEditing
            End Get
            Set(value As Boolean)

                _IsEditing = value

                CallPropertyChanged()
                CallPropertyChanged(NameOf(IsReadOnly))

            End Set
        End Property

        ''' <summary>読取専用</summary>
        Public ReadOnly Property IsReadOnly
            Get
                Return Not _IsEditing
            End Get
        End Property

        ''' <summary>文章</summary>
        Public Property Text As String

#End Region

        ''' <summary>TextBoxに入力可能か</summary>
        Private _IsEditing As Boolean = False

    End Class

End Namespace