Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Design

Namespace Controls

    ''' <summary>
    ''' Control compuesto que combina un CheckBox con un ComboBox.
    ''' El ComboBox se habilita/deshabilita según el estado del CheckBox.
    ''' </summary>
    <ToolboxBitmap(GetType(ComboBox))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DefaultEvent("CheckedChanged")>
    Public Class NXCheckComboBox
        Inherits UserControl
        Implements Theming.IThemeable

#Region "Controles Internos"

        Private WithEvents _checkBox As CheckBox
        Private WithEvents _comboBox As NXComboBox

#End Region

#Region "Campos Privados"

        Private _checkBoxWidth As Integer = 20  ' Solo el checkbox, sin texto
        Private _spacing As Integer = 4  ' Espaciado mínimo

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            ' Crear CheckBox sin texto
            _checkBox = New CheckBox()
            _checkBox.Text = ""  ' Sin texto
            _checkBox.AutoSize = False
            _checkBox.Size = New Size(_checkBoxWidth, 32)
            _checkBox.Location = New Point(0, 0)
            _checkBox.Font = New Font("Segoe UI", 9)
            _checkBox.Checked = False

            ' Crear ComboBox
            _comboBox = New NXComboBox()
            _comboBox.Location = New Point(_checkBoxWidth + _spacing, 0)
            _comboBox.Size = New Size(176, 32)  ' Más ancho al no tener checkbox con texto
            _comboBox.Enabled = False ' Inicialmente deshabilitado

            ' Agregar controles
            Me.Controls.Add(_checkBox)
            Me.Controls.Add(_comboBox)

            ' Configuración del UserControl (más compacto)
            Me.Size = New Size(_checkBoxWidth + _spacing + 176, 32)
            Me.BackColor = Color.Transparent
        End Sub

#End Region

#Region "Propiedades - CheckBox"

        ''' <summary>
        ''' Estado del CheckBox (marcado/desmarcado)
        ''' </summary>
        <Category("Behavior")>
        <NXProperty()>
        <Description("Indica si el CheckBox está marcado")>
        <DefaultValue(False)>
        Public Property Checked As Boolean
            Get
                Return _checkBox.Checked
            End Get
            Set(value As Boolean)
                _checkBox.Checked = value
            End Set
        End Property

#End Region

#Region "Propiedades - ComboBox"

        ''' <summary>
        ''' Ancho del ComboBox
        ''' </summary>
        <Category("Layout")>
        <NXProperty()>
        <Description("Ancho del ComboBox en píxeles")>
        <DefaultValue(150)>
        Public Property ComboBoxWidth As Integer
            Get
                Return _comboBox.Width
            End Get
            Set(value As Integer)
                If value < 50 Then value = 50
                _comboBox.Width = value
                UpdateLayout()
            End Set
        End Property

        ''' <summary>
        ''' Espacio entre el CheckBox y el ComboBox
        ''' </summary>
        <Category("Layout")>
        <NXProperty()>
        <Description("Espacio en píxeles entre el CheckBox y el ComboBox")>
        <DefaultValue(8)>
        Public Property Spacing As Integer
            Get
                Return _spacing
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                _spacing = value
                UpdateLayout()
            End Set
        End Property

        ''' <summary>
        ''' Colección de items del ComboBox
        ''' </summary>
        <Category("Data")>
        <NXProperty()>
        <Description("Lista de items del ComboBox")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Items As List(Of NXComboBox.NXComboBoxItem)
            Get
                Return _comboBox.Items
            End Get
        End Property

        ''' <summary>
        ''' Índice del item seleccionado
        ''' </summary>
        <Category("Data")>
        <NXProperty()>
        <Description("Índice del item seleccionado en el ComboBox")>
        <DefaultValue(-1)>
        <Browsable(False)>
        Public Property SelectedIndex As Integer
            Get
                Return _comboBox.SelectedIndex
            End Get
            Set(value As Integer)
                _comboBox.SelectedIndex = value
            End Set
        End Property

        ''' <summary>
        ''' Item seleccionado
        ''' </summary>
        <Category("Data")>
        <NXProperty()>
        <Description("Item seleccionado en el ComboBox")>
        <Browsable(False)>
        Public ReadOnly Property SelectedItem As NXComboBox.NXComboBoxItem
            Get
                Return _comboBox.SelectedItem
            End Get
        End Property

        ''' <summary>
        ''' Valor del item seleccionado
        ''' </summary>
        <Category("Data")>
        <NXProperty()>
        <Description("Valor del item seleccionado en el ComboBox")>
        <Browsable(False)>
        Public ReadOnly Property SelectedValue As Object
            Get
                Return _comboBox.SelectedValue
            End Get
        End Property

        ''' <summary>
        ''' Items seleccionados (en modo multi-selección)
        ''' </summary>
        <Category("Data")>
        <Description("Lista de items seleccionados en modo multi-selección")>
        <Browsable(False)>
        Public ReadOnly Property SelectedItems As List(Of NXComboBox.NXComboBoxItem)
            Get
                Return _comboBox.SelectedItems
            End Get
        End Property

        ''' <summary>
        ''' Modo de selección del ComboBox
        ''' </summary>
        <Category("Behavior")>
        <NXProperty()>
        <Description("Modo de selección: Single, MultiCheckbox o MultiSimple")>
        <DefaultValue(GetType(NXComboBox.SelectionMode), "Single")>
        Public Property MultiSelect As NXComboBox.SelectionMode
            Get
                Return _comboBox.MultiSelect
            End Get
            Set(value As NXComboBox.SelectionMode)
                _comboBox.MultiSelect = value
            End Set
        End Property

        ''' <summary>
        ''' Habilita búsqueda incremental en el dropdown
        ''' </summary>
        <Category("Behavior")>
        <NXProperty()>
        <Description("Habilita búsqueda incremental en el dropdown")>
        <DefaultValue(True)>
        Public Property EnableSearch As Boolean
            Get
                Return _comboBox.EnableSearch
            End Get
            Set(value As Boolean)
                _comboBox.EnableSearch = value
            End Set
        End Property

        ''' <summary>
        ''' Habilita autocompletado mientras se escribe
        ''' </summary>
        <Category("Behavior")>
        <NXProperty()>
        <Description("Habilita autocompletado mientras se escribe")>
        <DefaultValue(True)>
        Public Property EnableAutoComplete As Boolean
            Get
                Return _comboBox.EnableAutoComplete
            End Get
            Set(value As Boolean)
                _comboBox.EnableAutoComplete = value
            End Set
        End Property

        ''' <summary>
        ''' Texto del placeholder
        ''' </summary>
        <Category("Appearance")>
        <NXProperty()>
        <Description("Texto que se muestra cuando no hay selección")>
        <DefaultValue("Seleccione una opción...")>
        Public Property Placeholder As String
            Get
                Return _comboBox.Placeholder
            End Get
            Set(value As String)
                _comboBox.Placeholder = value
            End Set
        End Property

        ''' <summary>
        ''' Estilo visual del dropdown
        ''' </summary>
        <Category("Appearance")>
        <NXProperty()>
        <Description("Estilo visual del dropdown")>
        <DefaultValue(GetType(NXComboBox.NXDropdownStyle), "Modern")>
        Public Property DropDownStyle As NXComboBox.NXDropdownStyle
            Get
                Return _comboBox.DropDownStyle
            End Get
            Set(value As NXComboBox.NXDropdownStyle)
                _comboBox.DropDownStyle = value
            End Set
        End Property

        ''' <summary>
        ''' Altura del dropdown
        ''' </summary>
        <Category("Appearance")>
        <NXProperty()>
        <Description("Altura del dropdown en píxeles")>
        <DefaultValue(200)>
        Public Property DropDownHeight As Integer
            Get
                Return _comboBox.DropDownHeight
            End Get
            Set(value As Integer)
                _comboBox.DropDownHeight = value
            End Set
        End Property

        ''' <summary>
        ''' Color de acento del ComboBox
        ''' </summary>
        <Category("Appearance")>
        <NXProperty()>
        <Description("Color de acento del ComboBox")>
        Public Property AccentColor As Color
            Get
                Return _comboBox.AccentColor
            End Get
            Set(value As Color)
                _comboBox.AccentColor = value
            End Set
        End Property

        ''' <summary>
        ''' Color del borde del ComboBox
        ''' </summary>
        <Category("Appearance")>
        <NXProperty()>
        <Description("Color del borde del ComboBox")>
        Public Property BorderColor As Color
            Get
                Return _comboBox.BorderColor
            End Get
            Set(value As Color)
                _comboBox.BorderColor = value
            End Set
        End Property

        ''' <summary>
        ''' Color del borde cuando tiene el foco
        ''' </summary>
        <Category("Appearance")>
        <NXProperty()>
        <Description("Color del borde cuando tiene el foco")>
        Public Property FocusBorderColor As Color
            Get
                Return _comboBox.FocusBorderColor
            End Get
            Set(value As Color)
                _comboBox.FocusBorderColor = value
            End Set
        End Property

        ''' <summary>
        ''' Indica si el usuario puede editar el texto del ComboBox
        ''' </summary>
        <Category("Behavior")>
        <NXProperty()>
        <Description("Si es True, el usuario no puede editar el texto manualmente, pero el código sí puede modificar items")>
        <DefaultValue(False)>
        Public Property [ReadOnly] As Boolean
            Get
                Return _comboBox.ReadOnly
            End Get
            Set(value As Boolean)
                _comboBox.ReadOnly = value
            End Set
        End Property

#End Region

#Region "Eventos Públicos"

        ''' <summary>
        ''' Se dispara cuando cambia el estado del CheckBox
        ''' </summary>
        <Category("Action")>
        <Description("Se dispara cuando cambia el estado del CheckBox")>
        Public Event CheckedChanged As EventHandler

        ''' <summary>
        ''' Se dispara cuando cambia la selección del ComboBox (modo single)
        ''' </summary>
        <Category("Action")>
        <Description("Se dispara cuando cambia la selección del ComboBox")>
        Public Event SelectedIndexChanged As EventHandler

        ''' <summary>
        ''' Se dispara cuando cambian los items seleccionados (modo multi)
        ''' </summary>
        <Category("Action")>
        <Description("Se dispara cuando cambian los items seleccionados en modo multi-selección")>
        Public Event SelectedItemsChanged As EventHandler

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Agrega un item al ComboBox con solo texto
        ''' </summary>
        Public Sub AddItem(text As String)
            _comboBox.AddItem(text)
        End Sub

        ''' <summary>
        ''' Agrega un item al ComboBox con texto y valor
        ''' </summary>
        Public Sub AddItem(text As String, value As Object)
            _comboBox.AddItem(text, value)
        End Sub

        ''' <summary>
        ''' Agrega un item completo al ComboBox
        ''' </summary>
        Public Sub AddItem(item As NXComboBox.NXComboBoxItem)
            _comboBox.AddItem(item)
        End Sub

        ''' <summary>
        ''' Agrega múltiples items al ComboBox
        ''' </summary>
        Public Sub AddItems(items As List(Of NXComboBox.NXComboBoxItem))
            _comboBox.AddItems(items)
        End Sub

        ''' <summary>
        ''' Remueve un item del ComboBox por índice
        ''' </summary>
        Public Sub RemoveItem(index As Integer)
            _comboBox.RemoveItem(index)
        End Sub

        ''' <summary>
        ''' Limpia todos los items del ComboBox
        ''' </summary>
        Public Sub Clear()
            _comboBox.Clear()
        End Sub

        ''' <summary>
        ''' Selecciona un item por su valor
        ''' </summary>
        ''' <param name="value">Valor a buscar</param>
        ''' <returns>True si se encontró y seleccionó el item</returns>
        Public Function SelectByValue(value As Object) As Boolean
            If value Is Nothing Then
                SelectedIndex = -1
                Return False
            End If

            For i As Integer = 0 To Items.Count - 1
                If Items(i).Value IsNot Nothing AndAlso Items(i).Value.Equals(value) Then
                    SelectedIndex = i
                    Return True
                End If
            Next

            Return False
        End Function

        ''' <summary>
        ''' Selecciona un item por su texto
        ''' </summary>
        ''' <param name="text">Texto a buscar</param>
        ''' <param name="ignoreCase">Si True, ignora mayúsculas/minúsculas</param>
        ''' <returns>True si se encontró y seleccionó el item</returns>
        Public Function SelectByText(text As String, Optional ignoreCase As Boolean = True) As Boolean
            If String.IsNullOrEmpty(text) Then
                SelectedIndex = -1
                Return False
            End If

            Dim comparison As StringComparison = If(ignoreCase,
                                                    StringComparison.OrdinalIgnoreCase,
                                                    StringComparison.Ordinal)

            For i As Integer = 0 To Items.Count - 1
                If Items(i).Text.Equals(text, comparison) Then
                    SelectedIndex = i
                    Return True
                End If
            Next

            Return False
        End Function

        ''' <summary>
        ''' Busca un item por su valor
        ''' </summary>
        ''' <param name="value">Valor a buscar</param>
        ''' <returns>El item encontrado o Nothing</returns>
        Public Function FindByValue(value As Object) As NXComboBox.NXComboBoxItem
            If value Is Nothing Then Return Nothing

            For Each item In Items
                If item.Value IsNot Nothing AndAlso item.Value.Equals(value) Then
                    Return item
                End If
            Next

            Return Nothing
        End Function

        ''' <summary>
        ''' Busca un item por su texto
        ''' </summary>
        ''' <param name="text">Texto a buscar</param>
        ''' <param name="ignoreCase">Si True, ignora mayúsculas/minúsculas</param>
        ''' <returns>El item encontrado o Nothing</returns>
        Public Function FindByText(text As String, Optional ignoreCase As Boolean = True) As NXComboBox.NXComboBoxItem
            If String.IsNullOrEmpty(text) Then Return Nothing

            Dim comparison As StringComparison = If(ignoreCase,
                                                    StringComparison.OrdinalIgnoreCase,
                                                    StringComparison.Ordinal)

            For Each item In Items
                If item.Text.Equals(text, comparison) Then
                    Return item
                End If
            Next

            Return Nothing
        End Function

#End Region

#Region "Eventos de Controles Internos"

        Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _checkBox.CheckedChanged
            ' Habilitar/deshabilitar el ComboBox según el estado del CheckBox
            _comboBox.Enabled = _checkBox.Checked

            ' Disparar evento público
            RaiseEvent CheckedChanged(Me, EventArgs.Empty)
        End Sub

        Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _comboBox.SelectedIndexChanged
            ' Disparar evento público
            RaiseEvent SelectedIndexChanged(Me, EventArgs.Empty)
        End Sub

        Private Sub ComboBox_SelectedItemsChanged(sender As Object, e As EventArgs) Handles _comboBox.SelectedItemsChanged
            ' Disparar evento público
            RaiseEvent SelectedItemsChanged(Me, EventArgs.Empty)
        End Sub

#End Region

#Region "Layout"

        Private Sub UpdateLayout()
            _comboBox.Location = New Point(_checkBoxWidth + _spacing, 0)

            ' Actualizar ancho total del control
            Dim totalWidth As Integer = _checkBoxWidth + _spacing + _comboBox.Width
            Me.Width = totalWidth
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)

            ' Mantener altura consistente
            If Me.Height <> 32 Then
                Me.Height = 32
            End If

            ' Ajustar posiciones si el usuario cambió el ancho manualmente
            If Me.Width > _checkBoxWidth + _spacing Then
                Dim availableWidth = Me.Width - _checkBoxWidth - _spacing
                If availableWidth > 50 Then
                    _comboBox.Width = availableWidth
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

            Me.BackColor = theme.BackColor
            _checkBox.ForeColor = theme.ForeColor
            _comboBox.BackColor = theme.BackColor
            _comboBox.ForeColor = theme.ForeColor
            _comboBox.BorderColor = theme.BorderColor
            _comboBox.FocusBorderColor = theme.PrimaryColor
            _comboBox.AccentColor = theme.PrimaryColor
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace