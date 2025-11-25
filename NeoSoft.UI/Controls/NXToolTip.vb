Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' ToolTip avanzado con estilos, HTML básico, iconos y animaciones
    ''' </summary>
    <ProvideProperty("ToolTip", GetType(Control))>
    <ToolboxBitmap(GetType(ToolTip))>
    Public Class NXToolTip
        Inherits Component
        Implements IExtenderProvider
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Estilos predefinidos del tooltip
        ''' </summary>
        Public Enum TooltipStyle
            ''' <summary>Estilo por defecto</summary>
            [Default]
            ''' <summary>Estilo informativo (azul)</summary>
            Info
            ''' <summary>Estilo de éxito (verde)</summary>
            Success
            ''' <summary>Estilo de advertencia (amarillo/naranja)</summary>
            Warning
            ''' <summary>Estilo de error (rojo)</summary>
            [Error]
            ''' <summary>Estilo oscuro</summary>
            Dark
            ''' <summary>Estilo personalizado</summary>
            Custom
        End Enum

        ''' <summary>
        ''' Posición del tooltip respecto al control
        ''' </summary>
        Public Enum TooltipPosition
            ''' <summary>Posicionamiento automático inteligente</summary>
            Auto
            ''' <summary>Arriba del control</summary>
            Top
            ''' <summary>Abajo del control</summary>
            Bottom
            ''' <summary>Izquierda del control</summary>
            Left
            ''' <summary>Derecha del control</summary>
            Right
        End Enum

        ''' <summary>
        ''' Iconos predefinidos
        ''' </summary>
        Public Enum TooltipIcon
            ''' <summary>Sin icono</summary>
            None
            ''' <summary>Icono de información</summary>
            Info
            ''' <summary>Icono de advertencia</summary>
            Warning
            ''' <summary>Icono de error</summary>
            [Error]
            ''' <summary>Icono de éxito</summary>
            Success
            ''' <summary>Icono de ayuda</summary>
            Help
        End Enum

        ''' <summary>
        ''' Efecto de animación
        ''' </summary>
        Public Enum AnimationEffect
            ''' <summary>Sin animación</summary>
            None
            ''' <summary>Fade (aparecer/desvanecer)</summary>
            Fade
            ''' <summary>Slide (deslizar)</summary>
            Slide
            ''' <summary>Zoom (escalar)</summary>
            Zoom
        End Enum

#End Region

#Region "Clases Internas"

        ''' <summary>
        ''' Información del tooltip para cada control
        ''' </summary>
        Private Class TooltipInfo
            Public Property Text As String = ""
            Public Property Title As String = ""
            Public Property Icon As TooltipIcon = TooltipIcon.None
            Public Property Style As TooltipStyle = TooltipStyle.Default
            Public Property Position As TooltipPosition = TooltipPosition.Auto
        End Class

        ''' <summary>
        ''' Ventana de tooltip personalizada
        ''' </summary>
        Private Class TooltipWindow
            Inherits Form

            Private _text As String = ""
            Private _title As String = ""
            Private _icon As TooltipIcon = TooltipIcon.None
            Private _style As TooltipStyle = TooltipStyle.Default
            Private _owner As NXToolTip

            Public Sub New(owner As NXToolTip)
                _owner = owner
                Me.FormBorderStyle = FormBorderStyle.None
                Me.ShowInTaskbar = False
                Me.StartPosition = FormStartPosition.Manual
                Me.TopMost = True
                Me.BackColor = Color.White
                Me.Opacity = 0
                Me.SetStyle(ControlStyles.UserPaint Or
                           ControlStyles.AllPaintingInWmPaint Or
                           ControlStyles.OptimizedDoubleBuffer, True)
            End Sub

            Public Sub SetContent(text As String, title As String, icon As TooltipIcon, style As TooltipStyle)
                _text = text
                _title = title
                _icon = icon
                _style = style
                CalculateSize()
            End Sub

            Private Sub CalculateSize()
                Dim maxWidth As Integer = 300
                Dim padding As Integer = 12
                Dim iconSize As Integer = If(_icon <> TooltipIcon.None, 20, 0)
                Dim iconPadding As Integer = If(_icon <> TooltipIcon.None, 8, 0)

                Using g As Graphics = Me.CreateGraphics()
                    ' Medir título
                    Dim titleHeight As Integer = 0
                    If Not String.IsNullOrEmpty(_title) Then
                        Dim titleSize As SizeF = g.MeasureString(_title, New Font("Segoe UI", 10, FontStyle.Bold), maxWidth - padding * 2 - iconSize - iconPadding)
                        titleHeight = CInt(titleSize.Height) + 8
                    End If

                    ' Medir texto (procesar HTML básico)
                    Dim plainText As String = StripHtmlTags(_text)
                    Dim textSize As SizeF = g.MeasureString(plainText, New Font("Segoe UI", 9), maxWidth - padding * 2)

                    Dim width As Integer = Math.Min(CInt(Math.Max(textSize.Width, 100)) + padding * 2 + iconSize + iconPadding, maxWidth)
                    Dim height As Integer = padding * 2 + titleHeight + CInt(textSize.Height)

                    Me.Size = New Size(width, height)
                End Using
            End Sub

            Private Function StripHtmlTags(html As String) As String
                Return Regex.Replace(html, "<.*?>", String.Empty)
            End Function

            Protected Overrides Sub OnPaint(e As PaintEventArgs)
                Dim g As Graphics = e.Graphics
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                ' Obtener colores según estilo
                Dim colors As StyleColors = GetStyleColors(_style)

                ' Dibujar fondo con sombra
                DrawShadow(g)

                ' Dibujar fondo
                Using path As GraphicsPath = GetRoundedRectangle(New Rectangle(2, 2, Me.Width - 4, Me.Height - 4), 6)
                    Using brush As New SolidBrush(colors.BackColor)
                        g.FillPath(brush, path)
                    End Using

                    ' Dibujar borde
                    Using pen As New Pen(colors.BorderColor, 1)
                        g.DrawPath(pen, path)
                    End Using
                End Using

                ' Dibujar contenido
                Dim xOffset As Integer = 12
                Dim yOffset As Integer = 12

                ' Dibujar icono
                If _icon <> TooltipIcon.None Then
                    DrawIcon(g, xOffset, yOffset + 2, _icon, colors.IconColor)
                    xOffset += 28
                End If

                ' Dibujar título
                If Not String.IsNullOrEmpty(_title) Then
                    Using brush As New SolidBrush(colors.TitleColor)
                        Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                            g.DrawString(_title, font, brush, New RectangleF(xOffset, yOffset, Me.Width - xOffset - 12, Me.Height))
                        End Using
                    End Using
                    yOffset += 24
                End If

                ' Dibujar texto (con HTML básico)
                DrawFormattedText(g, _text, xOffset, yOffset, Me.Width - xOffset - 12, colors.TextColor)
            End Sub

            Private Sub DrawShadow(g As Graphics)
                Using shadowPath As GraphicsPath = GetRoundedRectangle(New Rectangle(4, 4, Me.Width - 4, Me.Height - 4), 6)
                    Using shadowBrush As New SolidBrush(Color.FromArgb(50, 0, 0, 0))
                        g.FillPath(shadowBrush, shadowPath)
                    End Using
                End Using
            End Sub

            Private Sub DrawIcon(g As Graphics, x As Integer, y As Integer, icon As TooltipIcon, color As Color)
                Using pen As New Pen(color, 2)
                    Using brush As New SolidBrush(color)
                        Select Case icon
                            Case TooltipIcon.Info
                                ' Círculo con "i"
                                g.DrawEllipse(pen, x, y, 16, 16)
                                g.DrawString("i", New Font("Segoe UI", 11, FontStyle.Bold), brush, x + 4, y + 0)

                            Case TooltipIcon.Warning
                                ' Triángulo con "!"
                                Dim points() As Point = {
                                    New Point(x + 8, y),
                                    New Point(x + 16, y + 16),
                                    New Point(x, y + 16)
                                }
                                g.DrawPolygon(pen, points)
                                g.DrawString("!", New Font("Segoe UI", 10, FontStyle.Bold), brush, x + 5, y + 2)

                            Case TooltipIcon.Error
                                ' Círculo con "X"
                                g.DrawEllipse(pen, x, y, 16, 16)
                                g.DrawString("✕", New Font("Segoe UI", 10, FontStyle.Bold), brush, x + 3, y + 1)

                            Case TooltipIcon.Success
                                ' Círculo con checkmark
                                g.DrawEllipse(pen, x, y, 16, 16)
                                g.DrawString("✓", New Font("Segoe UI", 10, FontStyle.Bold), brush, x + 3, y + 0)

                            Case TooltipIcon.Help
                                ' Círculo con "?"
                                g.DrawEllipse(pen, x, y, 16, 16)
                                g.DrawString("?", New Font("Segoe UI", 10, FontStyle.Bold), brush, x + 4, y + 0)
                        End Select
                    End Using
                End Using
            End Sub

            Private Sub DrawFormattedText(g As Graphics, html As String, x As Integer, y As Integer, maxWidth As Integer, textColor As Color)
                ' Procesar HTML básico: <b>, <i>, <br>, <u>
                Dim currentY As Single = y
                Dim currentX As Single = x

                ' Dividir por <br> o <br/>
                Dim lines() As String = Regex.Split(html, "<br\s*/?>", RegexOptions.IgnoreCase)

                For Each line In lines
                    ' Procesar formato en línea
                    Dim segments As List(Of TextSegment) = ParseHtmlLine(line)

                    For Each segment In segments
                        Dim font As Font = CreateFontFromStyle(segment)
                        Using brush As New SolidBrush(textColor)
                            Dim size As SizeF = g.MeasureString(segment.Text, font)
                            g.DrawString(segment.Text, font, brush, currentX, currentY)
                            currentX += size.Width
                        End Using
                        font.Dispose()
                    Next
                    currentX = x
                    currentY += 18
                Next
            End Sub

            Private Function ParseHtmlLine(html As String) As List(Of TextSegment)
                Dim segments As New List(Of TextSegment)
                Dim pattern As String = "(<b>|</b>|<i>|</i>|<u>|</u>|[^<]+)"
                Dim matches As MatchCollection = Regex.Matches(html, pattern, RegexOptions.IgnoreCase)

                Dim isBold As Boolean = False
                Dim isItalic As Boolean = False
                Dim isUnderline As Boolean = False

                For Each match As Match In matches
                    Dim token As String = match.Value
                    Select Case token.ToLower()
                        Case "<b>"
                            isBold = True
                        Case "</b>"
                            isBold = False
                        Case "<i>"
                            isItalic = True
                        Case "</i>"
                            isItalic = False
                        Case "<u>"
                            isUnderline = True
                        Case "</u>"
                            isUnderline = False
                        Case Else
                            If Not String.IsNullOrWhiteSpace(token) Then
                                segments.Add(New TextSegment With {
                                    .Text = token,
                                    .IsBold = isBold,
                                    .IsItalic = isItalic,
                                    .IsUnderline = isUnderline
                                })
                            End If
                    End Select
                Next

                Return segments
            End Function

            Private Function CreateFontFromStyle(segment As TextSegment) As Font
                Dim style As FontStyle = FontStyle.Regular
                If segment.IsBold Then style = style Or FontStyle.Bold
                If segment.IsItalic Then style = style Or FontStyle.Italic
                If segment.IsUnderline Then style = style Or FontStyle.Underline
                Return New Font("Segoe UI", 9, style)
            End Function

            Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
                Dim path As New GraphicsPath()
                Dim diameter As Integer = radius * 2
                Dim arc As New Rectangle(rect.Location, New Size(diameter, diameter))

                path.AddArc(arc, 180, 90)
                arc.X = rect.Right - diameter
                path.AddArc(arc, 270, 90)
                arc.Y = rect.Bottom - diameter
                path.AddArc(arc, 0, 90)
                arc.X = rect.Left
                path.AddArc(arc, 90, 90)
                path.CloseFigure()

                Return path
            End Function

            Private Function GetStyleColors(style As TooltipStyle) As StyleColors
                Select Case style
                    Case TooltipStyle.Info
                        Return New StyleColors With {
                            .BackColor = Color.FromArgb(230, 244, 255),
                            .BorderColor = Color.FromArgb(33, 150, 243),
                            .TextColor = Color.FromArgb(1, 87, 155),
                            .TitleColor = Color.FromArgb(1, 87, 155),
                            .IconColor = Color.FromArgb(33, 150, 243)
                        }
                    Case TooltipStyle.Success
                        Return New StyleColors With {
                            .BackColor = Color.FromArgb(232, 245, 233),
                            .BorderColor = Color.FromArgb(76, 175, 80),
                            .TextColor = Color.FromArgb(27, 94, 32),
                            .TitleColor = Color.FromArgb(27, 94, 32),
                            .IconColor = Color.FromArgb(76, 175, 80)
                        }
                    Case TooltipStyle.Warning
                        Return New StyleColors With {
                            .BackColor = Color.FromArgb(255, 248, 225),
                            .BorderColor = Color.FromArgb(255, 152, 0),
                            .TextColor = Color.FromArgb(230, 81, 0),
                            .TitleColor = Color.FromArgb(230, 81, 0),
                            .IconColor = Color.FromArgb(255, 152, 0)
                        }
                    Case TooltipStyle.Error
                        Return New StyleColors With {
                            .BackColor = Color.FromArgb(255, 235, 238),
                            .BorderColor = Color.FromArgb(244, 67, 54),
                            .TextColor = Color.FromArgb(183, 28, 28),
                            .TitleColor = Color.FromArgb(183, 28, 28),
                            .IconColor = Color.FromArgb(244, 67, 54)
                        }
                    Case TooltipStyle.Dark
                        Return New StyleColors With {
                            .BackColor = Color.FromArgb(33, 33, 33),
                            .BorderColor = Color.FromArgb(66, 66, 66),
                            .TextColor = Color.FromArgb(245, 245, 245),
                            .TitleColor = Color.White,
                            .IconColor = Color.FromArgb(200, 200, 200)
                        }
                    Case Else ' Default
                        Return New StyleColors With {
                            .BackColor = Color.White,
                            .BorderColor = Color.FromArgb(200, 200, 200),
                            .TextColor = Color.FromArgb(66, 66, 66),
                            .TitleColor = Color.FromArgb(33, 33, 33),
                            .IconColor = Color.FromArgb(100, 100, 100)
                        }
                End Select
            End Function
        End Class

        Private Class TextSegment
            Public Property Text As String
            Public Property IsBold As Boolean
            Public Property IsItalic As Boolean
            Public Property IsUnderline As Boolean
        End Class

        Private Class StyleColors
            Public Property BackColor As Color
            Public Property BorderColor As Color
            Public Property TextColor As Color
            Public Property TitleColor As Color
            Public Property IconColor As Color
        End Class

#End Region

#Region "Campos Privados"

        Private _tooltips As New Dictionary(Of Control, TooltipInfo)
        Private _tooltipWindow As TooltipWindow
        Private WithEvents _showTimer As New Timer With {.Interval = 500}
        Private WithEvents _hideTimer As New Timer With {.Interval = 3000}
        Private WithEvents _fadeTimer As New Timer With {.Interval = 20}
        Private _currentControl As Control
        Private _targetOpacity As Double = 1.0
        Private _fadeDirection As Integer = 1

        ' Propiedades globales
        Private _defaultStyle As TooltipStyle = TooltipStyle.Default
        Private _defaultPosition As TooltipPosition = TooltipPosition.Auto
        Private _animationEffect As AnimationEffect = AnimationEffect.Fade
        Private _showDelay As Integer = 500
        Private _autoHideDelay As Integer = 3000
        Private _useTheme As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            MyBase.New()
            _tooltipWindow = New TooltipWindow(Me)
        End Sub

#End Region

#Region "IExtenderProvider"

        Public Function CanExtend(extendee As Object) As Boolean Implements IExtenderProvider.CanExtend
            Return TypeOf extendee Is Control AndAlso Not TypeOf extendee Is Form
        End Function

#End Region

#Region "Propiedades Extendidas"

        <Category("NX ToolTip")>
        <Description("Texto del tooltip")>
        <DefaultValue("")>
        Public Function GetToolTip(control As Control) As String
            Dim info As TooltipInfo = GetTooltipInfo(control)
            Return If(info IsNot Nothing, info.Text, "")
        End Function

        Public Sub SetToolTip(control As Control, value As String)
            Dim info As TooltipInfo = GetOrCreateTooltipInfo(control)
            info.Text = value

            If String.IsNullOrEmpty(value) Then
                RemoveHandlers(control)
                _tooltips.Remove(control)
            Else
                AddHandlers(control)
            End If
        End Sub

        <Category("NX ToolTip")>
        <Description("Título del tooltip")>
        <DefaultValue("")>
        Public Function GetToolTipTitle(control As Control) As String
            Dim info As TooltipInfo = GetTooltipInfo(control)
            Return If(info IsNot Nothing, info.Title, "")
        End Function

        Public Sub SetToolTipTitle(control As Control, value As String)
            Dim info As TooltipInfo = GetOrCreateTooltipInfo(control)
            info.Title = value
        End Sub

        <Category("NX ToolTip")>
        <Description("Icono del tooltip")>
        <DefaultValue(GetType(TooltipIcon), "None")>
        Public Function GetToolTipIcon(control As Control) As TooltipIcon
            Dim info As TooltipInfo = GetTooltipInfo(control)
            Return If(info IsNot Nothing, info.Icon, TooltipIcon.None)
        End Function

        Public Sub SetToolTipIcon(control As Control, value As TooltipIcon)
            Dim info As TooltipInfo = GetOrCreateTooltipInfo(control)
            info.Icon = value
        End Sub

        <Category("NX ToolTip")>
        <Description("Estilo del tooltip")>
        <DefaultValue(GetType(TooltipStyle), "Default")>
        Public Function GetToolTipStyle(control As Control) As TooltipStyle
            Dim info As TooltipInfo = GetTooltipInfo(control)
            Return If(info IsNot Nothing, info.Style, _defaultStyle)
        End Function

        Public Sub SetToolTipStyle(control As Control, value As TooltipStyle)
            Dim info As TooltipInfo = GetOrCreateTooltipInfo(control)
            info.Style = value
        End Sub

        <Category("NX ToolTip")>
        <Description("Posición del tooltip")>
        <DefaultValue(GetType(TooltipPosition), "Auto")>
        Public Function GetToolTipPosition(control As Control) As TooltipPosition
            Dim info As TooltipInfo = GetTooltipInfo(control)
            Return If(info IsNot Nothing, info.Position, _defaultPosition)
        End Function

        Public Sub SetToolTipPosition(control As Control, value As TooltipPosition)
            Dim info As TooltipInfo = GetOrCreateTooltipInfo(control)
            info.Position = value
        End Sub

#End Region

#Region "Propiedades Globales"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo predeterminado para todos los tooltips")>
        <DefaultValue(GetType(TooltipStyle), "Default")>
        Public Property DefaultStyle As TooltipStyle
            Get
                Return _defaultStyle
            End Get
            Set(value As TooltipStyle)
                _defaultStyle = value
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Posición predeterminada para todos los tooltips")>
        <DefaultValue(GetType(TooltipPosition), "Auto")>
        Public Property DefaultPosition As TooltipPosition
            Get
                Return _defaultPosition
            End Get
            Set(value As TooltipPosition)
                _defaultPosition = value
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Efecto de animación")>
        <DefaultValue(GetType(AnimationEffect), "Fade")>
        Public Property Animation As AnimationEffect
            Get
                Return _animationEffect
            End Get
            Set(value As AnimationEffect)
                _animationEffect = value
            End Set
        End Property

        <Category("Behavior")>
        <Description("Retraso antes de mostrar el tooltip (ms)")>
        <DefaultValue(500)>
        Public Property ShowDelay As Integer
            Get
                Return _showDelay
            End Get
            Set(value As Integer)
                _showDelay = Math.Max(0, value)
                _showTimer.Interval = _showDelay
            End Set
        End Property

        <Category("Behavior")>
        <Description("Tiempo antes de ocultar automáticamente (ms, 0 = no ocultar)")>
        <DefaultValue(3000)>
        Public Property AutoHideDelay As Integer
            Get
                Return _autoHideDelay
            End Get
            Set(value As Integer)
                _autoHideDelay = Math.Max(0, value)
                _hideTimer.Interval = _autoHideDelay
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Usar tema global")>
        <DefaultValue(False)>
        Public Property UseTheme As Boolean Implements IThemeable.UseTheme
            Get
                Return _useTheme
            End Get
            Set(value As Boolean)
                _useTheme = value
            End Set
        End Property

#End Region

#Region "Métodos Privados"

        Private Function GetTooltipInfo(control As Control) As TooltipInfo
            If _tooltips.ContainsKey(control) Then
                Return _tooltips(control)
            End If
            Return Nothing
        End Function

        Private Function GetOrCreateTooltipInfo(control As Control) As TooltipInfo
            If Not _tooltips.ContainsKey(control) Then
                _tooltips(control) = New TooltipInfo()
            End If
            Return _tooltips(control)
        End Function

        Private Sub AddHandlers(control As Control)
            RemoveHandlers(control)
            AddHandler control.MouseEnter, AddressOf Control_MouseEnter
            AddHandler control.MouseLeave, AddressOf Control_MouseLeave
            AddHandler control.MouseMove, AddressOf Control_MouseMove
        End Sub

        Private Sub RemoveHandlers(control As Control)
            RemoveHandler control.MouseEnter, AddressOf Control_MouseEnter
            RemoveHandler control.MouseLeave, AddressOf Control_MouseLeave
            RemoveHandler control.MouseMove, AddressOf Control_MouseMove
        End Sub

        Private Sub Control_MouseEnter(sender As Object, e As EventArgs)
            _currentControl = TryCast(sender, Control)
            _showTimer.Stop()
            _showTimer.Start()
        End Sub

        Private Sub Control_MouseLeave(sender As Object, e As EventArgs)
            _showTimer.Stop()
            HideTooltip()
        End Sub

        Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
            If _tooltipWindow.Visible Then
                UpdateTooltipPosition()
            End If
        End Sub

        Private Sub ShowTimer_Tick(sender As Object, e As EventArgs) Handles _showTimer.Tick
            _showTimer.Stop()
            ShowTooltip()
        End Sub

        Private Sub HideTimer_Tick(sender As Object, e As EventArgs) Handles _hideTimer.Tick
            _hideTimer.Stop()
            HideTooltip()
        End Sub

        Private Sub ShowTooltip()
            If _currentControl Is Nothing Then Return

            Dim info As TooltipInfo = GetTooltipInfo(_currentControl)
            If info Is Nothing OrElse String.IsNullOrEmpty(info.Text) Then Return

            ' Configurar contenido
            _tooltipWindow.SetContent(info.Text, info.Title, info.Icon, info.Style)

            ' Posicionar tooltip
            UpdateTooltipPosition()

            ' Mostrar con animación
            Select Case _animationEffect
                Case AnimationEffect.Fade
                    _tooltipWindow.Opacity = 0
                    _tooltipWindow.Show()
                    _fadeDirection = 1
                    _targetOpacity = 0.95
                    _fadeTimer.Start()
                Case AnimationEffect.Slide, AnimationEffect.Zoom
                    _tooltipWindow.Opacity = 0.95
                    _tooltipWindow.Show()
                Case Else
                    _tooltipWindow.Opacity = 0.95
                    _tooltipWindow.Show()
            End Select

            ' Iniciar temporizador de auto-ocultar
            If _autoHideDelay > 0 Then
                _hideTimer.Start()
            End If
        End Sub

        Private Sub HideTooltip()
            If Not _tooltipWindow.Visible Then Return

            Select Case _animationEffect
                Case AnimationEffect.Fade
                    _fadeDirection = -1
                    _targetOpacity = 0
                    _fadeTimer.Start()
                Case Else
                    _tooltipWindow.Hide()
            End Select
        End Sub

        Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles _fadeTimer.Tick
            Dim newOpacity As Double = _tooltipWindow.Opacity + (0.1 * _fadeDirection)

            If _fadeDirection > 0 Then
                If newOpacity >= _targetOpacity Then
                    _tooltipWindow.Opacity = _targetOpacity
                    _fadeTimer.Stop()
                Else
                    _tooltipWindow.Opacity = newOpacity
                End If
            Else
                If newOpacity <= 0 Then
                    _tooltipWindow.Opacity = 0
                    _tooltipWindow.Hide()
                    _fadeTimer.Stop()
                Else
                    _tooltipWindow.Opacity = newOpacity
                End If
            End If
        End Sub

        Private Sub UpdateTooltipPosition()
            If _currentControl Is Nothing Then Return

            Dim info As TooltipInfo = GetTooltipInfo(_currentControl)
            If info Is Nothing Then Return

            Dim controlLocation As Point = _currentControl.PointToScreen(Point.Empty)
            Dim tooltipSize As Size = _tooltipWindow.Size
            Dim position As TooltipPosition = If(info.Position = TooltipPosition.Auto, _defaultPosition, info.Position)

            Dim x As Integer = 0
            Dim y As Integer = 0

            ' Determinar posición
            Select Case position
                Case TooltipPosition.Top
                    x = controlLocation.X + (_currentControl.Width - tooltipSize.Width) \ 2
                    y = controlLocation.Y - tooltipSize.Height - 8

                Case TooltipPosition.Bottom
                    x = controlLocation.X + (_currentControl.Width - tooltipSize.Width) \ 2
                    y = controlLocation.Y + _currentControl.Height + 8

                Case TooltipPosition.Left
                    x = controlLocation.X - tooltipSize.Width - 8
                    y = controlLocation.Y + (_currentControl.Height - tooltipSize.Height) \ 2

                Case TooltipPosition.Right
                    x = controlLocation.X + _currentControl.Width + 8
                    y = controlLocation.Y + (_currentControl.Height - tooltipSize.Height) \ 2

                Case TooltipPosition.Auto
                    ' Posicionamiento inteligente
                    x = controlLocation.X + _currentControl.Width + 8
                    y = controlLocation.Y

                    ' Ajustar si se sale de la pantalla
                    Dim screen As Screen = Screen.FromControl(_currentControl)
                    If x + tooltipSize.Width > screen.WorkingArea.Right Then
                        x = controlLocation.X - tooltipSize.Width - 8
                    End If
                    If y + tooltipSize.Height > screen.WorkingArea.Bottom Then
                        y = controlLocation.Y - tooltipSize.Height + _currentControl.Height
                    End If
            End Select

            ' Asegurar que esté dentro de la pantalla
            Dim workingArea As Rectangle = Screen.FromControl(_currentControl).WorkingArea
            x = Math.Max(workingArea.Left, Math.Min(x, workingArea.Right - tooltipSize.Width))
            y = Math.Max(workingArea.Top, Math.Min(y, workingArea.Bottom - tooltipSize.Height))

            _tooltipWindow.Location = New Point(x, y)
        End Sub

#End Region

#Region "IThemeable"

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            ' El tema se puede aplicar a los estilos personalizados
        End Sub

#End Region

#Region "Dispose"

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                _showTimer?.Dispose()
                _hideTimer?.Dispose()
                _fadeTimer?.Dispose()
                _tooltipWindow?.Dispose()

                For Each control In _tooltips.Keys.ToList()
                    RemoveHandlers(control)
                Next
                _tooltips.Clear()
            End If
            MyBase.Dispose(disposing)
        End Sub

#End Region

    End Class

End Namespace