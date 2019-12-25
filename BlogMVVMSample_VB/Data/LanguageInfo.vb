Imports System
Imports System.IO
Imports System.Threading
Imports System.Windows
Imports System.Windows.Markup

Namespace Data

    ''' <summary>表示言語情報</summary>
    Public Class LanguageInfo

        ''' <summary>該当言語のResourceDictionary</summary>
        Public ReadOnly Property LanguageDictionary As ResourceDictionary

        ''' <summary>選択中の言語</summary>
        Public ReadOnly Property SelectedLanguage As Languages

        ''' <summary>ResourceDictionaryの保存フォルダパス</summary>
        Private Const _LanguagePath As String = "Forms/Languages"

        ''' <summary>表示言語情報</summary>
        ''' <param name="fileName">ResourceDictionaryのファイル名</param>
        Public Sub New(fileName As String)

            ' 言語はCurrentUICultureから取得
            SelectedLanguage = Languages.English

            Select Case Thread.CurrentThread.CurrentUICulture.Name

                Case "en-US"
                    SelectedLanguage = Languages.English

                Case "ja-JP"
                    SelectedLanguage = Languages.Japanese

            End Select

            LanguageDictionary = GetResourceDictionary(_LanguagePath, fileName)

        End Sub

        ''' <summary>表示言語情報</summary>
        ''' <param name="fileName">ResourceDictionaryのファイル名</param>
        ''' <param name="selectedLanguage">選択した言語</param>
        Public Sub New(fileName As String, selectedLanguage As Languages)

            Me.SelectedLanguage = selectedLanguage
            LanguageDictionary = GetResourceDictionary(_LanguagePath, fileName)

        End Sub

        ''' <summary>表示言語情報</summary>
        ''' <param name="fileName">ResourceDictionaryのファイル名</param>
        ''' <param name="selectedLanguage">選択した言語</param>
        ''' <param name="languagePath">ResourceDictionaryの保存フォルダパス</param>
        Public Sub New(fileName As String, selectedLanguage As Languages, languagePath As String)

            Me.SelectedLanguage = selectedLanguage
            LanguageDictionary = GetResourceDictionary(languagePath, fileName)

        End Sub

        ''' <summary>ResourceDictionaryの取得</summary>
        ''' <param name="languagePath">ResourceDictionaryの保存フォルダパス</param>
        ''' <param name="fileName">ResourceDictionaryのファイル名</param>
        Private Function GetResourceDictionary(languagePath As String, fileName As String)

            ' ファイル名に拡張子を付与
            If fileName.Length <= 4 OrElse Not fileName.Substring(fileName.Length - 5, 5).ToUpper().Equals(".XAML") Then
                fileName &= ".xaml"
            End If

            ' 言語フォルダの名称取得
            Dim culture As String = Thread.CurrentThread.CurrentUICulture.Name

            Select Case SelectedLanguage

                Case Languages.English
                    culture = "en-US"

                Case Languages.Japanese
                    culture = "ja-JP"

            End Select

            ' ResourceDictionaryの取得
            Return New ResourceDictionary() With
            {
                .Source = New Uri(Path.Combine(Path.Combine(languagePath, culture), fileName), UriKind.Relative)
            }

        End Function

        ''' <summary>ResourceDictionary更新</summary>
        Public Sub UpdateResourceDictionary()

            Using writer As New StreamWriter(LanguageDictionary.Source.ToString())

                XamlWriter.Save(LanguageDictionary, writer)

            End Using

        End Sub

    End Class

End Namespace