Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Barra de progreso avanzada con soporte de texto, separadores y control de operaciones
    ''' </summary>
    <ToolboxBitmap(GetType(ProgressBar))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DefaultProperty("Value")>
    <DefaultEvent("ValueChanged")>
    Public Class NXProgressBar
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Estilo de visualización de la barra de progreso
        ''' </summary>
        Public Enum ProgressBarStyle
            Continuous      ' Barra continua
            Blocks          ' Bloques separados
            Marquee         ' Animación continua (indeterminado)
        End Enum

        ''' <summary>
        ''' Posición del texto de porcentaje
        ''' </summary>
        Public Enum TextPosition
            None            ' No mostrar texto
            Center          ' Centro de la barra
            Right           ' Derecha de la barra
            Custom          ' Posición personalizada
        End Enum

        ''' <summary>
        ''' Orientación de la barra
        ''' </summary>
        Public Enum ProgressBarOrientation
            Horizontal
            Vertical
        End Enum

#End Region

#Region "Campos Privados"

        ' Valores de progreso
        Private _minimum As Integer = 0
        Private _maximum As Integer = 100
        Private _value As Integer = 0
        Private _step As Integer = 1

        ' Apariencia
        Private _progressColor As Color = Color.FromArgb(0, 120, 215)
        Private _progressColor2 As Color = Color.Empty ' Para gradiente
        Private _backgroundColor As Color = Color.FromArgb(230, 230, 230)
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _borderRadius As Integer = 4
        Private _borderSize As Integer = 1

        ' Estilo
        Private _style As ProgressBarStyle = ProgressBarStyle.Continuous
        Private _orientation As ProgressBarOrientation = ProgressBarOrientation.Horizontal

        ' Texto
        Private _showPercentage As Boolean = True
        Private _textPosition As TextPosition = TextPosition.Center
        Private _customText As String = String.Empty
        Private _textFormat As String = "{0}%" ' Formato del porcentaje
        Private _textColor As Color = Color.White
        Private _textFont As Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

        ' Separadores
        Private _showSeparators As Boolean = False
        Private _separatorCount As Integer = 10
        Private _separatorWidth As Integer = 2
        Private _separatorColor As Color = Color.White

        ' Animación y operación
        Private _isOperationInProgress As Boolean = False
        Private _marqueeSpeed As Integer = 30 ' Velocidad del marquee
        Private _marqueePosition As Integer = 0
        Private _animationTimer As Timer

        ' Gradiente
        Private _useGradient As Boolean = True
        Private _gradientMode As LinearGradientMode = LinearGradientMode.Horizontal

        ' Interacción con mouse
        Private _allowMouseInteraction As Boolean = True

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            Me.Size = New Size(300, 25)
            Me.BackColor = Color.Transparent
            Me.Cursor = Cursors.Hand ' Cursor por defecto

            ' Timer para animación de marquee
            _animationTimer = New Timer()
            _animationTimer.Interval = 50
            AddHandler _animationTimer.Tick, AddressOf AnimationTimer_Tick
        End Sub

#End Region

