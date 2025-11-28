Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' ListBox avanzado con virtualización, checkboxes, iconos, drag&drop y búsqueda
    ''' </summary>
    <ToolboxBitmap(GetType(ListBox))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DefaultEvent("SelectedIndexChanged")>
    Public Class NXListBox
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Modo de selección del ListBox
        ''' </summary>
        Public Enum SelectionModeType
            ''' <summary>Sin selección</summary>
            None
            ''' <summary>Selección simple</summary>
            [Single]
            ''' <summary>Multi-selección con checkboxes</summary>
            MultiCheckbox
            ''' <summary>Multi-selección extendida (Ctrl/Shift)</summary>
            MultiExtended
        End Enum

        ''' <summary>
        ''' Estilo de visualización
        ''' </summary>
        Public Enum ViewStyle
            ''' <summary>Lista simple</summary>
            List
            ''' <summary>Lista con detalles (sub-items)</summary>
            Details
            ''' <summary>Iconos grandes</summary>
            LargeIcon
            ''' <summary>Iconos pequeños</summary>
            SmallIcon
        End Enum

#End Region

#Region "Clases de Item"

        ''' <summary>
        ''' Item del ListBox con soporte para iconos, sub-items y datos
        ''' </summary>
        Public Class NXListBoxItem
            Public Property Text As String = ""
            Public Property Value As Object = Nothing
            Public Property Icon As Image = Nothing
            Public Property SubItems As New List(Of String)
            Public Property Tag As Object = Nothing
            Public Property ForeColor As Color = Color.Empty
            Public Property BackColor As Color = Color.Empty
            Public Property Font As Font = Nothing
            Public Property IsChecked As Boolean = False
            Public Property IsSelected As Boolean = False
            Public Property Enabled As Boolean = True

            Public Sub New()
            End Sub

            Public Sub New(text As String)
                Me.Text = text
                Me.Value = text
            End Sub

            Public Sub New(text As String, value As Object)
                Me.Text = text
                Me.Value = value
            End Sub

            Public Sub New(text As String, value As Object, icon As Image)
                Me.Text = text
                Me.Value = value
                Me.Icon = icon
            End Sub

            Public Overrides Function ToString() As String
                Return Text
            End Function
        End Class

#End Region

#Region "Campos Privados"

        Private _items As New List(Of NXListBoxItem)
        Private _selectedItems As New List(Of NXListBoxItem)
        Private _selectedIndex As Integer = -1
        Private _checkedItems As New List(Of NXListBoxItem)

        ' Virtualización
        Private _firstVisibleIndex As Integer = 0
        Private _visibleItemCount As Integer = 0
        Private WithEvents _vScrollBar As VScrollBar

        ' Búsqueda
        Private WithEvents _searchBox As TextBox
        Private _filteredItems As List(Of NXListBoxItem)
        Private _searchEnabled As Boolean = True

        ' Drag & Drop
        Private _dragDropEnabled As Boolean = False
        Private _dragStartIndex As Integer = -1
        Private _dragOverIndex As Integer = -1

        ' Propiedades visuales
        Private _selectionMode As SelectionModeType = SelectionModeType.Single
        Private _viewStyle As ViewStyle = ViewStyle.List
        Private _itemHeight As Integer = 32
        Private _iconSize As Size = New Size(24, 24)
        Private _showCheckboxes As Boolean = False
        Private _alternateRowColors As Boolean = True
        Private _alternateColor1 As Color = Color.White
        Private _alternateColor2 As Color = Color.FromArgb(250, 250, 250)

        ' Colores y tema
        Private _accentColor As Color = Color.FromArgb(0, 120, 215)
        Private _borderColor As Color = Color.FromArgb(180, 180, 180)
        Private _selectionColor As Color = Color.FromArgb(230, 244, 255)
        Private _hoverColor As Color = Color.FromArgb(240, 248, 255)
        Private _useTheme As Boolean = False

        ' Estados
        Private _hoveredIndex As Integer = -1
        Private _isMouseOver As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.Selectable Or
                       ControlStyles.SupportsTransparentBackColor, True)

            Me.Size = New Size(250, 300)
            Me.BackColor = Color.White
            Me.Font = New Font("Segoe UI", 9)

            InitializeScrollBar()
            InitializeSearchBox()

            _filteredItems = _items
        End Sub

        Private Sub InitializeScrollBar()
            _vScrollBar = New VScrollBar With {
                .Dock = DockStyle.Right,
                .Width = 18,
                .Visible = False
            }
            Me.Controls.Add(_vScrollBar)
        End Sub

        Private Sub InitializeSearchBox()
            _searchBox = New TextBox With {
                .Dock = DockStyle.Top,
                .Height = 28,
                .BorderStyle = BorderStyle.None,
                .Font = New Font("Segoe UI", 9),
                .Visible = _searchEnabled,
                .BackColor = Color.FromArgb(245, 245, 245)
            }

            Dim searchPanel As New Panel With {
                .Dock = DockStyle.Top,
                .Height = 30,
                .Padding = New Padding(5),
                .BackColor = Color.FromArgb(245, 245, 245),
                .Visible = _searchEnabled
            }
            searchPanel.Controls.Add(_searchBox)
            Me.Controls.Add(searchPanel)
        End Sub

