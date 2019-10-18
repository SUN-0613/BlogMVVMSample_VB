Imports BlogMVVMSample_VB.Data
Imports System.Globalization

Namespace Converter

    ''' <summary>Enumの対象valueが選択されているかbool判定</summary>
    <ValueConversion(GetType(JobStatus), GetType(Boolean))>
    Public Class EnumToBoolConverter
        Implements IValueConverter

        ''' <summary>Enum -> Boolean</summary>
        ''' <param name="value">The value produced by the binding source.</param>
        ''' <param name="targetType">The type of the binding target property.</param>
        ''' <param name="parameter">The converter parameter to use.</param>
        ''' <param name="culture">The culture to use in the converter.</param>
        ''' <returns>String</returns>
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert

            Try

                If Not IsNothing(value) AndAlso Not IsNothing(parameter) Then

                    Return value.ToString().Equals(parameter.ToString())

                Else

                    Return False

                End If

            Catch ex As Exception

                Return False

            End Try

        End Function

        ''' <summary>Boolean -> Enum</summary>
        ''' <param name="value">The value that is produced by the binding target.</param>
        ''' <param name="targetType">The type to convert to.</param>
        ''' <param name="parameter">The converter parameter to use.</param>
        ''' <param name="culture">The culture to use in the converter.</param>
        ''' <returns>Enum</returns>
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack

            Try

                If Not IsNothing(value) AndAlso Not IsNothing(parameter) Then

                    Dim bool As Boolean = value

                    If bool Then

                        Return System.Enum.Parse(targetType, parameter.ToString())

                    Else

                        Return Binding.DoNothing

                    End If

                Else

                    Return Binding.DoNothing

                End If

            Catch ex As Exception

                Return Binding.DoNothing

            End Try

        End Function

    End Class

End Namespace