Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.IO

Namespace Forms.ViewModel

    ''' <summary>Excel読込.ViewModel</summary>
    Public Class ExcelViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>Excel読込.Model</summary>
        Private _Model As New Model.ExcelModel

#End Region

#Region "Property"

        ''' <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        Public Property DragAndDropPaths As IList
            Get
                Return _DragAndDropPath
            End Get
            Set(value As IList)

                _DragAndDropPath = value
                FilePath = _Model.GetExcelFile(_DragAndDropPath)

            End Set
        End Property

        ''' <summary>ファイルを選択するダイアログ</summary>
        Public Property OpenDialog As CommonOpenFileDialog

        ''' <summary>ダイアログの処理結果</summary>
        Public Property DialogResult As CommonFileDialogResult

        ''' <summary>ダイアログ表示コマンド</summary>
        Public Property DialogCommand As DelegateCommand
            Get
                Return _DialogCommand
            End Get
            Private Set(value As DelegateCommand)
                _DialogCommand = value
            End Set
        End Property

        ''' <summary>ファイルパス</summary>
        Public Property FilePath As String
            Get
                Return _FilePath
            End Get
            Set(value As String)

                _FilePath = value
                CallPropertyChanged()

                Addresses = _Model.ReadExcelFile(_FilePath)
                CallPropertyChanged(NameOf(Addresses))

            End Set
        End Property

        ''' <summary>住所一覧</summary>
        Public Property Addresses As ObservableCollection(Of Address)

#End Region

        ''' <summary>ファイルパス</summary>
        Private _FilePath As String

        ''' <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        Private _DragAndDropPath As IList

        ''' <summary>ダイアログ表示コマンド</summary>
        Private _DialogCommand As DelegateCommand

        ''' <summary>Excel読込.ViewModel</summary>
        Public Sub New()

            DialogCommand = New DelegateCommand(
            Sub()

                OpenDialog = New CommonOpenFileDialog() With
                {
                    .Title = "Excelファイルを選択してください",         ' タイトル
                    .IsFolderPicker = False,                            ' フォルダ選択
                    .DefaultDirectory = Environment.CurrentDirectory,   ' 初期表示フォルダ
                    .Multiselect = False                                ' 複数選択
                }

                ' 拡張子フィルタ
                OpenDialog.Filters.Add(New CommonFileDialogFilter("Excelファイル", "*.xlsx;*.xlsm"))

                CallPropertyChanged(NameOf(OpenDialog))

                If DialogResult.Equals(CommonFileDialogResult.Ok) Then
                    FilePath = OpenDialog.FileName
                End If

            End Sub,
            Function()
                Return True
            End Function)

        End Sub

    End Class

End Namespace