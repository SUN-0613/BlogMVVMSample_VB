Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System.Collections.ObjectModel
Imports System.Data

Namespace Forms.ViewModel

    ''' <summary>SQL Serverクラス使用サンプル.ViewModel</summary>
    Public Class SqlServerViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>SQL Serverクラス使用サンプル.Model</summary>
        Private _Model As New Model.SqlServerModel

#End Region

#Region "Property"

        ''' <summary>データベース・テーブル一覧</summary>
        Public Property DataBaseInfoList As New ObservableCollection(Of DataBaseInfo)

        ''' <summary>選択しているデータベース・テーブル</summary>
        Public Property SelectedItem As DataBaseInfo
            Get
                Return _SelectedItem
            End Get
            Set(value As DataBaseInfo)

                _SelectedItem = value

                ' 選択したテーブルのレコードを表示
                TableRecord = _Model.GetTableRecord(_SelectedItem)
                CallPropertyChanged(NameOf(TableRecord))

            End Set
        End Property

        ''' <summary>選択しているデータベース・テーブル</summary>
        Private _SelectedItem As DataBaseInfo

        ''' <summary>テーブルレコード</summary>
        Public Property TableRecord As DataTable

#End Region

        ''' <summary>SQL Serverクラス使用サンプル.ViewModel</summary>
        Public Sub New()

            DataBaseInfoList = _Model.GetDataBaseInfo()
            CallPropertyChanged(NameOf(DataBaseInfoList))

        End Sub

    End Class

End Namespace