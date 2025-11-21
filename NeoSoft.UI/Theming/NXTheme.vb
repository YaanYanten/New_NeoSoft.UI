Imports System.Drawing

Namespace Theming

    ''' <summary>
    ''' Representa un tema visual para controles NX
    ''' </summary>
    Public Class NXTheme

        Public Property Name As String
        Public Property DisplayName As String
        Public Property Description As String

        ' Colores base
        Public Property BackColor As Color
        Public Property ForeColor As Color
        Public Property PrimaryColor As Color
        Public Property SecondaryColor As Color
        Public Property AccentColor As Color

        ' Colores de estado
        Public Property SuccessColor As Color
        Public Property WarningColor As Color
        Public Property ErrorColor As Color
        Public Property InfoColor As Color

        ' Colores de interacción
        Public Property BorderColor As Color
        Public Property DisabledColor As Color
        Public Property HoverColor As Color
        Public Property PressedColor As Color
        Public Property ShadowColor As Color

        ' Colores de contenedores
        Public Property FormBackColor As Color
        Public Property PanelBackColor As Color

        ' Configuración de bordes
        Public Property BorderRadius As Integer
        Public Property ButtonBorderRadius As Integer
        Public Property TextBoxBorderRadius As Integer

        ' Animaciones
        Public Property AnimationDuration As Integer

        ''' <summary>
        ''' Clona el tema actual
        ''' </summary>
        Public Function Clone() As NXTheme
            Return DirectCast(Me.MemberwiseClone(), NXTheme)
        End Function

    End Class

End Namespace