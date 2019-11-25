Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System.Collections.ObjectModel

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

#End Region

        ''' <summary>SQL Serverクラス使用サンプル.ViewModel</summary>
        Public Sub New()

            DataBaseInfoList = _Model.GetDataBaseInfo()
            CallPropertyChanged(NameOf(DataBaseInfoList))

        End Sub

    End Class

End Namespace