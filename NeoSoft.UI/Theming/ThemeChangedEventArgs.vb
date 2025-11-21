Namespace Theming

    ''' <summary>
    ''' Argumentos del evento de cambio de tema
    ''' </summary>
    Public Class ThemeChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property NewTheme As NXTheme

        Public Sub New(theme As NXTheme)
            NewTheme = theme
        End Sub

    End Class

End Namespace