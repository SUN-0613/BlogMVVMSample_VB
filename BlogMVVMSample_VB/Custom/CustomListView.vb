Imports System.Collections
Imports System.Windows
Imports System.Windows.Controls

Namespace Custom

    ''' <summary>
    ''' ListViewカスタマイズ
    ''' Binding可能なSelectedItemsを追加
    ''' </summary>
    Public Class CustomListView
        Inherits ListView

#Region "DependencyProperty"

        ''' <summary>SelectedItems依存プロパティ</summary>
        Public Shared ReadOnly CustomSelectedItemsProperty As DependencyProperty _
            = DependencyProperty.Register(
            NameOf(CustomSelectedItems),
            GetType(IList),
            GetType(CustomListView),
            New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault))

#End Region

#Region "Property"

        ''' <summary>SelectedItemsプロパティ</summary>
        Public Property CustomSelectedItems As IList
            Get
                Return DirectCast(GetValue(CustomSelectedItemsProperty), IList)
            End Get
            Set(value As IList)
                SetValue(CustomSelectedItemsProperty, value)
            End Set
        End Property

#End Region

#Region "Event"

        ''' <summary>SelectedItems変更イベント</summary>
        ''' <param name="e">変更イベントデータ</param>
        Protected Overrides Sub OnSelectionChanged(e As SelectionChangedEventArgs)

            MyBase.OnSelectionChanged(e)

            ' 作成したプロパティにセット
            SetValue(CustomSelectedItemsProperty, SelectedItems)

        End Sub

#End Region

    End Class

End Namespace