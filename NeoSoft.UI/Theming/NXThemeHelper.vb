Imports System.Windows.Forms

Namespace Theming

    ''' <summary>
    ''' Helper para aplicar temas a formularios y contenedores
    ''' </summary>
    Public Class NXThemeHelper

        ''' <summary>
        ''' Aplica un tema a un formulario y todos sus controles con UseTheme = True
        ''' </summary>
        Public Shared Sub ApplyThemeToForm(form As Form, theme As NXTheme)
            ' Aplicar al formulario
            form.BackColor = theme.FormBackColor
            form.ForeColor = theme.ForeColor

            ' Aplicar a todos los controles recursivamente
            ApplyThemeToControls(form.Controls, theme)
        End Sub

        ''' <summary>
        ''' Aplica un tema a una colección de controles recursivamente
        ''' </summary>
        Public Shared Sub ApplyThemeToControls(controls As Control.ControlCollection, theme As NXTheme)
            For Each ctrl As Control In controls
                ' Si el control implementa IThemeable y UseTheme está activo
                If TypeOf ctrl Is IThemeable Then
                    Dim themeable As IThemeable = DirectCast(ctrl, IThemeable)
                    If themeable.UseTheme Then
                        themeable.ApplyTheme(theme)
                    End If
                End If

                ' Aplicar a controles hijos recursivamente
                If ctrl.HasChildren Then
                    ApplyThemeToControls(ctrl.Controls, theme)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Habilita UseTheme en todos los controles NX de un formulario
        ''' </summary>
        Public Shared Sub EnableThemeOnAllControls(form As Form)
            EnableThemeOnControls(form.Controls)
        End Sub

        Private Shared Sub EnableThemeOnControls(controls As Control.ControlCollection)
            For Each ctrl As Control In controls
                If TypeOf ctrl Is IThemeable Then
                    DirectCast(ctrl, IThemeable).UseTheme = True
                End If

                If ctrl.HasChildren Then
                    EnableThemeOnControls(ctrl.Controls)
                End If
            Next
        End Sub

    End Class

End Namespace