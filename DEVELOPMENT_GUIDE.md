# Guía de Desarrollo - NeoSoft.UI

## 🎓 Conceptos Fundamentales

### ¿Qué es un Control Personalizado?

Un control personalizado en Windows Forms es una clase que:
1. Hereda de `Control` (o de otro control existente)
2. Define su propia lógica de renderizado (Paint)
3. Maneja eventos de usuario (Click, MouseMove, etc.)
4. Expone propiedades personalizables

### Jerarquía de Herencia

```
Object
  └─ MarshalByRefObject
      └─ Component
          └─ Control
              ├─ ScrollableControl
              │   └─ ContainerControl
              │       └─ UserControl
              ├─ ButtonBase
              │   └─ Button
              ├─ TextBoxBase
              │   └─ TextBox
              └─ ... (otros controles)
```

## 🏗️ Anatomía de un Control

### 1. Estructura Básica

```vb
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' [Descripción del control]
    ''' </summary>
    Public Class MiControl
        Inherits Control

        #Region "Campos Privados"
        ' Variables de instancia privadas
        Private _miPropiedad As Integer = 0
        #End Region

        #Region "Propiedades"
        ' Propiedades públicas con atributos
        <Category("Comportamiento")>
        <Description("Descripción de la propiedad")>
        <DefaultValue(0)>
        Public Property MiPropiedad As Integer
            Get
                Return _miPropiedad
            End Get
            Set(value As Integer)
                If _miPropiedad <> value Then
                    _miPropiedad = value
                    Me.Invalidate() ' Redibuja el control
                End If
            End Set
        End Property
        #End Region

        #Region "Constructor"
        Public Sub New()
            ' Configuración inicial
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer, True)
            Me.Size = New Size(100, 30)
        End Sub
        #End Region

        #Region "Métodos Protegidos (Overrides)"
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            ' Lógica de renderizado
            MyBase.OnPaint(e)
        End Sub
        #End Region

        #Region "Métodos Públicos"
        ' Métodos expuestos al usuario del control
        #End Region

        #Region "Métodos Privados"
        ' Métodos auxiliares internos
        #End Region

    End Class

End Namespace
```

### 2. ControlStyles Importantes

```vb
' Habilitar renderizado personalizado completo
Me.SetStyle(ControlStyles.UserPaint, True)

' Evitar parpadeo (doble buffer)
Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

' Todo el pintado en WM_PAINT
Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

' Soportar transparencia
Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

' Redimensionable
Me.SetStyle(ControlStyles.ResizeRedraw, True)

' Selectable con Tab
Me.SetStyle(ControlStyles.Selectable, True)
```

## 🎨 Renderizado (Painting)

### OnPaint - El Corazón del Control

```vb
Protected Overrides Sub OnPaint(e As PaintEventArgs)
    ' 1. Obtener el Graphics object
    Dim g As Graphics = e.Graphics
    
    ' 2. Configurar calidad de renderizado
    g.SmoothingMode = SmoothingMode.AntiAlias
    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
    
    ' 3. Dibujar fondo
    Using brush As New SolidBrush(Me.BackColor)
        g.FillRectangle(brush, Me.ClientRectangle)
    End Using
    
    ' 4. Dibujar contenido personalizado
    ' ... tu código aquí ...
    
    ' 5. Llamar a la implementación base
    MyBase.OnPaint(e)
End Sub
```

### Técnicas de Dibujo

#### Rectángulos con Esquinas Redondeadas
```vb
Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
    Dim path As New GraphicsPath()
    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
    path.CloseFigure()
    Return path
End Function
```

#### Gradientes
```vb
Using brush As New LinearGradientBrush(Me.ClientRectangle, Color.Blue, Color.DarkBlue, 90)
    g.FillRectangle(brush, Me.ClientRectangle)
End Using
```

#### Sombras
```vb
' Sombra difuminada
Using shadowPath As GraphicsPath = GetRoundedRectangle(shadowRect, radius)
    Using shadowBrush As New PathGradientBrush(shadowPath)
        shadowBrush.CenterColor = Color.FromArgb(50, 0, 0, 0)
        shadowBrush.SurroundColors = {Color.Transparent}
        g.FillPath(shadowBrush, shadowPath)
    End Using
End Using
```

## 🎯 Manejo de Eventos

### Eventos de Mouse

```vb
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
    If _isPressed Then
        _isPressed = False
        Me.Invalidate()
    End If
    MyBase.OnMouseUp(e)
End Sub
```

