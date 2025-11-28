Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing.Design
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Control NumericUpDown avanzado con formatos, máscaras y validación
    ''' </summary>
    <ToolboxBitmap(GetType(NumericUpDown))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DefaultEvent("ValueChanged")>
    Public Class NXNumericUpDown
        Inherits Control
        Implements IThemeable

#Region "Enumeraciones"

        ''' <summary>
        ''' Formato de visualización del valor
        ''' </summary>
        Public Enum NumericFormat
            ''' <summary>Número entero (sin decimales)</summary>
            [Integer]
            ''' <summary>Número decimal</summary>
            [Decimal]
            ''' <summary>Formato moneda ($1,234.56)</summary>
            Currency
            ''' <summary>Formato porcentaje (12.34%)</summary>
            Percentage
        End Enum

#End Region

#Region "Campos Privados"

        ' TextBox interno
        Private WithEvents _textBox As TextBox
        Private WithEvents _maskedTextBox As MaskedTextBox

        ' Botones de incremento/decremento
        Private _btnUp As Button
        Private _btnDown As Button

        ' Valores
        Private _value As Decimal = 0D
        Private _minimum As Decimal = 0D
        Private _maximum As Decimal = 100D
        Private _increment As Decimal = 1D
        Private _decimalPlaces As Integer = 2

        ' Formato
        Private _format As NumericFormat = NumericFormat.Integer
        Private _prefix As String = ""
        Private _suffix As String = ""
        Private _thousandsSeparator As Boolean = False
        Private _useMask As Boolean = False
        Private _mask As String = ""

        ' Apariencia
        Private _borderColor As Color = Color.FromArgb(180, 180, 180)
        Private _focusBorderColor As Color = Color.FromArgb(0, 120, 215)
        Private _accentColor As Color = Color.FromArgb(0, 120, 215)
        Private _buttonBackColor As Color = Color.FromArgb(240, 240, 240)
        Private _buttonHoverColor As Color = Color.FromArgb(220, 220, 220)
        Private _isFocused As Boolean = False
        Private _isReadOnly As Boolean = False
        Private _useTheme As Boolean = False

        ' Validación
        Private _allowNegative As Boolean = True
        Private _wrapValue As Boolean = False

        ' Mouse wheel
        Private _enableMouseWheel As Boolean = True

#End Region

#Region "Constructor"

        Public Sub New()
            MyBase.New()

            ' Configuración del control
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            ' Inicializar componentes PRIMERO
            InitializeComponents()

            ' Establecer propiedades visuales DESPUÉS (para evitar eventos antes de que existan los controles)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Font = New Font("Segoe UI", 9.0F)

            ' Establecer tamaño al final
            Me.Size = New Size(120, 28)
            UpdateTextBoxValue()
        End Sub

#End Region

