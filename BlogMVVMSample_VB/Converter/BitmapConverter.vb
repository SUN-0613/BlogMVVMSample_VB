Imports System
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Interop
Imports System.Windows.Media.Imaging

Namespace Converter

    ''' <summary>BitmapをBitmapSourceへ変換</summary>
    <ValueConversion(GetType(Bitmap), GetType(BitmapSource))>
    Public Class BitmapConverter
        Implements IValueConverter

        ''' <summary>メモリ解放</summary>
        ''' <param name="hObject">対象オブジェクト</param>
        <DllImport("gdi32.dll", EntryPoint:="DeleteObject")>
        Private Shared Function DeleteObject(hObject As IntPtr) As Boolean

        End Function

        ''' <summary>Bitmap -> BitmapSource</summary>
        ''' <param name="value">The value produced by the binding source.</param>
        ''' <param name="targetType">The type of the binding target property.</param>
        ''' <param name="parameter">The converter parameter to use.</param>
        ''' <param name="culture">The culture to use in the converter.</param>
        ''' <returns>BitmapSource</returns>
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert

            Dim bitmap As Bitmap = TryCast(value, Bitmap)

            If Not IsNothing(bitmap) Then

                Dim handle As IntPtr = bitmap.GetHbitmap()

                Try

                    Return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())

                Catch ex As Exception

                    Return Nothing

                Finally

                    DeleteObject(handle)

                End Try

            Else

                Return Nothing

            End If

        End Function

        ''' <summary>BitmapSource -> Bitmap</summary>
        ''' <param name="value">The value that is produced by the binding target.</param>
        ''' <param name="targetType">The type to convert to.</param>
        ''' <param name="parameter">The converter parameter to use.</param>
        ''' <param name="culture">The culture to use in the converter.</param>
        ''' <returns>Bitmap</returns>
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack

            ' 今回は使用しない
            Throw New NotImplementedException()

        End Function
    End Class

End Namespace