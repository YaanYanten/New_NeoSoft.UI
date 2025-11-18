Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

''' <summary>
''' Editor personalizado para propiedades de tipo Image que muestra el NXImagePickerDialog
''' CORREGIDO: Maneja correctamente IWindowsFormsEditorService para evitar bloqueo de controles
''' </summary>
Public Class NXImageUITypeEditor
    Inherits UITypeEditor

#Region "Overrides - Estilo de Editor"

    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        If context IsNot Nothing AndAlso context.Instance IsNot Nothing Then
            Return UITypeEditorEditStyle.Modal
        End If
        Return UITypeEditorEditStyle.None
    End Function

#End Region

#Region "Overrides - Edición de Valor"

    Public Overrides Function EditValue(context As ITypeDescriptorContext,
                                   provider As IServiceProvider,
                                   value As Object) As Object
        If context Is Nothing OrElse provider Is Nothing Then
            Return value
        End If

        Try
            ' Crear instancia del diálogo
            Dim dlg As New NXImagePickerDialog()

            ' ⭐ CRÍTICO: Pasar el contexto del diseñador
            dlg.SetDesignerContext(context)

            ' Obtener el servicio de editor
            Dim editorService As IWindowsFormsEditorService =
            TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            Dim result As DialogResult

            If editorService IsNot Nothing Then
                ' ⭐ USAR EL SERVICIO DE EDITOR (evita bloqueo de controles)
                result = editorService.ShowDialog(dlg)
            Else
                ' Fallback para contextos donde no hay servicio de editor
                result = dlg.ShowDialog()
            End If

            ' Procesar resultado
            If result = DialogResult.OK Then
                ' ⭐ DEVOLVER Nothing SI NO HAY IMAGEN (para eliminar)
                If dlg.SelectedImage Is Nothing Then
                    Debug.WriteLine("NXImageUITypeEditor: Devolviendo Nothing (imagen eliminada)")
                    Return Nothing
                Else
                    Debug.WriteLine($"NXImageUITypeEditor: Devolviendo imagen válida")
                    Return dlg.SelectedImage
                End If
            End If

            ' Limpiar
            dlg.Dispose()

        Catch ex As Exception
            Debug.WriteLine($"Error en NXImageUITypeEditor: {ex.Message}")
            MessageBox.Show($"Error al abrir el selector de imágenes:{vbCrLf}{ex.Message}",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' ⭐ SI SE CANCELA, DEVOLVER EL VALOR ORIGINAL
        Return value
    End Function

#End Region

#Region "Overrides - Soporte de Pintura"

    Public Overrides Function GetPaintValueSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(e As PaintValueEventArgs)
        If TypeOf e.Value Is Image Then
            Dim img As Image = DirectCast(e.Value, Image)
            Try
                e.Graphics.DrawImage(img, e.Bounds)
            Catch ex As Exception
                Debug.WriteLine("Error al pintar miniatura: " & ex.Message)
            End Try
        End If
    End Sub

#End Region

End Class

#Region "Editor Alternativo - Para propiedades Icon"

Public Class NXIconUITypeEditor
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
        If context Is Nothing OrElse provider Is Nothing Then
            Return value
        End If

        Try
            Dim dialog As New NXImagePickerDialog()
            dialog.SetDesignerContext(context)

            Dim editorService As IWindowsFormsEditorService =
                TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            Dim result As DialogResult
            If editorService IsNot Nothing Then
                result = editorService.ShowDialog(dialog)
            Else
                result = dialog.ShowDialog()
            End If

            If result = DialogResult.OK Then
                If dialog.SelectedImage IsNot Nothing Then
                    Try
                        If TypeOf value Is Icon Then
                            Dim bmp As New Bitmap(dialog.SelectedImage)
                            Dim hIcon As IntPtr = bmp.GetHicon()
                            Dim icon As Icon = Icon.FromHandle(hIcon)
                            bmp.Dispose()
                            Return icon
                        Else
                            Return dialog.SelectedImage
                        End If
                    Catch ex As Exception
                        Return dialog.SelectedImage
                    End Try
                End If
            End If

            dialog.Dispose()

        Catch ex As Exception
            Debug.WriteLine($"Error en NXIconUITypeEditor: {ex.Message}")
        End Try

        Return value
    End Function

    Public Overrides Function GetPaintValueSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(e As PaintValueEventArgs)
        Try
            If TypeOf e.Value Is Icon Then
                Dim icn As Icon = DirectCast(e.Value, Icon)
                e.Graphics.DrawIcon(icn, e.Bounds)
            ElseIf TypeOf e.Value Is Image Then
                Dim img As Image = DirectCast(e.Value, Image)
                e.Graphics.DrawImage(img, e.Bounds)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error al pintar miniatura de icono: " & ex.Message)
        End Try
    End Sub

End Class

#End Region