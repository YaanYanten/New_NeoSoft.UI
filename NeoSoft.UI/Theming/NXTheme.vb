Imports System.Drawing

Namespace Theming

    ''' <summary>
    ''' Define un tema visual para los controles NX
    ''' </summary>
    Public Class NXTheme

#Region "Identificación"

        Public Property Name As String = "Default"
        Public Property DisplayName As String = "Default"
        Public Property Description As String = ""

#End Region

#Region "Colores Base"

        Public Property BackColor As Color = Color.White
        Public Property ForeColor As Color = Color.FromArgb(33, 33, 33)
        Public Property PrimaryColor As Color = Color.FromArgb(0, 120, 215)
        Public Property SecondaryColor As Color = Color.FromArgb(118, 118, 118)
        Public Property AccentColor As Color = Color.FromArgb(0, 99, 177)

#End Region

#Region "Colores de Estado"

        Public Property SuccessColor As Color = Color.FromArgb(76, 175, 80)
        Public Property WarningColor As Color = Color.FromArgb(255, 152, 0)
        Public Property ErrorColor As Color = Color.FromArgb(244, 67, 54)
        Public Property InfoColor As Color = Color.FromArgb(33, 150, 243)

#End Region

#Region "Colores de Interacción"

        Public Property BorderColor As Color = Color.FromArgb(200, 200, 200)
        Public Property DisabledColor As Color = Color.FromArgb(189, 189, 189)
        Public Property HoverColor As Color = Color.FromArgb(229, 241, 251)
        Public Property PressedColor As Color = Color.FromArgb(204, 228, 247)
        Public Property ShadowColor As Color = Color.FromArgb(100, 0, 0, 0)

#End Region

#Region "Colores de Controles Específicos"

        Public Property FormBackColor As Color = Color.FromArgb(245, 245, 245)
        Public Property PanelBackColor As Color = Color.White
        Public Property ControlBackColor As Color = Color.White
        Public Property GroupHeaderBackColor As Color = Color.FromArgb(245, 245, 245)
        Public Property GroupForeColor As Color = Color.FromArgb(33, 33, 33)

#End Region

#Region "Propiedades de Forma"

        Public Property BorderRadius As Integer = 4
        Public Property ButtonBorderRadius As Integer = 4
        Public Property TextBoxBorderRadius As Integer = 4
        Public Property GroupBorderRadius As Integer = 8

#End Region

#Region "Propiedades de Animación"

        Public Property AnimationDuration As Integer = 200

#End Region

    End Class

End Namespace