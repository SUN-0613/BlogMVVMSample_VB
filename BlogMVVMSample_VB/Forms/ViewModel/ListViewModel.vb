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

        ''' <summary>パス一覧</summary>
        Public Property Paths As ObservableCollection(Of PathInfo)
            Get
                Return _Model.Paths
            End Get
            Set(value As ObservableCollection(Of PathInfo))
                _Model.Paths = value
            End Set
        End Property

        ''' <summary>選択パス</summary>
        Public Property SelectedPath As PathInfo
            Get
                Return _Model.SelectedPath
            End Get
            Set(value As PathInfo)
                _Model.SelectedPath = value
                CallPropertyChanged()
                CallPropertyChanged(NameOf(FullPath))
                CallPropertyChanged(NameOf(Files))
            End Set
        End Property

        ''' <summary>選択パスのフルパス</summary>
        Public ReadOnly Property FullPath As String
            Get
                Return _Model.SelectedPath.FullPath
            End Get
        End Property

        ''' <summary>選択パス直下のファイル一覧</summary>
        Public Property Files As ObservableCollection(Of FileInfo)
            Get
                Return _Model.Files
            End Get
            Set(value As ObservableCollection(Of FileInfo))
                _Model.Files = value
            End Set
        End Property

#End Region

        ''' <summary>一覧表示Controlsサンプル.ViewModel</summary>
        Public Sub New()
            _Model = New Model.ListModel()
        End Sub

    End Class

End Namespace