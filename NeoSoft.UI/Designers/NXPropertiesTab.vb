Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace Design

    ''' <summary>
    ''' Tab personalizado "NX" en el Property Grid que muestra solo propiedades NeoSoft.UI
    ''' </summary>
    Public Class NXPropertiesTab
        Inherits PropertyTab

#Region "Constructor"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region

#Region "Propiedades del Tab"

        ''' <summary>
        ''' Nombre que aparece en el tooltip del tab
        ''' </summary>
        Public Overrides ReadOnly Property TabName As String
            Get
                Return "NeoSoft.UI Properties"
            End Get
        End Property

        ''' <summary>
        ''' Icono que aparece en la barra de tabs (16x16)
        ''' </summary>
        Public Overrides ReadOnly Property Bitmap As Bitmap
            Get
                ' ⭐ OPCIÓN 1: Usar recurso embebido (recomendado)
                ' Return My.Resources.nx_icon_16x16

                ' ⭐ OPCIÓN 2: Crear icono programáticamente
                Return CreateNXIcon()
            End Get
        End Property

#End Region

#Region "Métodos Override"

        ''' <summary>
        ''' Determina si este tab puede extender el objeto especificado
        ''' </summary>
        Public Overrides Function CanExtend(extendee As Object) As Boolean
            ' Retornar True si el control es de NeoSoft.UI
            If extendee Is Nothing Then Return False

            Dim typeName As String = extendee.GetType().Namespace
            Return typeName IsNot Nothing AndAlso typeName.StartsWith("NeoSoft.UI")
        End Function

        ''' <summary>
        ''' Obtiene las propiedades que se mostrarán en este tab
        ''' </summary>
        Public Overrides Function GetProperties(context As ITypeDescriptorContext,
                                                component As Object,
                                                attributes As Attribute()) As PropertyDescriptorCollection

            ' Obtener solo propiedades con el atributo [NXProperty]
            Return TypeDescriptor.GetProperties(component,
                                               New Attribute() {New NXPropertyAttribute()})
        End Function

        ''' <summary>
        ''' Obtiene las propiedades en el orden especificado
        ''' </summary>
        Public Overrides Function GetProperties(component As Object,
                                                attributes As Attribute()) As PropertyDescriptorCollection
            Return GetProperties(Nothing, component, attributes)
        End Function

#End Region

#Region "Helper - Crear Icono NX"

        ''' <summary>
        ''' Crea un icono "NX" de 16x16 píxeles
        ''' </summary>
        Private Function CreateNXIcon() As Bitmap
            Dim bmp As New Bitmap(16, 16)

            Using g As Graphics = Graphics.FromImage(bmp)
                ' Fondo transparente
                g.Clear(Color.Transparent)

                ' Configurar calidad
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                ' Dibujar fondo circular azul
                Using brush As New SolidBrush(Color.FromArgb(0, 120, 215))
                    g.FillEllipse(brush, 0, 0, 15, 15)
                End Using

                ' Dibujar texto "NX" en blanco
                Using font As New Font("Segoe UI", 6.5F, FontStyle.Bold)
                    Using brush As New SolidBrush(Color.White)
                        Dim sf As New StringFormat With {
                            .Alignment = StringAlignment.Center,
                            .LineAlignment = StringAlignment.Center
                        }
                        g.DrawString("NX", font, brush, New RectangleF(0, 0, 15, 15), sf)
                    End Using
                End Using
            End Using

            Return bmp
        End Function

#End Region

    End Class

End Namespace