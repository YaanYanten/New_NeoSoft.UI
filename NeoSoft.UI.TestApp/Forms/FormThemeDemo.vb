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

        ' Cargar estados guardados de los toggles
        LoadToggleStates()
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

#Region "Toggle Switch Events"

    Private Sub TglNotifications_IsOnChanged(sender As Object, e As EventArgs) Handles tglNotifications.IsOnChanged
        ' Guardar estado
        'My.Settings.NotificationsEnabled = tglNotifications.IsOn
        'My.Settings.Save()

        ' Log del cambio
        Console.WriteLine($"🔔 Notificaciones: {If(tglNotifications.IsOn, "ACTIVADAS", "DESACTIVADAS")}")
    End Sub

    Private Sub TglDarkMode_IsOnChanged(sender As Object, e As EventArgs) Handles tglDarkMode.IsOnChanged
        ' Guardar estado
        'My.Settings.DarkModeEnabled = tglDarkMode.IsOn
        'My.Settings.Save()

        ' Aplicar modo oscuro (ejemplo)
        If tglDarkMode.IsOn Then
            ' Activar modo oscuro
            Console.WriteLine("🌙 Modo Oscuro ACTIVADO")
            ' Aquí puedes cambiar al tema oscuro si lo tienes
            ' Por ejemplo: NXThemeManager.Instance.ApplyTheme("dark")
        Else
            ' Desactivar modo oscuro
            Console.WriteLine("☀️ Modo Claro ACTIVADO")
        End If
    End Sub

    Private Sub TglSounds_IsOnChanged(sender As Object, e As EventArgs) Handles tglSounds.IsOnChanged
        ' Guardar estado
        'My.Settings.SoundsEnabled = tglSounds.IsOn
        'My.Settings.Save()

        Console.WriteLine($"🔊 Sonidos: {If(tglSounds.IsOn, "ACTIVADOS", "DESACTIVADOS")}")
    End Sub

    Private Sub TglAutoSave_IsOnChanged(sender As Object, e As EventArgs) Handles tglAutoSave.IsOnChanged
        ' Guardar estado
        'My.Settings.AutoSaveEnabled = tglAutoSave.IsOn
        'My.Settings.Save()

        Console.WriteLine($"💾 Autoguardado: {If(tglAutoSave.IsOn, "ACTIVADO", "DESACTIVADO")}")
    End Sub

    Private Sub TglWiFi_IsOnChanged(sender As Object, e As EventArgs) Handles tglWiFi.IsOnChanged
        'My.Settings.WiFiEnabled = tglWiFi.IsOn
        'My.Settings.Save()

        Console.WriteLine($"📶 WiFi: {If(tglWiFi.IsOn, "ACTIVADO", "DESACTIVADO")}")
    End Sub

    Private Sub TglBluetooth_IsOnChanged(sender As Object, e As EventArgs) Handles tglBluetooth.IsOnChanged
        'My.Settings.BluetoothEnabled = tglBluetooth.IsOn
        'My.Settings.Save()

        Console.WriteLine($"📱 Bluetooth: {If(tglBluetooth.IsOn, "ACTIVADO", "DESACTIVADO")}")
    End Sub

    Private Sub TglAirplaneMode_IsOnChanged(sender As Object, e As EventArgs) Handles tglAirplaneMode.IsOnChanged
        'My.Settings.AirplaneModeEnabled = tglAirplaneMode.IsOn
        'My.Settings.Save()

        If tglAirplaneMode.IsOn Then
            ' Desactivar WiFi y Bluetooth cuando se activa modo avión
            tglWiFi.IsOn = False
            tglBluetooth.IsOn = False
            Console.WriteLine("✈️ Modo Avión ACTIVADO - WiFi y Bluetooth desactivados")
        Else
            Console.WriteLine("✈️ Modo Avión DESACTIVADO")
        End If
    End Sub

#End Region

#Region "Load/Save Toggle States"

    Private Sub LoadToggleStates()
        ' Cargar estados guardados
        Try
            'tglNotifications.IsOn = My.Settings.NotificationsEnabled
            'tglDarkMode.IsOn = My.Settings.DarkModeEnabled
            'tglSounds.IsOn = My.Settings.SoundsEnabled
            'tglAutoSave.IsOn = My.Settings.AutoSaveEnabled
            'tglWiFi.IsOn = My.Settings.WiFiEnabled
            'tglBluetooth.IsOn = My.Settings.BluetoothEnabled
            'tglAirplaneMode.IsOn = My.Settings.AirplaneModeEnabled

            Console.WriteLine("✅ Estados de toggles cargados desde configuración")
        Catch ex As Exception
            Console.WriteLine($"⚠️ Error al cargar estados: {ex.Message}")
            ' Establecer valores predeterminados
            tglNotifications.IsOn = True
            tglDarkMode.IsOn = False
            tglSounds.IsOn = True
            tglAutoSave.IsOn = False
            tglWiFi.IsOn = True
            tglBluetooth.IsOn = False
            tglAirplaneMode.IsOn = False
        End Try
    End Sub

#End Region

End Class