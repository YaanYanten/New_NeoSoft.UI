Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' ComboBox avanzado con búsqueda, autocompletado, iconos, grupos y multi-selección
    ''' </summary>
    <ToolboxBitmap(GetType(ComboBox))>
    <Designer(GetType(NXComboBoxDesigner))>
    Public Class NXComboBox
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Estilo del dropdown
        ''' </summary>
        Public Enum DropdownStyle
            ''' <summary>Estilo simple</summary>
            Simple
            ''' <summary>Estilo moderno con sombra</summary>
            Modern
            ''' <summary>Estilo flat</summary>
            Flat
            ''' <summary>Estilo Material Design</summary>
            Material
        End Enum

        ''' <summary>
        ''' Modo de selección
        ''' </summary>
        Public Enum SelectionMode
            ''' <summary>Selección simple</summary>
            [Single]
            ''' <summary>Multi-selección con checkboxes</summary>
            MultiCheckbox
            ''' <summary>Multi-selección con Ctrl+Click</summary>
            MultiSimple
        End Enum

#End Region

#Region "Clases de Item"

        ''' <summary>
        ''' Item del ComboBox con icono, grupo y valor
        ''' </summary>
        Public Class NXComboBoxItem
            Public Property Text As String = ""
            Public Property Value As Object = Nothing
            Public Property Icon As Image = Nothing
            Public Property Group As String = ""
            Public Property Tag As Object = Nothing
            Public Property Enabled As Boolean = True
            Public Property IsSelected As Boolean = False

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

            Public Sub New(text As String, value As Object, icon As Image, group As String)
                Me.Text = text
                Me.Value = value
                Me.Icon = icon
                Me.Group = group
            End Sub

            Public Overrides Function ToString() As String
                Return Text
            End Function
        End Class

        ''' <summary>
        ''' Grupo de items
        ''' </summary>
        Public Class NXComboBoxGroup
            Public Property Name As String = ""
            Public Property Icon As Image = Nothing
            Public Property Expanded As Boolean = True

            Public Sub New()
            End Sub

            Public Sub New(name As String)
                Me.Name = name
            End Sub

            Public Sub New(name As String, icon As Image)
                Me.Name = name
                Me.Icon = icon
            End Sub
        End Class

#End Region

#Region "Dropdown Personalizado"

        Private Class NXDropdownForm
            Inherits Form

            Private _owner As NXComboBox
            Private WithEvents _listBox As ListBox
            Private WithEvents _searchBox As TextBox
            Private _groups As New Dictionary(Of String, List(Of NXComboBoxItem))

            Public Sub New(owner As NXComboBox)
                _owner = owner
                InitializeDropdown()
            End Sub

            Private Sub InitializeDropdown()
                Me.FormBorderStyle = FormBorderStyle.None
                Me.ShowInTaskbar = False
                Me.StartPosition = FormStartPosition.Manual
                Me.TopMost = True
                Me.BackColor = Color.White
                Me.Size = New Size(_owner.Width, 200)

                ' Crear searchbox si está habilitado
                If _owner._enableSearch Then
                    _searchBox = New TextBox With {
                        .Dock = DockStyle.Top,
                        .Font = New Font("Segoe UI", 9),
                        .BorderStyle = BorderStyle.None,
                        .Height = 28,
                        .BackColor = Color.FromArgb(245, 245, 245)
                    }
                    Dim searchPanel As New Panel With {
                        .Dock = DockStyle.Top,
                        .Height = 30,
                        .Padding = New Padding(5),
                        .BackColor = Color.FromArgb(245, 245, 245)
                    }
                    searchPanel.Controls.Add(_searchBox)
                    Me.Controls.Add(searchPanel)
                End If

                ' Crear listbox
                _listBox = New ListBox With {
                    .Dock = DockStyle.Fill,
                    .DrawMode = DrawMode.OwnerDrawFixed,
                    .ItemHeight = 28,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Segoe UI", 9),
                    .IntegralHeight = False
                }

                If _owner._selectionMode = SelectionMode.MultiCheckbox OrElse
                   _owner._selectionMode = SelectionMode.MultiSimple Then
                    _listBox.SelectionMode = Windows.Forms.SelectionMode.MultiExtended
                Else
                    _listBox.SelectionMode = Windows.Forms.SelectionMode.One
                End If

                Me.Controls.Add(_listBox)

                Me.SetStyle(ControlStyles.UserPaint Or
                           ControlStyles.AllPaintingInWmPaint Or
                           ControlStyles.OptimizedDoubleBuffer, True)
            End Sub

            Public Sub LoadItems()
                _listBox.Items.Clear()
                _groups.Clear()

                ' Agrupar items si tienen grupos
                Dim hasGroups As Boolean = False
                For Each item As NXComboBoxItem In _owner._items
                    If Not String.IsNullOrEmpty(item.Group) Then
                        hasGroups = True
                        If Not _groups.ContainsKey(item.Group) Then
                            _groups(item.Group) = New List(Of NXComboBoxItem)
                        End If
                        _groups(item.Group).Add(item)
                    Else
                        If Not _groups.ContainsKey("") Then
                            _groups("") = New List(Of NXComboBoxItem)
                        End If
                        _groups("").Add(item)
                    End If
                Next

                ' Agregar items al listbox
                If hasGroups Then
                    For Each group In _groups
                        If Not String.IsNullOrEmpty(group.Key) Then
                            _listBox.Items.Add($"[GROUP]{group.Key}")
                        End If
                        For Each item In group.Value
                            _listBox.Items.Add(item)
                        Next
                    Next
                Else
                    For Each item As NXComboBoxItem In _owner._items
                        _listBox.Items.Add(item)
                    Next
                End If

                ' Restaurar selección
                If _owner._selectionMode = SelectionMode.Single Then
                    If _owner._selectedIndex >= 0 AndAlso _owner._selectedIndex < _listBox.Items.Count Then
                        _listBox.SelectedIndex = _owner._selectedIndex
                    End If
                Else
                    ' Restaurar multi-selección
                    For i As Integer = 0 To _listBox.Items.Count - 1
                        Dim item = TryCast(_listBox.Items(i), NXComboBoxItem)
                        If item IsNot Nothing AndAlso item.IsSelected Then
                            _listBox.SetSelected(i, True)
                        End If
                    Next
                End If
            End Sub

            Private Sub ListBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles _listBox.DrawItem
                If e.Index < 0 Then Return

                Dim g As Graphics = e.Graphics
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                Dim item = _listBox.Items(e.Index)
                Dim isGroup As Boolean = False
                Dim groupName As String = ""

                ' Verificar si es un grupo
                If TypeOf item Is String Then
                    Dim strItem As String = item.ToString()
                    If strItem.StartsWith("[GROUP]") Then
                        isGroup = True
                        groupName = strItem.Substring(7)
                    End If
                End If

                Dim backColor As Color = Color.White
                Dim textColor As Color = Color.FromArgb(66, 66, 66)

                If isGroup Then
                    ' Dibujar grupo
                    backColor = Color.FromArgb(240, 240, 240)
                    textColor = _owner._accentColor

                    Using brush As New SolidBrush(backColor)
                        g.FillRectangle(brush, e.Bounds)
                    End Using

                    ' Dibujar línea inferior
                    Using pen As New Pen(Color.FromArgb(220, 220, 220))
                        g.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1)
                    End Using

                    ' Dibujar texto del grupo
                    Using brush As New SolidBrush(textColor)
                        Using font As New Font("Segoe UI", 8.5F, FontStyle.Bold)
                            g.DrawString(groupName.ToUpper(), font, brush, e.Bounds.Left + 10, e.Bounds.Top + 7)
                        End Using
                    End Using
                Else
                    ' Dibujar item normal
                    Dim nxItem = TryCast(item, NXComboBoxItem)
                    If nxItem Is Nothing Then Return

                    ' Color de fondo
                    If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                        backColor = Color.FromArgb(230, 244, 255)
                    End If

                    Using brush As New SolidBrush(backColor)
                        g.FillRectangle(brush, e.Bounds)
                    End Using

                    Dim xOffset As Integer = e.Bounds.Left + 10

                    ' Dibujar checkbox si multi-selección
                    If _owner._selectionMode = SelectionMode.MultiCheckbox Then
                        Dim checkRect As New Rectangle(xOffset, e.Bounds.Top + 6, 16, 16)
                        DrawCheckbox(g, checkRect, nxItem.IsSelected)
                        xOffset += 25
                    End If

                    ' Dibujar icono
                    If nxItem.Icon IsNot Nothing Then
                        g.DrawImage(nxItem.Icon, xOffset, e.Bounds.Top + 4, 20, 20)
                        xOffset += 28
                    End If

                    ' Dibujar texto
                    If Not nxItem.Enabled Then
                        textColor = Color.FromArgb(180, 180, 180)
                    End If

                    Using brush As New SolidBrush(textColor)
                        Dim textRect As New Rectangle(xOffset, e.Bounds.Top, e.Bounds.Width - xOffset, e.Bounds.Height)
                        Dim format As New StringFormat With {
                            .LineAlignment = StringAlignment.Center,
                            .Alignment = StringAlignment.Near
                        }
                        g.DrawString(nxItem.Text, e.Font, brush, textRect, format)
                    End Using
                End If

                e.DrawFocusRectangle()
            End Sub

            Private Sub DrawCheckbox(g As Graphics, rect As Rectangle, isChecked As Boolean)
                ' Dibujar fondo del checkbox
                Using brush As New SolidBrush(Color.White)
                    g.FillRectangle(brush, rect)
                End Using

                ' Dibujar borde
                Using pen As New Pen(If(isChecked, _owner._accentColor, Color.FromArgb(180, 180, 180)))
                    g.DrawRectangle(pen, rect)
                End Using

                ' Dibujar check si está marcado
                If isChecked Then
                    Using brush As New SolidBrush(_owner._accentColor)
                        Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                            g.DrawString("✓", font, brush, rect.Left + 1, rect.Top - 2)
                        End Using
                    End Using
                End If
            End Sub

            Private Sub ListBox_Click(sender As Object, e As EventArgs) Handles _listBox.Click
                If _listBox.SelectedIndex < 0 Then Return

                Dim item = _listBox.Items(_listBox.SelectedIndex)

                ' Ignorar clicks en grupos
                If TypeOf item Is String AndAlso item.ToString().StartsWith("[GROUP]") Then
                    Return
                End If

                Dim nxItem = TryCast(item, NXComboBoxItem)
                If nxItem Is Nothing OrElse Not nxItem.Enabled Then Return

                If _owner._selectionMode = SelectionMode.Single Then
                    _owner.SelectedIndex = _owner._items.IndexOf(nxItem)
                    Me.Close()
                ElseIf _owner._selectionMode = SelectionMode.MultiCheckbox Then
                    nxItem.IsSelected = Not nxItem.IsSelected
                    _listBox.Invalidate()
                    _owner.UpdateSelectedItems()
                End If
            End Sub

            Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles _searchBox.TextChanged
                FilterItems(_searchBox.Text)
            End Sub

            Private Sub FilterItems(searchText As String)
                _listBox.Items.Clear()

                If String.IsNullOrWhiteSpace(searchText) Then
                    LoadItems()
                    Return
                End If

                For Each item As NXComboBoxItem In _owner._items
                    If item.Text.ToLower().Contains(searchText.ToLower()) Then
                        _listBox.Items.Add(item)
                    End If
                Next
            End Sub

            Protected Overrides Sub OnPaint(e As PaintEventArgs)
                Dim g As Graphics = e.Graphics

                ' Dibujar borde según estilo
                Select Case _owner._dropdownStyle
                    Case DropDownStyle.Modern
                        ' Sombra
                        Using shadowBrush As New SolidBrush(Color.FromArgb(30, 0, 0, 0))
                            g.FillRectangle(shadowBrush, 2, 2, Me.Width - 4, Me.Height - 4)
                        End Using
                        ' Borde
                        Using pen As New Pen(Color.FromArgb(200, 200, 200))
                            g.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
                        End Using

                    Case DropDownStyle.Material
                        ' Sin borde, solo sombra
                        Using shadowBrush As New SolidBrush(Color.FromArgb(40, 0, 0, 0))
                            g.FillRectangle(shadowBrush, 3, 3, Me.Width - 6, Me.Height - 6)
                        End Using

                    Case Else
                        ' Simple/Flat
                        Using pen As New Pen(Color.FromArgb(180, 180, 180))
                            g.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
                        End Using
                End Select
            End Sub

            Protected Overrides Sub OnDeactivate(e As EventArgs)
                MyBase.OnDeactivate(e)
                Me.Close()
            End Sub
        End Class

#End Region

#Region "Campos Privados"

        Private _items As New List(Of NXComboBoxItem)
        Private _selectedIndex As Integer = -1
        Private _selectedItems As New List(Of NXComboBoxItem)
        Private _isDropdownOpen As Boolean = False
        Private _dropdownForm As NXDropdownForm
        Private WithEvents _textBox As TextBox

        ' Propiedades
        Private _selectionMode As SelectionMode = SelectionMode.Single
        Private _dropdownStyle As DropdownStyle = DropDownStyle.Modern
        Private _enableSearch As Boolean = True
        Private _enableAutoComplete As Boolean = True
        Private _accentColor As Color = Color.FromArgb(0, 120, 215)
        Private _borderColor As Color = Color.FromArgb(180, 180, 180)
        Private _focusBorderColor As Color = Color.FromArgb(0, 120, 215)
        Private _useTheme As Boolean = False
        Private _placeholder As String = "Seleccione una opción..."
        Private _dropdownHeight As Integer = 200

        ' Estados
        Private _isMouseOver As Boolean = False
        Private _isFocused As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            Me.Size = New Size(200, 32)
            Me.BackColor = Color.White
            Me.Font = New Font("Segoe UI", 9)

            ' Crear textbox interno con posición fija inicial
            _textBox = New TextBox With {
                .BorderStyle = BorderStyle.None,
                .Font = Me.Font,
                .BackColor = Me.BackColor,
                .ForeColor = Me.ForeColor,
                .Location = New Point(8, 8),
                .Size = New Size(165, 20)
            }
            Me.Controls.Add(_textBox)

            AddHandler _textBox.KeyDown, AddressOf TextBox_KeyDown
        End Sub

#End Region

#Region "Propiedades"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Modo de selección (Simple o Multi-selección)")>
        <DefaultValue(GetType(SelectionMode), "Single")>
        Public Property MultiSelect As SelectionMode
            Get
                Return _selectionMode
            End Get
            Set(value As SelectionMode)
                _selectionMode = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Estilo del dropdown")>
        <DefaultValue(GetType(DropdownStyle), "Modern")>
        Public Property DropDownStyl As DropdownStyle
            Get
                Return _dropdownStyle
            End Get
            Set(value As DropdownStyle)
                _dropdownStyle = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Behavior")>
        <Description("Habilitar búsqueda incremental")>
        <DefaultValue(True)>
        Public Property EnableSearch As Boolean
            Get
                Return _enableSearch
            End Get
            Set(value As Boolean)
                _enableSearch = value
            End Set
        End Property

        <Category("Behavior")>
        <Description("Habilitar autocompletado inteligente")>
        <DefaultValue(True)>
        Public Property EnableAutoComplete As Boolean
            Get
                Return _enableAutoComplete
            End Get
            Set(value As Boolean)
                _enableAutoComplete = value
                UpdateAutoComplete()
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
        <Description("Color del borde cuando tiene foco")>
        Public Property FocusBorderColor As Color
            Get
                Return _focusBorderColor
            End Get
            Set(value As Color)
                _focusBorderColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Texto placeholder")>
        <DefaultValue("Seleccione una opción...")>
        Public Property Placeholder As String
            Get
                Return _placeholder
            End Get
            Set(value As String)
                _placeholder = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Behavior")>
        <Description("Altura del dropdown")>
        <DefaultValue(200)>
        Public Property DropDownHeight As Integer
            Get
                Return _dropdownHeight
            End Get
            Set(value As Integer)
                _dropdownHeight = Math.Max(100, Math.Min(value, 400))
            End Set
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Items As List(Of NXComboBoxItem)
            Get
                Return _items
            End Get
            Set(value As List(Of NXComboBoxItem))
                _items = value
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
                If value >= -1 AndAlso value < _items.Count Then
                    _selectedIndex = value
                    UpdateTextBox()
                    Me.Invalidate()
                    RaiseEvent SelectedIndexChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedItem As NXComboBoxItem
            Get
                If _selectedIndex >= 0 AndAlso _selectedIndex < _items.Count Then
                    Return _items(_selectedIndex)
                End If
                Return Nothing
            End Get
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedItems As List(Of NXComboBoxItem)
            Get
                Return _selectedItems
            End Get
        End Property

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedValue As Object
            Get
                If SelectedItem IsNot Nothing Then
                    Return SelectedItem.Value
                End If
                Return Nothing
            End Get
            Set(value As Object)
                For i As Integer = 0 To _items.Count - 1
                    If _items(i).Value IsNot Nothing AndAlso _items(i).Value.Equals(value) Then
                        SelectedIndex = i
                        Exit For
                    End If
                Next
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

#Region "Eventos"

        Public Event SelectedIndexChanged As EventHandler
        Public Event SelectedItemsChanged As EventHandler

#End Region

#Region "Métodos Públicos"

        Public Sub AddItem(text As String)
            _items.Add(New NXComboBoxItem(text))
            Me.Invalidate()
        End Sub

        Public Sub AddItem(text As String, value As Object)
            _items.Add(New NXComboBoxItem(text, value))
            Me.Invalidate()
        End Sub

        Public Sub AddItem(item As NXComboBoxItem)
            _items.Add(item)
            Me.Invalidate()
        End Sub

        Public Sub AddItems(items As IEnumerable(Of String))
            For Each Texts In items
                _items.Add(New NXComboBoxItem(Texts))
            Next
            Me.Invalidate()
        End Sub

        Public Sub RemoveItem(index As Integer)
            If index >= 0 AndAlso index < _items.Count Then
                _items.RemoveAt(index)
                If _selectedIndex = index Then
                    _selectedIndex = -1
                    UpdateTextBox()
                End If
                Me.Invalidate()
            End If
        End Sub

        Public Sub Clear()
            _items.Clear()
            _selectedIndex = -1
            _selectedItems.Clear()
            UpdateTextBox()
            Me.Invalidate()
        End Sub

#End Region

#Region "Métodos Privados"

        Private Sub UpdateTextBox()
            If _selectionMode = SelectionMode.Single Then
                If _selectedIndex >= 0 AndAlso _selectedIndex < _items.Count Then
                    _textBox.Text = _items(_selectedIndex).Text
                    _textBox.ForeColor = Me.ForeColor
                Else
                    _textBox.Text = _placeholder
                    _textBox.ForeColor = Color.FromArgb(160, 160, 160)
                End If
            Else
                If _selectedItems.Count > 0 Then
                    _textBox.Text = String.Join(", ", _selectedItems.Select(Function(i) i.Text))
                    _textBox.ForeColor = Me.ForeColor
                Else
                    _textBox.Text = _placeholder
                    _textBox.ForeColor = Color.FromArgb(160, 160, 160)
                End If
            End If
        End Sub

        Private Sub UpdateTextBoxPosition()
            _textBox.Location = New Point(8, (Me.Height - _textBox.Height) \ 2)
            _textBox.Size = New Size(Me.Width - 35, _textBox.Height)
        End Sub

        Private Sub UpdateAutoComplete()
            If _enableAutoComplete Then
                Dim collection As New AutoCompleteStringCollection()
                For Each item In _items
                    collection.Add(item.Text)
                Next
                _textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                _textBox.AutoCompleteSource = AutoCompleteSource.CustomSource
                _textBox.AutoCompleteCustomSource = collection
            Else
                _textBox.AutoCompleteMode = AutoCompleteMode.None
            End If
        End Sub

        Friend Sub UpdateSelectedItems()
            _selectedItems.Clear()
            For Each item In _items
                If item.IsSelected Then
                    _selectedItems.Add(item)
                End If
            Next
            UpdateTextBox()
            RaiseEvent SelectedItemsChanged(Me, EventArgs.Empty)
        End Sub

        Private Sub ShowDropdown()
            If _isDropdownOpen Then Return

            _dropdownForm = New NXDropdownForm(Me)
            _dropdownForm.LoadItems()

            Dim screenPos As Point = Me.PointToScreen(New Point(0, Me.Height))
            _dropdownForm.Location = screenPos
            _dropdownForm.Width = Me.Width
            _dropdownForm.Height = _dropdownHeight

            _isDropdownOpen = True
            _dropdownForm.Show()

            AddHandler _dropdownForm.FormClosed, Sub()
                                                     _isDropdownOpen = False
                                                     Me.Invalidate()
                                                 End Sub
        End Sub

        Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
            If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Enter Then
                ShowDropdown()
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End Sub

#End Region

#Region "Eventos Override"

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            UpdateTextBoxPosition()
        End Sub

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            _isMouseOver = True
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            _isMouseOver = False
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
            MyBase.OnMouseClick(e)

            ' Verificar si se hizo click en el botón del dropdown
            Dim buttonRect As New Rectangle(Me.Width - 30, 0, 30, Me.Height)
            If buttonRect.Contains(e.Location) Then
                ShowDropdown()
            End If
        End Sub

        Protected Overrides Sub OnGotFocus(e As EventArgs)
            MyBase.OnGotFocus(e)
            _isFocused = True
            _textBox.Focus()
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnLostFocus(e As EventArgs)
            MyBase.OnLostFocus(e)
            _isFocused = False
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Dibujar fondo
            Using brush As New SolidBrush(Me.BackColor)
                g.FillRectangle(brush, Me.ClientRectangle)
            End Using

            ' Dibujar borde
            Dim borderColor As Color = _borderColor
            If _isFocused OrElse _isMouseOver Then
                borderColor = _focusBorderColor
            End If

            Using pen As New Pen(borderColor, If(_isFocused, 2, 1))
                g.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
            End Using

            ' Dibujar botón dropdown
            Dim buttonRect As New Rectangle(Me.Width - 30, 1, 29, Me.Height - 2)
            Using brush As New SolidBrush(If(_isMouseOver, Color.FromArgb(240, 240, 240), Me.BackColor))
                g.FillRectangle(brush, buttonRect)
            End Using

            ' Dibujar línea separadora
            Using pen As New Pen(Color.FromArgb(220, 220, 220))
                g.DrawLine(pen, Me.Width - 30, 5, Me.Width - 30, Me.Height - 5)
            End Using

            ' Dibujar flecha
            Dim arrowPoints() As Point = {
                New Point(Me.Width - 20, Me.Height \ 2 - 2),
                New Point(Me.Width - 15, Me.Height \ 2 + 3),
                New Point(Me.Width - 10, Me.Height \ 2 - 2)
            }
            Using pen As New Pen(Color.FromArgb(100, 100, 100), 2)
                g.DrawLines(pen, arrowPoints)
            End Using
        End Sub

#End Region

#Region "IThemeable"

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            Me.BackColor = theme.ControlBackColor
            Me.ForeColor = theme.ForeColor
            _accentColor = theme.AccentColor
            _borderColor = theme.BorderColor
            _focusBorderColor = theme.AccentColor
            _textBox.BackColor = Me.BackColor
            _textBox.ForeColor = Me.ForeColor
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace