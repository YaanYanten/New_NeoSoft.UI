Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Contenedor para agrupar RadioButtons con gestión automática de selección,
    ''' soporte de iconos, colapsar/expandir y header personalizable
    ''' </summary>
    <ToolboxBitmap(GetType(GroupBox))>
    <DefaultProperty("Text")>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    Public Class NXGroup
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
        ''' Posición del icono en el header
        ''' </summary>
        Public Enum IconPosition
            ''' <summary>Izquierda del texto</summary>
            Left
            ''' <summary>Derecha del texto</summary>
            Right
        End Enum

        ''' <summary>
        ''' Estilo del fondo del header
        ''' </summary>
        Public Enum HeaderBackgroundStyle
            ''' <summary>Color sólido</summary>
            Solid
            ''' <summary>Gradiente horizontal</summary>
            Gradient
            ''' <summary>Transparente</summary>
            Transparent
        End Enum

#End Region

#Region "Campos Privados - NXAppearance"

        ' ⭐ PASO 1: Agregar campo privado para NXAppearance
        Private _appearance As NXAppearance

#End Region

#Region "Campos Privados - Otros"

        ' RadioButtons
        Private _radioButtons As New List(Of NXRadioButton)

        ' Colapsar/Expandir
        Private _collapsed As Boolean = False
        Private _allowCollapse As Boolean = False
        Private _expandedHeight As Integer = 0
        Private _collapsedHeight As Integer = 0
        Private _collapseButtonRect As Rectangle
        Private _isCollapseButtonHovered As Boolean = False
        Private _animationTimer As Timer

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
            Me.Size = New Size(250, 200)
            Me.Padding = New Padding(15, 50, 15, 15)
            Me.Font = New Font("Segoe UI", 9.0F)

            ' ⭐ PASO 2: Inicializar NXAppearance en constructor
            _appearance = New NXAppearance(Me)

            ' Timer para animación de colapso
            _animationTimer = New Timer()
            _animationTimer.Interval = 10
            AddHandler _animationTimer.Tick, AddressOf AnimationTimer_Tick

            ' Suscribirse a eventos de controles
            AddHandler Me.ControlAdded, AddressOf OnControlAddedToGroup
            AddHandler Me.ControlRemoved, AddressOf OnControlRemovedFromGroup

            ' Guardar altura inicial
            _expandedHeight = Me.Height
        End Sub

#End Region

