﻿Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.IO

Namespace Forms.ViewModel

    ''' <summary>CSVを読み込みDataGridに表示.ViewModel</summary>
    Public Class CsvViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>CSVを読み込みDataGridに表示.Model</summary>
        Private _Model As New Model.CsvModel()

#End Region

#Region "Property"

        ''' <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        Public Property DragAndDropPaths As IList
            Get
                Return _DragAndDropPaths
            End Get
            Set(value As IList)

                _DragAndDropPaths = value
                FilePath = _Model.GetCsvFile(_DragAndDropPaths)

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

                Addresses = _Model.ReadCsvFile(_FilePath)
                CallPropertyChanged(NameOf(Addresses))

            End Set
        End Property

        ''' <summary>住所一覧</summary>
        Public Property Addresses As ObservableCollection(Of Address)

        ''' <summary>ファイルを保存するダイアログ</summary>
        Public Property SaveDialog As CommonSaveFileDialog

        ''' <summary>保存ダイアログ表示コマンド</summary>
        Public Property SaveDialogCommand As DelegateCommand
            Get
                Return _SaveDialogCommand
            End Get
            Private Set(value As DelegateCommand)
                _SaveDialogCommand = value
            End Set
        End Property

#End Region

        ''' <summary>ファイルパス</summary>
        Private _FilePath As String

        ''' <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        Private _DragAndDropPaths As IList

        ''' <summary>ダイアログ表示コマンド</summary>
        Private _DialogCommand As DelegateCommand

        ''' <summary>保存ダイアログ表示コマンド</summary>
        Private _SaveDialogCommand As DelegateCommand

        ''' <summary>CSVを読み込みDataGridに表示.ViewModel</summary>
        Public Sub New()

            DialogCommand = New DelegateCommand(
                Sub()

                    OpenDialog = New CommonOpenFileDialog() With
                    {
                        .Title = "CSVファイルを選択してください",           ' タイトル
                        .IsFolderPicker = False,                            ' フォルダ選択
                        .DefaultDirectory = Environment.CurrentDirectory,   ' 初期表示フォルダ
                        .Multiselect = False                                ' 複数選択
                    }

                    ' 拡張子フィルタ
                    OpenDialog.Filters.Add(New CommonFileDialogFilter("CSVファイル", "*.csv"))

                    CallPropertyChanged(NameOf(OpenDialog))

                    If DialogResult.Equals(CommonFileDialogResult.Ok) Then
                        FilePath = OpenDialog.FileName
                    End If

                    OpenDialog.Dispose()
                    OpenDialog = Nothing

                End Sub,
                Function()
                    Return True
                End Function)

            SaveDialogCommand = New DelegateCommand(
            Sub()

                SaveDialog = New CommonSaveFileDialog With
                {
                    .Title = "保存するファイル名を入力してください",    ' タイトル
                    .DefaultDirectory = Environment.CurrentDirectory,   ' 初期表示フォルダ
                    .DefaultFileName = "SaveFile.csv"                   ' 初期ファイル名
                }

                ' 拡張子フィルタ
                SaveDialog.Filters.Add(New CommonFileDialogFilter("CSVファイル", "*.csv"))

                CallPropertyChanged(NameOf(SaveDialog))

                If DialogResult.Equals(CommonFileDialogResult.Ok) Then
                    _Model.SaveCsvFile(SaveDialog.FileName, Addresses)
                End If

                SaveDialog.Dispose()
                SaveDialog = Nothing

            End Sub,
            Function()
                Return True
            End Function)

        End Sub

    End Class

End Namespace