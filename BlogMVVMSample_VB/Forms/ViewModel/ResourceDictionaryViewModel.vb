Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM

Namespace Forms.ViewModel

    ''' <summary>ResourceDictionaryによる表示言語切替.ViewModel</summary>
    Public Class ResourceDictionaryViewModel
        Inherits ViewModelBase

        ''' <summary>ResourceDictionaryのファイル名</summary>
        Private Const _FileName As String = "LanguageDictionary"

#Region "Property"

        ''' <summary>表示言語情報</summary>
        Public Property LanguageInfo As LanguageInfo = New LanguageInfo(_FileName)

        ''' <summary>選択している言語</summary>
        Private _SelectedLanguage As Languages

        ''' <summary>選択している言語</summary>
        Public Property SelectedLanguage As Languages
            Get
                Return _SelectedLanguage
            End Get
            Set(value As Languages)

                _SelectedLanguage = value

                ' 言語切替
                LanguageInfo = New LanguageInfo(_FileName, value)
                CallPropertyChanged(NameOf(LanguageInfo))

            End Set
        End Property

#End Region

        ''' <summary>ResourceDictionaryによる表示言語切替.ViewModel</summary>
        Public Sub New()

            SelectedLanguage = LanguageInfo.SelectedLanguage

        End Sub

    End Class

End Namespace