Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Control de interruptor tipo toggle con animaciones suaves y colores personalizables
    ''' </summary>
    <ToolboxBitmap(GetType(CheckBox))>
    <DefaultProperty("IsOn")>
    <DefaultEvent("IsOnChanged")>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    Public Class NXToggleSwitch
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Posición del texto respecto al switch
        ''' </summary>
        Public Enum TextAlign
            ''' <summary>Texto a la izquierda del switch</summary>
            [Left]
            ''' <summary>Texto centrado (encima del switch)</summary>
            Center
            ''' <summary>Texto a la derecha del switch</summary>
            [Right]
        End Enum

        ''' <summary>
        ''' Posición del switch dentro del control (estilo DevExpress)
        ''' </summary>
        Public Enum SwitchAlignment
            ''' <summary>Switch a la izquierda</summary>
            Near
            ''' <summary>Switch centrado</summary>
            Center
            ''' <summary>Switch a la derecha</summary>
            Far
        End Enum

        ''' <summary>
        ''' Tamaño predefinido del switch
        ''' </summary>
        Public Enum ToggleSize
            ''' <summary>Pequeño (40x20)</summary>
            Small
            ''' <summary>Mediano (50x25)</summary>
            Medium
            ''' <summary>Grande (60x30)</summary>
            Large
            ''' <summary>Extra Grande (70x35)</summary>
            ExtraLarge
            ''' <summary>Tamaño personalizado</summary>
            Custom
        End Enum

#End Region

#Region "Campos Privados"

        ' Estado
        Private _isOn As Boolean = False
        Private _enabled As Boolean = True

        ' Tamaño
        Private _toggleSize As ToggleSize = ToggleSize.Medium
        Private _switchWidth As Integer = 50
        Private _switchHeight As Integer = 25

        ' Colores
        Private _onColor As Color = Color.FromArgb(0, 120, 215)
        Private _offColor As Color = Color.FromArgb(200, 200, 200)
        Private _thumbColor As Color = Color.White
        Private _borderColor As Color = Color.FromArgb(180, 180, 180)
        Private _disabledColor As Color = Color.FromArgb(220, 220, 220)

        ' Texto
        Private _textOn As String = "ON"
        Private _textOff As String = "OFF"
        Private _showText As Boolean = False
        Private _textAlignment As TextAlign = TextAlign.Left
        Private _textPadding As Integer = 8

        ' Posición del Switch (GlyphAlignment estilo DevExpress)
        Private _glyphAlignment As SwitchAlignment = SwitchAlignment.Near

        ' Animación
        Private WithEvents _animationTimer As New Timer With {.Interval = 10}
        Private _thumbPosition As Single = 0
        Private _targetPosition As Single = 0
        Private _animationSpeed As Single = 0.15F
        Private _useAnimation As Boolean = True

        ' Interacción
        Private _isHovering As Boolean = False
        Private _isPressed As Boolean = False

        ' Borde y Forma
        Private _borderSize As Integer = 1
        Private _borderRadius As Integer = 12

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor Or
                       ControlStyles.Selectable, True)

            ' Usar color sólido por defecto (240,240,240) para evitar bug de renderizado múltiple
            Me.BackColor = Color.White
            Me.ForeColor = Color.FromArgb(33, 33, 33)
            Me.Font = New Font("Segoe UI", 9.0F)
            Me.Cursor = Cursors.Hand

            ' Configurar tamaño inicial
            UpdateSizeFromToggleSize()
            CalculateInitialThumbPosition()
        End Sub

#End Region

#Region "Propiedades - Estado"

        <Category("Behavior")>
        <Description("Indica si el switch está activado (ON) o desactivado (OFF)")>
        <DefaultValue(False)>
        Public Property IsOn As Boolean
            Get
                Return _isOn
            End Get
            Set(value As Boolean)
                If _isOn <> value Then
                    _isOn = value
                    AnimateToState(value)
                    RaiseEvent IsOnChanged(Me, EventArgs.Empty)
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Behavior")>
        <Description("Indica si el control está habilitado")>
        <DefaultValue(True)>
        Public Shadows Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                If _enabled <> value Then
                    _enabled = value
                    Me.Cursor = If(value, Cursors.Hand, Cursors.Default)
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Tamaño"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Tamaño predefinido del switch")>
        <DefaultValue(GetType(ToggleSize), "Medium")>
        Public Property SwitchSize As ToggleSize
            Get
                Return _toggleSize
            End Get
            Set(value As ToggleSize)
                If _toggleSize <> value Then
                    _toggleSize = value
                    If value <> ToggleSize.Custom Then
                        UpdateSizeFromToggleSize()
                    End If
                    CalculateInitialThumbPosition()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Ancho del switch (solo cuando SwitchSize es Custom)")>
        <DefaultValue(50)>
        Public Property SwitchWidth As Integer
            Get
                Return _switchWidth
            End Get
            Set(value As Integer)
                If value < 30 Then value = 30
                If value > 200 Then value = 200
                If _switchWidth <> value Then
                    _switchWidth = value
                    If _toggleSize = ToggleSize.Custom Then
                        UpdateControlSize()
                        CalculateInitialThumbPosition()
                    End If
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Alto del switch (solo cuando SwitchSize es Custom)")>
        <DefaultValue(25)>
        Public Property SwitchHeight As Integer
            Get
                Return _switchHeight
            End Get
            Set(value As Integer)
                If value < 15 Then value = 15
                If value > 100 Then value = 100
                If _switchHeight <> value Then
                    _switchHeight = value
                    If _toggleSize = ToggleSize.Custom Then
                        UpdateControlSize()
                        CalculateInitialThumbPosition()
                    End If
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Colores"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color cuando el switch está activado (ON)")>
        Public Property OnColor As Color
            Get
                Return _onColor
            End Get
            Set(value As Color)
                If _onColor <> value Then
                    _onColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color cuando el switch está desactivado (OFF)")>
        Public Property OffColor As Color
            Get
                Return _offColor
            End Get
            Set(value As Color)
                If _offColor <> value Then
                    _offColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del círculo deslizante (thumb)")>
        Public Property ThumbColor As Color
            Get
                Return _thumbColor
            End Get
            Set(value As Color)
                If _thumbColor <> value Then
                    _thumbColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del borde del switch")>
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
        <Description("Color cuando el switch está deshabilitado")>
        Public Property DisabledColor As Color
            Get
                Return _disabledColor
            End Get
            Set(value As Color)
                If _disabledColor <> value Then
                    _disabledColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Texto"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Texto que se muestra cuando el switch está activado")>
        <DefaultValue("ON")>
        Public Property TextOn As String
            Get
                Return _textOn
            End Get
            Set(value As String)
                If _textOn <> value Then
                    _textOn = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Texto que se muestra cuando el switch está desactivado")>
        <DefaultValue("OFF")>
        Public Property TextOff As String
            Get
                Return _textOff
            End Get
            Set(value As String)
                If _textOff <> value Then
                    _textOff = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Muestra el texto del estado actual")>
        <DefaultValue(False)>
        Public Property ShowText As Boolean
            Get
                Return _showText
            End Get
            Set(value As Boolean)
                If _showText <> value Then
                    _showText = value
                    UpdateControlSize()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Alineación del texto respecto al switch")>
        <DefaultValue(GetType(TextAlign), "Left")>
        Public Property TextAlignment As TextAlign
            Get
                Return _textAlignment
            End Get
            Set(value As TextAlign)
                If _textAlignment <> value Then
                    _textAlignment = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Posición del switch dentro del control (Near=Izq, Center=Centro, Far=Der)")>
        <DefaultValue(GetType(SwitchAlignment), "Near")>
        Public Property GlyphAlignment As SwitchAlignment
            Get
                Return _glyphAlignment
            End Get
            Set(value As SwitchAlignment)
                If _glyphAlignment <> value Then
                    _glyphAlignment = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Espaciado entre el texto y el switch")>
        <DefaultValue(8)>
        Public Property TextPadding As Integer
            Get
                Return _textPadding
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _textPadding <> value Then
                    _textPadding = value
                    UpdateControlSize()
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Animación"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Habilita animaciones suaves al cambiar de estado")>
        <DefaultValue(True)>
        Public Property UseAnimation As Boolean
            Get
                Return _useAnimation
            End Get
            Set(value As Boolean)
                If _useAnimation <> value Then
                    _useAnimation = value
                    If Not value Then
                        _animationTimer.Stop()
                        CalculateInitialThumbPosition()
                    End If
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Velocidad de la animación (0.05 = lento, 0.3 = rápido)")>
        <DefaultValue(0.15F)>
        Public Property AnimationSpeed As Single
            Get
                Return _animationSpeed
            End Get
            Set(value As Single)
                If value < 0.05F Then value = 0.05F
                If value > 0.5F Then value = 0.5F
                _animationSpeed = value
            End Set
        End Property

#End Region

#Region "Propiedades - Borde"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Grosor del borde")>
        <DefaultValue(1)>
        Public Property BorderSize As Integer
            Get
                Return _borderSize
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If value > 5 Then value = 5
                If _borderSize <> value Then
                    _borderSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Radio de las esquinas redondeadas del switch")>
        <DefaultValue(12)>
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

#End Region

#Region "Eventos"

        ''' <summary>
        ''' Se dispara cuando el estado IsOn cambia
        ''' </summary>
        <Category("Action")>
        <Description("Se dispara cuando el estado IsOn cambia")>
        Public Event IsOnChanged As EventHandler

