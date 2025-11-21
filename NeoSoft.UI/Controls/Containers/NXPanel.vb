Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Panel personalizado con bordes redondeados, sombras y soporte de temas
    ''' </summary>
    <ToolboxBitmap(GetType(Panel))>
    Public Class NXPanel
        Inherits Panel
        Implements IThemeable

#Region "Campos Privados"

        Private _borderRadius As Integer = 8
        Private _borderSize As Integer = 0
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _showShadow As Boolean = False
        Private _shadowColor As Color = Color.FromArgb(50, 0, 0, 0)
        Private _shadowOffset As Integer = 5

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            Me.BackColor = Color.White
            Me.Size = New Size(200, 150)
            Me.Padding = New Padding(10)
        End Sub

#End Region

#Region "Propiedades"

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
                    Me.Invalidate()
                End If
            End Set
        End Property

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

        <Category("Apariencia NX")>
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
                ' Dibujar fondo
                Using brush As New SolidBrush(Me.BackColor)
                    g.FillPath(brush, path)
                End Using

                ' Dibujar borde
                If _borderSize > 0 Then
                    Using pen As New Pen(_borderColor, _borderSize)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using
                End If
            End Using

            MyBase.OnPaint(e)
        End Sub

        Private Sub DrawShadow(g As Graphics, rect As Rectangle)
            Try
                Dim shadowRect As New Rectangle(
                    rect.X + _shadowOffset,
                    rect.Y + _shadowOffset,
                    rect.Width,
                    rect.Height
                )

                Using path As GraphicsPath = GetRoundedRectangle(shadowRect, _borderRadius)
                    Using brush As New SolidBrush(_shadowColor)
                        g.FillPath(brush, path)
                    End Using
                End Using
            Catch
                ' Silencioso si falla el dibujo de sombra
            End Try
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

#Region "Soporte de Temas"

        Private _useTheme As Boolean = False

        <Category("Apariencia NX")>
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

            Me.BackColor = theme.PanelBackColor
            Me.BorderColor = theme.BorderColor
            Me.BorderRadius = theme.BorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace