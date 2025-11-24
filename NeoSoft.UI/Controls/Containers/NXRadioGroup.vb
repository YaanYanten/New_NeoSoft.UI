Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Control RadioGroup estilo DevExpress con colección de items editable
    ''' </summary>
    <ToolboxBitmap(GetType(RadioButton))>
    <DefaultProperty("Items")>
    <DefaultEvent("SelectedIndexChanged")>
    Public Class NXRadioGroup
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        Public Enum LayoutOrientation
            Vertical
            Horizontal
            Flow
        End Enum

        Public Enum GlyphAlignment
            Near
            Far
        End Enum

#End Region

#Region "Campos Privados"

        Private _items As NXRadioGroupItemCollection
        Private _selectedIndex As Integer = -1
        Private _borderRadius As Integer = 8
        Private _borderSize As Integer = 1
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _itemSpacing As Integer = 8
        Private _itemHeight As Integer = 28
        Private _radioSize As Integer = 18
        Private _radioColor As Color = Color.FromArgb(0, 120, 215)
        Private _radioColorUnchecked As Color = Color.FromArgb(200, 200, 200)
        Private _hoveredIndex As Integer = -1
        Private _columns As Integer = 0
        Private _orientation As LayoutOrientation = LayoutOrientation.Vertical
        Private _glyphAlignment As GlyphAlignment = GlyphAlignment.Near
        Private _itemBounds As New List(Of Rectangle)

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor Or
                       ControlStyles.Selectable, True)

            _items = New NXRadioGroupItemCollection(Me)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Font = New Font("Segoe UI", 9.0F)
            Me.Size = New Size(200, 150)
            Me.Padding = New Padding(10)
        End Sub

#End Region

#Region "Propiedades Públicas"

        <Category("Data")>
        <Description("Colección de items del RadioGroup")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Editor(GetType(NXRadioGroupItemCollectionEditor), GetType(System.Drawing.Design.UITypeEditor))>
        Public ReadOnly Property Items As NXRadioGroupItemCollection
            Get
                Return _items
            End Get
        End Property

        <Category("Behavior")>
        <Description("Índice del item seleccionado")>
        <DefaultValue(-1)>
        Public Property SelectedIndex As Integer
            Get
                Return _selectedIndex
            End Get
            Set(value As Integer)
                If value < -1 OrElse value >= _items.Count Then
                    value = -1
                End If

                If _selectedIndex <> value Then
                    _selectedIndex = value
                    Me.Invalidate()
                    RaiseEvent SelectedIndexChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Category("Behavior")>
        <Description("Item seleccionado actualmente")>
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedItem As NXRadioGroupItem
            Get
                If _selectedIndex >= 0 AndAlso _selectedIndex < _items.Count Then
                    Return _items(_selectedIndex)
                End If
                Return Nothing
            End Get
            Set(value As NXRadioGroupItem)
                If value IsNot Nothing Then
                    Dim index = _items.IndexOf(value)
                    If index >= 0 Then
                        SelectedIndex = index
                    End If
                End If
            End Set
        End Property

        <Category("Layout")>
        <Description("Número de columnas (0 = automático)")>
        <DefaultValue(0)>
        Public Property Columns As Integer
            Get
                Return _columns
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _columns <> value Then
                    _columns = value
                    CalculateLayout()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Layout")>
        <Description("Orientación del layout")>
        <DefaultValue(GetType(LayoutOrientation), "Vertical")>
        Public Property Orientation As LayoutOrientation
            Get
                Return _orientation
            End Get
            Set(value As LayoutOrientation)
                If _orientation <> value Then
                    _orientation = value
                    CalculateLayout()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Layout")>
        <Description("Alineación del glyph (radio button)")>
        <DefaultValue(GetType(GlyphAlignment), "Near")>
        Public Property GlyphAlignments As GlyphAlignment
            Get
                Return _glyphAlignment
            End Get
            Set(value As GlyphAlignment)
                If _glyphAlignment <> value Then
                    _glyphAlignment = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Espaciado entre items")>
        <DefaultValue(8)>
        Public Property ItemSpacing As Integer
            Get
                Return _itemSpacing
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _itemSpacing <> value Then
                    _itemSpacing = value
                    CalculateLayout()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Altura de cada item")>
        <DefaultValue(28)>
        Public Property ItemHeight As Integer
            Get
                Return _itemHeight
            End Get
            Set(value As Integer)
                If value < 20 Then value = 20
                If _itemHeight <> value Then
                    _itemHeight = value
                    CalculateLayout()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Tamaño del círculo del radio button")>
        <DefaultValue(18)>
        Public Property RadioSize As Integer
            Get
                Return _radioSize
            End Get
            Set(value As Integer)
                If value < 12 Then value = 12
                If value > 30 Then value = 30
                If _radioSize <> value Then
                    _radioSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Radio del borde redondeado")>
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

        <Category("Apariencia NX")>
        <Description("Grosor del borde")>
        <DefaultValue(1)>
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

        <Category("Apariencia NX")>
        <Description("Color del borde")>
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

#End Region

#Region "Eventos"

        Public Event SelectedIndexChanged As EventHandler

#End Region

#Region "Métodos Públicos"

        Friend Sub OnItemsChanged()
            CalculateLayout()
            Me.Invalidate()
        End Sub

#End Region

#Region "Métodos Privados - Layout"

        Private Sub CalculateLayout()
            _itemBounds.Clear()

            If _items.Count = 0 Then
                Return
            End If

            Dim contentRect As New Rectangle(
                Me.Padding.Left,
                Me.Padding.Top,
                Me.Width - Me.Padding.Horizontal,
                Me.Height - Me.Padding.Vertical)

            Select Case _orientation
                Case LayoutOrientation.Vertical
                    CalculateVerticalLayout(contentRect)
                Case LayoutOrientation.Horizontal
                    CalculateHorizontalLayout(contentRect)
                Case LayoutOrientation.Flow
                    CalculateFlowLayout(contentRect)
            End Select
        End Sub

        Private Sub CalculateVerticalLayout(contentRect As Rectangle)
            Dim y As Integer = contentRect.Top
            Dim itemWidth As Integer = contentRect.Width

            If _columns > 0 Then
                ' Layout con múltiples columnas
                Dim columnWidth As Integer = contentRect.Width \ _columns
                Dim itemsPerColumn As Integer = CInt(Math.Ceiling(_items.Count / CDbl(_columns)))

                For i As Integer = 0 To _items.Count - 1
                    Dim col As Integer = i \ itemsPerColumn
                    Dim row As Integer = i Mod itemsPerColumn

                    Dim x As Integer = contentRect.Left + (col * columnWidth)
                    Dim itemY As Integer = contentRect.Top + (row * (_itemHeight + _itemSpacing))

                    ' Restar spacing del ancho de columna para evitar solapamiento
                    Dim actualColumnWidth As Integer = columnWidth - (_itemSpacing \ 2)
                    _itemBounds.Add(New Rectangle(x, itemY, actualColumnWidth, _itemHeight))
                Next
            Else
                ' Layout de una sola columna - usar todo el ancho disponible
                For i As Integer = 0 To _items.Count - 1
                    _itemBounds.Add(New Rectangle(contentRect.Left, y, itemWidth, _itemHeight))
                    y += _itemHeight + _itemSpacing
                Next
            End If
        End Sub

        Private Sub CalculateHorizontalLayout(contentRect As Rectangle)
            Dim x As Integer = contentRect.Left
            Dim y As Integer = contentRect.Top
            Dim itemWidth As Integer

            If _columns > 0 Then
                ' Ancho fijo basado en columnas
                itemWidth = (contentRect.Width - (_itemSpacing * (_columns - 1))) \ _columns
            Else
                ' Ancho automático basado en el número de items
                If _items.Count > 0 Then
                    itemWidth = (contentRect.Width - (_itemSpacing * (_items.Count - 1))) \ _items.Count
                Else
                    itemWidth = 100
                End If
            End If

            For i As Integer = 0 To _items.Count - 1
                ' Si excede el ancho, saltar a la siguiente línea
                If _columns > 0 AndAlso x + itemWidth > contentRect.Right Then
                    x = contentRect.Left
                    y += _itemHeight + _itemSpacing
                End If

                _itemBounds.Add(New Rectangle(x, y, itemWidth, _itemHeight))
                x += itemWidth + _itemSpacing
            Next
        End Sub

        Private Sub CalculateFlowLayout(contentRect As Rectangle)
            Dim x As Integer = contentRect.Left
            Dim y As Integer = contentRect.Top
            Dim itemWidth As Integer = 150 ' Ancho predeterminado más amplio

            ' Calcular ancho óptimo basado en el texto más largo si es posible
            If _items.Count > 0 Then
                Using g As Graphics = Me.CreateGraphics()
                    Dim maxTextWidth As Integer = 0
                    For Each item As NXRadioGroupItem In _items
                        Dim textSize As Size = TextRenderer.MeasureText(g, item.Text, Me.Font)
                        maxTextWidth = Math.Max(maxTextWidth, textSize.Width)
                    Next
                    ' Agregar espacio para el radio button y márgenes
                    itemWidth = Math.Max(150, maxTextWidth + _radioSize + 30)
                End Using
            End If

            For i As Integer = 0 To _items.Count - 1
                ' Salto de línea si se excede el ancho
                If x + itemWidth > contentRect.Right AndAlso x > contentRect.Left Then
                    x = contentRect.Left
                    y += _itemHeight + _itemSpacing
                End If

                _itemBounds.Add(New Rectangle(x, y, Math.Min(itemWidth, contentRect.Width), _itemHeight))
                x += itemWidth + _itemSpacing
            Next
        End Sub

        Private Function GetItemIndexAt(location As Point) As Integer
            For i As Integer = 0 To _itemBounds.Count - 1
                If _itemBounds(i).Contains(location) Then
                    Return i
                End If
            Next
            Return -1
        End Function

#End Region

#Region "Métodos de Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Dibujar fondo
            Using path As GraphicsPath = GetRoundedRectangle(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), _borderRadius)
                Using brush As New SolidBrush(Me.BackColor)
                    g.FillPath(brush, path)
                End Using

                ' Dibujar borde
                If _borderSize > 0 Then
                    Using pen As New Pen(_borderColor, _borderSize)
                        g.DrawPath(pen, path)
                    End Using
                End If
            End Using

            ' Dibujar items
            For i As Integer = 0 To _items.Count - 1
                DrawRadioItem(g, i)
            Next
        End Sub

        Private Sub DrawRadioItem(g As Graphics, index As Integer)
            If index < 0 OrElse index >= _items.Count OrElse index >= _itemBounds.Count Then
                Return
            End If

            Dim item As NXRadioGroupItem = _items(index)
            Dim bounds As Rectangle = _itemBounds(index)
            Dim isSelected As Boolean = (index = _selectedIndex)
            Dim isHovered As Boolean = (index = _hoveredIndex)
            Dim isEnabled As Boolean = item.Enabled AndAlso Me.Enabled

            ' Fondo hover
            If isHovered AndAlso isEnabled Then
                Using brush As New SolidBrush(Color.FromArgb(240, 240, 240))
                    g.FillRectangle(brush, bounds)
                End Using
            End If

            ' Calcular posiciones
            Dim radioX As Integer
            Dim textX As Integer
            Dim radioRect As Rectangle

            If _glyphAlignment = GlyphAlignment.Near Then
                radioX = bounds.Left + 5
                textX = radioX + _radioSize + 8
                radioRect = New Rectangle(radioX, bounds.Top + (bounds.Height - _radioSize) \ 2, _radioSize, _radioSize)
            Else
                textX = bounds.Left + 5
                radioX = bounds.Right - _radioSize - 5
                radioRect = New Rectangle(radioX, bounds.Top + (bounds.Height - _radioSize) \ 2, _radioSize, _radioSize)
            End If

            ' Dibujar radio button
            DrawRadioButton(g, radioRect, isSelected, isEnabled)

            ' Dibujar texto
            Dim textRect As New Rectangle(
                textX,
                bounds.Top,
                bounds.Width - _radioSize - 18,
                bounds.Height)

            Dim textColor As Color = If(isEnabled, Me.ForeColor, Color.FromArgb(150, 150, 150))
            TextRenderer.DrawText(g, item.Text, Me.Font, textRect,
                                textColor,
                                TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
        End Sub

        Private Sub DrawRadioButton(g As Graphics, bounds As Rectangle, isSelected As Boolean, isEnabled As Boolean)
            ' Círculo exterior
            Dim outerColor As Color = If(isEnabled,
                                        If(isSelected, _radioColor, _radioColorUnchecked),
                                        Color.FromArgb(180, 180, 180))

            Using pen As New Pen(outerColor, 2)
                g.DrawEllipse(pen, bounds)
            End Using

            ' Círculo interior (punto seleccionado)
            If isSelected Then
                Dim innerSize As Integer = CInt(bounds.Width * 0.5)
                Dim innerBounds As New Rectangle(
                    bounds.X + (bounds.Width - innerSize) \ 2,
                    bounds.Y + (bounds.Height - innerSize) \ 2,
                    innerSize, innerSize)

                Using brush As New SolidBrush(outerColor)
                    g.FillEllipse(brush, innerBounds)
                End Using
            End If
        End Sub

        Private Function GetRoundedRectangle(bounds As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            If radius <= 0 Then
                path.AddRectangle(bounds)
                Return path
            End If

            Dim diameter As Integer = radius * 2
            Dim arc As New Rectangle(bounds.Location, New Size(diameter, diameter))

            ' Esquina superior izquierda
            path.AddArc(arc, 180, 90)

            ' Esquina superior derecha
            arc.X = bounds.Right - diameter
            path.AddArc(arc, 270, 90)

            ' Esquina inferior derecha
            arc.Y = bounds.Bottom - diameter
            path.AddArc(arc, 0, 90)

            ' Esquina inferior izquierda
            arc.X = bounds.Left
            path.AddArc(arc, 90, 90)

            path.CloseFigure()
            Return path
        End Function

#End Region

#Region "Eventos de Mouse"

        Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
            MyBase.OnMouseClick(e)

            Dim index As Integer = GetItemIndexAt(e.Location)
            If index >= 0 AndAlso index < _items.Count Then
                Dim item As NXRadioGroupItem = _items(index)
                If item.Enabled AndAlso Me.Enabled Then
                    SelectedIndex = index
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            Dim newHoveredIndex As Integer = GetItemIndexAt(e.Location)
            If newHoveredIndex <> _hoveredIndex Then
                _hoveredIndex = newHoveredIndex
                Me.Invalidate()
                Me.Cursor = If(_hoveredIndex >= 0 AndAlso _items(_hoveredIndex).Enabled, Cursors.Hand, Cursors.Default)
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)

            If _hoveredIndex <> -1 Then
                _hoveredIndex = -1
                Me.Invalidate()
            End If
        End Sub

#End Region

#Region "Implementación IThemeable"

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

            Me.BackColor = theme.PanelBackColor
            Me.ForeColor = theme.ForeColor
            _borderColor = theme.BorderColor
            _radioColor = theme.PrimaryColor
            _radioColorUnchecked = theme.DisabledColor
            Me.Invalidate()
        End Sub

#End Region

#Region "Overrides"

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            CalculateLayout()
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaddingChanged(e As EventArgs)
            MyBase.OnPaddingChanged(e)
            CalculateLayout()
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnFontChanged(e As EventArgs)
            MyBase.OnFontChanged(e)
            CalculateLayout()
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            CalculateLayout()
        End Sub

        Protected Overrides Sub OnSizeChanged(e As EventArgs)
            MyBase.OnSizeChanged(e)
            CalculateLayout()
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace