Imports NeoSoft.UI.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormThemeDemo
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub InitializeComponent()
        Me.lblTitle = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlHeader = New NeoSoft.UI.Controls.NXPanel()
        Me.btnApplyToAll = New NeoSoft.UI.Controls.NXButton()
        Me.lblThemeDescription = New NeoSoft.UI.Controls.NXLabel()
        Me.cboThemes = New System.Windows.Forms.ComboBox()
        Me.lblSelectTheme = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlCheckBoxes = New NeoSoft.UI.Controls.NXPanel()
        Me.chkButton = New NeoSoft.UI.Controls.NXCheckBox()
        Me.chkSwitch = New NeoSoft.UI.Controls.NXCheckBox()
        Me.chkStandard = New NeoSoft.UI.Controls.NXCheckBox()
        Me.lblCheckBoxSection = New NeoSoft.UI.Controls.NXLabel()
        Me.grpPayment = New NeoSoft.UI.Controls.NXGroup()
        Me.rdoTransfer = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoCash = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoDebitCard = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoCreditCard = New NeoSoft.UI.Controls.NXRadioButton()
        Me.grpGender = New NeoSoft.UI.Controls.NXGroup()
        Me.rdoMale = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoFemale = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoOther = New NeoSoft.UI.Controls.NXRadioButton()
        Me.pnlHeader.SuspendLayout()
        Me.pnlCheckBoxes.SuspendLayout()
        Me.grpPayment.SuspendLayout()
        Me.grpGender.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblTitle.BorderRadius = 4
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle.GradientColor = System.Drawing.Color.Empty
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.OutlineColor = System.Drawing.Color.Black
        Me.lblTitle.Padding = New System.Windows.Forms.Padding(5)
        Me.lblTitle.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitle.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblTitle.Size = New System.Drawing.Size(1000, 60)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "🎨 Demostración de Temas - NeoSoft.UI"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTitle.UseTheme = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlHeader.BorderRadius = 4
        Me.pnlHeader.BorderSize = 1
        Me.pnlHeader.Controls.Add(Me.btnApplyToAll)
        Me.pnlHeader.Controls.Add(Me.lblThemeDescription)
        Me.pnlHeader.Controls.Add(Me.cboThemes)
        Me.pnlHeader.Controls.Add(Me.lblSelectTheme)
        Me.pnlHeader.Location = New System.Drawing.Point(20, 70)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlHeader.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlHeader.ShowShadow = True
        Me.pnlHeader.Size = New System.Drawing.Size(960, 100)
        Me.pnlHeader.TabIndex = 1
        Me.pnlHeader.UseTheme = True
        '
        'btnApplyToAll
        '
        Me.btnApplyToAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnApplyToAll.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnApplyToAll.BorderRadius = 4
        Me.btnApplyToAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyToAll.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnApplyToAll.ForeColor = System.Drawing.Color.White
        Me.btnApplyToAll.HoverBackColor = System.Drawing.Color.Empty
        Me.btnApplyToAll.Image = Nothing
        Me.btnApplyToAll.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnApplyToAll.Location = New System.Drawing.Point(790, 20)
        Me.btnApplyToAll.Name = "btnApplyToAll"
        Me.btnApplyToAll.PressedBackColor = System.Drawing.Color.Empty
        Me.btnApplyToAll.Size = New System.Drawing.Size(150, 35)
        Me.btnApplyToAll.TabIndex = 3
        Me.btnApplyToAll.Text = "Aplicar a Todos"
        Me.btnApplyToAll.UseTheme = True
        '
        'lblThemeDescription
        '
        Me.lblThemeDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblThemeDescription.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblThemeDescription.BorderRadius = 4
        Me.lblThemeDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblThemeDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblThemeDescription.GradientColor = System.Drawing.Color.Empty
        Me.lblThemeDescription.Location = New System.Drawing.Point(170, 55)
        Me.lblThemeDescription.Name = "lblThemeDescription"
        Me.lblThemeDescription.OutlineColor = System.Drawing.Color.Black
        Me.lblThemeDescription.Padding = New System.Windows.Forms.Padding(5)
        Me.lblThemeDescription.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblThemeDescription.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblThemeDescription.Size = New System.Drawing.Size(600, 30)
        Me.lblThemeDescription.TabIndex = 2
        Me.lblThemeDescription.Text = "Descripción del tema..."
        Me.lblThemeDescription.UseTheme = True
        '
        'cboThemes
        '
        Me.cboThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThemes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboThemes.Location = New System.Drawing.Point(170, 20)
        Me.cboThemes.Name = "cboThemes"
        Me.cboThemes.Size = New System.Drawing.Size(300, 25)
        Me.cboThemes.TabIndex = 1
        '
        'lblSelectTheme
        '
        Me.lblSelectTheme.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectTheme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSelectTheme.BorderRadius = 4
        Me.lblSelectTheme.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSelectTheme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSelectTheme.GradientColor = System.Drawing.Color.Empty
        Me.lblSelectTheme.Location = New System.Drawing.Point(15, 20)
        Me.lblSelectTheme.Name = "lblSelectTheme"
        Me.lblSelectTheme.OutlineColor = System.Drawing.Color.Black
        Me.lblSelectTheme.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSelectTheme.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSelectTheme.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSelectTheme.Size = New System.Drawing.Size(150, 30)
        Me.lblSelectTheme.TabIndex = 0
        Me.lblSelectTheme.Text = "Seleccionar Tema:"
        Me.lblSelectTheme.UseTheme = True
        '
        'pnlCheckBoxes
        '
        Me.pnlCheckBoxes.BackColor = System.Drawing.Color.White
        Me.pnlCheckBoxes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlCheckBoxes.BorderRadius = 4
        Me.pnlCheckBoxes.BorderSize = 1
        Me.pnlCheckBoxes.Controls.Add(Me.chkButton)
        Me.pnlCheckBoxes.Controls.Add(Me.chkSwitch)
        Me.pnlCheckBoxes.Controls.Add(Me.chkStandard)
        Me.pnlCheckBoxes.Controls.Add(Me.lblCheckBoxSection)
        Me.pnlCheckBoxes.Location = New System.Drawing.Point(20, 490)
        Me.pnlCheckBoxes.Name = "pnlCheckBoxes"
        Me.pnlCheckBoxes.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlCheckBoxes.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlCheckBoxes.ShowShadow = True
        Me.pnlCheckBoxes.Size = New System.Drawing.Size(960, 100)
        Me.pnlCheckBoxes.TabIndex = 4
        Me.pnlCheckBoxes.UseTheme = True
        '
        'chkButton
        '
        Me.chkButton.BackColor = System.Drawing.Color.Transparent
        Me.chkButton.CheckColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.chkButton.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.chkButton.Location = New System.Drawing.Point(445, 50)
        Me.chkButton.Name = "chkButton"
        Me.chkButton.Size = New System.Drawing.Size(140, 40)
        Me.chkButton.Style = NeoSoft.UI.Controls.NXCheckBox.CheckBoxStyle.Button
        Me.chkButton.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkButton.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkButton.TabIndex = 3
        Me.chkButton.Text = "Button Style"
        Me.chkButton.UseTheme = True
        '
        'chkSwitch
        '
        Me.chkSwitch.BackColor = System.Drawing.Color.Transparent
        Me.chkSwitch.CheckColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.chkSwitch.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkSwitch.Checked = True
        Me.chkSwitch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSwitch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSwitch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.chkSwitch.Location = New System.Drawing.Point(230, 55)
        Me.chkSwitch.Name = "chkSwitch"
        Me.chkSwitch.Size = New System.Drawing.Size(200, 30)
        Me.chkSwitch.Style = NeoSoft.UI.Controls.NXCheckBox.CheckBoxStyle.Switch
        Me.chkSwitch.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkSwitch.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkSwitch.TabIndex = 2
        Me.chkSwitch.Text = "Toggle Switch"
        Me.chkSwitch.UseTheme = True
        '
        'chkStandard
        '
        Me.chkStandard.BackColor = System.Drawing.Color.Transparent
        Me.chkStandard.CheckColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.chkStandard.CheckColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.chkStandard.Checked = True
        Me.chkStandard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkStandard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkStandard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.chkStandard.Location = New System.Drawing.Point(15, 55)
        Me.chkStandard.Name = "chkStandard"
        Me.chkStandard.Size = New System.Drawing.Size(200, 30)
        Me.chkStandard.SwitchColorOff = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.chkStandard.SwitchColorOn = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.chkStandard.TabIndex = 1
        Me.chkStandard.Text = "CheckBox Standard"
        Me.chkStandard.UseTheme = True
        '
        'lblCheckBoxSection
        '
        Me.lblCheckBoxSection.BackColor = System.Drawing.Color.Transparent
        Me.lblCheckBoxSection.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblCheckBoxSection.BorderRadius = 4
        Me.lblCheckBoxSection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckBoxSection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblCheckBoxSection.GradientColor = System.Drawing.Color.Empty
        Me.lblCheckBoxSection.Location = New System.Drawing.Point(15, 10)
        Me.lblCheckBoxSection.Name = "lblCheckBoxSection"
        Me.lblCheckBoxSection.OutlineColor = System.Drawing.Color.Black
        Me.lblCheckBoxSection.Padding = New System.Windows.Forms.Padding(5)
        Me.lblCheckBoxSection.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCheckBoxSection.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblCheckBoxSection.Size = New System.Drawing.Size(930, 30)
        Me.lblCheckBoxSection.TabIndex = 0
        Me.lblCheckBoxSection.Text = "CheckBoxes"
        Me.lblCheckBoxSection.UseTheme = True
        '
        'grpPayment
        '
        Me.grpPayment.BackColor = System.Drawing.Color.White
        Me.grpPayment.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.grpPayment.Controls.Add(Me.rdoTransfer)
        Me.grpPayment.Controls.Add(Me.rdoCash)
        Me.grpPayment.Controls.Add(Me.rdoDebitCard)
        Me.grpPayment.Controls.Add(Me.rdoCreditCard)
        Me.grpPayment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpPayment.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.grpPayment.Location = New System.Drawing.Point(240, 176)
        Me.grpPayment.Name = "grpPayment"
        Me.grpPayment.Padding = New System.Windows.Forms.Padding(15, 50, 15, 15)
        Me.grpPayment.Size = New System.Drawing.Size(250, 200)
        Me.grpPayment.TabIndex = 35
        Me.grpPayment.Text = "Método de Pago"
        '
        'rdoTransfer
        '
        Me.rdoTransfer.BackColor = System.Drawing.Color.Transparent
        Me.rdoTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoTransfer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoTransfer.ForeColor = System.Drawing.Color.Black
        Me.rdoTransfer.Location = New System.Drawing.Point(15, 150)
        Me.rdoTransfer.Name = "rdoTransfer"
        Me.rdoTransfer.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoTransfer.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoTransfer.Size = New System.Drawing.Size(220, 25)
        Me.rdoTransfer.TabIndex = 3
        Me.rdoTransfer.Text = "🏦 Transferencia"
        '
        'rdoCash
        '
        Me.rdoCash.BackColor = System.Drawing.Color.Transparent
        Me.rdoCash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoCash.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoCash.ForeColor = System.Drawing.Color.Black
        Me.rdoCash.Location = New System.Drawing.Point(15, 120)
        Me.rdoCash.Name = "rdoCash"
        Me.rdoCash.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoCash.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoCash.Size = New System.Drawing.Size(220, 25)
        Me.rdoCash.TabIndex = 2
        Me.rdoCash.Text = "💵 Efectivo"
        '
        'rdoDebitCard
        '
        Me.rdoDebitCard.BackColor = System.Drawing.Color.Transparent
        Me.rdoDebitCard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoDebitCard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoDebitCard.ForeColor = System.Drawing.Color.Black
        Me.rdoDebitCard.Location = New System.Drawing.Point(15, 90)
        Me.rdoDebitCard.Name = "rdoDebitCard"
        Me.rdoDebitCard.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoDebitCard.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoDebitCard.Size = New System.Drawing.Size(220, 25)
        Me.rdoDebitCard.TabIndex = 1
        Me.rdoDebitCard.Text = "💳 Tarjeta de Débito"
        '
        'rdoCreditCard
        '
        Me.rdoCreditCard.BackColor = System.Drawing.Color.Transparent
        Me.rdoCreditCard.Checked = True
        Me.rdoCreditCard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoCreditCard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoCreditCard.ForeColor = System.Drawing.Color.Black
        Me.rdoCreditCard.Location = New System.Drawing.Point(15, 60)
        Me.rdoCreditCard.Name = "rdoCreditCard"
        Me.rdoCreditCard.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoCreditCard.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoCreditCard.Size = New System.Drawing.Size(220, 25)
        Me.rdoCreditCard.TabIndex = 0
        Me.rdoCreditCard.Text = "💳 Tarjeta de Crédito"
        '
        'grpGender
        '
        Me.grpGender.BackColor = System.Drawing.Color.White
        Me.grpGender.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.grpGender.Controls.Add(Me.rdoOther)
        Me.grpGender.Controls.Add(Me.rdoFemale)
        Me.grpGender.Controls.Add(Me.rdoMale)
        Me.grpGender.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpGender.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.grpGender.Location = New System.Drawing.Point(20, 176)
        Me.grpGender.Name = "grpGender"
        Me.grpGender.Padding = New System.Windows.Forms.Padding(15, 50, 15, 15)
        Me.grpGender.Size = New System.Drawing.Size(210, 200)
        Me.grpGender.TabIndex = 34
        Me.grpGender.Text = "Género"
        '
        'rdoMale
        '
        Me.rdoMale.BackColor = System.Drawing.Color.Transparent
        Me.rdoMale.Checked = True
        Me.rdoMale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoMale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoMale.ForeColor = System.Drawing.Color.Black
        Me.rdoMale.Location = New System.Drawing.Point(15, 60)
        Me.rdoMale.Name = "rdoMale"
        Me.rdoMale.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoMale.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoMale.Size = New System.Drawing.Size(220, 25)
        Me.rdoMale.TabIndex = 0
        Me.rdoMale.Text = "Masculino"
        '
        'rdoFemale
        '
        Me.rdoFemale.BackColor = System.Drawing.Color.Transparent
        Me.rdoFemale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoFemale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoFemale.ForeColor = System.Drawing.Color.Black
        Me.rdoFemale.Location = New System.Drawing.Point(15, 90)
        Me.rdoFemale.Name = "rdoFemale"
        Me.rdoFemale.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoFemale.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoFemale.Size = New System.Drawing.Size(177, 25)
        Me.rdoFemale.TabIndex = 1
        Me.rdoFemale.Text = "Femenino"
        '
        'rdoOther
        '
        Me.rdoOther.BackColor = System.Drawing.Color.Transparent
        Me.rdoOther.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoOther.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoOther.ForeColor = System.Drawing.Color.Black
        Me.rdoOther.Location = New System.Drawing.Point(15, 120)
        Me.rdoOther.Name = "rdoOther"
        Me.rdoOther.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoOther.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoOther.Size = New System.Drawing.Size(220, 25)
        Me.rdoOther.TabIndex = 2
        Me.rdoOther.Text = "Otro"
        '
        'FormThemeDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 620)
        Me.Controls.Add(Me.pnlCheckBoxes)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.grpGender)
        Me.Controls.Add(Me.grpPayment)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FormThemeDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo de Temas - NeoSoft.UI"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlCheckBoxes.ResumeLayout(False)
        Me.grpPayment.ResumeLayout(False)
        Me.grpGender.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As NXLabel
    Friend WithEvents pnlHeader As NXPanel
    Friend WithEvents btnApplyToAll As NXButton
    Friend WithEvents lblThemeDescription As NXLabel
    Friend WithEvents cboThemes As ComboBox
    Friend WithEvents lblSelectTheme As NXLabel
    Friend WithEvents pnlCheckBoxes As NXPanel
    Friend WithEvents chkButton As NXCheckBox
    Friend WithEvents chkSwitch As NXCheckBox
    Friend WithEvents chkStandard As NXCheckBox
    Friend WithEvents lblCheckBoxSection As NXLabel
    Friend WithEvents grpPayment As NXGroup
    Friend WithEvents rdoCreditCard As NXRadioButton
    Friend WithEvents rdoDebitCard As NXRadioButton
    Friend WithEvents rdoCash As NXRadioButton
    Friend WithEvents rdoTransfer As NXRadioButton
    Friend WithEvents grpGender As NXGroup
    Friend WithEvents rdoOther As NXRadioButton
    Friend WithEvents rdoFemale As NXRadioButton
    Friend WithEvents rdoMale As NXRadioButton
End Class