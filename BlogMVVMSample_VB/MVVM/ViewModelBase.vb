Imports System.ComponentModel

Namespace MVVM

    ''' <summary>ViewModel.ベースクラス</summary>
    Public MustInherit Class ViewModelBase
        Implements INotifyPropertyChanged

        ''' <summary>プロパティ変更イベント</summary>
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ''' <summary>PropertyChanged()呼び出し</summary>
        Protected Overridable Overloads Sub CallPropertyChanged()

            ' 呼び出し元メソッド名をプロパティ名として取得
            Dim caller As StackFrame = New StackFrame(1)                    ' 呼び出し元メソッド情報
            Dim methodNames As String() = caller.GetMethod().Name.Split("_") ' 呼び出し元メソッド名
            Dim propertyName As String = methodNames(methodNames.Length - 1)

            CallPropertyChanged(propertyName)

        End Sub

        ''' <summary>PropertyChanged()呼び出し</summary>
        ''' <param name="propertyName">イベントを発生させたいプロパティ名</param>
        Protected Overloads Sub CallPropertyChanged(propertyName As String)

            ' イベント発生
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))

        End Sub

    End Class

End Namespace