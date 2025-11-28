<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNXControlTest1
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblMainTitle = New System.Windows.Forms.Label()
        Me.tabControlMain = New System.Windows.Forms.TabControl()
        Me.tabFormats = New System.Windows.Forms.TabPage()
        Me.lblFormatTitle = New System.Windows.Forms.Label()
        Me.lblInteger = New System.Windows.Forms.Label()
        Me.numInteger = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblIntegerDesc = New System.Windows.Forms.Label()
        Me.lblIntegerValue = New System.Windows.Forms.Label()
        Me.lblDecimal = New System.Windows.Forms.Label()
        Me.numDecimal = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblDecimalDesc = New System.Windows.Forms.Label()
        Me.lblDecimalValue = New System.Windows.Forms.Label()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.numCurrency = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblCurrencyDesc = New System.Windows.Forms.Label()
        Me.lblCurrencyValue = New System.Windows.Forms.Label()
        Me.lblPercentage = New System.Windows.Forms.Label()
        Me.numPercentage = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblPercentageDesc = New System.Windows.Forms.Label()
        Me.lblPercentageValue = New System.Windows.Forms.Label()
        Me.tabMasks = New System.Windows.Forms.TabPage()
        Me.tabValidation = New System.Windows.Forms.TabPage()
        Me.tabCustomization = New System.Windows.Forms.TabPage()
        Me.lblMaskTitle = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.numPhone = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblPhoneDesc = New System.Windows.Forms.Label()
        Me.lblPhoneValue = New System.Windows.Forms.Label()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.numZip = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblZipDesc = New System.Windows.Forms.Label()
        Me.lblZipValue = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.numTime = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblTimeDesc = New System.Windows.Forms.Label()
        Me.lblTimeValue = New System.Windows.Forms.Label()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.numIP = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblIPDesc = New System.Windows.Forms.Label()
        Me.lblIPValue = New System.Windows.Forms.Label()
        Me.lblValidationTitle = New System.Windows.Forms.Label()
        Me.lblRange = New System.Windows.Forms.Label()
        Me.numRange = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblRangeDesc = New System.Windows.Forms.Label()
        Me.lblRangeValue = New System.Windows.Forms.Label()
        Me.lblWrap = New System.Windows.Forms.Label()
        Me.numWrap = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblWrapDesc = New System.Windows.Forms.Label()
        Me.lblWrapValue = New System.Windows.Forms.Label()
        Me.lblNegative = New System.Windows.Forms.Label()
        Me.numNegative = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblNegativeDesc = New System.Windows.Forms.Label()
        Me.lblNegativeValue = New System.Windows.Forms.Label()
        Me.lblPositive = New System.Windows.Forms.Label()
        Me.numPositive = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblPositiveDesc = New System.Windows.Forms.Label()
        Me.lblPositiveValue = New System.Windows.Forms.Label()
        Me.lblCustomTitle = New System.Windows.Forms.Label()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.numPrefix = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblPrefixDesc = New System.Windows.Forms.Label()
        Me.lblPrefixValue = New System.Windows.Forms.Label()
        Me.lblSuffix = New System.Windows.Forms.Label()
        Me.numSuffix = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblSuffixDesc = New System.Windows.Forms.Label()
        Me.lblSuffixValue = New System.Windows.Forms.Label()
        Me.lblReadOnly = New System.Windows.Forms.Label()
        Me.numReadOnly = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblReadOnlyDesc = New System.Windows.Forms.Label()
        Me.lblReadOnlyValue = New System.Windows.Forms.Label()
        Me.lblIncrement = New System.Windows.Forms.Label()
        Me.numIncrement = New NeoSoft.UI.Controls.NXNumericUpDown()
        Me.lblIncrementDesc = New System.Windows.Forms.Label()
        Me.lblIncrementValue = New System.Windows.Forms.Label()
        Me.tabControlMain.SuspendLayout()
        Me.tabFormats.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMainTitle
        '
        Me.lblMainTitle.AutoSize = True
        Me.lblMainTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblMainTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblMainTitle.Name = "lblMainTitle"
        Me.lblMainTitle.Size = New System.Drawing.Size(368, 30)
        Me.lblMainTitle.TabIndex = 0
        Me.lblMainTitle.Text = "NeoSoft.UI - Pruebas de Controles"
        '
        'tabControlMain
        '
        Me.tabControlMain.Controls.Add(Me.tabFormats)
        Me.tabControlMain.Controls.Add(Me.tabMasks)
        Me.tabControlMain.Controls.Add(Me.tabValidation)
        Me.tabControlMain.Controls.Add(Me.tabCustomization)
        Me.tabControlMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tabControlMain.Location = New System.Drawing.Point(20, 70)
        Me.tabControlMain.Name = "tabControlMain"
        Me.tabControlMain.SelectedIndex = 0
        Me.tabControlMain.Size = New System.Drawing.Size(860, 745)
        Me.tabControlMain.TabIndex = 1
        '
        'tabFormats
        '
        Me.tabFormats.BackColor = System.Drawing.Color.White
        Me.tabFormats.Controls.Add(Me.lblCustomTitle)
        Me.tabFormats.Controls.Add(Me.lblPrefix)
        Me.tabFormats.Controls.Add(Me.numPrefix)
        Me.tabFormats.Controls.Add(Me.lblPrefixDesc)
        Me.tabFormats.Controls.Add(Me.lblPrefixValue)
        Me.tabFormats.Controls.Add(Me.lblSuffix)
        Me.tabFormats.Controls.Add(Me.numSuffix)
        Me.tabFormats.Controls.Add(Me.lblSuffixDesc)
        Me.tabFormats.Controls.Add(Me.lblSuffixValue)
        Me.tabFormats.Controls.Add(Me.lblReadOnly)
        Me.tabFormats.Controls.Add(Me.numReadOnly)
        Me.tabFormats.Controls.Add(Me.lblReadOnlyDesc)
        Me.tabFormats.Controls.Add(Me.lblReadOnlyValue)
        Me.tabFormats.Controls.Add(Me.lblIncrement)
        Me.tabFormats.Controls.Add(Me.numIncrement)
        Me.tabFormats.Controls.Add(Me.lblIncrementDesc)
        Me.tabFormats.Controls.Add(Me.lblIncrementValue)
        Me.tabFormats.Controls.Add(Me.lblValidationTitle)
        Me.tabFormats.Controls.Add(Me.lblRange)
        Me.tabFormats.Controls.Add(Me.numRange)
        Me.tabFormats.Controls.Add(Me.lblRangeDesc)
        Me.tabFormats.Controls.Add(Me.lblRangeValue)
        Me.tabFormats.Controls.Add(Me.lblWrap)
        Me.tabFormats.Controls.Add(Me.numWrap)
        Me.tabFormats.Controls.Add(Me.lblWrapDesc)
        Me.tabFormats.Controls.Add(Me.lblWrapValue)
        Me.tabFormats.Controls.Add(Me.lblNegative)
        Me.tabFormats.Controls.Add(Me.numNegative)
        Me.tabFormats.Controls.Add(Me.lblNegativeDesc)
        Me.tabFormats.Controls.Add(Me.lblNegativeValue)
        Me.tabFormats.Controls.Add(Me.lblPositive)
        Me.tabFormats.Controls.Add(Me.numPositive)
        Me.tabFormats.Controls.Add(Me.lblPositiveDesc)
        Me.tabFormats.Controls.Add(Me.lblPositiveValue)
        Me.tabFormats.Controls.Add(Me.lblMaskTitle)
        Me.tabFormats.Controls.Add(Me.lblPhone)
        Me.tabFormats.Controls.Add(Me.numPhone)
        Me.tabFormats.Controls.Add(Me.lblPhoneDesc)
        Me.tabFormats.Controls.Add(Me.lblPhoneValue)
        Me.tabFormats.Controls.Add(Me.lblZip)
        Me.tabFormats.Controls.Add(Me.numZip)
        Me.tabFormats.Controls.Add(Me.lblZipDesc)
        Me.tabFormats.Controls.Add(Me.lblZipValue)
        Me.tabFormats.Controls.Add(Me.lblTime)
        Me.tabFormats.Controls.Add(Me.numTime)
        Me.tabFormats.Controls.Add(Me.lblTimeDesc)
        Me.tabFormats.Controls.Add(Me.lblTimeValue)
        Me.tabFormats.Controls.Add(Me.lblIP)
        Me.tabFormats.Controls.Add(Me.numIP)
        Me.tabFormats.Controls.Add(Me.lblIPDesc)
        Me.tabFormats.Controls.Add(Me.lblIPValue)
        Me.tabFormats.Controls.Add(Me.lblFormatTitle)
        Me.tabFormats.Controls.Add(Me.lblInteger)
        Me.tabFormats.Controls.Add(Me.numInteger)
        Me.tabFormats.Controls.Add(Me.lblIntegerDesc)
        Me.tabFormats.Controls.Add(Me.lblIntegerValue)
        Me.tabFormats.Controls.Add(Me.lblDecimal)
        Me.tabFormats.Controls.Add(Me.numDecimal)
        Me.tabFormats.Controls.Add(Me.lblDecimalDesc)
        Me.tabFormats.Controls.Add(Me.lblDecimalValue)
        Me.tabFormats.Controls.Add(Me.lblCurrency)
        Me.tabFormats.Controls.Add(Me.numCurrency)
        Me.tabFormats.Controls.Add(Me.lblCurrencyDesc)
        Me.tabFormats.Controls.Add(Me.lblCurrencyValue)
        Me.tabFormats.Controls.Add(Me.lblPercentage)
        Me.tabFormats.Controls.Add(Me.numPercentage)
        Me.tabFormats.Controls.Add(Me.lblPercentageDesc)
        Me.tabFormats.Controls.Add(Me.lblPercentageValue)
        Me.tabFormats.Location = New System.Drawing.Point(4, 24)
        Me.tabFormats.Name = "tabFormats"
        Me.tabFormats.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFormats.Size = New System.Drawing.Size(852, 717)
        Me.tabFormats.TabIndex = 0
        Me.tabFormats.Text = "NXNumericUPDown Control"
        '
        'lblFormatTitle
        '
        Me.lblFormatTitle.AutoSize = True
        Me.lblFormatTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblFormatTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblFormatTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblFormatTitle.Name = "lblFormatTitle"
        Me.lblFormatTitle.Size = New System.Drawing.Size(380, 21)
        Me.lblFormatTitle.TabIndex = 0
        Me.lblFormatTitle.Text = "NXNumericUpDown - Formatos de Visualización"
        '
        'lblInteger
        '
        Me.lblInteger.AutoSize = True
        Me.lblInteger.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInteger.Location = New System.Drawing.Point(20, 70)
        Me.lblInteger.Name = "lblInteger"
        Me.lblInteger.Size = New System.Drawing.Size(47, 15)
        Me.lblInteger.TabIndex = 1
        Me.lblInteger.Text = "Entero:"
        '
        'numInteger
        '
        Me.numInteger.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numInteger.AllowNegative = True
        Me.numInteger.BackColor = System.Drawing.Color.White
        Me.numInteger.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numInteger.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numInteger.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numInteger.DecimalPlaces = 2
        Me.numInteger.EnableMouseWheel = True
        Me.numInteger.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numInteger.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numInteger.ForeColor = System.Drawing.Color.Black
        Me.numInteger.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numInteger.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numInteger.Location = New System.Drawing.Point(20, 92)
        Me.numInteger.Mask = ""
        Me.numInteger.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numInteger.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numInteger.Name = "numInteger"
        Me.numInteger.Prefix = ""
        Me.numInteger.ReadOnly = False
        Me.numInteger.Size = New System.Drawing.Size(190, 28)
        Me.numInteger.Suffix = ""
        Me.numInteger.TabIndex = 2
        Me.numInteger.ThousandsSeparator = True
        Me.numInteger.UseMask = False
        Me.numInteger.Value = New Decimal(New Integer() {42, 0, 0, 0})
        Me.numInteger.WrapValue = False
        '
        'lblIntegerDesc
        '
        Me.lblIntegerDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblIntegerDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblIntegerDesc.Location = New System.Drawing.Point(20, 125)
        Me.lblIntegerDesc.Name = "lblIntegerDesc"
        Me.lblIntegerDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblIntegerDesc.TabIndex = 3
        Me.lblIntegerDesc.Text = "Números enteros sin decimales"
        '
        'lblIntegerValue
        '
        Me.lblIntegerValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblIntegerValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblIntegerValue.Location = New System.Drawing.Point(20, 155)
        Me.lblIntegerValue.Name = "lblIntegerValue"
        Me.lblIntegerValue.Size = New System.Drawing.Size(190, 15)
        Me.lblIntegerValue.TabIndex = 4
        Me.lblIntegerValue.Text = "Valor: 42"
        '
        'lblDecimal
        '
        Me.lblDecimal.AutoSize = True
        Me.lblDecimal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDecimal.Location = New System.Drawing.Point(230, 70)
        Me.lblDecimal.Name = "lblDecimal"
        Me.lblDecimal.Size = New System.Drawing.Size(55, 15)
        Me.lblDecimal.TabIndex = 5
        Me.lblDecimal.Text = "Decimal:"
        '
        'numDecimal
        '
        Me.numDecimal.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numDecimal.AllowNegative = True
        Me.numDecimal.BackColor = System.Drawing.Color.White
        Me.numDecimal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numDecimal.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numDecimal.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numDecimal.DecimalPlaces = 4
        Me.numDecimal.EnableMouseWheel = True
        Me.numDecimal.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numDecimal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numDecimal.ForeColor = System.Drawing.Color.Black
        Me.numDecimal.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Decimal]
        Me.numDecimal.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numDecimal.Location = New System.Drawing.Point(230, 92)
        Me.numDecimal.Mask = ""
        Me.numDecimal.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numDecimal.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDecimal.Name = "numDecimal"
        Me.numDecimal.Prefix = ""
        Me.numDecimal.ReadOnly = False
        Me.numDecimal.Size = New System.Drawing.Size(190, 28)
        Me.numDecimal.Suffix = ""
        Me.numDecimal.TabIndex = 6
        Me.numDecimal.ThousandsSeparator = False
        Me.numDecimal.UseMask = False
        Me.numDecimal.Value = New Decimal(New Integer() {314159, 0, 0, 327680})
        Me.numDecimal.WrapValue = False
        '
        'lblDecimalDesc
        '
        Me.lblDecimalDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDecimalDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblDecimalDesc.Location = New System.Drawing.Point(230, 125)
        Me.lblDecimalDesc.Name = "lblDecimalDesc"
        Me.lblDecimalDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblDecimalDesc.TabIndex = 7
        Me.lblDecimalDesc.Text = "Números con decimales (4 lugares)"
        '
        'lblDecimalValue
        '
        Me.lblDecimalValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblDecimalValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblDecimalValue.Location = New System.Drawing.Point(230, 155)
        Me.lblDecimalValue.Name = "lblDecimalValue"
        Me.lblDecimalValue.Size = New System.Drawing.Size(190, 15)
        Me.lblDecimalValue.TabIndex = 8
        Me.lblDecimalValue.Text = "Valor: 3.14159"
        '
        'lblCurrency
        '
        Me.lblCurrency.AutoSize = True
        Me.lblCurrency.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrency.Location = New System.Drawing.Point(440, 70)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(55, 15)
        Me.lblCurrency.TabIndex = 9
        Me.lblCurrency.Text = "Moneda:"
        '
        'numCurrency
        '
        Me.numCurrency.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numCurrency.AllowNegative = True
        Me.numCurrency.BackColor = System.Drawing.Color.White
        Me.numCurrency.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numCurrency.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numCurrency.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numCurrency.DecimalPlaces = 2
        Me.numCurrency.EnableMouseWheel = True
        Me.numCurrency.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numCurrency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numCurrency.ForeColor = System.Drawing.Color.Black
        Me.numCurrency.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.Currency
        Me.numCurrency.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numCurrency.Location = New System.Drawing.Point(440, 92)
        Me.numCurrency.Mask = ""
        Me.numCurrency.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numCurrency.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCurrency.Name = "numCurrency"
        Me.numCurrency.Prefix = ""
        Me.numCurrency.ReadOnly = False
        Me.numCurrency.Size = New System.Drawing.Size(190, 28)
        Me.numCurrency.Suffix = ""
        Me.numCurrency.TabIndex = 10
        Me.numCurrency.ThousandsSeparator = False
        Me.numCurrency.UseMask = False
        Me.numCurrency.Value = New Decimal(New Integer() {123456, 0, 0, 131072})
        Me.numCurrency.WrapValue = False
        '
        'lblCurrencyDesc
        '
        Me.lblCurrencyDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblCurrencyDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblCurrencyDesc.Location = New System.Drawing.Point(440, 125)
        Me.lblCurrencyDesc.Name = "lblCurrencyDesc"
        Me.lblCurrencyDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblCurrencyDesc.TabIndex = 11
        Me.lblCurrencyDesc.Text = "Formato de moneda ($)"
        '
        'lblCurrencyValue
        '
        Me.lblCurrencyValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblCurrencyValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblCurrencyValue.Location = New System.Drawing.Point(440, 155)
        Me.lblCurrencyValue.Name = "lblCurrencyValue"
        Me.lblCurrencyValue.Size = New System.Drawing.Size(190, 15)
        Me.lblCurrencyValue.TabIndex = 12
        Me.lblCurrencyValue.Text = "Valor: 1234.56"
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPercentage.Location = New System.Drawing.Point(650, 70)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(70, 15)
        Me.lblPercentage.TabIndex = 13
        Me.lblPercentage.Text = "Porcentaje:"
        '
        'numPercentage
        '
        Me.numPercentage.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPercentage.AllowNegative = True
        Me.numPercentage.BackColor = System.Drawing.Color.White
        Me.numPercentage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numPercentage.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numPercentage.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numPercentage.DecimalPlaces = 1
        Me.numPercentage.EnableMouseWheel = True
        Me.numPercentage.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPercentage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numPercentage.ForeColor = System.Drawing.Color.Black
        Me.numPercentage.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.Percentage
        Me.numPercentage.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numPercentage.Location = New System.Drawing.Point(650, 92)
        Me.numPercentage.Mask = ""
        Me.numPercentage.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numPercentage.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPercentage.Name = "numPercentage"
        Me.numPercentage.Prefix = ""
        Me.numPercentage.ReadOnly = False
        Me.numPercentage.Size = New System.Drawing.Size(190, 28)
        Me.numPercentage.Suffix = ""
        Me.numPercentage.TabIndex = 14
        Me.numPercentage.ThousandsSeparator = False
        Me.numPercentage.UseMask = False
        Me.numPercentage.Value = New Decimal(New Integer() {75, 0, 0, 0})
        Me.numPercentage.WrapValue = False
        '
        'lblPercentageDesc
        '
        Me.lblPercentageDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPercentageDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblPercentageDesc.Location = New System.Drawing.Point(650, 125)
        Me.lblPercentageDesc.Name = "lblPercentageDesc"
        Me.lblPercentageDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblPercentageDesc.TabIndex = 15
        Me.lblPercentageDesc.Text = "Formato de porcentaje (%)"
        '
        'lblPercentageValue
        '
        Me.lblPercentageValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblPercentageValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblPercentageValue.Location = New System.Drawing.Point(650, 155)
        Me.lblPercentageValue.Name = "lblPercentageValue"
        Me.lblPercentageValue.Size = New System.Drawing.Size(190, 15)
        Me.lblPercentageValue.TabIndex = 16
        Me.lblPercentageValue.Text = "Valor: 75"
        '
        'tabMasks
        '
        Me.tabMasks.BackColor = System.Drawing.Color.White
        Me.tabMasks.Location = New System.Drawing.Point(4, 24)
        Me.tabMasks.Name = "tabMasks"
        Me.tabMasks.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMasks.Size = New System.Drawing.Size(852, 717)
        Me.tabMasks.TabIndex = 1
        Me.tabMasks.Text = "Máscaras Numéricas"
        '
        'tabValidation
        '
        Me.tabValidation.BackColor = System.Drawing.Color.White
        Me.tabValidation.Location = New System.Drawing.Point(4, 24)
        Me.tabValidation.Name = "tabValidation"
        Me.tabValidation.Size = New System.Drawing.Size(852, 717)
        Me.tabValidation.TabIndex = 2
        Me.tabValidation.Text = "Validación y Rangos"
        '
        'tabCustomization
        '
        Me.tabCustomization.BackColor = System.Drawing.Color.White
        Me.tabCustomization.Location = New System.Drawing.Point(4, 24)
        Me.tabCustomization.Name = "tabCustomization"
        Me.tabCustomization.Size = New System.Drawing.Size(852, 717)
        Me.tabCustomization.TabIndex = 3
        Me.tabCustomization.Text = "Personalización"
        '
        'lblMaskTitle
        '
        Me.lblMaskTitle.AutoSize = True
        Me.lblMaskTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblMaskTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblMaskTitle.Location = New System.Drawing.Point(16, 191)
        Me.lblMaskTitle.Name = "lblMaskTitle"
        Me.lblMaskTitle.Size = New System.Drawing.Size(336, 21)
        Me.lblMaskTitle.TabIndex = 17
        Me.lblMaskTitle.Text = "NXNumericUpDown - Máscaras de Entrada"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPhone.Location = New System.Drawing.Point(16, 241)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(59, 15)
        Me.lblPhone.TabIndex = 18
        Me.lblPhone.Text = "Teléfono:"
        '
        'numPhone
        '
        Me.numPhone.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPhone.AllowNegative = True
        Me.numPhone.BackColor = System.Drawing.Color.White
        Me.numPhone.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numPhone.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numPhone.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numPhone.DecimalPlaces = 2
        Me.numPhone.EnableMouseWheel = True
        Me.numPhone.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numPhone.ForeColor = System.Drawing.Color.Black
        Me.numPhone.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numPhone.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPhone.Location = New System.Drawing.Point(16, 263)
        Me.numPhone.Mask = "(000) 0000-0000"
        Me.numPhone.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numPhone.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPhone.Name = "numPhone"
        Me.numPhone.Prefix = ""
        Me.numPhone.ReadOnly = False
        Me.numPhone.Size = New System.Drawing.Size(150, 28)
        Me.numPhone.Suffix = ""
        Me.numPhone.TabIndex = 19
        Me.numPhone.ThousandsSeparator = False
        Me.numPhone.UseMask = True
        Me.numPhone.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPhone.WrapValue = False
        '
        'lblPhoneDesc
        '
        Me.lblPhoneDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPhoneDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblPhoneDesc.Location = New System.Drawing.Point(16, 296)
        Me.lblPhoneDesc.Name = "lblPhoneDesc"
        Me.lblPhoneDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblPhoneDesc.TabIndex = 20
        Me.lblPhoneDesc.Text = "Máscara de teléfono"
        '
        'lblPhoneValue
        '
        Me.lblPhoneValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblPhoneValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblPhoneValue.Location = New System.Drawing.Point(16, 326)
        Me.lblPhoneValue.Name = "lblPhoneValue"
        Me.lblPhoneValue.Size = New System.Drawing.Size(190, 15)
        Me.lblPhoneValue.TabIndex = 21
        Me.lblPhoneValue.Text = "Valor: 0"
        '
        'lblZip
        '
        Me.lblZip.AutoSize = True
        Me.lblZip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblZip.Location = New System.Drawing.Point(226, 241)
        Me.lblZip.Name = "lblZip"
        Me.lblZip.Size = New System.Drawing.Size(59, 15)
        Me.lblZip.TabIndex = 22
        Me.lblZip.Text = "ZIP Code:"
        '
        'numZip
        '
        Me.numZip.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numZip.AllowNegative = True
        Me.numZip.BackColor = System.Drawing.Color.White
        Me.numZip.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numZip.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numZip.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numZip.DecimalPlaces = 2
        Me.numZip.EnableMouseWheel = True
        Me.numZip.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numZip.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numZip.ForeColor = System.Drawing.Color.Black
        Me.numZip.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numZip.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numZip.Location = New System.Drawing.Point(226, 263)
        Me.numZip.Mask = "00000-0000"
        Me.numZip.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numZip.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numZip.Name = "numZip"
        Me.numZip.Prefix = ""
        Me.numZip.ReadOnly = False
        Me.numZip.Size = New System.Drawing.Size(150, 28)
        Me.numZip.Suffix = ""
        Me.numZip.TabIndex = 23
        Me.numZip.ThousandsSeparator = False
        Me.numZip.UseMask = True
        Me.numZip.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numZip.WrapValue = False
        '
        'lblZipDesc
        '
        Me.lblZipDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblZipDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblZipDesc.Location = New System.Drawing.Point(226, 296)
        Me.lblZipDesc.Name = "lblZipDesc"
        Me.lblZipDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblZipDesc.TabIndex = 24
        Me.lblZipDesc.Text = "Código postal USA"
        '
        'lblZipValue
        '
        Me.lblZipValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblZipValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblZipValue.Location = New System.Drawing.Point(226, 326)
        Me.lblZipValue.Name = "lblZipValue"
        Me.lblZipValue.Size = New System.Drawing.Size(190, 15)
        Me.lblZipValue.TabIndex = 25
        Me.lblZipValue.Text = "Valor: 0"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTime.Location = New System.Drawing.Point(436, 241)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(37, 15)
        Me.lblTime.TabIndex = 26
        Me.lblTime.Text = "Hora:"
        '
        'numTime
        '
        Me.numTime.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numTime.AllowNegative = True
        Me.numTime.BackColor = System.Drawing.Color.White
        Me.numTime.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numTime.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numTime.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numTime.DecimalPlaces = 2
        Me.numTime.EnableMouseWheel = True
        Me.numTime.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numTime.ForeColor = System.Drawing.Color.Black
        Me.numTime.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numTime.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTime.Location = New System.Drawing.Point(436, 263)
        Me.numTime.Mask = "00:00:00"
        Me.numTime.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numTime.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTime.Name = "numTime"
        Me.numTime.Prefix = ""
        Me.numTime.ReadOnly = False
        Me.numTime.Size = New System.Drawing.Size(150, 28)
        Me.numTime.Suffix = ""
        Me.numTime.TabIndex = 27
        Me.numTime.ThousandsSeparator = False
        Me.numTime.UseMask = True
        Me.numTime.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTime.WrapValue = False
        '
        'lblTimeDesc
        '
        Me.lblTimeDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTimeDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblTimeDesc.Location = New System.Drawing.Point(436, 296)
        Me.lblTimeDesc.Name = "lblTimeDesc"
        Me.lblTimeDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblTimeDesc.TabIndex = 28
        Me.lblTimeDesc.Text = "Formato de hora"
        '
        'lblTimeValue
        '
        Me.lblTimeValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblTimeValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblTimeValue.Location = New System.Drawing.Point(436, 326)
        Me.lblTimeValue.Name = "lblTimeValue"
        Me.lblTimeValue.Size = New System.Drawing.Size(190, 15)
        Me.lblTimeValue.TabIndex = 29
        Me.lblTimeValue.Text = "Valor: 0"
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIP.Location = New System.Drawing.Point(646, 241)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(35, 15)
        Me.lblIP.TabIndex = 30
        Me.lblIP.Text = "IPv4:"
        '
        'numIP
        '
        Me.numIP.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numIP.AllowNegative = True
        Me.numIP.BackColor = System.Drawing.Color.White
        Me.numIP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numIP.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numIP.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numIP.DecimalPlaces = 2
        Me.numIP.EnableMouseWheel = True
        Me.numIP.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numIP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numIP.ForeColor = System.Drawing.Color.Black
        Me.numIP.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numIP.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numIP.Location = New System.Drawing.Point(646, 263)
        Me.numIP.Mask = "000.000.000.000"
        Me.numIP.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numIP.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numIP.Name = "numIP"
        Me.numIP.Prefix = ""
        Me.numIP.ReadOnly = False
        Me.numIP.Size = New System.Drawing.Size(150, 28)
        Me.numIP.Suffix = ""
        Me.numIP.TabIndex = 31
        Me.numIP.ThousandsSeparator = False
        Me.numIP.UseMask = True
        Me.numIP.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numIP.WrapValue = False
        '
        'lblIPDesc
        '
        Me.lblIPDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblIPDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblIPDesc.Location = New System.Drawing.Point(646, 296)
        Me.lblIPDesc.Name = "lblIPDesc"
        Me.lblIPDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblIPDesc.TabIndex = 32
        Me.lblIPDesc.Text = "Dirección IPv4"
        '
        'lblIPValue
        '
        Me.lblIPValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblIPValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblIPValue.Location = New System.Drawing.Point(646, 326)
        Me.lblIPValue.Name = "lblIPValue"
        Me.lblIPValue.Size = New System.Drawing.Size(190, 15)
        Me.lblIPValue.TabIndex = 33
        Me.lblIPValue.Text = "Valor: 0"
        '
        'lblValidationTitle
        '
        Me.lblValidationTitle.AutoSize = True
        Me.lblValidationTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblValidationTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblValidationTitle.Location = New System.Drawing.Point(16, 354)
        Me.lblValidationTitle.Name = "lblValidationTitle"
        Me.lblValidationTitle.Size = New System.Drawing.Size(344, 21)
        Me.lblValidationTitle.TabIndex = 34
        Me.lblValidationTitle.Text = "NXNumericUpDown - Validación de Rangos"
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRange.Location = New System.Drawing.Point(16, 404)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(74, 15)
        Me.lblRange.TabIndex = 35
        Me.lblRange.Text = "Rango 1-10:"
        '
        'numRange
        '
        Me.numRange.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numRange.AllowNegative = True
        Me.numRange.BackColor = System.Drawing.Color.White
        Me.numRange.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numRange.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numRange.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numRange.DecimalPlaces = 2
        Me.numRange.EnableMouseWheel = True
        Me.numRange.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numRange.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numRange.ForeColor = System.Drawing.Color.Black
        Me.numRange.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numRange.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRange.Location = New System.Drawing.Point(16, 426)
        Me.numRange.Mask = ""
        Me.numRange.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numRange.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRange.Name = "numRange"
        Me.numRange.Prefix = ""
        Me.numRange.ReadOnly = False
        Me.numRange.Size = New System.Drawing.Size(190, 28)
        Me.numRange.Suffix = ""
        Me.numRange.TabIndex = 36
        Me.numRange.ThousandsSeparator = False
        Me.numRange.UseMask = False
        Me.numRange.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numRange.WrapValue = False
        '
        'lblRangeDesc
        '
        Me.lblRangeDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblRangeDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblRangeDesc.Location = New System.Drawing.Point(16, 459)
        Me.lblRangeDesc.Name = "lblRangeDesc"
        Me.lblRangeDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblRangeDesc.TabIndex = 37
        Me.lblRangeDesc.Text = "Limitado entre 1 y 10"
        '
        'lblRangeValue
        '
        Me.lblRangeValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblRangeValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblRangeValue.Location = New System.Drawing.Point(16, 489)
        Me.lblRangeValue.Name = "lblRangeValue"
        Me.lblRangeValue.Size = New System.Drawing.Size(190, 15)
        Me.lblRangeValue.TabIndex = 38
        Me.lblRangeValue.Text = "Valor: 5"
        '
        'lblWrap
        '
        Me.lblWrap.AutoSize = True
        Me.lblWrap.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblWrap.Location = New System.Drawing.Point(226, 404)
        Me.lblWrap.Name = "lblWrap"
        Me.lblWrap.Size = New System.Drawing.Size(64, 15)
        Me.lblWrap.TabIndex = 39
        Me.lblWrap.Text = "Con Wrap:"
        '
        'numWrap
        '
        Me.numWrap.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numWrap.AllowNegative = True
        Me.numWrap.BackColor = System.Drawing.Color.White
        Me.numWrap.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numWrap.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numWrap.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numWrap.DecimalPlaces = 2
        Me.numWrap.EnableMouseWheel = True
        Me.numWrap.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numWrap.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numWrap.ForeColor = System.Drawing.Color.Black
        Me.numWrap.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numWrap.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numWrap.Location = New System.Drawing.Point(226, 426)
        Me.numWrap.Mask = ""
        Me.numWrap.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numWrap.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numWrap.Name = "numWrap"
        Me.numWrap.Prefix = ""
        Me.numWrap.ReadOnly = False
        Me.numWrap.Size = New System.Drawing.Size(190, 28)
        Me.numWrap.Suffix = ""
        Me.numWrap.TabIndex = 40
        Me.numWrap.ThousandsSeparator = False
        Me.numWrap.UseMask = False
        Me.numWrap.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numWrap.WrapValue = True
        '
        'lblWrapDesc
        '
        Me.lblWrapDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblWrapDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblWrapDesc.Location = New System.Drawing.Point(226, 459)
        Me.lblWrapDesc.Name = "lblWrapDesc"
        Me.lblWrapDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblWrapDesc.TabIndex = 41
        Me.lblWrapDesc.Text = "Vuelve al inicio/fin"
        '
        'lblWrapValue
        '
        Me.lblWrapValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblWrapValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblWrapValue.Location = New System.Drawing.Point(226, 489)
        Me.lblWrapValue.Name = "lblWrapValue"
        Me.lblWrapValue.Size = New System.Drawing.Size(190, 15)
        Me.lblWrapValue.TabIndex = 42
        Me.lblWrapValue.Text = "Valor: 5"
        '
        'lblNegative
        '
        Me.lblNegative.AutoSize = True
        Me.lblNegative.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNegative.Location = New System.Drawing.Point(436, 404)
        Me.lblNegative.Name = "lblNegative"
        Me.lblNegative.Size = New System.Drawing.Size(90, 15)
        Me.lblNegative.TabIndex = 43
        Me.lblNegative.Text = "Con Negativos:"
        '
        'numNegative
        '
        Me.numNegative.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numNegative.AllowNegative = True
        Me.numNegative.BackColor = System.Drawing.Color.White
        Me.numNegative.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numNegative.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numNegative.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numNegative.DecimalPlaces = 2
        Me.numNegative.EnableMouseWheel = True
        Me.numNegative.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numNegative.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numNegative.ForeColor = System.Drawing.Color.Black
        Me.numNegative.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numNegative.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numNegative.Location = New System.Drawing.Point(436, 426)
        Me.numNegative.Mask = ""
        Me.numNegative.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numNegative.Minimum = New Decimal(New Integer() {-100, 0, 0, -2147483648})
        Me.numNegative.Name = "numNegative"
        Me.numNegative.Prefix = ""
        Me.numNegative.ReadOnly = False
        Me.numNegative.Size = New System.Drawing.Size(190, 28)
        Me.numNegative.Suffix = ""
        Me.numNegative.TabIndex = 44
        Me.numNegative.ThousandsSeparator = False
        Me.numNegative.UseMask = False
        Me.numNegative.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numNegative.WrapValue = False
        '
        'lblNegativeDesc
        '
        Me.lblNegativeDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNegativeDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblNegativeDesc.Location = New System.Drawing.Point(436, 459)
        Me.lblNegativeDesc.Name = "lblNegativeDesc"
        Me.lblNegativeDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblNegativeDesc.TabIndex = 45
        Me.lblNegativeDesc.Text = "Permite valores negativos"
        '
        'lblNegativeValue
        '
        Me.lblNegativeValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblNegativeValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblNegativeValue.Location = New System.Drawing.Point(436, 489)
        Me.lblNegativeValue.Name = "lblNegativeValue"
        Me.lblNegativeValue.Size = New System.Drawing.Size(190, 15)
        Me.lblNegativeValue.TabIndex = 46
        Me.lblNegativeValue.Text = "Valor: 0"
        '
        'lblPositive
        '
        Me.lblPositive.AutoSize = True
        Me.lblPositive.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPositive.Location = New System.Drawing.Point(646, 404)
        Me.lblPositive.Name = "lblPositive"
        Me.lblPositive.Size = New System.Drawing.Size(86, 15)
        Me.lblPositive.TabIndex = 47
        Me.lblPositive.Text = "Solo Positivos:"
        '
        'numPositive
        '
        Me.numPositive.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPositive.AllowNegative = False
        Me.numPositive.BackColor = System.Drawing.Color.White
        Me.numPositive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numPositive.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numPositive.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numPositive.DecimalPlaces = 2
        Me.numPositive.EnableMouseWheel = True
        Me.numPositive.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPositive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numPositive.ForeColor = System.Drawing.Color.Black
        Me.numPositive.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numPositive.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numPositive.Location = New System.Drawing.Point(646, 426)
        Me.numPositive.Mask = ""
        Me.numPositive.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numPositive.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPositive.Name = "numPositive"
        Me.numPositive.Prefix = ""
        Me.numPositive.ReadOnly = False
        Me.numPositive.Size = New System.Drawing.Size(190, 28)
        Me.numPositive.Suffix = ""
        Me.numPositive.TabIndex = 48
        Me.numPositive.ThousandsSeparator = False
        Me.numPositive.UseMask = False
        Me.numPositive.Value = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numPositive.WrapValue = False
        '
        'lblPositiveDesc
        '
        Me.lblPositiveDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPositiveDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblPositiveDesc.Location = New System.Drawing.Point(646, 459)
        Me.lblPositiveDesc.Name = "lblPositiveDesc"
        Me.lblPositiveDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblPositiveDesc.TabIndex = 49
        Me.lblPositiveDesc.Text = "Solo valores positivos"
        '
        'lblPositiveValue
        '
        Me.lblPositiveValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblPositiveValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblPositiveValue.Location = New System.Drawing.Point(646, 489)
        Me.lblPositiveValue.Name = "lblPositiveValue"
        Me.lblPositiveValue.Size = New System.Drawing.Size(190, 15)
        Me.lblPositiveValue.TabIndex = 50
        Me.lblPositiveValue.Text = "Valor: 50"
        '
        'lblCustomTitle
        '
        Me.lblCustomTitle.AutoSize = True
        Me.lblCustomTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustomTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblCustomTitle.Location = New System.Drawing.Point(20, 525)
        Me.lblCustomTitle.Name = "lblCustomTitle"
        Me.lblCustomTitle.Size = New System.Drawing.Size(301, 21)
        Me.lblCustomTitle.TabIndex = 51
        Me.lblCustomTitle.Text = "NXNumericUpDown - Personalización"
        '
        'lblPrefix
        '
        Me.lblPrefix.AutoSize = True
        Me.lblPrefix.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrefix.Location = New System.Drawing.Point(20, 575)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(71, 15)
        Me.lblPrefix.TabIndex = 52
        Me.lblPrefix.Text = "Con Prefijo:"
        '
        'numPrefix
        '
        Me.numPrefix.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPrefix.AllowNegative = True
        Me.numPrefix.BackColor = System.Drawing.Color.White
        Me.numPrefix.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numPrefix.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numPrefix.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numPrefix.DecimalPlaces = 2
        Me.numPrefix.EnableMouseWheel = True
        Me.numPrefix.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numPrefix.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numPrefix.ForeColor = System.Drawing.Color.Black
        Me.numPrefix.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Decimal]
        Me.numPrefix.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPrefix.Location = New System.Drawing.Point(20, 597)
        Me.numPrefix.Mask = ""
        Me.numPrefix.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numPrefix.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPrefix.Name = "numPrefix"
        Me.numPrefix.Prefix = "$ "
        Me.numPrefix.ReadOnly = False
        Me.numPrefix.Size = New System.Drawing.Size(190, 28)
        Me.numPrefix.Suffix = ""
        Me.numPrefix.TabIndex = 53
        Me.numPrefix.ThousandsSeparator = True
        Me.numPrefix.UseMask = False
        Me.numPrefix.Value = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numPrefix.WrapValue = False
        '
        'lblPrefixDesc
        '
        Me.lblPrefixDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPrefixDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblPrefixDesc.Location = New System.Drawing.Point(20, 630)
        Me.lblPrefixDesc.Name = "lblPrefixDesc"
        Me.lblPrefixDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblPrefixDesc.TabIndex = 54
        Me.lblPrefixDesc.Text = "Prefijo personalizado"
        '
        'lblPrefixValue
        '
        Me.lblPrefixValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblPrefixValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblPrefixValue.Location = New System.Drawing.Point(20, 660)
        Me.lblPrefixValue.Name = "lblPrefixValue"
        Me.lblPrefixValue.Size = New System.Drawing.Size(190, 15)
        Me.lblPrefixValue.TabIndex = 55
        Me.lblPrefixValue.Text = "Valor: 25"
        '
        'lblSuffix
        '
        Me.lblSuffix.AutoSize = True
        Me.lblSuffix.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuffix.Location = New System.Drawing.Point(230, 575)
        Me.lblSuffix.Name = "lblSuffix"
        Me.lblSuffix.Size = New System.Drawing.Size(66, 15)
        Me.lblSuffix.TabIndex = 56
        Me.lblSuffix.Text = "Con Sufijo:"
        '
        'numSuffix
        '
        Me.numSuffix.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numSuffix.AllowNegative = True
        Me.numSuffix.BackColor = System.Drawing.Color.White
        Me.numSuffix.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numSuffix.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numSuffix.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numSuffix.DecimalPlaces = 1
        Me.numSuffix.EnableMouseWheel = True
        Me.numSuffix.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numSuffix.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numSuffix.ForeColor = System.Drawing.Color.Black
        Me.numSuffix.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Decimal]
        Me.numSuffix.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSuffix.Location = New System.Drawing.Point(230, 597)
        Me.numSuffix.Mask = ""
        Me.numSuffix.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numSuffix.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numSuffix.Name = "numSuffix"
        Me.numSuffix.Prefix = ""
        Me.numSuffix.ReadOnly = False
        Me.numSuffix.Size = New System.Drawing.Size(190, 28)
        Me.numSuffix.Suffix = " kg"
        Me.numSuffix.TabIndex = 57
        Me.numSuffix.ThousandsSeparator = False
        Me.numSuffix.UseMask = False
        Me.numSuffix.Value = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numSuffix.WrapValue = False
        '
        'lblSuffixDesc
        '
        Me.lblSuffixDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblSuffixDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblSuffixDesc.Location = New System.Drawing.Point(230, 630)
        Me.lblSuffixDesc.Name = "lblSuffixDesc"
        Me.lblSuffixDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblSuffixDesc.TabIndex = 58
        Me.lblSuffixDesc.Text = "Sufijo personalizado"
        '
        'lblSuffixValue
        '
        Me.lblSuffixValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblSuffixValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblSuffixValue.Location = New System.Drawing.Point(230, 660)
        Me.lblSuffixValue.Name = "lblSuffixValue"
        Me.lblSuffixValue.Size = New System.Drawing.Size(190, 15)
        Me.lblSuffixValue.TabIndex = 59
        Me.lblSuffixValue.Text = "Valor: 100"
        '
        'lblReadOnly
        '
        Me.lblReadOnly.AutoSize = True
        Me.lblReadOnly.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblReadOnly.Location = New System.Drawing.Point(440, 575)
        Me.lblReadOnly.Name = "lblReadOnly"
        Me.lblReadOnly.Size = New System.Drawing.Size(79, 15)
        Me.lblReadOnly.TabIndex = 60
        Me.lblReadOnly.Text = "Solo Lectura:"
        '
        'numReadOnly
        '
        Me.numReadOnly.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numReadOnly.AllowNegative = True
        Me.numReadOnly.BackColor = System.Drawing.Color.White
        Me.numReadOnly.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numReadOnly.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numReadOnly.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numReadOnly.DecimalPlaces = 2
        Me.numReadOnly.EnableMouseWheel = True
        Me.numReadOnly.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numReadOnly.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numReadOnly.ForeColor = System.Drawing.Color.Black
        Me.numReadOnly.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Integer]
        Me.numReadOnly.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numReadOnly.Location = New System.Drawing.Point(440, 597)
        Me.numReadOnly.Mask = ""
        Me.numReadOnly.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numReadOnly.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numReadOnly.Name = "numReadOnly"
        Me.numReadOnly.Prefix = ""
        Me.numReadOnly.ReadOnly = True
        Me.numReadOnly.Size = New System.Drawing.Size(190, 28)
        Me.numReadOnly.Suffix = ""
        Me.numReadOnly.TabIndex = 61
        Me.numReadOnly.ThousandsSeparator = False
        Me.numReadOnly.UseMask = False
        Me.numReadOnly.Value = New Decimal(New Integer() {42, 0, 0, 0})
        Me.numReadOnly.WrapValue = False
        '
        'lblReadOnlyDesc
        '
        Me.lblReadOnlyDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblReadOnlyDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblReadOnlyDesc.Location = New System.Drawing.Point(440, 630)
        Me.lblReadOnlyDesc.Name = "lblReadOnlyDesc"
        Me.lblReadOnlyDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblReadOnlyDesc.TabIndex = 62
        Me.lblReadOnlyDesc.Text = "Control deshabilitado"
        '
        'lblReadOnlyValue
        '
        Me.lblReadOnlyValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblReadOnlyValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblReadOnlyValue.Location = New System.Drawing.Point(440, 660)
        Me.lblReadOnlyValue.Name = "lblReadOnlyValue"
        Me.lblReadOnlyValue.Size = New System.Drawing.Size(190, 15)
        Me.lblReadOnlyValue.TabIndex = 63
        Me.lblReadOnlyValue.Text = "Valor: 42"
        '
        'lblIncrement
        '
        Me.lblIncrement.AutoSize = True
        Me.lblIncrement.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIncrement.Location = New System.Drawing.Point(650, 575)
        Me.lblIncrement.Name = "lblIncrement"
        Me.lblIncrement.Size = New System.Drawing.Size(57, 15)
        Me.lblIncrement.TabIndex = 64
        Me.lblIncrement.Text = "Inc. 0.25:"
        '
        'numIncrement
        '
        Me.numIncrement.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numIncrement.AllowNegative = True
        Me.numIncrement.BackColor = System.Drawing.Color.White
        Me.numIncrement.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.numIncrement.ButtonBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.numIncrement.ButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.numIncrement.DecimalPlaces = 2
        Me.numIncrement.EnableMouseWheel = True
        Me.numIncrement.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.numIncrement.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numIncrement.ForeColor = System.Drawing.Color.Black
        Me.numIncrement.Format = NeoSoft.UI.Controls.NXNumericUpDown.NumericFormat.[Decimal]
        Me.numIncrement.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.numIncrement.Location = New System.Drawing.Point(650, 597)
        Me.numIncrement.Mask = ""
        Me.numIncrement.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numIncrement.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numIncrement.Name = "numIncrement"
        Me.numIncrement.Prefix = ""
        Me.numIncrement.ReadOnly = False
        Me.numIncrement.Size = New System.Drawing.Size(190, 28)
        Me.numIncrement.Suffix = ""
        Me.numIncrement.TabIndex = 65
        Me.numIncrement.ThousandsSeparator = False
        Me.numIncrement.UseMask = False
        Me.numIncrement.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numIncrement.WrapValue = False
        '
        'lblIncrementDesc
        '
        Me.lblIncrementDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblIncrementDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblIncrementDesc.Location = New System.Drawing.Point(650, 630)
        Me.lblIncrementDesc.Name = "lblIncrementDesc"
        Me.lblIncrementDesc.Size = New System.Drawing.Size(190, 30)
        Me.lblIncrementDesc.TabIndex = 66
        Me.lblIncrementDesc.Text = "Incremento de 0.25"
        '
        'lblIncrementValue
        '
        Me.lblIncrementValue.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.lblIncrementValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblIncrementValue.Location = New System.Drawing.Point(650, 660)
        Me.lblIncrementValue.Name = "lblIncrementValue"
        Me.lblIncrementValue.Size = New System.Drawing.Size(190, 15)
        Me.lblIncrementValue.TabIndex = 67
        Me.lblIncrementValue.Text = "Valor: 5"
        '
        'frmNXControlTest1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(900, 828)
        Me.Controls.Add(Me.tabControlMain)
        Me.Controls.Add(Me.lblMainTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmNXControlTest1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NeoSoft.UI - Test de Controles"
        Me.tabControlMain.ResumeLayout(False)
        Me.tabFormats.ResumeLayout(False)
        Me.tabFormats.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMainTitle As Label
    Friend WithEvents tabControlMain As TabControl
    Friend WithEvents tabFormats As TabPage
    Friend WithEvents tabMasks As TabPage
    Friend WithEvents tabValidation As TabPage
    Friend WithEvents tabCustomization As TabPage
    '
    ' Tab 1: Formatos
    Friend WithEvents lblFormatTitle As Label
    Friend WithEvents lblInteger As Label
    Friend WithEvents numInteger As NeoSoft.UI.Controls.NXNumericUpDown
    Friend WithEvents lblIntegerDesc As Label
    Friend WithEvents lblIntegerValue As Label
    Friend WithEvents lblDecimal As Label
    Friend WithEvents numDecimal As NeoSoft.UI.Controls.NXNumericUpDown
    Friend WithEvents lblDecimalDesc As Label
    Friend WithEvents lblDecimalValue As Label
    Friend WithEvents lblCurrency As Label
    Friend WithEvents numCurrency As NeoSoft.UI.Controls.NXNumericUpDown
    Friend WithEvents lblCurrencyDesc As Label
    Friend WithEvents lblCurrencyValue As Label
    Friend WithEvents lblPercentage As Label
    Friend WithEvents numPercentage As NeoSoft.UI.Controls.NXNumericUpDown
    Friend WithEvents lblPercentageDesc As Label
    Friend WithEvents lblPercentageValue As Label
    Friend WithEvents lblValidationTitle As Label
    Friend WithEvents lblRange As Label
    Friend WithEvents numRange As Controls.NXNumericUpDown
    Friend WithEvents lblRangeDesc As Label
    Friend WithEvents lblRangeValue As Label
    Friend WithEvents lblWrap As Label
    Friend WithEvents numWrap As Controls.NXNumericUpDown
    Friend WithEvents lblWrapDesc As Label
    Friend WithEvents lblWrapValue As Label
    Friend WithEvents lblNegative As Label
    Friend WithEvents numNegative As Controls.NXNumericUpDown
    Friend WithEvents lblNegativeDesc As Label
    Friend WithEvents lblNegativeValue As Label
    Friend WithEvents lblPositive As Label
    Friend WithEvents numPositive As Controls.NXNumericUpDown
    Friend WithEvents lblPositiveDesc As Label
    Friend WithEvents lblPositiveValue As Label
    Friend WithEvents lblMaskTitle As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents numPhone As Controls.NXNumericUpDown
    Friend WithEvents lblPhoneDesc As Label
    Friend WithEvents lblPhoneValue As Label
    Friend WithEvents lblZip As Label
    Friend WithEvents numZip As Controls.NXNumericUpDown
    Friend WithEvents lblZipDesc As Label
    Friend WithEvents lblZipValue As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents numTime As Controls.NXNumericUpDown
    Friend WithEvents lblTimeDesc As Label
    Friend WithEvents lblTimeValue As Label
    Friend WithEvents lblIP As Label
    Friend WithEvents numIP As Controls.NXNumericUpDown
    Friend WithEvents lblIPDesc As Label
    Friend WithEvents lblIPValue As Label
    Friend WithEvents lblCustomTitle As Label
    Friend WithEvents lblPrefix As Label
    Friend WithEvents numPrefix As Controls.NXNumericUpDown
    Friend WithEvents lblPrefixDesc As Label
    Friend WithEvents lblPrefixValue As Label
    Friend WithEvents lblSuffix As Label
    Friend WithEvents numSuffix As Controls.NXNumericUpDown
    Friend WithEvents lblSuffixDesc As Label
    Friend WithEvents lblSuffixValue As Label
    Friend WithEvents lblReadOnly As Label
    Friend WithEvents numReadOnly As Controls.NXNumericUpDown
    Friend WithEvents lblReadOnlyDesc As Label
    Friend WithEvents lblReadOnlyValue As Label
    Friend WithEvents lblIncrement As Label
    Friend WithEvents numIncrement As Controls.NXNumericUpDown
    Friend WithEvents lblIncrementDesc As Label
    Friend WithEvents lblIncrementValue As Label
End Class