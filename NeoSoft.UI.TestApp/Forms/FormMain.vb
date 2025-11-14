Imports NeoSoft.UI.Controls

Public Class FormMain

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' El diseño ya está configurado en el Designer
        ' Solo agregamos los manejadores de eventos aquí
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

End Class