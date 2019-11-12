Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>ViewModelのDisposeを行うビヘイビアの使用サンプル.ViewModel</summary>
    Public Class DisposeViewModel
        Inherits ViewModelBase
        Implements IDisposable

        ''' <summary>解放処理</summary>
        Public Sub Dispose() Implements IDisposable.Dispose

            Debug.WriteLine("Dispose()")

        End Sub

    End Class

End Namespace