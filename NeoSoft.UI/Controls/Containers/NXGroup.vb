Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Theming

Namespace Controls

    ''' <summary>
    ''' Contenedor para agrupar RadioButtons con gestión automática de selección
    ''' </summary>
    <ToolboxBitmap(GetType(GroupBox))>
    <DefaultProperty("Text")>
    Public Class NXGroup
        Inherits Panel
        Implements IThemeable

#Region "Campos Privados"

        Private _borderRadius As Integer = 8
        Private _borderSize As Integer = 1
        Private _borderColor As Color = Color.FromArgb(200, 200, 200)
        Private _headerHeight As Integer = 35
        Private _headerBackColor As Color = Color.FromArgb(245, 245, 245)
        Private _showHeader As Boolean = True
        Private _radioButtons As New List(Of NXRadioButton)

#End Region

#Region "Constructor"

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint Or
                       ControlStyles.AllPaintingInWmPaint Or
                       ControlStyles.OptimizedDoubleBuffer Or
                       ControlStyles.ResizeRedraw Or
                       ControlStyles.SupportsTransparentBackColor Or
                       ControlStyles.ContainerControl, True)

            Me.BackColor = Color.White
            Me.Size = New Size(250, 200)
            Me.Padding = New Padding(15, 50, 15, 15)
            Me.Font = New Font("Segoe UI", 9.0F)

            ' Suscribirse a eventos de controles
            AddHandler Me.ControlAdded, AddressOf OnControlAddedToGroup
            AddHandler Me.ControlRemoved, AddressOf OnControlRemovedFromGroup
        End Sub

#End Region

#Region "Propiedades"

        <Category("Apariencia NX")>
        <Description("Radio de las esquinas redondeadas")>
        <DefaultValue(8)>
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
        <Description("Grosor del borde")>
        <DefaultValue(1)>
        Public Property BorderSize As Integer
            Get
                Return _borderSize
            End Get
            Set(value As Integer)
                If value < 0 Then value = 0
                If _borderSize <> value Then
                    _borderSize = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color del borde")>
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
        <Description("Altura del header")>
        <DefaultValue(35)>
        Public Property HeaderHeight As Integer
            Get
                Return _headerHeight
            End Get
            Set(value As Integer)
                If value < 20 Then value = 20
                If _headerHeight <> value Then
                    _headerHeight = value
                    UpdatePadding()
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Color de fondo del header")>
        Public Property HeaderBackColor As Color
            Get
                Return _headerBackColor
            End Get
            Set(value As Color)
                If _headerBackColor <> value Then
                    _headerBackColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        <Category("Apariencia NX")>
        <Description("Muestra el header con el texto")>
        <DefaultValue(True)>
        Public Property ShowHeader As Boolean
            Get
                Return _showHeader
            End Get
            Set(value As Boolean)
                If _showHeader <> value Then
                    _showHeader = value
                    UpdatePadding()
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Texto que se muestra en el header del grupo
        ''' </summary>
        <Category("Appearance")>
        <Description("Texto que se muestra en el header del grupo")>
        <Browsable(True)>
        <EditorBrowsable(EditorBrowsableState.Always)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                If MyBase.Text <> value Then
                    MyBase.Text = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Obtiene el RadioButton seleccionado actualmente
        ''' </summary>
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedRadioButton As NXRadioButton
            Get
                Return _radioButtons.FirstOrDefault(Function(rb) rb.Checked)
            End Get
        End Property

        ''' <summary>
        ''' Obtiene o establece el índice del RadioButton seleccionado
        ''' </summary>
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedIndex As Integer
            Get
                Dim selected = SelectedRadioButton
                If selected IsNot Nothing Then
                    Return _radioButtons.IndexOf(selected)
                End If
                Return -1
            End Get
            Set(value As Integer)
                If value >= 0 AndAlso value < _radioButtons.Count Then
                    _radioButtons(value).Checked = True
                End If
            End Set
        End Property

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Obtiene todos los RadioButtons en el grupo
        ''' </summary>
        Public Function GetRadioButtons() As List(Of NXRadioButton)
            Return New List(Of NXRadioButton)(_radioButtons)
        End Function

        ''' <summary>
        ''' Limpia la selección de todos los RadioButtons
        ''' </summary>
        Public Sub ClearSelection()
            For Each radio In _radioButtons
                radio.Checked = False
            Next
        End Sub

#End Region