#End Region

#Region "Propiedades - Comportamiento"

        <Category("Behavior")>
        <NXProperty()>
        <Description("Modo de selección del ListBox")>
        <DefaultValue(GetType(SelectionModeType), "Single")>
        Public Property SelectionMode As SelectionModeType
            Get
                Return _selectionMode
            End Get
            Set(value As SelectionModeType)
                _selectionMode = value
                _showCheckboxes = (value = SelectionModeType.MultiCheckbox)
                Me.Invalidate()
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Habilitar búsqueda integrada")>
        <DefaultValue(True)>
        Public Property EnableSearch As Boolean
            Get
                Return _searchEnabled
            End Get
            Set(value As Boolean)
                _searchEnabled = value
                _searchBox.Parent.Visible = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Behavior")>
        <NXProperty()>
        <Description("Habilitar arrastrar y soltar items")>
        <DefaultValue(False)>
        Public Property EnableDragDrop As Boolean
            Get
                Return _dragDropEnabled
            End Get
            Set(value As Boolean)
                _dragDropEnabled = value
                Me.AllowDrop = value
            End Set
        End Property

#End Region

#Region "Propiedades - Apariencia"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo de visualización")>
        <DefaultValue(GetType(ViewStyle), "List")>
        Public Property View As ViewStyle
            Get
                Return _viewStyle
            End Get
            Set(value As ViewStyle)
                _viewStyle = value
                CalculateItemHeight()
                UpdateScrollBar()
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Altura de cada item en píxeles")>
        <DefaultValue(32)>
        Public Property ItemHeight As Integer
            Get
                Return _itemHeight
            End Get
            Set(value As Integer)
                _itemHeight = Math.Max(20, Math.Min(value, 100))
                UpdateScrollBar()
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Tamaño de los iconos")>
        Public Property IconSize As Size
            Get
                Return _iconSize
            End Get
            Set(value As Size)
                _iconSize = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Mostrar checkboxes en los items")>
        <DefaultValue(False)>
        Public Property ShowCheckboxes As Boolean
            Get
                Return _showCheckboxes
            End Get
            Set(value As Boolean)
                _showCheckboxes = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Alternar colores de filas")>
        <DefaultValue(True)>
        Public Property AlternateRowColors As Boolean
            Get
                Return _alternateRowColors
            End Get
            Set(value As Boolean)
                _alternateRowColors = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color principal para filas alternadas")>
        Public Property AlternateColor1 As Color
            Get
                Return _alternateColor1
            End Get
            Set(value As Color)
                _alternateColor1 = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color secundario para filas alternadas")>
        Public Property AlternateColor2 As Color
            Get
                Return _alternateColor2
            End Get
            Set(value As Color)
                _alternateColor2 = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de acento")>
        Public Property AccentColor As Color
            Get
                Return _accentColor
            End Get
            Set(value As Color)
                _accentColor = value
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
        <Description("Color de selección")>
        Public Property SelectionColor As Color
            Get
                Return _selectionColor
            End Get
            Set(value As Color)
                _selectionColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color de hover")>
        Public Property HoverColor As Color
            Get
                Return _hoverColor
            End Get
            Set(value As Color)
                _hoverColor = value
                Me.Invalidate()
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
                If value Then ApplyTheme(NXThemeManager.Instance.CurrentTheme)
            End Set
        End Property

#End Region

#Region "Propiedades - Datos"

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Items As List(Of NXListBoxItem)
            Get
                Return _items
            End Get
            Set(value As List(Of NXListBoxItem))
                _items = value
                _filteredItems = _items
                UpdateScrollBar()
                Me.Invalidate()
            End Set
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedIndex As Integer
            Get
                Return _selectedIndex
            End Get
            Set(value As Integer)
                If value >= -1 AndAlso value < _filteredItems.Count Then
                    ClearSelection()
                    _selectedIndex = value
                    If value >= 0 Then
                        _filteredItems(value).IsSelected = True
                        _selectedItems.Add(_filteredItems(value))
                        EnsureVisible(value)
                    End If
                    Me.Invalidate()
                    RaiseEvent SelectedIndexChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedItem As NXListBoxItem
            Get
                If _selectedIndex >= 0 AndAlso _selectedIndex < _filteredItems.Count Then
                    Return _filteredItems(_selectedIndex)
                End If
                Return Nothing
            End Get
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedItems As List(Of NXListBoxItem)
            Get
                Return _selectedItems
            End Get
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property CheckedItems As List(Of NXListBoxItem)
            Get
                Return _checkedItems
            End Get
        End Property

#End Region

#Region "Eventos"

        Public Event SelectedIndexChanged As EventHandler
        Public Event ItemCheck As EventHandler(Of ItemCheckEventArgs)
        Public Event ItemDrag As EventHandler(Of ItemDragEventArgs)

        Public Class ItemCheckEventArgs
            Inherits EventArgs

            Public Property Item As NXListBoxItem
            Public Property NewCheckState As Boolean
            Public Property Cancel As Boolean = False
        End Class

        Public Class ItemDragEventArgs
            Inherits EventArgs

            Public Property Item As NXListBoxItem
            Public Property SourceIndex As Integer
            Public Property TargetIndex As Integer
        End Class

#End Region

#Region "Métodos Públicos - Gestión de Items"

        Public Sub AddItem(text As String)
            Dim item As New NXListBoxItem(text)
            _items.Add(item)
            ApplyFilter()
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub AddItem(text As String, value As Object)
            Dim item As New NXListBoxItem(text, value)
            _items.Add(item)
            ApplyFilter()
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub AddItem(text As String, value As Object, icon As Image)
            Dim item As New NXListBoxItem(text, value, icon)
            _items.Add(item)
            ApplyFilter()
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub AddItem(item As NXListBoxItem)
            _items.Add(item)
            ApplyFilter()
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub AddItems(items As IEnumerable(Of String))
            For Each Texts In items
                _items.Add(New NXListBoxItem(Texts))
            Next
            ApplyFilter()
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub RemoveItem(index As Integer)
            If index >= 0 AndAlso index < _items.Count Then
                _items.RemoveAt(index)
                ApplyFilter()
                UpdateScrollBar()
                Me.Invalidate()
            End If
        End Sub

        Public Sub RemoveItem(item As NXListBoxItem)
            _items.Remove(item)
            ApplyFilter()
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub Clear()
            _items.Clear()
            _filteredItems.Clear()
            _selectedItems.Clear()
            _checkedItems.Clear()
            _selectedIndex = -1
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

        Public Sub ClearSelection()
            For Each item In _filteredItems
                item.IsSelected = False
            Next
            _selectedItems.Clear()
            _selectedIndex = -1
            Me.Invalidate()
        End Sub

#End Region

