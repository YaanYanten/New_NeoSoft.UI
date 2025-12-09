Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Control de pestañas (TabControl) personalizado con soporte para temas Material Design
    ''' Versión CORREGIDA con soporte completo para Design-Time
    ''' </summary>
    <ToolboxBitmap(GetType(TabControl))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Class NXTabControl
        Inherits TabControl
        Implements IThemeable

#Region "Fields"
        ' Colores
        Private _primaryColor As Color = Color.FromArgb(33, 150, 243)
        Private _surfaceColor As Color = Color.White
        Private _backgroundColor As Color = Color.FromArgb(245, 245, 245)
        Private _textColor As Color = Color.FromArgb(33, 33, 33)
        Private _textSecondaryColor As Color = Color.FromArgb(117, 117, 117)
        Private _borderColor As Color = Color.FromArgb(224, 224, 224)
        Private _hoverColor As Color = Color.FromArgb(240, 240, 240)
        Private _accentColor As Color = Color.FromArgb(33, 150, 243)

        ' Configuración
        Private _tabStyle As NXTabStyle = NXTabStyle.Material
        Private _tabPosition As NXTabPosition = NXTabPosition.Top
        Private _showCloseButton As Boolean = True
        Private _allowDragDrop As Boolean = False
        Private _animationEnabled As Boolean = True
        Private _tabHeight As Integer = 40
        Private _tabWidth As Integer = 150
        Private _useTheme As Boolean = False

        ' Estado
        Private _hoveredTabIndex As Integer = -1
        Private _hoveredCloseButtonIndex As Integer = -1
        Private _draggedTabIndex As Integer = -1
        Private _dragStartPoint As Point
        Private _isDragging As Boolean = False

        ' Animación
        Private WithEvents _animationTimer As Timer
        Private _animationProgress As Single = 0
        Private _animatingFromIndex As Integer = -1
        Private _animatingToIndex As Integer = -1
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()

            ' CRÍTICO: Configurar estilos ANTES de cualquier otra cosa
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

            ' Configuraciones básicas del TabControl
            Me.DrawMode = TabDrawMode.OwnerDrawFixed
            Me.SizeMode = TabSizeMode.Fixed
            Me.Appearance = TabAppearance.Normal  ' CRÍTICO para visibility
            Me.ItemSize = New Size(_tabWidth, _tabHeight)
            Me.Padding = New Point(16, 0)

            ' NO llamar UpdateStyles en design-time
            If Not Me.DesignMode Then
                Me.UpdateStyles()
            End If

            ' Inicializar timer solo en runtime
            If Not Me.DesignMode Then
                _animationTimer = New Timer()
                _animationTimer.Interval = 16 ' ~60 FPS
                AddHandler _animationTimer.Tick, AddressOf AnimationTimer_Tick
            Else
                ' En design-time, forzar layout inicial
                Me.UpdateBounds()
                Me.PerformLayout()
            End If
        End Sub
#End Region

