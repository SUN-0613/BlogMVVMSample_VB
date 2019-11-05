Imports System
Imports System.Collections.Generic

Namespace CustomClass

    ''' <summary>List()にリソース解放処理</summary>
    ''' <typeparam name="T">型指定</typeparam>
    Public Class DisposableList(Of T)
        Inherits List(Of T)
        Implements IDisposable

        ''' <summary>解放処理</summary>
        Public Sub Dispose() Implements IDisposable.Dispose

            ' List()内要素にてリソース解放が必要なら実施
            ForEach(
                Sub(value As T)

                    Dim disposable As IDisposable = TryCast(value, IDisposable)

                    If Not IsNothing(disposable) Then
                        disposable.Dispose()
                    End If

                End Sub)

            ' List()から全ての要素を削除
            Clear()

        End Sub

    End Class

End Namespace