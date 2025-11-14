# NeoSoft.UI - Biblioteca de Controles Personalizados

Biblioteca profesional de controles de Windows Forms desarrollada en VB.NET, diseñada para crear interfaces modernas y funcionales similares a DevExpress.

## 📋 Información del Proyecto

- **Framework**: .NET Framework 4.7.2
- **Lenguaje**: Visual Basic .NET
- **Tipo**: Class Library (DLL)
- **Compatibilidad**: Windows Forms Applications

## 🏗️ Estructura del Proyecto

```
NeoSoft.UI/
│
├── NeoSoft.UI/                          # Biblioteca principal (genera DLL)
│   ├── Controls/                        # Controles visuales personalizados
│   ├── Components/                      # Componentes no visuales
│   ├── Designers/                       # Diseñadores personalizados
│   ├── Editors/                         # Editores de propiedades
│   ├── Themes/                          # Sistema de temas y estilos
│   ├── Common/                          # Utilidades y clases base
│   ├── Resources/                       # Recursos embebidos (iconos, imágenes)
│   └── My Project/                      # Configuración del proyecto
│
├── NeoSoft.UI.TestApp/                  # Aplicación de prueba
│   ├── Forms/                           # Formularios de prueba
│   └── My Project/                      # Configuración del proyecto
│
└── NeoSoft.UI.sln                       # Archivo de solución
```

## 🎯 Propósito de cada Carpeta

### NeoSoft.UI (Biblioteca Principal)

#### `/Controls`
- Controles visuales personalizados que heredan de controles base de Windows Forms
- Ejemplos: Botones personalizados, TextBox mejorados, Paneles con efectos, etc.
- Cada control debe tener su propio archivo .vb

#### `/Components`
- Componentes no visuales (aparecen en la bandeja de componentes)
- Ejemplos: Timers personalizados, Proveedores de datos, Servicios, etc.
- Heredan de `Component` en lugar de `Control`

#### `/Designers`
- Diseñadores personalizados para controles
- Mejoran la experiencia de diseño en Visual Studio
- Implementan `ControlDesigner` o `ComponentDesigner`

#### `/Editors`
- Editores de propiedades personalizados
- Aparecen en la ventana de Propiedades de Visual Studio
- Implementan `UITypeEditor`

#### `/Themes`
- Sistema de temas y paletas de colores
- Gestión de estilos globales
- Clases para cambiar apariencia de controles dinámicamente

#### `/Common`
- Clases base compartidas
- Utilidades y helpers
- Enumeraciones y constantes
- Clases de extensión

#### `/Resources`
- Iconos, imágenes y recursos embebidos
- Archivos .resx para localización
- Recursos binarios

## 🔧 Cómo Funciona la Generación de DLL

### Compilación

1. **Debug Mode**:
   - Genera `NeoSoft.UI.dll` en `bin\Debug\`
   - Incluye símbolos de depuración (.pdb)
   - No está optimizada

2. **Release Mode**:
   - Genera `NeoSoft.UI.dll` en `bin\Release\`
   - Código optimizado
   - Lista para distribución

### Uso de la DLL en Otros Proyectos

#### Método 1: Referencia Directa
```
1. Clic derecho en el proyecto → Agregar → Referencia
2. Examinar → Seleccionar NeoSoft.UI.dll
3. Los controles aparecen automáticamente en el Toolbox
```

#### Método 2: Copiar al GAC (Global Assembly Cache)
```bash
gacutil /i NeoSoft.UI.dll
```

#### Método 3: NuGet Package (Avanzado)
Crear un paquete NuGet para distribución profesional.

## 🎨 Ejemplo de Creación de un Control

```vb
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace Controls

    ''' <summary>
    ''' Botón personalizado con esquinas redondeadas y efectos de hover
    ''' </summary>
    <ToolboxBitmap(GetType(NeoButton), "NeoButton.bmp")>
    Public Class NeoButton
        Inherits Control

        #Region "Propiedades"

        Private _borderRadius As Integer = 10
        
        <Category("Apariencia")>
        <Description("Radio de las esquinas redondeadas")>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                _borderRadius = value
                Me.Invalidate()
            End Set
        End Property

        #End Region

        #Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer, True)
            Me.Size = New Size(150, 40)
        End Sub

        #End Region

        #Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            
            ' Dibujar el botón con esquinas redondeadas
            Using path As New GraphicsPath()
                path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90)
                path.AddArc(Me.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90)
                path.AddArc(Me.Width - _borderRadius, Me.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90)
                path.AddArc(0, Me.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90)
                path.CloseFigure()
                
                Using brush As New SolidBrush(Me.BackColor)
                    e.Graphics.FillPath(brush, path)
                End Using
            End Using
            
            ' Dibujar texto
            TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, Me.ClientRectangle,
                                Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            
            MyBase.OnPaint(e)
        End Sub

        #End Region

    End Class

End Namespace
```

## 🚀 Ventajas de Usar VB.NET

1. **Compatibilidad Total**: La DLL generada es 100% compatible con proyectos C# y VB.NET
2. **Interoperabilidad**: El código compilado es IL (Intermediate Language), independiente del lenguaje fuente
3. **Diseñador Visual**: Funciona perfectamente en el diseñador de Visual Studio
4. **IntelliSense**: Documentación XML se exporta y funciona en cualquier proyecto .NET

## 📦 Distribución

### Opción 1: DLL Simple
- Copiar `NeoSoft.UI.dll` al proyecto destino
- Agregar como referencia

### Opción 2: NuGet Package
```xml
<!-- Archivo .nuspec -->
<?xml version="1.0"?>
<package>
  <metadata>
    <id>NeoSoft.UI</id>
    <version>1.0.0</version>
    <authors>NeoSoft</authors>
    <description>Biblioteca de controles personalizados para Windows Forms</description>
  </metadata>
  <files>
    <file src="bin\Release\NeoSoft.UI.dll" target="lib\net472" />
  </files>
</package>
```

### Opción 3: Instalador
Crear un instalador MSI que:
- Copie la DLL a una ubicación estándar
- Registre en el GAC (opcional)
- Agregue entradas en el Toolbox de Visual Studio

## 🔍 Depuración

Para depurar la biblioteca mientras desarrollas:

1. Establece `NeoSoft.UI.TestApp` como proyecto de inicio
2. Coloca breakpoints en el código de `NeoSoft.UI`
3. Los breakpoints funcionarán durante la ejecución de TestApp

## 📝 Convenciones de Código

- **Prefijos**: Usar "Neo" para todos los controles (NeoButton, NeoPanel, etc.)
- **Regiones**: Organizar código en regiones (#Region)
- **Comentarios XML**: Documentar todas las clases y miembros públicos
- **Propiedades**: Usar atributos `Category` y `Description`

## 🎯 Próximos Pasos

1. Crear controles básicos (Botón, TextBox, Panel)
2. Implementar sistema de temas
3. Agregar diseñadores personalizados
4. Crear editores de propiedades avanzados
5. Documentación completa
6. Ejemplos de uso

## 📄 Licencia

Copyright © 2024 NeoSoft. Todos los derechos reservados.

---

**Desarrollado con ❤️ en VB.NET**
