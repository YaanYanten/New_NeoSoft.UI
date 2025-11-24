Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design

Namespace Design

    ''' <summary>
    ''' Agrupa las propiedades de apariencia personalizadas de NeoSoft.UI
    ''' en un grupo expandible en el Property Grid similar a OttComputer.Properties
    ''' </summary>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class NXAppearance

#Region "Campos Privados"

        Private _control As Control

        ' Borde
        Private _borderRadius As Integer = 8
        Private _borderSize As Integer = 1
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _borderStyle As BorderStyle = BorderStyle.Solid

        ' Header (para controles que lo soporten)
        Private _headerHeight As Integer = 35
        Private _headerBackColor As Color = Color.FromArgb(245, 245, 245)
        Private _headerBackColor2 As Color = Color.FromArgb(230, 230, 230)
        Private _showHeader As Boolean = True
        Private _headerBackgroundStyle As HeaderBackgroundStyle = HeaderBackgroundStyle.Solid

        ' Icono
        Private _headerIcon As Image = Nothing
        Private _headerIconPosition As IconPosition = IconPosition.Left
        Private _headerIconSize As Size = New Size(20, 20)
        Private _headerIconSpacing As Integer = 6

        ' Colores adicionales
        Private _hoverBackColor As Color = Color.Empty
        Private _pressedBackColor As Color = Color.Empty

        ' Tema
        Private _useTheme As Boolean = False

#End Region

#Region "Enumeraciones"

        Public Enum BorderStyle
            Solid
            Dotted
            Dashed
            [Double]
            None
        End Enum

        Public Enum IconPosition
            Left
            Right
        End Enum

        ''' <summary>
        ''' Estilo del fondo del header
        ''' </summary>
        Public Enum HeaderBackgroundStyle
            ''' <summary>Color sólido</summary>
            Solid
            ''' <summary>Gradiente horizontal</summary>
            Gradient
            ''' <summary>Transparente</summary>
            Transparent
        End Enum

#End Region

#Region "Constructor"

        Public Sub New(control As Control)
            _control = control
        End Sub

#End Region

#Region "Propiedades - Borde"

        <Category("Apariencia NX")>
        <Description("Radio de las esquinas redondeadas")>
        <DefaultValue(8)>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _borderRadius <> value Then
                    _borderRadius = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Grosor del borde")>
        <DefaultValue(1)>
        Public Property BorderSize As Integer
            Get
                Return _borderSize
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _borderSize <> value Then
                    _borderSize = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color del borde")>
        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(value As Color)
                If _borderColor <> value Then
                    _borderColor = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Estilo del borde (Solid, Dotted, Dashed, Double, None)")>
        <DefaultValue(GetType(BorderStyle), "Solid")>
        Public Property BorderStyleType As BorderStyle
            Get
                Return _borderStyle
            End Get
            Set(value As BorderStyle)
                If _borderStyle <> value Then
                    _borderStyle = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Header"

        <Category("Apariencia NX")>
        <Description("Altura del header")>
        <DefaultValue(35)>
        Public Property HeaderHeight As Integer
            Get
                Return _headerHeight
            End Get
            Set(value As Integer)
                If value < 20 Then value = 20
                If _headerHeight <> value Then
                    _headerHeight = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color de fondo del header")>
        Public Property HeaderBackColor As Color
            Get
                Return _headerBackColor
            End Get
            Set(value As Color)
                If _headerBackColor <> value Then
                    _headerBackColor = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color secundario para gradiente del header")>
        Public Property HeaderBackColor2 As Color
            Get
                Return _headerBackColor2
            End Get
            Set(value As Color)
                If _headerBackColor2 <> value Then
                    _headerBackColor2 = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Muestra el header")>
        <DefaultValue(True)>
        Public Property ShowHeader As Boolean
            Get
                Return _showHeader
            End Get
            Set(value As Boolean)
                If _showHeader <> value Then
                    _showHeader = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Estilo de fondo del header (Solid, Gradient, Transparent)")>
        <DefaultValue(GetType(HeaderBackgroundStyle), "Solid")>
        Public Property HeaderBackgroundStl As HeaderBackgroundStyle
            Get
                Return _headerBackgroundStyle
            End Get
            Set(value As HeaderBackgroundStyle)
                If _headerBackgroundStyle <> value Then
                    _headerBackgroundStyle = value
                    _control.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Icono"

        <Category("Apariencia NX")>
        <Description("Icono del header")>
        <Editor(GetType(NXImageUITypeEditor), GetType(UITypeEditor))>
        <Localizable(True)>
        Public Property HeaderIcon As Image
            Get
                Return _headerIcon
            End Get
            Set(value As Image)
                If _headerIcon IsNot Nothing AndAlso _headerIcon IsNot value Then
                    Try
                        _headerIcon.Dispose()
                    Catch
                    End Try
                End If
                _headerIcon = value
                _control?.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Posición del icono (Left/Right)")>
        <DefaultValue(GetType(IconPosition), "Left")>
        Public Property HeaderIconPosition As IconPosition
            Get
                Return _headerIconPosition
            End Get
            Set(value As IconPosition)
                If _headerIconPosition <> value Then
                    _headerIconPosition = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Tamaño del icono")>
        Public Property HeaderIconSize As Size
            Get
                Return _headerIconSize
            End Get
            Set(value As Size)
                If _headerIconSize <> value Then
                    _headerIconSize = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Espacio entre el icono y el texto")>
        <DefaultValue(6)>
        Public Property HeaderIconSpacing As Integer
            Get
                Return _headerIconSpacing
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _headerIconSpacing <> value Then
                    _headerIconSpacing = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Colores de Estado"

        <Category("Apariencia NX")>
        <Description("Color de fondo cuando el mouse está sobre el control")>
        Public Property HoverBackColor As Color
            Get
                Return _hoverBackColor
            End Get
            Set(value As Color)
                _hoverBackColor = value
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color de fondo cuando el control está presionado")>
        Public Property PressedBackColor As Color
            Get
                Return _pressedBackColor
            End Get
            Set(value As Color)
                _pressedBackColor = value
            End Set
        End Property

#End Region

#Region "Propiedades - Tema"

        <Category("Apariencia NX")>
        <Description("Indica si el control usa el tema global automáticamente")>
        <DefaultValue(False)>
        Public Property UseTheme As Boolean
            Get
                Return _useTheme
            End Get
            Set(value As Boolean)
                If _useTheme <> value Then
                    _useTheme = value
                    _control?.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Override ToString"

        ''' <summary>
        ''' Muestra información resumida del objeto en el Property Grid
        ''' </summary>
        Public Overrides Function ToString() As String
            Return $"BorderRadius: {_borderRadius}, BorderSize: {_borderSize}"
        End Function

#End Region

#Region "Métodos para Resetear Valores"

        Public Sub ResetBorderRadius()
            BorderRadius = 8
        End Sub

        Public Function ShouldSerializeBorderRadius() As Boolean
            Return BorderRadius <> 8
        End Function

        Public Sub ResetBorderSize()
            BorderSize = 1
        End Sub

        Public Function ShouldSerializeBorderSize() As Boolean
            Return BorderSize <> 1
        End Function

        Public Sub ResetBorderColor()
            BorderColor = Color.FromArgb(200, 200, 200)
        End Sub

        Public Function ShouldSerializeBorderColor() As Boolean
            Return BorderColor <> Color.FromArgb(200, 200, 200)
        End Function

#End Region

#Region "Cleanup"

        Public Sub Dispose()
            If _headerIcon IsNot Nothing Then
                Try
                    _headerIcon.Dispose()
                Catch
                End Try
                _headerIcon = Nothing
            End If
        End Sub

#End Region

    End Class

End Namespace