#Region "Métodos Privados - Virtualización"

        Private Sub CalculateItemHeight()
            Select Case _viewStyle
                Case ViewStyle.List
                    _itemHeight = 32
                Case ViewStyle.Details
                    _itemHeight = 40
                Case ViewStyle.LargeIcon
                    _itemHeight = 80
                Case ViewStyle.SmallIcon
                    _itemHeight = 28
            End Select
        End Sub

        Private Sub UpdateScrollBar()
            Dim contentHeight = _filteredItems.Count * _itemHeight
            Dim availableHeight = GetAvailableHeight()

            _visibleItemCount = Math.Max(1, availableHeight \ _itemHeight)

            If contentHeight > availableHeight Then
                _vScrollBar.Visible = True
                _vScrollBar.Maximum = _filteredItems.Count - 1
                _vScrollBar.LargeChange = _visibleItemCount
                _vScrollBar.SmallChange = 1
            Else
                _vScrollBar.Visible = False
                _firstVisibleIndex = 0
            End If
        End Sub

        Private Function GetAvailableHeight() As Integer
            Dim height = Me.ClientSize.Height - 2 ' Borde
            If _searchEnabled Then height -= 30 ' SearchBox
            Return height
        End Function

        Private Sub EnsureVisible(index As Integer)
            If index < _firstVisibleIndex Then
                _firstVisibleIndex = index
                _vScrollBar.Value = _firstVisibleIndex
            ElseIf index >= _firstVisibleIndex + _visibleItemCount Then
                _firstVisibleIndex = index - _visibleItemCount + 1
                _vScrollBar.Value = Math.Max(0, _firstVisibleIndex)
            End If
            Me.Invalidate()
        End Sub

#End Region

#Region "Métodos Privados - Búsqueda"

        Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles _searchBox.TextChanged
            ApplyFilter()
        End Sub

        Private Sub ApplyFilter()
            If String.IsNullOrWhiteSpace(_searchBox.Text) Then
                _filteredItems = _items
            Else
                Dim searchText = _searchBox.Text.ToLower()
                _filteredItems = _items.Where(Function(item) item.Text.ToLower().Contains(searchText)).ToList()
            End If

            _firstVisibleIndex = 0
            UpdateScrollBar()
            Me.Invalidate()
        End Sub

#End Region

#Region "Eventos de ScrollBar"

        Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles _vScrollBar.Scroll
            _firstVisibleIndex = _vScrollBar.Value
            Me.Invalidate()
        End Sub

#End Region

