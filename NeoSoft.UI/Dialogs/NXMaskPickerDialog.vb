Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Diálogo para selección de máscaras de entrada de datos
''' Soporta constructores para filtrar por categoría (Numeric, String, etc.)
''' </summary>
Partial Public Class NXMaskPickerDialog
    Inherits Form

#Region "Enumeraciones"

    Public Enum MaskType
        None
        DateOnly
        DateTime
        DateTimeWithOffset
        ExtendedRegularExpression
        Numeric
        Simple
        SimplifiedRegularExpression
        TimeOnly
        TimeSpan
    End Enum

    ''' <summary>
    ''' Categorías de máscaras disponibles
    ''' </summary>
    Public Enum MaskCategory
        All         ' Todas las categorías
        Numeric     ' Solo máscaras numéricas
        [String]    ' Solo máscaras de texto/string
        DateTime    ' Solo máscaras de fecha/hora
        Phone       ' Solo máscaras de teléfono
        Custom      ' Personalizado (especificar lista)
    End Enum

#End Region

#Region "Campos Privados"

    Private _selectedMask As String = ""
    Private _selectedMaskType As MaskType = MaskType.None
    Private _selectedMaskDescription As String = ""
    Private _filterCategory As MaskCategory = MaskCategory.All
    Private _allowedTypes As New List(Of String)

#End Region

#Region "Propiedades Públicas"

    Public ReadOnly Property SelectedMask As String
        Get
            Return _selectedMask
        End Get
    End Property

    Public ReadOnly Property SelectedMaskType As MaskType
        Get
            Return _selectedMaskType
        End Get
    End Property

    Public ReadOnly Property SelectedMaskDescription As String
        Get
            Return _selectedMaskDescription
        End Get
    End Property

#End Region

#Region "Constructores"

    ''' <summary>
    ''' Constructor por defecto - Muestra TODAS las categorías de máscaras
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        _filterCategory = MaskCategory.All
        InitializeDialog()
    End Sub

    ''' <summary>
    ''' Constructor con categoría específica - Filtra por categoría
    ''' </summary>
    ''' <param name="category">Categoría a mostrar (Numeric, String, DateTime, etc.)</param>
    Public Sub New(category As MaskCategory)
        InitializeComponent()
        _filterCategory = category

        ' Configurar tipos permitidos según la categoría
        Select Case category
            Case MaskCategory.Numeric
                _allowedTypes.Add("Numeric")

            Case MaskCategory.String
                _allowedTypes.Add("Simple")
                _allowedTypes.Add("Extended Regular Expression")
                _allowedTypes.Add("Simplified Regular Expression")

            Case MaskCategory.DateTime
                _allowedTypes.Add("DateOnly")
                _allowedTypes.Add("DateTime")
                _allowedTypes.Add("DateTime with Offset")
                _allowedTypes.Add("TimeOnly")
                _allowedTypes.Add("TimeSpan")

            Case MaskCategory.Phone
                _allowedTypes.Add("Simple")
                _allowedTypes.Add("Extended Regular Expression")

            Case MaskCategory.All
                ' No hay filtro

        End Select

        InitializeDialog()
    End Sub

    ''' <summary>
    ''' Constructor con lista personalizada de tipos
    ''' </summary>
    ''' <param name="allowedTypes">Lista de tipos permitidos (ej: {"Numeric", "Simple"})</param>
    Public Sub New(allowedTypes As List(Of String))
        InitializeComponent()
        _filterCategory = MaskCategory.Custom
        _allowedTypes = If(allowedTypes, New List(Of String))
        InitializeDialog()
    End Sub

#End Region

#Region "Inicialización"

    Private Sub InitializeDialog()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.Size = New Size(760, 550)

        ' Configurar título según la categoría
        Select Case _filterCategory
            Case MaskCategory.Numeric
                Me.Text = "Mask Settings - Numeric Only"
            Case MaskCategory.String
                Me.Text = "Mask Settings - String Only"
            Case MaskCategory.DateTime
                Me.Text = "Mask Settings - Date/Time Only"
            Case MaskCategory.Phone
                Me.Text = "Mask Settings - Phone Only"
            Case Else
                Me.Text = "Mask Settings"
        End Select

        ' Cargar tipos de máscaras (filtrados si es necesario)
        LoadMaskTypes()

        ' ⭐ IMPORTANTE: Si solo hay un tipo, cargar las máscaras inmediatamente
        If _allowedTypes.Count = 1 Then
            ' Cargar máscaras para el tipo único
            LoadMasksForType(_allowedTypes(0))
            ConfigureSingleCategoryMode()
        Else
            ' Cargar máscaras predefinidas (vacías)
            LoadPredefinedMasks()
        End If
    End Sub

    ''' <summary>
    ''' Configura el diálogo cuando solo hay una categoría disponible
    ''' </summary>
    Private Sub ConfigureSingleCategoryMode()
        If lstMaskType Is Nothing Then Return

        ' Ocultar el ListBox de tipos
        If lblMaskType IsNot Nothing Then
            lblMaskType.Visible = False
        End If
        lstMaskType.Visible = False

        ' Ajustar layout - expandir el área de máscaras
        If lstMasks IsNot Nothing Then
            Dim originalTop As Integer = lstMasks.Top
            lstMasks.Top = If(lblMasks IsNot Nothing, lblMasks.Bottom + 10, 20)
            lstMasks.Height = lstMasks.Height + (originalTop - lstMasks.Top)
        End If

        ' Actualizar descripción según la categoría
        If lblDescription IsNot Nothing Then
            Select Case _filterCategory
                Case MaskCategory.Numeric
                    lblDescription.Text = "Máscaras numéricas para entrada de datos. Seleccione una máscara predefinida o ingrese una personalizada."
                Case MaskCategory.String
                    lblDescription.Text = "Máscaras de texto para entrada de datos. Seleccione una máscara predefinida o ingrese una personalizada."
                Case MaskCategory.DateTime
                    lblDescription.Text = "Máscaras de fecha y hora para entrada de datos. Seleccione una máscara predefinida."
            End Select
        End If
    End Sub

#End Region

#Region "Carga de Datos"

    Private Sub LoadMaskTypes()
        If lstMaskType Is Nothing Then Return

        lstMaskType.Items.Clear()

        If _filterCategory = MaskCategory.All Then
            ' Cargar TODOS los tipos
            lstMaskType.Items.Add("(None)")
            lstMaskType.Items.Add("DateOnly")
            lstMaskType.Items.Add("DateTime")
            lstMaskType.Items.Add("DateTime with Offset")
            lstMaskType.Items.Add("Extended Regular Expression")
            lstMaskType.Items.Add("Numeric")
            lstMaskType.Items.Add("Simple")
            lstMaskType.Items.Add("Simplified Regular Expression")
            lstMaskType.Items.Add("TimeOnly")
            lstMaskType.Items.Add("TimeSpan")
            lstMaskType.SelectedIndex = 0
        Else
            ' Cargar solo los tipos permitidos
            For Each allowedType As String In _allowedTypes
                lstMaskType.Items.Add(allowedType)
            Next

            ' Seleccionar el primero automáticamente
            If lstMaskType.Items.Count > 0 Then
                lstMaskType.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub LoadPredefinedMasks()
        If lstMasks Is Nothing Then Return
        lstMasks.Items.Clear()
    End Sub

    Private Sub LoadMasksForType(maskType As String)
        If lstMasks Is Nothing Then Return

        lstMasks.Items.Clear()

        Select Case maskType
            Case "DateOnly"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000", .Description = "Fecha corta (DD/MM/AAAA)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-00-00", .Description = "Fecha ISO 8601 (AAAA-MM-DD)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/L00/0000", .Description = "Día mes año con letra"})

            Case "DateTime"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00", .Description = "Fecha y hora corta"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00:00", .Description = "Fecha y hora larga"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-00-00 00:00:00", .Description = "DateTime ISO 8601"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00 AA", .Description = "Fecha hora con AM/PM"})

            Case "DateTime with Offset"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00 +00:00", .Description = "Fecha hora con offset"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-00-00T00:00:00+00:00", .Description = "ISO 8601 con zona horaria"})

            Case "Extended Regular Expression"
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 0000-0000", .Description = "Número telefónico USA"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "+00 (000) 0000-0000", .Description = "Teléfono internacional"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "(999) 000-00-00", .Description = "Teléfono con código opcional"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Número de seguro social"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Código ZIP corto"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Código ZIP largo"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000.000.000.000", .Description = "Dirección IPv4"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Hora del día (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00 AA", .Description = "Hora con designador AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "LLLLLL", .Description = "Solo letras (6 caracteres)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = ">LLLLLL", .Description = "Letras mayúsculas (6 caracteres)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "<llllll", .Description = "Letras minúsculas (6 caracteres)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = ">L<LLLLL", .Description = "Title case (primera mayúscula)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "LLL-0000", .Description = "Código alfanumérico (ABC-1234)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "CCCCCCCCCC", .Description = "Cualquier carácter (10 posiciones)"})

            Case "Numeric"
                ' ⭐ MÁSCARAS NUMÉRICAS ESPECÍFICAS PARA NXNUMERICUPDOWN
                lstMasks.Items.Add(New MaskItem With {.Mask = "", .Description = "Ninguna (entrada numérica libre)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000", .Description = "3 dígitos (ej: 123)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000", .Description = "4 dígitos (ej: 1234, PIN, año)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "5 dígitos (ej: 12345, ZIP)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000000", .Description = "6 dígitos (ej: 123456, PIN largo)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 0000-0000", .Description = "Teléfono USA (###) ###-####"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "+00 (000) 000-0000", .Description = "Teléfono internacional"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Código ZIP extendido"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Número de seguro social"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000 0000 0000 0000", .Description = "Número de tarjeta de crédito"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-0000-0000-0000", .Description = "Número de cuenta (con guiones)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000", .Description = "CVV (3 dígitos)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000", .Description = "CVV extendido (4 dígitos)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Hora en formato HH:MM (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00", .Description = "Hora completa HH:MM:SS"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000", .Description = "Fecha numérica DD/MM/AAAA"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000.000.000.000", .Description = "Dirección IPv4"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Puerto de red (1-65535)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-000-000", .Description = "Número de serie (###-###-###)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "##.##", .Description = "Decimal con 2 lugares (opcional)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000,000", .Description = "Miles con separador de coma"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000,000.00", .Description = "Formato de moneda (sin símbolo)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "999,999.99", .Description = "Número con decimales opcionales"})

            Case "Simple"
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 000-0000", .Description = "Número telefónico simple"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Número de seguro social"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Código ZIP"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Código ZIP + 4"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000", .Description = "Fecha corta"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Hora corta (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "AA-0000", .Description = "Código de producto"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "AAA-000", .Description = "Código alfanumérico simple"})

            Case "Simplified Regular Expression"
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 0000-0000", .Description = "Número telefónico"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Número de seguro social"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Código ZIP corto"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Código ZIP largo"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/00", .Description = "Fecha corta (MM/DD/AA)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Hora corta"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00 AA", .Description = "Hora larga con AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Extensión"})

            Case "TimeOnly"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Hora corta (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00", .Description = "Hora larga (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00 AA", .Description = "Hora corta con AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00 AA", .Description = "Hora larga con AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "90:00", .Description = "Hora con primer dígito opcional"})

            Case "TimeSpan"
                lstMasks.Items.Add(New MaskItem With {.Mask = "0:00:00", .Description = "Horas:Minutos:Segundos"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00", .Description = "Formato de horas fijo"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000:00:00", .Description = "Formato de horas extendido"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0.00:00:00", .Description = "Días.Horas:Minutos:Segundos"})

        End Select
    End Sub

#End Region

#Region "Eventos - Mask Type"

    Private Sub LstMaskType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMaskType.SelectedIndexChanged
        If lstMaskType.SelectedIndex < 0 Then Return

        Dim selectedType As String = lstMaskType.SelectedItem.ToString()

        If selectedType = "(None)" Then
            lstMasks.Items.Clear()
            txtMaskPreview.Text = ""
            lblDescription.Text = "Seleccione un tipo de máscara para ver las opciones disponibles."
            Return
        End If

        ' Actualizar descripción según el tipo
        UpdateTypeDescription(selectedType)

        ' Cargar máscaras para el tipo seleccionado
        LoadMasksForType(selectedType)
    End Sub

    Private Sub UpdateTypeDescription(maskType As String)
        Select Case maskType
            Case "DateOnly"
                lblDescription.Text = "Máscaras para ingresar valores de fecha (sin hora)."
            Case "DateTime"
                lblDescription.Text = "Máscaras para ingresar valores de fecha y hora."
            Case "DateTime with Offset"
                lblDescription.Text = "Máscaras para ingresar fecha, hora y zona horaria."
            Case "Extended Regular Expression"
                lblDescription.Text = "Expresiones regulares completas con todas las funcionalidades."
            Case "Numeric"
                lblDescription.Text = "Máscaras para ingresar valores numéricos."
            Case "Simple"
                lblDescription.Text = "Máscaras simples para patrones comunes de entrada de datos."
            Case "Simplified Regular Expression"
                lblDescription.Text = "Expresiones regulares simplificadas (sin alternancia, sin autocompletado)."
            Case "TimeOnly"
                lblDescription.Text = "Máscaras para ingresar solo valores de hora."
            Case "TimeSpan"
                lblDescription.Text = "Máscaras para ingresar duraciones de tiempo."
            Case Else
                lblDescription.Text = ""
        End Select
    End Sub

#End Region

#Region "Eventos - Masks"

    Private Sub LstMasks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMasks.SelectedIndexChanged
        If lstMasks.SelectedIndex < 0 Then Return

        Dim selectedItem As MaskItem = TryCast(lstMasks.SelectedItem, MaskItem)
        If selectedItem Is Nothing Then Return

        txtMaskPreview.Text = selectedItem.Mask
        txtMaskPreview.ReadOnly = False ' Permitir edición personalizada
        _selectedMask = selectedItem.Mask
        _selectedMaskDescription = selectedItem.Description
    End Sub

    Private Sub LstMasks_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstMasks.DrawItem
        If e.Index < 0 Then Return

        Try
            ' Obtener el item
            Dim item As MaskItem = TryCast(lstMasks.Items(e.Index), MaskItem)
            If item Is Nothing Then Return

            ' Colores
            Dim backgroundColor As Color
            Dim textColor As Color = Color.Black

            ' Determinar color de fondo según el estado
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                backgroundColor = Color.FromArgb(0, 120, 215) ' Azul de selección
                textColor = Color.White
            Else
                backgroundColor = Color.White
            End If

            ' Dibujar fondo
            e.Graphics.FillRectangle(New SolidBrush(backgroundColor), e.Bounds)

            ' Definir fuentes
            Dim maskFont As New Font("Consolas", 9.0F, FontStyle.Bold)
            Dim descFont As New Font("Segoe UI", 9.0F, FontStyle.Regular)

            ' Calcular posiciones
            Dim maskWidth As Integer = 180 ' Ancho reservado para la máscara
            Dim padding As Integer = 8

            ' Posición de la máscara (izquierda)
            Dim maskRect As New Rectangle(e.Bounds.X + padding,
                                         e.Bounds.Y + 2,
                                         maskWidth,
                                         e.Bounds.Height)

            ' Posición de la descripción (derecha)
            Dim descRect As New Rectangle(e.Bounds.X + maskWidth + padding + 10,
                                         e.Bounds.Y + 2,
                                         e.Bounds.Width - maskWidth - padding - 20,
                                         e.Bounds.Height)

            ' Dibujar máscara en negrita
            If Not String.IsNullOrEmpty(item.Mask) Then
                e.Graphics.DrawString(item.Mask,
                                     maskFont,
                                     New SolidBrush(textColor),
                                     maskRect,
                                     StringFormat.GenericDefault)
            Else
                ' Si está vacía, mostrar "(Ninguna)"
                e.Graphics.DrawString("(Ninguna)",
                                     New Font("Segoe UI", 9.0F, FontStyle.Italic),
                                     New SolidBrush(If(textColor = Color.White, Color.White, Color.Gray)),
                                     maskRect,
                                     StringFormat.GenericDefault)
            End If

            ' Dibujar descripción
            Dim descColor As Color = If((e.State And DrawItemState.Selected) = DrawItemState.Selected,
                                       Color.White,
                                       Color.FromArgb(100, 100, 100))

            e.Graphics.DrawString(item.Description,
                                 descFont,
                                 New SolidBrush(descColor),
                                 descRect,
                                 StringFormat.GenericDefault)

            ' Dibujar línea separadora sutil entre items
            If (e.State And DrawItemState.Selected) <> DrawItemState.Selected Then
                Using pen As New Pen(Color.FromArgb(230, 230, 230))
                    e.Graphics.DrawLine(pen,
                                       e.Bounds.X,
                                       e.Bounds.Bottom - 1,
                                       e.Bounds.Right,
                                       e.Bounds.Bottom - 1)
                End Using
            End If

            ' Dibujar borde de foco
            e.DrawFocusRectangle()

        Catch ex As Exception
            Debug.WriteLine($"Error en LstMasks_DrawItem: {ex.Message}")
        End Try
    End Sub

#End Region

#Region "Eventos - Botones"

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lstMaskType.SelectedIndex >= 0 Then
            Dim typeStr As String = lstMaskType.SelectedItem.ToString()
            _selectedMaskType = ParseMaskType(typeStr)
        Else
            _selectedMaskType = MaskType.None
        End If

        ' Obtener la máscara del preview (puede ser editada manualmente)
        _selectedMask = txtMaskPreview.Text

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Métodos Auxiliares"

    Private Function ParseMaskType(typeString As String) As MaskType
        Select Case typeString
            Case "DateOnly"
                Return MaskType.DateOnly
            Case "DateTime"
                Return MaskType.DateTime
            Case "DateTime with Offset"
                Return MaskType.DateTimeWithOffset
            Case "Extended Regular Expression"
                Return MaskType.ExtendedRegularExpression
            Case "Numeric"
                Return MaskType.Numeric
            Case "Simple"
                Return MaskType.Simple
            Case "Simplified Regular Expression"
                Return MaskType.SimplifiedRegularExpression
            Case "TimeOnly"
                Return MaskType.TimeOnly
            Case "TimeSpan"
                Return MaskType.TimeSpan
            Case Else
                Return MaskType.None
        End Select
    End Function

#End Region

#Region "Clases Auxiliares"

    Private Class MaskItem
        Public Property Mask As String
        Public Property Description As String

        Public Overrides Function ToString() As String
            If String.IsNullOrEmpty(Mask) Then
                Return $"(Ninguna) - {Description}"
            Else
                Return $"{Mask} - {Description}"
            End If
        End Function
    End Class

#End Region

End Class