#Region "Métodos Internos"

        ''' <summary>
        ''' Establece el RadioButton seleccionado (llamado por NXRadioButton)
        ''' </summary>
        Friend Sub SetCheckedRadioButton(checkedRadio As NXRadioButton)
            For Each radio In _radioButtons
                If radio IsNot checkedRadio Then
                    radio.Checked = False
                End If
            Next
        End Sub

#End Region

#Region "Eventos de Controles"

        Private Sub OnControlAddedToGroup(sender As Object, e As ControlEventArgs)
            If TypeOf e.Control Is NXRadioButton Then
                Dim radio As NXRadioButton = DirectCast(e.Control, NXRadioButton)
                If Not _radioButtons.Contains(radio) Then
                    _radioButtons.Add(radio)
                    radio.RadioGroup = Me
                End If
            End If
        End Sub

        Private Sub OnControlRemovedFromGroup(sender As Object, e As ControlEventArgs)
            If TypeOf e.Control Is NXRadioButton Then
                Dim radio As NXRadioButton = DirectCast(e.Control, NXRadioButton)
                If _radioButtons.Contains(radio) Then
                    _radioButtons.Remove(radio)
                    radio.RadioGroup = Nothing
                End If
            End If
        End Sub

#End Region

#Region "Renderizado"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            Dim rectBorder As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            ' Crear path con bordes redondeados
            Using path As GraphicsPath = GetRoundedRectangle(rectBorder, _borderRadius)
                ' Dibujar fondo
                Using brush As New SolidBrush(Me.BackColor)
                    g.FillPath(brush, path)
                End Using

                ' Dibujar header si está visible
                If _showHeader Then
                    Dim headerRect As New Rectangle(0, 0, Me.Width - 1, _headerHeight)
                    Using headerPath As GraphicsPath = GetRoundedRectangleTop(headerRect, _borderRadius)
                        Using brush As New SolidBrush(_headerBackColor)
                            g.FillPath(brush, headerPath)
                        End Using
                    End Using

                    ' Dibujar texto del header
                    If Not String.IsNullOrEmpty(Me.Text) Then
                        Using brush As New SolidBrush(Me.ForeColor)
                            Dim sf As New StringFormat With {
                                .Alignment = StringAlignment.Near,
                                .LineAlignment = StringAlignment.Center
                            }
                            Dim textRect As New Rectangle(15, 0, Me.Width - 30, _headerHeight)
                            g.DrawString(Me.Text, Me.Font, brush, textRect, sf)
                        End Using
                    End If
                End If

                ' Dibujar borde
                If _borderSize > 0 Then
                    Using pen As New Pen(_borderColor, _borderSize)
                        pen.Alignment = PenAlignment.Inset
                        g.DrawPath(pen, path)
                    End Using
                End If
            End Using

            MyBase.OnPaint(e)
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            ' No pintar fondo - lo hacemos en OnPaint
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

        Private Function GetRoundedRectangleTop(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            Dim diameter As Integer = radius * 2

            path.StartFigure()
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom)
            path.CloseFigure()

            Return path
        End Function

        Private Sub UpdatePadding()
            If _showHeader Then
                Me.Padding = New Padding(15, _headerHeight + 15, 15, 15)
            Else
                Me.Padding = New Padding(15, 15, 15, 15)
            End If
        End Sub

#End Region

#Region "Soporte de Temas"

        Private _useTheme As Boolean = False

        <Category("Apariencia NX")>
        <Description("Indica si el control usa el tema global automáticamente")>
        <DefaultValue(False)>
        Public Property UseTheme As Boolean Implements IThemeable.UseTheme
            Get
                Return _useTheme
            End Get
            Set(value As Boolean)
                If _useTheme <> value Then
                    _useTheme = value
                    If value Then
                        ApplyTheme(NXThemeManager.Instance.CurrentTheme)
                    End If
                End If
            End Set
        End Property

        Public Sub ApplyTheme(theme As NXTheme) Implements IThemeable.ApplyTheme
            If Not _useTheme Then Return

            Me.BackColor = theme.PanelBackColor
            Me.ForeColor = theme.ForeColor
            Me.BorderColor = theme.BorderColor

            ' Calcular color del header basado en el fondo del panel
            Me.HeaderBackColor = If(theme.PanelBackColor.GetBrightness() > 0.5,
                                    Helpers.ColorHelper.Darken(theme.PanelBackColor, 3),
                                    Helpers.ColorHelper.Lighten(theme.PanelBackColor, 10))

            Me.BorderRadius = theme.BorderRadius
            Me.Invalidate()
        End Sub

#End Region

    End Class

End Namespace