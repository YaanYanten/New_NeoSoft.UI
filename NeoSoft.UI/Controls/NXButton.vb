Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports NeoSoft.UI.Theming

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
        Implements IThemeable

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

        'Image
        Private _image As Image = Nothing
        Private _imageAlign As ContentAlignment = ContentAlignment.MiddleLeft
        Private _imageSize As Size = New Size(24, 24)

#End Region

#Region "Propiedades - Apariencia"

        ''' <summary>
        ''' Imagen del botón - Usa el editor personalizado
        ''' </summary>
        <Category("Appearance")>
        <Description("Imagen que se muestra en el botón")>
        <Editor(GetType(NXImageUITypeEditor), GetType(UITypeEditor))>
        <Localizable(True)>
        Public Property Image As Image
            Get
                Return _image
            End Get
            Set(value As Image)
                If _image IsNot Nothing AndAlso _image IsNot value Then
                    Try
                        _image.Dispose()
                    Catch

                    End Try
                End If
                _image = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Alineación de la imagen en el botón
        ''' </summary>
        <Category("Appearance")>
        <Description("Alineación de la imagen en el botón")>
        <DefaultValue(GetType(ContentAlignment), "MiddleLeft")>
        Public Property ImageAlign As ContentAlignment
            Get
                Return _imageAlign
            End Get
            Set(value As ContentAlignment)
                If _imageAlign <> value Then
                    _imageAlign = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Tamaño de la imagen cuando se muestra con texto
        ''' </summary>
        <Category("Appearance")>
        <Description("Tamaño de la imagen cuando se muestra con texto")>
        Public Property ImageSize As Size
            Get
                Return _imageSize
            End Get
            Set(value As Size)
                If _imageSize <> value Then
                    _imageSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

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

            ' ============================================================
            ' NUEVO: DIBUJAR IMAGEN Y TEXTO
            ' ============================================================

            Dim hasImage As Boolean = (_image IsNot Nothing)
            Dim hasText As Boolean = Not String.IsNullOrEmpty(Me.Text)

            If hasImage AndAlso hasText Then
                ' Imagen + Texto: Dibujar imagen a la izquierda, texto a la derecha
                DrawImageAndText(g, textColor)

            ElseIf hasImage Then
                ' Solo imagen: Centrada
                DrawImageOnly(g)

            ElseIf hasText Then
                ' Solo texto: Centrado
                DrawTextOnly(g, textColor)
            End If

            MyBase.OnPaint(e)
        End Sub

        ''' <summary>
        ''' Dibuja solo la imagen (centrada o según ImageAlign si no hay texto)
        ''' </summary>
        Private Sub DrawImageOnly(g As Graphics)
            If _image Is Nothing Then Return

            ' Tamaño de la imagen
            Dim imgWidth As Integer = _image.Width
            Dim imgHeight As Integer = _image.Height

            ' Escalar si la imagen es muy grande
            If imgWidth > Me.Width - 10 OrElse imgHeight > Me.Height - 10 Then
                Dim scale As Single = Math.Min((Me.Width - 10) / CSng(imgWidth), (Me.Height - 10) / CSng(imgHeight))
                imgWidth = CInt(imgWidth * scale)
                imgHeight = CInt(imgHeight * scale)
            End If

            Dim imgX As Integer = 0
            Dim imgY As Integer = 0

            ' Calcular posición según ImageAlign
            Select Case _imageAlign
                Case ContentAlignment.TopLeft
                    imgX = 5
                    imgY = 5

                Case ContentAlignment.TopCenter
                    imgX = (Me.Width - imgWidth) \ 2
                    imgY = 5

                Case ContentAlignment.TopRight
                    imgX = Me.Width - imgWidth - 5
                    imgY = 5

                Case ContentAlignment.MiddleLeft
                    imgX = 5
                    imgY = (Me.Height - imgHeight) \ 2

                Case ContentAlignment.MiddleCenter
                    imgX = (Me.Width - imgWidth) \ 2
                    imgY = (Me.Height - imgHeight) \ 2

                Case ContentAlignment.MiddleRight
                    imgX = Me.Width - imgWidth - 5
                    imgY = (Me.Height - imgHeight) \ 2

                Case ContentAlignment.BottomLeft
                    imgX = 5
                    imgY = Me.Height - imgHeight - 5

                Case ContentAlignment.BottomCenter
                    imgX = (Me.Width - imgWidth) \ 2
                    imgY = Me.Height - imgHeight - 5

                Case ContentAlignment.BottomRight
                    imgX = Me.Width - imgWidth - 5
                    imgY = Me.Height - imgHeight - 5

                Case Else ' Default: centrado
                    imgX = (Me.Width - imgWidth) \ 2
                    imgY = (Me.Height - imgHeight) \ 2
            End Select

            ' Dibujar imagen con calidad alta
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(_image, imgX, imgY, imgWidth, imgHeight)
        End Sub

        ''' <summary>
        ''' Dibuja solo el texto (centrado)
        ''' </summary>
        Private Sub DrawTextOnly(g As Graphics, textColor As Color)
            Dim textRect As Rectangle = Me.ClientRectangle
            TextRenderer.DrawText(g, Me.Text, Me.Font, textRect, textColor,
                        TextFormatFlags.HorizontalCenter Or
                        TextFormatFlags.VerticalCenter Or
                        TextFormatFlags.EndEllipsis)
        End Sub

        ''' <summary>
        ''' Dibuja imagen y texto juntos según ImageAlign
        ''' </summary>
        Private Sub DrawImageAndText(g As Graphics, textColor As Color)
            If _image Is Nothing Then
                DrawTextOnly(g, textColor)
                Return
            End If

            Const padding As Integer = 8
            Const spacing As Integer = 6

            ' Tamaño de la imagen
            Dim imgWidth As Integer = _imageSize.Width
            Dim imgHeight As Integer = _imageSize.Height

            ' Escalar si es necesario
            If imgWidth > _image.Width Then imgWidth = _image.Width
            If imgHeight > _image.Height Then imgHeight = _image.Height

            ' Medir texto
            Dim textSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)

            ' Variables para posiciones
            Dim imgX As Integer = 0
            Dim imgY As Integer = 0
            Dim textX As Integer = 0
            Dim textY As Integer = 0
            Dim textRect As Rectangle

            ' Calcular posiciones según ImageAlign
            Select Case _imageAlign
                Case ContentAlignment.TopLeft
                    imgX = padding
                    imgY = padding
                    textX = imgX
                    textY = imgY + imgHeight + spacing
                    textRect = New Rectangle(textX, textY, Me.Width - textX - padding, Me.Height - textY - padding)

                Case ContentAlignment.TopCenter
                    imgX = (Me.Width - imgWidth) \ 2
                    imgY = padding
                    textX = 0
                    textY = imgY + imgHeight + spacing
                    textRect = New Rectangle(padding, textY, Me.Width - (padding * 2), Me.Height - textY - padding)

                Case ContentAlignment.TopRight
                    imgX = Me.Width - imgWidth - padding
                    imgY = padding
                    textX = 0
                    textY = imgY + imgHeight + spacing
                    textRect = New Rectangle(padding, textY, Me.Width - (padding * 2), Me.Height - textY - padding)

                Case ContentAlignment.MiddleLeft
                    imgX = padding
                    imgY = (Me.Height - imgHeight) \ 2
                    textX = imgX + imgWidth + spacing
                    textY = 0
                    textRect = New Rectangle(textX, padding, Me.Width - textX - padding, Me.Height - (padding * 2))

                Case ContentAlignment.MiddleCenter
                    ' Imagen arriba, texto abajo, ambos centrados
                    imgX = (Me.Width - imgWidth) \ 2
                    Dim totalHeight = imgHeight + spacing + textSize.Height
                    imgY = (Me.Height - totalHeight) \ 2
                    textX = 0
                    textY = imgY + imgHeight + spacing
                    textRect = New Rectangle(padding, textY, Me.Width - (padding * 2), Me.Height - textY - padding)

                Case ContentAlignment.MiddleRight
                    imgX = Me.Width - imgWidth - padding
                    imgY = (Me.Height - imgHeight) \ 2
                    textX = padding
                    textY = 0
                    textRect = New Rectangle(textX, padding, imgX - textX - spacing, Me.Height - (padding * 2))

                Case ContentAlignment.BottomLeft
                    imgX = padding
                    imgY = Me.Height - imgHeight - padding
                    textX = imgX
                    textY = padding
                    textRect = New Rectangle(textX, textY, Me.Width - textX - padding, imgY - textY - spacing)

                Case ContentAlignment.BottomCenter
                    imgX = (Me.Width - imgWidth) \ 2
                    imgY = Me.Height - imgHeight - padding
                    textX = 0
                    textY = padding
                    textRect = New Rectangle(padding, textY, Me.Width - (padding * 2), imgY - textY - spacing)

                Case ContentAlignment.BottomRight
                    imgX = Me.Width - imgWidth - padding
                    imgY = Me.Height - imgHeight - padding
                    textX = 0
                    textY = padding
                    textRect = New Rectangle(padding, textY, Me.Width - (padding * 2), imgY - textY - spacing)

                Case Else ' Default a MiddleLeft
                    imgX = padding
                    imgY = (Me.Height - imgHeight) \ 2
                    textX = imgX + imgWidth + spacing
                    textY = 0
                    textRect = New Rectangle(textX, padding, Me.Width - textX - padding, Me.Height - (padding * 2))
            End Select

            ' Dibujar imagen
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(_image, imgX, imgY, imgWidth, imgHeight)

            ' Dibujar texto con alineación apropiada
            Dim textFlags As TextFormatFlags = TextFormatFlags.EndEllipsis Or TextFormatFlags.WordBreak

            ' Determinar alineación horizontal del texto según ImageAlign
            Select Case _imageAlign
                Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                    textFlags = textFlags Or TextFormatFlags.Left
                Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                    textFlags = textFlags Or TextFormatFlags.HorizontalCenter
                Case ContentAlignment.TopRight, ContentAlignment.MiddleRight, ContentAlignment.BottomRight
                    textFlags = textFlags Or TextFormatFlags.Right
            End Select

            ' Determinar alineación vertical del texto
            Select Case _imageAlign
                Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
                    textFlags = textFlags Or TextFormatFlags.Top
                Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                    textFlags = textFlags Or TextFormatFlags.VerticalCenter
                Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
                    textFlags = textFlags Or TextFormatFlags.Bottom
            End Select

            TextRenderer.DrawText(g, Me.Text, Me.Font, textRect, textColor, textFlags)
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

            ' Aplicar colores del tema según el estilo del botón
            Select Case _buttonStyle
                Case ButtonStyle.Solid
                    Me.BackColor = theme.PrimaryColor
                    Me.ForeColor = Helpers.ColorHelper.GetContrastingTextColor(theme.PrimaryColor)
                    Me.BorderColor = theme.PrimaryColor

                Case ButtonStyle.Outline
                    Me.BackColor = theme.BackColor
                    Me.ForeColor = theme.PrimaryColor
                    Me.BorderColor = theme.PrimaryColor

                Case ButtonStyle.Gradient
                    Me.BackColor = theme.PrimaryColor
                    Me.ForeColor = Helpers.ColorHelper.GetContrastingTextColor(theme.PrimaryColor)
                    Me.BorderColor = theme.PrimaryColor
            End Select

            Me.BorderRadius = theme.ButtonBorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace
