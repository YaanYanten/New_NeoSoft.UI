Imports NeoSoft.UI.Controls
Imports NeoSoft.UI.Theming

Public Class FormThemeDemo

    Public Sub New()
        InitializeComponent()

        ' Inicializar temas predefinidos
        NXThemeManager.Instance.InitializeBuiltInThemes()

        ' Cargar lista de temas
        LoadThemes()

        ' Suscribirse al evento de cambio de tema
        AddHandler NXThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

        ' Aplicar tema inicial
        ApplyCurrentTheme()
    End Sub

    Private Sub LoadThemes()
        cboThemes.Items.Clear()

        For Each themeName As String In NXThemeManager.Instance.AvailableThemes.Keys
            Dim theme As NXTheme = NXThemeManager.Instance.AvailableThemes(themeName)
            cboThemes.Items.Add(theme.DisplayName)
        Next

        cboThemes.SelectedIndex = 0
    End Sub

    Private Sub CboThemes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboThemes.SelectedIndexChanged
        If cboThemes.SelectedIndex >= 0 Then
            Dim themeName As String = GetThemeKeyByDisplayName(cboThemes.SelectedItem.ToString())
            NXThemeManager.Instance.ApplyTheme(themeName)
        End If
    End Sub

    Private Function GetThemeKeyByDisplayName(displayName As String) As String
        For Each kvp In NXThemeManager.Instance.AvailableThemes
            If kvp.Value.DisplayName = displayName Then
                Return kvp.Key
            End If
        Next
        Return "Default"
    End Function

    Private Sub OnThemeChanged(sender As Object, e As ThemeChangedEventArgs)
        ApplyCurrentTheme()
    End Sub

    Private Sub ApplyCurrentTheme()
        Dim theme As NXTheme = NXThemeManager.Instance.CurrentTheme

        ' Aplicar al formulario
        Me.BackColor = theme.FormBackColor
        Me.ForeColor = theme.ForeColor

        ' Actualizar descripción del tema
        lblThemeDescription.Text = theme.Description

        ' Aplicar a todos los controles con UseTheme = True
        NXThemeHelper.ApplyThemeToForm(Me, theme)
    End Sub

    Private Sub BtnApplyToAll_Click(sender As Object, e As EventArgs) Handles btnApplyToAll.Click
        ' Habilitar UseTheme en todos los controles
        NXThemeHelper.EnableThemeOnAllControls(Me)
        ApplyCurrentTheme()
        MessageBox.Show("Tema aplicado a todos los controles", "NeoSoft.UI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#Region "Radio Button Events"

    Private Sub GrpGender_SelectedChanged() Handles grpGender.ControlAdded, grpGender.ControlRemoved
        ' Se puede usar para detectar cambios en el grupo
        UpdateGenderSelection()
    End Sub

    Private Sub RdoMale_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMale.CheckedChanged
        If rdoMale.Checked Then
            UpdateGenderSelection()
        End If
    End Sub

    Private Sub RdoFemale_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFemale.CheckedChanged
        If rdoFemale.Checked Then
            UpdateGenderSelection()
        End If
    End Sub

    Private Sub RdoOther_CheckedChanged(sender As Object, e As EventArgs) Handles rdoOther.CheckedChanged
        If rdoOther.Checked Then
            UpdateGenderSelection()
        End If
    End Sub

    Private Sub UpdateGenderSelection()
        Dim selected = grpGender.SelectedRadioButton
        If selected IsNot Nothing Then
            Console.WriteLine($"Género seleccionado: {selected.Text}")
        End If
    End Sub

    Private Sub RdoCreditCard_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCreditCard.CheckedChanged
        If rdoCreditCard.Checked Then
            UpdatePaymentSelection()
        End If
    End Sub

    Private Sub RdoDebitCard_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDebitCard.CheckedChanged
        If rdoDebitCard.Checked Then
            UpdatePaymentSelection()
        End If
    End Sub

    Private Sub RdoCash_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCash.CheckedChanged
        If rdoCash.Checked Then
            UpdatePaymentSelection()
        End If
    End Sub

    Private Sub RdoTransfer_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTransfer.CheckedChanged
        If rdoTransfer.Checked Then
            UpdatePaymentSelection()
        End If
    End Sub

    Private Sub UpdatePaymentSelection()
        Dim selected = grpPayment.SelectedRadioButton
        If selected IsNot Nothing Then
            Console.WriteLine($"Método de pago seleccionado: {selected.Text}")
            ' Aquí podrías mostrar/ocultar campos según el método de pago
            Select Case grpPayment.SelectedIndex
                Case 0 ' Tarjeta de Crédito
                ' Mostrar campos de tarjeta
                Case 1 ' Tarjeta de Débito
                ' Mostrar campos de tarjeta
                Case 2 ' Efectivo
                ' Ocultar campos de tarjeta
                Case 3 ' Transferencia
                    ' Mostrar campos de transferencia
            End Select
        End If
    End Sub

#End Region

End Class