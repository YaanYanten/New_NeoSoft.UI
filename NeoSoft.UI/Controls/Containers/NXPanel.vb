Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Panel personalizado con bordes redondeados, sombras, gradientes y auto-scroll mejorado
    ''' </summary>
    <ToolboxBitmap(GetType(Panel))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    Public Class NXPanel
        Inherits Panel
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Estilos de borde disponibles
        ''' </summary>
        Public Enum BorderStyle
            ''' <summary>Borde sólido</summary>
            Solid
            ''' <summary>Borde punteado</summary>
            Dotted
            ''' <summary>Borde discontinuo</summary>
            Dashed
            ''' <summary>Borde doble</summary>
            [Double]
            ''' <summary>Sin borde</summary>
            None
        End Enum

        ''' <summary>
        ''' Estilos de fondo disponibles
        ''' </summary>
        Public Enum BackgroundStyle
            ''' <summary>Color sólido</summary>
            Solid
            ''' <summary>Gradiente vertical</summary>
            GradientVertical
            ''' <summary>Gradiente horizontal</summary>
            GradientHorizontal
            ''' <summary>Gradiente diagonal (↘)</summary>
            GradientDiagonalDown
            ''' <summary>Gradiente diagonal (↗)</summary>
            GradientDiagonalUp
        End Enum

#End Region

#Region "Campos Privados"

        ' Borde
        Private _borderRadius As Integer = 8
        Private _borderSize As Integer = 0
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _borderStyle As BorderStyle = BorderStyle.Solid

        ' Sombra
        Private _showShadow As Boolean = False
        Private _shadowColor As Color = Color.FromArgb(50, 0, 0, 0)
        Private _shadowOffset As Integer = 5
        Private _shadowBlur As Integer = 10

        ' Gradiente
        Private _backgroundStyle As BackgroundStyle = BackgroundStyle.Solid
        Private _gradientColor1 As Color = Color.White
        Private _gradientColor2 As Color = Color.LightGray

        ' Auto-scroll mejorado
        Private _smoothScrolling As Boolean = False
        Private _scrollBarWidth As Integer = 10
        Private _scrollBarColor As Color = Color.FromArgb(150, 150, 150)

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor Or
                       ControlStyles.ContainerControl, True)

            Me.BackColor = Color.White
            Me.Size = New Size(200, 150)
            Me.Padding = New Padding(10)
            Me.AutoScroll = False

            ' Inicializar colores de gradiente
            _gradientColor1 = Me.BackColor
            _gradientColor2 = ControlPaint.Light(Me.BackColor, 0.2F)
        End Sub

#End Region

#Region "Propiedades - Borde"

        <Category("Apariencia NX")>
        <NXProperty()>
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
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
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

        <Category("Apariencia NX")>
        <NXProperty()>
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

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo del borde (Solid, Dotted, Dashed, Double, None)")>
        <DefaultValue(GetType(BorderStyle), "Solid")>
        Public Property BorderStyleType As BorderStyle
            Get
                Return _borderStyle
            End Get
            Set(value As BorderStyle)
                If _borderStyle <> value Then
                    _borderStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Sombra"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Muestra sombra debajo del panel")>
        <DefaultValue(False)>
        Public Property ShowShadow As Boolean
            Get
                Return _showShadow
            End Get
            Set(value As Boolean)
                If _showShadow <> value Then
                    _showShadow = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de la sombra")>
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

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Desplazamiento de la sombra en píxeles")>
        <DefaultValue(5)>
        Public Property ShadowOffset As Integer
            Get
                Return _shadowOffset
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _shadowOffset <> value Then
                    _shadowOffset = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Difuminado de la sombra en píxeles")>
        <DefaultValue(10)>
        Public Property ShadowBlur As Integer
            Get
                Return _shadowBlur
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _shadowBlur <> value Then
                    _shadowBlur = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Gradiente"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo del fondo (Solid, GradientVertical, GradientHorizontal, etc.)")>
        <DefaultValue(GetType(BackgroundStyle), "Solid")>
        Public Property BackgroundStyleType As BackgroundStyle
            Get
                Return _backgroundStyle
            End Get
            Set(value As BackgroundStyle)
                If _backgroundStyle <> value Then
                    _backgroundStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color principal del gradiente (o color sólido si BackgroundStyle es Solid)")>
        Public Property GradientColor1 As Color
            Get
                Return _gradientColor1
            End Get
            Set(value As Color)
                If _gradientColor1 <> value Then
                    _gradientColor1 = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color secundario del gradiente")>
        Public Property GradientColor2 As Color
            Get
                Return _gradientColor2
            End Get
            Set(value As Color)
                If _gradientColor2 <> value Then
                    _gradientColor2 = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Auto-Scroll Mejorado"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Habilita desplazamiento suave (smooth scrolling)")>
        <DefaultValue(False)>
        Public Property SmoothScrolling As Boolean
            Get
                Return _smoothScrolling
            End Get
            Set(value As Boolean)
                If _smoothScrolling <> value Then
                    _smoothScrolling = value
                    ConfigureAutoScroll()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Ancho personalizado de las barras de desplazamiento")>
        <DefaultValue(10)>
        Public Property ScrollBarWidth As Integer
            Get
                Return _scrollBarWidth
            End Get
            Set(value As Integer)
                If value < 5 Then value = 5
                If value > 30 Then value = 30
                If _scrollBarWidth <> value Then
                    _scrollBarWidth = value
                    ConfigureAutoScroll()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de las barras de desplazamiento")>
        Public Property ScrollBarColor As Color
            Get
                Return _scrollBarColor
            End Get
            Set(value As Color)
                If _scrollBarColor <> value Then
                    _scrollBarColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim rectSurface As New Rectangle(0, 0, Me.Width, Me.Height)
            Dim rectBorder As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            ' Dibujar sombra si está habilitada
            If _showShadow Then
                DrawShadow(g, rectBorder)
            End If

            ' Crear path con bordes redondeados
            Using path As GraphicsPath = GetRoundedRectangle(rectBorder, _borderRadius)
                ' Dibujar fondo (sólido o gradiente)
                DrawBackground(g, path, rectBorder)

                ' Dibujar borde
                If _borderSize > 0 AndAlso _borderStyle <> BorderStyle.None Then
                    DrawBorder(g, path, rectBorder)
                End If
            End Using

            MyBase.OnPaint(e)
        End Sub

        Private Sub DrawBackground(g As Graphics, path As GraphicsPath, rect As Rectangle)
            Select Case _backgroundStyle
                Case BackgroundStyle.Solid
                    ' Color sólido
                    Using brush As New SolidBrush(_gradientColor1)
                        g.FillPath(brush, path)
                    End Using

                Case BackgroundStyle.GradientVertical
                    ' Gradiente vertical (arriba → abajo)
                    Using brush As New LinearGradientBrush(rect, _gradientColor1, _gradientColor2, LinearGradientMode.Vertical)
                        g.FillPath(brush, path)
                    End Using

                Case BackgroundStyle.GradientHorizontal
                    ' Gradiente horizontal (izquierda → derecha)
                    Using brush As New LinearGradientBrush(rect, _gradientColor1, _gradientColor2, LinearGradientMode.Horizontal)
                        g.FillPath(brush, path)
                    End Using

                Case BackgroundStyle.GradientDiagonalDown
                    ' Gradiente diagonal (↘)
                    Using brush As New LinearGradientBrush(rect, _gradientColor1, _gradientColor2, LinearGradientMode.ForwardDiagonal)
                        g.FillPath(brush, path)
                    End Using

                Case BackgroundStyle.GradientDiagonalUp
                    ' Gradiente diagonal (↗)
                    Using brush As New LinearGradientBrush(rect, _gradientColor1, _gradientColor2, LinearGradientMode.BackwardDiagonal)
                        g.FillPath(brush, path)
                    End Using
            End Select
        End Sub

        Private Sub DrawShadow(g As Graphics, rect As Rectangle)
            Try
                ' Crear múltiples capas de sombra para efecto de difuminado
                Dim layers As Integer = Math.Min(_shadowBlur, 20)
                Dim alphaStep As Integer = _shadowColor.A \ layers

                For i As Integer = layers To 1 Step -1
                    Dim offset As Integer = _shadowOffset + (i * _shadowBlur \ layers)
                    Dim alpha As Integer = alphaStep * (layers - i + 1)

                    Dim shadowRect As New Rectangle(
                        rect.X + offset,
                        rect.Y + offset,
                        rect.Width,
                        rect.Height
                    )

                    Using path As GraphicsPath = GetRoundedRectangle(shadowRect, _borderRadius)
                        Using brush As New SolidBrush(Color.FromArgb(alpha, _shadowColor))
                            g.FillPath(brush, path)
                        End Using
                    End Using
                Next
            Catch
                ' Silencioso si falla el dibujo de sombra
            End Try
        End Sub

        Private Sub DrawBorder(g As Graphics, path As GraphicsPath, rect As Rectangle)
            Select Case _borderStyle
                Case BorderStyle.Solid
                    Using pen As New Pen(_borderColor, _borderSize)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using

                Case BorderStyle.Dotted
                    Using pen As New Pen(_borderColor, _borderSize)
                        pen.Alignment = PenAlignment.Inset
                        pen.DashStyle = DashStyle.Dot
                        g.DrawPath(pen, path)
                    End Using

                Case BorderStyle.Dashed
                    Using pen As New Pen(_borderColor, _borderSize)
                        pen.Alignment = PenAlignment.Inset
                        pen.DashStyle = DashStyle.Dash
                        g.DrawPath(pen, path)
                    End Using

                Case BorderStyle.Double
                    ' Borde exterior
                    Using pen As New Pen(_borderColor, _borderSize)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using

                    ' Borde interior
                    Dim innerRect As New Rectangle(rect.X + _borderSize + 2, rect.Y + _borderSize + 2,
                                                   rect.Width - (_borderSize + 2) * 2,
                                                   rect.Height - (_borderSize + 2) * 2)
                    Using innerPath As GraphicsPath = GetRoundedRectangle(innerRect, _borderRadius - 3)
                        Using pen As New Pen(_borderColor, _borderSize)
                            pen.Alignment = PenAlignment.Inset
                            g.DrawPath(pen, innerPath)
                        End Using
                    End Using
            End Select
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            ' No pintar fondo - lo hacemos en OnPaint
        End Sub

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

#End Region

#Region "Auto-Scroll Mejorado"

        Private Sub ConfigureAutoScroll()
            ' Nota: WinForms no permite personalizar completamente las barras de scroll nativas
            ' Esta es una configuración básica. Para scroll completamente personalizado
            ' se requeriría crear controles custom de scrollbar

            If _smoothScrolling Then
                ' Habilitar auto-scroll suave
                Me.AutoScroll = True
                Me.HorizontalScroll.SmallChange = 10
                Me.VerticalScroll.SmallChange = 10
                Me.HorizontalScroll.LargeChange = 50
                Me.VerticalScroll.LargeChange = 50
            End If
        End Sub

        Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
            If _smoothScrolling Then
                ' Scroll suave con rueda del mouse
                Dim delta As Integer = e.Delta * SystemInformation.MouseWheelScrollLines \ 120
                Dim newValue As Integer = Me.VerticalScroll.Value - (delta * 20)

                ' Limitar al rango válido
                If newValue < Me.VerticalScroll.Minimum Then
                    newValue = Me.VerticalScroll.Minimum
                ElseIf newValue > Me.VerticalScroll.Maximum - Me.VerticalScroll.LargeChange Then
                    newValue = Me.VerticalScroll.Maximum - Me.VerticalScroll.LargeChange + 1
                End If

                Me.AutoScrollPosition = New Point(-Me.HorizontalScroll.Value, newValue)
            Else
                MyBase.OnMouseWheel(e)
            End If
        End Sub

#End Region

#Region "Soporte de Temas"

        Private _useTheme As Boolean = False

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Indica si el control usa el tema global automáticamente")>
        <DefaultValue(False)>
        Public Property UseTheme As Boolean Implements IThemeable.UseTheme
            Get
                Return _useTheme
            End Get
            Set(value As Boolean)
                If _useTheme <> value Then
                    _useTheme = value
                    If value Then
                        ApplyTheme(NXThemeManager.Instance.CurrentTheme)
                    End If
                End If
            End Set
        End Property

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            If Not _useTheme Then Return

            Me.GradientColor1 = theme.PanelBackColor
            Me.BorderColor = theme.BorderColor
            Me.BorderRadius = theme.BorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace