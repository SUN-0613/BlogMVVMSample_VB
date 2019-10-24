Imports BlogMVVMSample_VB.Data
Imports System.Windows
Imports System.Windows.Interactivity

Namespace Behaviors

    ''' <summary>MessageBoxを表示するためのビヘイビア</summary>
    Public Class MessageBoxBehavior
        Inherits TriggerAction(Of FrameworkElement)

        ''' <summary>MessageBoxを表示</summary>
        ''' <param name="parameter">MessageBoxInfoプロパティ更新イベントデータ</param>
        Protected Overrides Sub Invoke(parameter As Object)

            Dim e As DependencyPropertyChangedEventArgs = parameter
            Dim info As MessageBoxInfo = DirectCast(e.NewValue, MessageBoxInfo)

            info.Result = MessageBox.Show(info.Message, info.Title, info.Button, info.Image, info.DefaultResult, info.Options)

        End Sub

    End Class

End Namespace