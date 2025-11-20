Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Diálogo para selección de máscaras de entrada de datos
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

#End Region

#Region "Campos Privados"

    Private _selectedMask As String = ""
    Private _selectedMaskType As MaskType = MaskType.None
    Private _selectedMaskDescription As String = ""

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

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
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
        Me.Text = "Mask Settings"

        ' Cargar tipos de máscaras
        LoadMaskTypes()

        ' Cargar máscaras predefinidas
        LoadPredefinedMasks()
    End Sub

#End Region

#Region "Carga de Datos"

    Private Sub LoadMaskTypes()
        If lstMaskType Is Nothing Then Return

        lstMaskType.Items.Clear()
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
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000", .Description = "Short date pattern (d)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-00-00", .Description = "ISO 8601 date pattern"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/L00/0000", .Description = "Day month year pattern"})

            Case "DateTime"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00", .Description = "Short date and time"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00:00", .Description = "Long date and time"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-00-00 00:00:00", .Description = "ISO 8601 datetime"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00 AA", .Description = "Date time with AM/PM"})

            Case "DateTime with Offset"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000 00:00 +00:00", .Description = "Short date time with offset"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000-00-00T00:00:00+00:00", .Description = "ISO 8601 with timezone"})

            Case "Extended Regular Expression"
                ' Máscaras corregidas para Extended Regular Expression
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 0000-0000", .Description = "Phone number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "(999) 000-00-00", .Description = "Phone number with optional city code"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Social security number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Decimal number (5 digits)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = ">AAAAA", .Description = "Hexadecimal number (5 chars)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Octal number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000000", .Description = "Binary number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000.99", .Description = "Numeric with optional fractional part"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00", .Description = "Number in range 1-99"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Short ZIP Code"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Long ZIP Code"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Extension"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000.000.000.000", .Description = "IPv4"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Time of day (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00 AA", .Description = "Time with AM/PM designator"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "CCCCCCCCC", .Description = "Any symbols (9 chars)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "LLLLLL", .Description = "Latin letters only (6 chars)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "LLLLLL", .Description = "Letters only (6 chars)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = ">LLLLLL", .Description = "Uppercase letters"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "<llllll", .Description = "Lowercase letters"})
                lstMasks.Items.Add(New MaskItem With {.Mask = ">L<LLL", .Description = "Title case"})

            Case "Numeric"
                lstMasks.Items.Add(New MaskItem With {.Mask = "000", .Description = "3 digits"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0000", .Description = "4 digits"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "5 digits"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000,000", .Description = "Thousands separator"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000.00", .Description = "Decimal (2 places)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0,000.00", .Description = "Currency format"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "999,999.99", .Description = "Optional digits with decimal"})

            Case "Simple"
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 000-0000", .Description = "Phone number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Social security number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Zip code"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Zip code + 4"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/0000", .Description = "Short date"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Short time (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "AA-0000", .Description = "Product code"})

            Case "Simplified Regular Expression"
                lstMasks.Items.Add(New MaskItem With {.Mask = "(000) 0000-0000", .Description = "Phone number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000-00-0000", .Description = "Social security number"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Short ZIP Code"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000-0000", .Description = "Long ZIP Code"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00/00/00", .Description = "Short date (MM/DD/YY)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Short time"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00 AA", .Description = "Long time with AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00000", .Description = "Extension"})

            Case "TimeOnly"
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00", .Description = "Short time (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00", .Description = "Long time (24h)"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00 AA", .Description = "Short time with AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00 AA", .Description = "Long time with AM/PM"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "90:00", .Description = "Time with optional first digit"})

            Case "TimeSpan"
                lstMasks.Items.Add(New MaskItem With {.Mask = "0:00:00", .Description = "Hours:Minutes:Seconds"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "00:00:00", .Description = "Fixed hours format"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "000:00:00", .Description = "Extended hours format"})
                lstMasks.Items.Add(New MaskItem With {.Mask = "0.00:00:00", .Description = "Days.Hours:Minutes:Seconds"})

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
            lblDescription.Text = "Masks for entering date values (without time part)."
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
                lblDescription.Text = "Masks for entering date values (without time part)."
            Case "DateTime"
                lblDescription.Text = "Masks for entering date and time values."
            Case "DateTime with Offset"
                lblDescription.Text = "Masks for entering date, time, and timezone offset values."
            Case "Extended Regular Expression"
                lblDescription.Text = "Full-functional regular expressions."
            Case "Numeric"
                lblDescription.Text = "Masks for entering numeric values."
            Case "Simple"
                lblDescription.Text = "Simple masks for common data entry patterns."
            Case "Simplified Regular Expression"
                lblDescription.Text = "Simplified regular expressions (no alternation, no auto-complete)."
            Case "TimeOnly"
                lblDescription.Text = "Masks for entering time values only."
            Case "TimeSpan"
                lblDescription.Text = "Masks for entering time span durations."
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
        txtMaskPreview.ReadOnly = True
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
            Dim maskWidth As Integer = 150 ' Ancho reservado para la máscara
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
            End If

            ' Dibujar descripción con texto gris (si no está seleccionado)
            Dim descColor As Color = If((e.State And DrawItemState.Selected) = DrawItemState.Selected,
                                       Color.White,
                                       Color.FromArgb(100, 100, 100))

            e.Graphics.DrawString(item.Description,
                                 descFont,
                                 New SolidBrush(descColor),
                                 descRect,
                                 StringFormat.GenericDefault)

            ' Dibujar línea separadora sutil entre items (solo si no está seleccionado)
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
        If lstMaskType.SelectedIndex > 0 Then
            Dim typeStr As String = lstMaskType.SelectedItem.ToString()
            _selectedMaskType = ParseMaskType(typeStr)
        Else
            _selectedMaskType = MaskType.None
        End If

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
    End Class

#End Region

End Class