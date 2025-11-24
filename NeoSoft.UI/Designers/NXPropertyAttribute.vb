Imports System

Namespace Design

    ''' <summary>
    ''' Atributo para marcar propiedades que deben aparecer en el tab "NX" del Property Grid
    ''' </summary>
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False, Inherited:=True)>
    Public Class NXPropertyAttribute
        Inherits Attribute

        ''' <summary>
        ''' Indica si la propiedad debe mostrarse en el tab NX
        ''' </summary>
        Public Property Visible As Boolean = True

        ''' <summary>
        ''' Constructor por defecto
        ''' </summary>
        Public Sub New()
            Visible = True
        End Sub

        ''' <summary>
        ''' Constructor con visibilidad
        ''' </summary>
        Public Sub New(visible As Boolean)
            Me.Visible = visible
        End Sub

    End Class

End Namespace