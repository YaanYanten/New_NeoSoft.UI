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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblInfoImagePicker = New NeoSoft.UI.Controls.NXLabel()
        Me.btnImagePicker = New NeoSoft.UI.Controls.NXButton()
        Me.lblSectionImagePicker = New NeoSoft.UI.Controls.NXLabel()
        Me.lblInfoLabel = New NeoSoft.UI.Controls.NXLabel()
        Me.lblBorderBottom = New NeoSoft.UI.Controls.NXLabel()
        Me.lblBorderLeft = New NeoSoft.UI.Controls.NXLabel()
        Me.lblShadow = New NeoSoft.UI.Controls.NXLabel()
        Me.lblGradient = New NeoSoft.UI.Controls.NXLabel()
        Me.lblSolid = New NeoSoft.UI.Controls.NXLabel()
        Me.lblSectionLabel = New NeoSoft.UI.Controls.NXLabel()
        Me.lblInfoTextBox = New NeoSoft.UI.Controls.NXLabel()
        Me.txtUnderline = New NeoSoft.UI.Controls.NXTextBox()
        Me.txtSuccess = New NeoSoft.UI.Controls.NXTextBox()
        Me.txtError = New NeoSoft.UI.Controls.NXTextBox()
        Me.txtNormal = New NeoSoft.UI.Controls.NXTextBox()
        Me.lblSectionTextBox = New NeoSoft.UI.Controls.NXLabel()
        Me.lblInfoButtons = New NeoSoft.UI.Controls.NXLabel()
        Me.btnDisabled = New NeoSoft.UI.Controls.NXButton()
        Me.btnSquare = New NeoSoft.UI.Controls.NXButton()
        Me.btnRounded = New NeoSoft.UI.Controls.NXButton()
        Me.btnOutline = New NeoSoft.UI.Controls.NXButton()
        Me.btnGradient = New NeoSoft.UI.Controls.NXButton()
        Me.btnSolid = New NeoSoft.UI.Controls.NXButton()
        Me.btnThemeDemo = New NeoSoft.UI.Controls.NXButton()
        Me.lblSectionButtons = New NeoSoft.UI.Controls.NXLabel()
        Me.lblTitle = New NeoSoft.UI.Controls.NXLabel()
        Me.chkStandard = New NeoSoft.UI.Controls.NXCheckBox()
        Me.chkSwitch = New NeoSoft.UI.Controls.NXCheckBox()
        Me.chkButton = New NeoSoft.UI.Controls.NXCheckBox()
        Me.chkDisabled = New NeoSoft.UI.Controls.NXCheckBox()
        Me.lblSectionCheckBox = New NeoSoft.UI.Controls.NXLabel()
        Me.lblInfoCheckBox = New NeoSoft.UI.Controls.NXLabel()
        Me.btnProgressDemo = New NeoSoft.UI.Controls.NXButton()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(571, 127)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(250, 35)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "▼ Cambiar Máscara de txtNormal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(831, 127)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(250, 35)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "✓ Validar Todos los Campos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblInfoImagePicker
        '
        Me.lblInfoImagePicker.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoImagePicker.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoImagePicker.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoImagePicker.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoImagePicker.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoImagePicker.Location = New System.Drawing.Point(571, 102)
        Me.lblInfoImagePicker.Name = "lblInfoImagePicker"
        Me.lblInfoImagePicker.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoImagePicker.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoImagePicker.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoImagePicker.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoImagePicker.Size = New System.Drawing.Size(500, 20)
        Me.lblInfoImagePicker.TabIndex = 24
        Me.lblInfoImagePicker.Text = "Diálogo completo para seleccionar imágenes de múltiples fuentes"
        '
        'btnImagePicker
        '
        Me.btnImagePicker.BackColor = System.Drawing.Color.LightGray
        Me.btnImagePicker.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnImagePicker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImagePicker.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnImagePicker.ForeColor = System.Drawing.Color.White
        Me.btnImagePicker.HoverBackColor = System.Drawing.Color.Empty
        Me.btnImagePicker.Image = CType(resources.GetObject("btnImagePicker.Image"), System.Drawing.Image)
        Me.btnImagePicker.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImagePicker.Location = New System.Drawing.Point(571, 52)
        Me.btnImagePicker.Name = "btnImagePicker"
        Me.btnImagePicker.PressedBackColor = System.Drawing.Color.Empty
        Me.btnImagePicker.Size = New System.Drawing.Size(184, 40)
        Me.btnImagePicker.TabIndex = 23
        Me.btnImagePicker.Text = "Abrir Image Picker"
        '
        'lblSectionImagePicker
        '
        Me.lblSectionImagePicker.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionImagePicker.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionImagePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionImagePicker.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionImagePicker.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionImagePicker.Location = New System.Drawing.Point(561, 12)
        Me.lblSectionImagePicker.Name = "lblSectionImagePicker"
        Me.lblSectionImagePicker.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionImagePicker.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionImagePicker.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionImagePicker.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionImagePicker.Size = New System.Drawing.Size(530, 30)
        Me.lblSectionImagePicker.TabIndex = 22
        Me.lblSectionImagePicker.Text = "NXImagePickerDialog - Selector de Imágenes"
        '
        'lblInfoLabel
        '
        Me.lblInfoLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoLabel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoLabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoLabel.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoLabel.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoLabel.Location = New System.Drawing.Point(22, 482)
        Me.lblInfoLabel.Name = "lblInfoLabel"
        Me.lblInfoLabel.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoLabel.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoLabel.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoLabel.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoLabel.Size = New System.Drawing.Size(520, 20)
        Me.lblInfoLabel.TabIndex = 21
        Me.lblInfoLabel.Text = "Soporta gradientes, sombras, bordes y múltiples estilos visuales"
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
        Me.lblBorderBottom.Location = New System.Drawing.Point(282, 442)
        Me.lblBorderBottom.Name = "lblBorderBottom"
        Me.lblBorderBottom.OutlineColor = System.Drawing.Color.Black
        Me.lblBorderBottom.Padding = New System.Windows.Forms.Padding(5)
        Me.lblBorderBottom.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBorderBottom.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblBorderBottom.Size = New System.Drawing.Size(240, 30)
        Me.lblBorderBottom.TabIndex = 20
        Me.lblBorderBottom.Text = "Label con Borde Inferior"
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
        Me.lblBorderLeft.Location = New System.Drawing.Point(22, 442)
        Me.lblBorderLeft.Name = "lblBorderLeft"
        Me.lblBorderLeft.OutlineColor = System.Drawing.Color.Black
        Me.lblBorderLeft.Padding = New System.Windows.Forms.Padding(12, 5, 5, 5)
        Me.lblBorderLeft.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBorderLeft.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblBorderLeft.Size = New System.Drawing.Size(240, 30)
        Me.lblBorderLeft.TabIndex = 19
        Me.lblBorderLeft.Text = "Label con Borde Izquierdo"
        '
        'lblShadow
        '
        Me.lblShadow.BackColor = System.Drawing.Color.Transparent
        Me.lblShadow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblShadow.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblShadow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblShadow.GradientColor = System.Drawing.Color.Empty
        Me.lblShadow.Location = New System.Drawing.Point(362, 397)
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
        'lblGradient
        '
        Me.lblGradient.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.lblGradient.BackgroundStyleValue = NeoSoft.UI.Controls.NXLabel.BackgroundStyle.GradientHorizontal
        Me.lblGradient.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblGradient.BorderRadius = 6
        Me.lblGradient.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblGradient.ForeColor = System.Drawing.Color.White
        Me.lblGradient.GradientColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.lblGradient.Location = New System.Drawing.Point(192, 397)
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
        'lblSolid
        '
        Me.lblSolid.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSolid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSolid.BorderRadius = 6
        Me.lblSolid.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSolid.ForeColor = System.Drawing.Color.White
        Me.lblSolid.GradientColor = System.Drawing.Color.Empty
        Me.lblSolid.Location = New System.Drawing.Point(22, 397)
        Me.lblSolid.Name = "lblSolid"
        Me.lblSolid.OutlineColor = System.Drawing.Color.Black
        Me.lblSolid.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSolid.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSolid.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSolid.Size = New System.Drawing.Size(160, 35)
        Me.lblSolid.TabIndex = 27
        Me.lblSolid.Text = "Label con Fondo"
        Me.lblSolid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSectionLabel
        '
        Me.lblSectionLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionLabel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionLabel.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionLabel.Location = New System.Drawing.Point(12, 357)
        Me.lblSectionLabel.Name = "lblSectionLabel"
        Me.lblSectionLabel.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionLabel.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionLabel.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionLabel.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionLabel.Size = New System.Drawing.Size(530, 30)
        Me.lblSectionLabel.TabIndex = 28
        Me.lblSectionLabel.Text = "NXLabel - Labels con Efectos"
        '
        'lblInfoTextBox
        '
        Me.lblInfoTextBox.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoTextBox.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoTextBox.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoTextBox.Location = New System.Drawing.Point(22, 317)
        Me.lblInfoTextBox.Name = "lblInfoTextBox"
        Me.lblInfoTextBox.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoTextBox.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoTextBox.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoTextBox.Size = New System.Drawing.Size(520, 20)
        Me.lblInfoTextBox.TabIndex = 29
        Me.lblInfoTextBox.Text = "Soporta máscaras con validación en tiempo real, placeholder y estilos personaliza" &
    "dos"
        '
        'txtUnderline
        '
        Me.txtUnderline.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtUnderline.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtUnderline.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtUnderline.ErrorColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtUnderline.ForeColor = System.Drawing.Color.Black
        Me.txtUnderline.Location = New System.Drawing.Point(282, 272)
        Me.txtUnderline.Name = "txtUnderline"
        Me.txtUnderline.Padding = New System.Windows.Forms.Padding(8)
        Me.txtUnderline.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtUnderline.PlaceholderText = "Estilo subrayado..."
        Me.txtUnderline.Size = New System.Drawing.Size(250, 35)
        Me.txtUnderline.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtUnderline.TabIndex = 13
        Me.txtUnderline.UnderlineStyle = True
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
        Me.txtSuccess.Location = New System.Drawing.Point(22, 272)
        Me.txtSuccess.Name = "txtSuccess"
        Me.txtSuccess.Padding = New System.Windows.Forms.Padding(8)
        Me.txtSuccess.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtSuccess.PlaceholderText = "Contraseña (success)"
        Me.txtSuccess.ShowSuccessIndicator = True
        Me.txtSuccess.Size = New System.Drawing.Size(250, 35)
        Me.txtSuccess.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtSuccess.TabIndex = 12
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
        Me.txtError.Location = New System.Drawing.Point(282, 227)
        Me.txtError.Name = "txtError"
        Me.txtError.Padding = New System.Windows.Forms.Padding(8)
        Me.txtError.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtError.PlaceholderText = "Email (error)"
        Me.txtError.Size = New System.Drawing.Size(250, 35)
        Me.txtError.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtError.TabIndex = 11
        '
        'txtNormal
        '
        Me.txtNormal.BackColor = System.Drawing.Color.White
        Me.txtNormal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtNormal.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtNormal.BorderRadius = 6
        Me.txtNormal.ErrorColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtNormal.ForeColor = System.Drawing.Color.Black
        Me.txtNormal.Location = New System.Drawing.Point(22, 227)
        Me.txtNormal.Mask = "00/00/00"
        Me.txtNormal.Name = "txtNormal"
        Me.txtNormal.Padding = New System.Windows.Forms.Padding(8)
        Me.txtNormal.PlaceholderColor = System.Drawing.Color.Gray
        Me.txtNormal.PlaceholderText = "Escribe tu nombre..."
        Me.txtNormal.Size = New System.Drawing.Size(250, 35)
        Me.txtNormal.SuccessColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.txtNormal.TabIndex = 10
        Me.txtNormal.Text = "  /  /"
        '
        'lblSectionTextBox
        '
        Me.lblSectionTextBox.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionTextBox.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionTextBox.Location = New System.Drawing.Point(12, 187)
        Me.lblSectionTextBox.Name = "lblSectionTextBox"
        Me.lblSectionTextBox.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionTextBox.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionTextBox.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionTextBox.Size = New System.Drawing.Size(530, 30)
        Me.lblSectionTextBox.TabIndex = 9
        Me.lblSectionTextBox.Text = "NXTextBox - TextBox Mejorados"
        '
        'lblInfoButtons
        '
        Me.lblInfoButtons.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoButtons.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoButtons.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoButtons.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoButtons.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoButtons.Location = New System.Drawing.Point(22, 147)
        Me.lblInfoButtons.Name = "lblInfoButtons"
        Me.lblInfoButtons.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoButtons.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoButtons.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoButtons.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoButtons.Size = New System.Drawing.Size(520, 20)
        Me.lblInfoButtons.TabIndex = 8
        Me.lblInfoButtons.Text = "Haz clic en los botones para probarlos"
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
        Me.btnDisabled.Image = Nothing
        Me.btnDisabled.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnDisabled.Location = New System.Drawing.Point(282, 102)
        Me.btnDisabled.Name = "btnDisabled"
        Me.btnDisabled.PressedBackColor = System.Drawing.Color.Empty
        Me.btnDisabled.Size = New System.Drawing.Size(120, 35)
        Me.btnDisabled.TabIndex = 7
        Me.btnDisabled.Text = "Deshabilitado"
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
        Me.btnSquare.Image = Nothing
        Me.btnSquare.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnSquare.Location = New System.Drawing.Point(152, 102)
        Me.btnSquare.Name = "btnSquare"
        Me.btnSquare.PressedBackColor = System.Drawing.Color.Empty
        Me.btnSquare.Size = New System.Drawing.Size(120, 35)
        Me.btnSquare.TabIndex = 6
        Me.btnSquare.Text = "Cuadrado"
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
        Me.btnRounded.Image = Nothing
        Me.btnRounded.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnRounded.Location = New System.Drawing.Point(22, 102)
        Me.btnRounded.Name = "btnRounded"
        Me.btnRounded.PressedBackColor = System.Drawing.Color.Empty
        Me.btnRounded.Size = New System.Drawing.Size(120, 35)
        Me.btnRounded.TabIndex = 5
        Me.btnRounded.Text = "Redondeado"
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
        Me.btnOutline.Image = CType(resources.GetObject("btnOutline.Image"), System.Drawing.Image)
        Me.btnOutline.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOutline.Location = New System.Drawing.Point(342, 52)
        Me.btnOutline.Name = "btnOutline"
        Me.btnOutline.PressedBackColor = System.Drawing.Color.Empty
        Me.btnOutline.Size = New System.Drawing.Size(150, 40)
        Me.btnOutline.Style = NeoSoft.UI.Controls.NXButton.ButtonStyle.Outline
        Me.btnOutline.TabIndex = 4
        Me.btnOutline.Text = "Botón Outline"
        '
        'btnGradient
        '
        Me.btnGradient.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnGradient.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnGradient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGradient.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnGradient.ForeColor = System.Drawing.Color.White
        Me.btnGradient.HoverBackColor = System.Drawing.Color.Empty
        Me.btnGradient.Image = CType(resources.GetObject("btnGradient.Image"), System.Drawing.Image)
        Me.btnGradient.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnGradient.Location = New System.Drawing.Point(182, 52)
        Me.btnGradient.Name = "btnGradient"
        Me.btnGradient.PressedBackColor = System.Drawing.Color.Empty
        Me.btnGradient.Size = New System.Drawing.Size(150, 40)
        Me.btnGradient.Style = NeoSoft.UI.Controls.NXButton.ButtonStyle.Gradient
        Me.btnGradient.TabIndex = 3
        Me.btnGradient.Text = "Botón Gradient"
        '
        'btnSolid
        '
        Me.btnSolid.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnSolid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnSolid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSolid.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnSolid.ForeColor = System.Drawing.Color.White
        Me.btnSolid.HoverBackColor = System.Drawing.Color.Empty
        Me.btnSolid.Image = CType(resources.GetObject("btnSolid.Image"), System.Drawing.Image)
        Me.btnSolid.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnSolid.Location = New System.Drawing.Point(22, 52)
        Me.btnSolid.Name = "btnSolid"
        Me.btnSolid.PressedBackColor = System.Drawing.Color.Empty
        Me.btnSolid.Size = New System.Drawing.Size(150, 40)
        Me.btnSolid.TabIndex = 2
        Me.btnSolid.Text = "Botón Solid"
        '
        'btnThemeDemo
        '
        Me.btnThemeDemo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnThemeDemo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnThemeDemo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnThemeDemo.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnThemeDemo.ForeColor = System.Drawing.Color.White
        Me.btnThemeDemo.HoverBackColor = System.Drawing.Color.Empty
        Me.btnThemeDemo.Image = Nothing
        Me.btnThemeDemo.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnThemeDemo.Location = New System.Drawing.Point(741, 357)
        Me.btnThemeDemo.Name = "btnThemeDemo"
        Me.btnThemeDemo.PressedBackColor = System.Drawing.Color.Empty
        Me.btnThemeDemo.Size = New System.Drawing.Size(140, 40)
        Me.btnThemeDemo.TabIndex = 33
        Me.btnThemeDemo.Text = "🎨 Demo de Temas"
        '
        'lblSectionButtons
        '
        Me.lblSectionButtons.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionButtons.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionButtons.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionButtons.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionButtons.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionButtons.Location = New System.Drawing.Point(12, 12)
        Me.lblSectionButtons.Name = "lblSectionButtons"
        Me.lblSectionButtons.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionButtons.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionButtons.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionButtons.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionButtons.Size = New System.Drawing.Size(530, 30)
        Me.lblSectionButtons.TabIndex = 1
        Me.lblSectionButtons.Text = "NXButton - Botones Personalizados"
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
        'chkStandard
        '
        Me.chkStandard.BackColor = System.Drawing.Color.Transparent
        Me.chkStandard.CheckColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.chkStandard.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkStandard.Checked = True
        Me.chkStandard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkStandard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkStandard.ForeColor = System.Drawing.Color.Black
        Me.chkStandard.Location = New System.Drawing.Point(571, 227)
        Me.chkStandard.Name = "chkStandard"
        Me.chkStandard.Size = New System.Drawing.Size(200, 25)
        Me.chkStandard.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkStandard.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkStandard.TabIndex = 27
        Me.chkStandard.Text = "Standard CheckBox"
        '
        'chkSwitch
        '
        Me.chkSwitch.BackColor = System.Drawing.Color.Transparent
        Me.chkSwitch.CheckColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkSwitch.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkSwitch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSwitch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSwitch.ForeColor = System.Drawing.Color.Black
        Me.chkSwitch.Location = New System.Drawing.Point(571, 262)
        Me.chkSwitch.Name = "chkSwitch"
        Me.chkSwitch.Size = New System.Drawing.Size(200, 25)
        Me.chkSwitch.Style = NeoSoft.UI.Controls.NXCheckBox.CheckBoxStyle.Switch
        Me.chkSwitch.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkSwitch.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkSwitch.TabIndex = 28
        Me.chkSwitch.Text = "Toggle Switch"
        '
        'chkButton
        '
        Me.chkButton.BackColor = System.Drawing.Color.Transparent
        Me.chkButton.BorderRadius = 6
        Me.chkButton.CheckColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.chkButton.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkButton.ForeColor = System.Drawing.Color.Black
        Me.chkButton.Location = New System.Drawing.Point(831, 227)
        Me.chkButton.Name = "chkButton"
        Me.chkButton.Size = New System.Drawing.Size(120, 35)
        Me.chkButton.Style = NeoSoft.UI.Controls.NXCheckBox.CheckBoxStyle.Button
        Me.chkButton.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkButton.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkButton.TabIndex = 29
        Me.chkButton.Text = "Button Style"
        '
        'chkDisabled
        '
        Me.chkDisabled.BackColor = System.Drawing.Color.Transparent
        Me.chkDisabled.CheckColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.chkDisabled.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkDisabled.Checked = True
        Me.chkDisabled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDisabled.Enabled = False
        Me.chkDisabled.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDisabled.ForeColor = System.Drawing.Color.Black
        Me.chkDisabled.Location = New System.Drawing.Point(831, 262)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(120, 25)
        Me.chkDisabled.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkDisabled.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkDisabled.TabIndex = 30
        Me.chkDisabled.Text = "Disabled"
        '
        'lblSectionCheckBox
        '
        Me.lblSectionCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionCheckBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSectionCheckBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionCheckBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSectionCheckBox.GradientColor = System.Drawing.Color.Empty
        Me.lblSectionCheckBox.Location = New System.Drawing.Point(571, 187)
        Me.lblSectionCheckBox.Name = "lblSectionCheckBox"
        Me.lblSectionCheckBox.OutlineColor = System.Drawing.Color.Black
        Me.lblSectionCheckBox.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSectionCheckBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSectionCheckBox.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSectionCheckBox.Size = New System.Drawing.Size(530, 30)
        Me.lblSectionCheckBox.TabIndex = 31
        Me.lblSectionCheckBox.Text = "NXCheckBox - CheckBoxes Modernos"
        '
        'lblInfoCheckBox
        '
        Me.lblInfoCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoCheckBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblInfoCheckBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblInfoCheckBox.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoCheckBox.GradientColor = System.Drawing.Color.Empty
        Me.lblInfoCheckBox.Location = New System.Drawing.Point(571, 297)
        Me.lblInfoCheckBox.Name = "lblInfoCheckBox"
        Me.lblInfoCheckBox.OutlineColor = System.Drawing.Color.Black
        Me.lblInfoCheckBox.Padding = New System.Windows.Forms.Padding(5)
        Me.lblInfoCheckBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfoCheckBox.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblInfoCheckBox.Size = New System.Drawing.Size(520, 20)
        Me.lblInfoCheckBox.TabIndex = 32
        Me.lblInfoCheckBox.Text = "Soporta estilos Standard, Switch y Button con animaciones suaves"
        '
        'btnProgressDemo
        '
        Me.btnProgressDemo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnProgressDemo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnProgressDemo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProgressDemo.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnProgressDemo.ForeColor = System.Drawing.Color.White
        Me.btnProgressDemo.HoverBackColor = System.Drawing.Color.Empty
        Me.btnProgressDemo.Image = Nothing
        Me.btnProgressDemo.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnProgressDemo.Location = New System.Drawing.Point(561, 357)
        Me.btnProgressDemo.Name = "btnProgressDemo"
        Me.btnProgressDemo.PressedBackColor = System.Drawing.Color.Empty
        Me.btnProgressDemo.Size = New System.Drawing.Size(140, 40)
        Me.btnProgressDemo.TabIndex = 34
        Me.btnProgressDemo.Text = "Demo Progress"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1103, 534)
        Me.Controls.Add(Me.btnProgressDemo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblInfoImagePicker)
        Me.Controls.Add(Me.btnImagePicker)
        Me.Controls.Add(Me.lblSectionImagePicker)
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
        Me.Controls.Add(Me.btnThemeDemo)
        Me.Controls.Add(Me.lblSectionButtons)
        Me.Controls.Add(Me.chkStandard)
        Me.Controls.Add(Me.chkSwitch)
        Me.Controls.Add(Me.chkButton)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.lblSectionCheckBox)
        Me.Controls.Add(Me.lblInfoCheckBox)
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
    Friend WithEvents lblSectionImagePicker As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents btnImagePicker As NeoSoft.UI.Controls.NXButton
    Friend WithEvents lblInfoImagePicker As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents chkStandard As NeoSoft.UI.Controls.NXCheckBox
    Friend WithEvents chkSwitch As NeoSoft.UI.Controls.NXCheckBox
    Friend WithEvents chkButton As NeoSoft.UI.Controls.NXCheckBox
    Friend WithEvents chkDisabled As NeoSoft.UI.Controls.NXCheckBox
    Friend WithEvents lblSectionCheckBox As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents lblInfoCheckBox As NeoSoft.UI.Controls.NXLabel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnThemeDemo As NeoSoft.UI.Controls.NXButton
    Friend WithEvents btnProgressDemo As Controls.NXButton
End Class