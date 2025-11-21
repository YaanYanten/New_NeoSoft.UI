Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' RadioButton personalizado con estilos modernos y animaciones
    ''' </summary>
    <ToolboxBitmap(GetType(RadioButton))>
    <DefaultEvent("CheckedChanged")>
    Public Class NXRadioButton
        Inherits Control
        Implements IThemeable

#Region "Campos Privados"

        Private _checked As Boolean = False
        Private _radioSize As Integer = 18
        Private _radioColor As Color = Color.FromArgb(0, 120, 215)
        Private _radioColorUnchecked As Color = Color.FromArgb(200, 200, 200)
        Private _radioColorDisabled As Color = Color.FromArgb(180, 180, 180)
        Private _animationProgress As Single = 0.0F
        Private _animationTimer As Timer
        Private _isHovered As Boolean = False
        Private _radioGroup As NXGroup = Nothing

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
            _animationTimer.Interval = 15
            AddHandler _animationTimer.Tick, AddressOf AnimationTimer_Tick
        End Sub

#End Region

#Region "Propiedades Públicas"

        <Category("Apariencia NX")>
        <Description("Indica si el RadioButton está seleccionado")>
        <DefaultValue(False)>
        Public Property Checked As Boolean
            Get
                Return _checked
            End Get
            Set(value As Boolean)
                If _checked <> value Then
                    _checked = value

                    If value Then
                        ' Desmarcar otros radiobuttons en el grupo
                        UncheckOtherRadioButtons()
                        StartAnimation()
                    End If

                    Me.Invalidate()
                    RaiseEvent CheckedChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Tamaño del círculo del RadioButton")>
        <DefaultValue(18)>
        Public Property RadioSize As Integer
            Get
                Return _radioSize
            End Get
            Set(value As Integer)
                If value < 10 Then value = 10
                If value > 50 Then value = 50
                If _radioSize <> value Then
                    _radioSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color cuando está seleccionado")>
        Public Property RadioColor As Color
            Get
                Return _radioColor
            End Get
            Set(value As Color)
                _radioColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color cuando no está seleccionado")>
        Public Property RadioColorUnchecked As Color
            Get
                Return _radioColorUnchecked
            End Get
            Set(value As Color)
                _radioColorUnchecked = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Grupo al que pertenece este RadioButton (para uso interno)
        ''' </summary>
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property RadioGroup As NXGroup
            Get
                Return _radioGroup
            End Get
            Set(value As NXGroup)
                _radioGroup = value
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

            ' Calcular posiciones
            Dim radioRect As New Rectangle(0, (Me.Height - _radioSize) \ 2, _radioSize, _radioSize)
            Dim textRect As New Rectangle(_radioSize + 8, 0, Me.Width - _radioSize - 8, Me.Height)

            ' Color según estado
            Dim currentColor As Color = If(Me.Enabled, If(_checked, _radioColor, _radioColorUnchecked), _radioColorDisabled)

            ' Dibujar círculo exterior con animación
            If _animationProgress > 0 AndAlso _checked Then
                Dim animColor As Color = Helpers.ColorHelper.Interpolate(_radioColorUnchecked, _radioColor, _animationProgress)
                Using pen As New Pen(animColor, 2)
                    g.DrawEllipse(pen, radioRect)
                End Using
            Else
                Using pen As New Pen(currentColor, 2)
                    g.DrawEllipse(pen, radioRect)
                End Using
            End If

            ' Efecto hover
            If _isHovered AndAlso Me.Enabled Then
                Using brush As New SolidBrush(Helpers.ColorHelper.WithOpacity(currentColor, 20))
                    g.FillEllipse(brush, radioRect)
                End Using
            End If

            ' Dibujar círculo interior si está checked
            If _checked Then
                Dim innerSize As Single = _radioSize * 0.5F
                Dim innerProgress As Single = If(_animationProgress > 0, _animationProgress, 1.0F)
                innerSize *= innerProgress

                Dim innerX As Single = radioRect.X + (_radioSize - innerSize) / 2.0F
                Dim innerY As Single = radioRect.Y + (_radioSize - innerSize) / 2.0F
                Dim innerRect As New RectangleF(innerX, innerY, innerSize, innerSize)

                Using brush As New SolidBrush(currentColor)
                    g.FillEllipse(brush, innerRect)
                End Using
            End If

            ' Dibujar texto
            If Not String.IsNullOrEmpty(Me.Text) Then
                Dim textColor As Color = If(Me.Enabled, Me.ForeColor, _radioColorDisabled)
                Using brush As New SolidBrush(textColor)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Near,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                End Using
            End If

            MyBase.OnPaint(e)
        End Sub

#End Region

#Region "Animación"

        Private Sub StartAnimation()
            _animationProgress = 0.0F
            _animationTimer.Start()
        End Sub

        Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs)
            _animationProgress += 0.2F

            If _animationProgress >= 1.0F Then
                _animationProgress = 0.0F
                _animationTimer.Stop()
            End If

            Me.Invalidate()
        End Sub

#End Region

#Region "Métodos Privados"

        Private Sub UncheckOtherRadioButtons()
            ' Si pertenece a un grupo, usar el grupo
            If _radioGroup IsNot Nothing Then
                _radioGroup.SetCheckedRadioButton(Me)
                Return
            End If

            ' Si no hay grupo, buscar en el contenedor padre
            If Me.Parent IsNot Nothing Then
                For Each ctrl As Control In Me.Parent.Controls
                    If TypeOf ctrl Is NXRadioButton AndAlso ctrl IsNot Me Then
                        Dim radio As NXRadioButton = DirectCast(ctrl, NXRadioButton)
                        ' Solo desmarcar si no pertenece a ningún grupo o pertenece al mismo contenedor
                        If radio.RadioGroup Is Nothing Then
                            radio.Checked = False
                        End If
                    End If
                Next
            End If
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

        Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
            If e.Button = MouseButtons.Left AndAlso Me.Enabled Then
                Me.Checked = True
            End If
            MyBase.OnMouseClick(e)
        End Sub

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter Then
                Me.Checked = True
                e.Handled = True
            End If
            MyBase.OnKeyDown(e)
        End Sub

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

            Me.ForeColor = theme.ForeColor
            Me.RadioColor = theme.PrimaryColor
            Me.RadioColorUnchecked = theme.BorderColor
            Me.Invalidate()
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

    End Class

End Namespace