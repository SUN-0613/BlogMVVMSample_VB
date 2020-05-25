Imports BlogMVVMSample_VB.MVVM
Imports System

Namespace Forms.ViewModel

    ''' <summary>
    ''' UserControlのTimePickerサンプルViewModel
    ''' </summary>
    Public Class TimePickerViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>
        ''' 選択時間
        ''' </summary>
        Private _SelectedTime As TimeSpan = DateTime.Now.TimeOfDay

        Public Property SelectedTime As TimeSpan
            Get
                Return _SelectedTime
            End Get
            Set(value As TimeSpan)

                _SelectedTime = value
                CallPropertyChanged()

            End Set
        End Property

#End Region

    End Class

End Namespace