#Region "Eventos Override - Mouse"

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            Dim index = GetItemIndexFromPoint(e.Location)
            If index <> _hoveredIndex Then
                _hoveredIndex = index
                Me.Invalidate()
            End If

            ' Drag & Drop
            If _dragDropEnabled AndAlso e.Button = MouseButtons.Left AndAlso _dragStartIndex >= 0 Then
                _dragOverIndex = index
                Me.Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            Dim index = GetItemIndexFromPoint(e.Location)
            If index < 0 OrElse index >= _filteredItems.Count Then Return

            Dim item = _filteredItems(index)

            ' Checkbox click
            If _showCheckboxes AndAlso IsCheckboxClick(e.Location, index) Then
                Dim args As New ItemCheckEventArgs With {
                    .Item = item,
                    .NewCheckState = Not item.IsChecked
                }
                RaiseEvent ItemCheck(Me, args)

                If Not args.Cancel Then
                    item.IsChecked = args.NewCheckState
                    If item.IsChecked Then
                        If Not _checkedItems.Contains(item) Then _checkedItems.Add(item)
                    Else
                        _checkedItems.Remove(item)
                    End If
                    Me.Invalidate()
                End If
                Return
            End If

            ' Selección
            Select Case _selectionMode
                Case SelectionModeType.Single
                    SelectedIndex = index

                Case SelectionModeType.MultiExtended
                    If ModifierKeys = Keys.Control Then
                        item.IsSelected = Not item.IsSelected
                        If item.IsSelected Then
                            _selectedItems.Add(item)
                        Else
                            _selectedItems.Remove(item)
                        End If
                    ElseIf ModifierKeys = Keys.Shift AndAlso _selectedIndex >= 0 Then
                        ClearSelection()
                        Dim start = Math.Min(_selectedIndex, index)
                        Dim [end] = Math.Max(_selectedIndex, index)
                        For i = start To [end]
                            _filteredItems(i).IsSelected = True
                            _selectedItems.Add(_filteredItems(i))
                        Next
                    Else
                        SelectedIndex = index
                    End If
            End Select

            ' Drag & Drop
            If _dragDropEnabled Then
                _dragStartIndex = index
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)

            ' Completar Drag & Drop
            If _dragDropEnabled AndAlso _dragStartIndex >= 0 AndAlso _dragOverIndex >= 0 AndAlso _dragStartIndex <> _dragOverIndex Then
                Dim item = _filteredItems(_dragStartIndex)
                _filteredItems.RemoveAt(_dragStartIndex)
                _filteredItems.Insert(_dragOverIndex, item)

                RaiseEvent ItemDrag(Me, New ItemDragEventArgs With {
                    .Item = item,
                    .SourceIndex = _dragStartIndex,
                    .TargetIndex = _dragOverIndex
                })

                Me.Invalidate()
            End If

            _dragStartIndex = -1
            _dragOverIndex = -1
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            _hoveredIndex = -1
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
            MyBase.OnMouseWheel(e)

            If _vScrollBar.Visible Then
                Dim newValue = _vScrollBar.Value - (e.Delta \ 120)
                newValue = Math.Max(_vScrollBar.Minimum, Math.Min(_vScrollBar.Maximum - _vScrollBar.LargeChange + 1, newValue))

                ' Actualizar tanto el ScrollBar como el índice visible
                _vScrollBar.Value = newValue
                _firstVisibleIndex = newValue

                ' Redibujar el control para mostrar los nuevos items
                Me.Invalidate()
            End If
        End Sub

#End Region

#Region "Métodos Auxiliares"

        Private Function GetItemIndexFromPoint(location As Point) As Integer
            Dim yOffset = If(_searchEnabled, 30, 0)
            Dim y = location.Y - yOffset - 1

            If y < 0 Then Return -1

            Dim index = _firstVisibleIndex + (y \ _itemHeight)
            If index >= 0 AndAlso index < _filteredItems.Count Then
                Return index
            End If

            Return -1
        End Function

        Private Function IsCheckboxClick(location As Point, index As Integer) As Boolean
            If Not _showCheckboxes Then Return False

            Dim itemRect = GetItemRectangle(index)
            Dim checkRect As New Rectangle(itemRect.Left + 10, itemRect.Top + (itemRect.Height - 16) \ 2, 16, 16)

            Return checkRect.Contains(location)
        End Function

        Private Function GetItemRectangle(index As Integer) As Rectangle
            Dim yOffset = If(_searchEnabled, 30, 0)
            Dim y = yOffset + 1 + ((index - _firstVisibleIndex) * _itemHeight)
            Dim width = Me.ClientSize.Width - (If(_vScrollBar.Visible, _vScrollBar.Width, 0)) - 2

            Return New Rectangle(1, y, width, _itemHeight)
        End Function