### Eventos de Teclado

```vb
Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
    Select Case e.KeyCode
        Case Keys.Enter
            ' Manejar Enter
        Case Keys.Escape
            ' Manejar Escape
    End Select
    MyBase.OnKeyDown(e)
End Sub
```

## 🔧 Propiedades Personalizadas

### Atributos Importantes

```vb
' Categoría en la ventana de Propiedades
<Category("Apariencia")>

' Descripción tooltip
<Description("Descripción de la propiedad")>

' Valor por defecto
<DefaultValue(True)>

' Editor personalizado
<Editor(GetType(MiEditor), GetType(UITypeEditor))>

' Browsable = False para ocultar
<Browsable(False)>

' Diseñador serializa el valor
<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
```

### Propiedad con Validación

```vb
Private _porcentaje As Integer = 50

<Category("Datos")>
<Description("Porcentaje de progreso (0-100)")>
<DefaultValue(50)>
Public Property Porcentaje As Integer
    Get
        Return _porcentaje
    End Get
    Set(value As Integer)
        ' Validar rango
        If value < 0 Then value = 0
        If value > 100 Then value = 100
        
        If _porcentaje <> value Then
            _porcentaje = value
            Me.Invalidate()
            
            ' Disparar evento personalizado
            RaiseEvent PorcentajeCambiado(Me, EventArgs.Empty)
        End If
    End Set
End Property

' Evento personalizado
Public Event PorcentajeCambiado As EventHandler
```

## 🎭 Diseñadores Personalizados

### Crear un ControlDesigner

```vb
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design

Namespace Designers

    Public Class MiControlDesigner
        Inherits ControlDesigner

        ' Lista de verbos (acciones en el menú contextual)
        Public Overrides ReadOnly Property Verbs As DesignerVerbCollection
            Get
                Return New DesignerVerbCollection({
                    New DesignerVerb("Cambiar a Modo A", AddressOf OnCambiarModoA),
                    New DesignerVerb("Cambiar a Modo B", AddressOf OnCambiarModoB)
                })
            End Get
        End Property

        Private Sub OnCambiarModoA(sender As Object, e As EventArgs)
            Dim ctrl As MiControl = DirectCast(Me.Control, MiControl)
            ' Cambiar propiedad
            Dim propDescriptor = TypeDescriptor.GetProperties(ctrl)("Modo")
            propDescriptor.SetValue(ctrl, ModoEnum.ModoA)
        End Sub

        Private Sub OnCambiarModoB(sender As Object, e As EventArgs)
            Dim ctrl As MiControl = DirectCast(Me.Control, MiControl)
            Dim propDescriptor = TypeDescriptor.GetProperties(ctrl)("Modo")
            propDescriptor.SetValue(ctrl, ModoEnum.ModoB)
        End Sub

    End Class

End Namespace
```

### Aplicar el Diseñador

```vb
<Designer(GetType(MiControlDesigner))>
Public Class MiControl
    Inherits Control
    ' ...
End Class
```

## 📊 Editores de Propiedades

### Editor de Color Personalizado

```vb
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Namespace Editors

    Public Class ColorPickerEditor
        Inherits UITypeEditor

        Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.DropDown
        End Function

        Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
            If provider IsNot Nothing Then
                Dim editorService = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
                
                If editorService IsNot Nothing Then
                    ' Crear un control personalizado de selección de color
                    Using colorPicker As New MiColorPicker(DirectCast(value, Color))
                        editorService.DropDownControl(colorPicker)
                        Return colorPicker.SelectedColor
                    End Using
                End If
            End If
            
            Return value
        End Function

    End Class

End Namespace
```

## 🎨 Sistema de Temas

### Estructura de Tema

```vb
Namespace Themes

    Public Class NeoTheme

        Public Property PrimaryColor As Color
        Public Property SecondaryColor As Color
        Public Property AccentColor As Color
        Public Property BackgroundColor As Color
        Public Property ForegroundColor As Color
        Public Property BorderColor As Color
        
        Public Property BorderRadius As Integer
        Public Property ShadowEnabled As Boolean
        
        ' Tema predeterminado
        Public Shared ReadOnly Property DefaultTheme As NeoTheme
            Get
                Return New NeoTheme With {
                    .PrimaryColor = Color.FromArgb(0, 120, 215),
                    .SecondaryColor = Color.FromArgb(0, 90, 158),
                    .AccentColor = Color.FromArgb(255, 185, 0),
                    .BackgroundColor = Color.White,
                    .ForegroundColor = Color.Black,
                    .BorderColor = Color.FromArgb(200, 200, 200),
                    .BorderRadius = 4,
                    .ShadowEnabled = True
                }
            End Get
        End Property
        
        ' Tema oscuro
        Public Shared ReadOnly Property DarkTheme As NeoTheme
            Get
                Return New NeoTheme With {
                    .PrimaryColor = Color.FromArgb(0, 120, 215),
                    .SecondaryColor = Color.FromArgb(0, 90, 158),
                    .AccentColor = Color.FromArgb(255, 185, 0),
                    .BackgroundColor = Color.FromArgb(32, 32, 32),
                    .ForegroundColor = Color.White,
                    .BorderColor = Color.FromArgb(60, 60, 60),
                    .BorderRadius = 4,
                    .ShadowEnabled = True
                }
            End Get
        End Property

    End Class

    ' Gestor de temas global
    Public Class ThemeManager
    
        Private Shared _currentTheme As NeoTheme = NeoTheme.DefaultTheme
        
        Public Shared Property CurrentTheme As NeoTheme
            Get
                Return _currentTheme
            End Get
            Set(value As NeoTheme)
                _currentTheme = value
                RaiseEvent ThemeChanged(Nothing, EventArgs.Empty)
            End Set
        End Property
        
        Public Shared Event ThemeChanged As EventHandler
        
    End Class

End Namespace
```

### Aplicar Tema en Control

```vb
Public Class NeoButton
    Inherits Control
    
    Public Sub New()
        ' Suscribirse a cambios de tema
        AddHandler ThemeManager.ThemeChanged, AddressOf OnThemeChanged
        ApplyTheme()
    End Sub
    
    Private Sub ApplyTheme()
        Dim theme = ThemeManager.CurrentTheme
        Me.BackColor = theme.PrimaryColor
        Me.ForeColor = theme.ForegroundColor
        Me.Invalidate()
    End Sub
    
    Private Sub OnThemeChanged(sender As Object, e As EventArgs)
        ApplyTheme()
    End Sub
    
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            RemoveHandler ThemeManager.ThemeChanged, AddressOf OnThemeChanged
        End If
        MyBase.Dispose(disposing)
    End Sub
    
End Class
```

## 🚀 Tips y Mejores Prácticas

### 1. Performance
- Usar `DoubleBuffering` para evitar parpadeo
- Cachear objetos Graphics (Pens, Brushes) cuando sea posible
- Minimizar llamadas a `Invalidate()`

### 2. Diseño
- Siempre implementar `Dispose` correctamente
- Liberar recursos no administrados (Bitmaps, Graphics objects)
- Usar `Using` statements para IDisposable

### 3. Usabilidad
- Soportar navegación con teclado (Tab, Enter, Espacio)
- Implementar tooltips informativos
- Proveer feedback visual (hover, pressed, disabled)

### 4. Accesibilidad
- Establecer propiedades de accesibilidad
```vb
Me.AccessibleName = "Mi Control"
Me.AccessibleDescription = "Descripción del control"
Me.AccessibleRole = AccessibleRole.PushButton
```

### 5. Documentación
- Usar comentarios XML para IntelliSense
- Documentar todas las propiedades públicas
- Incluir ejemplos de uso

```vb
''' <summary>
''' Representa un botón personalizado con efectos visuales mejorados
''' </summary>
''' <remarks>
''' Este control soporta esquinas redondeadas, sombras y animaciones.
''' </remarks>
''' <example>
''' <code>
''' Dim btn As New NeoButton()
''' btn.Text = "Click Me"
''' btn.BorderRadius = 10
''' Me.Controls.Add(btn)
''' </code>
''' </example>
Public Class NeoButton
```

## 📦 Deployment

### Firma Digital (Strong Name)

1. Crear par de claves:
```bash
sn -k NeoSoft.UI.snk
```

2. Agregar al proyecto:
```xml
<PropertyGroup>
    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>NeoSoft.UI.snk</AssemblyOriginatorKeyFile>
</PropertyGroup>
```

### Versioning

```vb
<Assembly: AssemblyVersion("1.0.0.0")>        ' Versión de ensamblado
<Assembly: AssemblyFileVersion("1.0.0.0")>    ' Versión de archivo
<Assembly: AssemblyInformationalVersion("1.0.0-beta")> ' Versión informativa
```

---

**¡Listo para crear controles increíbles!** 🎉
