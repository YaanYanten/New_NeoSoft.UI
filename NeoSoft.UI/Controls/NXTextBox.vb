Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports NeoSoft.UI.Design
Imports NeoSoft.UI.NeoSoft.UI.Controls

Namespace Controls

    ''' <summary>
    ''' TextBox personalizado con soporte para placeholder, bordes redondeados, máscaras y validación visual.
    ''' </summary>
    <ToolboxBitmap(GetType(TextBox))>
    <PropertyTab(GetType(NXPropertiesTab), PropertyTabScope.Component)>
    <DefaultEvent("TextChanged")>
    Public Class NXTextBox
        Inherits UserControl
        Implements Theming.IThemeable

#Region "Campos Privados"

        Private _textBox As TextBoxBase
        Private _validationRule As Helpers.MaskValidationRules.MaskRule
        Private _borderRadius As Integer = 4
        Private _borderSize As Integer = 2
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _borderFocusColor As Color = Color.FromArgb(0, 120, 215)
        Private _placeholderText As String = ""
        Private _placeholderColor As Color = Color.Gray
        Private _isPlaceholder As Boolean = False
        Private _isFocused As Boolean = False
        Private _isPassword As Boolean = False
        Private _underlineStyle As Boolean = False

        ' Estados de validación
        Private _hasError As Boolean = False
        Private _errorColor As Color = Color.FromArgb(220, 53, 69)
        Private _successColor As Color = Color.FromArgb(40, 167, 69)
        Private _showSuccessIndicator As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                   ControlStyles.AllPaintingInWmPaint Or
                   ControlStyles.OptimizedDoubleBuffer Or
                   ControlStyles.ResizeRedraw Or
                   ControlStyles.SupportsTransparentBackColor, True)

            ' Crear TextBox normal por defecto
            _textBox = New TextBox()
            _textBox.BorderStyle = BorderStyle.None
            _textBox.Font = New Font("Segoe UI", 10.0F)
            _textBox.ForeColor = Color.Black
            _textBox.BackColor = Color.White

            Me.Size = New Size(200, 35)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Padding = New Padding(8, 8, 8, 8)

            Me.Controls.Add(_textBox)

            AddHandler _textBox.TextChanged, AddressOf OnBaseTextChanged
            AddHandler _textBox.Enter, AddressOf OnBaseEnter
            AddHandler _textBox.Leave, AddressOf OnBaseLeave
            AddHandler _textBox.KeyPress, AddressOf OnBaseKeyPress

            UpdateTextBoxPosition()
        End Sub

#End Region

#Region "Inicialización en Tiempo de Diseño"

        ''' <summary>
        ''' Se llama después de que todas las propiedades han sido establecidas
        ''' CRÍTICO: Aquí es donde aplicamos la máscara después de la deserialización
        ''' </summary>
        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)

            ' ⭐ Si hay una máscara configurada en el diseñador, aplicarla ahora
            If Not String.IsNullOrEmpty(_pendingMask) Then
                ApplyMask(_pendingMask)
                _pendingMask = Nothing
            End If
        End Sub

        Private _pendingMask As String = Nothing

#End Region

#Region "Propiedades - Apariencia"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Radio de las esquinas redondeadas")>
        <DefaultValue(4)>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _borderRadius <> value Then
                    _borderRadius = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Grosor del borde")>
        <DefaultValue(2)>
        Public Property BorderSize As Integer
            Get
                Return _borderSize
            End Get
            Set(value As Integer)
                If value < 1 Then value = 1
                If _borderSize <> value Then
                    _borderSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del borde en estado normal")>
        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(value As Color)
                If _borderColor <> value Then
                    _borderColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del borde cuando tiene el foco")>
        Public Property BorderFocusColor As Color
            Get
                Return _borderFocusColor
            End Get
            Set(value As Color)
                If _borderFocusColor <> value Then
                    _borderFocusColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Muestra solo el borde inferior (estilo subrayado)")>
        <DefaultValue(False)>
        Public Property UnderlineStyle As Boolean
            Get
                Return _underlineStyle
            End Get
            Set(value As Boolean)
                If _underlineStyle <> value Then
                    _underlineStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region "Propiedades - Texto y Placeholder"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Texto de placeholder cuando está vacío")>
        <DefaultValue("")>
        Public Property PlaceholderText As String
            Get
                Return _placeholderText
            End Get
            Set(value As String)
                _placeholderText = value
                If String.IsNullOrWhiteSpace(_textBox.Text) OrElse _isPlaceholder Then
                    SetPlaceholder()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del texto del placeholder")>
        Public Property PlaceholderColor As Color
            Get
                Return _placeholderColor
            End Get
            Set(value As Color)
                _placeholderColor = value
                If _isPlaceholder Then
                    _textBox.ForeColor = value
                End If
            End Set
        End Property

        <Category("Apariencia")>
        <NXProperty()>
        <Description("Texto del control")>
        <Browsable(True)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Text As String
            Get
                If _isPlaceholder Then Return ""
                Return _textBox.Text
            End Get
            Set(value As String)
                If _isPlaceholder Then RemovePlaceholder()
                _textBox.Text = value
                If String.IsNullOrWhiteSpace(value) AndAlso Not _isFocused Then
                    SetPlaceholder()
                End If
            End Set
        End Property

        <Category("Comportamiento")>
        <NXProperty()>
        <Description("Muestra caracteres de contraseña")>
        <DefaultValue(False)>
        Public Property IsPassword As Boolean
            Get
                Return _isPassword
            End Get
            Set(value As Boolean)
                _isPassword = value
                If Not _isPlaceholder AndAlso TypeOf _textBox Is TextBox Then
                    DirectCast(_textBox, TextBox).UseSystemPasswordChar = value
                End If
            End Set
        End Property

        <Category("Comportamiento")>
        <NXProperty()>
        <Description("Permite texto en varias líneas")>
        <DefaultValue(False)>
        Public Property Multiline As Boolean
            Get
                If TypeOf _textBox Is TextBox Then
                    Return DirectCast(_textBox, TextBox).Multiline
                End If
                Return False
            End Get
            Set(value As Boolean)
                If TypeOf _textBox Is TextBox Then
                    DirectCast(_textBox, TextBox).Multiline = value
                    UpdateTextBoxPosition()
                End If
            End Set
        End Property

        <Category("Comportamiento")>
        <NXProperty()>
        <Description("Máximo número de caracteres")>
        <DefaultValue(32767)>
        Public Property MaxLength As Integer
            Get
                Return _textBox.MaxLength
            End Get
            Set(value As Integer)
                _textBox.MaxLength = value
            End Set
        End Property

#End Region

#Region "Propiedades - Validación Visual"

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Indica si hay un error de validación")>
        <DefaultValue(False)>
        Public Property HasError As Boolean
            Get
                Return _hasError
            End Get
            Set(value As Boolean)
                If _hasError <> value Then
                    _hasError = value
                    If value Then _showSuccessIndicator = False
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Muestra indicador de validación correcta")>
        <DefaultValue(False)>
        Public Property ShowSuccessIndicator As Boolean
            Get
                Return _showSuccessIndicator
            End Get
            Set(value As Boolean)
                If _showSuccessIndicator <> value Then
                    _showSuccessIndicator = value
                    If value Then _hasError = False
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del borde cuando hay error")>
        Public Property ErrorColor As Color
            Get
                Return _errorColor
            End Get
            Set(value As Color)
                _errorColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Apariencia NX")>
        <NXProperty()>
        <Description("Color del borde cuando la validación es correcta")>
        Public Property SuccessColor As Color
            Get
                Return _successColor
            End Get
            Set(value As Color)
                _successColor = value
                Me.Invalidate()
            End Set
        End Property

#End Region

#Region "Propiedades - Mask"

        Private _currentMask As String = ""

        ''' <summary>
        ''' Máscara de entrada de datos con validación en tiempo real
        ''' </summary>
        <Category("Comportamiento")>
        <NXProperty()>
        <Description("Máscara de entrada de datos con validación en tiempo real")>
        <DefaultValue("")>
        <Editor(GetType(NXMaskUITypeEditor), GetType(System.Drawing.Design.UITypeEditor))>
        Public Property Mask As String
            Get
                Return _currentMask
            End Get
            Set(value As String)
                _currentMask = value

                ' ⭐ Si el handle no está creado, guardar para aplicar después
                If Not Me.IsHandleCreated Then
                    _pendingMask = value
                    Return
                End If

                ApplyMask(value)
            End Set
        End Property

        Private Sub ApplyMask(maskValue As String)
            If String.IsNullOrEmpty(maskValue) Then
                If TypeOf _textBox Is NXMaskedTextBox Then
                    ConvertToNormalTextBox()
                End If
                _validationRule = Nothing
            Else
                _validationRule = Helpers.MaskValidationRules.GetRuleForMask(maskValue)

                If Not TypeOf _textBox Is NXMaskedTextBox Then
                    ConvertToMaskedTextBox()
                End If

                Dim maskedBox As NXMaskedTextBox = DirectCast(_textBox, NXMaskedTextBox)
                maskedBox.ValidationRule = _validationRule

                ' ⭐ CRÍTICO: Solo aplicar la máscara si es diferente
                If maskedBox.Mask <> maskValue Then
                    maskedBox.Mask = maskValue
                End If
            End If
        End Sub

        Private Sub ConvertToMaskedTextBox()
            Dim oldText As String = If(_isPlaceholder, "", _textBox.Text)
            Dim oldFont As Font = _textBox.Font
            Dim oldForeColor As Color = _textBox.ForeColor
            Dim oldBackColor As Color = _textBox.BackColor

            RemoveHandler _textBox.TextChanged, AddressOf OnBaseTextChanged
            RemoveHandler _textBox.Enter, AddressOf OnBaseEnter
            RemoveHandler _textBox.Leave, AddressOf OnBaseLeave
            RemoveHandler _textBox.KeyPress, AddressOf OnBaseKeyPress

            Me.Controls.Remove(_textBox)
            _textBox.Dispose()

            Dim maskedBox As New NXMaskedTextBox()
            maskedBox.BorderStyle = BorderStyle.None
            maskedBox.Font = oldFont
            maskedBox.ForeColor = oldForeColor
            maskedBox.BackColor = oldBackColor
            maskedBox.BeepOnError = False
            maskedBox.RejectInputOnFirstFailure = False

            _textBox = maskedBox

            ' ⭐ NO restaurar texto aquí - el diseñador lo hará
            If Not String.IsNullOrEmpty(oldText) AndAlso Not Me.DesignMode Then
                Try
                    _textBox.Text = oldText
                Catch
                    ' Ignorar errores de máscara inválida
                End Try
            End If

            AddHandler _textBox.TextChanged, AddressOf OnBaseTextChanged
            AddHandler _textBox.Enter, AddressOf OnBaseEnter
            AddHandler _textBox.Leave, AddressOf OnBaseLeave
            AddHandler _textBox.KeyPress, AddressOf OnBaseKeyPress

            Me.Controls.Add(_textBox)
            UpdateTextBoxPosition()

            Debug.WriteLine($"✅ Convertido a NXMaskedTextBox con máscara: {_currentMask}")
        End Sub

        Private Sub ConvertToNormalTextBox()
            Dim oldText As String = _textBox.Text.Replace("_", "").Trim()
            Dim oldFont As Font = _textBox.Font
            Dim oldForeColor As Color = _textBox.ForeColor
            Dim oldBackColor As Color = _textBox.BackColor

            RemoveHandler _textBox.TextChanged, AddressOf OnBaseTextChanged
            RemoveHandler _textBox.Enter, AddressOf OnBaseEnter
            RemoveHandler _textBox.Leave, AddressOf OnBaseLeave
            RemoveHandler _textBox.KeyPress, AddressOf OnBaseKeyPress

            Me.Controls.Remove(_textBox)
            _textBox.Dispose()

            Dim normalBox As New TextBox()
            normalBox.BorderStyle = BorderStyle.None
            normalBox.Font = oldFont
            normalBox.ForeColor = oldForeColor
            normalBox.BackColor = oldBackColor

            _textBox = normalBox

            If Not String.IsNullOrEmpty(oldText) Then
                _textBox.Text = oldText
            End If

            AddHandler _textBox.TextChanged, AddressOf OnBaseTextChanged
            AddHandler _textBox.Enter, AddressOf OnBaseEnter
            AddHandler _textBox.Leave, AddressOf OnBaseLeave
            AddHandler _textBox.KeyPress, AddressOf OnBaseKeyPress

            Me.Controls.Add(_textBox)
            UpdateTextBoxPosition()

            Debug.WriteLine("✅ Convertido a TextBox normal")
        End Sub

