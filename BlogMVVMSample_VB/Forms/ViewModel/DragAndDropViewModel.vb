Imports BlogMVVMSample_VB.MVVM
Imports System.Collections

Namespace Forms.ViewModel

    ''' <summary>ドラッグ＆ドロップ.ViewModel</summary>
    Public Class DragAndDropViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>パス一覧</summary>
        Public Property Paths As IList
            Get
                Return _Paths
            End Get
            Set(value As IList)

                _Paths = value
                CallPropertyChanged()

            End Set
        End Property


#End Region

        ''' <summary>パス一覧</summary>
        Private _Paths As IList

    End Class

End Namespace