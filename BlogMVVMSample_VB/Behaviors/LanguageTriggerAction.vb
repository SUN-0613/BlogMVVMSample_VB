Imports BlogMVVMSample_VB.Data
Imports System.IO
Imports System.Windows
Imports System.Windows.Interactivity

Namespace Behaviors

    ''' <summary>言語変更トリガアクション</summary>
    Public Class LanguageTriggerAction
        Inherits TriggerAction(Of FrameworkElement)

        ''' <summary>言語を変更</summary>
        ''' <param name="parameter">LanguageInfoクラス</param>
        Protected Overrides Sub Invoke(parameter As Object)

            Dim e As DependencyPropertyChangedEventArgs = parameter
            Dim info As LanguageInfo = e.NewValue

            ' MergedDictionariesより同ファイル名のindexを検索する
            Dim index As Integer = -1
            Dim fileName As String = Path.GetFileName(info.LanguageDictionary.Source.OriginalString)

            For i As Integer = 0 To AssociatedObject.Resources.MergedDictionaries.Count

                If Path.GetFileName(AssociatedObject.Resources.MergedDictionaries(i).Source.OriginalString).Equals(fileName) Then
                    index = i
                    Exit For
                End If

            Next

            If index.Equals(-1) Then

                ' MergedDictionaries未登録なら追加
                AssociatedObject.Resources.MergedDictionaries.Add(info.LanguageDictionary)

            Else

                ' 新規言語に切替
                AssociatedObject.Resources.MergedDictionaries(index) = info.LanguageDictionary

            End If

        End Sub

    End Class

End Namespace