#Region "NXTabPage"

        ''' <summary>
        ''' Página de pestaña personalizada para NXTabControl
        ''' </summary>
        Public Class NXTabPage
            Inherits Panel

            Private _image As Image
            Private _canClose As Boolean = True
            Private _tagData As Object

            <Category("Apariencia NX")>
            <NXProperty()>
            <Description("Imagen mostrada en la pestaña")>
            Public Property TabImage As Image
                Get
                    Return _image
                End Get
                Set(value As Image)
                    _image = value
                    If Parent IsNot Nothing Then Parent.Invalidate()
                End Set
            End Property

            <Category("Comportamiento")>
            <NXProperty()>
            <Description("Indica si la pestaña puede cerrarse")>
            <DefaultValue(True)>
            Public Property CanClose As Boolean
                Get
                    Return _canClose
                End Get
                Set(value As Boolean)
                    _canClose = value
                    If Parent IsNot Nothing Then Parent.Invalidate()
                End Set
            End Property

            <Category("Datos")>
            <Description("Datos adicionales asociados a la pestaña")>
            <Browsable(True)>
            Public Shadows Property Tag As Object
                Get
                    Return _tagData
                End Get
                Set(value As Object)
                    _tagData = value
                End Set
            End Property

            Public Sub New()
                MyBase.New()
                Me.Dock = DockStyle.Fill
            End Sub
        End Class

#End Region

#Region "Properties - Colors"
        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color primario del control")>
        Public Property PrimaryColor As Color
            Get
                Return _primaryColor
            End Get
            Set(value As Color)
                _primaryColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color de superficie (fondo de pestañas)")>
        Public Property SurfaceColor As Color
            Get
                Return _surfaceColor
            End Get
            Set(value As Color)
                _surfaceColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color de fondo del control")>
        Public Property BackgroundColor As Color
            Get
                Return _backgroundColor
            End Get
            Set(value As Color)
                _backgroundColor = value
                Me.BackColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color del texto principal")>
        Public Property TextColor As Color
            Get
                Return _textColor
            End Get
            Set(value As Color)
                _textColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color del texto secundario")>
        Public Property TextSecondaryColor As Color
            Get
                Return _textSecondaryColor
            End Get
            Set(value As Color)
                _textSecondaryColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
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

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color al pasar el mouse")>
        Public Property HoverColor As Color
            Get
                Return _hoverColor
            End Get
            Set(value As Color)
                _hoverColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Color de acento (línea activa)")>
        Public Property AccentColor As Color
            Get
                Return _accentColor
            End Get
            Set(value As Color)
                _accentColor = value
                Me.Invalidate()
            End Set
        End Property
#End Region

#Region "Properties - Configuration"
        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Estilo visual de las pestañas")>
        <DefaultValue(NXTabStyle.Material)>
        Public Property TabStyle As NXTabStyle
            Get
                Return _tabStyle
            End Get
            Set(value As NXTabStyle)
                _tabStyle = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Posición de las pestañas")>
        <DefaultValue(NXTabPosition.Top)>
        Public Property TabPosition As NXTabPosition
            Get
                Return _tabPosition
            End Get
            Set(value As NXTabPosition)
                _tabPosition = value
                Select Case value
                    Case NXTabPosition.Top
                        Me.Alignment = TabAlignment.Top
                    Case NXTabPosition.Bottom
                        Me.Alignment = TabAlignment.Bottom
                    Case NXTabPosition.Left
                        Me.Alignment = TabAlignment.Left
                    Case NXTabPosition.Right
                        Me.Alignment = TabAlignment.Right
                End Select
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Comportamiento")>
        <Description("Mostrar botón de cierre en las pestañas")>
        <DefaultValue(True)>
        Public Property ShowCloseButton As Boolean
            Get
                Return _showCloseButton
            End Get
            Set(value As Boolean)
                _showCloseButton = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Comportamiento")>
        <Description("Permitir arrastrar y soltar pestañas")>
        <DefaultValue(False)>
        Public Property AllowDragDrop As Boolean
            Get
                Return _allowDragDrop
            End Get
            Set(value As Boolean)
                _allowDragDrop = value
            End Set
        End Property

        <NXProperty()>
        <Category("Comportamiento")>
        <Description("Habilitar animaciones de transición")>
        <DefaultValue(True)>
        Public Property AnimationEnabled As Boolean
            Get
                Return _animationEnabled
            End Get
            Set(value As Boolean)
                _animationEnabled = value
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Altura de las pestañas")>
        <DefaultValue(40)>
        Public Property TabHeight As Integer
            Get
                Return _tabHeight
            End Get
            Set(value As Integer)
                _tabHeight = value
                Me.ItemSize = New Size(_tabWidth, _tabHeight)
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("Apariencia NX")>
        <Description("Ancho de las pestañas")>
        <DefaultValue(150)>
        Public Property TabWidth As Integer
            Get
                Return _tabWidth
            End Get
            Set(value As Integer)
                _tabWidth = value
                Me.ItemSize = New Size(_tabWidth, _tabHeight)
                Me.Invalidate()
            End Set
        End Property

        <Category("Comportamiento")>
        <Description("Usar tema del sistema")>
        <DefaultValue(False)>
        Public Property UseTheme As Boolean Implements IThemeable.UseTheme
            Get
                Return _useTheme
            End Get
            Set(value As Boolean)
                _useTheme = value
                If value AndAlso NXThemeManager.Instance IsNot Nothing Then
                    ApplyTheme(NXThemeManager.Instance.CurrentTheme)
                End If
            End Set
        End Property
#End Region

#Region "OnPaint - CRÍTICO PARA DESIGN-TIME"
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Try
                ' CRÍTICO: En design-time usar dibujo simplificado
                If Me.DesignMode Then
                    DrawDesignTimeView(e.Graphics)
                    Return
                End If

                ' Dibujo normal para runtime
                MyBase.OnPaint(e)

                If Me.TabCount > 0 Then
                    ' Dibujar fondo
                    e.Graphics.Clear(_backgroundColor)

                    ' Dibujar área de contenido
                    Dim contentRect As Rectangle = Me.DisplayRectangle
                    Using bgBrush As New SolidBrush(_surfaceColor)
                        e.Graphics.FillRectangle(bgBrush, contentRect)
                    End Using

                    ' Dibujar pestañas
                    For i As Integer = 0 To Me.TabCount - 1
                        DrawTab(e.Graphics, i)
                    Next
                End If

            Catch ex As Exception
                ' En caso de error en design-time, mostrar algo básico
                If Me.DesignMode Then
                    e.Graphics.Clear(Color.White)
                    Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                        e.Graphics.DrawString("NXTabControl", font, Brushes.Gray, 10, 10)
                    End Using
                End If
            End Try
        End Sub

        Private Sub DrawDesignTimeView(g As Graphics)
            ' Vista simplificada para el Designer de Visual Studio
            g.Clear(_backgroundColor)

            If Me.TabCount = 0 Then
                ' Si no hay pestañas, mostrar indicación
                Using font As New Font("Segoe UI", 10)
                    g.DrawString("NXTabControl (Sin pestañas)", font, Brushes.Gray, 10, 10)
                End Using
                Return
            End If

            ' Calcular áreas según posición de pestañas
            Dim tabAreaRect As Rectangle
            Dim contentRect As Rectangle = Me.ClientRectangle

            Select Case Me.Alignment
                Case TabAlignment.Top
                    tabAreaRect = New Rectangle(0, 0, Me.Width, _tabHeight + 4)
                    contentRect = New Rectangle(0, _tabHeight + 4, Me.Width, Me.Height - _tabHeight - 4)

                Case TabAlignment.Bottom
                    contentRect = New Rectangle(0, 0, Me.Width, Me.Height - _tabHeight - 4)
                    tabAreaRect = New Rectangle(0, contentRect.Bottom, Me.Width, _tabHeight + 4)

                Case TabAlignment.Left
                    tabAreaRect = New Rectangle(0, 0, _tabWidth + 4, Me.Height)
                    contentRect = New Rectangle(_tabWidth + 4, 0, Me.Width - _tabWidth - 4, Me.Height)

                Case TabAlignment.Right
                    contentRect = New Rectangle(0, 0, Me.Width - _tabWidth - 4, Me.Height)
                    tabAreaRect = New Rectangle(contentRect.Right, 0, _tabWidth + 4, Me.Height)
            End Select

            ' Dibujar área de pestañas con color distintivo
            Using bgBrush As New SolidBrush(Color.FromArgb(250, 250, 250))
                g.FillRectangle(bgBrush, tabAreaRect)
            End Using

            ' Dibujar área de contenido
            Using contentBrush As New SolidBrush(_surfaceColor)
                g.FillRectangle(contentBrush, contentRect)
            End Using
            Using borderPen As New Pen(_borderColor, 2)
                g.DrawRectangle(borderPen, contentRect)
            End Using

            ' Dibujar pestañas de forma básica pero visible
            For i As Integer = 0 To Me.TabCount - 1
                Try
                    Dim tabRect As Rectangle = GetTabRect(i)
                    Dim isSelected As Boolean = (i = SelectedIndex)

                    ' Fondo de pestaña con colores más contrastantes
                    Dim tabColor As Color = If(isSelected, Color.White, Color.FromArgb(230, 230, 230))
                    Using tabBrush As New SolidBrush(tabColor)
                        g.FillRectangle(tabBrush, tabRect)
                    End Using

                    ' Borde de pestaña más grueso si está seleccionada
                    Dim borderWidth As Integer = If(isSelected, 2, 1)
                    Using borderPen As New Pen(_borderColor, borderWidth)
                        g.DrawRectangle(borderPen, tabRect)
                    End Using

                    ' Línea de acento si está seleccionada - MÁS VISIBLE
                    If isSelected Then
                        Using accentPen As New Pen(_accentColor, 4)
                            Select Case Me.Alignment
                                Case TabAlignment.Top
                                    g.DrawLine(accentPen, tabRect.Left + 4, tabRect.Bottom - 2,
                                              tabRect.Right - 4, tabRect.Bottom - 2)
                                Case TabAlignment.Bottom
                                    g.DrawLine(accentPen, tabRect.Left + 4, tabRect.Top + 1,
                                              tabRect.Right - 4, tabRect.Top + 1)
                                Case TabAlignment.Left
                                    g.DrawLine(accentPen, tabRect.Right - 2, tabRect.Top + 4,
                                              tabRect.Right - 2, tabRect.Bottom - 4)
                                Case TabAlignment.Right
                                    g.DrawLine(accentPen, tabRect.Left + 1, tabRect.Top + 4,
                                              tabRect.Left + 1, tabRect.Bottom - 4)
                            End Select
                        End Using
                    End If

                    ' Texto de pestaña con mejor visibilidad
                    Dim textColor As Color = If(isSelected, Color.Black, Color.Gray)
                    Dim textFont As Font = If(isSelected,
                        New Font(Me.Font, FontStyle.Bold),
                        Me.Font)

                    Using textBrush As New SolidBrush(textColor)
                        Dim sf As New StringFormat()
                        sf.Alignment = StringAlignment.Center
                        sf.LineAlignment = StringAlignment.Center
                        sf.Trimming = StringTrimming.EllipsisCharacter

                        g.DrawString(Me.TabPages(i).Text, textFont, textBrush, tabRect, sf)
                        sf.Dispose()
                    End Using

                    If isSelected Then textFont.Dispose()

                Catch ex As Exception
                    ' Ignorar errores en pestañas individuales
                End Try
            Next

            ' Dibujar indicador de "clic aquí" si estamos en la primera vez
            If SelectedIndex = 0 AndAlso Me.TabCount > 1 Then
                Using hintFont As New Font("Segoe UI", 8, FontStyle.Italic)
                    Using hintBrush As New SolidBrush(Color.Gray)
                        g.DrawString("← Haz clic en las pestañas para cambiar",
                                   hintFont, hintBrush, tabAreaRect.Left + 10, tabAreaRect.Top + 2)
                    End Using
                End Using
            End If
        End Sub
#End Region

#Region "DrawTab Methods"
        Private Sub DrawTab(g As Graphics, index As Integer)
            Dim tabRect As Rectangle = GetTabRect(index)
            Dim isSelected As Boolean = (index = SelectedIndex)
            Dim isHovered As Boolean = (index = _hoveredTabIndex)

            Select Case _tabStyle
                Case NXTabStyle.Flat
                    DrawFlatTab(g, tabRect, index, isSelected, isHovered)
                Case NXTabStyle.ThreeD
                    DrawThreeDTab(g, tabRect, index, isSelected, isHovered)
                Case NXTabStyle.Material
                    DrawMaterialTab(g, tabRect, index, isSelected, isHovered)
            End Select
        End Sub

        Private Sub DrawFlatTab(g As Graphics, rect As Rectangle, index As Integer, isSelected As Boolean, isHovered As Boolean)
            ' Fondo
            Dim bgColor As Color = If(isSelected, _surfaceColor, If(isHovered, _hoverColor, _backgroundColor))
            Using brush As New SolidBrush(bgColor)
                g.FillRectangle(brush, rect)
            End Using

            ' Línea de acento para pestaña seleccionada
            If isSelected Then
                Using pen As New Pen(_accentColor, 3)
                    Select Case Me.Alignment
                        Case TabAlignment.Top
                            g.DrawLine(pen, rect.Left, rect.Bottom - 2, rect.Right, rect.Bottom - 2)
                        Case TabAlignment.Bottom
                            g.DrawLine(pen, rect.Left, rect.Top + 1, rect.Right, rect.Top + 1)
                        Case TabAlignment.Left
                            g.DrawLine(pen, rect.Right - 2, rect.Top, rect.Right - 2, rect.Bottom)
                        Case TabAlignment.Right
                            g.DrawLine(pen, rect.Left + 1, rect.Top, rect.Left + 1, rect.Bottom)
                    End Select
                End Using
            End If

            ' Texto
            DrawTabText(g, rect, index, isSelected)

            ' Botón de cierre
            If _showCloseButton AndAlso CanCloseTab(index) Then
                DrawCloseButton(g, rect, index)
            End If
        End Sub

        Private Sub DrawThreeDTab(g As Graphics, rect As Rectangle, index As Integer, isSelected As Boolean, isHovered As Boolean)
            ' Efecto 3D con gradiente
            Dim startColor As Color = If(isSelected, _surfaceColor, If(isHovered, _hoverColor, _backgroundColor))
            Dim endColor As Color = ControlPaint.Dark(startColor, 0.1)

            Using brush As New LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Vertical)
                g.FillRectangle(brush, rect)
            End Using

            ' Bordes elevados
            ControlPaint.DrawBorder3D(g, rect, Border3DStyle.Raised)

            ' Texto
            DrawTabText(g, rect, index, isSelected)

            ' Botón de cierre
            If _showCloseButton AndAlso CanCloseTab(index) Then
                DrawCloseButton(g, rect, index)
            End If
        End Sub

        Private Sub DrawMaterialTab(g As Graphics, rect As Rectangle, index As Integer, isSelected As Boolean, isHovered As Boolean)
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Fondo con esquinas redondeadas
            Dim bgColor As Color = If(isSelected, _surfaceColor, If(isHovered, _hoverColor, _backgroundColor))
            Using brush As New SolidBrush(bgColor)
                Using path As GraphicsPath = GetRoundedRectangle(rect, 8)
                    g.FillPath(brush, path)
                End Using
            End Using

            ' Sombra sutil para pestaña seleccionada
            If isSelected Then
                Using shadowBrush As New SolidBrush(Color.FromArgb(20, 0, 0, 0))
                    Dim shadowRect As New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
                    Using path As GraphicsPath = GetRoundedRectangle(shadowRect, 8)
                        g.FillPath(shadowBrush, path)
                    End Using
                End Using
            End If

            ' Línea de acento en la parte inferior
            If isSelected Then
                Using pen As New Pen(_accentColor, 3)
                    pen.StartCap = LineCap.Round
                    pen.EndCap = LineCap.Round
                    Dim y As Integer = rect.Bottom - 2
                    g.DrawLine(pen, rect.Left + 8, y, rect.Right - 8, y)
                End Using
            End If

            ' Texto
            DrawTabText(g, rect, index, isSelected)

            ' Botón de cierre
            If _showCloseButton AndAlso CanCloseTab(index) Then
                DrawCloseButton(g, rect, index)
            End If
        End Sub

        Private Sub DrawTabText(g As Graphics, rect As Rectangle, index As Integer, isSelected As Boolean)
            Dim textColor As Color = If(isSelected, _textColor, _textSecondaryColor)
            Dim textRect As Rectangle = rect

            ' Ajustar rectángulo si hay botón de cierre
            If _showCloseButton AndAlso CanCloseTab(index) Then
                textRect.Width -= 24
            End If

            ' Dibujar texto
            Using brush As New SolidBrush(textColor)
                Dim sf As New StringFormat()
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                sf.Trimming = StringTrimming.EllipsisCharacter
                g.DrawString(Me.TabPages(index).Text, Me.Font, brush, textRect, sf)
                sf.Dispose()
            End Using
        End Sub

        Private Sub DrawCloseButton(g As Graphics, tabRect As Rectangle, index As Integer)
            Dim isHovered As Boolean = (index = _hoveredCloseButtonIndex)
            Dim closeButtonRect As New Rectangle(
                tabRect.Right - 22,
                tabRect.Top + (tabRect.Height - 16) \ 2,
                16, 16)

            ' Fondo del botón si está hover
            If isHovered Then
                Using brush As New SolidBrush(Color.FromArgb(150, Color.Red))
                    g.FillEllipse(brush, closeButtonRect)
                End Using
            End If

            ' Dibujar X
            Using pen As New Pen(If(isHovered, Color.White, _textSecondaryColor), 2)
                pen.StartCap = LineCap.Round
                pen.EndCap = LineCap.Round
                Dim offset As Integer = 4
                g.DrawLine(pen,
                    closeButtonRect.Left + offset, closeButtonRect.Top + offset,
                    closeButtonRect.Right - offset, closeButtonRect.Bottom - offset)
                g.DrawLine(pen,
                    closeButtonRect.Right - offset, closeButtonRect.Top + offset,
                    closeButtonRect.Left + offset, closeButtonRect.Bottom - offset)
            End Using
        End Sub

        Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            Dim diameter As Integer = radius * 2

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
            path.CloseFigure()

            Return path
        End Function

        Private Function CanCloseTab(index As Integer) As Boolean
            If index < 0 OrElse index >= Me.TabCount Then Return False
            Dim page = TryCast(Me.TabPages(index), NXTabPage)
            Return If(page IsNot Nothing, page.CanClose, True)
        End Function
#End Region

#Region "Mouse Events - Design-Time Support"
        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            ' Permitir cambio de pestaña en design-time mediante clic
            If Me.DesignMode Then
                For i As Integer = 0 To Me.TabCount - 1
                    Try
                        Dim tabRect As Rectangle = GetTabRect(i)
                        If tabRect.Contains(e.Location) Then
                            Me.SelectedIndex = i
                            Me.Invalidate()
                            Exit For
                        End If
                    Catch
                        ' Ignorar errores al obtener rectángulo de pestaña
                    End Try
                Next
            End If
        End Sub
#End Region

#Region "Animation"
        Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles _animationTimer.Tick
            _animationProgress += 0.1F
            If _animationProgress >= 1.0F Then
                _animationProgress = 1.0F
                _animationTimer.Stop()
                _animatingFromIndex = -1
                _animatingToIndex = -1
            End If
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
            MyBase.OnSelectedIndexChanged(e)

            ' Solo animar en runtime
            If Not Me.DesignMode AndAlso _animationEnabled AndAlso _animationTimer IsNot Nothing Then
                _animatingFromIndex = If(_animatingToIndex = -1, 0, _animatingToIndex)
                _animatingToIndex = Me.SelectedIndex
                _animationProgress = 0
                _animationTimer.Start()
            End If
        End Sub
#End Region

#Region "IThemeable Implementation"
        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            If theme Is Nothing Then Return

            _primaryColor = theme.PrimaryColor
            '_surfaceColor = theme.Surface
            '_backgroundColor = theme.Background
            '_textColor = theme.OnSurface
            '_borderColor = Color.FromArgb(Math.Max(0, theme.OnSurface.R - 100),
            '                             Math.Max(0, theme.OnSurface.G - 100),
            '                             Math.Max(0, theme.OnSurface.B - 100))
            '_textSecondaryColor = Color.FromArgb(theme.OnSurface.A \ 2,
            '                                    theme.OnSurface.R,
            '                                    theme.OnSurface.G,
            '                                    theme.OnSurface.B)
            '_hoverColor = Color.FromArgb(Math.Min(255, theme.Surface.R + 10),
            '                            Math.Min(255, theme.Surface.G + 10),
            '                            Math.Min(255, theme.Surface.B + 10))
            _accentColor = theme.PrimaryColor

            Me.Invalidate()
        End Sub
#End Region

#Region "Cleanup"
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

#Region "Enums"
    Public Enum NXTabStyle
        Flat
        ThreeD
        Material
    End Enum

    Public Enum NXTabPosition
        Top
        Bottom
        Left
        Right
    End Enum
#End Region

End Namespace