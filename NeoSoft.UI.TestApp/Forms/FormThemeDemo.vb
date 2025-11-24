Imports NeoSoft.UI.Theming
Imports NeoSoft.UI.Controls
Imports System.Windows.Forms

Public Class FormThemeDemo

#Region "Form Load"

    Private Sub FormThemeDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar temas disponibles
        NXThemeManager.Instance.InitializeBuiltInThemes()

        ' Cargar tema guardado
        Dim savedTheme As String = ThemeSettings.LoadCurrentTheme()

        ' Poblar combo con temas disponibles
        cboThemes.Items.Clear()
        For Each themeName As String In NXThemeManager.Instance.AvailableThemes.Keys
            cboThemes.Items.Add(NXThemeManager.Instance.AvailableThemes(themeName).DisplayName)
        Next

        ' Seleccionar el tema guardado
        SelectSavedTheme(savedTheme)

        ' Aplicar tema inicial
        ApplyCurrentTheme()
    End Sub

#End Region

#Region "Selección de Tema"

    Private Sub SelectSavedTheme(themeName As String)
        ' Buscar el tema en el combo
        For i As Integer = 0 To cboThemes.Items.Count - 1
            Dim displayName As String = cboThemes.Items(i).ToString()

            ' Buscar el tema por nombre interno
            For Each kvp In NXThemeManager.Instance.AvailableThemes
                If kvp.Key = themeName AndAlso kvp.Value.DisplayName = displayName Then
                    cboThemes.SelectedIndex = i
                    Return
                End If
            Next
        Next

        ' Si no se encontró, seleccionar el primero (Default)
        If cboThemes.Items.Count > 0 Then
            cboThemes.SelectedIndex = 0
        End If
    End Sub

    Private Sub CboThemes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboThemes.SelectedIndexChanged
        If cboThemes.SelectedIndex >= 0 Then
            ApplyCurrentTheme()
        End If
    End Sub

#End Region

#Region "Aplicar Tema"

    Private Sub ApplyCurrentTheme()
        If cboThemes.SelectedIndex < 0 Then Return

        Dim selectedDisplayName As String = cboThemes.SelectedItem.ToString()

        ' Encontrar el tema por DisplayName
        Dim selectedThemeName As String = ""
        For Each kvp In NXThemeManager.Instance.AvailableThemes
            If kvp.Value.DisplayName = selectedDisplayName Then
                selectedThemeName = kvp.Key
                Exit For
            End If
        Next

        If String.IsNullOrEmpty(selectedThemeName) Then Return

        ' Aplicar tema
        NXThemeManager.Instance.ApplyTheme(selectedThemeName)
        Dim theme As NXTheme = NXThemeManager.Instance.CurrentTheme

        ' Aplicar al formulario
        Me.BackColor = theme.FormBackColor
        Me.ForeColor = theme.ForeColor

        ' Aplicar a todos los controles con UseTheme
        NXThemeHelper.ApplyThemeToForm(Me, theme)

        ' Actualizar descripción
        lblThemeDescription.Text = theme.Description

        ' GUARDAR EL TEMA SELECCIONADO
        ThemeSettings.SaveCurrentTheme(selectedThemeName)

        Console.WriteLine($"✅ Tema '{theme.DisplayName}' aplicado y guardado")
    End Sub

#End Region

#Region "Botón Aplicar a Todos"

    Private Sub BtnApplyToAll_Click(sender As Object, e As EventArgs) Handles btnApplyToAll.Click
        ' Aplicar el tema actual
        ApplyCurrentTheme()

        MessageBox.Show($"Tema aplicado a todos los controles.{Environment.NewLine}" &
                       $"Este tema se recordará para futuros formularios.",
                       "Tema Aplicado",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

#End Region

End Class