#Region "Inicialización de Componentes"

        Private Sub InitializeComponents()
            ' TextBox normal (usado cuando NO hay máscara)
            _textBox = New TextBox With {
                .BorderStyle = BorderStyle.None,
                .BackColor = Me.BackColor,
                .ForeColor = Me.ForeColor,
                .Font = Me.Font,
                .TextAlign = HorizontalAlignment.Right,
                .Visible = Not _useMask
            }
            AddHandler _textBox.KeyPress, AddressOf TextBox_KeyPress
            AddHandler _textBox.Leave, AddressOf TextBox_Leave
            AddHandler _textBox.Enter, AddressOf TextBox_Enter
            Me.Controls.Add(_textBox)

            ' MaskedTextBox (usado cuando hay máscara)
            _maskedTextBox = New MaskedTextBox With {
                .BorderStyle = BorderStyle.None,
                .BackColor = Me.BackColor,
                .ForeColor = Me.ForeColor,
                .Font = Me.Font,
                .TextAlign = HorizontalAlignment.Right,
                .Visible = _useMask
            }
            AddHandler _maskedTextBox.Leave, AddressOf MaskedTextBox_Leave
            AddHandler _maskedTextBox.Enter, AddressOf TextBox_Enter
            Me.Controls.Add(_maskedTextBox)

            ' Botón Up
            _btnUp = New Button With {
                .FlatStyle = FlatStyle.Flat,
                .BackColor = _buttonBackColor,
                .Text = "▲",
                .Font = New Font("Segoe UI", 6.0F),
                .Cursor = Cursors.Hand,
                .TabStop = False
            }
            _btnUp.FlatAppearance.BorderSize = 0
            AddHandler _btnUp.Click, AddressOf BtnUp_Click
            AddHandler _btnUp.MouseEnter, AddressOf Btn_MouseEnter
            AddHandler _btnUp.MouseLeave, AddressOf Btn_MouseLeave
            Me.Controls.Add(_btnUp)

            ' Botón Down
            _btnDown = New Button With {
                .FlatStyle = FlatStyle.Flat,
                .BackColor = _buttonBackColor,
                .Text = "▼",
                .Font = New Font("Segoe UI", 6.0F),
                .Cursor = Cursors.Hand,
                .TabStop = False
            }
            _btnDown.FlatAppearance.BorderSize = 0
            AddHandler _btnDown.Click, AddressOf BtnDown_Click
            AddHandler _btnDown.MouseEnter, AddressOf Btn_MouseEnter
            AddHandler _btnDown.MouseLeave, AddressOf Btn_MouseLeave
            Me.Controls.Add(_btnDown)

            UpdateControlLayout()
        End Sub

        Private Sub UpdateControlLayout()
            ' Evitar actualización si el control no tiene tamaño válido
            If Me.Width <= 0 Or Me.Height <= 0 Then Return
            If _btnUp Is Nothing Or _btnDown Is Nothing Then Return
            If _textBox Is Nothing Or _maskedTextBox Is Nothing Then Return

            Dim buttonWidth As Integer = 18
            Dim buttonHeight As Integer = (Me.Height - 2) \ 2

            ' Posicionar botones
            _btnUp.Bounds = New Rectangle(Me.Width - buttonWidth - 1, 1, buttonWidth, buttonHeight)
            _btnDown.Bounds = New Rectangle(Me.Width - buttonWidth - 1, 1 + buttonHeight, buttonWidth, buttonHeight)

            ' Posicionar TextBox
            Dim textBoxX As Integer = 4
            Dim textBoxWidth As Integer = Me.Width - buttonWidth - 8
            Dim textBoxY As Integer = (Me.Height - 20) \ 2

            If _useMask AndAlso _maskedTextBox.Visible Then
                _maskedTextBox.Bounds = New Rectangle(textBoxX, textBoxY, textBoxWidth, 20)
            Else
                _textBox.Bounds = New Rectangle(textBoxX, textBoxY, textBoxWidth, 20)
            End If
        End Sub

#End Region

#Region "Propiedades - Valor"

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Valor actual del control")>
        Public Property Value As Decimal
            Get
                Return _value
            End Get
            Set(value As Decimal)
                Dim newValue As Decimal = ClampValue(value)
                If _value <> newValue Then
                    _value = newValue
                    UpdateTextBoxValue()
                    OnValueChanged(EventArgs.Empty)
                End If
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Valor mínimo permitido")>
        Public Property Minimum As Decimal
            Get
                Return _minimum
            End Get
            Set(value As Decimal)
                _minimum = value
                If _value < _minimum Then
                    Me.Value = _minimum
                End If
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Valor máximo permitido")>
        Public Property Maximum As Decimal
            Get
                Return _maximum
            End Get
            Set(value As Decimal)
                _maximum = value
                If _value > _maximum Then
                    Me.Value = _maximum
                End If
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Incremento al usar botones o rueda del mouse")>
        Public Property Increment As Decimal
            Get
                Return _increment
            End Get
            Set(value As Decimal)
                If value > 0 Then
                    _increment = value
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Formato"

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Formato de visualización del número")>
        Public Property Format As NumericFormat
            Get
                Return _format
            End Get
            Set(value As NumericFormat)
                _format = value
                UpdateTextBoxValue()
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Número de decimales a mostrar")>
        Public Property DecimalPlaces As Integer
            Get
                Return _decimalPlaces
            End Get
            Set(value As Integer)
                If value >= 0 AndAlso value <= 10 Then
                    _decimalPlaces = value
                    UpdateTextBoxValue()
                End If
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Mostrar separadores de miles")>
        Public Property ThousandsSeparator As Boolean
            Get
                Return _thousandsSeparator
            End Get
            Set(value As Boolean)
                _thousandsSeparator = value
                UpdateTextBoxValue()
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Prefijo a mostrar antes del número (ej: '$', '€')")>
        Public Property Prefix As String
            Get
                Return _prefix
            End Get
            Set(value As String)
                _prefix = value
                UpdateTextBoxValue()
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Sufijo a mostrar después del número (ej: '%', 'kg')")>
        Public Property Suffix As String
            Get
                Return _suffix
            End Get
            Set(value As String)
                _suffix = value
                UpdateTextBoxValue()
            End Set
        End Property

#End Region

#Region "Propiedades - Máscara"

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Usar máscara numérica para entrada de datos")>
        Public Property UseMask As Boolean
            Get
                Return _useMask
            End Get
            Set(value As Boolean)
                _useMask = value
                _textBox.Visible = Not value
                _maskedTextBox.Visible = value
                UpdateControlLayout()
                UpdateTextBoxValue()
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Máscara numérica para entrada de datos")>
        <Editor(GetType(NXMaskUITypeEditor), GetType(UITypeEditor))>
        Public Property Mask As String
            Get
                Return _mask
            End Get
            Set(value As String)
                _mask = value
                If _useMask Then
                    _maskedTextBox.Mask = value
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Validación"

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Permitir valores negativos")>
        Public Property AllowNegative As Boolean
            Get
                Return _allowNegative
            End Get
            Set(value As Boolean)
                _allowNegative = value
                If Not value AndAlso _value < 0 Then
                    Me.Value = 0
                End If
                If Not value Then
                    _minimum = Math.Max(0, _minimum)
                End If
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Volver al valor mínimo/máximo al exceder los límites")>
        Public Property WrapValue As Boolean
            Get
                Return _wrapValue
            End Get
            Set(value As Boolean)
                _wrapValue = value
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Habilitar incremento/decremento con rueda del mouse")>
        Public Property EnableMouseWheel As Boolean
            Get
                Return _enableMouseWheel
            End Get
            Set(value As Boolean)
                _enableMouseWheel = value
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("El control es de solo lectura")>
        Public Property [ReadOnly] As Boolean
            Get
                Return _isReadOnly
            End Get
            Set(value As Boolean)
                _isReadOnly = value
                _textBox.ReadOnly = value
                _maskedTextBox.ReadOnly = value
                _btnUp.Enabled = Not value
                _btnDown.Enabled = Not value
            End Set
        End Property

#End Region

#Region "Propiedades - Apariencia"

        <NXProperty()>
        <Category("NeoSoft")>
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

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Color del borde cuando está enfocado")>
        Public Property FocusBorderColor As Color
            Get
                Return _focusBorderColor
            End Get
            Set(value As Color)
                _focusBorderColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Color de acento para botones")>
        Public Property AccentColor As Color
            Get
                Return _accentColor
            End Get
            Set(value As Color)
                _accentColor = value
                Me.Invalidate()
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Color de fondo de los botones")>
        Public Property ButtonBackColor As Color
            Get
                Return _buttonBackColor
            End Get
            Set(value As Color)
                _buttonBackColor = value
                _btnUp.BackColor = value
                _btnDown.BackColor = value
            End Set
        End Property

        <NXProperty()>
        <Category("NeoSoft")>
        <Description("Color de los botones al pasar el mouse")>
        Public Property ButtonHoverColor As Color
            Get
                Return _buttonHoverColor
            End Get
            Set(value As Color)
                _buttonHoverColor = value
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

