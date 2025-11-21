Namespace Theming

    ''' <summary>
    ''' Interfaz que deben implementar los controles que soporten temas
    ''' </summary>
    Public Interface IThemeable

        ''' <summary>
        ''' Aplica un tema al control
        ''' </summary>
        Sub ApplyTheme(theme As NXTheme)

        ''' <summary>
        ''' Indica si el control usa temas automáticamente
        ''' </summary>
        Property UseTheme As Boolean

    End Interface

End Namespace