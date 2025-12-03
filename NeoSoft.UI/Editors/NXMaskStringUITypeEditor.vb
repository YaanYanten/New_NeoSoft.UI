Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

''' <summary>
''' Editor personalizado para la propiedad Mask con validación automática
''' </summary>
Public Class NXMaskStringUITypeEditor
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        If context IsNot Nothing AndAlso context.Instance IsNot Nothing Then
            Return UITypeEditorEditStyle.Modal
        End If
        Return UITypeEditorEditStyle.None
    End Function

    Public Overrides Function EditValue(context As ITypeDescriptorContext,
                                       provider As IServiceProvider,
                                       value As Object) As Object
        If context Is Nothing OrElse provider Is Nothing Then Return value

        Try
            Dim dlg As New NXMaskPickerDialog(NXMaskPickerDialog.MaskCategory.String)

            Dim editorService As IWindowsFormsEditorService =
                TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            Dim result As System.Windows.Forms.DialogResult = If(editorService IsNot Nothing,
                                            editorService.ShowDialog(dlg),
                                            dlg.ShowDialog())

            If result = System.Windows.Forms.DialogResult.OK Then
                ' ⭐ Solo devolver la máscara - La validación es automática en NXMaskedTextBox
                Debug.WriteLine($"✅ Máscara aplicada: {dlg.SelectedMask}")
                Return dlg.SelectedMask
            End If

            dlg.Dispose()
        Catch ex As Exception
            Debug.WriteLine($"❌ Error en NXMaskUITypeEditor: {ex.Message}")
            System.Windows.Forms.MessageBox.Show($"Error al aplicar máscara: {ex.Message}", "Error",
                                                 System.Windows.Forms.MessageBoxButtons.OK,
                                                 System.Windows.Forms.MessageBoxIcon.Error)
        End Try

        Return value
    End Function

End Class