#Region "⭐ PASO 3: Propiedad Principal NeoSoft.UI (Grupo Expandible)"

        ''' <summary>
        ''' Agrupa todas las propiedades de apariencia personalizadas de NeoSoft.UI
        ''' </summary>
        <Category("NeoSoft.UI")>
        <Description("Propiedades de apariencia personalizadas de NeoSoft.UI")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Appearance As NXAppearance
            Get
                Return _appearance
            End Get
        End Property

#End Region

#Region "⭐ PASO 4: Propiedades de Acceso Directo (Ocultas, para compatibilidad de código)"

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property BorderRadius As Integer
            Get
                Return _appearance.BorderRadius
            End Get
            Set(value As Integer)
                _appearance.BorderRadius = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property BorderSize As Integer
            Get
                Return _appearance.BorderSize
            End Get
            Set(value As Integer)
                _appearance.BorderSize = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property BorderColor As Color
            Get
                Return _appearance.BorderColor
            End Get
            Set(value As Color)
                _appearance.BorderColor = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property BorderStyleType As BorderStyle
            Get
                Return _appearance.BorderStyleType
            End Get
            Set(value As BorderStyle)
                _appearance.BorderStyleType = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderHeight As Integer
            Get
                Return _appearance.HeaderHeight
            End Get
            Set(value As Integer)
                _appearance.HeaderHeight = value
                UpdatePadding()
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderBackColor As Color
            Get
                Return _appearance.HeaderBackColor
            End Get
            Set(value As Color)
                _appearance.HeaderBackColor = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderBackColor2 As Color
            Get
                Return _appearance.HeaderBackColor2
            End Get
            Set(value As Color)
                _appearance.HeaderBackColor2 = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderBackgroundStl As HeaderBackgroundStyle
            Get
                Return _appearance.HeaderBackgroundStl
            End Get
            Set(value As HeaderBackgroundStyle)
                _appearance.HeaderBackgroundStl = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property ShowHeader As Boolean
            Get
                Return _appearance.ShowHeader
            End Get
            Set(value As Boolean)
                _appearance.ShowHeader = value
                UpdatePadding()
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderIcon As Image
            Get
                Return _appearance.HeaderIcon
            End Get
            Set(value As Image)
                _appearance.HeaderIcon = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderIconPosition As IconPosition
            Get
                Return _appearance.HeaderIconPosition
            End Get
            Set(value As IconPosition)
                _appearance.HeaderIconPosition = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderIconSize As Size
            Get
                Return _appearance.HeaderIconSize
            End Get
            Set(value As Size)
                _appearance.HeaderIconSize = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property HeaderIconSpacing As Integer
            Get
                Return _appearance.HeaderIconSpacing
            End Get
            Set(value As Integer)
                _appearance.HeaderIconSpacing = value
            End Set
        End Property

        <Browsable(False)>
        <NXProperty()>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property UseTheme As Boolean Implements IThemeable.UseTheme
            Get
                Return _appearance.UseTheme
            End Get
            Set(value As Boolean)
                _appearance.UseTheme = value
            End Set
        End Property

#End Region

#Region "Propiedades - Appearance (Texto)"

        ''' <summary>
        ''' Texto que se muestra en el header del grupo
        ''' </summary>
        <Category("Appearance")>
        <Description("Texto que se muestra en el header del grupo")>
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
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Behavior (Colapsar/Expandir)"

        <Category("Behavior")>
        <Description("Permite colapsar/expandir el grupo")>
        <DefaultValue(False)>
        Public Property AllowCollapse As Boolean
            Get
                Return _allowCollapse
            End Get
            Set(value As Boolean)
                If _allowCollapse <> value Then
                    _allowCollapse = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Behavior")>
        <Description("Indica si el grupo está colapsado")>
        <DefaultValue(False)>
        Public Property Collapsed As Boolean
            Get
                Return _collapsed
            End Get
            Set(value As Boolean)
                If _collapsed <> value Then
                    If _allowCollapse OrElse Not value Then
                        _collapsed = value
                        If _allowCollapse Then
                            AnimateCollapse()
                        End If
                        RaiseEvent CollapsedChanged(Me, EventArgs.Empty)
                    End If
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - RadioButtons"

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedRadioButton As NXRadioButton
            Get
                Return _radioButtons.FirstOrDefault(Function(rb) rb.Checked)
            End Get
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedIndex As Integer
            Get
                Dim selected = SelectedRadioButton
                If selected IsNot Nothing Then
                    Return _radioButtons.IndexOf(selected)
                End If
                Return -1
            End Get
            Set(value As Integer)
                If value >= 0 AndAlso value < _radioButtons.Count Then
                    _radioButtons(value).Checked = True
                End If
            End Set
        End Property

#End Region

#Region "Eventos"

        Public Event CollapsedChanged As EventHandler

#End Region

#Region "Métodos Públicos"

        Public Function GetRadioButtons() As List(Of NXRadioButton)
            Return New List(Of NXRadioButton)(_radioButtons)
        End Function

        Public Sub ClearSelection()
            For Each radio In _radioButtons
                radio.Checked = False
            Next
        End Sub

        Public Sub Expand()
            If _collapsed Then
                Collapsed = False
            End If
        End Sub

        Public Sub Collapse()
            If Not _collapsed Then
                Collapsed = True
            End If
        End Sub

#End Region

#Region "Métodos Internos"

        Friend Sub SetCheckedRadioButton(checkedRadio As NXRadioButton)
            For Each radio In _radioButtons
                If radio IsNot checkedRadio Then
                    radio.Checked = False
                End If
            Next
        End Sub

#End Region

#Region "Eventos de Controles"

        Private Sub OnControlAddedToGroup(sender As Object, e As ControlEventArgs)
            If TypeOf e.Control Is NXRadioButton Then
                Dim radio As NXRadioButton = DirectCast(e.Control, NXRadioButton)
                If Not _radioButtons.Contains(radio) Then
                    _radioButtons.Add(radio)
                    radio.RadioGroup = Me
                End If
            End If
        End Sub

        Private Sub OnControlRemovedFromGroup(sender As Object, e As ControlEventArgs)
            If TypeOf e.Control Is NXRadioButton Then
                Dim radio As NXRadioButton = DirectCast(e.Control, NXRadioButton)
                If _radioButtons.Contains(radio) Then
                    _radioButtons.Remove(radio)
                    radio.RadioGroup = Nothing
                End If
            End If
        End Sub

#End Region

#Region "Animación de Colapso"

        Private _targetHeight As Integer
        Private _currentHeight As Integer
        Private _animationStep As Integer = 15

        Private Sub AnimateCollapse()
            If _collapsed Then
                If _expandedHeight = 0 Then
                    _expandedHeight = Me.Height
                End If

                _collapsedHeight = _appearance.HeaderHeight + (_appearance.BorderSize * 2) + 5
                _targetHeight = _collapsedHeight

                For Each ctrl As Control In Me.Controls
                    ctrl.Visible = False
                Next
            Else
                _targetHeight = _expandedHeight
            End If

            _currentHeight = Me.Height

            If Not _animationTimer.Enabled Then
                _animationTimer.Start()
            End If
        End Sub

        Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs)
            Dim diff As Integer = _targetHeight - _currentHeight

            If Math.Abs(diff) <= _animationStep Then
                Me.Height = _targetHeight
                _animationTimer.Stop()

                If Not _collapsed Then
                    For Each ctrl As Control In Me.Controls
                        ctrl.Visible = True
                    Next
                End If
            Else
                If diff > 0 Then
                    _currentHeight += _animationStep
                Else
                    _currentHeight -= _animationStep
                End If

                Me.Height = _currentHeight
            End If

            Me.Invalidate()
        End Sub

#End Region

#Region "Eventos de Mouse"

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If _allowCollapse Then
                Dim wasHovered As Boolean = _isCollapseButtonHovered
                _isCollapseButtonHovered = _collapseButtonRect.Contains(e.Location)

                If wasHovered <> _isCollapseButtonHovered Then
                    Me.Cursor = If(_isCollapseButtonHovered, Cursors.Hand, Cursors.Default)
                    Me.Invalidate()
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)

            If _isCollapseButtonHovered Then
                _isCollapseButtonHovered = False
                Me.Cursor = Cursors.Default
                Me.Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
            MyBase.OnMouseClick(e)

            If _allowCollapse AndAlso _collapseButtonRect.Contains(e.Location) Then
                Collapsed = Not Collapsed
            End If
        End Sub

#End Region

#Region "⭐ PASO 5: Renderizado - Usar _appearance en lugar de campos directos"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            Dim rectBorder As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            ' ⭐ Usar _appearance.BorderRadius en lugar de _borderRadius
            Using path As GraphicsPath = GetRoundedRectangle(rectBorder, _appearance.BorderRadius)
                Using brush As New SolidBrush(Me.BackColor)
                    g.FillPath(brush, path)
                End Using

                If _appearance.ShowHeader Then
                    DrawHeader(g)
                End If

                ' ⭐ Usar _appearance.BorderSize y _appearance.BorderStyleType
                If _appearance.BorderSize > 0 AndAlso _appearance.BorderStyleType <> BorderStyle.None Then
                    DrawBorder(g, path, rectBorder)
                End If
            End Using

            MyBase.OnPaint(e)
        End Sub

        Private Sub DrawHeader(g As Graphics)
            ' ⭐ Usar _appearance.HeaderHeight
            Dim headerRect As New Rectangle(0, 0, Me.Width - 1, _appearance.HeaderHeight)

            Using headerPath As GraphicsPath = GetRoundedRectangleTop(headerRect, _appearance.BorderRadius)
                ' ⭐ Usar _appearance.HeaderBackgroundStyle
                Select Case _appearance.HeaderBackgroundStl
                    Case HeaderBackgroundStyle.Solid
                        Using brush As New SolidBrush(_appearance.HeaderBackColor)
                            g.FillPath(brush, headerPath)
                        End Using

                    Case HeaderBackgroundStyle.Gradient
                        Dim gradientColor2 As Color = If(_appearance.HeaderBackColor2 <> Color.Empty,
                                                         _appearance.HeaderBackColor2,
                                                         ControlPaint.Light(_appearance.HeaderBackColor, 0.1F))
                        Using brush As New LinearGradientBrush(headerRect, _appearance.HeaderBackColor, gradientColor2, LinearGradientMode.Horizontal)
                            g.FillPath(brush, headerPath)
                        End Using

                    Case HeaderBackgroundStyle.Transparent
                        ' No dibujar fondo
                End Select
            End Using

            Dim textX As Integer = 15
            Dim iconX As Integer = 15
            ' ⭐ Usar _appearance.HeaderIconSize
            Dim iconY As Integer = (_appearance.HeaderHeight - _appearance.HeaderIconSize.Height) \ 2

            ' ⭐ Usar _appearance.HeaderIcon
            If _appearance.HeaderIcon IsNot Nothing Then
                If _appearance.HeaderIconPosition = IconPosition.Left Then
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic
                    g.DrawImage(_appearance.HeaderIcon, iconX, iconY, _appearance.HeaderIconSize.Width, _appearance.HeaderIconSize.Height)
                    textX = iconX + _appearance.HeaderIconSize.Width + _appearance.HeaderIconSpacing
                End If
            End If

            Dim collapseButtonWidth As Integer = 0
            If _allowCollapse Then
                collapseButtonWidth = 30
            End If

            If Not String.IsNullOrEmpty(Me.Text) Then
                Using brush As New SolidBrush(Me.ForeColor)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Near,
                        .LineAlignment = StringAlignment.Center,
                        .FormatFlags = StringFormatFlags.NoWrap,
                        .Trimming = StringTrimming.EllipsisCharacter
                    }

                    Dim textWidth As Integer = Me.Width - textX - 15 - collapseButtonWidth
                    If _appearance.HeaderIcon IsNot Nothing AndAlso _appearance.HeaderIconPosition = IconPosition.Right Then
                        textWidth -= _appearance.HeaderIconSize.Width + _appearance.HeaderIconSpacing
                    End If

                    Dim textRect As New Rectangle(textX, 0, textWidth, _appearance.HeaderHeight)
                    g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                End Using
            End If

            If _appearance.HeaderIcon IsNot Nothing AndAlso _appearance.HeaderIconPosition = IconPosition.Right Then
                iconX = Me.Width - _appearance.HeaderIconSize.Width - 15 - collapseButtonWidth
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.DrawImage(_appearance.HeaderIcon, iconX, iconY, _appearance.HeaderIconSize.Width, _appearance.HeaderIconSize.Height)
            End If

            If _allowCollapse Then
                DrawCollapseButton(g)
            End If
        End Sub

        Private Sub DrawCollapseButton(g As Graphics)
            Dim buttonSize As Integer = 16
            Dim buttonX As Integer = Me.Width - buttonSize - 10
            Dim buttonY As Integer = (_appearance.HeaderHeight - buttonSize) \ 2

            _collapseButtonRect = New Rectangle(buttonX, buttonY, buttonSize, buttonSize)

            If _isCollapseButtonHovered Then
                Using brush As New SolidBrush(Color.FromArgb(50, Color.Black))
                    g.FillEllipse(brush, _collapseButtonRect)
                End Using
            End If

            Using pen As New Pen(Me.ForeColor, 2)
                pen.StartCap = LineCap.Round
                pen.EndCap = LineCap.Round

                Dim centerX As Integer = buttonX + buttonSize \ 2
                Dim centerY As Integer = buttonY + buttonSize \ 2
                Dim arrowSize As Integer = 4

                If _collapsed Then
                    g.DrawLine(pen, centerX - arrowSize, centerY - 2, centerX, centerY + 2)
                    g.DrawLine(pen, centerX, centerY + 2, centerX + arrowSize, centerY - 2)
                Else
                    g.DrawLine(pen, centerX - arrowSize, centerY + 2, centerX, centerY - 2)
                    g.DrawLine(pen, centerX, centerY - 2, centerX + arrowSize, centerY + 2)
                End If
            End Using
        End Sub

        Private Sub DrawBorder(g As Graphics, path As GraphicsPath, rect As Rectangle)
            ' ⭐ Usar _appearance.BorderStyleType
            Select Case _appearance.BorderStyleType
                Case BorderStyle.Solid
                    Using pen As New Pen(_appearance.BorderColor, _appearance.BorderSize)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using

                Case BorderStyle.Dotted
                    Using pen As New Pen(_appearance.BorderColor, _appearance.BorderSize)
                        pen.Alignment = PenAlignment.Inset
                        pen.DashStyle = DashStyle.Dot
                        g.DrawPath(pen, path)
                    End Using

                Case BorderStyle.Dashed
                    Using pen As New Pen(_appearance.BorderColor, _appearance.BorderSize)
                        pen.Alignment = PenAlignment.Inset
                        pen.DashStyle = DashStyle.Dash
                        g.DrawPath(pen, path)
                    End Using

                Case BorderStyle.Double
                    Using pen As New Pen(_appearance.BorderColor, _appearance.BorderSize)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using

                    Dim innerRect As New Rectangle(rect.X + _appearance.BorderSize + 2, rect.Y + _appearance.BorderSize + 2,
                                                   rect.Width - (_appearance.BorderSize + 2) * 2,
                                                   rect.Height - (_appearance.BorderSize + 2) * 2)
                    Using innerPath As GraphicsPath = GetRoundedRectangle(innerRect, _appearance.BorderRadius - 3)
                        Using pen As New Pen(_appearance.BorderColor, _appearance.BorderSize)
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

        Private Function GetRoundedRectangleTop(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            Dim diameter As Integer = radius * 2

            path.StartFigure()
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom)
            path.CloseFigure()

            Return path
        End Function

        Private Sub UpdatePadding()
            ' ⭐ Usar _appearance.ShowHeader y _appearance.HeaderHeight
            If _appearance.ShowHeader Then
                Me.Padding = New Padding(15, _appearance.HeaderHeight + 15, 15, 15)
            Else
                Me.Padding = New Padding(15, 15, 15, 15)
            End If
        End Sub

#End Region

#Region "Soporte de Temas"

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            If Not _appearance.UseTheme Then Return

            Me.BackColor = theme.PanelBackColor
            Me.ForeColor = theme.GroupForeColor
            _appearance.BorderColor = theme.BorderColor
            _appearance.HeaderBackColor = theme.GroupHeaderBackColor
            _appearance.BorderRadius = theme.GroupBorderRadius
            Me.Invalidate()
        End Sub

#End Region

#Region "⭐ PASO 6: Cleanup - Disponer _appearance"

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If _animationTimer IsNot Nothing Then
                    _animationTimer.Stop()
                    _animationTimer.Dispose()
                End If
                ' ⭐ Disponer _appearance
                _appearance?.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#End Region

    End Class

End Namespace