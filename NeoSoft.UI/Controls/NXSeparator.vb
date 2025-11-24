Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Separador visual horizontal o vertical con texto opcional, estilos y gradientes
    ''' </summary>
    <ToolboxBitmap(GetType(Label))>
    <DefaultProperty("Text")>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    Public Class NXSeparator
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Orientación del separador
        ''' </summary>
        Public Enum SeparatorOrientation
            ''' <summary>Separador horizontal</summary>
            Horizontal
            ''' <summary>Separador vertical</summary>
            Vertical
        End Enum

        ''' <summary>
        ''' Estilos de línea disponibles
        ''' </summary>
        Public Enum LineStyle
            ''' <summary>Línea sólida continua</summary>
            Solid
            ''' <summary>Línea discontinua (- - - -)</summary>
            Dashed
            ''' <summary>Línea punteada (· · · ·)</summary>
            Dotted
        End Enum

        ''' <summary>
        ''' Tipo de color de línea
        ''' </summary>
        Public Enum LineColorStyle
            ''' <summary>Color sólido</summary>
            Solid
            ''' <summary>Gradiente a lo largo de la línea</summary>
            Gradient
        End Enum

        ''' <summary>
        ''' Alineación del texto en el separador
        ''' </summary>
        Public Enum TextAlignment
            ''' <summary>Texto al inicio</summary>
            [Left]
            ''' <summary>Texto centrado</summary>
            Center
            ''' <summary>Texto al final</summary>
            [Right]
        End Enum

#End Region

#Region "Campos Privados"

        ' Orientación
        Private _orientation As SeparatorOrientation = SeparatorOrientation.Horizontal

        ' Línea
        Private _lineStyle As LineStyle = LineStyle.Solid
        Private _lineThickness As Integer = 1
        Private _lineColor As Color = Color.FromArgb(200, 200, 200)

        ' Gradiente
        Private _lineColorStyle As LineColorStyle = LineColorStyle.Solid
        Private _lineGradientColor1 As Color = Color.FromArgb(200, 200, 200)
        Private _lineGradientColor2 As Color = Color.FromArgb(100, 100, 100)

        ' Texto
        Private _showText As Boolean = False
        Private _textAlignment As TextAlignment = TextAlignment.Center
        Private _textPadding As Integer = 10
        Private _textBackColor As Color = Color.Transparent

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            Me.BackColor = Color.Transparent
            Me.ForeColor = Color.FromArgb(100, 100, 100)
            Me.Size = New Size(200, 20)
            Me.Font = New Font("Segoe UI", 9.0F)
            Me.Text = String.Empty

            ' Inicializar colores de gradiente
            _lineGradientColor1 = _lineColor
            _lineGradientColor2 = ControlPaint.Dark(_lineColor, 0.3F)
        End Sub

#End Region

#Region "Propiedades - Orientación"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Orientación del separador (Horizontal o Vertical)")>
        <DefaultValue(GetType(SeparatorOrientation), "Horizontal")>
        Public Property Orientation As SeparatorOrientation
            Get
                Return _orientation
            End Get
            Set(value As SeparatorOrientation)
                If _orientation <> value Then
                    _orientation = value
                    AdjustSizeForOrientation()
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Línea"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo de la línea (Solid, Dashed, Dotted)")>
        <DefaultValue(GetType(LineStyle), "Solid")>
        Public Property LineStyleType As LineStyle
            Get
                Return _lineStyle
            End Get
            Set(value As LineStyle)
                If _lineStyle <> value Then
                    _lineStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Grosor de la línea en píxeles")>
        <DefaultValue(1)>
        Public Property LineThickness As Integer
            Get
                Return _lineThickness
            End Get
            Set(value As Integer)
                If value < 1 Then value = 1
                If value > 20 Then value = 20
                If _lineThickness <> value Then
                    _lineThickness = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de la línea")>
        Public Property LineColor As Color
            Get
                Return _lineColor
            End Get
            Set(value As Color)
                If _lineColor <> value Then
                    _lineColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Gradiente"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Tipo de color de línea (Solid o Gradient)")>
        <DefaultValue(GetType(LineColorStyle), "Solid")>
        Public Property LineColorStyleType As LineColorStyle
            Get
                Return _lineColorStyle
            End Get
            Set(value As LineColorStyle)
                If _lineColorStyle <> value Then
                    _lineColorStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color inicial del gradiente")>
        Public Property LineGradientColor1 As Color
            Get
                Return _lineGradientColor1
            End Get
            Set(value As Color)
                If _lineGradientColor1 <> value Then
                    _lineGradientColor1 = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color final del gradiente")>
        Public Property LineGradientColor2 As Color
            Get
                Return _lineGradientColor2
            End Get
            Set(value As Color)
                If _lineGradientColor2 <> value Then
                    _lineGradientColor2 = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Texto"

        ''' <summary>
        ''' Texto que se muestra en el separador
        ''' </summary>
        <Category("Appearance")>
        <Description("Texto opcional que se muestra en el separador")>
        <Browsable(True)>
        <EditorBrowsable(EditorBrowsableState.Always)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                If MyBase.Text <> value Then
                    MyBase.Text = value
                    _showText = Not String.IsNullOrWhiteSpace(value)
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Muestra el texto en el separador")>
        <DefaultValue(False)>
        Public Property ShowText As Boolean
            Get
                Return _showText
            End Get
            Set(value As Boolean)
                If _showText <> value Then
                    _showText = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Alineación del texto (Left, Center, Right)")>
        <DefaultValue(GetType(TextAlignment), "Center")>
        Public Property TextAlign As TextAlignment
            Get
                Return _textAlignment
            End Get
            Set(value As TextAlignment)
                If _textAlignment <> value Then
                    _textAlignment = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Espaciado alrededor del texto en píxeles")>
        <DefaultValue(10)>
        Public Property TextPadding As Integer
            Get
                Return _textPadding
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _textPadding <> value Then
                    _textPadding = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de fondo del texto")>
        Public Property TextBackColor As Color
            Get
                Return _textBackColor
            End Get
            Set(value As Color)
                If _textBackColor <> value Then
                    _textBackColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            If _orientation = SeparatorOrientation.Horizontal Then
                DrawHorizontalSeparator(g)
            Else
                DrawVerticalSeparator(g)
            End If

            MyBase.OnPaint(e)
        End Sub

        Private Sub DrawHorizontalSeparator(g As Graphics)
            Dim centerY As Integer = Me.Height \ 2
            Dim lineY As Integer = centerY - (_lineThickness \ 2)

            If _showText AndAlso Not String.IsNullOrWhiteSpace(Me.Text) Then
                ' Calcular tamaño del texto
                Dim textSize As SizeF = g.MeasureString(Me.Text, Me.Font)
                Dim textRect As Rectangle
                Dim line1Rect As Rectangle
                Dim line2Rect As Rectangle

                ' Calcular posiciones según alineación
                Select Case _textAlignment
                    Case TextAlignment.Left
                        textRect = New Rectangle(_textPadding, 0, CInt(textSize.Width) + _textPadding * 2, Me.Height)
                        line1Rect = Rectangle.Empty
                        line2Rect = New Rectangle(textRect.Right + _textPadding, lineY, Me.Width - textRect.Right - _textPadding, _lineThickness)

                    Case TextAlignment.Center
                        Dim textWidth As Integer = CInt(textSize.Width) + _textPadding * 2
                        Dim textX As Integer = (Me.Width - textWidth) \ 2
                        textRect = New Rectangle(textX, 0, textWidth, Me.Height)
                        line1Rect = New Rectangle(0, lineY, textX - _textPadding, _lineThickness)
                        line2Rect = New Rectangle(textRect.Right + _textPadding, lineY, Me.Width - textRect.Right - _textPadding, _lineThickness)

                    Case TextAlignment.Right
                        Dim textWidth As Integer = CInt(textSize.Width) + _textPadding * 2
                        Dim textX As Integer = Me.Width - textWidth - _textPadding
                        textRect = New Rectangle(textX, 0, textWidth, Me.Height)
                        line1Rect = New Rectangle(0, lineY, textX - _textPadding, _lineThickness)
                        line2Rect = Rectangle.Empty
                End Select

                ' Dibujar fondo del texto si no es transparente
                If _textBackColor <> Color.Transparent Then
                    Using brush As New SolidBrush(_textBackColor)
                        g.FillRectangle(brush, textRect)
                    End Using
                End If

                ' Dibujar líneas
                If line1Rect.Width > 0 Then
                    DrawLine(g, line1Rect)
                End If
                If line2Rect.Width > 0 Then
                    DrawLine(g, line2Rect)
                End If

                ' Dibujar texto
                Using brush As New SolidBrush(Me.ForeColor)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                End Using
            Else
                ' Sin texto, línea completa
                Dim lineRect As New Rectangle(0, lineY, Me.Width, _lineThickness)
                DrawLine(g, lineRect)
            End If
        End Sub

        Private Sub DrawVerticalSeparator(g As Graphics)
            Dim centerX As Integer = Me.Width \ 2
            Dim lineX As Integer = centerX - (_lineThickness \ 2)

            If _showText AndAlso Not String.IsNullOrWhiteSpace(Me.Text) Then
                ' Calcular tamaño del texto (rotado)
                Dim textSize As SizeF = g.MeasureString(Me.Text, Me.Font)
                Dim textRect As Rectangle
                Dim line1Rect As Rectangle
                Dim line2Rect As Rectangle

                ' Calcular posiciones según alineación
                Select Case _textAlignment
                    Case TextAlignment.Left ' Top en vertical
                        textRect = New Rectangle(0, _textPadding, Me.Width, CInt(textSize.Width) + _textPadding * 2)
                        line1Rect = Rectangle.Empty
                        line2Rect = New Rectangle(lineX, textRect.Bottom + _textPadding, _lineThickness, Me.Height - textRect.Bottom - _textPadding)

                    Case TextAlignment.Center
                        Dim textHeight As Integer = CInt(textSize.Width) + _textPadding * 2
                        Dim textY As Integer = (Me.Height - textHeight) \ 2
                        textRect = New Rectangle(0, textY, Me.Width, textHeight)
                        line1Rect = New Rectangle(lineX, 0, _lineThickness, textY - _textPadding)
                        line2Rect = New Rectangle(lineX, textRect.Bottom + _textPadding, _lineThickness, Me.Height - textRect.Bottom - _textPadding)

                    Case TextAlignment.Right ' Bottom en vertical
                        Dim textHeight As Integer = CInt(textSize.Width) + _textPadding * 2
                        Dim textY As Integer = Me.Height - textHeight - _textPadding
                        textRect = New Rectangle(0, textY, Me.Width, textHeight)
                        line1Rect = New Rectangle(lineX, 0, _lineThickness, textY - _textPadding)
                        line2Rect = Rectangle.Empty
                End Select

                ' Dibujar fondo del texto si no es transparente
                If _textBackColor <> Color.Transparent Then
                    Using brush As New SolidBrush(_textBackColor)
                        g.FillRectangle(brush, textRect)
                    End Using
                End If

                ' Dibujar líneas
                If line1Rect.Height > 0 Then
                    DrawLine(g, line1Rect)
                End If
                If line2Rect.Height > 0 Then
                    DrawLine(g, line2Rect)
                End If

                ' Dibujar texto rotado
                Dim state As GraphicsState = g.Save()
                g.TranslateTransform(textRect.Left + textRect.Width / 2, textRect.Top + textRect.Height / 2)
                g.RotateTransform(-90)

                Using brush As New SolidBrush(Me.ForeColor)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(Me.Text, Me.Font, brush, 0, 0, sf)
                End Using

                g.Restore(state)
            Else
                ' Sin texto, línea completa
                Dim lineRect As New Rectangle(lineX, 0, _lineThickness, Me.Height)
                DrawLine(g, lineRect)
            End If
        End Sub

        Private Sub DrawLine(g As Graphics, rect As Rectangle)
            ' Crear pen según estilo
            Dim pen As Pen

            ' Aplicar color (sólido o gradiente)
            If _lineColorStyle = LineColorStyle.Gradient Then
                Dim brush As LinearGradientBrush
                If _orientation = SeparatorOrientation.Horizontal Then
                    brush = New LinearGradientBrush(rect, _lineGradientColor1, _lineGradientColor2, LinearGradientMode.Horizontal)
                Else
                    brush = New LinearGradientBrush(rect, _lineGradientColor1, _lineGradientColor2, LinearGradientMode.Vertical)
                End If
                pen = New Pen(brush, _lineThickness)
            Else
                pen = New Pen(_lineColor, _lineThickness)
            End If

            Try
                ' Aplicar estilo de línea
                Select Case _lineStyle
                    Case LineStyle.Solid
                        pen.DashStyle = DashStyle.Solid

                    Case LineStyle.Dashed
                        pen.DashStyle = DashStyle.Dash

                    Case LineStyle.Dotted
                        pen.DashStyle = DashStyle.Dot
                End Select

                ' Dibujar línea
                If _orientation = SeparatorOrientation.Horizontal Then
                    Dim y As Integer = rect.Y + rect.Height \ 2
                    g.DrawLine(pen, rect.Left, y, rect.Right, y)
                Else
                    Dim x As Integer = rect.X + rect.Width \ 2
                    g.DrawLine(pen, x, rect.Top, x, rect.Bottom)
                End If
            Finally
                pen.Dispose()
            End Try
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            If Me.BackColor <> Color.Transparent Then
                MyBase.OnPaintBackground(e)
            End If
        End Sub

#End Region

#Region "Helpers"

        Private Sub AdjustSizeForOrientation()
            ' Ajustar tamaño sugerido según orientación
            If _orientation = SeparatorOrientation.Horizontal Then
                If Me.Height > Me.Width Then
                    Me.Size = New Size(Me.Height, 20)
                End If
            Else
                If Me.Width > Me.Height Then
                    Me.Size = New Size(20, Me.Width)
                End If
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

            Me.LineColor = theme.BorderColor
            Me.ForeColor = theme.ForeColor
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace