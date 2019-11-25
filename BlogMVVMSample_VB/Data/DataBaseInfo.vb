Imports System.Collections.ObjectModel

Namespace Data

    ''' <summary>データベース情報</summary>
    Public Class DataBaseInfo

#Region "Property"

        ''' <summary>データベース・テーブル名称</summary>
        Public Property Name As String

        ''' <summary>自身がテーブルの場合、所属するデータベース</summary>
        Public Property ParentName As String = String.Empty

        ''' <summary>テーブル一覧</summary>
        Public Property Tables As New ObservableCollection(Of DataBaseInfo)

#End Region

    End Class

End Namespace