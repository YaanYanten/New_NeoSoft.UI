<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNXToolTipDemo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()

        ' NXToolTip
        Me.nxToolTip1 = New NeoSoft.UI.Controls.NXToolTip()
        Me.nxToolTip1.ShowDelay = 300
        Me.nxToolTip1.AutoHideDelay = 5000
        Me.nxToolTip1.Animation = NeoSoft.UI.Controls.NXToolTip.AnimationEffect.Fade

        ' Sección 1: Estilos Predefinidos
        Me.lblStylesTitle = New System.Windows.Forms.Label()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.btnSuccess = New System.Windows.Forms.Button()
        Me.btnWarning = New System.Windows.Forms.Button()
        Me.btnError = New System.Windows.Forms.Button()
        Me.btnDark = New System.Windows.Forms.Button()

        ' Sección 2: Con Iconos
        Me.lblIconsTitle = New System.Windows.Forms.Label()
        Me.btnIconInfo = New System.Windows.Forms.Button()
        Me.btnIconWarning = New System.Windows.Forms.Button()
        Me.btnIconError = New System.Windows.Forms.Button()
        Me.btnIconSuccess = New System.Windows.Forms.Button()
        Me.btnIconHelp = New System.Windows.Forms.Button()

        ' Sección 3: Con Títulos
        Me.lblTitlesTitle = New System.Windows.Forms.Label()
        Me.btnTitleSimple = New System.Windows.Forms.Button()
        Me.btnTitleIcon = New System.Windows.Forms.Button()
        Me.btnTitleLong = New System.Windows.Forms.Button()

        ' Sección 4: HTML Básico
        Me.lblHtmlTitle = New System.Windows.Forms.Label()
        Me.btnHtmlBold = New System.Windows.Forms.Button()
        Me.btnHtmlItalic = New System.Windows.Forms.Button()
        Me.btnHtmlMixed = New System.Windows.Forms.Button()
        Me.btnHtmlMultiline = New System.Windows.Forms.Button()

        ' Sección 5: Posicionamiento
        Me.lblPositionTitle = New System.Windows.Forms.Label()
        Me.btnPosAuto = New System.Windows.Forms.Button()
        Me.btnPosTop = New System.Windows.Forms.Button()
        Me.btnPosBottom = New System.Windows.Forms.Button()
        Me.btnPosLeft = New System.Windows.Forms.Button()
        Me.btnPosRight = New System.Windows.Forms.Button()

        ' Sección 6: Configuración Global
        Me.grpGlobalSettings = New System.Windows.Forms.GroupBox()
        Me.lblAnimationLabel = New System.Windows.Forms.Label()
        Me.cboAnimation = New System.Windows.Forms.ComboBox()
        Me.lblDelayLabel = New System.Windows.Forms.Label()
        Me.numShowDelay = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoHideLabel = New System.Windows.Forms.Label()
        Me.numAutoHide = New System.Windows.Forms.NumericUpDown()

        ' Sección 7: NXComboBox
        Me.lblComboBoxTitle = New System.Windows.Forms.Label()
        Me.lblComboSimple = New System.Windows.Forms.Label()
        Me.nxComboSimple = New NeoSoft.UI.Controls.NXComboBox()
        Me.lblComboIcons = New System.Windows.Forms.Label()
        Me.nxComboWithIcons = New NeoSoft.UI.Controls.NXComboBox()
        Me.lblComboGroups = New System.Windows.Forms.Label()
        Me.nxComboWithGroups = New NeoSoft.UI.Controls.NXComboBox()
        Me.lblComboMulti = New System.Windows.Forms.Label()
        Me.nxComboMultiSelect = New NeoSoft.UI.Controls.NXComboBox()

        Me.grpGlobalSettings.SuspendLayout()
        CType(Me.numShowDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAutoHide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '
        'lblStylesTitle
        '
        Me.lblStylesTitle.AutoSize = True
        Me.lblStylesTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblStylesTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblStylesTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblStylesTitle.Name = "lblStylesTitle"
        Me.lblStylesTitle.Text = "1. Estilos Predefinidos"

        '
        'btnDefault
        '
        Me.btnDefault.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
        Me.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefault.FlatAppearance.BorderSize = 0
        Me.btnDefault.Location = New System.Drawing.Point(20, 55)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(110, 35)
        Me.btnDefault.Text = "Default"

        '
        'btnInfo
        '
        Me.btnInfo.BackColor = System.Drawing.Color.FromArgb(33, 150, 243)
        Me.btnInfo.ForeColor = System.Drawing.Color.White
        Me.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfo.FlatAppearance.BorderSize = 0
        Me.btnInfo.Location = New System.Drawing.Point(140, 55)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(110, 35)
        Me.btnInfo.Text = "Info"

        '
        'btnSuccess
        '
        Me.btnSuccess.BackColor = System.Drawing.Color.FromArgb(76, 175, 80)
        Me.btnSuccess.ForeColor = System.Drawing.Color.White
        Me.btnSuccess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuccess.FlatAppearance.BorderSize = 0
        Me.btnSuccess.Location = New System.Drawing.Point(260, 55)
        Me.btnSuccess.Name = "btnSuccess"
        Me.btnSuccess.Size = New System.Drawing.Size(110, 35)
        Me.btnSuccess.Text = "Success"

        '
        'btnWarning
        '
        Me.btnWarning.BackColor = System.Drawing.Color.FromArgb(255, 152, 0)
        Me.btnWarning.ForeColor = System.Drawing.Color.White
        Me.btnWarning.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWarning.FlatAppearance.BorderSize = 0
        Me.btnWarning.Location = New System.Drawing.Point(380, 55)
        Me.btnWarning.Name = "btnWarning"
        Me.btnWarning.Size = New System.Drawing.Size(110, 35)
        Me.btnWarning.Text = "Warning"

        '
        'btnError
        '
        Me.btnError.BackColor = System.Drawing.Color.FromArgb(244, 67, 54)
        Me.btnError.ForeColor = System.Drawing.Color.White
        Me.btnError.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnError.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnError.FlatAppearance.BorderSize = 0
        Me.btnError.Location = New System.Drawing.Point(500, 55)
        Me.btnError.Name = "btnError"
        Me.btnError.Size = New System.Drawing.Size(110, 35)
        Me.btnError.Text = "Error"

        '
        'btnDark
        '
        Me.btnDark.BackColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.btnDark.ForeColor = System.Drawing.Color.White
        Me.btnDark.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDark.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDark.FlatAppearance.BorderSize = 0
        Me.btnDark.Location = New System.Drawing.Point(620, 55)
        Me.btnDark.Name = "btnDark"
        Me.btnDark.Size = New System.Drawing.Size(110, 35)
        Me.btnDark.Text = "Dark"

        '
        'lblIconsTitle
        '
        Me.lblIconsTitle.AutoSize = True
        Me.lblIconsTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblIconsTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblIconsTitle.Location = New System.Drawing.Point(20, 115)
        Me.lblIconsTitle.Name = "lblIconsTitle"
        Me.lblIconsTitle.Text = "2. Tooltips con Iconos"

        '
        'btnIconInfo
        '
        Me.btnIconInfo.BackColor = System.Drawing.Color.FromArgb(33, 150, 243)
        Me.btnIconInfo.ForeColor = System.Drawing.Color.White
        Me.btnIconInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIconInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIconInfo.FlatAppearance.BorderSize = 0
        Me.btnIconInfo.Location = New System.Drawing.Point(20, 150)
        Me.btnIconInfo.Name = "btnIconInfo"
        Me.btnIconInfo.Size = New System.Drawing.Size(110, 35)
        Me.btnIconInfo.Text = "Info Icon"

        '
        'btnIconWarning
        '
        Me.btnIconWarning.BackColor = System.Drawing.Color.FromArgb(255, 152, 0)
        Me.btnIconWarning.ForeColor = System.Drawing.Color.White
        Me.btnIconWarning.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIconWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIconWarning.FlatAppearance.BorderSize = 0
        Me.btnIconWarning.Location = New System.Drawing.Point(140, 150)
        Me.btnIconWarning.Name = "btnIconWarning"
        Me.btnIconWarning.Size = New System.Drawing.Size(110, 35)
        Me.btnIconWarning.Text = "Warning Icon"

        '
        'btnIconError
        '
        Me.btnIconError.BackColor = System.Drawing.Color.FromArgb(244, 67, 54)
        Me.btnIconError.ForeColor = System.Drawing.Color.White
        Me.btnIconError.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIconError.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIconError.FlatAppearance.BorderSize = 0
        Me.btnIconError.Location = New System.Drawing.Point(260, 150)
        Me.btnIconError.Name = "btnIconError"
        Me.btnIconError.Size = New System.Drawing.Size(110, 35)
        Me.btnIconError.Text = "Error Icon"

        '
        'btnIconSuccess
        '
        Me.btnIconSuccess.BackColor = System.Drawing.Color.FromArgb(76, 175, 80)
        Me.btnIconSuccess.ForeColor = System.Drawing.Color.White
        Me.btnIconSuccess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIconSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIconSuccess.FlatAppearance.BorderSize = 0
        Me.btnIconSuccess.Location = New System.Drawing.Point(380, 150)
        Me.btnIconSuccess.Name = "btnIconSuccess"
        Me.btnIconSuccess.Size = New System.Drawing.Size(110, 35)
        Me.btnIconSuccess.Text = "Success Icon"

        '
        'btnIconHelp
        '
        Me.btnIconHelp.BackColor = System.Drawing.Color.FromArgb(156, 39, 176)
        Me.btnIconHelp.ForeColor = System.Drawing.Color.White
        Me.btnIconHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIconHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIconHelp.FlatAppearance.BorderSize = 0
        Me.btnIconHelp.Location = New System.Drawing.Point(500, 150)
        Me.btnIconHelp.Name = "btnIconHelp"
        Me.btnIconHelp.Size = New System.Drawing.Size(110, 35)
        Me.btnIconHelp.Text = "Help Icon"

        '
        'lblTitlesTitle
        '
        Me.lblTitlesTitle.AutoSize = True
        Me.lblTitlesTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitlesTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblTitlesTitle.Location = New System.Drawing.Point(20, 210)
        Me.lblTitlesTitle.Name = "lblTitlesTitle"
        Me.lblTitlesTitle.Text = "3. Tooltips con Títulos"

        '
        'btnTitleSimple
        '
        Me.btnTitleSimple.BackColor = System.Drawing.Color.FromArgb(103, 58, 183)
        Me.btnTitleSimple.ForeColor = System.Drawing.Color.White
        Me.btnTitleSimple.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTitleSimple.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitleSimple.FlatAppearance.BorderSize = 0
        Me.btnTitleSimple.Location = New System.Drawing.Point(20, 245)
        Me.btnTitleSimple.Name = "btnTitleSimple"
        Me.btnTitleSimple.Size = New System.Drawing.Size(130, 35)
        Me.btnTitleSimple.Text = "Título Simple"

        '
        'btnTitleIcon
        '
        Me.btnTitleIcon.BackColor = System.Drawing.Color.FromArgb(33, 150, 243)
        Me.btnTitleIcon.ForeColor = System.Drawing.Color.White
        Me.btnTitleIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTitleIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitleIcon.FlatAppearance.BorderSize = 0
        Me.btnTitleIcon.Location = New System.Drawing.Point(160, 245)
        Me.btnTitleIcon.Name = "btnTitleIcon"
        Me.btnTitleIcon.Size = New System.Drawing.Size(130, 35)
        Me.btnTitleIcon.Text = "Título + Icono"

        '
        'btnTitleLong
        '
        Me.btnTitleLong.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnTitleLong.ForeColor = System.Drawing.Color.White
        Me.btnTitleLong.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTitleLong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitleLong.FlatAppearance.BorderSize = 0
        Me.btnTitleLong.Location = New System.Drawing.Point(300, 245)
        Me.btnTitleLong.Name = "btnTitleLong"
        Me.btnTitleLong.Size = New System.Drawing.Size(130, 35)
        Me.btnTitleLong.Text = "Título Largo"

        '
        'lblHtmlTitle
        '
        Me.lblHtmlTitle.AutoSize = True
        Me.lblHtmlTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblHtmlTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblHtmlTitle.Location = New System.Drawing.Point(20, 305)
        Me.lblHtmlTitle.Name = "lblHtmlTitle"
        Me.lblHtmlTitle.Text = "4. HTML Básico (<b>, <i>, <u>, <br>)"

        '
        'btnHtmlBold
        '
        Me.btnHtmlBold.BackColor = System.Drawing.Color.FromArgb(63, 81, 181)
        Me.btnHtmlBold.ForeColor = System.Drawing.Color.White
        Me.btnHtmlBold.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHtmlBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHtmlBold.FlatAppearance.BorderSize = 0
        Me.btnHtmlBold.Location = New System.Drawing.Point(20, 340)
        Me.btnHtmlBold.Name = "btnHtmlBold"
        Me.btnHtmlBold.Size = New System.Drawing.Size(110, 35)
        Me.btnHtmlBold.Text = "Texto Bold"

        '
        'btnHtmlItalic
        '
        Me.btnHtmlItalic.BackColor = System.Drawing.Color.FromArgb(63, 81, 181)
        Me.btnHtmlItalic.ForeColor = System.Drawing.Color.White
        Me.btnHtmlItalic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHtmlItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHtmlItalic.FlatAppearance.BorderSize = 0
        Me.btnHtmlItalic.Location = New System.Drawing.Point(140, 340)
        Me.btnHtmlItalic.Name = "btnHtmlItalic"
        Me.btnHtmlItalic.Size = New System.Drawing.Size(110, 35)
        Me.btnHtmlItalic.Text = "Texto Italic"

        '
        'btnHtmlMixed
        '
        Me.btnHtmlMixed.BackColor = System.Drawing.Color.FromArgb(63, 81, 181)
        Me.btnHtmlMixed.ForeColor = System.Drawing.Color.White
        Me.btnHtmlMixed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHtmlMixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHtmlMixed.FlatAppearance.BorderSize = 0
        Me.btnHtmlMixed.Location = New System.Drawing.Point(260, 340)
        Me.btnHtmlMixed.Name = "btnHtmlMixed"
        Me.btnHtmlMixed.Size = New System.Drawing.Size(110, 35)
        Me.btnHtmlMixed.Text = "Texto Mixto"

        '
        'btnHtmlMultiline
        '
        Me.btnHtmlMultiline.BackColor = System.Drawing.Color.FromArgb(63, 81, 181)
        Me.btnHtmlMultiline.ForeColor = System.Drawing.Color.White
        Me.btnHtmlMultiline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHtmlMultiline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHtmlMultiline.FlatAppearance.BorderSize = 0
        Me.btnHtmlMultiline.Location = New System.Drawing.Point(380, 340)
        Me.btnHtmlMultiline.Name = "btnHtmlMultiline"
        Me.btnHtmlMultiline.Size = New System.Drawing.Size(110, 35)
        Me.btnHtmlMultiline.Text = "Multilínea"

        '
        'lblPositionTitle
        '
        Me.lblPositionTitle.AutoSize = True
        Me.lblPositionTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPositionTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblPositionTitle.Location = New System.Drawing.Point(20, 400)
        Me.lblPositionTitle.Name = "lblPositionTitle"
        Me.lblPositionTitle.Text = "5. Posicionamiento Inteligente"

        '
        'btnPosAuto
        '
        Me.btnPosAuto.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnPosAuto.ForeColor = System.Drawing.Color.White
        Me.btnPosAuto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPosAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosAuto.FlatAppearance.BorderSize = 0
        Me.btnPosAuto.Location = New System.Drawing.Point(20, 435)
        Me.btnPosAuto.Name = "btnPosAuto"
        Me.btnPosAuto.Size = New System.Drawing.Size(110, 35)
        Me.btnPosAuto.Text = "Auto"

        '
        'btnPosTop
        '
        Me.btnPosTop.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnPosTop.ForeColor = System.Drawing.Color.White
        Me.btnPosTop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPosTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosTop.FlatAppearance.BorderSize = 0
        Me.btnPosTop.Location = New System.Drawing.Point(140, 435)
        Me.btnPosTop.Name = "btnPosTop"
        Me.btnPosTop.Size = New System.Drawing.Size(110, 35)
        Me.btnPosTop.Text = "Top"

        '
        'btnPosBottom
        '
        Me.btnPosBottom.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnPosBottom.ForeColor = System.Drawing.Color.White
        Me.btnPosBottom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPosBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosBottom.FlatAppearance.BorderSize = 0
        Me.btnPosBottom.Location = New System.Drawing.Point(260, 435)
        Me.btnPosBottom.Name = "btnPosBottom"
        Me.btnPosBottom.Size = New System.Drawing.Size(110, 35)
        Me.btnPosBottom.Text = "Bottom"

        '
        'btnPosLeft
        '
        Me.btnPosLeft.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnPosLeft.ForeColor = System.Drawing.Color.White
        Me.btnPosLeft.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPosLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosLeft.FlatAppearance.BorderSize = 0
        Me.btnPosLeft.Location = New System.Drawing.Point(380, 435)
        Me.btnPosLeft.Name = "btnPosLeft"
        Me.btnPosLeft.Size = New System.Drawing.Size(110, 35)
        Me.btnPosLeft.Text = "Left"

        '
        'btnPosRight
        '
        Me.btnPosRight.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnPosRight.ForeColor = System.Drawing.Color.White
        Me.btnPosRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPosRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosRight.FlatAppearance.BorderSize = 0
        Me.btnPosRight.Location = New System.Drawing.Point(500, 435)
        Me.btnPosRight.Name = "btnPosRight"
        Me.btnPosRight.Size = New System.Drawing.Size(110, 35)
        Me.btnPosRight.Text = "Right"

        '
        'grpGlobalSettings
        '
        Me.grpGlobalSettings.Controls.Add(Me.lblAnimationLabel)
        Me.grpGlobalSettings.Controls.Add(Me.cboAnimation)
        Me.grpGlobalSettings.Controls.Add(Me.lblDelayLabel)
        Me.grpGlobalSettings.Controls.Add(Me.numShowDelay)
        Me.grpGlobalSettings.Controls.Add(Me.lblAutoHideLabel)
        Me.grpGlobalSettings.Controls.Add(Me.numAutoHide)
        Me.grpGlobalSettings.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpGlobalSettings.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.grpGlobalSettings.Location = New System.Drawing.Point(20, 495)
        Me.grpGlobalSettings.Name = "grpGlobalSettings"
        Me.grpGlobalSettings.Size = New System.Drawing.Size(850, 120)
        Me.grpGlobalSettings.TabStop = False
        Me.grpGlobalSettings.Text = "6. Configuración Global"

        '
        'lblAnimationLabel
        '
        Me.lblAnimationLabel.AutoSize = True
        Me.lblAnimationLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAnimationLabel.Location = New System.Drawing.Point(20, 30)
        Me.lblAnimationLabel.Name = "lblAnimationLabel"
        Me.lblAnimationLabel.Text = "Animación:"

        '
        'cboAnimation
        '
        Me.cboAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnimation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboAnimation.FormattingEnabled = True
        Me.cboAnimation.Items.AddRange(New Object() {"None", "Fade", "Slide", "Zoom"})
        Me.cboAnimation.Location = New System.Drawing.Point(100, 27)
        Me.cboAnimation.Name = "cboAnimation"
        Me.cboAnimation.Size = New System.Drawing.Size(150, 25)
        Me.cboAnimation.SelectedIndex = 1

        '
        'lblDelayLabel
        '
        Me.lblDelayLabel.AutoSize = True
        Me.lblDelayLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDelayLabel.Location = New System.Drawing.Point(20, 65)
        Me.lblDelayLabel.Name = "lblDelayLabel"
        Me.lblDelayLabel.Text = "Show Delay (ms):"

        '
        'numShowDelay
        '
        Me.numShowDelay.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numShowDelay.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numShowDelay.Location = New System.Drawing.Point(130, 62)
        Me.numShowDelay.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numShowDelay.Name = "numShowDelay"
        Me.numShowDelay.Size = New System.Drawing.Size(120, 25)
        Me.numShowDelay.Value = New Decimal(New Integer() {300, 0, 0, 0})

        '
        'lblAutoHideLabel
        '
        Me.lblAutoHideLabel.AutoSize = True
        Me.lblAutoHideLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAutoHideLabel.Location = New System.Drawing.Point(280, 65)
        Me.lblAutoHideLabel.Name = "lblAutoHideLabel"
        Me.lblAutoHideLabel.Text = "Auto Hide (ms):"

        '
        'numAutoHide
        '
        Me.numAutoHide.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numAutoHide.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numAutoHide.Location = New System.Drawing.Point(390, 62)
        Me.numAutoHide.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numAutoHide.Name = "numAutoHide"
        Me.numAutoHide.Size = New System.Drawing.Size(120, 25)
        Me.numAutoHide.Value = New Decimal(New Integer() {5000, 0, 0, 0})

        '
        'lblComboBoxTitle
        '
        Me.lblComboBoxTitle.AutoSize = True
        Me.lblComboBoxTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblComboBoxTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblComboBoxTitle.Location = New System.Drawing.Point(20, 635)
        Me.lblComboBoxTitle.Name = "lblComboBoxTitle"
        Me.lblComboBoxTitle.Text = "7. NXComboBox - ComboBox Avanzado"

        '
        'lblComboSimple
        '
        Me.lblComboSimple.AutoSize = True
        Me.lblComboSimple.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblComboSimple.Location = New System.Drawing.Point(20, 675)
        Me.lblComboSimple.Name = "lblComboSimple"
        Me.lblComboSimple.Text = "Simple:"

        '
        'nxComboSimple
        '
        Me.nxComboSimple.Location = New System.Drawing.Point(120, 670)
        Me.nxComboSimple.Name = "nxComboSimple"
        Me.nxComboSimple.Size = New System.Drawing.Size(250, 32)

        '
        'lblComboIcons
        '
        Me.lblComboIcons.AutoSize = True
        Me.lblComboIcons.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblComboIcons.Location = New System.Drawing.Point(20, 720)
        Me.lblComboIcons.Name = "lblComboIcons"
        Me.lblComboIcons.Text = "Con Iconos:"

        '
        'nxComboWithIcons
        '
        Me.nxComboWithIcons.Location = New System.Drawing.Point(120, 715)
        Me.nxComboWithIcons.Name = "nxComboWithIcons"
        Me.nxComboWithIcons.Size = New System.Drawing.Size(250, 32)

        '
        'lblComboGroups
        '
        Me.lblComboGroups.AutoSize = True
        Me.lblComboGroups.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblComboGroups.Location = New System.Drawing.Point(20, 765)
        Me.lblComboGroups.Name = "lblComboGroups"
        Me.lblComboGroups.Text = "Con Grupos:"

        '
        'nxComboWithGroups
        '
        Me.nxComboWithGroups.Location = New System.Drawing.Point(120, 760)
        Me.nxComboWithGroups.Name = "nxComboWithGroups"
        Me.nxComboWithGroups.Size = New System.Drawing.Size(250, 32)

        '
        'lblComboMulti
        '
        Me.lblComboMulti.AutoSize = True
        Me.lblComboMulti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblComboMulti.Location = New System.Drawing.Point(20, 810)
        Me.lblComboMulti.Name = "lblComboMulti"
        Me.lblComboMulti.Text = "Multi-Selección:"

        '
        'nxComboMultiSelect
        '
        Me.nxComboMultiSelect.Location = New System.Drawing.Point(120, 805)
        Me.nxComboMultiSelect.Name = "nxComboMultiSelect"
        Me.nxComboMultiSelect.Size = New System.Drawing.Size(250, 32)
        Me.nxComboMultiSelect.MultiSelect = NeoSoft.UI.Controls.NXComboBox.SelectionMode.MultiCheckbox

        '
        'FormNXToolTipDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
        Me.ClientSize = New System.Drawing.Size(900, 900)
        Me.Controls.Add(Me.lblStylesTitle)
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.btnInfo)
        Me.Controls.Add(Me.btnSuccess)
        Me.Controls.Add(Me.btnWarning)
        Me.Controls.Add(Me.btnError)
        Me.Controls.Add(Me.btnDark)
        Me.Controls.Add(Me.lblIconsTitle)
        Me.Controls.Add(Me.btnIconInfo)
        Me.Controls.Add(Me.btnIconWarning)
        Me.Controls.Add(Me.btnIconError)
        Me.Controls.Add(Me.btnIconSuccess)
        Me.Controls.Add(Me.btnIconHelp)
        Me.Controls.Add(Me.lblTitlesTitle)
        Me.Controls.Add(Me.btnTitleSimple)
        Me.Controls.Add(Me.btnTitleIcon)
        Me.Controls.Add(Me.btnTitleLong)
        Me.Controls.Add(Me.lblHtmlTitle)
        Me.Controls.Add(Me.btnHtmlBold)
        Me.Controls.Add(Me.btnHtmlItalic)
        Me.Controls.Add(Me.btnHtmlMixed)
        Me.Controls.Add(Me.btnHtmlMultiline)
        Me.Controls.Add(Me.lblPositionTitle)
        Me.Controls.Add(Me.btnPosAuto)
        Me.Controls.Add(Me.btnPosTop)
        Me.Controls.Add(Me.btnPosBottom)
        Me.Controls.Add(Me.btnPosLeft)
        Me.Controls.Add(Me.btnPosRight)
        Me.Controls.Add(Me.grpGlobalSettings)
        Me.Controls.Add(Me.lblComboBoxTitle)
        Me.Controls.Add(Me.lblComboSimple)
        Me.Controls.Add(Me.nxComboSimple)
        Me.Controls.Add(Me.lblComboIcons)
        Me.Controls.Add(Me.nxComboWithIcons)
        Me.Controls.Add(Me.lblComboGroups)
        Me.Controls.Add(Me.nxComboWithGroups)
        Me.Controls.Add(Me.lblComboMulti)
        Me.Controls.Add(Me.nxComboMultiSelect)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FormNXToolTipDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NXToolTip & NXComboBox - Demostración Completa"
        Me.grpGlobalSettings.ResumeLayout(False)
        Me.grpGlobalSettings.PerformLayout()
        CType(Me.numShowDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAutoHide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

        '
        'FormNXToolTipDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
        Me.ClientSize = New System.Drawing.Size(900, 900)
        Me.Controls.Add(Me.lblStylesTitle)
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.btnInfo)
        Me.Controls.Add(Me.btnSuccess)
        Me.Controls.Add(Me.btnWarning)
        Me.Controls.Add(Me.btnError)
        Me.Controls.Add(Me.btnDark)
        Me.Controls.Add(Me.lblIconsTitle)
        Me.Controls.Add(Me.btnIconInfo)
        Me.Controls.Add(Me.btnIconWarning)
        Me.Controls.Add(Me.btnIconError)
        Me.Controls.Add(Me.btnIconSuccess)
        Me.Controls.Add(Me.btnIconHelp)
        Me.Controls.Add(Me.lblTitlesTitle)
        Me.Controls.Add(Me.btnTitleSimple)
        Me.Controls.Add(Me.btnTitleIcon)
        Me.Controls.Add(Me.btnTitleLong)
        Me.Controls.Add(Me.lblHtmlTitle)
        Me.Controls.Add(Me.btnHtmlBold)
        Me.Controls.Add(Me.btnHtmlItalic)
        Me.Controls.Add(Me.btnHtmlMixed)
        Me.Controls.Add(Me.btnHtmlMultiline)
        Me.Controls.Add(Me.lblPositionTitle)
        Me.Controls.Add(Me.btnPosAuto)
        Me.Controls.Add(Me.btnPosTop)
        Me.Controls.Add(Me.btnPosBottom)
        Me.Controls.Add(Me.btnPosLeft)
        Me.Controls.Add(Me.btnPosRight)
        Me.Controls.Add(Me.grpGlobalSettings)
        Me.Controls.Add(Me.lblComboBoxTitle)
        Me.Controls.Add(Me.lblComboSimple)
        Me.Controls.Add(Me.nxComboSimple)
        Me.Controls.Add(Me.lblComboIcons)
        Me.Controls.Add(Me.nxComboWithIcons)
        Me.Controls.Add(Me.lblComboGroups)
        Me.Controls.Add(Me.nxComboWithGroups)
        Me.Controls.Add(Me.lblComboMulti)
        Me.Controls.Add(Me.nxComboMultiSelect)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FormNXToolTipDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NXToolTip & NXComboBox - Demostración Completa"
        Me.grpGlobalSettings.ResumeLayout(False)
        Me.grpGlobalSettings.PerformLayout()
        CType(Me.numShowDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAutoHide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nxToolTip1 As NeoSoft.UI.Controls.NXToolTip
    Friend WithEvents lblStylesTitle As Label
    Friend WithEvents btnDefault As Button
    Friend WithEvents btnInfo As Button
    Friend WithEvents btnSuccess As Button
    Friend WithEvents btnWarning As Button
    Friend WithEvents btnError As Button
    Friend WithEvents btnDark As Button
    Friend WithEvents lblIconsTitle As Label
    Friend WithEvents btnIconInfo As Button
    Friend WithEvents btnIconWarning As Button
    Friend WithEvents btnIconError As Button
    Friend WithEvents btnIconSuccess As Button
    Friend WithEvents btnIconHelp As Button
    Friend WithEvents lblTitlesTitle As Label
    Friend WithEvents btnTitleSimple As Button
    Friend WithEvents btnTitleIcon As Button
    Friend WithEvents btnTitleLong As Button
    Friend WithEvents lblHtmlTitle As Label
    Friend WithEvents btnHtmlBold As Button
    Friend WithEvents btnHtmlItalic As Button
    Friend WithEvents btnHtmlMixed As Button
    Friend WithEvents btnHtmlMultiline As Button
    Friend WithEvents lblPositionTitle As Label
    Friend WithEvents btnPosAuto As Button
    Friend WithEvents btnPosTop As Button
    Friend WithEvents btnPosBottom As Button
    Friend WithEvents btnPosLeft As Button
    Friend WithEvents btnPosRight As Button
    Friend WithEvents grpGlobalSettings As GroupBox
    Friend WithEvents lblAnimationLabel As Label
    Friend WithEvents cboAnimation As ComboBox
    Friend WithEvents lblDelayLabel As Label
    Friend WithEvents numShowDelay As NumericUpDown
    Friend WithEvents lblAutoHideLabel As Label
    Friend WithEvents numAutoHide As NumericUpDown
    Friend WithEvents lblComboBoxTitle As Label
    Friend WithEvents lblComboSimple As Label
    Friend WithEvents nxComboSimple As NeoSoft.UI.Controls.NXComboBox
    Friend WithEvents lblComboIcons As Label
    Friend WithEvents nxComboWithIcons As NeoSoft.UI.Controls.NXComboBox
    Friend WithEvents lblComboGroups As Label
    Friend WithEvents nxComboWithGroups As NeoSoft.UI.Controls.NXComboBox
    Friend WithEvents lblComboMulti As Label
    Friend WithEvents nxComboMultiSelect As NeoSoft.UI.Controls.NXComboBox

End Class