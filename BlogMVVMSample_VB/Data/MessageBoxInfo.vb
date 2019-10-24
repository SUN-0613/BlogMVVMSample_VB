Imports System.Windows

Namespace Data

    ''' <summary>メッセージボックス表示内容</summary>
    Public Class MessageBoxInfo

        ''' <summary>表示するテキスト</summary>
        Public Property Message As String

        ''' <summary>表示するタイトルバー</summary>
        Public Property Title As String

        ''' <summary>表示するボタンを指定する値</summary>
        Public Property Button As MessageBoxButton = MessageBoxButton.OK

        ''' <summary>表示するアイコンを指定する値</summary>
        Public Property Image As MessageBoxImage = MessageBoxImage.None

        ''' <summary>結果の既定値</summary>
        Public Property DefaultResult As MessageBoxResult = MessageBoxResult.None

        ''' <summary>オプションを指定する値オブジェクト</summary>
        Public Property Options As MessageBoxOptions = MessageBoxOptions.None

        ''' <summary>結果</summary>
        Public Property Result As MessageBoxResult = MessageBoxResult.None

    End Class

End Namespace