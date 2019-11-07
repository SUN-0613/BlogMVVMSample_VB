Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Windows
Imports System.Windows.Interactivity

Namespace Behaviors

    ''' <summary>ファイル・フォルダ操作ダイアログを表示するビヘイビア</summary>
    Public Class CommonDialogBehavior
        Inherits TriggerAction(Of FrameworkElement)

#Region "DependencyProperty"

        ''' <summary>ダイアログの処理結果の依存プロパティ</summary>
        Public Shared ReadOnly Property ResultProperty As DependencyProperty _
            = DependencyProperty.Register(NameOf(Result),
                                          GetType(CommonFileDialogResult),
                                          GetType(CommonDialogBehavior),
                                          New PropertyMetadata(CommonFileDialogResult.None))

#End Region

#Region "Property"

        ''' <summary>ダイアログの処理結果</summary>
        Public Property Result As CommonFileDialogResult
            Get
                Return DirectCast(GetValue(ResultProperty), CommonFileDialogResult)
            End Get
            Set(value As CommonFileDialogResult)
                SetValue(ResultProperty, value)
            End Set
        End Property

#End Region

        ''' <summary>ダイアログを表示</summary>
        ''' <param name="parameter"></param>
        Protected Overrides Sub Invoke(parameter As Object)

            Dim e As DependencyPropertyChangedEventArgs = parameter

            ' ファイル・フォルダを開くダイアログ
            Dim openDialog As CommonOpenFileDialog = TryCast(e.NewValue, CommonOpenFileDialog)

            If Not IsNothing(openDialog) Then

                Result = openDialog.ShowDialog()

            Else

                ' ファイルを保存するダイアログ
                Dim saveDialog As CommonSaveFileDialog = TryCast(e.NewValue, CommonSaveFileDialog)

                If Not IsNothing(saveDialog) Then

                    Result = saveDialog.ShowDialog()

                End If

            End If


        End Sub

    End Class

End Namespace