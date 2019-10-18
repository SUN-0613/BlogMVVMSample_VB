Imports BlogMVVMSample_VB.Data
Imports System.Globalization

Namespace Converter

    ''' <summary>Enumのvalueをstringに変換</summary>
    <ValueConversion(GetType(JobStatus), GetType(String))>
    Public Class JobStatusConverter
        Implements IValueConverter

        ''' <summary>Enum -> String</summary>
        ''' <param name="value">The value produced by the binding source.</param>
        ''' <param name="targetType">The type of the binding target property.</param>
        ''' <param name="parameter">The converter parameter to use.</param>
        ''' <param name="culture">The culture to use in the converter.</param>
        ''' <returns>String</returns>
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert

            Try

                Dim job As JobStatus = value

                Select Case job

                    Case JobStatus.NotOrdered
                        Return "未注"

                    Case JobStatus.Ordered
                        Return "受注"

                    Case JobStatus.Delivery
                        Return "納品"

                    Case JobStatus.Finished
                        Return "完了"

                    Case Else
                        Return ""

                End Select

            Catch ex As Exception

                Return ""

            End Try

        End Function

        ''' <summary>String -> Enum</summary>
        ''' <param name="value">The value that is produced by the binding target.</param>
        ''' <param name="targetType">The type to convert to.</param>
        ''' <param name="parameter">The converter parameter to use.</param>
        ''' <param name="culture">The culture to use in the converter.</param>
        ''' <returns>Enum</returns>
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack

            Try

                Dim str As String = value

                Select Case str

                    Case "受注"
                        Return JobStatus.NotOrdered

                    Case "受注"
                        Return JobStatus.Ordered

                    Case "納品"
                        Return JobStatus.Delivery

                    Case "完了"
                        Return JobStatus.Finished

                    Case Else
                        Return JobStatus.NotOrdered

                End Select

            Catch ex As Exception

                Return JobStatus.NotOrdered

            End Try

        End Function

    End Class

End Namespace

