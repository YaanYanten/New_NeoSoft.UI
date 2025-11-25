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
        Dim NxRadioGroupItem7 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem8 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem9 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem10 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem11 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim NxRadioGroupItem12 As NeoSoft.UI.Controls.NXRadioGroupItem = New NeoSoft.UI.Controls.NXRadioGroupItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormThemeDemo))
        Me.pnlToggleAndSeparator = New NeoSoft.UI.Controls.NXPanel()
        Me.tglAirplaneMode = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.tglBluetooth = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.tglWiFi = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.sepVertical1 = New NeoSoft.UI.Controls.NXSeparator()
        Me.tglAutoSave = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.lblToggleSounds = New NeoSoft.UI.Controls.NXLabel()
        Me.tglSounds = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.lblToggleDarkMode = New NeoSoft.UI.Controls.NXLabel()
        Me.tglDarkMode = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.lblToggleBasic = New NeoSoft.UI.Controls.NXLabel()
        Me.tglNotifications = New NeoSoft.UI.Controls.NXToggleSwitch()
        Me.sepDashed = New NeoSoft.UI.Controls.NXSeparator()
        Me.sepGradient = New NeoSoft.UI.Controls.NXSeparator()
        Me.sepWithText = New NeoSoft.UI.Controls.NXSeparator()
        Me.lblSeparatorDemo = New NeoSoft.UI.Controls.NXLabel()
        Me.sepHorizontal1 = New NeoSoft.UI.Controls.NXSeparator()
        Me.lblToggleSwitchSection = New NeoSoft.UI.Controls.NXLabel()
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
        Me.pnlToggleAndSeparator.SuspendLayout()
        Me.pnlRadioGroups.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.grpGender.SuspendLayout()
        Me.grpPayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToggleAndSeparator
        '
        Me.pnlToggleAndSeparator.BackColor = System.Drawing.Color.White
        Me.pnlToggleAndSeparator.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlToggleAndSeparator.BorderRadius = 4
        Me.pnlToggleAndSeparator.BorderSize = 1
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglAirplaneMode)
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglBluetooth)
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglWiFi)
        Me.pnlToggleAndSeparator.Controls.Add(Me.sepVertical1)
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglAutoSave)
        Me.pnlToggleAndSeparator.Controls.Add(Me.lblToggleSounds)
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglSounds)
        Me.pnlToggleAndSeparator.Controls.Add(Me.lblToggleDarkMode)
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglDarkMode)
        Me.pnlToggleAndSeparator.Controls.Add(Me.lblToggleBasic)
        Me.pnlToggleAndSeparator.Controls.Add(Me.tglNotifications)
        Me.pnlToggleAndSeparator.Controls.Add(Me.sepDashed)
        Me.pnlToggleAndSeparator.Controls.Add(Me.sepGradient)
        Me.pnlToggleAndSeparator.Controls.Add(Me.sepWithText)
        Me.pnlToggleAndSeparator.Controls.Add(Me.lblSeparatorDemo)
        Me.pnlToggleAndSeparator.Controls.Add(Me.sepHorizontal1)
        Me.pnlToggleAndSeparator.Controls.Add(Me.lblToggleSwitchSection)
        Me.pnlToggleAndSeparator.GradientColor1 = System.Drawing.Color.White
        Me.pnlToggleAndSeparator.GradientColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlToggleAndSeparator.Location = New System.Drawing.Point(510, 176)
        Me.pnlToggleAndSeparator.Name = "pnlToggleAndSeparator"
        Me.pnlToggleAndSeparator.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlToggleAndSeparator.ScrollBarColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.pnlToggleAndSeparator.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlToggleAndSeparator.ShowShadow = True
        Me.pnlToggleAndSeparator.Size = New System.Drawing.Size(470, 414)
        Me.pnlToggleAndSeparator.TabIndex = 37
        Me.pnlToggleAndSeparator.UseTheme = True
        '
        'tglAirplaneMode
        '
        Me.tglAirplaneMode.BackColor = System.Drawing.Color.White
        Me.tglAirplaneMode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.tglAirplaneMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglAirplaneMode.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tglAirplaneMode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglAirplaneMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglAirplaneMode.GlyphAlignment = NeoSoft.UI.Controls.NXToggleSwitch.SwitchAlignment.Far
        Me.tglAirplaneMode.Location = New System.Drawing.Point(270, 260)
        Me.tglAirplaneMode.Name = "tglAirplaneMode"
        Me.tglAirplaneMode.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglAirplaneMode.OnColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.tglAirplaneMode.ShowText = True
        Me.tglAirplaneMode.Size = New System.Drawing.Size(152, 25)
        Me.tglAirplaneMode.TabIndex = 16
        Me.tglAirplaneMode.TextOff = "Modo Avión"
        Me.tglAirplaneMode.TextOn = "Modo Avión"
        Me.tglAirplaneMode.ThumbColor = System.Drawing.Color.White
        '
        'tglBluetooth
        '
        Me.tglBluetooth.BackColor = System.Drawing.Color.White
        Me.tglBluetooth.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.tglBluetooth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglBluetooth.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tglBluetooth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglBluetooth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglBluetooth.GlyphAlignment = NeoSoft.UI.Controls.NXToggleSwitch.SwitchAlignment.Far
        Me.tglBluetooth.Location = New System.Drawing.Point(270, 225)
        Me.tglBluetooth.Name = "tglBluetooth"
        Me.tglBluetooth.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglBluetooth.OnColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.tglBluetooth.ShowText = True
        Me.tglBluetooth.Size = New System.Drawing.Size(152, 25)
        Me.tglBluetooth.TabIndex = 15
        Me.tglBluetooth.TextOff = "Bluetooth"
        Me.tglBluetooth.TextOn = "Bluetooth"
        Me.tglBluetooth.ThumbColor = System.Drawing.Color.White
        '
        'tglWiFi
        '
        Me.tglWiFi.BackColor = System.Drawing.Color.White
        Me.tglWiFi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.tglWiFi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglWiFi.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tglWiFi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglWiFi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglWiFi.GlyphAlignment = NeoSoft.UI.Controls.NXToggleSwitch.SwitchAlignment.Far
        Me.tglWiFi.IsOn = True
        Me.tglWiFi.Location = New System.Drawing.Point(270, 190)
        Me.tglWiFi.Name = "tglWiFi"
        Me.tglWiFi.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglWiFi.OnColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.tglWiFi.ShowText = True
        Me.tglWiFi.Size = New System.Drawing.Size(152, 25)
        Me.tglWiFi.TabIndex = 14
        Me.tglWiFi.TextOff = "WiFi"
        Me.tglWiFi.TextOn = "WiFi"
        Me.tglWiFi.ThumbColor = System.Drawing.Color.White
        '
        'sepVertical1
        '
        Me.sepVertical1.BackColor = System.Drawing.Color.White
        Me.sepVertical1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.sepVertical1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.sepVertical1.LineColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepVertical1.LineGradientColor1 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepVertical1.LineGradientColor2 = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.sepVertical1.Location = New System.Drawing.Point(230, 190)
        Me.sepVertical1.Name = "sepVertical1"
        Me.sepVertical1.Orientation = NeoSoft.UI.Controls.NXSeparator.SeparatorOrientation.Vertical
        Me.sepVertical1.Size = New System.Drawing.Size(20, 140)
        Me.sepVertical1.TabIndex = 13
        Me.sepVertical1.TextBackColor = System.Drawing.Color.Transparent
        Me.sepVertical1.UseTheme = True
        '
        'tglAutoSave
        '
        Me.tglAutoSave.BackColor = System.Drawing.Color.White
        Me.tglAutoSave.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglAutoSave.BorderRadius = 10
        Me.tglAutoSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglAutoSave.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.tglAutoSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglAutoSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglAutoSave.Location = New System.Drawing.Point(15, 305)
        Me.tglAutoSave.Name = "tglAutoSave"
        Me.tglAutoSave.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglAutoSave.OnColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.tglAutoSave.ShowText = True
        Me.tglAutoSave.Size = New System.Drawing.Size(40, 20)
        Me.tglAutoSave.SwitchHeight = 20
        Me.tglAutoSave.SwitchSize = NeoSoft.UI.Controls.NXToggleSwitch.ToggleSize.Small
        Me.tglAutoSave.SwitchWidth = 40
        Me.tglAutoSave.TabIndex = 12
        Me.tglAutoSave.TextOff = "Autoguardado"
        Me.tglAutoSave.TextOn = "Autoguardado"
        Me.tglAutoSave.ThumbColor = System.Drawing.Color.White
        Me.tglAutoSave.UseTheme = True
        '
        'lblToggleSounds
        '
        Me.lblToggleSounds.BackColor = System.Drawing.Color.Transparent
        Me.lblToggleSounds.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblToggleSounds.BorderRadius = 4
        Me.lblToggleSounds.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblToggleSounds.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblToggleSounds.GradientColor = System.Drawing.Color.Empty
        Me.lblToggleSounds.Location = New System.Drawing.Point(15, 260)
        Me.lblToggleSounds.Name = "lblToggleSounds"
        Me.lblToggleSounds.OutlineColor = System.Drawing.Color.Black
        Me.lblToggleSounds.Padding = New System.Windows.Forms.Padding(5)
        Me.lblToggleSounds.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToggleSounds.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblToggleSounds.Size = New System.Drawing.Size(100, 25)
        Me.lblToggleSounds.TabIndex = 10
        Me.lblToggleSounds.Text = "Sonidos:"
        Me.lblToggleSounds.UseTheme = True
        '
        'tglSounds
        '
        Me.tglSounds.BackColor = System.Drawing.Color.White
        Me.tglSounds.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.tglSounds.BorderRadius = 15
        Me.tglSounds.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglSounds.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tglSounds.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglSounds.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglSounds.IsOn = True
        Me.tglSounds.Location = New System.Drawing.Point(120, 260)
        Me.tglSounds.Name = "tglSounds"
        Me.tglSounds.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglSounds.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tglSounds.Size = New System.Drawing.Size(60, 30)
        Me.tglSounds.SwitchHeight = 30
        Me.tglSounds.SwitchSize = NeoSoft.UI.Controls.NXToggleSwitch.ToggleSize.Large
        Me.tglSounds.SwitchWidth = 60
        Me.tglSounds.TabIndex = 11
        Me.tglSounds.ThumbColor = System.Drawing.Color.White
        '
        'lblToggleDarkMode
        '
        Me.lblToggleDarkMode.BackColor = System.Drawing.Color.Transparent
        Me.lblToggleDarkMode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblToggleDarkMode.BorderRadius = 4
        Me.lblToggleDarkMode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblToggleDarkMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblToggleDarkMode.GradientColor = System.Drawing.Color.Empty
        Me.lblToggleDarkMode.Location = New System.Drawing.Point(15, 225)
        Me.lblToggleDarkMode.Name = "lblToggleDarkMode"
        Me.lblToggleDarkMode.OutlineColor = System.Drawing.Color.Black
        Me.lblToggleDarkMode.Padding = New System.Windows.Forms.Padding(5)
        Me.lblToggleDarkMode.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToggleDarkMode.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblToggleDarkMode.Size = New System.Drawing.Size(100, 25)
        Me.lblToggleDarkMode.TabIndex = 8
        Me.lblToggleDarkMode.Text = "Modo Oscuro:"
        Me.lblToggleDarkMode.UseTheme = True
        '
        'tglDarkMode
        '
        Me.tglDarkMode.BackColor = System.Drawing.Color.White
        Me.tglDarkMode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.tglDarkMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglDarkMode.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tglDarkMode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglDarkMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglDarkMode.Location = New System.Drawing.Point(120, 225)
        Me.tglDarkMode.Name = "tglDarkMode"
        Me.tglDarkMode.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglDarkMode.OnColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.tglDarkMode.Size = New System.Drawing.Size(50, 25)
        Me.tglDarkMode.TabIndex = 9
        Me.tglDarkMode.ThumbColor = System.Drawing.Color.White
        '
        'lblToggleBasic
        '
        Me.lblToggleBasic.BackColor = System.Drawing.Color.Transparent
        Me.lblToggleBasic.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblToggleBasic.BorderRadius = 4
        Me.lblToggleBasic.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblToggleBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblToggleBasic.GradientColor = System.Drawing.Color.Empty
        Me.lblToggleBasic.Location = New System.Drawing.Point(15, 190)
        Me.lblToggleBasic.Name = "lblToggleBasic"
        Me.lblToggleBasic.OutlineColor = System.Drawing.Color.Black
        Me.lblToggleBasic.Padding = New System.Windows.Forms.Padding(5)
        Me.lblToggleBasic.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToggleBasic.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblToggleBasic.Size = New System.Drawing.Size(100, 25)
        Me.lblToggleBasic.TabIndex = 6
        Me.lblToggleBasic.Text = "Notificaciones:"
        Me.lblToggleBasic.UseTheme = True
        '
        'tglNotifications
        '
        Me.tglNotifications.BackColor = System.Drawing.Color.White
        Me.tglNotifications.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglNotifications.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tglNotifications.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.tglNotifications.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglNotifications.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tglNotifications.IsOn = True
        Me.tglNotifications.Location = New System.Drawing.Point(120, 190)
        Me.tglNotifications.Name = "tglNotifications"
        Me.tglNotifications.OffColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.tglNotifications.OnColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.tglNotifications.Size = New System.Drawing.Size(50, 25)
        Me.tglNotifications.TabIndex = 7
        Me.tglNotifications.ThumbColor = System.Drawing.Color.White
        Me.tglNotifications.UseTheme = True
        '
        'sepDashed
        '
        Me.sepDashed.BackColor = System.Drawing.Color.White
        Me.sepDashed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.sepDashed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.sepDashed.LineColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepDashed.LineGradientColor1 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepDashed.LineGradientColor2 = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.sepDashed.LineStyleType = NeoSoft.UI.Controls.NXSeparator.LineStyle.Dashed
        Me.sepDashed.LineThickness = 2
        Me.sepDashed.Location = New System.Drawing.Point(15, 150)
        Me.sepDashed.Name = "sepDashed"
        Me.sepDashed.ShowText = True
        Me.sepDashed.Size = New System.Drawing.Size(440, 25)
        Me.sepDashed.TabIndex = 5
        Me.sepDashed.Text = "Línea Discontinua"
        Me.sepDashed.TextAlign = NeoSoft.UI.Controls.NXSeparator.TextAlignment.Right
        Me.sepDashed.TextBackColor = System.Drawing.Color.Transparent
        Me.sepDashed.UseTheme = True
        '
        'sepGradient
        '
        Me.sepGradient.BackColor = System.Drawing.Color.White
        Me.sepGradient.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.sepGradient.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.sepGradient.LineColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepGradient.LineColorStyleType = NeoSoft.UI.Controls.NXSeparator.LineColorStyle.Gradient
        Me.sepGradient.LineGradientColor1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.sepGradient.LineGradientColor2 = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.sepGradient.LineThickness = 2
        Me.sepGradient.Location = New System.Drawing.Point(15, 120)
        Me.sepGradient.Name = "sepGradient"
        Me.sepGradient.ShowText = True
        Me.sepGradient.Size = New System.Drawing.Size(440, 25)
        Me.sepGradient.TabIndex = 4
        Me.sepGradient.Text = "Gradiente"
        Me.sepGradient.TextAlign = NeoSoft.UI.Controls.NXSeparator.TextAlignment.Left
        Me.sepGradient.TextBackColor = System.Drawing.Color.White
        '
        'sepWithText
        '
        Me.sepWithText.BackColor = System.Drawing.Color.White
        Me.sepWithText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.sepWithText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.sepWithText.LineColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepWithText.LineGradientColor1 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepWithText.LineGradientColor2 = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.sepWithText.Location = New System.Drawing.Point(15, 90)
        Me.sepWithText.Name = "sepWithText"
        Me.sepWithText.ShowText = True
        Me.sepWithText.Size = New System.Drawing.Size(440, 25)
        Me.sepWithText.TabIndex = 3
        Me.sepWithText.Text = "Con Texto"
        Me.sepWithText.TextBackColor = System.Drawing.Color.Transparent
        Me.sepWithText.UseTheme = True
        '
        'lblSeparatorDemo
        '
        Me.lblSeparatorDemo.BackColor = System.Drawing.Color.Transparent
        Me.lblSeparatorDemo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSeparatorDemo.BorderRadius = 4
        Me.lblSeparatorDemo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeparatorDemo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSeparatorDemo.GradientColor = System.Drawing.Color.Empty
        Me.lblSeparatorDemo.Location = New System.Drawing.Point(15, 60)
        Me.lblSeparatorDemo.Name = "lblSeparatorDemo"
        Me.lblSeparatorDemo.OutlineColor = System.Drawing.Color.Black
        Me.lblSeparatorDemo.Padding = New System.Windows.Forms.Padding(5)
        Me.lblSeparatorDemo.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSeparatorDemo.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblSeparatorDemo.Size = New System.Drawing.Size(150, 25)
        Me.lblSeparatorDemo.TabIndex = 2
        Me.lblSeparatorDemo.Text = "Separadores:"
        Me.lblSeparatorDemo.UseTheme = True
        '
        'sepHorizontal1
        '
        Me.sepHorizontal1.BackColor = System.Drawing.Color.White
        Me.sepHorizontal1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.sepHorizontal1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.sepHorizontal1.LineColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepHorizontal1.LineGradientColor1 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.sepHorizontal1.LineGradientColor2 = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.sepHorizontal1.Location = New System.Drawing.Point(15, 45)
        Me.sepHorizontal1.Name = "sepHorizontal1"
        Me.sepHorizontal1.Size = New System.Drawing.Size(440, 10)
        Me.sepHorizontal1.TabIndex = 1
        Me.sepHorizontal1.TextBackColor = System.Drawing.Color.Transparent
        Me.sepHorizontal1.UseTheme = True
        '
        'lblToggleSwitchSection
        '
        Me.lblToggleSwitchSection.BackColor = System.Drawing.Color.Transparent
        Me.lblToggleSwitchSection.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblToggleSwitchSection.BorderRadius = 4
        Me.lblToggleSwitchSection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblToggleSwitchSection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblToggleSwitchSection.GradientColor = System.Drawing.Color.Empty
        Me.lblToggleSwitchSection.Location = New System.Drawing.Point(15, 10)
        Me.lblToggleSwitchSection.Name = "lblToggleSwitchSection"
        Me.lblToggleSwitchSection.OutlineColor = System.Drawing.Color.Black
        Me.lblToggleSwitchSection.Padding = New System.Windows.Forms.Padding(5)
        Me.lblToggleSwitchSection.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToggleSwitchSection.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblToggleSwitchSection.Size = New System.Drawing.Size(440, 30)
        Me.lblToggleSwitchSection.TabIndex = 0
        Me.lblToggleSwitchSection.Text = "🎛️ NXToggleSwitch && ➖ NXSeparator"
        Me.lblToggleSwitchSection.UseTheme = True
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
        Me.pnlRadioGroups.GradientColor1 = System.Drawing.Color.White
        Me.pnlRadioGroups.GradientColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlRadioGroups.Location = New System.Drawing.Point(20, 390)
        Me.pnlRadioGroups.Name = "pnlRadioGroups"
        Me.pnlRadioGroups.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlRadioGroups.ScrollBarColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
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
        NxRadioGroupItem7.Tag = Nothing
        NxRadioGroupItem7.Text = "🔔 Todas"
        NxRadioGroupItem7.Value = "all"
        NxRadioGroupItem8.Tag = Nothing
        NxRadioGroupItem8.Text = "🔕 Solo importantes"
        NxRadioGroupItem8.Value = "important"
        NxRadioGroupItem9.Tag = Nothing
        NxRadioGroupItem9.Text = "⛔ Ninguna"
        NxRadioGroupItem9.Value = "none"
        Me.rgpNotifications.Items.Add(NxRadioGroupItem7)
        Me.rgpNotifications.Items.Add(NxRadioGroupItem8)
        Me.rgpNotifications.Items.Add(NxRadioGroupItem9)
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
        NxRadioGroupItem10.Tag = Nothing
        NxRadioGroupItem10.Text = "📅 Mensual - $9.99"
        NxRadioGroupItem10.Value = "monthly"
        NxRadioGroupItem11.Tag = Nothing
        NxRadioGroupItem11.Text = "📆 Anual - $99.99 (ahorra 17%)"
        NxRadioGroupItem11.Value = "yearly"
        NxRadioGroupItem12.Tag = Nothing
        NxRadioGroupItem12.Text = "🆓 Gratuito"
        NxRadioGroupItem12.Value = "free"
        Me.rgpSubscription.Items.Add(NxRadioGroupItem10)
        Me.rgpSubscription.Items.Add(NxRadioGroupItem11)
        Me.rgpSubscription.Items.Add(NxRadioGroupItem12)
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
        Me.pnlHeader.GradientColor1 = System.Drawing.Color.White
        Me.pnlHeader.GradientColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlHeader.Location = New System.Drawing.Point(20, 70)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlHeader.ScrollBarColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
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
        Me.Controls.Add(Me.pnlToggleAndSeparator)
        Me.Controls.Add(Me.pnlRadioGroups)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.grpGender)
        Me.Controls.Add(Me.grpPayment)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FormThemeDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo de Temas - NeoSoft.UI"
        Me.pnlToggleAndSeparator.ResumeLayout(False)
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
    Friend WithEvents pnlToggleAndSeparator As NXPanel
    Friend WithEvents lblToggleSwitchSection As NXLabel
    Friend WithEvents sepHorizontal1 As NXSeparator
    Friend WithEvents lblSeparatorDemo As NXLabel
    Friend WithEvents sepWithText As NXSeparator
    Friend WithEvents sepGradient As NXSeparator
    Friend WithEvents sepDashed As NXSeparator
    Friend WithEvents lblToggleBasic As NXLabel
    Friend WithEvents tglNotifications As NXToggleSwitch
    Friend WithEvents lblToggleDarkMode As NXLabel
    Friend WithEvents tglDarkMode As NXToggleSwitch
    Friend WithEvents lblToggleSounds As NXLabel
    Friend WithEvents tglSounds As NXToggleSwitch
    Friend WithEvents tglAutoSave As NXToggleSwitch
    Friend WithEvents sepVertical1 As NXSeparator
    Friend WithEvents tglWiFi As NXToggleSwitch
    Friend WithEvents tglBluetooth As NXToggleSwitch
    Friend WithEvents tglAirplaneMode As NXToggleSwitch
End Class