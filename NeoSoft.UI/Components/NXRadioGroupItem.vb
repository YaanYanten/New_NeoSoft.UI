Imports System.ComponentModel
Imports System.Drawing

Namespace Controls
    ''' <summary>
    ''' Representa un item individual dentro de un NXRadioGroup
    ''' </summary>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class NXRadioGroupItem

#Region "Campos Privados"

        Private _text As String = "Radio Item"
        Private _value As Object = Nothing
        Private _tag As Object = Nothing
        Private _enabled As Boolean = True
        Private _description As String = String.Empty

#End Region

#Region "Constructor"

        Public Sub New()
        End Sub

        Public Sub New(text As String)
            _text = text
        End Sub

        Public Sub New(text As String, value As Object)
            _text = text
            _value = value
        End Sub

#End Region

#Region "Propiedades"

        <Category("Appearance")>
        <Description("Texto que se muestra para este item")>
        Public Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                _text = value
            End Set
        End Property

        <Category("Data")>
        <Description("Valor asociado a este item")>
        <Browsable(True)>
        Public Property Value As Object
            Get
                Return _value
            End Get
            Set(value As Object)
                _value = value
            End Set
        End Property

        <Category("Data")>
        <Description("Datos adicionales del usuario")>
        <Browsable(True)>
        <TypeConverter(GetType(StringConverter))>
        Public Property Tag As Object
            Get
                Return _tag
            End Get
            Set(value As Object)
                _tag = value
            End Set
        End Property

        <Category("Behavior")>
        <Description("Indica si el item está habilitado")>
        <DefaultValue(True)>
        Public Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
            End Set
        End Property

        <Category("Appearance")>
        <Description("Descripción del item")>
        <DefaultValue("")>
        Public Property Description As String
            Get
                Return _description
            End Get
            Set(value As String)
                _description = value
            End Set
        End Property

#End Region

#Region "Overrides"

        Public Overrides Function ToString() As String
            Return _text
        End Function

#End Region

    End Class

End Namespace