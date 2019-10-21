Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace Custom

    ''' <summary>
    ''' TreeViewカスタマイズ
    ''' Binding可能なSelectedItemを追加
    ''' </summary>
    Public Class CustomTreeView
        Inherits TreeView

#Region "DependencyProperty"

        ''' <summary>SelectedItem依存プロパティ</summary>
        Public Shared ReadOnly CustomSelectedItemProperty As DependencyProperty _
            = DependencyProperty.Register(
                NameOf(CustomSelectedItem) _
                , GetType(Object) _
                , GetType(CustomTreeView) _
                , New UIPropertyMetadata(Nothing))

#End Region

#Region "Property"

        ''' <summary>SelectedItemプロパティ</summary>
        Public Property CustomSelectedItem As Object
            Get
                Return GetValue(CustomSelectedItemProperty)
            End Get
            Set(value As Object)
                SetValue(CustomSelectedItemProperty, value)
            End Set
        End Property

#End Region

#Region "Event"

        ''' <summary>SelectedItem変更イベント</summary>
        Protected Overrides Sub OnSelectedItemChanged(e As RoutedPropertyChangedEventArgs(Of Object))

            MyBase.OnSelectedItemChanged(e)

            ' 作成したプロパティにセット
            SetValue(CustomSelectedItemProperty, SelectedItem)

        End Sub

#End Region

    End Class

End Namespace