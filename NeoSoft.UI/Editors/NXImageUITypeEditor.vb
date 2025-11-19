Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

''' <summary>
''' Editor personalizado para propiedades de tipo Image que muestra el NXImagePickerDialog
''' </summary>
Public Class NXImageUITypeEditor
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
            Dim dlg As New NXImagePickerDialog()
            dlg.SetDesignerContext(context)

            Dim editorService As IWindowsFormsEditorService =
                TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            Dim result As DialogResult = If(editorService IsNot Nothing,
                                            editorService.ShowDialog(dlg),
                                            dlg.ShowDialog())

            If result = DialogResult.OK Then
                Return dlg.SelectedImage ' Puede ser Nothing para eliminar imagen
            End If

            dlg.Dispose()
        Catch ex As Exception
            Debug.WriteLine($"Error en NXImageUITypeEditor: {ex.Message}")
        End Try

        Return value
    End Function

    Public Overrides Function GetPaintValueSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(e As PaintValueEventArgs)
        If TypeOf e.Value Is Image Then
            Try
                e.Graphics.DrawImage(DirectCast(e.Value, Image), e.Bounds)
            Catch ex As Exception
                Debug.WriteLine($"Error al pintar miniatura: {ex.Message}")
            End Try
        End If
    End Sub

End Class

''' <summary>
''' Editor personalizado para propiedades de tipo Icon
''' </summary>
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
        If context Is Nothing OrElse provider Is Nothing Then Return value

        Try
            Dim dialog As New NXImagePickerDialog()
            dialog.SetDesignerContext(context)

            Dim editorService As IWindowsFormsEditorService =
                TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            Dim result As DialogResult = If(editorService IsNot Nothing,
                                            editorService.ShowDialog(dialog),
                                            dialog.ShowDialog())

            If result = DialogResult.OK AndAlso dialog.SelectedImage IsNot Nothing Then
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
                e.Graphics.DrawIcon(DirectCast(e.Value, Icon), e.Bounds)
            ElseIf TypeOf e.Value Is Image Then
                e.Graphics.DrawImage(DirectCast(e.Value, Image), e.Bounds)
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error al pintar miniatura de icono: {ex.Message}")
        End Try
    End Sub

End Class