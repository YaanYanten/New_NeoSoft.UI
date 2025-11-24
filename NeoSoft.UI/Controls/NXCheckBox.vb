Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design

Namespace Controls

    ''' <summary>
    ''' CheckBox personalizado con estilos modernos, animaciones y switch toggle
    ''' </summary>
    <ToolboxBitmap(GetType(CheckBox))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DefaultEvent("CheckedChanged")>
    Public Class NXCheckBox
        Inherits Control
        Implements Theming.IThemeable

#Region "Enumeraciones"

        Public Enum CheckBoxStyle
            Standard    ' CheckBox tradicional con check mark
            Switch      ' Toggle switch estilo iOS/Material
            Button      ' Botón que cambia de estado
        End Enum

#End Region

#Region "Campos Privados"

        Private _checked As Boolean = False
        Private _checkBoxStyle As CheckBoxStyle = CheckBoxStyle.Standard
        Private _checkSize As Integer = 20
        Private _checkColor As Color = Color.FromArgb(0, 120, 215)
        Private _checkColorUnchecked As Color = Color.FromArgb(200, 200, 200)
        Private _checkColorDisabled As Color = Color.FromArgb(180, 180, 180)
        Private _borderRadius As Integer = 4
        Private _animationProgress As Single = 0.0F
        Private _animationTimer As Timer
        Private _isHovered As Boolean = False
        Private _isPressed As Boolean = False

        ' Switch específico
        Private _switchWidth As Integer = 45
        Private _switchHeight As Integer = 22
        Private _switchPadding As Integer = 2
        Private _switchColorOn As Color = Color.FromArgb(76, 175, 80)
        Private _switchColorOff As Color = Color.FromArgb(189, 189, 189)

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            Me.BackColor = Color.Transparent
            Me.ForeColor = Color.Black
            Me.Font = New Font("Segoe UI", 9.0F)
            Me.Size = New Size(150, 25)
            Me.Cursor = Cursors.Hand

            ' Timer para animaciones
            _animationTimer = New Timer()
            _animationTimer.Interval = 15 ' ~60 FPS
            AddHandler _animationTimer.Tick, AddressOf AnimationTimer_Tick
        End Sub

#End Region

#Region "Propiedades Públicas"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Indica si el CheckBox está marcado")>
        <DefaultValue(False)>
        Public Property Checked As Boolean
            Get
                Return _checked
            End Get
            Set(value As Boolean)
                If _checked <> value Then
                    _checked = value
                    StartAnimation()
                    Me.Invalidate()
                    RaiseEvent CheckedChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo del CheckBox (Standard, Switch, Button)")>
        <DefaultValue(GetType(CheckBoxStyle), "Standard")>
        Public Property Style As CheckBoxStyle
            Get
                Return _checkBoxStyle
            End Get
            Set(value As CheckBoxStyle)
                If _checkBoxStyle <> value Then
                    _checkBoxStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Tamaño del checkbox en píxeles")>
        <DefaultValue(20)>
        Public Property CheckSize As Integer
            Get
                Return _checkSize
            End Get
            Set(value As Integer)
                If value < 10 Then value = 10
                If value > 50 Then value = 50
                If _checkSize <> value Then
                    _checkSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color cuando está marcado")>
        Public Property CheckColor As Color
            Get
                Return _checkColor
            End Get
            Set(value As Color)
                _checkColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color cuando está desmarcado")>
        Public Property CheckColorUnchecked As Color
            Get
                Return _checkColorUnchecked
            End Get
            Set(value As Color)
                _checkColorUnchecked = value
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
                If _borderRadius <> value Then
                    _borderRadius = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Ancho del switch (solo para estilo Switch)")>
        <DefaultValue(45)>
        Public Property SwitchWidth As Integer
            Get
                Return _switchWidth
            End Get
            Set(value As Integer)
                If value < 30 Then value = 30
                If _switchWidth <> value Then
                    _switchWidth = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Alto del switch (solo para estilo Switch)")>
        <DefaultValue(22)>
        Public Property SwitchHeight As Integer
            Get
                Return _switchHeight
            End Get
            Set(value As Integer)
                If value < 15 Then value = 15
                If _switchHeight <> value Then
                    _switchHeight = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del switch cuando está ON")>
        Public Property SwitchColorOn As Color
            Get
                Return _switchColorOn
            End Get
            Set(value As Color)
                _switchColorOn = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del switch cuando está OFF")>
        Public Property SwitchColorOff As Color
            Get
                Return _switchColorOff
            End Get
            Set(value As Color)
                _switchColorOff = value
                Me.Invalidate()
            End Set
        End Property

#End Region

#Region "Eventos"

        Public Event CheckedChanged As EventHandler

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            Select Case _checkBoxStyle
                Case CheckBoxStyle.Standard
                    DrawStandardCheckBox(g)
                Case CheckBoxStyle.Switch
                    DrawSwitchCheckBox(g)
                Case CheckBoxStyle.Button
                    DrawButtonCheckBox(g)
            End Select

            MyBase.OnPaint(e)
        End Sub

        Private Sub DrawStandardCheckBox(g As Graphics)
            Try
                ' Calcular posiciones
                Dim checkRect As New Rectangle(0, (Me.Height - _checkSize) \ 2, _checkSize, _checkSize)
                Dim textRect As New Rectangle(_checkSize + 8, 0, Me.Width - _checkSize - 8, Me.Height)

                ' Color del checkbox según estado
                Dim currentColor As Color = If(Me.Enabled, If(_checked, _checkColor, _checkColorUnchecked), _checkColorDisabled)

                ' Fondo del checkbox con animación
                If _animationProgress > 0 AndAlso _checked Then
                    Dim animColor As Color = Helpers.ColorHelper.Interpolate(_checkColorUnchecked, _checkColor, _animationProgress)
                    Using path As GraphicsPath = GetRoundedRectangle(checkRect, _borderRadius)
                        Using brush As New SolidBrush(animColor)
                            g.FillPath(brush, path)
                        End Using
                    End Using
                ElseIf _animationProgress > 0 AndAlso Not _checked Then
                    Dim animColor As Color = Helpers.ColorHelper.Interpolate(_checkColor, _checkColorUnchecked, _animationProgress)
                    Using path As GraphicsPath = GetRoundedRectangle(checkRect, _borderRadius)
                        Using pen As New Pen(animColor, 2)
                            g.DrawPath(pen, path)
                        End Using
                    End Using
                Else
                    ' Estado estático
                    Using path As GraphicsPath = GetRoundedRectangle(checkRect, _borderRadius)
                        If _checked Then
                            Using brush As New SolidBrush(currentColor)
                                g.FillPath(brush, path)
                            End Using
                        Else
                            Using pen As New Pen(currentColor, 2)
                                g.DrawPath(pen, path)
                            End Using
                        End If
                    End Using
                End If

                ' Efecto hover
                If _isHovered AndAlso Me.Enabled Then
                    Using path As GraphicsPath = GetRoundedRectangle(checkRect, _borderRadius)
                        Using brush As New SolidBrush(Helpers.ColorHelper.WithOpacity(currentColor, 20))
                            g.FillPath(brush, path)
                        End Using
                    End Using
                End If

                ' Dibujar check mark
                If _checked Then
                    Dim checkProgress As Single = If(_animationProgress > 0, _animationProgress, 1.0F)
                    DrawCheckMark(g, checkRect, Color.White, checkProgress)
                End If

                ' Dibujar texto
                If Not String.IsNullOrEmpty(Me.Text) Then
                    Dim textColor As Color = If(Me.Enabled, Me.ForeColor, _checkColorDisabled)
                    Using brush As New SolidBrush(textColor)
                        Dim sf As New StringFormat With {
                            .Alignment = StringAlignment.Near,
                            .LineAlignment = StringAlignment.Center
                        }
                        g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                    End Using
                End If

            Catch ex As Exception
                ' Fallback silencioso
                DrawBasicFallback(g)
            End Try
        End Sub

        Private Sub DrawBasicFallback(g As Graphics)
            Try
                Dim checkRect As New Rectangle(0, (Me.Height - _checkSize) \ 2, _checkSize, _checkSize)
                Using brush As New SolidBrush(If(_checked, _checkColor, _checkColorUnchecked))
                    g.FillRectangle(brush, checkRect)
                End Using
            Catch
                ' Silencioso
            End Try
        End Sub

        Private Sub DrawSwitchCheckBox(g As Graphics)
            Try
                ' Calcular posiciones
                Dim switchRect As New Rectangle(0, (Me.Height - _switchHeight) \ 2, _switchWidth, _switchHeight)
                Dim textRect As New Rectangle(_switchWidth + 8, 0, Me.Width - _switchWidth - 8, Me.Height)

                ' Color del switch según estado con animación
                Dim currentColor As Color
                If _animationProgress > 0 Then
                    currentColor = If(_checked,
                        Helpers.ColorHelper.Interpolate(_switchColorOff, _switchColorOn, _animationProgress),
                        Helpers.ColorHelper.Interpolate(_switchColorOn, _switchColorOff, _animationProgress))
                Else
                    currentColor = If(_checked, _switchColorOn, _switchColorOff)
                End If

                If Not Me.Enabled Then
                    currentColor = _checkColorDisabled
                End If

                ' Dibujar track del switch
                Dim trackRadius As Integer = _switchHeight \ 2
                Using path As GraphicsPath = GetRoundedRectangle(switchRect, trackRadius)
                    Using brush As New SolidBrush(currentColor)
                        g.FillPath(brush, path)
                    End Using
                End Using

                ' Calcular posición del thumb con animación
                Dim thumbSize As Integer = _switchHeight - (_switchPadding * 2)
                Dim thumbOffPosition As Integer = switchRect.X + _switchPadding
                Dim thumbOnPosition As Integer = switchRect.Right - thumbSize - _switchPadding

                Dim thumbX As Integer
                If _animationProgress > 0 Then
                    Dim diff As Integer = thumbOnPosition - thumbOffPosition
                    thumbX = If(_checked,
                        thumbOffPosition + CInt(diff * _animationProgress),
                        thumbOnPosition - CInt(diff * _animationProgress))
                Else
                    thumbX = If(_checked, thumbOnPosition, thumbOffPosition)
                End If

                Dim thumbY As Integer = switchRect.Y + _switchPadding
                Dim thumbRect As New Rectangle(thumbX, thumbY, thumbSize, thumbSize)

                ' Dibujar thumb (círculo)
                Using brush As New SolidBrush(Color.White)
                    g.FillEllipse(brush, thumbRect)
                End Using

                ' Sombra del thumb
                If Me.Enabled Then
                    Using shadowBrush As New SolidBrush(Color.FromArgb(50, 0, 0, 0))
                        Dim shadowRect As New Rectangle(thumbRect.X + 1, thumbRect.Y + 2, thumbRect.Width, thumbRect.Height)
                        g.FillEllipse(shadowBrush, shadowRect)
                    End Using
                End If

                ' Dibujar texto
                If Not String.IsNullOrEmpty(Me.Text) Then
                    Dim textColor As Color = If(Me.Enabled, Me.ForeColor, _checkColorDisabled)
                    Using brush As New SolidBrush(textColor)
                        Dim sf As New StringFormat With {
                            .Alignment = StringAlignment.Near,
                            .LineAlignment = StringAlignment.Center
                        }
                        g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                    End Using
                End If

            Catch ex As Exception
                ' Silencioso
            End Try
        End Sub

        Private Sub DrawButtonCheckBox(g As Graphics)
            Try
                Dim buttonRect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
                Dim currentColor As Color = If(_checked, _checkColor, _checkColorUnchecked)

                If Not Me.Enabled Then
                    currentColor = _checkColorDisabled
                End If

                Using path As GraphicsPath = GetRoundedRectangle(buttonRect, _borderRadius)
                    If _checked Then
                        Using brush As New SolidBrush(currentColor)
                            g.FillPath(brush, path)
                        End Using
                    Else
                        Using brush As New SolidBrush(Me.BackColor)
                            g.FillPath(brush, path)
                        End Using
                        Using pen As New Pen(currentColor, 2)
                            g.DrawPath(pen, path)
                        End Using
                    End If

                    If _isHovered AndAlso Me.Enabled Then
                        Using brush As New SolidBrush(Color.FromArgb(30, currentColor))
                            g.FillPath(brush, path)
                        End Using
                    End If

                    If _isPressed AndAlso Me.Enabled Then
                        Using brush As New SolidBrush(Color.FromArgb(50, Color.Black))
                            g.FillPath(brush, path)
                        End Using
                    End If
                End Using

                If Not String.IsNullOrEmpty(Me.Text) Then
                    Dim textColor As Color = If(_checked, Color.White, Me.ForeColor)
                    If Not Me.Enabled Then textColor = _checkColorDisabled

                    Using brush As New SolidBrush(textColor)
                        Dim sf As New StringFormat With {
                            .Alignment = StringAlignment.Center,
                            .LineAlignment = StringAlignment.Center
                        }
                        g.DrawString(Me.Text, Me.Font, brush, buttonRect, sf)
                    End Using
                End If

            Catch ex As Exception
                ' Silencioso
            End Try
        End Sub

        Private Sub DrawCheckMark(g As Graphics, rect As Rectangle, color As Color, progress As Single)
            Dim scale As Single = rect.Width / 20.0F
            Dim centerX As Integer = rect.X + rect.Width \ 2
            Dim centerY As Integer = rect.Y + rect.Height \ 2

            Dim pt1 As New PointF(centerX - 5 * scale, centerY)
            Dim pt2 As New PointF(centerX - 2 * scale, centerY + 3 * scale)
            Dim pt3 As New PointF(centerX + 5 * scale, centerY - 4 * scale)

            If progress < 1.0F Then
                pt3.X = pt2.X + (pt3.X - pt2.X) * progress
                pt3.Y = pt2.Y + (pt3.Y - pt2.Y) * progress
            End If

            Using pen As New Pen(color, 2.5F)
                pen.StartCap = LineCap.Round
                pen.EndCap = LineCap.Round
                g.DrawLine(pen, pt1, pt2)
                If progress > 0.3F Then
                    g.DrawLine(pen, pt2, pt3)
                End If
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

#Region "Animación"

        Private Sub StartAnimation()
            _animationProgress = 0.0F
            _animationTimer.Start()
        End Sub

        Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs)
            _animationProgress += 0.15F

            If _animationProgress >= 1.0F Then
                _animationProgress = 0.0F
                _animationTimer.Stop()
            End If

            Me.Invalidate()
        End Sub

#End Region

#Region "Eventos del Mouse"

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            _isHovered = True
            Me.Invalidate()
            MyBase.OnMouseEnter(e)
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            _isHovered = False
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
            If e.Button = MouseButtons.Left Then
                _isPressed = False
                If Me.ClientRectangle.Contains(e.Location) Then
                    Me.Checked = Not Me.Checked
                End If
                Me.Invalidate()
            End If
            MyBase.OnMouseUp(e)
        End Sub

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter Then
                Me.Checked = Not Me.Checked
                e.Handled = True
            End If
            MyBase.OnKeyDown(e)
        End Sub

#End Region

#Region "Limpieza"

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

#Region "Soporte de Temas"

        Private _useTheme As Boolean = False

        <Category("Apariencia NX")>
        <NXProperty()>
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
            Me.CheckColor = theme.PrimaryColor
            Me.CheckColorUnchecked = theme.BorderColor
            Me.SwitchColorOn = theme.SuccessColor
            Me.SwitchColorOff = theme.DisabledColor
            Me.BorderRadius = theme.BorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace