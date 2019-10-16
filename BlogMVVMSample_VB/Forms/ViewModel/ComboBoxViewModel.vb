Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System.Collections.ObjectModel

Namespace Forms.ViewModel

    ''' <summary>ComboBox表示サンプル.ViewModel</summary>
    Public Class ComboBoxViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>ComboBox表示サンプル.Model</summary>
        Private _Model As Model.ComboBoxModel

#End Region

#Region "Property"

        ''' <summary>学生一覧</summary>
        Public Property Students As ObservableCollection(Of Student)
            Get
                Return _Model.Students
            End Get
            Set(value As ObservableCollection(Of Student))

                _Model.Students = value
                CallPropertyChanged()

            End Set
        End Property

        ''' <summary>選択中の学生</summary>
        Public Property SelectedStudent As Student
            Get
                Return _Model.SelectedStudent
            End Get
            Set(value As Student)
                _Model.SelectedStudent = value
                CallPropertyChanged()
            End Set
        End Property

#End Region

        ''' <summary>ComboBox表示サンプル.ViewModel</summary>
        Public Sub New()

            ' Modelを新規作成
            _Model = New Model.ComboBoxModel()

        End Sub

    End Class

End Namespace