#End Region

#Region "Métodos Privados - Tamaño"

        Private Sub UpdateSizeFromToggleSize()
            Select Case _toggleSize
                Case ToggleSize.Small
                    _switchWidth = 40
                    _switchHeight = 20
                Case ToggleSize.Medium
                    _switchWidth = 50
                    _switchHeight = 25
                Case ToggleSize.Large
                    _switchWidth = 60
                    _switchHeight = 30
                Case ToggleSize.ExtraLarge
                    _switchWidth = 70
                    _switchHeight = 35
                Case ToggleSize.Custom
                    ' Mantener valores personalizados
            End Select

            _borderRadius = _switchHeight \ 2
            UpdateControlSize()
        End Sub

        Private Sub UpdateControlSize()
            ' CRÍTICO: No forzar el tamaño en tiempo de diseño
            Dim isDesignMode As Boolean = (LicenseManager.UsageMode = LicenseUsageMode.Designtime)

            ' En tiempo de diseño, NO actualizar el tamaño automáticamente
            ' El usuario debe poder arrastrarlo al tamaño que quiera
            If isDesignMode Then
                Return
            End If

            ' En tiempo de ejecución, el tamaño es fijo según el SwitchSize
            ' GlyphAlignment NO afecta el tamaño, solo la posición interna
            Dim totalWidth As Integer = _switchWidth
            Dim totalHeight As Integer = _switchHeight

            Me.Size = New Size(totalWidth, totalHeight)
        End Sub

        Private Sub CalculateInitialThumbPosition()
            If _isOn Then
                _thumbPosition = GetThumbMaxPosition()
                _targetPosition = _thumbPosition
            Else
                _thumbPosition = GetThumbMinPosition()
                _targetPosition = _thumbPosition
            End If
        End Sub

        Private Function GetThumbMinPosition() As Single
            Dim thumbDiameter As Integer = _switchHeight - 6
            Return 3
        End Function

        Private Function GetThumbMaxPosition() As Single
            Dim thumbDiameter As Integer = _switchHeight - 6
            Return _switchWidth - thumbDiameter - 3
        End Function