#End Region

#Region "Métodos Públicos"

        Public Shadows Sub Focus()
            _textBox.Focus()
        End Sub

        Public Sub SelectAll()
            _textBox.SelectAll()
        End Sub

        Public Sub Clear()
            _textBox.Clear()
            SetPlaceholder()
        End Sub

        ''' <summary>
        ''' Obtiene el texto sin caracteres de máscara
        ''' </summary>
        Public Function GetTextWithoutMask() As String
            If TypeOf _textBox Is NXMaskedTextBox Then
                Return _textBox.Text.Replace("_", "").Replace("/", "").Replace("-", "").Replace(":", "").
                       Replace(" ", "").Replace("(", "").Replace(")", "").Replace(".", "").Replace(",", "").Trim()
            End If
            Return Me.Text
        End Function

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim currentBorderColor As Color = _borderColor
            If _hasError Then
                currentBorderColor = _errorColor
            ElseIf _showSuccessIndicator Then
                currentBorderColor = _successColor
            ElseIf _isFocused Then
                currentBorderColor = _borderFocusColor
            End If

            Dim rectBorder As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            If _underlineStyle Then
                Using pen As New Pen(currentBorderColor, _borderSize)
                    g.DrawLine(pen, 0, Me.Height - _borderSize, Me.Width, Me.Height - _borderSize)
                End Using
            Else
                Using path As GraphicsPath = GetRoundedRectangle(rectBorder, _borderRadius)
                    Using brush As New SolidBrush(Me.BackColor)
                        g.FillPath(brush, path)
                    End Using

                    If _borderSize > 0 Then
                        Using pen As New Pen(currentBorderColor, _borderSize)
                            pen.Alignment = PenAlignment.Inset
                            g.DrawPath(pen, path)
                        End Using
                    End If
                End Using
            End If

            MyBase.OnPaint(e)
        End Sub

        Private Function GetRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            If radius > rect.Height / 2 Then radius = rect.Height / 2
            If radius > rect.Width / 2 Then radius = rect.Width / 2

            Dim diameter As Integer = radius * 2

            path.StartFigure()
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
            path.CloseFigure()

            Return path
        End Function

#End Region

#Region "Eventos"

        Private Sub OnBaseTextChanged(sender As Object, e As EventArgs)
            MyBase.OnTextChanged(e)
        End Sub

        Private Sub OnBaseEnter(sender As Object, e As EventArgs)
            _isFocused = True
            If _isPlaceholder Then RemovePlaceholder()
            Me.Invalidate()
        End Sub

        Private Sub OnBaseLeave(sender As Object, e As EventArgs)
            _isFocused = False
            If String.IsNullOrWhiteSpace(_textBox.Text) Then
                SetPlaceholder()
            End If
            Me.Invalidate()
        End Sub

        Private Sub OnBaseKeyPress(sender As Object, e As KeyPressEventArgs)
            MyBase.OnKeyPress(e)
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            UpdateTextBoxPosition()
            MyBase.OnResize(e)
        End Sub

        Protected Overrides Sub OnFontChanged(e As EventArgs)
            _textBox.Font = Me.Font
            UpdateTextBoxPosition()
            MyBase.OnFontChanged(e)
        End Sub

        Protected Overrides Sub OnForeColorChanged(e As EventArgs)
            If Not _isPlaceholder Then
                _textBox.ForeColor = Me.ForeColor
            End If
            MyBase.OnForeColorChanged(e)
        End Sub

        Protected Overrides Sub OnBackColorChanged(e As EventArgs)
            _textBox.BackColor = Me.BackColor
            Me.Invalidate()
            MyBase.OnBackColorChanged(e)
        End Sub

#End Region

#Region "Placeholder"

        Private Sub SetPlaceholder()
            If Not String.IsNullOrWhiteSpace(_placeholderText) Then
                _isPlaceholder = True
                _textBox.Text = _placeholderText
                _textBox.ForeColor = _placeholderColor
                If TypeOf _textBox Is TextBox Then
                    DirectCast(_textBox, TextBox).UseSystemPasswordChar = False
                End If
            End If
        End Sub

        Private Sub RemovePlaceholder()
            If _isPlaceholder Then
                _isPlaceholder = False
                _textBox.Text = ""
                _textBox.ForeColor = Me.ForeColor
                If _isPassword AndAlso TypeOf _textBox Is TextBox Then
                    DirectCast(_textBox, TextBox).UseSystemPasswordChar = True
                End If
            End If
        End Sub

#End Region

#Region "Posicionamiento"

        Private Sub UpdateTextBoxPosition()
            Dim isMultiline As Boolean = False
            If TypeOf _textBox Is TextBox Then
                isMultiline = DirectCast(_textBox, TextBox).Multiline
            End If

            If isMultiline Then
                _textBox.Location = New Point(Me.Padding.Left, Me.Padding.Top)
                _textBox.Size = New Size(Me.Width - Me.Padding.Left - Me.Padding.Right,
                                        Me.Height - Me.Padding.Top - Me.Padding.Bottom)
            Else
                Dim yPos As Integer = (Me.Height - _textBox.Height) \ 2
                _textBox.Location = New Point(Me.Padding.Left, yPos)
                _textBox.Size = New Size(Me.Width - Me.Padding.Left - Me.Padding.Right, _textBox.Height)
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
            Me.ForeColor = theme.ForeColor
            Me.BorderColor = theme.BorderColor
            Me.BorderFocusColor = theme.PrimaryColor
            Me.ErrorColor = theme.ErrorColor
            Me.SuccessColor = theme.SuccessColor
            Me.BorderRadius = theme.TextBoxBorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace