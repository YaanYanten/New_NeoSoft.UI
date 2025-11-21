Imports System.Drawing

Namespace Helpers

    ''' <summary>
    ''' Utilidades para manipulación de colores
    ''' </summary>
    Public Class ColorHelper

        ''' <summary>
        ''' Interpola entre dos colores según el progreso
        ''' </summary>
        Public Shared Function Interpolate(color1 As Color, color2 As Color, progress As Single) As Color
            Try
                ' Validar progress PRIMERO antes de cualquier logging
                If Single.IsNaN(progress) OrElse Single.IsInfinity(progress) Then
                    progress = 0
                End If
                progress = Math.Max(0.0F, Math.Min(1.0F, progress))

                ' Calcular diferencias
                Dim diffA As Integer = color2.A - color1.A
                Dim diffR As Integer = color2.R - color1.R
                Dim diffG As Integer = color2.G - color1.G
                Dim diffB As Integer = color2.B - color1.B

                ' Aplicar progreso
                Dim a As Integer = color1.A + CInt(diffA * progress)
                Dim r As Integer = color1.R + CInt(diffR * progress)
                Dim g As Integer = color1.G + CInt(diffG * progress)
                Dim b As Integer = color1.B + CInt(diffB * progress)

                ' Limitar a [0, 255]
                a = Math.Max(0, Math.Min(255, a))
                r = Math.Max(0, Math.Min(255, r))
                g = Math.Max(0, Math.Min(255, g))
                b = Math.Max(0, Math.Min(255, b))

                Return Color.FromArgb(a, r, g, b)

            Catch ex As OverflowException
                ' Fallback sin logging para evitar recursión
                Return color1
            Catch ex As Exception
                Return color1
            End Try
        End Function

        Private Shared Function ClampToByte(value As Integer) As Integer
            Return Math.Max(0, Math.Min(255, value))
        End Function

        Public Shared Function Lighten(color As Color, percent As Single) As Color
            Try
                percent = Math.Max(0, Math.Min(100, percent))
                Dim factor As Single = 1.0F + (percent / 100.0F)

                Dim r As Integer = ClampToByte(CInt(color.R * factor))
                Dim g As Integer = ClampToByte(CInt(color.G * factor))
                Dim b As Integer = ClampToByte(CInt(color.B * factor))

                Return Color.FromArgb(color.A, r, g, b)
            Catch ex As Exception
                Return color
            End Try
        End Function

        Public Shared Function Darken(color As Color, percent As Single) As Color
            Try
                percent = Math.Max(0, Math.Min(100, percent))
                Dim factor As Single = 1.0F - (percent / 100.0F)

                Dim r As Integer = ClampToByte(CInt(color.R * factor))
                Dim g As Integer = ClampToByte(CInt(color.G * factor))
                Dim b As Integer = ClampToByte(CInt(color.B * factor))

                Return Color.FromArgb(color.A, r, g, b)
            Catch ex As Exception
                Return color
            End Try
        End Function

        Public Shared Function WithOpacity(color As Color, opacity As Integer) As Color
            Try
                opacity = ClampToByte(opacity)
                Return Color.FromArgb(opacity, color.R, color.G, color.B)
            Catch ex As Exception
                Return color
            End Try
        End Function

        Public Shared Function WithOpacityPercent(color As Color, percent As Single) As Color
            Try
                percent = Math.Max(0, Math.Min(100, percent))
                Dim opacity As Integer = ClampToByte(CInt((percent / 100.0F) * 255))
                Return Color.FromArgb(opacity, color.R, color.G, color.B)
            Catch ex As Exception
                Return color
            End Try
        End Function

        Public Shared Function Blend(color1 As Color, color2 As Color, weight As Single) As Color
            Try
                weight = Math.Max(0, Math.Min(100, weight))
                Dim ratio As Single = weight / 100.0F
                Return Interpolate(color1, color2, ratio)
            Catch ex As Exception
                Return color1
            End Try
        End Function

        Public Shared Function ToGrayscale(color As Color) As Color
            Try
                Dim gray As Integer = ClampToByte(CInt(color.R * 0.299 + color.G * 0.587 + color.B * 0.114))
                Return Color.FromArgb(color.A, gray, gray, gray)
            Catch ex As Exception
                Return color
            End Try
        End Function

        Public Shared Function GetComplementary(color As Color) As Color
            Try
                Return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B)
            Catch ex As Exception
                Return color
            End Try
        End Function

        Public Shared Function IsDark(color As Color) As Boolean
            Try
                Dim luminance As Double = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255.0
                Return luminance < 0.5
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function GetContrastingTextColor(backgroundColor As Color) As Color
            Return If(IsDark(backgroundColor), Color.White, Color.Black)
        End Function

    End Class

End Namespace