#End Region

#Region "Métodos Privados - Animación"

        Private Sub AnimateToState(isOn As Boolean)
            If Not _useAnimation Then
                _thumbPosition = If(isOn, GetThumbMaxPosition(), GetThumbMinPosition())
                _targetPosition = _thumbPosition
                Return
            End If

            _targetPosition = If(isOn, GetThumbMaxPosition(), GetThumbMinPosition())
            _animationTimer.Start()
        End Sub

        Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles _animationTimer.Tick
            Dim difference As Single = _targetPosition - _thumbPosition

            If Math.Abs(difference) < 0.5F Then
                _thumbPosition = _targetPosition
                _animationTimer.Stop()
            Else
                _thumbPosition += difference * _animationSpeed
            End If

            Me.Invalidate()
        End Sub

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            ' CRÍTICO: Limpiar área en tiempo de diseño para evitar renderizado múltiple
            Dim isDesignMode As Boolean = (LicenseManager.UsageMode = LicenseUsageMode.Designtime)

            If isDesignMode AndAlso Me.BackColor = Color.Transparent Then
                ' En tiempo de diseño con fondo transparente, limpiar primero
                Dim parentColor As Color = If(Me.Parent IsNot Nothing, Me.Parent.BackColor, SystemColors.Control)
                e.Graphics.Clear(parentColor)
            End If

            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Calcular rectángulos
            Dim switchRect As Rectangle = GetSwitchRectangle()
            Dim textRect As Rectangle = GetTextRectangle(switchRect)

            ' Dibujar switch
            DrawSwitch(g, switchRect)

            ' Dibujar texto si está habilitado
            If _showText Then
                DrawText(g, textRect)
            End If

            MyBase.OnPaint(e)
        End Sub

        Private Function GetSwitchRectangle() As Rectangle
            Dim x As Integer = 0
            Dim y As Integer = (Me.Height - _switchHeight) \ 2

            ' GlyphAlignment controla la posición del SWITCH dentro del control
            Select Case _glyphAlignment
                Case SwitchAlignment.Near
                    x = 0
                Case SwitchAlignment.Center
                    x = (Me.Width - _switchWidth) \ 2
                Case SwitchAlignment.Far
                    x = Me.Width - _switchWidth
            End Select

            Return New Rectangle(x, y, _switchWidth, _switchHeight)
        End Function

        Private Function GetTextRectangle(switchRect As Rectangle) As Rectangle
            If Not _showText Then Return Rectangle.Empty

            Dim text As String = If(_isOn, _textOn, _textOff)
            Dim textSize As Size = TextRenderer.MeasureText(text, Me.Font)
            Dim x As Integer = 0
            Dim y As Integer = (Me.Height - textSize.Height) \ 2

            ' TextAlignment controla la posición del TEXTO dentro del control
            Select Case _textAlignment
                Case TextAlign.Left
                    x = _textPadding
                Case TextAlign.Center
                    x = (Me.Width - textSize.Width) \ 2
                Case TextAlign.Right
                    x = Me.Width - textSize.Width - _textPadding
            End Select

            Return New Rectangle(x, y, textSize.Width, textSize.Height)
        End Function

        Private Sub DrawSwitch(g As Graphics, rect As Rectangle)
            ' Determinar color de fondo
            Dim backColor As Color
            If Not _enabled Then
                backColor = _disabledColor
            ElseIf _isOn Then
                backColor = _onColor
            Else
                backColor = _offColor
            End If

            ' Aplicar efecto hover
            If _enabled AndAlso _isHovering Then
                backColor = ControlPaint.Light(backColor, 0.1F)
            End If

            ' Aplicar efecto pressed
            If _enabled AndAlso _isPressed Then
                backColor = ControlPaint.Dark(backColor, 0.05F)
            End If

            ' Dibujar fondo del switch
            Using path As GraphicsPath = GetRoundedRectangle(rect, _borderRadius)
                Using brush As New SolidBrush(backColor)
                    g.FillPath(brush, path)
                End Using

                ' Dibujar borde si es necesario
                If _borderSize > 0 Then
                    Using pen As New Pen(_borderColor, _borderSize)
                        g.DrawPath(pen, path)
                    End Using
                End If
            End Using

            ' Dibujar thumb (círculo deslizante)
            DrawThumb(g, rect)
        End Sub

        Private Sub DrawThumb(g As Graphics, switchRect As Rectangle)
            Dim thumbDiameter As Integer = _switchHeight - 6
            Dim thumbY As Integer = switchRect.Y + 3
            Dim thumbX As Integer = CInt(switchRect.X + _thumbPosition)

            Dim thumbRect As New Rectangle(thumbX, thumbY, thumbDiameter, thumbDiameter)

            ' Sombra del thumb
            If _enabled Then
                Using shadowPath As GraphicsPath = GetRoundedRectangle(
                    New Rectangle(thumbX + 1, thumbY + 1, thumbDiameter, thumbDiameter),
                    thumbDiameter \ 2)
                    Using shadowBrush As New SolidBrush(Color.FromArgb(50, 0, 0, 0))
                        g.FillPath(shadowBrush, shadowPath)
                    End Using
                End Using
            End If

            ' Thumb principal
            Using thumbPath As GraphicsPath = GetRoundedRectangle(thumbRect, thumbDiameter \ 2)
                Dim thumbColor As Color = If(_enabled, _thumbColor, ControlPaint.Light(_disabledColor, 0.2F))
                Using brush As New SolidBrush(thumbColor)
                    g.FillPath(brush, thumbPath)
                End Using

                ' Borde del thumb
                If _enabled Then
                    Using pen As New Pen(Color.FromArgb(50, 0, 0, 0), 1)
                        g.DrawPath(pen, thumbPath)
                    End Using
                End If
            End Using
        End Sub

        Private Sub DrawText(g As Graphics, rect As Rectangle)
            If rect = Rectangle.Empty Then Return

            Dim text As String = If(_isOn, _textOn, _textOff)
            Dim textColor As Color = If(_enabled, Me.ForeColor, _disabledColor)

            Using brush As New SolidBrush(textColor)
                Dim sf As New StringFormat With {
                    .Alignment = StringAlignment.Near,
                    .LineAlignment = StringAlignment.Center
                }
                g.DrawString(text, Me.Font, brush, rect, sf)
            End Using
        End Sub

        Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            Dim diameter As Integer = radius * 2
            Dim arc As New Rectangle(rect.Location, New Size(diameter, diameter))

            ' Esquina superior izquierda
            path.AddArc(arc, 180, 90)

            ' Esquina superior derecha
            arc.X = rect.Right - diameter
            path.AddArc(arc, 270, 90)

            ' Esquina inferior derecha
            arc.Y = rect.Bottom - diameter
            path.AddArc(arc, 0, 90)

            ' Esquina inferior izquierda
            arc.X = rect.Left
            path.AddArc(arc, 90, 90)

            path.CloseFigure()
            Return path
        End Function

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            If Me.BackColor <> Color.Transparent Then
                MyBase.OnPaintBackground(e)
            End If
        End Sub

#End Region

#Region "Eventos del Mouse"

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            If _enabled Then
                _isHovering = True
                Me.Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            _isHovering = False
            _isPressed = False
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If _enabled AndAlso e.Button = MouseButtons.Left Then
                _isPressed = True
                Me.Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            _isPressed = False
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnClick(e As EventArgs)
            MyBase.OnClick(e)
            If _enabled Then
                Me.IsOn = Not Me.IsOn
            End If
        End Sub

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            MyBase.OnKeyDown(e)
            If _enabled AndAlso (e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter) Then
                Me.IsOn = Not Me.IsOn
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

            Me.OnColor = theme.PrimaryColor
            Me.OffColor = theme.BorderColor
            Me.ThumbColor = theme.ControlBackColor
            Me.BorderColor = theme.BorderColor
            Me.ForeColor = theme.ForeColor
            Me.DisabledColor = theme.DisabledColor
            Me.Invalidate()
        End Sub

#End Region

#Region "Dispose"

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If _animationTimer IsNot Nothing Then
                    _animationTimer.Stop()
                    _animationTimer.Dispose()
                    _animationTimer = Nothing
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#End Region

    End Class

End Namespace