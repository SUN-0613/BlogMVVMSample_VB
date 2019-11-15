Imports BlogMVVMSample_VB.MVVM
Imports System.Collections.ObjectModel
Imports System.Threading.Tasks

Namespace Forms.ViewModel

    ''' <summary>Callbackサンプル.ViewModel</summary>
    Public Class CallbackViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>Callbackサンプル.Model</summary>
        Private _Model As New Model.CallbackModel()

#End Region

#Region "Property"

        ''' <summary>カウントダウン</summary>
        Public Property CountDown As Integer
            Get
                Return _CountDown
            End Get
            Private Set(value As Integer)
                _CountDown = value
            End Set
        End Property

        ''' <summary>数値一覧</summary>
        Public Property Values As ObservableCollection(Of Integer)
            Get
                Return _Values
            End Get
            Private Set(value As ObservableCollection(Of Integer))
                _Values = value
            End Set
        End Property

        ''' <summary>一覧作成コマンド</summary>
        Public ReadOnly Property MakeListCommand As DelegateCommand

#End Region

        ''' <summary>カウントダウン</summary>
        Private _CountDown As Integer

        ''' <summary>数値一覧</summary>
        Private _Values As New ObservableCollection(Of Integer)

        ''' <summary>Callbackサンプル.ViewModel</summary>
        Public Sub New()

            MakeListCommand = New DelegateCommand(
                Sub()

                    ' メモリ解放
                    If Not IsNothing(Values) Then

                        Values.Clear()
                        Values = Nothing

                    End If

                    Task.Run(
                    Sub()

                        Values = _Model.MakeCollection(AddressOf CountDownCallback)
                        CallPropertyChanged(NameOf(Values))

                    End Sub)

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

        ''' <summary>コールバックメソッド</summary>
        ''' <param name="value">経過秒数</param>
        Public Sub CountDownCallback(value As Integer)

            CountDown = value
            CallPropertyChanged(NameOf(CountDown))

        End Sub

    End Class

End Namespace