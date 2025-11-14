Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' TextBox personalizado con soporte para placeholder, bordes redondeados y validación visual.
    ''' Proporciona una alternativa moderna al TextBox estándar de Windows Forms.
    ''' </summary>
    ''' <remarks>
    ''' El control NXTextBox incluye características como texto de placeholder,
    ''' bordes personalizables, indicadores de foco y validación visual.
    ''' </remarks>
    <ToolboxBitmap(GetType(TextBox))>
    <DefaultEvent("TextChanged")>
    Public Class NXTextBox
        Inherits UserControl

#Region "Campos Privados"

        Private _textBox As TextBox
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
            ' Configurar estilos del UserControl
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor, True)

            ' Crear y configurar TextBox interno
            _textBox = New TextBox()
            _textBox.BorderStyle = BorderStyle.None
            _textBox.Font = New Font("Segoe UI", 10.0F)
            _textBox.ForeColor = Color.Black
            _textBox.BackColor = Color.White

            ' Configuración inicial
            Me.Size = New Size(200, 35)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Padding = New Padding(8, 8, 8, 8)

            ' Agregar TextBox al control
            Me.Controls.Add(_textBox)

            ' Suscribirse a eventos del TextBox
            AddHandler _textBox.TextChanged, AddressOf OnBaseTextChanged
            AddHandler _textBox.Enter, AddressOf OnBaseEnter
            AddHandler _textBox.Leave, AddressOf OnBaseLeave
            AddHandler _textBox.KeyPress, AddressOf OnBaseKeyPress

            UpdateTextBoxPosition()
        End Sub

#End Region

#Region "Propiedades - Apariencia"

        ''' <summary>
        ''' Radio de las esquinas redondeadas del TextBox
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Grosor del borde del TextBox
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Color del borde en estado normal
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Color del borde cuando el TextBox tiene el foco
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Estilo de borde solo en la parte inferior (subrayado)
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Texto del placeholder que se muestra cuando el TextBox está vacío
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Color del texto del placeholder
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Obtiene o establece el texto del TextBox
        ''' </summary>
        <Category("Apariencia")>
        <Description("Texto del control")>
        <Browsable(True)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Text As String
            Get
                If _isPlaceholder Then
                    Return ""
                Else
                    Return _textBox.Text
                End If
            End Get
            Set(value As String)
                If _isPlaceholder Then
                    RemovePlaceholder()
                End If
                _textBox.Text = value
                If String.IsNullOrWhiteSpace(value) AndAlso Not _isFocused Then
                    SetPlaceholder()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Indica si el TextBox debe mostrar caracteres de contraseña
        ''' </summary>
        <Category("Comportamiento")>
        <Description("Muestra caracteres de contraseña")>
        <DefaultValue(False)>
        Public Property IsPassword As Boolean
            Get
                Return _isPassword
            End Get
            Set(value As Boolean)
                _isPassword = value
                If Not _isPlaceholder Then
                    _textBox.UseSystemPasswordChar = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Obtiene o establece si el texto está en varias líneas
        ''' </summary>
        <Category("Comportamiento")>
        <Description("Permite texto en varias líneas")>
        <DefaultValue(False)>
        Public Property Multiline As Boolean
            Get
                Return _textBox.Multiline
            End Get
            Set(value As Boolean)
                _textBox.Multiline = value
                UpdateTextBoxPosition()
            End Set
        End Property

        ''' <summary>
        ''' Máximo número de caracteres permitidos
        ''' </summary>
        <Category("Comportamiento")>
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

#Region "Propiedades - Validación"

        ''' <summary>
        ''' Indica si el TextBox tiene un error de validación
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Muestra un indicador de éxito/validación correcta
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Color del borde cuando hay error
        ''' </summary>
        <Category("Apariencia NX")>
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

        ''' <summary>
        ''' Color del borde cuando la validación es correcta
        ''' </summary>
        <Category("Apariencia NX")>
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

#Region "Métodos Protegidos - Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Determinar color del borde según estado
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
                ' Estilo subrayado (solo borde inferior)
                Using pen As New Pen(currentBorderColor, _borderSize)
                    g.DrawLine(pen, 0, Me.Height - _borderSize, Me.Width, Me.Height - _borderSize)
                End Using
            Else
                ' Estilo con esquinas redondeadas
                Using path As GraphicsPath = GetRoundedRectangle(rectBorder, _borderRadius)
                    ' Fondo
                    Using brush As New SolidBrush(Me.BackColor)
                        g.FillPath(brush, path)
                    End Using

                    ' Borde
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

        ''' <summary>
        ''' Crea una ruta de gráficos con esquinas redondeadas
        ''' </summary>
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

#Region "Métodos Privados - Placeholder"

        Private Sub SetPlaceholder()
            If Not String.IsNullOrWhiteSpace(_placeholderText) Then
                _isPlaceholder = True
                _textBox.Text = _placeholderText
                _textBox.ForeColor = _placeholderColor
                _textBox.UseSystemPasswordChar = False
            End If
        End Sub

        Private Sub RemovePlaceholder()
            If _isPlaceholder Then
                _isPlaceholder = False
                _textBox.Text = ""
                _textBox.ForeColor = Me.ForeColor
                If _isPassword Then
                    _textBox.UseSystemPasswordChar = True
                End If
            End If
        End Sub

#End Region

#Region "Métodos Privados - Eventos del TextBox Base"

        Private Sub OnBaseTextChanged(sender As Object, e As EventArgs)
            MyBase.OnTextChanged(e)
        End Sub

        Private Sub OnBaseEnter(sender As Object, e As EventArgs)
            _isFocused = True
            If _isPlaceholder Then
                RemovePlaceholder()
            End If
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

#End Region

#Region "Métodos Privados - Actualización"

        Private Sub UpdateTextBoxPosition()
            If _textBox.Multiline Then
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

#Region "Métodos Protegidos - Overrides"

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

#Region "Métodos Públicos"

        ''' <summary>
        ''' Establece el foco en el TextBox
        ''' </summary>
        Public Shadows Sub Focus()
            _textBox.Focus()
        End Sub

        ''' <summary>
        ''' Selecciona todo el texto del TextBox
        ''' </summary>
        Public Sub SelectAll()
            _textBox.SelectAll()
        End Sub

        ''' <summary>
        ''' Limpia el contenido del TextBox
        ''' </summary>
        Public Sub Clear()
            _textBox.Clear()
            SetPlaceholder()
        End Sub

#End Region

    End Class

End Namespace
