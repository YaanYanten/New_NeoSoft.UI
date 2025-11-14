<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New NeoSoft.UI.Controls.NXLabel()
        Me.lblSectionButtons = New NeoSoft.UI.Controls.NXLabel()
        Me.btnSolid = New NeoSoft.UI.Controls.NXButton()
        Me.btnGradient = New NeoSoft.UI.Controls.NXButton()
        Me.btnOutline = New NeoSoft.UI.Controls.NXButton()
        Me.btnRounded = New NeoSoft.UI.Controls.NXButton()
        Me.btnSquare = New NeoSoft.UI.Controls.NXButton()
        Me.btnDisabled = New NeoSoft.UI.Controls.NXButton()
        Me.lblInfoButtons = New NeoSoft.UI.Controls.NXLabel()
        Me.lblSectionTextBox = New NeoSoft.UI.Controls.NXLabel()
        Me.txtNormal = New NeoSoft.UI.Controls.NXTextBox()
        Me.txtError = New NeoSoft.UI.Controls.NXTextBox()
        Me.txtSuccess = New NeoSoft.UI.Controls.NXTextBox()
        Me.txtUnderline = New NeoSoft.UI.Controls.NXTextBox()
        Me.lblInfoTextBox = New NeoSoft.UI.Controls.NXLabel()
        Me.lblSectionLabel = New NeoSoft.UI.Controls.NXLabel()
        Me.lblSolid = New NeoSoft.UI.Controls.NXLabel()
        Me.lblGradient = New NeoSoft.UI.Controls.NXLabel()
        Me.lblShadow = New NeoSoft.UI.Controls.NXLabel()
        Me.lblBorderLeft = New NeoSoft.UI.Controls.NXLabel()
        Me.lblBorderBottom = New NeoSoft.UI.Controls.NXLabel()
        Me.lblInfoLabel = New NeoSoft.UI.Controls.NXLabel()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblTitle.BorderRadius = 8
        Me.lblTitle.BorderSize = 1
        Me.lblTitle.BorderStyleValue = NeoSoft.UI.Controls.NXLabel.BorderStyle.Solid
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle.GradientColor = System.Drawing.Color.Empty
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.OutlineColor = System.Drawing.Color.Black
        Me.lblTitle.Padding = New System.Windows.Forms.Padding(5)
        Me.lblTitle.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitle.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblTitle.Size = New System.Drawing.Size(530, 50)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Controles NX - Demostración"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSectionButtons
        '
        Me.lblSectionButtons.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionButtons.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionButtons.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionButtons.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionButtons.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionButtons.Location = New System.Drawing.Point(20, 90)
        Me.lblSectionButtons.Name = "lblSectionButtons"
        Me.lblSectionButtons.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionButtons.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionButtons.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionButtons.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionButtons.Size = New System.Drawing.Size(760, 30)
        Me.lblSectionButtons.TabIndex = 1
        Me.lblSectionButtons.Text = "NXButton - Botones Personalizados"
        '
        'btnSolid
        '
        Me.btnSolid.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnSolid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnSolid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSolid.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnSolid.ForeColor = System.Drawing.Color.White
        Me.btnSolid.HoverBackColor = System.Drawing.Color.Empty
        Me.btnSolid.Location = New System.Drawing.Point(30, 130)
        Me.btnSolid.Name = "btnSolid"
        Me.btnSolid.PressedBackColor = System.Drawing.Color.Empty
        Me.btnSolid.Size = New System.Drawing.Size(150, 40)
        Me.btnSolid.TabIndex = 2
        Me.btnSolid.Text = "Botón Solid"
        '
        'btnGradient
        '
        Me.btnGradient.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnGradient.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnGradient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGradient.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnGradient.ForeColor = System.Drawing.Color.White
        Me.btnGradient.HoverBackColor = System.Drawing.Color.Empty
        Me.btnGradient.Location = New System.Drawing.Point(190, 130)
        Me.btnGradient.Name = "btnGradient"
        Me.btnGradient.PressedBackColor = System.Drawing.Color.Empty
        Me.btnGradient.Size = New System.Drawing.Size(150, 40)
        Me.btnGradient.Style = NeoSoft.UI.Controls.NXButton.ButtonStyle.Gradient
        Me.btnGradient.TabIndex = 3
        Me.btnGradient.Text = "Botón Gradient"
        '
        'btnOutline
        '
        Me.btnOutline.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOutline.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOutline.BorderSize = 2
        Me.btnOutline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOutline.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnOutline.ForeColor = System.Drawing.Color.White
        Me.btnOutline.HoverBackColor = System.Drawing.Color.Empty
        Me.btnOutline.Location = New System.Drawing.Point(350, 130)
        Me.btnOutline.Name = "btnOutline"
        Me.btnOutline.PressedBackColor = System.Drawing.Color.Empty
        Me.btnOutline.Size = New System.Drawing.Size(150, 40)
        Me.btnOutline.Style = NeoSoft.UI.Controls.NXButton.ButtonStyle.Outline
        Me.btnOutline.TabIndex = 4
        Me.btnOutline.Text = "Botón Outline"
        '
        'btnRounded
        '
        Me.btnRounded.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnRounded.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRounded.BorderRadius = 20
        Me.btnRounded.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRounded.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnRounded.ForeColor = System.Drawing.Color.White
        Me.btnRounded.HoverBackColor = System.Drawing.Color.Empty
        Me.btnRounded.Location = New System.Drawing.Point(30, 180)
        Me.btnRounded.Name = "btnRounded"
        Me.btnRounded.PressedBackColor = System.Drawing.Color.Empty
        Me.btnRounded.Size = New System.Drawing.Size(120, 35)
        Me.btnRounded.TabIndex = 5
        Me.btnRounded.Text = "Redondeado"
        '
        'btnSquare
        '
        Me.btnSquare.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnSquare.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnSquare.BorderRadius = 0
        Me.btnSquare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSquare.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnSquare.ForeColor = System.Drawing.Color.White
        Me.btnSquare.HoverBackColor = System.Drawing.Color.Empty
        Me.btnSquare.Location = New System.Drawing.Point(160, 180)
        Me.btnSquare.Name = "btnSquare"
        Me.btnSquare.PressedBackColor = System.Drawing.Color.Empty
        Me.btnSquare.Size = New System.Drawing.Size(120, 35)
        Me.btnSquare.TabIndex = 6
        Me.btnSquare.Text = "Cuadrado"
        '
        'btnDisabled
        '
        Me.btnDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnDisabled.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnDisabled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDisabled.Enabled = False
        Me.btnDisabled.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnDisabled.ForeColor = System.Drawing.Color.White
        Me.btnDisabled.HoverBackColor = System.Drawing.Color.Empty
        Me.btnDisabled.Location = New System.Drawing.Point(290, 180)
        Me.btnDisabled.Name = "btnDisabled"
        Me.btnDisabled.PressedBackColor = System.Drawing.Color.Empty
        Me.btnDisabled.Size = New System.Drawing.Size(120, 35)
        Me.btnDisabled.TabIndex = 7
        Me.btnDisabled.Text = "Deshabilitado"
        '
        'lblInfoButtons
        '
        Me.lblInfoButtons.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoButtons.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoButtons.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoButtons.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoButtons.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoButtons.Location = New System.Drawing.Point(30, 225)
        Me.lblInfoButtons.Name = "lblInfoButtons"
        Me.lblInfoButtons.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoButtons.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoButtons.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoButtons.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoButtons.Size = New System.Drawing.Size(450, 20)
        Me.lblInfoButtons.TabIndex = 8
        Me.lblInfoButtons.Text = "Haz clic en los botones para probarlos"
        '
        'lblSectionTextBox
        '
        Me.lblSectionTextBox.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionTextBox.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionTextBox.Location = New System.Drawing.Point(20, 290)
        Me.lblSectionTextBox.Name = "lblSectionTextBox"
        Me.lblSectionTextBox.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionTextBox.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionTextBox.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionTextBox.Size = New System.Drawing.Size(760, 30)
        Me.lblSectionTextBox.TabIndex = 9
        Me.lblSectionTextBox.Text = "NXTextBox - TextBox Mejorados"
        '
        'txtNormal
        '
        Me.txtNormal.BackColor = System.Drawing.Color.White
        Me.txtNormal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtNormal.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtNormal.BorderRadius = 6
        Me.txtNormal.ErrorColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtNormal.ForeColor = System.Drawing.Color.Black
        Me.txtNormal.Location = New System.Drawing.Point(30, 330)
        Me.txtNormal.Name = "txtNormal"
        Me.txtNormal.Padding = New System.Windows.Forms.Padding(8)
        Me.txtNormal.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtNormal.PlaceholderText = "Escribe tu nombre..."
        Me.txtNormal.Size = New System.Drawing.Size(250, 35)
        Me.txtNormal.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtNormal.TabIndex = 10
        '
        'txtError
        '
        Me.txtError.BackColor = System.Drawing.Color.White
        Me.txtError.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtError.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtError.BorderRadius = 6
        Me.txtError.ErrorColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtError.ForeColor = System.Drawing.Color.Black
        Me.txtError.HasError = True
        Me.txtError.Location = New System.Drawing.Point(290, 330)
        Me.txtError.Name = "txtError"
        Me.txtError.Padding = New System.Windows.Forms.Padding(8)
        Me.txtError.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtError.PlaceholderText = "Email (error)"
        Me.txtError.Size = New System.Drawing.Size(250, 35)
        Me.txtError.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtError.TabIndex = 11
        '
        'txtSuccess
        '
        Me.txtSuccess.BackColor = System.Drawing.Color.White
        Me.txtSuccess.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtSuccess.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtSuccess.BorderRadius = 6
        Me.txtSuccess.ErrorColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtSuccess.ForeColor = System.Drawing.Color.Black
        Me.txtSuccess.IsPassword = True
        Me.txtSuccess.Location = New System.Drawing.Point(30, 375)
        Me.txtSuccess.Name = "txtSuccess"
        Me.txtSuccess.Padding = New System.Windows.Forms.Padding(8)
        Me.txtSuccess.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtSuccess.PlaceholderText = "Contraseña (success)"
        Me.txtSuccess.ShowSuccessIndicator = True
        Me.txtSuccess.Size = New System.Drawing.Size(250, 35)
        Me.txtSuccess.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtSuccess.TabIndex = 12
        '
        'txtUnderline
        '
        Me.txtUnderline.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtUnderline.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtUnderline.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtUnderline.ErrorColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtUnderline.ForeColor = System.Drawing.Color.Black
        Me.txtUnderline.Location = New System.Drawing.Point(290, 375)
        Me.txtUnderline.Name = "txtUnderline"
        Me.txtUnderline.Padding = New System.Windows.Forms.Padding(8)
        Me.txtUnderline.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtUnderline.PlaceholderText = "Estilo subrayado..."
        Me.txtUnderline.Size = New System.Drawing.Size(250, 35)
        Me.txtUnderline.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtUnderline.TabIndex = 13
        Me.txtUnderline.UnderlineStyle = True
        '
        'lblInfoTextBox
        '
        Me.lblInfoTextBox.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoTextBox.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoTextBox.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoTextBox.Location = New System.Drawing.Point(30, 420)
        Me.lblInfoTextBox.Name = "lblInfoTextBox"
        Me.lblInfoTextBox.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoTextBox.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoTextBox.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoTextBox.Size = New System.Drawing.Size(520, 20)
        Me.lblInfoTextBox.TabIndex = 14
        Me.lblInfoTextBox.Text = "Soporta placeholder, validación, password y estilos personalizados"
        '
        'lblSectionLabel
        '
        Me.lblSectionLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionLabel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionLabel.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionLabel.Location = New System.Drawing.Point(20, 470)
        Me.lblSectionLabel.Name = "lblSectionLabel"
        Me.lblSectionLabel.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionLabel.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionLabel.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionLabel.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionLabel.Size = New System.Drawing.Size(760, 30)
        Me.lblSectionLabel.TabIndex = 15
        Me.lblSectionLabel.Text = "NXLabel - Labels con Efectos"
        '
        'lblSolid
        '
        Me.lblSolid.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSolid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSolid.BorderRadius = 6
        Me.lblSolid.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSolid.ForeColor = System.Drawing.Color.White
        Me.lblSolid.GradientColor = System.Drawing.Color.Empty
        Me.lblSolid.Location = New System.Drawing.Point(30, 510)
        Me.lblSolid.Name = "lblSolid"
        Me.lblSolid.OutlineColor = System.Drawing.Color.Black
        Me.lblSolid.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSolid.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSolid.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSolid.Size = New System.Drawing.Size(160, 35)
        Me.lblSolid.TabIndex = 16
        Me.lblSolid.Text = "Label con Fondo"
        Me.lblSolid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGradient
        '
        Me.lblGradient.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.lblGradient.BackgroundStyleValue = NeoSoft.UI.Controls.NXLabel.BackgroundStyle.GradientHorizontal
        Me.lblGradient.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblGradient.BorderRadius = 6
        Me.lblGradient.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblGradient.ForeColor = System.Drawing.Color.White
        Me.lblGradient.GradientColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.lblGradient.Location = New System.Drawing.Point(200, 510)
        Me.lblGradient.Name = "lblGradient"
        Me.lblGradient.OutlineColor = System.Drawing.Color.Black
        Me.lblGradient.Padding = New System.Windows.Forms.Padding(5)
        Me.lblGradient.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblGradient.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblGradient.Size = New System.Drawing.Size(160, 35)
        Me.lblGradient.TabIndex = 17
        Me.lblGradient.Text = "Label con Gradiente"
        Me.lblGradient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblShadow
        '
        Me.lblShadow.BackColor = System.Drawing.Color.Transparent
        Me.lblShadow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblShadow.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblShadow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblShadow.GradientColor = System.Drawing.Color.Empty
        Me.lblShadow.Location = New System.Drawing.Point(370, 510)
        Me.lblShadow.Name = "lblShadow"
        Me.lblShadow.OutlineColor = System.Drawing.Color.Black
        Me.lblShadow.Padding = New System.Windows.Forms.Padding(5)
        Me.lblShadow.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblShadow.ShadowOffset = New System.Drawing.Point(2, 2)
        Me.lblShadow.Size = New System.Drawing.Size(160, 35)
        Me.lblShadow.TabIndex = 18
        Me.lblShadow.Text = "Label con Sombra"
        Me.lblShadow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblShadow.TextShadow = True
        '
        'lblBorderLeft
        '
        Me.lblBorderLeft.BackColor = System.Drawing.Color.Transparent
        Me.lblBorderLeft.BorderColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblBorderLeft.BorderSize = 4
        Me.lblBorderLeft.BorderStyleValue = NeoSoft.UI.Controls.NXLabel.BorderStyle.Left
        Me.lblBorderLeft.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblBorderLeft.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblBorderLeft.GradientColor = System.Drawing.Color.Empty
        Me.lblBorderLeft.Location = New System.Drawing.Point(30, 555)
        Me.lblBorderLeft.Name = "lblBorderLeft"
        Me.lblBorderLeft.OutlineColor = System.Drawing.Color.Black
        Me.lblBorderLeft.Padding = New System.Windows.Forms.Padding(12, 5, 5, 5)
        Me.lblBorderLeft.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBorderLeft.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblBorderLeft.Size = New System.Drawing.Size(240, 30)
        Me.lblBorderLeft.TabIndex = 19
        Me.lblBorderLeft.Text = "Label con Borde Izquierdo"
        '
        'lblBorderBottom
        '
        Me.lblBorderBottom.BackColor = System.Drawing.Color.Transparent
        Me.lblBorderBottom.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBorderBottom.BorderSize = 2
        Me.lblBorderBottom.BorderStyleValue = NeoSoft.UI.Controls.NXLabel.BorderStyle.Bottom
        Me.lblBorderBottom.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblBorderBottom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblBorderBottom.GradientColor = System.Drawing.Color.Empty
        Me.lblBorderBottom.Location = New System.Drawing.Point(290, 555)
        Me.lblBorderBottom.Name = "lblBorderBottom"
        Me.lblBorderBottom.OutlineColor = System.Drawing.Color.Black
        Me.lblBorderBottom.Padding = New System.Windows.Forms.Padding(5)
        Me.lblBorderBottom.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBorderBottom.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblBorderBottom.Size = New System.Drawing.Size(240, 30)
        Me.lblBorderBottom.TabIndex = 20
        Me.lblBorderBottom.Text = "Label con Borde Inferior"
        '
        'lblInfoLabel
        '
        Me.lblInfoLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoLabel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoLabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoLabel.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoLabel.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoLabel.Location = New System.Drawing.Point(30, 595)
        Me.lblInfoLabel.Name = "lblInfoLabel"
        Me.lblInfoLabel.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoLabel.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoLabel.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoLabel.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoLabel.Size = New System.Drawing.Size(520, 20)
        Me.lblInfoLabel.TabIndex = 21
        Me.lblInfoLabel.Text = "Soporta gradientes, sombras, bordes y múltiples estilos visuales"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(562, 650)
        Me.Controls.Add(Me.lblInfoLabel)
        Me.Controls.Add(Me.lblBorderBottom)
        Me.Controls.Add(Me.lblBorderLeft)
        Me.Controls.Add(Me.lblShadow)
        Me.Controls.Add(Me.lblGradient)
        Me.Controls.Add(Me.lblSolid)
        Me.Controls.Add(Me.lblSectionLabel)
        Me.Controls.Add(Me.lblInfoTextBox)
        Me.Controls.Add(Me.txtUnderline)
        Me.Controls.Add(Me.txtSuccess)
        Me.Controls.Add(Me.txtError)
        Me.Controls.Add(Me.txtNormal)
        Me.Controls.Add(Me.lblSectionTextBox)
        Me.Controls.Add(Me.lblInfoButtons)
        Me.Controls.Add(Me.btnDisabled)
        Me.Controls.Add(Me.btnSquare)
        Me.Controls.Add(Me.btnRounded)
        Me.Controls.Add(Me.btnOutline)
        Me.Controls.Add(Me.btnGradient)
        Me.Controls.Add(Me.btnSolid)
        Me.Controls.Add(Me.lblSectionButtons)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NeoSoft.UI - Demostración de Controles NX"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblSectionButtons As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents btnSolid As NeoSoft.UI.Controls.NXButton
    Friend WithEvents btnGradient As NeoSoft.UI.Controls.NXButton
    Friend WithEvents btnOutline As NeoSoft.UI.Controls.NXButton
    Friend WithEvents btnRounded As NeoSoft.UI.Controls.NXButton
    Friend WithEvents btnSquare As NeoSoft.UI.Controls.NXButton
    Friend WithEvents btnDisabled As NeoSoft.UI.Controls.NXButton
    Friend WithEvents lblInfoButtons As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblSectionTextBox As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents txtNormal As NeoSoft.UI.Controls.NXTextBox
    Friend WithEvents txtError As NeoSoft.UI.Controls.NXTextBox
    Friend WithEvents txtSuccess As NeoSoft.UI.Controls.NXTextBox
    Friend WithEvents txtUnderline As NeoSoft.UI.Controls.NXTextBox
    Friend WithEvents lblInfoTextBox As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblSectionLabel As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblSolid As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblGradient As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblShadow As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblBorderLeft As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblBorderBottom As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblInfoLabel As NeoSoft.UI.Controls.NXLabel

End Class