#Region "Métodos - Actualización de Valor"

        Private Sub UpdateTextBoxValue()
            Dim formattedValue As String = FormatValue(_value)

            If _useMask AndAlso _maskedTextBox.Visible Then
                ' Usar MaskedTextBox
                Try
                    _maskedTextBox.Text = _value.ToString()
                Catch
                    _maskedTextBox.Text = ""
                End Try
            Else
                ' Usar TextBox normal con formato
                _textBox.Text = formattedValue
            End If
        End Sub

        Private Function FormatValue(value As Decimal) As String
            Dim formatted As String = ""

            Select Case _format
                Case NumericFormat.Integer
                    formatted = Math.Round(value, 0).ToString("N0")
                    If Not _thousandsSeparator Then
                        formatted = formatted.Replace(",", "")
                    End If

                Case NumericFormat.Decimal
                    Dim formatString As String = If(_thousandsSeparator,
                                                    "N" & _decimalPlaces.ToString(),
                                                    "F" & _decimalPlaces.ToString())
                    formatted = value.ToString(formatString)
                    If Not _thousandsSeparator Then
                        formatted = formatted.Replace(",", "")
                    End If

                Case NumericFormat.Currency
                    formatted = value.ToString("C" & _decimalPlaces.ToString())

                Case NumericFormat.Percentage
                    formatted = (value / 100).ToString("P" & _decimalPlaces.ToString())
            End Select

            ' Agregar prefijo y sufijo
            If Not String.IsNullOrEmpty(_prefix) AndAlso _format <> NumericFormat.Currency AndAlso _format <> NumericFormat.Percentage Then
                formatted = _prefix & formatted
            End If

            If Not String.IsNullOrEmpty(_suffix) AndAlso _format <> NumericFormat.Percentage Then
                formatted = formatted & _suffix
            End If

            Return formatted
        End Function

        Private Function ParseValue(text As String) As Decimal
            If String.IsNullOrWhiteSpace(text) Then Return _value

            ' Remover prefijo y sufijo
            text = text.Trim()
            If Not String.IsNullOrEmpty(_prefix) Then
                text = text.Replace(_prefix, "")
            End If
            If Not String.IsNullOrEmpty(_suffix) Then
                text = text.Replace(_suffix, "")
            End If

            ' Remover símbolos de moneda y porcentaje
            text = text.Replace("$", "").Replace("€", "").Replace("%", "").Trim()

            ' Remover separadores de miles
            text = text.Replace(",", "")

            ' Intentar parsear
            Dim result As Decimal
            If Decimal.TryParse(text, result) Then
                ' Si es porcentaje, multiplicar por 100
                If _format = NumericFormat.Percentage Then
                    result *= 100
                End If
                Return result
            End If

            Return _value
        End Function

        Private Function ClampValue(value As Decimal) As Decimal
            If _wrapValue Then
                ' Modo wrap: volver al inicio/fin
                If value > _maximum Then
                    Return _minimum
                ElseIf value < _minimum Then
                    Return _maximum
                End If
            Else
                ' Modo clamp: limitar al rango
                If value > _maximum Then
                    Return _maximum
                ElseIf value < _minimum Then
                    Return _minimum
                End If
            End If

            ' Validar negativos
            If Not _allowNegative AndAlso value < 0 Then
                Return 0
            End If

            Return value
        End Function

#End Region

#Region "Eventos - Botones"

        Private Sub BtnUp_Click(sender As Object, e As EventArgs)
            IncrementValue()
        End Sub

        Private Sub BtnDown_Click(sender As Object, e As EventArgs)
            DecrementValue()
        End Sub

        Private Sub Btn_MouseEnter(sender As Object, e As EventArgs)
            Dim btn As Button = TryCast(sender, Button)
            If btn IsNot Nothing Then
                btn.BackColor = _buttonHoverColor
            End If
        End Sub

        Private Sub Btn_MouseLeave(sender As Object, e As EventArgs)
            Dim btn As Button = TryCast(sender, Button)
            If btn IsNot Nothing Then
                btn.BackColor = _buttonBackColor
            End If
        End Sub

        Public Sub IncrementValue()
            If Not _isReadOnly Then
                Me.Value = _value + _increment
            End If
        End Sub

        Public Sub DecrementValue()
            If Not _isReadOnly Then
                Me.Value = _value - _increment
            End If
        End Sub

#End Region

#Region "Eventos - TextBox"

        Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
            ' Solo permitir números, decimales, signos negativos y teclas de control
            If Not Char.IsControl(e.KeyChar) Then
                Dim isDigit As Boolean = Char.IsDigit(e.KeyChar)
                Dim isDecimal As Boolean = (e.KeyChar = "."c Or e.KeyChar = ","c) AndAlso _format <> NumericFormat.Integer
                Dim isNegative As Boolean = e.KeyChar = "-"c AndAlso _allowNegative

                If Not (isDigit Or isDecimal Or isNegative) Then
                    e.Handled = True
                End If
            End If

            ' Enter actualiza el valor
            If e.KeyChar = ChrW(Keys.Enter) Then
                TextBox_Leave(sender, EventArgs.Empty)
                e.Handled = True
            End If
        End Sub

        Private Sub TextBox_Leave(sender As Object, e As EventArgs)
            If Not _useMask Then
                Dim newValue As Decimal = ParseValue(_textBox.Text)
                Me.Value = newValue
            End If
        End Sub

        Private Sub MaskedTextBox_Leave(sender As Object, e As EventArgs)
            If _useMask Then
                Dim newValue As Decimal
                If Decimal.TryParse(_maskedTextBox.Text, newValue) Then
                    Me.Value = newValue
                End If
            End If
        End Sub

        Private Sub TextBox_Enter(sender As Object, e As EventArgs)
            _isFocused = True
            Me.Invalidate()

            ' Seleccionar todo el texto al enfocar
            If _useMask Then
                _maskedTextBox.SelectAll()
            Else
                _textBox.SelectAll()
            End If
        End Sub

#End Region