#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Fondo
            Using brush As New SolidBrush(Me.BackColor)
                g.FillRectangle(brush, Me.ClientRectangle)
            End Using

            ' Items virtualizados
            Dim lastVisibleIndex = Math.Min(_firstVisibleIndex + _visibleItemCount, _filteredItems.Count)
            For i = _firstVisibleIndex To lastVisibleIndex - 1
                DrawItem(g, i, _filteredItems(i))
            Next

            ' Borde
            Using pen As New Pen(_borderColor)
                g.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
            End Using
        End Sub

        Private Sub DrawItem(g As Graphics, index As Integer, item As NXListBoxItem)
            Dim itemRect = GetItemRectangle(index)

            ' Fondo
            Dim backColor = item.BackColor
            If backColor = Color.Empty Then
                If item.IsSelected Then
                    backColor = _selectionColor
                ElseIf index = _hoveredIndex Then
                    backColor = _hoverColor
                ElseIf _alternateRowColors Then
                    backColor = If(index Mod 2 = 0, _alternateColor1, _alternateColor2)
                Else
                    backColor = Me.BackColor
                End If
            End If

            Using brush As New SolidBrush(backColor)
                g.FillRectangle(brush, itemRect)
            End Using

            ' Indicador de drag
            If _dragDropEnabled AndAlso index = _dragOverIndex AndAlso _dragStartIndex >= 0 Then
                Using pen As New Pen(_accentColor, 2)
                    g.DrawLine(pen, itemRect.Left, itemRect.Top, itemRect.Right, itemRect.Top)
                End Using
            End If

            Dim xOffset = itemRect.Left + 10

            ' Checkbox
            If _showCheckboxes Then
                Dim checkRect As New Rectangle(xOffset, itemRect.Top + (itemRect.Height - 16) \ 2, 16, 16)
                DrawCheckbox(g, checkRect, item.IsChecked)
                xOffset += 25
            End If

            ' Icono
            If item.Icon IsNot Nothing Then
                Dim iconRect As New Rectangle(xOffset, itemRect.Top + (itemRect.Height - _iconSize.Height) \ 2, _iconSize.Width, _iconSize.Height)
                g.DrawImage(item.Icon, iconRect)
                xOffset += _iconSize.Width + 8
            End If

            ' Texto
            Dim textColor = If(item.ForeColor <> Color.Empty, item.ForeColor, Me.ForeColor)
            If Not item.Enabled Then textColor = Color.FromArgb(180, 180, 180)

            Using brush As New SolidBrush(textColor)
                Dim textFont = If(item.Font, Me.Font)
                Dim textRect As New Rectangle(xOffset, itemRect.Top, itemRect.Width - (xOffset - itemRect.Left), itemRect.Height)
                Dim format As New StringFormat With {
                    .LineAlignment = StringAlignment.Center,
                    .Alignment = StringAlignment.Near,
                    .Trimming = StringTrimming.EllipsisCharacter
                }

                g.DrawString(item.Text, textFont, brush, textRect, format)

                ' Sub-items (solo en modo Details)
                If _viewStyle = ViewStyle.Details AndAlso item.SubItems.Count > 0 Then
                    Dim subY = itemRect.Top + (itemRect.Height \ 2) + 2
                    Dim subFont As New Font(textFont.FontFamily, textFont.Size - 1)
                    Dim subColor = Color.FromArgb(128, textColor)
                    Using subBrush As New SolidBrush(subColor)
                        Dim subText = String.Join(" • ", item.SubItems)
                        g.DrawString(subText, subFont, subBrush, xOffset, subY)
                    End Using
                    subFont.Dispose()
                End If
            End Using
        End Sub

        Private Sub DrawCheckbox(g As Graphics, rect As Rectangle, isChecked As Boolean)
            ' Fondo
            Using brush As New SolidBrush(Color.White)
                g.FillRectangle(brush, rect)
            End Using

            ' Borde
            Using pen As New Pen(If(isChecked, _accentColor, Color.FromArgb(180, 180, 180)))
                g.DrawRectangle(pen, rect)
            End Using

            ' Check
            If isChecked Then
                Using brush As New SolidBrush(_accentColor)
                    Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                        Dim format As New StringFormat With {
                            .Alignment = StringAlignment.Center,
                            .LineAlignment = StringAlignment.Center
                        }
                        g.DrawString("✓", font, brush, rect, format)
                    End Using
                End Using
            End If
        End Sub

#End Region

#Region "IThemeable"

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            Me.BackColor = theme.ControlBackColor
            Me.ForeColor = theme.ForeColor
            _accentColor = theme.AccentColor
            _borderColor = theme.BorderColor
            _selectionColor = Color.FromArgb(230, theme.AccentColor.R, theme.AccentColor.G, theme.AccentColor.B)
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace