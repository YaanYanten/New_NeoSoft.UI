Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' Botón personalizado con esquinas redondeadas y efectos visuales mejorados.
    ''' Soporta estados hover, pressed y disabled con transiciones suaves.
    ''' </summary>
    ''' <remarks>
    ''' El control NXButton proporciona una alternativa moderna al Button estándar de Windows Forms
    ''' con soporte para esquinas redondeadas, efectos de sombra y estados visuales personalizables.
    ''' </remarks>
    <ToolboxBitmap(GetType(Button))>
    <DefaultEvent("Click")>
    Public Class NXButton
        Inherits Control

#Region "Enumeraciones"

        ''' <summary>
        ''' Define el estilo visual del botón
        ''' </summary>
        Public Enum ButtonStyle
            ''' <summary>Estilo sólido con color de fondo completo</summary>
            Solid
            ''' <summary>Estilo con gradiente vertical</summary>
            Gradient
            ''' <summary>Estilo solo con borde, fondo transparente</summary>
            Outline
        End Enum

#End Region

#Region "Campos Privados"

        Private _borderRadius As Integer = 8
        Private _borderSize As Integer = 0
        Private _borderColor As Color = Color.FromArgb(0, 120, 215)
        Private _buttonStyle As ButtonStyle = ButtonStyle.Solid

        ' Estados visuales
        Private _isHovered As Boolean = False
        Private _isPressed As Boolean = False
        Private _isFocused As Boolean = False

        ' Colores para estados
        Private _hoverBackColor As Color = Color.Empty
        Private _pressedBackColor As Color = Color.Empty
        Private _disabledBackColor As Color = Color.FromArgb(204, 204, 204)

#End Region

#Region "Propiedades - Apariencia"

        ''' <summary>
        ''' Radio de las esquinas redondeadas del botón (en píxeles)
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Radio de las esquinas redondeadas del botón")>
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

        ''' <summary>
        ''' Grosor del borde del botón (en píxeles)
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Grosor del borde del botón")>
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
        ''' Color del borde del botón
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color del borde del botón")>
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
        ''' Estilo visual del botón (Solid, Gradient, Outline)
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Estilo visual del botón")>
        <DefaultValue(GetType(ButtonStyle), "Solid")>
        Public Property Style As ButtonStyle
            Get
                Return _buttonStyle
            End Get
            Set(value As ButtonStyle)
                If _buttonStyle <> value Then
                    _buttonStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color de fondo cuando el mouse está sobre el botón
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color de fondo cuando el mouse está sobre el botón")>
        Public Property HoverBackColor As Color
            Get
                Return _hoverBackColor
            End Get
            Set(value As Color)
                _hoverBackColor = value
            End Set
        End Property

        ''' <summary>
        ''' Color de fondo cuando el botón está presionado
        ''' </summary>
        <Category("Apariencia NX")>
        <Description("Color de fondo cuando el botón está presionado")>
        Public Property PressedBackColor As Color
            Get
                Return _pressedBackColor
            End Get
            Set(value As Color)
                _pressedBackColor = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Public Sub New()
            ' Configurar estilos para renderizado óptimo
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor Or
                       ControlStyles.Selectable, True)

            ' Configuración inicial
            Me.Size = New Size(120, 40)
            Me.BackColor = Color.FromArgb(0, 120, 215)
            Me.ForeColor = Color.White
            Me.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular)
            Me.Cursor = Cursors.Hand
            Me.TabStop = True
        End Sub

#End Region

#Region "Métodos Protegidos - Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Determinar color de fondo según estado
            Dim buttonColor As Color = GetCurrentBackColor()
            Dim textColor As Color = If(Me.Enabled, Me.ForeColor, Color.FromArgb(160, Me.ForeColor))

            ' Crear región del botón
            Dim rectSurface As Rectangle = Me.ClientRectangle
            Dim rectBorder As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            Using path As GraphicsPath = GetRoundedRectangle(rectBorder, _borderRadius)
                ' Establecer región del control
                Me.Region = New Region(path)

                ' Dibujar fondo según estilo
                Select Case _buttonStyle
                    Case ButtonStyle.Solid
                        Using brush As New SolidBrush(buttonColor)
                            g.FillPath(brush, path)
                        End Using

                    Case ButtonStyle.Gradient
                        Using brush As New LinearGradientBrush(rectSurface, buttonColor,
                                                              ControlPaint.Dark(buttonColor, 0.15F),
                                                              LinearGradientMode.Vertical)
                            g.FillPath(brush, path)
                        End Using

                    Case ButtonStyle.Outline
                        ' Fondo transparente o blanco
                        Using brush As New SolidBrush(If(_isHovered OrElse _isPressed, Color.FromArgb(20, buttonColor), Me.Parent?.BackColor))
                            g.FillPath(brush, path)
                        End Using
                        textColor = If(Me.Enabled, buttonColor, Color.FromArgb(160, buttonColor))
                End Select

                ' Dibujar borde
                If _borderSize > 0 OrElse _buttonStyle = ButtonStyle.Outline Then
                    Dim borderWidth As Integer = If(_buttonStyle = ButtonStyle.Outline AndAlso _borderSize = 0, 2, _borderSize)
                    Using pen As New Pen(If(Me.Enabled, _borderColor, _disabledBackColor), borderWidth)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using
                End If

                ' Indicador de foco
                If _isFocused AndAlso Me.TabStop Then
                    Dim rectFocus As New Rectangle(3, 3, Me.Width - 7, Me.Height - 7)
                    Using pathFocus As GraphicsPath = GetRoundedRectangle(rectFocus, _borderRadius - 2)
                        Using pen As New Pen(Color.FromArgb(100, Color.White), 1)
                            pen.DashStyle = DashStyle.Dot
                            g.DrawPath(pen, pathFocus)
                        End Using
                    End Using
                End If
            End Using

            ' Dibujar texto centrado
            Dim textRect As Rectangle = Me.ClientRectangle
            TextRenderer.DrawText(g, Me.Text, Me.Font, textRect, textColor,
                                TextFormatFlags.HorizontalCenter Or
                                TextFormatFlags.VerticalCenter Or
                                TextFormatFlags.EndEllipsis)

            MyBase.OnPaint(e)
        End Sub

        ''' <summary>
        ''' Obtiene el color de fondo actual según el estado del botón
        ''' </summary>
        Private Function GetCurrentBackColor() As Color
            If Not Me.Enabled Then
                Return _disabledBackColor
            ElseIf _isPressed AndAlso _pressedBackColor <> Color.Empty Then
                Return _pressedBackColor
            ElseIf _isPressed Then
                Return ControlPaint.Dark(Me.BackColor, 0.2F)
            ElseIf _isHovered AndAlso _hoverBackColor <> Color.Empty Then
                Return _hoverBackColor
            ElseIf _isHovered Then
                Return ControlPaint.Light(Me.BackColor, 0.15F)
            Else
                Return Me.BackColor
            End If
        End Function

        ''' <summary>
        ''' Crea una ruta de gráficos con esquinas redondeadas
        ''' </summary>
        Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            ' Ajustar radio si es muy grande
            If radius > rect.Height / 2 Then radius = rect.Height / 2
            If radius > rect.Width / 2 Then radius = rect.Width / 2
            If radius <= 0 Then radius = 1

            Dim diameter As Integer = radius * 2

            ' Crear rectángulo con esquinas redondeadas
            path.StartFigure()
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
            path.CloseFigure()

            Return path
        End Function

#End Region

#Region "Métodos Protegidos - Eventos de Mouse"

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            _isHovered = True
            Me.Invalidate()
            MyBase.OnMouseEnter(e)
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            _isHovered = False
            _isPressed = False
            Me.Invalidate()
            MyBase.OnMouseLeave(e)
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                _isPressed = True
                Me.Invalidate()
            End If
            MyBase.OnMouseDown(e)
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            If _isPressed Then
                _isPressed = False
                Me.Invalidate()
            End If
            MyBase.OnMouseUp(e)
        End Sub

#End Region

#Region "Métodos Protegidos - Eventos de Teclado"

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter Then
                _isPressed = True
                Me.Invalidate()
                MyBase.OnClick(EventArgs.Empty)
            End If
            MyBase.OnKeyDown(e)
        End Sub

        Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter Then
                _isPressed = False
                Me.Invalidate()
            End If
            MyBase.OnKeyUp(e)
        End Sub

#End Region

#Region "Métodos Protegidos - Eventos de Foco"

        Protected Overrides Sub OnGotFocus(e As EventArgs)
            _isFocused = True
            Me.Invalidate()
            MyBase.OnGotFocus(e)
        End Sub

        Protected Overrides Sub OnLostFocus(e As EventArgs)
            _isFocused = False
            Me.Invalidate()
            MyBase.OnLostFocus(e)
        End Sub

#End Region

#Region "Métodos Protegidos - Otros"

        Protected Overrides Sub OnEnabledChanged(e As EventArgs)
            Me.Invalidate()
            MyBase.OnEnabledChanged(e)
        End Sub

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            Me.Invalidate()
            MyBase.OnTextChanged(e)
        End Sub

#End Region

    End Class

End Namespace
