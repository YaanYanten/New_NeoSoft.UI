Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' Label personalizado con soporte para efectos de texto, bordes y estilos avanzados.
    ''' Proporciona una alternativa mejorada al Label estándar de Windows Forms.
    ''' </summary>
    ''' <remarks>
    ''' El control NXLabel incluye características como sombras de texto, bordes personalizables,
    ''' fondos con gradientes y múltiples estilos de presentación.
    ''' </remarks>
    <ToolboxBitmap(GetType(Label))>
    Public Class NXLabel
        Inherits Control
        Implements Theming.IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Define el estilo de fondo del label
        ''' </summary>
        Public Enum BackgroundStyle
            ''' <summary>Color sólido</summary>
            Solid
            ''' <summary>Gradiente horizontal</summary>
            GradientHorizontal
            ''' <summary>Gradiente vertical</summary>
            GradientVertical
            ''' <summary>Transparente</summary>
            Transparent
        End Enum

        ''' <summary>
        ''' Define el estilo del borde
        ''' </summary>
        Public Enum BorderStyle
            ''' <summary>Sin borde</summary>
            None
            ''' <summary>Borde completo</summary>
            Solid
            ''' <summary>Solo borde inferior</summary>
            Bottom
            ''' <summary>Solo borde izquierdo</summary>
            Left
        End Enum

#End Region

#Region "Campos Privados"

        Private _borderRadius As Integer = 0
        Private _borderSize As Integer = 0
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _borderStyleValue As BorderStyle = BorderStyle.None
        Private _backgroundStyleValue As BackgroundStyle = BackgroundStyle.Solid
        Private _gradientColor As Color = Color.Empty

        ' Efectos de texto
        Private _textShadow As Boolean = False
        Private _shadowColor As Color = Color.FromArgb(100, 0, 0, 0)
        Private _shadowOffset As Point = New Point(1, 1)
        Private _textOutline As Boolean = False
        Private _outlineColor As Color = Color.Black
        Private _outlineWidth As Single = 1.0F

        ' Alineación
        Private _textAlign As ContentAlignment = ContentAlignment.MiddleLeft
        Private _autoEllipsis As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            ' Configurar estilos para renderizado óptimo
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            ' Configuración inicial
            Me.Size = New Size(150, 30)
            Me.BackColor = Color.Transparent
            Me.ForeColor = Color.Black
            Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
            Me.Padding = New Padding(5, 5, 5, 5)
        End Sub

#End Region

#Region "Propiedades - Apariencia"

        ''' <summary>
        ''' Radio de las esquinas redondeadas del label
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Radio de las esquinas redondeadas")>
        <DefaultValue(0)>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _borderRadius <> value Then
                    _borderRadius = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Grosor del borde del label
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Grosor del borde")>
        <DefaultValue(0)>
        Public Property BorderSize As Integer
            Get
                Return _borderSize
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _borderSize <> value Then
                    _borderSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color del borde del label
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color del borde")>
        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(value As Color)
                If _borderColor <> value Then
                    _borderColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Estilo del borde del label
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Estilo del borde")>
        <DefaultValue(GetType(BorderStyle), "None")>
        Public Property BorderStyleValue As BorderStyle
            Get
                Return _borderStyleValue
            End Get
            Set(value As BorderStyle)
                If _borderStyleValue <> value Then
                    _borderStyleValue = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Estilo de fondo del label
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Estilo de fondo")>
        <DefaultValue(GetType(BackgroundStyle), "Solid")>
        Public Property BackgroundStyleValue As BackgroundStyle
            Get
                Return _backgroundStyleValue
            End Get
            Set(value As BackgroundStyle)
                If _backgroundStyleValue <> value Then
                    _backgroundStyleValue = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color secundario para gradientes
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color secundario para gradientes")>
        Public Property GradientColor As Color
            Get
                Return _gradientColor
            End Get
            Set(value As Color)
                If _gradientColor <> value Then
                    _gradientColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Efectos de Texto"

        ''' <summary>
        ''' Activa la sombra del texto
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Activa la sombra del texto")>
        <DefaultValue(False)>
        Public Property TextShadow As Boolean
            Get
                Return _textShadow
            End Get
            Set(value As Boolean)
                If _textShadow <> value Then
                    _textShadow = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color de la sombra del texto
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color de la sombra del texto")>
        Public Property ShadowColor As Color
            Get
                Return _shadowColor
            End Get
            Set(value As Color)
                If _shadowColor <> value Then
                    _shadowColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Desplazamiento de la sombra del texto
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Desplazamiento de la sombra del texto")>
        Public Property ShadowOffset As Point
            Get
                Return _shadowOffset
            End Get
            Set(value As Point)
                If _shadowOffset <> value Then
                    _shadowOffset = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Activa el contorno del texto
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Activa el contorno del texto")>
        <DefaultValue(False)>
        Public Property TextOutline As Boolean
            Get
                Return _textOutline
            End Get
            Set(value As Boolean)
                If _textOutline <> value Then
                    _textOutline = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color del contorno del texto
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color del contorno del texto")>
        Public Property OutlineColor As Color
            Get
                Return _outlineColor
            End Get
            Set(value As Color)
                If _outlineColor <> value Then
                    _outlineColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Grosor del contorno del texto
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Grosor del contorno del texto")>
        <DefaultValue(1.0F)>
        Public Property OutlineWidth As Single
            Get
                Return _outlineWidth
            End Get
            Set(value As Single)
                If value < 0.5F Then value = 0.5F
                If _outlineWidth <> value Then
                    _outlineWidth = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Alineación"

        ''' <summary>
        ''' Alineación del texto dentro del label
        ''' </summary>
        <Category("Apariencia")>
        <Description("Alineación del texto")>
        <DefaultValue(GetType(ContentAlignment), "MiddleLeft")>
        Public Property TextAlign As ContentAlignment
            Get
                Return _textAlign
            End Get
            Set(value As ContentAlignment)
                If _textAlign <> value Then
                    _textAlign = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Muestra puntos suspensivos cuando el texto es muy largo
        ''' </summary>
        <Category("Comportamiento")>
        <Description("Muestra puntos suspensivos cuando el texto es muy largo")>
        <DefaultValue(False)>
        Public Property AutoEllipsis As Boolean
            Get
                Return _autoEllipsis
            End Get
            Set(value As Boolean)
                If _autoEllipsis <> value Then
                    _autoEllipsis = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Métodos Protegidos - Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

            Dim rectSurface As Rectangle = Me.ClientRectangle
            Dim rectBorder As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            ' Dibujar fondo
            If _backgroundStyleValue <> BackgroundStyle.Transparent Then
                DrawBackground(g, rectSurface)
            End If

            ' Dibujar borde
            If _borderSize > 0 AndAlso _borderStyleValue <> BorderStyle.None Then
                DrawBorder(g, rectBorder)
            End If

            ' Dibujar texto
            If Not String.IsNullOrEmpty(Me.Text) Then
                DrawText(g, rectSurface)
            End If

            MyBase.OnPaint(e)
        End Sub

        ''' <summary>
        ''' Dibuja el fondo del label según el estilo configurado
        ''' </summary>
        Private Sub DrawBackground(g As Graphics, rect As Rectangle)
            Select Case _backgroundStyleValue
                Case BackgroundStyle.Solid
                    Using brush As New SolidBrush(Me.BackColor)
                        If _borderRadius > 0 Then
                            Using path As GraphicsPath = GetRoundedRectangle(rect, _borderRadius)
                                g.FillPath(brush, path)
                            End Using
                        Else
                            g.FillRectangle(brush, rect)
                        End If
                    End Using

                Case BackgroundStyle.GradientHorizontal, BackgroundStyle.GradientVertical
                    Dim color2 As Color = If(_gradientColor <> Color.Empty, _gradientColor, ControlPaint.Light(Me.BackColor, 0.3F))
                    Dim mode As LinearGradientMode = If(_backgroundStyleValue = BackgroundStyle.GradientHorizontal,
                                                        LinearGradientMode.Horizontal,
                                                        LinearGradientMode.Vertical)

                    Using brush As New LinearGradientBrush(rect, Me.BackColor, color2, mode)
                        If _borderRadius > 0 Then
                            Using path As GraphicsPath = GetRoundedRectangle(rect, _borderRadius)
                                g.FillPath(brush, path)
                            End Using
                        Else
                            g.FillRectangle(brush, rect)
                        End If
                    End Using
            End Select
        End Sub

        ''' <summary>
        ''' Dibuja el borde del label según el estilo configurado
        ''' </summary>
        Private Sub DrawBorder(g As Graphics, rect As Rectangle)
            Using pen As New Pen(_borderColor, _borderSize)
                pen.Alignment = PenAlignment.Inset

                Select Case _borderStyleValue
                    Case BorderStyle.Solid
                        If _borderRadius > 0 Then
                            Using path As GraphicsPath = GetRoundedRectangle(rect, _borderRadius)
                                g.DrawPath(pen, path)
                            End Using
                        Else
                            g.DrawRectangle(pen, rect)
                        End If

                    Case BorderStyle.Bottom
                        g.DrawLine(pen, 0, Me.Height - _borderSize, Me.Width, Me.Height - _borderSize)

                    Case BorderStyle.Left
                        g.DrawLine(pen, _borderSize, 0, _borderSize, Me.Height)
                End Select
            End Using
        End Sub

        ''' <summary>
        ''' Dibuja el texto con los efectos configurados
        ''' </summary>
        Private Sub DrawText(g As Graphics, rect As Rectangle)
            ' Aplicar padding al rectángulo de texto
            Dim textRect As New Rectangle(
                rect.X + Me.Padding.Left,
                rect.Y + Me.Padding.Top,
                rect.Width - Me.Padding.Left - Me.Padding.Right,
                rect.Height - Me.Padding.Top - Me.Padding.Bottom
            )

            Dim sf As New StringFormat()
            sf.Alignment = GetHorizontalAlignment(_textAlign)
            sf.LineAlignment = GetVerticalAlignment(_textAlign)

            If _autoEllipsis Then
                sf.Trimming = StringTrimming.EllipsisCharacter
                sf.FormatFlags = StringFormatFlags.NoWrap
            End If

            ' Dibujar sombra si está habilitada
            If _textShadow Then
                Dim shadowRect As New Rectangle(
                    textRect.X + _shadowOffset.X,
                    textRect.Y + _shadowOffset.Y,
                    textRect.Width,
                    textRect.Height
                )
                Using shadowBrush As New SolidBrush(_shadowColor)
                    g.DrawString(Me.Text, Me.Font, shadowBrush, shadowRect, sf)
                End Using
            End If

            ' Dibujar contorno si está habilitado
            If _textOutline Then
                Using path As New GraphicsPath()
                    path.AddString(Me.Text, Me.Font.FontFamily, CInt(Me.Font.Style),
                                 g.DpiY * Me.Font.Size / 72, textRect, sf)

                    Using pen As New Pen(_outlineColor, _outlineWidth)
                        pen.LineJoin = LineJoin.Round
                        g.DrawPath(pen, path)
                    End Using

                    Using brush As New SolidBrush(Me.ForeColor)
                        g.FillPath(brush, path)
                    End Using
                End Using
            Else
                ' Dibujar texto normal
                Using brush As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                End Using
            End If

            sf.Dispose()
        End Sub

        ''' <summary>
        ''' Crea una ruta de gráficos con esquinas redondeadas
        ''' </summary>
        Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            If radius > rect.Height / 2 Then radius = rect.Height / 2
            If radius > rect.Width / 2 Then radius = rect.Width / 2

            Dim diameter As Integer = radius * 2

            path.StartFigure()
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
            path.CloseFigure()

            Return path
        End Function

        ''' <summary>
        ''' Convierte ContentAlignment a StringAlignment horizontal
        ''' </summary>
        Private Function GetHorizontalAlignment(align As ContentAlignment) As StringAlignment
            Select Case align
                Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                    Return StringAlignment.Near
                Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                    Return StringAlignment.Center
                Case ContentAlignment.TopRight, ContentAlignment.MiddleRight, ContentAlignment.BottomRight
                    Return StringAlignment.Far
                Case Else
                    Return StringAlignment.Near
            End Select
        End Function

        ''' <summary>
        ''' Convierte ContentAlignment a StringAlignment vertical
        ''' </summary>
        Private Function GetVerticalAlignment(align As ContentAlignment) As StringAlignment
            Select Case align
                Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
                    Return StringAlignment.Near
                Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                    Return StringAlignment.Center
                Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
                    Return StringAlignment.Far
                Case Else
                    Return StringAlignment.Near
            End Select
        End Function

#End Region

#Region "Métodos Protegidos - Eventos"

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            Me.Invalidate()
            MyBase.OnTextChanged(e)
        End Sub

#End Region

#Region "Soporte de Temas"

        Private _useTheme As Boolean = False

        <Category("Apariencia NX")>
        <Description("Indica si el control usa el tema global automáticamente")>
        <DefaultValue(False)>
        Public Property UseTheme As Boolean Implements Theming.IThemeable.UseTheme
            Get
                Return _useTheme
            End Get
            Set(value As Boolean)
                If _useTheme <> value Then
                    _useTheme = value
                    If value Then
                        ApplyTheme(Theming.NXThemeManager.Instance.CurrentTheme)
                    End If
                End If
            End Set
        End Property

        Public Sub ApplyTheme(theme As Theming.NXTheme) Implements Theming.IThemeable.ApplyTheme
            If Not _useTheme Then Return

            Me.ForeColor = theme.ForeColor
            Me.BorderColor = theme.BorderColor
            Me.BorderRadius = theme.BorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace
