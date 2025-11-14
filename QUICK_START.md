# 🚀 Guía de Inicio Rápido - NeoSoft.UI

## 📦 Lo que acabas de recibir

Has recibido una solución completa con:
- **NeoSoft.UI** - Proyecto biblioteca (genera la DLL)
- **NeoSoft.UI.TestApp** - Aplicación de prueba
- Documentación completa
- Estructura profesional lista para usar

## 🔧 Primeros Pasos

### 1. Abrir el Proyecto

1. Descomprime `NeoSoft.UI.zip` en tu ubicación preferida
2. Abre `NeoSoft.UI.sln` con Visual Studio 2017 o superior
3. Visual Studio cargará ambos proyectos

### 2. Compilar la Biblioteca

**Opción A: Compilación Rápida**
- Presiona `Ctrl + Shift + B` para compilar toda la solución
- La DLL se generará en `NeoSoft.UI\bin\Debug\NeoSoft.UI.dll`

**Opción B: Compilación Release**
1. Cambia el modo de compilación a "Release" (menú superior)
2. Clic derecho en `NeoSoft.UI` → Compilar
3. La DLL optimizada estará en `NeoSoft.UI\bin\Release\NeoSoft.UI.dll`

### 3. Probar la Biblioteca

1. Establece `NeoSoft.UI.TestApp` como proyecto de inicio
   - Clic derecho en el proyecto → "Establecer como proyecto de inicio"
2. Presiona `F5` para ejecutar
3. Se abrirá una ventana de prueba vacía

## 🎨 Crear tu Primer Control

### Paso 1: Crear Clase del Control

1. En el proyecto `NeoSoft.UI`, clic derecho en carpeta `Controls`
2. Agregar → Nuevo elemento → Clase
3. Nombrar: `NeoButton.vb`

```vb
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' Botón personalizado con esquinas redondeadas
    ''' </summary>
    <ToolboxBitmap(GetType(Button))>
    Public Class NeoButton
        Inherits Control

        #Region "Campos Privados"
        Private _borderRadius As Integer = 8
        Private _isHovered As Boolean = False
        Private _isPressed As Boolean = False
        #End Region

        #Region "Propiedades"

        <Category("Apariencia")>
        <Description("Radio de las esquinas redondeadas")>
        <DefaultValue(8)>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                _borderRadius = value
                Me.Invalidate()
            End Set
        End Property

        #End Region

        #Region "Constructor"

        Public Sub New()
            ' Configurar estilos para renderizado óptimo
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            ' Configuración inicial
            Me.Size = New Size(120, 40)
            Me.BackColor = Color.FromArgb(0, 120, 215)
            Me.ForeColor = Color.White
            Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            Me.Cursor = Cursors.Hand
        End Sub

        #End Region

        #Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Determinar color según estado
            Dim buttonColor As Color = Me.BackColor
            If Not Me.Enabled Then
                buttonColor = Color.FromArgb(150, buttonColor)
            ElseIf _isPressed Then
                buttonColor = ControlPaint.Dark(buttonColor, 0.2F)
            ElseIf _isHovered Then
                buttonColor = ControlPaint.Light(buttonColor, 0.2F)
            End If

            ' Dibujar botón con esquinas redondeadas
            Using path As GraphicsPath = GetRoundedRectangle(Me.ClientRectangle, _borderRadius)
                ' Fondo
                Using brush As New SolidBrush(buttonColor)
                    g.FillPath(brush, path)
                End Using

                ' Borde sutil
                Using pen As New Pen(ControlPaint.Dark(buttonColor, 0.3F), 1)
                    g.DrawPath(pen, path)
                End Using
            End Using

            ' Dibujar texto centrado
            Dim textColor As Color = If(Me.Enabled, Me.ForeColor, Color.FromArgb(150, Me.ForeColor))
            TextRenderer.DrawText(g, Me.Text, Me.Font, Me.ClientRectangle,
                                textColor,
                                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

            MyBase.OnPaint(e)
        End Sub

        Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            
            ' Ajustar si el radio es muy grande
            If radius > rect.Height / 2 Then radius = rect.Height / 2
            If radius > rect.Width / 2 Then radius = rect.Width / 2
            
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90)
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90)
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
            path.CloseFigure()
            
            Return path
        End Function

        #End Region

        #Region "Eventos de Mouse"

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            _isHovered = True
            Me.Invalidate()
            MyBase.OnMouseEnter(e)
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            _isHovered = False
            _isPressed = False
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
            _isPressed = False
            Me.Invalidate()
            MyBase.OnMouseUp(e)
        End Sub

        #End Region

    End Class

End Namespace
```

### Paso 2: Actualizar el .vbproj

Abre `NeoSoft.UI.vbproj` y dentro de `<ItemGroup>` donde están los `<Compile>`, agrega:

```xml
<Compile Include="Controls\NeoButton.vb">
  <SubType>Component</SubType>
</Compile>
```

### Paso 3: Compilar

1. Compila el proyecto `NeoSoft.UI` (Clic derecho → Compilar)
2. ¡Tu primer control está listo!

### Paso 4: Probar el Control

#### Opción A: Desde el Toolbox (Automático)

Cuando compiles `NeoSoft.UI.TestApp`, el control aparecerá automáticamente en el Toolbox porque está referenciado.

#### Opción B: Agregar Manualmente al Toolbox

1. Clic derecho en el Toolbox → "Elegir elementos..."
2. Pestaña "Componentes de .NET Framework"
3. Examinar → Seleccionar `NeoSoft.UI.dll`
4. Marcar `NeoButton` → Aceptar

#### Opción C: Crear Mediante Código

Edita `FormMain.vb`:

```vb
Imports NeoSoft.UI.Controls

Public Class FormMain

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "NeoSoft.UI - Aplicación de Prueba"
        
        ' Crear botón programáticamente
        Dim btn As New NeoButton()
        btn.Text = "¡Haz Click!"
        btn.Size = New Size(150, 45)
        btn.Location = New Point(50, 50)
        btn.BorderRadius = 12
        
        ' Agregar evento
        AddHandler btn.Click, AddressOf Btn_Click
        
        ' Agregar al formulario
        Me.Controls.Add(btn)
        
        ' Crear segundo botón con estilo diferente
        Dim btn2 As New NeoButton()
        btn2.Text = "Botón Secundario"
        btn2.Size = New Size(150, 45)
        btn2.Location = New Point(50, 110)
        btn2.BackColor = Color.FromArgb(76, 175, 80) ' Verde
        btn2.BorderRadius = 20
        Me.Controls.Add(btn2)
    End Sub

    Private Sub Btn_Click(sender As Object, e As EventArgs)
        MessageBox.Show("¡Control NeoSoft.UI funcionando!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
```

### Paso 5: Ejecutar

1. Presiona `F5`
2. ¡Verás tus botones personalizados en acción!

## 📚 Próximos Controles Recomendados

Una vez que domines el botón básico, puedes crear:

1. **NeoTextBox** - TextBox con borde redondeado y placeholder
2. **NeoPanel** - Panel con sombra y gradiente
3. **NeoProgressBar** - Barra de progreso animada
4. **NeoToggleSwitch** - Interruptor tipo iOS/Android
5. **NeoCard** - Contenedor tipo tarjeta con sombra
6. **NeoLabel** - Label con efectos de texto
7. **NeoComboBox** - ComboBox con estilo personalizado
8. **NeoCheckBox** - CheckBox con animación

## 🔧 Uso en Otros Proyectos

### Para usar NeoSoft.UI en un nuevo proyecto:

1. **Copiar la DLL**:
   - Copia `NeoSoft.UI.dll` desde `bin\Release\`
   - Pégala en una carpeta de tu nuevo proyecto (ej: `Libs\`)

2. **Agregar Referencia**:
   - En tu nuevo proyecto: Clic derecho en "Referencias" → "Agregar referencia"
   - Pestaña "Examinar" → Selecciona `NeoSoft.UI.dll`

3. **Usar los Controles**:
   ```vb
   Imports NeoSoft.UI.Controls
   
   ' Luego úsalos como cualquier control
   Dim btn As New NeoButton()
   ```

## 🎯 Consejos Importantes

### ✅ Hacer (Do's)

- ✅ Compila en modo Release para distribución
- ✅ Usa regiones para organizar tu código
- ✅ Documenta con comentarios XML
- ✅ Prueba en diferentes resoluciones y DPI
- ✅ Implementa `Dispose` correctamente
- ✅ Usa `Using` para objetos IDisposable

### ❌ Evitar (Don'ts)

- ❌ No olvides llamar a `Invalidate()` después de cambiar propiedades visuales
- ❌ No crees objetos Graphics, Pen o Brush sin liberarlos
- ❌ No hagas operaciones pesadas en el método `OnPaint`
- ❌ No modifiques propiedades del control desde threads externos sin `Invoke`

## 🐛 Solución de Problemas

### El control no aparece en el Toolbox
- Asegúrate de que el proyecto `NeoSoft.UI` esté compilado
- Verifica que `NeoSoft.UI.TestApp` tenga la referencia al proyecto
- Reconstruye la solución (`Ctrl + Shift + B`)

### Error de compilación "No se encuentra el tipo"
- Verifica que el archivo esté incluido en el .vbproj
- Asegúrate de que el namespace sea correcto
- Limpia y reconstruye la solución

### El control se ve mal o parpadea
- Verifica que `DoubleBuffering` esté habilitado
- Usa `SetStyle` con `OptimizedDoubleBuffer`
- Asegúrate de llamar a `MyBase.OnPaint(e)` al final

## 📖 Recursos Adicionales

- **README.md** - Visión general del proyecto
- **DEVELOPMENT_GUIDE.md** - Guía completa de desarrollo
- **Código de ejemplo** - Revisa `NeoButton.vb` creado arriba

## 🎉 ¡Felicidades!

Ya tienes tu propia biblioteca de controles funcionando. A partir de aquí, ¡el cielo es el límite!

Puedes crear:
- Controles más complejos
- Temas dinámicos
- Animaciones avanzadas
- Efectos visuales
- Y mucho más...

---

**¿Dudas? ¿Necesitas ayuda?** Solo pregunta y te ayudaré a resolver cualquier problema.

¡Mucho éxito con NeoSoft.UI! 🚀
