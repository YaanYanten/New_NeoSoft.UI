Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class NXImageUITypeEditor
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.Modal
    End Function

    Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        If provider IsNot Nothing Then
            Dim editorService = TryCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            If editorService IsNot Nothing Then
                Using dlg As New NXImagePickerDialog()
                    If dlg.ShowDialog() = DialogResult.OK Then
                        Dim selectedImage As Image = dlg.SelectedImage

                        If selectedImage IsNot Nothing Then
                            If dlg.SelectedImageSource = NXImagePickerDialog.ImageSource.LocalResource Then
                                Dim bmp As New Bitmap(selectedImage)
                                Return bmp
                            ElseIf dlg.SelectedImageSource = NXImagePickerDialog.ImageSource.ProjectResource Then
                                Return selectedImage
                            Else
                                Return selectedImage
                            End If
                        End If
                    End If
                End Using
            End If
        End If

        Return value
    End Function

    Public Overrides Function GetPaintValueSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(e As PaintValueEventArgs)
        If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Image Then
            Try
                e.Graphics.DrawImage(DirectCast(e.Value, Image), e.Bounds)
            Catch
            End Try
        End If
    End Sub

End Class