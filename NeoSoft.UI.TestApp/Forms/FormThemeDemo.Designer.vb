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
        Dim NxRadioGroupItem1 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem2 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem3 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem4 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem5 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem6 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormThemeDemo))
        Me.pnlRadioGroups = New NeoSoft.UI.Controls.NXPanel()
        Me.rgpNotifications = New NeoSoft.UI.Controls.NXRadioGroup()
        Me.rgpSubscription = New NeoSoft.UI.Controls.NXRadioGroup()
        Me.lblRadioGroupSection = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlHeader = New NeoSoft.UI.Controls.NXPanel()
        Me.btnApplyToAll = New NeoSoft.UI.Controls.NXButton()
        Me.lblThemeDescription = New NeoSoft.UI.Controls.NXLabel()
        Me.cboThemes = New System.Windows.Forms.ComboBox()
        Me.lblSelectTheme = New NeoSoft.UI.Controls.NXLabel()
        Me.grpGender = New NeoSoft.UI.Controls.NXGroup()
        Me.rdoOther = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoFemale = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoMale = New NeoSoft.UI.Controls.NXRadioButton()
        Me.grpPayment = New NeoSoft.UI.Controls.NXGroup()
        Me.rdoTransfer = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoCash = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoDebitCard = New NeoSoft.UI.Controls.NXRadioButton()
        Me.rdoCreditCard = New NeoSoft.UI.Controls.NXRadioButton()
        Me.lblTitle = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlRadioGroups.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.grpGender.SuspendLayout()
        Me.grpPayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRadioGroups
        '
        Me.pnlRadioGroups.BackColor = System.Drawing.Color.White
        Me.pnlRadioGroups.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlRadioGroups.BorderRadius = 4
        Me.pnlRadioGroups.BorderSize = 1
        Me.pnlRadioGroups.Controls.Add(Me.rgpNotifications)
        Me.pnlRadioGroups.Controls.Add(Me.rgpSubscription)
        Me.pnlRadioGroups.Controls.Add(Me.lblRadioGroupSection)
        Me.pnlRadioGroups.Location = New System.Drawing.Point(20, 390)
        Me.pnlRadioGroups.Name = "pnlRadioGroups"
        Me.pnlRadioGroups.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlRadioGroups.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlRadioGroups.ShowShadow = True
        Me.pnlRadioGroups.Size = New System.Drawing.Size(960, 200)
        Me.pnlRadioGroups.TabIndex = 36
        Me.pnlRadioGroups.UseTheme = True
        '
        'rgpNotifications
        '
        Me.rgpNotifications.BackColor = System.Drawing.Color.White
        Me.rgpNotifications.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rgpNotifications.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rgpNotifications.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        NxRadioGroupItem1.Tag = Nothing
        NxRadioGroupItem1.Text = "🔔 Todas"
        NxRadioGroupItem1.Value = "all"
        NxRadioGroupItem2.Tag = Nothing
        NxRadioGroupItem2.Text = "🔕 Solo importantes"
        NxRadioGroupItem2.Value = "important"
        NxRadioGroupItem3.Tag = Nothing
        NxRadioGroupItem3.Text = "⛔ Ninguna"
        NxRadioGroupItem3.Value = "none"
        Me.rgpNotifications.Items.Add(NxRadioGroupItem1)
        Me.rgpNotifications.Items.Add(NxRadioGroupItem2)
        Me.rgpNotifications.Items.Add(NxRadioGroupItem3)
        Me.rgpNotifications.Location = New System.Drawing.Point(330, 50)
        Me.rgpNotifications.Name = "rgpNotifications"
        Me.rgpNotifications.Padding = New System.Windows.Forms.Padding(10)
        Me.rgpNotifications.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rgpNotifications.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.rgpNotifications.SelectedIndex = 0
        Me.rgpNotifications.Size = New System.Drawing.Size(199, 130)
        Me.rgpNotifications.TabIndex = 2
        Me.rgpNotifications.UseTheme = True
        '
        'rgpSubscription
        '
        Me.rgpSubscription.BackColor = System.Drawing.Color.White
        Me.rgpSubscription.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rgpSubscription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rgpSubscription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        NxRadioGroupItem4.Tag = Nothing
        NxRadioGroupItem4.Text = "📅 Mensual - $9.99"
        NxRadioGroupItem4.Value = "monthly"
        NxRadioGroupItem5.Tag = Nothing
        NxRadioGroupItem5.Text = "📆 Anual - $99.99 (ahorra 17%)"
        NxRadioGroupItem5.Value = "yearly"
        NxRadioGroupItem6.Tag = Nothing
        NxRadioGroupItem6.Text = "🆓 Gratuito"
        NxRadioGroupItem6.Value = "free"
        Me.rgpSubscription.Items.Add(NxRadioGroupItem4)
        Me.rgpSubscription.Items.Add(NxRadioGroupItem5)
        Me.rgpSubscription.Items.Add(NxRadioGroupItem6)
        Me.rgpSubscription.Location = New System.Drawing.Point(15, 50)
        Me.rgpSubscription.Name = "rgpSubscription"
        Me.rgpSubscription.Padding = New System.Windows.Forms.Padding(10)
        Me.rgpSubscription.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rgpSubscription.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.rgpSubscription.SelectedIndex = 0
        Me.rgpSubscription.Size = New System.Drawing.Size(281, 130)
        Me.rgpSubscription.TabIndex = 1
        Me.rgpSubscription.UseTheme = True
        '
        'lblRadioGroupSection
        '
        Me.lblRadioGroupSection.BackColor = System.Drawing.Color.Transparent
        Me.lblRadioGroupSection.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblRadioGroupSection.BorderRadius = 4
        Me.lblRadioGroupSection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRadioGroupSection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblRadioGroupSection.GradientColor = System.Drawing.Color.Empty
        Me.lblRadioGroupSection.Location = New System.Drawing.Point(15, 10)
        Me.lblRadioGroupSection.Name = "lblRadioGroupSection"
        Me.lblRadioGroupSection.OutlineColor = System.Drawing.Color.Black
        Me.lblRadioGroupSection.Padding = New System.Windows.Forms.Padding(5)
        Me.lblRadioGroupSection.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRadioGroupSection.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblRadioGroupSection.Size = New System.Drawing.Size(930, 30)
        Me.lblRadioGroupSection.TabIndex = 0
        Me.lblRadioGroupSection.Text = "📻 NXRadioGroup - Estilo DevExpress"
        Me.lblRadioGroupSection.UseTheme = True
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
        'grpGender
        '
        Me.grpGender.Appearance.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.grpGender.Appearance.HeaderBackColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.grpGender.Appearance.HeaderIcon = Nothing
        Me.grpGender.Appearance.HeaderIconSize = New System.Drawing.Size(20, 20)
        Me.grpGender.Appearance.HoverBackColor = System.Drawing.Color.Empty
        Me.grpGender.Appearance.PressedBackColor = System.Drawing.Color.Empty
        Me.grpGender.Appearance.UseTheme = True
        Me.grpGender.BackColor = System.Drawing.Color.White
        Me.grpGender.Controls.Add(Me.rdoOther)
        Me.grpGender.Controls.Add(Me.rdoFemale)
        Me.grpGender.Controls.Add(Me.rdoMale)
        Me.grpGender.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpGender.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.grpGender.Location = New System.Drawing.Point(20, 176)
        Me.grpGender.Name = "grpGender"
        Me.grpGender.Padding = New System.Windows.Forms.Padding(15, 50, 15, 15)
        Me.grpGender.Size = New System.Drawing.Size(210, 200)
        Me.grpGender.TabIndex = 34
        Me.grpGender.Text = "Género"
        '
        'rdoOther
        '
        Me.rdoOther.BackColor = System.Drawing.Color.Transparent
        Me.rdoOther.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoOther.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoOther.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoOther.Location = New System.Drawing.Point(15, 120)
        Me.rdoOther.Name = "rdoOther"
        Me.rdoOther.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoOther.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoOther.Size = New System.Drawing.Size(220, 25)
        Me.rdoOther.TabIndex = 2
        Me.rdoOther.Text = "Otro"
        Me.rdoOther.UseTheme = True
        '
        'rdoFemale
        '
        Me.rdoFemale.BackColor = System.Drawing.Color.Transparent
        Me.rdoFemale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoFemale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoFemale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoFemale.Location = New System.Drawing.Point(15, 90)
        Me.rdoFemale.Name = "rdoFemale"
        Me.rdoFemale.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoFemale.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoFemale.Size = New System.Drawing.Size(177, 25)
        Me.rdoFemale.TabIndex = 1
        Me.rdoFemale.Text = "Femenino"
        Me.rdoFemale.UseTheme = True
        '
        'rdoMale
        '
        Me.rdoMale.BackColor = System.Drawing.Color.Transparent
        Me.rdoMale.Checked = True
        Me.rdoMale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoMale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoMale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoMale.Location = New System.Drawing.Point(15, 60)
        Me.rdoMale.Name = "rdoMale"
        Me.rdoMale.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoMale.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoMale.Size = New System.Drawing.Size(220, 25)
        Me.rdoMale.TabIndex = 0
        Me.rdoMale.Text = "Masculino"
        Me.rdoMale.UseTheme = True
        '
        'grpPayment
        '
        Me.grpPayment.Appearance.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.grpPayment.Appearance.HeaderBackColor2 = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.grpPayment.Appearance.HeaderIcon = CType(resources.GetObject("grpPayment.Appearance.HeaderIcon"), System.Drawing.Image)
        Me.grpPayment.Appearance.HeaderIconPosition = NeoSoft.UI.Design.NXAppearance.IconPosition.Right
        Me.grpPayment.Appearance.HeaderIconSize = New System.Drawing.Size(20, 20)
        Me.grpPayment.Appearance.HoverBackColor = System.Drawing.Color.Empty
        Me.grpPayment.Appearance.PressedBackColor = System.Drawing.Color.Empty
        Me.grpPayment.Appearance.UseTheme = True
        Me.grpPayment.BackColor = System.Drawing.Color.White
        Me.grpPayment.Controls.Add(Me.rdoTransfer)
        Me.grpPayment.Controls.Add(Me.rdoCash)
        Me.grpPayment.Controls.Add(Me.rdoDebitCard)
        Me.grpPayment.Controls.Add(Me.rdoCreditCard)
        Me.grpPayment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
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
        Me.rdoTransfer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoTransfer.Location = New System.Drawing.Point(15, 150)
        Me.rdoTransfer.Name = "rdoTransfer"
        Me.rdoTransfer.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoTransfer.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoTransfer.Size = New System.Drawing.Size(220, 25)
        Me.rdoTransfer.TabIndex = 3
        Me.rdoTransfer.Text = "🏦 Transferencia"
        Me.rdoTransfer.UseTheme = True
        '
        'rdoCash
        '
        Me.rdoCash.BackColor = System.Drawing.Color.Transparent
        Me.rdoCash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoCash.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoCash.Location = New System.Drawing.Point(15, 120)
        Me.rdoCash.Name = "rdoCash"
        Me.rdoCash.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoCash.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoCash.Size = New System.Drawing.Size(220, 25)
        Me.rdoCash.TabIndex = 2
        Me.rdoCash.Text = "💵 Efectivo"
        Me.rdoCash.UseTheme = True
        '
        'rdoDebitCard
        '
        Me.rdoDebitCard.BackColor = System.Drawing.Color.Transparent
        Me.rdoDebitCard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoDebitCard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoDebitCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoDebitCard.Location = New System.Drawing.Point(15, 90)
        Me.rdoDebitCard.Name = "rdoDebitCard"
        Me.rdoDebitCard.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoDebitCard.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoDebitCard.Size = New System.Drawing.Size(220, 25)
        Me.rdoDebitCard.TabIndex = 1
        Me.rdoDebitCard.Text = "💳 Tarjeta de Débito"
        Me.rdoDebitCard.UseTheme = True
        '
        'rdoCreditCard
        '
        Me.rdoCreditCard.BackColor = System.Drawing.Color.Transparent
        Me.rdoCreditCard.Checked = True
        Me.rdoCreditCard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdoCreditCard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoCreditCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.rdoCreditCard.Location = New System.Drawing.Point(15, 60)
        Me.rdoCreditCard.Name = "rdoCreditCard"
        Me.rdoCreditCard.RadioColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.rdoCreditCard.RadioColorUnchecked = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rdoCreditCard.Size = New System.Drawing.Size(220, 25)
        Me.rdoCreditCard.TabIndex = 0
        Me.rdoCreditCard.Text = "💳 Tarjeta de Crédito"
        Me.rdoCreditCard.UseTheme = True
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
        'FormThemeDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 610)
        Me.Controls.Add(Me.pnlRadioGroups)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.grpGender)
        Me.Controls.Add(Me.grpPayment)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FormThemeDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo de Temas - NeoSoft.UI"
        Me.pnlRadioGroups.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.grpGender.ResumeLayout(False)
        Me.grpPayment.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As NXLabel
    Friend WithEvents pnlHeader As NXPanel
    Friend WithEvents btnApplyToAll As NXButton
    Friend WithEvents lblThemeDescription As NXLabel
    Friend WithEvents cboThemes As ComboBox
    Friend WithEvents lblSelectTheme As NXLabel
    Friend WithEvents grpPayment As NXGroup
    Friend WithEvents rdoCreditCard As NXRadioButton
    Friend WithEvents rdoDebitCard As NXRadioButton
    Friend WithEvents rdoCash As NXRadioButton
    Friend WithEvents rdoTransfer As NXRadioButton
    Friend WithEvents grpGender As NXGroup
    Friend WithEvents rdoOther As NXRadioButton
    Friend WithEvents rdoFemale As NXRadioButton
    Friend WithEvents rdoMale As NXRadioButton
    Friend WithEvents pnlRadioGroups As NXPanel
    Friend WithEvents lblRadioGroupSection As NXLabel
    Friend WithEvents rgpSubscription As NXRadioGroup
    Friend WithEvents rgpNotifications As NXRadioGroup
End Class