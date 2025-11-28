<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNXCheckComboBoxDemo
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
        Me.lblMainTitle = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.nxCheckCombo1 = New NeoSoft.UI.Controls.NXCheckComboBox()
        Me.lblStatus1 = New System.Windows.Forms.Label()
        Me.lblSelection1 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.nxCheckCombo2 = New NeoSoft.UI.Controls.NXCheckComboBox()
        Me.lblStatus2 = New System.Windows.Forms.Label()
        Me.lblSelection2 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.nxCheckCombo3 = New NeoSoft.UI.Controls.NXCheckComboBox()
        Me.lblStatus3 = New System.Windows.Forms.Label()
        Me.lblSelection3 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.nxCheckCombo4 = New NeoSoft.UI.Controls.NXCheckComboBox()
        Me.lblStatus4 = New System.Windows.Forms.Label()
        Me.lblSelection4 = New System.Windows.Forms.Label()
        Me.tabControlListBox = New System.Windows.Forms.TabControl()
        Me.tabListSimple = New System.Windows.Forms.TabPage()
        Me.lblInfoSimple = New System.Windows.Forms.Label()
        Me.lblListSelection = New System.Windows.Forms.Label()
        Me.btnRemoveListItem = New System.Windows.Forms.Button()
        Me.btnAddListItem = New System.Windows.Forms.Button()
        Me.nxListSimple = New NeoSoft.UI.Controls.NXListBox()
        Me.lblTitleListSimple = New System.Windows.Forms.Label()
        Me.tabListCheckboxes = New System.Windows.Forms.TabPage()
        Me.lblCheckedListCount = New System.Windows.Forms.Label()
        Me.btnUncheckAllList = New System.Windows.Forms.Button()
        Me.btnCheckAllList = New System.Windows.Forms.Button()
        Me.nxListCheckboxes = New NeoSoft.UI.Controls.NXListBox()
        Me.lblTitleListCheckboxes = New System.Windows.Forms.Label()
        Me.tabListIcons = New System.Windows.Forms.TabPage()
        Me.lblContactListInfo = New System.Windows.Forms.Label()
        Me.btnAddContactList = New System.Windows.Forms.Button()
        Me.nxListIcons = New NeoSoft.UI.Controls.NXListBox()
        Me.lblTitleListIcons = New System.Windows.Forms.Label()
        Me.tabControlListBox.SuspendLayout()
        Me.tabListSimple.SuspendLayout()
        Me.tabListCheckboxes.SuspendLayout()
        Me.tabListIcons.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMainTitle
        '
        Me.lblMainTitle.AutoSize = True
        Me.lblMainTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblMainTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblMainTitle.Name = "lblMainTitle"
        Me.lblMainTitle.Size = New System.Drawing.Size(500, 30)
        Me.lblMainTitle.TabIndex = 0
        Me.lblMainTitle.Text = "NXCheckComboBox & NXListBox - Demo"
        '
        'lblTitle1
        '
        Me.lblTitle1.AutoSize = True
        Me.lblTitle1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle1.Location = New System.Drawing.Point(20, 70)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(259, 20)
        Me.lblTitle1.TabIndex = 1
        Me.lblTitle1.Text = "1. Selector Simple (☐ + ComboBox)"
        '
        'nxCheckCombo1
        '
        Me.nxCheckCombo1.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo1.BackColor = System.Drawing.Color.Transparent
        Me.nxCheckCombo1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxCheckCombo1.Checked = False
        Me.nxCheckCombo1.ComboBoxWidth = 200
        Me.nxCheckCombo1.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo1.Location = New System.Drawing.Point(25, 100)
        Me.nxCheckCombo1.Name = "nxCheckCombo1"
        Me.nxCheckCombo1.ReadOnly = True
        Me.nxCheckCombo1.Size = New System.Drawing.Size(224, 32)
        Me.nxCheckCombo1.Spacing = 4
        Me.nxCheckCombo1.TabIndex = 2
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblStatus1.Location = New System.Drawing.Point(25, 140)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(120, 15)
        Me.lblStatus1.TabIndex = 3
        Me.lblStatus1.Text = "Estado: Deshabilitado"
        '
        'lblSelection1
        '
        Me.lblSelection1.AutoSize = True
        Me.lblSelection1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSelection1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSelection1.Location = New System.Drawing.Point(25, 160)
        Me.lblSelection1.Name = "lblSelection1"
        Me.lblSelection1.Size = New System.Drawing.Size(115, 15)
        Me.lblSelection1.TabIndex = 4
        Me.lblSelection1.Text = "Selección: (ninguna)"
        '
        'lblTitle2
        '
        Me.lblTitle2.AutoSize = True
        Me.lblTitle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle2.Location = New System.Drawing.Point(20, 200)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(229, 20)
        Me.lblTitle2.TabIndex = 5
        Me.lblTitle2.Text = "2. Con Iconos (☐ + ComboBox)"
        '
        'nxCheckCombo2
        '
        Me.nxCheckCombo2.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo2.BackColor = System.Drawing.Color.Transparent
        Me.nxCheckCombo2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxCheckCombo2.Checked = False
        Me.nxCheckCombo2.ComboBoxWidth = 200
        Me.nxCheckCombo2.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo2.Location = New System.Drawing.Point(25, 230)
        Me.nxCheckCombo2.Name = "nxCheckCombo2"
        Me.nxCheckCombo2.ReadOnly = True
        Me.nxCheckCombo2.Size = New System.Drawing.Size(224, 32)
        Me.nxCheckCombo2.Spacing = 4
        Me.nxCheckCombo2.TabIndex = 6
        '
        'lblStatus2
        '
        Me.lblStatus2.AutoSize = True
        Me.lblStatus2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblStatus2.Location = New System.Drawing.Point(25, 270)
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(120, 15)
        Me.lblStatus2.TabIndex = 7
        Me.lblStatus2.Text = "Estado: Deshabilitado"
        '
        'lblSelection2
        '
        Me.lblSelection2.AutoSize = True
        Me.lblSelection2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSelection2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSelection2.Location = New System.Drawing.Point(25, 290)
        Me.lblSelection2.Name = "lblSelection2"
        Me.lblSelection2.Size = New System.Drawing.Size(115, 15)
        Me.lblSelection2.TabIndex = 8
        Me.lblSelection2.Text = "Selección: (ninguna)"
        '
        'lblTitle3
        '
        Me.lblTitle3.AutoSize = True
        Me.lblTitle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle3.Location = New System.Drawing.Point(20, 330)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(234, 20)
        Me.lblTitle3.TabIndex = 9
        Me.lblTitle3.Text = "3. Con Grupos (☐ + ComboBox)"
        '
        'nxCheckCombo3
        '
        Me.nxCheckCombo3.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo3.BackColor = System.Drawing.Color.Transparent
        Me.nxCheckCombo3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxCheckCombo3.Checked = False
        Me.nxCheckCombo3.ComboBoxWidth = 200
        Me.nxCheckCombo3.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo3.Location = New System.Drawing.Point(25, 360)
        Me.nxCheckCombo3.Name = "nxCheckCombo3"
        Me.nxCheckCombo3.ReadOnly = True
        Me.nxCheckCombo3.Size = New System.Drawing.Size(224, 32)
        Me.nxCheckCombo3.Spacing = 4
        Me.nxCheckCombo3.TabIndex = 10
        '
        'lblStatus3
        '
        Me.lblStatus3.AutoSize = True
        Me.lblStatus3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblStatus3.Location = New System.Drawing.Point(25, 400)
        Me.lblStatus3.Name = "lblStatus3"
        Me.lblStatus3.Size = New System.Drawing.Size(120, 15)
        Me.lblStatus3.TabIndex = 11
        Me.lblStatus3.Text = "Estado: Deshabilitado"
        '
        'lblSelection3
        '
        Me.lblSelection3.AutoSize = True
        Me.lblSelection3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSelection3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSelection3.Location = New System.Drawing.Point(25, 420)
        Me.lblSelection3.Name = "lblSelection3"
        Me.lblSelection3.Size = New System.Drawing.Size(115, 15)
        Me.lblSelection3.TabIndex = 12
        Me.lblSelection3.Text = "Selección: (ninguna)"
        '
        'lblTitle4
        '
        Me.lblTitle4.AutoSize = True
        Me.lblTitle4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle4.Location = New System.Drawing.Point(20, 460)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(259, 20)
        Me.lblTitle4.TabIndex = 13
        Me.lblTitle4.Text = "4. Multi-Selección (☐ + ComboBox)"
        '
        'nxCheckCombo4
        '
        Me.nxCheckCombo4.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo4.BackColor = System.Drawing.Color.Transparent
        Me.nxCheckCombo4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxCheckCombo4.Checked = False
        Me.nxCheckCombo4.ComboBoxWidth = 200
        Me.nxCheckCombo4.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxCheckCombo4.Location = New System.Drawing.Point(25, 490)
        Me.nxCheckCombo4.Name = "nxCheckCombo4"
        Me.nxCheckCombo4.ReadOnly = True
        Me.nxCheckCombo4.Size = New System.Drawing.Size(224, 32)
        Me.nxCheckCombo4.Spacing = 4
        Me.nxCheckCombo4.TabIndex = 14
        '
        'lblStatus4
        '
        Me.lblStatus4.AutoSize = True
        Me.lblStatus4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblStatus4.Location = New System.Drawing.Point(25, 530)
        Me.lblStatus4.Name = "lblStatus4"
        Me.lblStatus4.Size = New System.Drawing.Size(120, 15)
        Me.lblStatus4.TabIndex = 15
        Me.lblStatus4.Text = "Estado: Deshabilitado"
        '
        'lblSelection4
        '
        Me.lblSelection4.AutoSize = True
        Me.lblSelection4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSelection4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSelection4.Location = New System.Drawing.Point(25, 550)
        Me.lblSelection4.Name = "lblSelection4"
        Me.lblSelection4.Size = New System.Drawing.Size(115, 15)
        Me.lblSelection4.TabIndex = 16
        Me.lblSelection4.Text = "Selección: (ninguna)"
        '
        'tabControlListBox
        '
        Me.tabControlListBox.Controls.Add(Me.tabListSimple)
        Me.tabControlListBox.Controls.Add(Me.tabListCheckboxes)
        Me.tabControlListBox.Controls.Add(Me.tabListIcons)
        Me.tabControlListBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tabControlListBox.Location = New System.Drawing.Point(300, 20)
        Me.tabControlListBox.Name = "tabControlListBox"
        Me.tabControlListBox.SelectedIndex = 0
        Me.tabControlListBox.Size = New System.Drawing.Size(580, 560)
        Me.tabControlListBox.TabIndex = 17
        '
        'tabListSimple
        '
        Me.tabListSimple.BackColor = System.Drawing.Color.White
        Me.tabListSimple.Controls.Add(Me.lblInfoSimple)
        Me.tabListSimple.Controls.Add(Me.lblListSelection)
        Me.tabListSimple.Controls.Add(Me.btnRemoveListItem)
        Me.tabListSimple.Controls.Add(Me.btnAddListItem)
        Me.tabListSimple.Controls.Add(Me.nxListSimple)
        Me.tabListSimple.Controls.Add(Me.lblTitleListSimple)
        Me.tabListSimple.Location = New System.Drawing.Point(4, 24)
        Me.tabListSimple.Name = "tabListSimple"
        Me.tabListSimple.Padding = New System.Windows.Forms.Padding(3)
        Me.tabListSimple.Size = New System.Drawing.Size(572, 532)
        Me.tabListSimple.TabIndex = 0
        Me.tabListSimple.Text = "Lista Simple"
        '
        'lblTitleListSimple
        '
        Me.lblTitleListSimple.AutoSize = True
        Me.lblTitleListSimple.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleListSimple.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitleListSimple.Location = New System.Drawing.Point(10, 10)
        Me.lblTitleListSimple.Name = "lblTitleListSimple"
        Me.lblTitleListSimple.Size = New System.Drawing.Size(210, 21)
        Me.lblTitleListSimple.TabIndex = 0
        Me.lblTitleListSimple.Text = "NXListBox - Lista Simple"
        '
        'nxListSimple
        '
        Me.nxListSimple.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxListSimple.AlternateColor1 = System.Drawing.Color.White
        Me.nxListSimple.AlternateColor2 = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nxListSimple.AlternateRowColors = True
        Me.nxListSimple.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxListSimple.EnableDragDrop = False
        Me.nxListSimple.EnableSearch = True
        Me.nxListSimple.HoverColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.nxListSimple.IconSize = New System.Drawing.Size(16, 16)
        Me.nxListSimple.ItemHeight = 28
        Me.nxListSimple.Location = New System.Drawing.Point(10, 45)
        Me.nxListSimple.Name = "nxListSimple"
        Me.nxListSimple.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.nxListSimple.SelectionMode = NeoSoft.UI.Controls.NXListBox.SelectionModeType.Single
        Me.nxListSimple.ShowCheckboxes = False
        Me.nxListSimple.Size = New System.Drawing.Size(350, 430)
        Me.nxListSimple.TabIndex = 1
        Me.nxListSimple.UseTheme = False
        Me.nxListSimple.View = NeoSoft.UI.Controls.NXListBox.ViewStyle.List
        '
        'btnAddListItem
        '
        Me.btnAddListItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnAddListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddListItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddListItem.ForeColor = System.Drawing.Color.White
        Me.btnAddListItem.Location = New System.Drawing.Point(380, 45)
        Me.btnAddListItem.Name = "btnAddListItem"
        Me.btnAddListItem.Size = New System.Drawing.Size(150, 35)
        Me.btnAddListItem.TabIndex = 2
        Me.btnAddListItem.Text = "➕ Agregar Item"
        Me.btnAddListItem.UseVisualStyleBackColor = False
        '
        'btnRemoveListItem
        '
        Me.btnRemoveListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveListItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRemoveListItem.Location = New System.Drawing.Point(380, 90)
        Me.btnRemoveListItem.Name = "btnRemoveListItem"
        Me.btnRemoveListItem.Size = New System.Drawing.Size(150, 35)
        Me.btnRemoveListItem.TabIndex = 3
        Me.btnRemoveListItem.Text = "🗑️ Eliminar Selección"
        Me.btnRemoveListItem.UseVisualStyleBackColor = True
        '
        'lblListSelection
        '
        Me.lblListSelection.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblListSelection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblListSelection.Location = New System.Drawing.Point(380, 140)
        Me.lblListSelection.Name = "lblListSelection"
        Me.lblListSelection.Size = New System.Drawing.Size(180, 150)
        Me.lblListSelection.TabIndex = 4
        Me.lblListSelection.Text = "Selección: (ninguna)"
        '
        'lblInfoSimple
        '
        Me.lblInfoSimple.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblInfoSimple.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblInfoSimple.Location = New System.Drawing.Point(380, 300)
        Me.lblInfoSimple.Name = "lblInfoSimple"
        Me.lblInfoSimple.Size = New System.Drawing.Size(180, 150)
        Me.lblInfoSimple.TabIndex = 5
        Me.lblInfoSimple.Text = "💡 Características:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "• Virtualización" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "• Búsqueda rápida" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "• Scroll fluido" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "• Colores alternados"
        '
        'tabListCheckboxes
        '
        Me.tabListCheckboxes.BackColor = System.Drawing.Color.White
        Me.tabListCheckboxes.Controls.Add(Me.lblCheckedListCount)
        Me.tabListCheckboxes.Controls.Add(Me.btnUncheckAllList)
        Me.tabListCheckboxes.Controls.Add(Me.btnCheckAllList)
        Me.tabListCheckboxes.Controls.Add(Me.nxListCheckboxes)
        Me.tabListCheckboxes.Controls.Add(Me.lblTitleListCheckboxes)
        Me.tabListCheckboxes.Location = New System.Drawing.Point(4, 24)
        Me.tabListCheckboxes.Name = "tabListCheckboxes"
        Me.tabListCheckboxes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabListCheckboxes.Size = New System.Drawing.Size(572, 532)
        Me.tabListCheckboxes.TabIndex = 1
        Me.tabListCheckboxes.Text = "Con Checkboxes"
        '
        'lblTitleListCheckboxes
        '
        Me.lblTitleListCheckboxes.AutoSize = True
        Me.lblTitleListCheckboxes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleListCheckboxes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitleListCheckboxes.Location = New System.Drawing.Point(10, 10)
        Me.lblTitleListCheckboxes.Name = "lblTitleListCheckboxes"
        Me.lblTitleListCheckboxes.Size = New System.Drawing.Size(390, 21)
        Me.lblTitleListCheckboxes.TabIndex = 0
        Me.lblTitleListCheckboxes.Text = "NXListBox - Multi-selección con Checkboxes"
        '
        'nxListCheckboxes
        '
        Me.nxListCheckboxes.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxListCheckboxes.AlternateColor1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.nxListCheckboxes.AlternateColor2 = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.nxListCheckboxes.AlternateRowColors = True
        Me.nxListCheckboxes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxListCheckboxes.EnableDragDrop = False
        Me.nxListCheckboxes.EnableSearch = True
        Me.nxListCheckboxes.HoverColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.nxListCheckboxes.IconSize = New System.Drawing.Size(16, 16)
        Me.nxListCheckboxes.ItemHeight = 28
        Me.nxListCheckboxes.Location = New System.Drawing.Point(10, 45)
        Me.nxListCheckboxes.Name = "nxListCheckboxes"
        Me.nxListCheckboxes.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.nxListCheckboxes.SelectionMode = NeoSoft.UI.Controls.NXListBox.SelectionModeType.MultiCheckbox
        Me.nxListCheckboxes.ShowCheckboxes = True
        Me.nxListCheckboxes.Size = New System.Drawing.Size(350, 430)
        Me.nxListCheckboxes.TabIndex = 1
        Me.nxListCheckboxes.UseTheme = False
        Me.nxListCheckboxes.View = NeoSoft.UI.Controls.NXListBox.ViewStyle.List
        '
        'btnCheckAllList
        '
        Me.btnCheckAllList.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnCheckAllList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckAllList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckAllList.ForeColor = System.Drawing.Color.White
        Me.btnCheckAllList.Location = New System.Drawing.Point(380, 45)
        Me.btnCheckAllList.Name = "btnCheckAllList"
        Me.btnCheckAllList.Size = New System.Drawing.Size(150, 35)
        Me.btnCheckAllList.TabIndex = 2
        Me.btnCheckAllList.Text = "☑️ Marcar Todos"
        Me.btnCheckAllList.UseVisualStyleBackColor = False
        '
        'btnUncheckAllList
        '
        Me.btnUncheckAllList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUncheckAllList.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUncheckAllList.Location = New System.Drawing.Point(380, 90)
        Me.btnUncheckAllList.Name = "btnUncheckAllList"
        Me.btnUncheckAllList.Size = New System.Drawing.Size(150, 35)
        Me.btnUncheckAllList.TabIndex = 3
        Me.btnUncheckAllList.Text = "☐ Desmarcar Todos"
        Me.btnUncheckAllList.UseVisualStyleBackColor = True
        '
        'lblCheckedListCount
        '
        Me.lblCheckedListCount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCheckedListCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblCheckedListCount.Location = New System.Drawing.Point(380, 140)
        Me.lblCheckedListCount.Name = "lblCheckedListCount"
        Me.lblCheckedListCount.Size = New System.Drawing.Size(180, 200)
        Me.lblCheckedListCount.TabIndex = 4
        Me.lblCheckedListCount.Text = "Items marcados: 0"
        '
        'tabListIcons
        '
        Me.tabListIcons.BackColor = System.Drawing.Color.White
        Me.tabListIcons.Controls.Add(Me.lblContactListInfo)
        Me.tabListIcons.Controls.Add(Me.btnAddContactList)
        Me.tabListIcons.Controls.Add(Me.nxListIcons)
        Me.tabListIcons.Controls.Add(Me.lblTitleListIcons)
        Me.tabListIcons.Location = New System.Drawing.Point(4, 24)
        Me.tabListIcons.Name = "tabListIcons"
        Me.tabListIcons.Size = New System.Drawing.Size(572, 532)
        Me.tabListIcons.TabIndex = 2
        Me.tabListIcons.Text = "Con Iconos"
        '
        'lblTitleListIcons
        '
        Me.lblTitleListIcons.AutoSize = True
        Me.lblTitleListIcons.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleListIcons.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitleListIcons.Location = New System.Drawing.Point(10, 10)
        Me.lblTitleListIcons.Name = "lblTitleListIcons"
        Me.lblTitleListIcons.Size = New System.Drawing.Size(360, 21)
        Me.lblTitleListIcons.TabIndex = 0
        Me.lblTitleListIcons.Text = "NXListBox - Lista con Iconos y Sub-items"
        '
        'nxListIcons
        '
        Me.nxListIcons.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nxListIcons.AlternateColor1 = System.Drawing.Color.White
        Me.nxListIcons.AlternateColor2 = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nxListIcons.AlternateRowColors = True
        Me.nxListIcons.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.nxListIcons.EnableDragDrop = False
        Me.nxListIcons.EnableSearch = True
        Me.nxListIcons.HoverColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.nxListIcons.IconSize = New System.Drawing.Size(32, 32)
        Me.nxListIcons.ItemHeight = 50
        Me.nxListIcons.Location = New System.Drawing.Point(10, 45)
        Me.nxListIcons.Name = "nxListIcons"
        Me.nxListIcons.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.nxListIcons.SelectionMode = NeoSoft.UI.Controls.NXListBox.SelectionModeType.Single
        Me.nxListIcons.ShowCheckboxes = False
        Me.nxListIcons.Size = New System.Drawing.Size(350, 430)
        Me.nxListIcons.TabIndex = 1
        Me.nxListIcons.UseTheme = False
        Me.nxListIcons.View = NeoSoft.UI.Controls.NXListBox.ViewStyle.Details
        '
        'btnAddContactList
        '
        Me.btnAddContactList.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnAddContactList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddContactList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddContactList.ForeColor = System.Drawing.Color.White
        Me.btnAddContactList.Location = New System.Drawing.Point(380, 45)
        Me.btnAddContactList.Name = "btnAddContactList"
        Me.btnAddContactList.Size = New System.Drawing.Size(150, 35)
        Me.btnAddContactList.TabIndex = 2
        Me.btnAddContactList.Text = "👤 Agregar Contacto"
        Me.btnAddContactList.UseVisualStyleBackColor = False
        '
        'lblContactListInfo
        '
        Me.lblContactListInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblContactListInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblContactListInfo.Location = New System.Drawing.Point(380, 90)
        Me.lblContactListInfo.Name = "lblContactListInfo"
        Me.lblContactListInfo.Size = New System.Drawing.Size(180, 250)
        Me.lblContactListInfo.TabIndex = 3
        Me.lblContactListInfo.Text = "📇 Información del Contacto" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Selecciona un contacto para ver sus detalles."
        '
        'FormNXCheckComboBoxDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.tabControlListBox)
        Me.Controls.Add(Me.lblSelection4)
        Me.Controls.Add(Me.lblStatus4)
        Me.Controls.Add(Me.nxCheckCombo4)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblSelection3)
        Me.Controls.Add(Me.lblStatus3)
        Me.Controls.Add(Me.nxCheckCombo3)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblSelection2)
        Me.Controls.Add(Me.lblStatus2)
        Me.Controls.Add(Me.nxCheckCombo2)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblSelection1)
        Me.Controls.Add(Me.lblStatus1)
        Me.Controls.Add(Me.nxCheckCombo1)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblMainTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormNXCheckComboBoxDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NeoSoft.UI - NXCheckComboBox & NXListBox Demo"
        Me.tabControlListBox.ResumeLayout(False)
        Me.tabListSimple.ResumeLayout(False)
        Me.tabListSimple.PerformLayout()
        Me.tabListCheckboxes.ResumeLayout(False)
        Me.tabListCheckboxes.PerformLayout()
        Me.tabListIcons.ResumeLayout(False)
        Me.tabListIcons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMainTitle As System.Windows.Forms.Label
    Friend WithEvents lblTitle1 As System.Windows.Forms.Label
    Friend WithEvents nxCheckCombo1 As NeoSoft.UI.Controls.NXCheckComboBox
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents lblSelection1 As System.Windows.Forms.Label
    Friend WithEvents lblTitle2 As System.Windows.Forms.Label
    Friend WithEvents nxCheckCombo2 As NeoSoft.UI.Controls.NXCheckComboBox
    Friend WithEvents lblStatus2 As System.Windows.Forms.Label
    Friend WithEvents lblSelection2 As System.Windows.Forms.Label
    Friend WithEvents lblTitle3 As System.Windows.Forms.Label
    Friend WithEvents nxCheckCombo3 As NeoSoft.UI.Controls.NXCheckComboBox
    Friend WithEvents lblStatus3 As System.Windows.Forms.Label
    Friend WithEvents lblSelection3 As System.Windows.Forms.Label
    Friend WithEvents lblTitle4 As System.Windows.Forms.Label
    Friend WithEvents nxCheckCombo4 As NeoSoft.UI.Controls.NXCheckComboBox
    Friend WithEvents lblStatus4 As System.Windows.Forms.Label
    Friend WithEvents lblSelection4 As System.Windows.Forms.Label
    Friend WithEvents tabControlListBox As System.Windows.Forms.TabControl
    Friend WithEvents tabListSimple As System.Windows.Forms.TabPage
    Friend WithEvents lblInfoSimple As System.Windows.Forms.Label
    Friend WithEvents lblListSelection As System.Windows.Forms.Label
    Friend WithEvents btnRemoveListItem As System.Windows.Forms.Button
    Friend WithEvents btnAddListItem As System.Windows.Forms.Button
    Friend WithEvents nxListSimple As NeoSoft.UI.Controls.NXListBox
    Friend WithEvents lblTitleListSimple As System.Windows.Forms.Label
    Friend WithEvents tabListCheckboxes As System.Windows.Forms.TabPage
    Friend WithEvents lblCheckedListCount As System.Windows.Forms.Label
    Friend WithEvents btnUncheckAllList As System.Windows.Forms.Button
    Friend WithEvents btnCheckAllList As System.Windows.Forms.Button
    Friend WithEvents nxListCheckboxes As NeoSoft.UI.Controls.NXListBox
    Friend WithEvents lblTitleListCheckboxes As System.Windows.Forms.Label
    Friend WithEvents tabListIcons As System.Windows.Forms.TabPage
    Friend WithEvents lblContactListInfo As System.Windows.Forms.Label
    Friend WithEvents btnAddContactList As System.Windows.Forms.Button
    Friend WithEvents nxListIcons As NeoSoft.UI.Controls.NXListBox
    Friend WithEvents lblTitleListIcons As System.Windows.Forms.Label
End Class