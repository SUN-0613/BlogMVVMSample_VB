Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System.Collections.ObjectModel

Namespace Forms.ViewModel

    ''' <summary>一覧表示Controlsサンプル.ViewModel</summary>
    Public Class ListViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>一覧表示Controlsサンプル.Model</summary>
        Private _Model As Model.ListModel

#End Region

#Region "Property"

        Public Property Paths As ObservableCollection(Of PathInfo)
            Get
                Return _Model.Paths
            End Get
            Set(value As ObservableCollection(Of PathInfo))
                _Model.Paths = value
            End Set
        End Property

#End Region

        ''' <summary>一覧表示Controlsサンプル.ViewModel</summary>
        Public Sub New()
            _Model = New Model.ListModel()
        End Sub

    End Class

End Namespace