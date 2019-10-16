Imports BlogMVVMSample_VB.Data
Imports System.Collections.ObjectModel

Namespace Forms.Model

    ''' <summary>ComboBox表示サンプル.Model</summary>
    Public Class ComboBoxModel

#Region "ViewModel.Property"

        ''' <summary>学生一覧</summary>
        Public Students As ObservableCollection(Of Student)

        ''' <summary>選択中の学生</summary>
        Public SelectedStudent As Student

#End Region

        ''' <summary>ComboBox表示サンプル.Model</summary>
        Public Sub New()

            ' 一覧に初期値を設定
            Students = New ObservableCollection(Of Student) From
            {
                New Student With
                {
                    .No = 1,
                    .Name = "Aさん",
                    .Birthday = New DateTime(2000, 4, 11)
                },
                New Student With
                {
                    .No = 2,
                    .Name = "Bさん",
                    .Birthday = New DateTime(2000, 5, 4)
                },
                New Student With
                {
                    .No = 3,
                    .Name = "Cさん",
                    .Birthday = New DateTime(2000, 12, 4)
                }
            }

            ' 選択データの初期値を設定
            SelectedStudent = Students(0)

        End Sub

    End Class

End Namespace