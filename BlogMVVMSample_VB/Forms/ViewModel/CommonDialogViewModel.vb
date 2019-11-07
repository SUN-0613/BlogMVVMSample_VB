Imports BlogMVVMSample_VB.MVVM
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System
Imports System.Collections.ObjectModel

Namespace Forms.ViewModel

    ''' <summary>WindowsAPICodePackダイアログ表示.ViewModel</summary>
    Public Class CommonDialogViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>WindowsAPICodePackダイアログ表示.Model</summary>
        Private _Model As New Model.CommonDialogModel

#End Region

#Region "Property"

        ''' <summary>ファイル・フォルダを選択するダイアログ</summary>
        Public Property OpenDialog As CommonOpenFileDialog

        ''' <summary>ファイルを保存するダイアログ</summary>
        Public Property SaveDialog As CommonSaveFileDialog

        ''' <summary>ダイアログの処理結果</summary>
        Public Property DialogResult As CommonFileDialogResult

        ''' <summary>ダイアログ表示コマンド</summary>
        Public Property DialogCommand As DelegateCommand(Of String)

        ''' <summary>選択されたファイル一覧</summary>
        Public Property Files As New ObservableCollection(Of String)

#End Region

        ''' <summary>WindowsAPICodePackダイアログ表示.ViewModel</summary>
        Public Sub New()

            DialogCommand = New DelegateCommand(Of String)(
            Sub(parameter)

                Select Case parameter

                    Case "openFile"     ' ファイルを選択

                        OpenDialog = New CommonOpenFileDialog() With
                        {
                            .Title = "ファイルを選択してください",              ' タイトル
                            .IsFolderPicker = False,                            ' フォルダ選択
                            .DefaultDirectory = Environment.CurrentDirectory,   ' 初期表示
                            .Multiselect = True                                 ' 複数選択
                        }

                        ' 拡張子フィルタ
                        OpenDialog.Filters.Add(New CommonFileDialogFilter("全てのファイル", "*.*"))

                        CallPropertyChanged(NameOf(OpenDialog))

                        If DialogResult.Equals(CommonFileDialogResult.Ok) Then

                            Files.Clear()
                            Files = _Model.GetFiles(OpenDialog.FileNames)

                            CallPropertyChanged(NameOf(Files))

                        End If

                    Case "openFolder"   ' フォルダを選択

                        OpenDialog = New CommonOpenFileDialog() With
                        {
                            .Title = "フォルダを選択してください",              ' タイトル
                            .IsFolderPicker = True,                             ' フォルダ選択
                            .DefaultDirectory = Environment.CurrentDirectory,   ' 初期表示
                            .Multiselect = False                                ' 複数選択
                        }

                        CallPropertyChanged(NameOf(OpenDialog))

                        If DialogResult.Equals(CommonFileDialogResult.Ok) Then

                            Files.Clear()
                            Files = _Model.GetFiles(OpenDialog.FileName)

                            CallPropertyChanged(NameOf(Files))

                        End If

                    Case "saveFile"     ' ファイルを保存

                        SaveDialog = New CommonSaveFileDialog() With
                        {
                            .Title = "保存するファイル名を入力してください",    ' タイトル 
                            .DefaultDirectory = Environment.CurrentDirectory,   ' 初期表示
                            .DefaultFileName = "SaveFile.txt"                   ' 初期ファイル名
                        }

                        ' 拡張子フィルタ
                        SaveDialog.Filters.Add(New CommonFileDialogFilter("全てのファイル", "*.*"))

                        CallPropertyChanged(NameOf(SaveDialog))

                        If DialogResult.Equals(CommonFileDialogResult.Ok) Then
                            _Model.SaveFile(SaveDialog.FileName)
                        End If

                End Select

            End Sub,
            Function()
                Return True
            End Function)

        End Sub

    End Class

End Namespace