#Region "Propiedades - Valores"

        <Category("Behavior")>
        <NXProperty()>
        <Description("Valor mínimo de la barra de progreso")>
        <DefaultValue(0)>
        Public Property Minimum As Integer
            Get
                Return _minimum
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If value >= _maximum Then value = _maximum - 1

                If _minimum <> value Then
                    _minimum = value
                    If _value < _minimum Then _value = _minimum
                    Me.Invalidate()
                    RaiseEvent ValueChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Valor máximo de la barra de progreso")>
        <DefaultValue(100)>
        Public Property Maximum As Integer
            Get
                Return _maximum
            End Get
            Set(value As Integer)
                If value <= _minimum Then value = _minimum + 1

                If _maximum <> value Then
                    _maximum = value
                    If _value > _maximum Then _value = _maximum
                    Me.Invalidate()
                    RaiseEvent ValueChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Valor actual de la barra de progreso")>
        <DefaultValue(0)>
        Public Property Value As Integer
            Get
                Return _value
            End Get
            Set(value As Integer)
                ' Solo validar rango si NO hay operación activa
                ' Durante operación, Increment() controla el flujo
                If Not _isOperationInProgress Then
                    If value < _minimum Then value = _minimum
                    If value > _maximum Then value = _maximum

                    If _value <> value Then
                        _value = value
                        Me.Invalidate()
                        RaiseEvent ValueChanged(Me, EventArgs.Empty)
                    End If
                Else
                    ' Durante operación, solo permitir cambios dentro del rango
                    If value < _minimum Then value = _minimum
                    If value > _maximum Then value = _maximum

                    If _value <> value Then
                        _value = value
                        Me.Invalidate()
                        RaiseEvent ValueChanged(Me, EventArgs.Empty)
                    End If
                End If
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Incremento al llamar PerformStep")>
        <DefaultValue(1)>
        Public Property [Step] As Integer
            Get
                Return _step
            End Get
            Set(value As Integer)
                _step = value
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Indica si hay una operación en progreso (previene cambios de valor)")>
        <DefaultValue(False)>
        Public Property IsOperationInProgress As Boolean
            Get
                Return _isOperationInProgress
            End Get
            Set(value As Boolean)
                If _isOperationInProgress <> value Then
                    _isOperationInProgress = value
                    UpdateCursor()
                    RaiseEvent OperationStateChanged(Me, EventArgs.Empty)

                    ' Si se inicia operación con style Marquee, iniciar animación
                    If value AndAlso _style = ProgressBarStyle.Marquee Then
                        StartMarquee()
                    ElseIf Not value Then
                        StopMarquee()
                    End If
                End If
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Permite cambiar el valor haciendo clic con el mouse")>
        <DefaultValue(True)>
        Public Property AllowMouseInteraction As Boolean
            Get
                Return _allowMouseInteraction
            End Get
            Set(value As Boolean)
                _allowMouseInteraction = value
                UpdateCursor()
            End Set
        End Property

        Private Sub UpdateCursor()
            If _allowMouseInteraction AndAlso Not _isOperationInProgress AndAlso _style <> ProgressBarStyle.Marquee Then
                Me.Cursor = Cursors.Hand
            Else
                Me.Cursor = Cursors.Default
            End If
        End Sub

#End Region

#Region "Propiedades - Apariencia"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de la barra de progreso")>
        Public Property ProgressColor As Color
            Get
                Return _progressColor
            End Get
            Set(value As Color)
                _progressColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color secundario para gradiente (vacío para no usar gradiente)")>
        Public Property ProgressColor2 As Color
            Get
                Return _progressColor2
            End Get
            Set(value As Color)
                _progressColor2 = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de fondo de la barra")>
        Public Property BackgroundColor As Color
            Get
                Return _backgroundColor
            End Get
            Set(value As Color)
                _backgroundColor = value
                Me.Invalidate()
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
                _borderColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Radio de las esquinas redondeadas")>
        <DefaultValue(4)>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                _borderRadius = value
                Me.Invalidate()
            End Set
        End Property

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
                _borderSize = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Usar gradiente para la barra de progreso")>
        <DefaultValue(True)>
        Public Property UseGradient As Boolean
            Get
                Return _useGradient
            End Get
            Set(value As Boolean)
                _useGradient = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Modo de gradiente")>
        <DefaultValue(GetType(LinearGradientMode), "Horizontal")>
        Public Property GradientMode As LinearGradientMode
            Get
                Return _gradientMode
            End Get
            Set(value As LinearGradientMode)
                _gradientMode = value
                Me.Invalidate()
            End Set
        End Property

#End Region

