Imports NeoSoft.UI.Controls

Public Class FormMain

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ⭐ YA NO ES NECESARIO - Todo se configura automáticamente desde el diseñador
    End Sub

    Private Sub btnSolid_Click(sender As Object, e As EventArgs) Handles btnSolid.Click
        MessageBox.Show($"¡Hiciste clic en: {btnSolid.Text}!", "NeoSoft.UI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnGradient_Click(sender As Object, e As EventArgs) Handles btnGradient.Click
        MessageBox.Show($"¡Hiciste clic en: {btnGradient.Text}!", "NeoSoft.UI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnOutline_Click(sender As Object, e As EventArgs) Handles btnOutline.Click
        MessageBox.Show($"¡Hiciste clic en: {btnOutline.Text}!", "NeoSoft.UI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRounded_Click(sender As Object, e As EventArgs) Handles btnRounded.Click
        MessageBox.Show($"¡Hiciste clic en: {btnRounded.Text}!", "NeoSoft.UI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSquare_Click(sender As Object, e As EventArgs) Handles btnSquare.Click
        MessageBox.Show($"¡Hiciste clic en: {btnSquare.Text}!", "NeoSoft.UI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnImagePicker_Click(sender As Object, e As EventArgs) Handles btnImagePicker.Click
        Using dialog As New NXImagePickerDialog()
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                If dialog.SelectedImage IsNot Nothing Then
                    MessageBox.Show($"Imagen seleccionada desde: {dialog.SelectedImageSource}" & vbCrLf &
                                  $"Ruta: {dialog.SelectedImagePath}",
                                  "Imagen Seleccionada",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim resultados As New System.Text.StringBuilder()
        resultados.AppendLine("=== VALIDACIÓN DE MÁSCARAS ===")
        resultados.AppendLine()
        resultados.AppendLine($"📅 Fecha: {txtNormal.Text}")
        resultados.AppendLine($"📞 Teléfono: {txtError.Text}")
        resultados.AppendLine($"🕐 Hora: {txtSuccess.Text}")
        resultados.AppendLine($"📮 ZIP: {txtUnderline.Text}")

        MessageBox.Show(resultados.ToString(), "Valores Actuales",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ChkSwitch_CheckedChanged(sender As Object, e As EventArgs) Handles chkSwitch.CheckedChanged
        Debug.WriteLine($"Switch cambió a: {chkSwitch.Checked}")
    End Sub

    Private Sub BtnThemeDemo_Click(sender As Object, e As EventArgs) Handles btnThemeDemo.Click
        Dim frmTheme As New FormThemeDemo()
        frmTheme.ShowDialog()
    End Sub

    Private Sub btnProgressDemo_Click(sender As Object, e As EventArgs) Handles btnProgressDemo.Click
        Dim frmPrgDemo As New FormProgressBarDemo()
        frmPrgDemo.ShowDialog()
    End Sub
End Class