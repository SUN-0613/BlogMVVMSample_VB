Imports BlogMVVMSample_VB.MVVM
Imports System

Namespace Forms.ViewModel


    ''' <summary>カレンダーサンプル.ViewModel</summary>
    Public Class CalendarViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>カレンダーで選択している日付</summary>
        Public Property SelectedDate As DateTime
            Get
                Return _SelectedDate
            End Get
            Set(value As DateTime)
                _SelectedDate = value
                CallPropertyChanged(NameOf(SelectedDate))
            End Set
        End Property

        ''' <summary>カレンダー表示範囲の最初の日付</summary>
        Public Property DisplayDateStart As DateTime

        ''' <summary>カレンダー表示範囲の最後の日付</summary>
        Public Property DisplayDateEnd As DateTime

#End Region

        ''' <summary>カレンダーで選択している日付</summary>
        Private _SelectedDate As DateTime = DateTime.Now

        ''' <summary>カレンダーサンプル.ViewModel</summary>
        Public Sub New()

            DisplayDateStart = New Date(DateTime.Now.Year, 1, 1)
            DisplayDateEnd = New Date(DateTime.Now.Year, 12, 31)

        End Sub

    End Class

End Namespace