#Region "Propiedades - Estilo"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo de la barra de progreso")>
        <DefaultValue(GetType(ProgressBarStyle), "Continuous")>
        Public Property Style As ProgressBarStyle
            Get
                Return _style
            End Get
            Set(value As ProgressBarStyle)
                If _style <> value Then
                    _style = value
                    UpdateCursor()

                    ' Si cambia a Marquee y hay operación, iniciar animación
                    If value = ProgressBarStyle.Marquee AndAlso _isOperationInProgress Then
                        StartMarquee()
                    Else
                        StopMarquee()
                    End If

                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Orientación de la barra")>
        <DefaultValue(GetType(ProgressBarOrientation), "Horizontal")>
        Public Property Orientation As ProgressBarOrientation
            Get
                Return _orientation
            End Get
            Set(value As ProgressBarOrientation)
                _orientation = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Velocidad de animación del marquee (ms)")>
        <DefaultValue(30)>
        Public Property MarqueeSpeed As Integer
            Get
                Return _marqueeSpeed
            End Get
            Set(value As Integer)
                If value < 1 Then value = 1
                _marqueeSpeed = value
            End Set
        End Property

#End Region

#Region "Propiedades - Texto"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Mostrar porcentaje en la barra")>
        <DefaultValue(True)>
        Public Property ShowPercentage As Boolean
            Get
                Return _showPercentage
            End Get
            Set(value As Boolean)
                _showPercentage = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Posición del texto")>
        <DefaultValue(GetType(TextPosition), "Center")>
        Public Property TextPositions As TextPosition
            Get
                Return _textPosition
            End Get
            Set(value As TextPosition)
                _textPosition = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Texto personalizado (usar {0} para el porcentaje)")>
        <DefaultValue("")>
        Public Property CustomText As String
            Get
                Return _customText
            End Get
            Set(value As String)
                _customText = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Formato del texto de porcentaje")>
        <DefaultValue("{0}%")>
        Public Property TextFormat As String
            Get
                Return _textFormat
            End Get
            Set(value As String)
                _textFormat = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del texto")>
        Public Property TextColor As Color
            Get
                Return _textColor
            End Get
            Set(value As Color)
                _textColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Fuente del texto")>
        Public Property TextFont As Font
            Get
                Return _textFont
            End Get
            Set(value As Font)
                _textFont = value
                Me.Invalidate()
            End Set
        End Property

#End Region

#Region "Propiedades - Separadores"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Mostrar separadores en la barra")>
        <DefaultValue(False)>
        Public Property ShowSeparators As Boolean
            Get
                Return _showSeparators
            End Get
            Set(value As Boolean)
                _showSeparators = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Número de separadores")>
        <DefaultValue(10)>
        Public Property SeparatorCount As Integer
            Get
                Return _separatorCount
            End Get
            Set(value As Integer)
                If value < 1 Then value = 1
                _separatorCount = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Ancho de los separadores")>
        <DefaultValue(2)>
        Public Property SeparatorWidth As Integer
            Get
                Return _separatorWidth
            End Get
            Set(value As Integer)
                If value < 1 Then value = 1
                _separatorWidth = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de los separadores")>
        Public Property SeparatorColor As Color
            Get
                Return _separatorColor
            End Get
            Set(value As Color)
                _separatorColor = value
                Me.Invalidate()
            End Set
        End Property

#End Region

#Region "Propiedades Calculadas"

        ''' <summary>
        ''' Obtiene el porcentaje actual (0-100)
        ''' </summary>
        <Browsable(False)>
        Public ReadOnly Property PercentComplete As Double
            Get
                If _maximum = _minimum Then Return 0
                Return ((_value - _minimum) / (_maximum - _minimum)) * 100.0
            End Get
        End Property

#End Region

#Region "Eventos"

        Public Event ValueChanged As EventHandler
        Public Event OperationStateChanged As EventHandler
        Public Event ProgressCompleted As EventHandler

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Incrementa el valor por la cantidad especificada en Step
        ''' </summary>
        Public Sub PerformStep()
            Increment(_step)
        End Sub

        ''' <summary>
        ''' Incrementa el valor por la cantidad especificada
        ''' </summary>
        Public Sub Increment(amount As Integer)
            If _isOperationInProgress Then
                Dim newValue As Integer = _value + amount
                If newValue > _maximum Then
                    newValue = _maximum
                    CompleteOperation()
                End If
                Value = newValue
            End If
        End Sub

        ''' <summary>
        ''' Inicia una operación de progreso
        ''' </summary>
        Public Sub BeginOperation()
            IsOperationInProgress = True
            If _style <> ProgressBarStyle.Marquee Then
                Value = _minimum
            End If
        End Sub

        ''' <summary>
        ''' Completa la operación de progreso
        ''' </summary>
        Public Sub CompleteOperation()
            If _isOperationInProgress Then
                If _style <> ProgressBarStyle.Marquee Then
                    Value = _maximum
                End If
                IsOperationInProgress = False
                RaiseEvent ProgressCompleted(Me, EventArgs.Empty)
            End If
        End Sub

        ''' <summary>
        ''' Cancela la operación en progreso
        ''' </summary>
        Public Sub CancelOperation()
            IsOperationInProgress = False
            StopMarquee()
        End Sub

        ''' <summary>
        ''' Reinicia la barra de progreso
        ''' </summary>
        Public Sub Reset()
            Value = _minimum
            IsOperationInProgress = False
        End Sub

#End Region

#Region "Métodos Privados - Animación"

        Private Sub StartMarquee()
            If Not _animationTimer.Enabled Then
                _marqueePosition = 0
                _animationTimer.Start()
            End If
        End Sub

        Private Sub StopMarquee()
            If _animationTimer.Enabled Then
                _animationTimer.Stop()
            End If
        End Sub

        Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs)
            If _style = ProgressBarStyle.Marquee Then
                _marqueePosition += _marqueeSpeed
                If _marqueePosition > Me.Width Then
                    _marqueePosition = -100
                End If
                Me.Invalidate()
            End If
        End Sub

#End Region

#Region "Eventos de Mouse"

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If _allowMouseInteraction AndAlso Not _isOperationInProgress AndAlso _style <> ProgressBarStyle.Marquee Then
                UpdateValueFromMousePosition(e.Location)
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If _allowMouseInteraction AndAlso Not _isOperationInProgress AndAlso _style <> ProgressBarStyle.Marquee Then
                If e.Button = MouseButtons.Left Then
                    UpdateValueFromMousePosition(e.Location)
                End If
            End If
        End Sub

        Private Sub UpdateValueFromMousePosition(location As Point)
            Dim percent As Double

            If _orientation = ProgressBarOrientation.Horizontal Then
                ' Calcular porcentaje basado en posición X
                Dim contentWidth As Integer = Me.Width - (_borderSize * 2)
                Dim clickX As Integer = location.X - _borderSize

                If clickX < 0 Then clickX = 0
                If clickX > contentWidth Then clickX = contentWidth

                percent = (clickX / contentWidth) * 100.0
            Else
                ' Calcular porcentaje basado en posición Y (invertido)
                Dim contentHeight As Integer = Me.Height - (_borderSize * 2)
                Dim clickY As Integer = Me.Height - location.Y - _borderSize

                If clickY < 0 Then clickY = 0
                If clickY > contentHeight Then clickY = contentHeight

                percent = (clickY / contentHeight) * 100.0
            End If

            ' Convertir porcentaje a valor
            Dim newValue As Integer = _minimum + CInt((percent / 100.0) * (_maximum - _minimum))

            If newValue <> _value Then
                Value = newValue
            End If
        End Sub

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            ' Dibujar fondo
            Using path As GraphicsPath = GetRoundedRectangle(rect, _borderRadius)
                Using brush As New SolidBrush(_backgroundColor)
                    g.FillPath(brush, path)
                End Using
            End Using

            ' Dibujar progreso según el estilo
            Select Case _style
                Case ProgressBarStyle.Continuous
                    DrawContinuousProgress(g)
                Case ProgressBarStyle.Blocks
                    DrawBlocksProgress(g)
                Case ProgressBarStyle.Marquee
                    DrawMarqueeProgress(g)
            End Select

            ' Dibujar separadores si están habilitados
            If _showSeparators AndAlso _style <> ProgressBarStyle.Marquee Then
                DrawSeparators(g)
            End If

            ' Dibujar borde
            If _borderSize > 0 Then
                Using path As GraphicsPath = GetRoundedRectangle(rect, _borderRadius)
                    Using pen As New Pen(_borderColor, _borderSize)
                        g.DrawPath(pen, path)
                    End Using
                End Using
            End If

            ' Dibujar texto
            If _showPercentage AndAlso _textPosition <> TextPosition.None Then
                DrawProgressText(g)
            End If
        End Sub

        Private Sub DrawContinuousProgress(g As Graphics)
            If _value <= _minimum Then Return

            Dim progressWidth As Integer
            Dim progressHeight As Integer
            Dim progressRect As Rectangle

            If _orientation = ProgressBarOrientation.Horizontal Then
                progressWidth = CInt((Me.Width - (_borderSize * 2)) * ((_value - _minimum) / (_maximum - _minimum)))
                progressHeight = Me.Height - (_borderSize * 2)
                progressRect = New Rectangle(_borderSize, _borderSize, progressWidth, progressHeight)
            Else
                progressWidth = Me.Width - (_borderSize * 2)
                progressHeight = CInt((Me.Height - (_borderSize * 2)) * ((_value - _minimum) / (_maximum - _minimum)))
                progressRect = New Rectangle(_borderSize, Me.Height - progressHeight - _borderSize, progressWidth, progressHeight)
            End If

            If progressRect.Width > 0 AndAlso progressRect.Height > 0 Then
                Using path As GraphicsPath = GetRoundedRectangle(progressRect, _borderRadius - 1)
                    If _useGradient AndAlso _progressColor2 <> Color.Empty Then
                        Using brush As New LinearGradientBrush(progressRect, _progressColor, _progressColor2, _gradientMode)
                            g.FillPath(brush, path)
                        End Using
                    Else
                        Using brush As New SolidBrush(_progressColor)
                            g.FillPath(brush, path)
                        End Using
                    End If
                End Using
            End If
        End Sub

        Private Sub DrawBlocksProgress(g As Graphics)
            If _value <= _minimum Then Return

            Dim totalBlocks As Integer = _separatorCount
            Dim completedBlocks As Integer = CInt(totalBlocks * ((_value - _minimum) / (_maximum - _minimum)))

            Dim contentRect As New Rectangle(_borderSize, _borderSize,
                                            Me.Width - (_borderSize * 2),
                                            Me.Height - (_borderSize * 2))

            If _orientation = ProgressBarOrientation.Horizontal Then
                Dim blockWidth As Integer = (contentRect.Width - (_separatorWidth * (totalBlocks - 1))) \ totalBlocks
                Dim x As Integer = contentRect.X

                For i As Integer = 0 To completedBlocks - 1
                    Dim blockRect As New Rectangle(x, contentRect.Y, blockWidth, contentRect.Height)
                    Using path As GraphicsPath = GetRoundedRectangle(blockRect, _borderRadius - 1)
                        Using brush As New SolidBrush(_progressColor)
                            g.FillPath(brush, path)
                        End Using
                    End Using
                    x += blockWidth + _separatorWidth
                Next
            Else
                Dim blockHeight As Integer = (contentRect.Height - (_separatorWidth * (totalBlocks - 1))) \ totalBlocks
                Dim y As Integer = contentRect.Bottom - blockHeight

                For i As Integer = 0 To completedBlocks - 1
                    Dim blockRect As New Rectangle(contentRect.X, y, contentRect.Width, blockHeight)
                    Using path As GraphicsPath = GetRoundedRectangle(blockRect, _borderRadius - 1)
                        Using brush As New SolidBrush(_progressColor)
                            g.FillPath(brush, path)
                        End Using
                    End Using
                    y -= blockHeight + _separatorWidth
                Next
            End If
        End Sub

        Private Sub DrawMarqueeProgress(g As Graphics)
            Dim marqueeWidth As Integer = 100
            Dim contentRect As New Rectangle(_borderSize, _borderSize,
                                            Me.Width - (_borderSize * 2),
                                            Me.Height - (_borderSize * 2))

            Dim marqueeRect As New Rectangle(_marqueePosition, contentRect.Y, marqueeWidth, contentRect.Height)

            ' Clip para que no se salga
            g.SetClip(contentRect)

            Using path As GraphicsPath = GetRoundedRectangle(marqueeRect, _borderRadius - 1)
                If _useGradient AndAlso _progressColor2 <> Color.Empty Then
                    Using brush As New LinearGradientBrush(marqueeRect, _progressColor, _progressColor2, LinearGradientMode.Horizontal)
                        g.FillPath(brush, path)
                    End Using
                Else
                    Using brush As New SolidBrush(_progressColor)
                        g.FillPath(brush, path)
                    End Using
                End If
            End Using

            g.ResetClip()
        End Sub

        Private Sub DrawSeparators(g As Graphics)
            Dim contentRect As New Rectangle(_borderSize, _borderSize,
                                            Me.Width - (_borderSize * 2),
                                            Me.Height - (_borderSize * 2))

            Using pen As New Pen(_separatorColor, _separatorWidth)
                If _orientation = ProgressBarOrientation.Horizontal Then
                    Dim spacing As Single = contentRect.Width / CSng(_separatorCount)
                    For i As Integer = 1 To _separatorCount - 1
                        Dim x As Integer = contentRect.X + CInt(i * spacing)
                        g.DrawLine(pen, x, contentRect.Y, x, contentRect.Bottom)
                    Next
                Else
                    Dim spacing As Single = contentRect.Height / CSng(_separatorCount)
                    For i As Integer = 1 To _separatorCount - 1
                        Dim y As Integer = contentRect.Y + CInt(i * spacing)
                        g.DrawLine(pen, contentRect.X, y, contentRect.Right, y)
                    Next
                End If
            End Using
        End Sub

        Private Sub DrawProgressText(g As Graphics)
            Dim textToShow As String

            If Not String.IsNullOrEmpty(_customText) Then
                textToShow = String.Format(_customText, PercentComplete.ToString("0"))
            Else
                textToShow = String.Format(_textFormat, PercentComplete.ToString("0"))
            End If

            If _style = ProgressBarStyle.Marquee Then
                textToShow = "Procesando..."
            End If

            Using brush As New SolidBrush(_textColor)
                Dim textSize As SizeF = g.MeasureString(textToShow, _textFont)
                Dim textX As Single
                Dim textY As Single = (Me.Height - textSize.Height) / 2

                Select Case _textPosition
                    Case TextPosition.Center
                        textX = (Me.Width - textSize.Width) / 2
                    Case TextPosition.Right
                        textX = Me.Width - textSize.Width - 10
                    Case Else
                        textX = 10
                End Select

                g.DrawString(textToShow, _textFont, brush, textX, textY)
            End Using
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

#Region "Implementación IThemeable"

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

            _progressColor = theme.PrimaryColor
            _progressColor2 = theme.AccentColor
            _backgroundColor = theme.DisabledColor
            _borderColor = theme.BorderColor
            _borderRadius = theme.BorderRadius
            Me.Invalidate()
        End Sub

#End Region

#Region "Cleanup"

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If _animationTimer IsNot Nothing Then
                    _animationTimer.Stop()
                    _animationTimer.Dispose()
                End If
                If _textFont IsNot Nothing Then
                    _textFont.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#End Region

    End Class

End Namespace