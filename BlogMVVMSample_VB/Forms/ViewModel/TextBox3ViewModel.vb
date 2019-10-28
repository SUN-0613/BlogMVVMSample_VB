Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>配列のBindingサンプル.ViewModel</summary>
    Public Class TextBox3ViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>配列のBindingサンプル.Model</summary>
        Private _Model As Model.TextBox3Model

#End Region

#Region "Property"

        ''' <summary>表示No</summary>
        Public Property Numbers As Integer()

        ''' <summary>表示No加算コマンド</summary>
        Public ReadOnly Property AddCommand As DelegateCommand

#End Region

        ''' <summary>配列のBindingサンプル.ViewModel</summary>
        Public Sub New()

            ' Model
            _Model = New Model.TextBox3Model()

            ' 表示No
            Numbers = New Integer() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}

            ' 表示Noの値に10加算
            AddCommand = New DelegateCommand(
            Sub()

                _Model.AddNumbers(Numbers, 10)
                CallPropertyChanged(NameOf(Numbers))

            End Sub,
            Function()
                Return True
            End Function)

        End Sub

    End Class

End Namespace