#Region "Eventos - Mouse Wheel"

        Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
            MyBase.OnMouseWheel(e)

            If _enableMouseWheel AndAlso Not _isReadOnly Then
                If e.Delta > 0 Then
                    IncrementValue()
                ElseIf e.Delta < 0 Then
                    DecrementValue()
                End If
            End If
        End Sub

#End Region

#Region "Eventos - Teclado"

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            MyBase.OnKeyDown(e)

            If Not _isReadOnly Then
                Select Case e.KeyCode
                    Case Keys.Up
                        IncrementValue()
                        e.Handled = True
                    Case Keys.Down
                        DecrementValue()
                        e.Handled = True
                End Select
            End If
        End Sub

        Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
            ' Permitir que las flechas sean manejadas por el control
            If keyData = Keys.Up Or keyData = Keys.Down Then
                Return True
            End If
            Return MyBase.IsInputKey(keyData)
        End Function

#End Region

#Region "Eventos - Focus"

        Private Sub OnTextBoxLeave(sender As Object, e As EventArgs)
            _isFocused = False
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnGotFocus(e As EventArgs)
            MyBase.OnGotFocus(e)
            _isFocused = True

            ' Enfocar el TextBox interno
            If _useMask Then
                _maskedTextBox.Focus()
            Else
                _textBox.Focus()
            End If

            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnLostFocus(e As EventArgs)
            MyBase.OnLostFocus(e)
            _isFocused = False
            Me.Invalidate()
        End Sub

#End Region

#Region "Eventos - Layout"

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            UpdateControlLayout()
        End Sub

        Protected Overrides Sub OnBackColorChanged(e As EventArgs)
            MyBase.OnBackColorChanged(e)
            If _textBox IsNot Nothing Then
                _textBox.BackColor = Me.BackColor
            End If
            If _maskedTextBox IsNot Nothing Then
                _maskedTextBox.BackColor = Me.BackColor
            End If
        End Sub

        Protected Overrides Sub OnForeColorChanged(e As EventArgs)
            MyBase.OnForeColorChanged(e)
            If _textBox IsNot Nothing Then
                _textBox.ForeColor = Me.ForeColor
            End If
            If _maskedTextBox IsNot Nothing Then
                _maskedTextBox.ForeColor = Me.ForeColor
            End If
        End Sub

        Protected Overrides Sub OnFontChanged(e As EventArgs)
            MyBase.OnFontChanged(e)
            If _textBox IsNot Nothing Then
                _textBox.Font = Me.Font
            End If
            If _maskedTextBox IsNot Nothing Then
                _maskedTextBox.Font = Me.Font
            End If
            UpdateControlLayout()
        End Sub

#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Dibujar fondo
            Using brush As New SolidBrush(Me.BackColor)
                g.FillRectangle(brush, Me.ClientRectangle)
            End Using

            ' Dibujar borde
            Dim borderColor As Color = If(_isFocused, _focusBorderColor, _borderColor)
            Using pen As New Pen(borderColor, 1)
                g.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
            End Using

            ' Dibujar separador de botones
            Using pen As New Pen(_borderColor)
                Dim buttonX As Integer = Me.Width - 19
                g.DrawLine(pen, buttonX, 1, buttonX, Me.Height - 2)
            End Using
        End Sub

#End Region

#Region "IThemeable"

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            If Not _useTheme Then Return

            Me.BackColor = theme.ControlBackColor
            Me.ForeColor = theme.ForeColor
            _borderColor = theme.BorderColor
            _focusBorderColor = theme.AccentColor
            _accentColor = theme.AccentColor

            ' Actualizar botones
            _buttonBackColor = Color.FromArgb(
                Math.Max(0, theme.ControlBackColor.R - 15),
                Math.Max(0, theme.ControlBackColor.G - 15),
                Math.Max(0, theme.ControlBackColor.B - 15))
            _buttonHoverColor = Color.FromArgb(
                Math.Max(0, theme.ControlBackColor.R - 25),
                Math.Max(0, theme.ControlBackColor.G - 25),
                Math.Max(0, theme.ControlBackColor.B - 25))

            _btnUp.BackColor = _buttonBackColor
            _btnDown.BackColor = _buttonBackColor

            Me.Invalidate()
        End Sub

#End Region

#Region "Eventos Personalizados"

        ''' <summary>
        ''' Se dispara cuando el valor cambia
        ''' </summary>
        Public Event ValueChanged As EventHandler

        Protected Overridable Sub OnValueChanged(e As EventArgs)
            RaiseEvent ValueChanged(Me, e)
        End Sub

#End Region

    End Class

End Namespace