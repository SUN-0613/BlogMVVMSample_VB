Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows

Namespace UserControls

    ''' <summary>
    ''' 時間選択用UserControls
    ''' </summary>
    Public Class TimePicker
        Implements INotifyPropertyChanged

#Region "INotifyPropertyChanged"

        ''' <summary>プロパティ変更イベント</summary>
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ''' <summary>PropertyChanged()呼び出し</summary>
        ''' <param name="propertyName">イベントを発生させたいプロパティ名</param>
        Private Overloads Sub CallPropertyChanged(propertyName As String)

            ' イベント発生
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))

        End Sub

#End Region

#Region "DependencyProperty"

        ''' <summary>
        ''' 選択時間の依存プロパティ
        ''' </summary>
        Public Shared ReadOnly Property SelectedTimeProperty As DependencyProperty _
            = DependencyProperty.Register(NameOf(SelectedTime),
                                          GetType(TimeSpan),
                                          GetType(TimePicker),
                                          New FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault))

#End Region

#Region "Property"

        ''' <summary>
        ''' 選択時間
        ''' </summary>
        Public Property SelectedTime As TimeSpan
            Get
                Return DirectCast(GetValue(SelectedTimeProperty), TimeSpan)
            End Get
            Set(value As TimeSpan)

                SetValue(SelectedTimeProperty, value)

                CallPropertyChanged(NameOf(SelectedHour))
                CallPropertyChanged(NameOf(SelectedMinute))
                CallPropertyChanged(NameOf(SelectedSecond))

            End Set
        End Property

        ''' <summary>
        ''' 時間一覧
        ''' </summary>
        Public Property Hours As ObservableCollection(Of Integer) = New ObservableCollection(Of Integer)

        ''' <summary>
        ''' 分一覧
        ''' </summary>
        Public Property Minutes As ObservableCollection(Of Integer) = New ObservableCollection(Of Integer)

        ''' <summary>
        ''' 秒一覧
        ''' </summary>
        Public Property Seconds As ObservableCollection(Of Integer) = New ObservableCollection(Of Integer)

        ''' <summary>
        ''' 選択「時」
        ''' </summary>
        Public Property SelectedHour As Integer
            Get
                Return SelectedTime.Hours
            End Get
            Set(value As Integer)

                SelectedTime = New TimeSpan(value, SelectedTime.Minutes, SelectedTime.Seconds)

                CallPropertyChanged(NameOf(SelectedTime))

            End Set
        End Property

        ''' <summary>
        ''' 選択「分」
        ''' </summary>
        Public Property SelectedMinute As Integer
            Get
                Return SelectedTime.Minutes
            End Get
            Set(value As Integer)

                SelectedTime = New TimeSpan(SelectedTime.Hours, value, SelectedTime.Seconds)

                CallPropertyChanged(NameOf(SelectedTime))

            End Set
        End Property

        ''' <summary>
        ''' 選択「秒」
        ''' </summary>
        Public Property SelectedSecond As Integer
            Get
                Return SelectedTime.Seconds
            End Get
            Set(value As Integer)

                SelectedTime = New TimeSpan(SelectedTime.Hours, SelectedTime.Minutes, value)

                CallPropertyChanged(NameOf(SelectedTime))

            End Set
        End Property

#End Region

        ''' <summary>
        ''' 時間選択用UserControls
        ''' </summary>
        Public Sub New()

            InitializeComponent()

            For i As Integer = 0 To 23
                Hours.Add(i)
            Next

            For i As Integer = 0 To 59
                Minutes.Add(i)
                Seconds.Add(i)
            Next

        End Sub

    End Class

End Namespace