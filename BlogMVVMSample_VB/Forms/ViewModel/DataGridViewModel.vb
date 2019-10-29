Imports BlogMVVMSample_VB.Data
Imports BlogMVVMSample_VB.MVVM
Imports System
Imports System.Collections.ObjectModel

Namespace Forms.ViewModel

    ''' <summary>DataGridサンプル.ViewModel</summary>
    Public Class DataGridViewModel
        Inherits ViewModelBase

#Region "Property"

        ''' <summary>学生一覧</summary>
        Public Property Students As ObservableCollection(Of Student)

#End Region

        ''' <summary>DataGridサンプル.ViewModel</summary>
        Public Sub New()

            Students = New ObservableCollection(Of Student) From
            {
                New Student() With {.No = 1, .Name = "Aさん", .Birthday = New DateTime(2000, 4, 11), .Gender = Gender.Male, .IsWorkNext = True, .MailAddress = "aaa@student.com"},
                New Student() With {.No = 2, .Name = "Bさん", .Birthday = New DateTime(2000, 5, 4), .Gender = Gender.Female, .IsWorkNext = False, .MailAddress = "bbb@student.com"},
                New Student() With {.No = 3, .Name = "Cさん", .Birthday = New DateTime(2000, 10, 10), .Gender = Gender.Other, .IsWorkNext = False, .MailAddress = "ccc@student.com"}
            }

        End Sub

    End Class

End Namespace