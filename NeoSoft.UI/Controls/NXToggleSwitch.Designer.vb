Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace Controls

    Partial Public Class NXToggleSwitch

        ''' <summary>
        ''' Designer para NXToggleSwitch con Smart Tag
        ''' </summary>
        <System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
        Friend Class NXToggleSwitchDesigner
            Inherits System.Windows.Forms.Design.ControlDesigner

            Private _actionLists As DesignerActionListCollection

            Public Overrides ReadOnly Property ActionLists As DesignerActionListCollection
                Get
                    If _actionLists Is Nothing Then
                        _actionLists = New DesignerActionListCollection()
                        _actionLists.Add(New NXToggleSwitchActionList(Me.Component))
                    End If
                    Return _actionLists
                End Get
            End Property

            Public Overrides Sub InitializeNewComponent(defaultValues As System.Collections.IDictionary)
                MyBase.InitializeNewComponent(defaultValues)

                Dim toggle As NXToggleSwitch = TryCast(Me.Control, NXToggleSwitch)
                If toggle IsNot Nothing Then
                    ' Configuración inicial del designer
                    toggle.SwitchSize = NXToggleSwitch.ToggleSize.Medium
                    toggle.UseAnimation = True
                End If
            End Sub

            ' CRÍTICO: Prevenir el repaint múltiple en tiempo de diseño
            Protected Overrides Sub OnPaintAdornments(pe As PaintEventArgs)
                ' No hacer nada - esto previene el renderizado múltiple
                ' MyBase.OnPaintAdornments(pe) <- comentado intencionalmente
            End Sub
        End Class

        ''' <summary>
        ''' Smart Tag para NXToggleSwitch
        ''' </summary>
        Friend Class NXToggleSwitchActionList
            Inherits DesignerActionList

            Private _toggle As NXToggleSwitch

            Public Sub New(component As IComponent)
                MyBase.New(component)
                _toggle = TryCast(component, NXToggleSwitch)
            End Sub

#Region "Propiedades del Smart Tag"

            <Category("Estado")>
            <DisplayName("Estado Activado (IsOn)")>
            <Description("Activa o desactiva el switch")>
            Public Property IsOn As Boolean
                Get
                    Return _toggle.IsOn
                End Get
                Set(value As Boolean)
                    SetProperty("IsOn", value)
                End Set
            End Property

            <Category("Apariencia")>
            <DisplayName("Tamaño del Switch")>
            <Description("Tamaño predefinido del switch")>
            Public Property SwitchSize As NXToggleSwitch.ToggleSize
                Get
                    Return _toggle.SwitchSize
                End Get
                Set(value As NXToggleSwitch.ToggleSize)
                    SetProperty("SwitchSize", value)
                End Set
            End Property

            <Category("Apariencia")>
            <DisplayName("Mostrar Texto")>
            <Description("Muestra el texto del estado")>
            Public Property ShowText As Boolean
                Get
                    Return _toggle.ShowText
                End Get
                Set(value As Boolean)
                    SetProperty("ShowText", value)
                End Set
            End Property

            <Category("Apariencia")>
            <DisplayName("Alineación del Texto")>
            <Description("Posición del texto dentro del control")>
            Public Property TextAlignment As NXToggleSwitch.TextAlign
                Get
                    Return _toggle.TextAlignment
                End Get
                Set(value As NXToggleSwitch.TextAlign)
                    SetProperty("TextAlignment", value)
                End Set
            End Property

            <Category("Apariencia")>
            <DisplayName("Posición del Switch (GlyphAlignment)")>
            <Description("Posición del switch dentro del control")>
            Public Property GlyphAlignment As NXToggleSwitch.SwitchAlignment
                Get
                    Return _toggle.GlyphAlignment
                End Get
                Set(value As NXToggleSwitch.SwitchAlignment)
                    SetProperty("GlyphAlignment", value)
                End Set
            End Property

            <Category("Colores")>
            <DisplayName("Color Activado (ON)")>
            <Description("Color cuando está activado")>
            Public Property OnColor As Color
                Get
                    Return _toggle.OnColor
                End Get
                Set(value As Color)
                    SetProperty("OnColor", value)
                End Set
            End Property

            <Category("Colores")>
            <DisplayName("Color Desactivado (OFF)")>
            <Description("Color cuando está desactivado")>
            Public Property OffColor As Color
                Get
                    Return _toggle.OffColor
                End Get
                Set(value As Color)
                    SetProperty("OffColor", value)
                End Set
            End Property

            <Category("Animación")>
            <DisplayName("Usar Animación")>
            <Description("Habilita animaciones suaves")>
            Public Property UseAnimation As Boolean
                Get
                    Return _toggle.UseAnimation
                End Get
                Set(value As Boolean)
                    SetProperty("UseAnimation", value)
                End Set
            End Property

            <Category("Tema")>
            <DisplayName("Usar Tema")>
            <Description("Aplica el tema global automáticamente")>
            Public Property UseTheme As Boolean
                Get
                    Return _toggle.UseTheme
                End Get
                Set(value As Boolean)
                    SetProperty("UseTheme", value)
                End Set
            End Property

#End Region

            Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
                Dim items As New DesignerActionItemCollection()

                ' Encabezados y propiedades
                items.Add(New DesignerActionHeaderItem("Estado"))
                items.Add(New DesignerActionPropertyItem("IsOn", "Estado Activado (IsOn)", "Estado",
                         "Activa o desactiva el switch"))

                items.Add(New DesignerActionHeaderItem("Apariencia"))
                items.Add(New DesignerActionPropertyItem("SwitchSize", "Tamaño del Switch", "Apariencia",
                         "Tamaño predefinido del switch"))
                items.Add(New DesignerActionPropertyItem("ShowText", "Mostrar Texto", "Apariencia",
                         "Muestra el texto del estado"))
                items.Add(New DesignerActionPropertyItem("GlyphAlignment", "Posición del Switch", "Apariencia",
                         "Posición del switch: Near, Center, Far"))
                items.Add(New DesignerActionPropertyItem("TextAlignment", "Alineación del Texto", "Apariencia",
                         "Posición del texto: Left, Center, Right"))

                items.Add(New DesignerActionHeaderItem("Colores"))
                items.Add(New DesignerActionPropertyItem("OnColor", "Color Activado (ON)", "Colores",
                         "Color cuando está activado"))
                items.Add(New DesignerActionPropertyItem("OffColor", "Color Desactivado (OFF)", "Colores",
                         "Color cuando está desactivado"))

                items.Add(New DesignerActionHeaderItem("Animación"))
                items.Add(New DesignerActionPropertyItem("UseAnimation", "Usar Animación", "Animación",
                         "Habilita animaciones suaves"))

                items.Add(New DesignerActionHeaderItem("Tema"))
                items.Add(New DesignerActionPropertyItem("UseTheme", "Usar Tema", "Tema",
                         "Aplica el tema global automáticamente"))

                ' Métodos de acción
                items.Add(New DesignerActionHeaderItem("Acciones"))
                items.Add(New DesignerActionMethodItem(Me, "ToggleState",
                         "Cambiar Estado", "Acciones",
                         "Cambia el estado actual del switch", True))
                items.Add(New DesignerActionMethodItem(Me, "ResetColors",
                         "Restablecer Colores", "Acciones",
                         "Restablece los colores a los valores predeterminados", True))

                Return items
            End Function

#Region "Métodos de Acción"

            Public Sub ToggleState()
                SetProperty("IsOn", Not _toggle.IsOn)
            End Sub

            Public Sub ResetColors()
                SetProperty("OnColor", Color.FromArgb(0, 120, 215))
                SetProperty("OffColor", Color.FromArgb(200, 200, 200))
                SetProperty("ThumbColor", Color.White)
                SetProperty("BorderColor", Color.FromArgb(180, 180, 180))
            End Sub

#End Region

            Private Sub SetProperty(propertyName As String, value As Object)
                Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(_toggle)(propertyName)
                If prop IsNot Nothing Then
                    prop.SetValue(_toggle, value)
                End If
            End Sub

        End Class

    End Class

End Namespace