Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports NeoSoft.UI.Controls

Namespace Design

    ''' <summary>
    ''' Designer para NXComboBox con Smart Tags
    ''' </summary>
    Friend Class NXComboBoxDesigner
        Inherits ControlDesigner

        Private _actionLists As DesignerActionListCollection

        Public Overrides ReadOnly Property ActionLists As DesignerActionListCollection
            Get
                If _actionLists Is Nothing Then
                    _actionLists = New DesignerActionListCollection()
                    _actionLists.Add(New NXComboBoxActionList(Me.Component))
                End If
                Return _actionLists
            End Get
        End Property

    End Class

    ''' <summary>
    ''' Smart Tags para NXComboBox
    ''' </summary>
    Friend Class NXComboBoxActionList
        Inherits DesignerActionList

        Private _comboBox As NXComboBox

        Public Sub New(component As IComponent)
            MyBase.New(component)
            _comboBox = TryCast(component, NXComboBox)
        End Sub

        Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection()

            ' Propiedades
            items.Add(New DesignerActionHeaderItem("Configuración"))
            items.Add(New DesignerActionPropertyItem("MultiSelect", "Modo de Selección", "Configuración"))
            items.Add(New DesignerActionPropertyItem("DropDownStyle", "Estilo Dropdown", "Configuración"))
            items.Add(New DesignerActionPropertyItem("EnableSearch", "Habilitar Búsqueda", "Configuración"))
            items.Add(New DesignerActionPropertyItem("EnableAutoComplete", "Autocompletado", "Configuración"))

            items.Add(New DesignerActionHeaderItem("Apariencia"))
            items.Add(New DesignerActionPropertyItem("AccentColor", "Color Acento", "Apariencia"))
            items.Add(New DesignerActionPropertyItem("BorderColor", "Color Borde", "Apariencia"))

            ' Métodos
            items.Add(New DesignerActionHeaderItem("Acciones"))
            items.Add(New DesignerActionMethodItem(Me, "AddSampleItems", "Agregar Items de Ejemplo", "Acciones", True))
            items.Add(New DesignerActionMethodItem(Me, "ClearItems", "Limpiar Items", "Acciones", True))

            Return items
        End Function

        ' Propiedades para Smart Tags
        Public Property MultiSelect As NXComboBox.SelectionMode
            Get
                Return _comboBox.MultiSelect
            End Get
            Set(value As NXComboBox.SelectionMode)
                GetPropertyByName("MultiSelect").SetValue(_comboBox, value)
            End Set
        End Property

        Public Property DropDownStyle As NXComboBox.NXDropdownStyle
            Get
                Return _comboBox.DropDownStyle
            End Get
            Set(value As NXComboBox.NXDropdownStyle)
                GetPropertyByName("DropDownStyle").SetValue(_comboBox, value)
            End Set
        End Property

        Public Property EnableSearch As Boolean
            Get
                Return _comboBox.EnableSearch
            End Get
            Set(value As Boolean)
                GetPropertyByName("EnableSearch").SetValue(_comboBox, value)
            End Set
        End Property

        Public Property EnableAutoComplete As Boolean
            Get
                Return _comboBox.EnableAutoComplete
            End Get
            Set(value As Boolean)
                GetPropertyByName("EnableAutoComplete").SetValue(_comboBox, value)
            End Set
        End Property

        Public Property AccentColor As Color
            Get
                Return _comboBox.AccentColor
            End Get
            Set(value As Color)
                GetPropertyByName("AccentColor").SetValue(_comboBox, value)
            End Set
        End Property

        Public Property BorderColor As Color
            Get
                Return _comboBox.BorderColor
            End Get
            Set(value As Color)
                GetPropertyByName("BorderColor").SetValue(_comboBox, value)
            End Set
        End Property

        ' Métodos de acción
        Public Sub AddSampleItems()
            _comboBox.Clear()
            _comboBox.AddItem("Opción 1")
            _comboBox.AddItem("Opción 2")
            _comboBox.AddItem("Opción 3")
            _comboBox.AddItem("Opción 4")
            _comboBox.AddItem("Opción 5")
        End Sub

        Public Sub ClearItems()
            _comboBox.Clear()
        End Sub

        Private Function GetPropertyByName(propName As String) As PropertyDescriptor
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(_comboBox)(propName)
            If prop Is Nothing Then
                Throw New ArgumentException($"Property {propName} not found", propName)
            End If
            Return prop
        End Function

    End Class

End Namespace