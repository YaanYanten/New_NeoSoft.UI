<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NXImagePickerDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NXImagePickerDialog))
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabImagePicker = New System.Windows.Forms.TabPage()
        Me.panelPreview = New System.Windows.Forms.Panel()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.grpResourceContext = New System.Windows.Forms.GroupBox()
        Me.panelProjectResource = New System.Windows.Forms.Panel()
        Me.btnImportProject = New System.Windows.Forms.Button()
        Me.txtProjectResource = New System.Windows.Forms.TextBox()
        Me.lblProjectResource = New System.Windows.Forms.Label()
        Me.rbProjectResource = New System.Windows.Forms.RadioButton()
        Me.panelLocalResource = New System.Windows.Forms.Panel()
        Me.btnImportLocal = New System.Windows.Forms.Button()
        Me.btnClearLocal = New System.Windows.Forms.Button()
        Me.lstLocalResources = New System.Windows.Forms.ListBox()
        Me.rbLocalResource = New System.Windows.Forms.RadioButton()
        Me.tabRasterImages = New System.Windows.Forms.TabPage()
        Me.flowRasterIcons = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelRasterFilters = New System.Windows.Forms.Panel()
        Me.lblCategories = New System.Windows.Forms.Label()
        Me.chkListCategories = New System.Windows.Forms.CheckedListBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.chkListSize = New System.Windows.Forms.CheckedListBox()
        Me.txtRasterSearch = New System.Windows.Forms.TextBox()
        Me.rbAddToForm = New System.Windows.Forms.RadioButton()
        Me.rbAddToProject = New System.Windows.Forms.RadioButton()
        Me.tabVectorImages = New System.Windows.Forms.TabPage()
        Me.tabFontIcons = New System.Windows.Forms.TabPage()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout()
        Me.tabImagePicker.SuspendLayout()
        Me.panelPreview.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLeft.SuspendLayout()
        Me.grpResourceContext.SuspendLayout()
        Me.panelProjectResource.SuspendLayout()
        Me.panelLocalResource.SuspendLayout()
        Me.tabRasterImages.SuspendLayout()
        Me.panelRasterFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabImagePicker)
        Me.tabControl.Controls.Add(Me.tabRasterImages)
        Me.tabControl.Controls.Add(Me.tabVectorImages)
        Me.tabControl.Controls.Add(Me.tabFontIcons)
        Me.tabControl.Location = New System.Drawing.Point(12, 12)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(660, 520)
        Me.tabControl.TabIndex = 0
        '
        'tabImagePicker
        '
        Me.tabImagePicker.Controls.Add(Me.panelPreview)
        Me.tabImagePicker.Controls.Add(Me.panelLeft)
        Me.tabImagePicker.Location = New System.Drawing.Point(4, 24)
        Me.tabImagePicker.Name = "tabImagePicker"
        Me.tabImagePicker.Padding = New System.Windows.Forms.Padding(3)
        Me.tabImagePicker.Size = New System.Drawing.Size(652, 492)
        Me.tabImagePicker.TabIndex = 0
        Me.tabImagePicker.Text = "Image Picker"
        Me.tabImagePicker.UseVisualStyleBackColor = True
        '
        'panelPreview
        '
        Me.panelPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelPreview.BackColor = System.Drawing.Color.Gray
        Me.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPreview.Controls.Add(Me.picPreview)
        Me.panelPreview.Location = New System.Drawing.Point(290, 10)
        Me.panelPreview.Name = "panelPreview"
        Me.panelPreview.Size = New System.Drawing.Size(350, 470)
        Me.panelPreview.TabIndex = 1
        '
        'picPreview
        '
        Me.picPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview.Location = New System.Drawing.Point(0, 0)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(348, 468)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picPreview.TabIndex = 0
        Me.picPreview.TabStop = False
        '
        'panelLeft
        '
        Me.panelLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panelLeft.Controls.Add(Me.grpResourceContext)
        Me.panelLeft.Location = New System.Drawing.Point(10, 10)
        Me.panelLeft.Name = "panelLeft"
        Me.panelLeft.Size = New System.Drawing.Size(270, 470)
        Me.panelLeft.TabIndex = 0
        '
        'grpResourceContext
        '
        Me.grpResourceContext.Controls.Add(Me.panelProjectResource)
        Me.grpResourceContext.Controls.Add(Me.rbProjectResource)
        Me.grpResourceContext.Controls.Add(Me.panelLocalResource)
        Me.grpResourceContext.Controls.Add(Me.rbLocalResource)
        Me.grpResourceContext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpResourceContext.Location = New System.Drawing.Point(0, 0)
        Me.grpResourceContext.Name = "grpResourceContext"
        Me.grpResourceContext.Size = New System.Drawing.Size(270, 470)
        Me.grpResourceContext.TabIndex = 0
        Me.grpResourceContext.TabStop = False
        Me.grpResourceContext.Text = "Resource context"
        '
        'panelProjectResource
        '
        Me.panelProjectResource.Controls.Add(Me.btnImportProject)
        Me.panelProjectResource.Controls.Add(Me.txtProjectResource)
        Me.panelProjectResource.Controls.Add(Me.lblProjectResource)
        Me.panelProjectResource.Enabled = False
        Me.panelProjectResource.Location = New System.Drawing.Point(15, 310)
        Me.panelProjectResource.Name = "panelProjectResource"
        Me.panelProjectResource.Size = New System.Drawing.Size(240, 150)
        Me.panelProjectResource.TabIndex = 3
        '
        'btnImportProject
        '
        Me.btnImportProject.Location = New System.Drawing.Point(10, 110)
        Me.btnImportProject.Name = "btnImportProject"
        Me.btnImportProject.Size = New System.Drawing.Size(100, 30)
        Me.btnImportProject.TabIndex = 2
        Me.btnImportProject.Text = "Import..."
        Me.btnImportProject.UseVisualStyleBackColor = True
        '
        'txtProjectResource
        '
        Me.txtProjectResource.Location = New System.Drawing.Point(10, 30)
        Me.txtProjectResource.Multiline = True
        Me.txtProjectResource.Name = "txtProjectResource"
        Me.txtProjectResource.ReadOnly = True
        Me.txtProjectResource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProjectResource.Size = New System.Drawing.Size(220, 70)
        Me.txtProjectResource.TabIndex = 1
        Me.txtProjectResource.Text = "My.Project.Resources.resx"
        '
        'lblProjectResource
        '
        Me.lblProjectResource.AutoSize = True
        Me.lblProjectResource.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblProjectResource.Location = New System.Drawing.Point(10, 10)
        Me.lblProjectResource.Name = "lblProjectResource"
        Me.lblProjectResource.Size = New System.Drawing.Size(0, 15)
        Me.lblProjectResource.TabIndex = 0
        '
        'rbProjectResource
        '
        Me.rbProjectResource.AutoSize = True
        Me.rbProjectResource.Location = New System.Drawing.Point(15, 285)
        Me.rbProjectResource.Name = "rbProjectResource"
        Me.rbProjectResource.Size = New System.Drawing.Size(110, 19)
        Me.rbProjectResource.TabIndex = 2
        Me.rbProjectResource.Text = "Project resource"
        Me.rbProjectResource.UseVisualStyleBackColor = True
        '
        'panelLocalResource
        '
        Me.panelLocalResource.Controls.Add(Me.btnImportLocal)
        Me.panelLocalResource.Controls.Add(Me.btnClearLocal)
        Me.panelLocalResource.Controls.Add(Me.lstLocalResources)
        Me.panelLocalResource.Location = New System.Drawing.Point(15, 45)
        Me.panelLocalResource.Name = "panelLocalResource"
        Me.panelLocalResource.Size = New System.Drawing.Size(240, 230)
        Me.panelLocalResource.TabIndex = 1
        '
        'btnImportLocal
        '
        Me.btnImportLocal.Location = New System.Drawing.Point(10, 190)
        Me.btnImportLocal.Name = "btnImportLocal"
        Me.btnImportLocal.Size = New System.Drawing.Size(100, 30)
        Me.btnImportLocal.TabIndex = 2
        Me.btnImportLocal.Text = "Import..."
        Me.btnImportLocal.UseVisualStyleBackColor = True
        '
        'btnClearLocal
        '
        Me.btnClearLocal.Location = New System.Drawing.Point(120, 190)
        Me.btnClearLocal.Name = "btnClearLocal"
        Me.btnClearLocal.Size = New System.Drawing.Size(100, 30)
        Me.btnClearLocal.TabIndex = 1
        Me.btnClearLocal.Text = "Clear"
        Me.btnClearLocal.UseVisualStyleBackColor = True
        '
        'lstLocalResources
        '
        Me.lstLocalResources.FormattingEnabled = True
        Me.lstLocalResources.ItemHeight = 15
        Me.lstLocalResources.Location = New System.Drawing.Point(10, 10)
        Me.lstLocalResources.Name = "lstLocalResources"
        Me.lstLocalResources.Size = New System.Drawing.Size(220, 169)
        Me.lstLocalResources.TabIndex = 0
        '
        'rbLocalResource
        '
        Me.rbLocalResource.AutoSize = True
        Me.rbLocalResource.Checked = True
        Me.rbLocalResource.Location = New System.Drawing.Point(15, 25)
        Me.rbLocalResource.Name = "rbLocalResource"
        Me.rbLocalResource.Size = New System.Drawing.Size(101, 19)
        Me.rbLocalResource.TabIndex = 0
        Me.rbLocalResource.TabStop = True
        Me.rbLocalResource.Text = "Local resource"
        Me.rbLocalResource.UseVisualStyleBackColor = True
        '
        'tabRasterImages
        '
        Me.tabRasterImages.Controls.Add(Me.flowRasterIcons)
        Me.tabRasterImages.Controls.Add(Me.panelRasterFilters)
        Me.tabRasterImages.Controls.Add(Me.txtRasterSearch)
        Me.tabRasterImages.Controls.Add(Me.rbAddToForm)
        Me.tabRasterImages.Controls.Add(Me.rbAddToProject)
        Me.tabRasterImages.Location = New System.Drawing.Point(4, 24)
        Me.tabRasterImages.Name = "tabRasterImages"
        Me.tabRasterImages.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRasterImages.Size = New System.Drawing.Size(652, 492)
        Me.tabRasterImages.TabIndex = 1
        Me.tabRasterImages.Text = "Raster Images"
        Me.tabRasterImages.UseVisualStyleBackColor = True
        '
        'flowRasterIcons
        '
        Me.flowRasterIcons.AutoScroll = True
        Me.flowRasterIcons.BackColor = System.Drawing.Color.White
        Me.flowRasterIcons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flowRasterIcons.Location = New System.Drawing.Point(230, 40)
        Me.flowRasterIcons.Name = "flowRasterIcons"
        Me.flowRasterIcons.Size = New System.Drawing.Size(410, 420)
        Me.flowRasterIcons.TabIndex = 2
        '
        'panelRasterFilters
        '
        Me.panelRasterFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelRasterFilters.Controls.Add(Me.lblCategories)
        Me.panelRasterFilters.Controls.Add(Me.chkListCategories)
        Me.panelRasterFilters.Controls.Add(Me.lblSize)
        Me.panelRasterFilters.Controls.Add(Me.chkListSize)
        Me.panelRasterFilters.Location = New System.Drawing.Point(10, 40)
        Me.panelRasterFilters.Name = "panelRasterFilters"
        Me.panelRasterFilters.Size = New System.Drawing.Size(210, 420)
        Me.panelRasterFilters.TabIndex = 0
        '
        'lblCategories
        '
        Me.lblCategories.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategories.Location = New System.Drawing.Point(5, 5)
        Me.lblCategories.Name = "lblCategories"
        Me.lblCategories.Size = New System.Drawing.Size(190, 15)
        Me.lblCategories.TabIndex = 0
        Me.lblCategories.Text = "Categories"
        '
        'chkListCategories
        '
        Me.chkListCategories.CheckOnClick = True
        Me.chkListCategories.Items.AddRange(New Object() {"Select All", "Actions", "Alignment", "Analysis", "Appearance", "Arrange", "Arrows", "Business Objects", "Chart"})
        Me.chkListCategories.Location = New System.Drawing.Point(5, 25)
        Me.chkListCategories.Name = "chkListCategories"
        Me.chkListCategories.Size = New System.Drawing.Size(195, 292)
        Me.chkListCategories.TabIndex = 0
        '
        'lblSize
        '
        Me.lblSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSize.Location = New System.Drawing.Point(5, 328)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(190, 15)
        Me.lblSize.TabIndex = 1
        Me.lblSize.Text = "Size"
        '
        'chkListSize
        '
        Me.chkListSize.CheckOnClick = True
        Me.chkListSize.Items.AddRange(New Object() {"16x16", "32x32"})
        Me.chkListSize.Location = New System.Drawing.Point(5, 348)
        Me.chkListSize.Name = "chkListSize"
        Me.chkListSize.Size = New System.Drawing.Size(195, 40)
        Me.chkListSize.TabIndex = 1
        '
        'txtRasterSearch
        '
        Me.txtRasterSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtRasterSearch.Location = New System.Drawing.Point(430, 10)
        Me.txtRasterSearch.Name = "txtRasterSearch"
        Me.txtRasterSearch.Size = New System.Drawing.Size(200, 23)
        Me.txtRasterSearch.TabIndex = 1
        Me.txtRasterSearch.Text = "Enter text to search..."
        '
        'rbAddToForm
        '
        Me.rbAddToForm.Checked = True
        Me.rbAddToForm.Location = New System.Drawing.Point(230, 467)
        Me.rbAddToForm.Name = "rbAddToForm"
        Me.rbAddToForm.Size = New System.Drawing.Size(160, 20)
        Me.rbAddToForm.TabIndex = 4
        Me.rbAddToForm.TabStop = True
        Me.rbAddToForm.Text = "Add to form resources"
        '
        'rbAddToProject
        '
        Me.rbAddToProject.Location = New System.Drawing.Point(50, 467)
        Me.rbAddToProject.Name = "rbAddToProject"
        Me.rbAddToProject.Size = New System.Drawing.Size(160, 20)
        Me.rbAddToProject.TabIndex = 3
        Me.rbAddToProject.Text = "Add to project resources"
        '
        'tabVectorImages
        '
        Me.tabVectorImages.Location = New System.Drawing.Point(4, 24)
        Me.tabVectorImages.Name = "tabVectorImages"
        Me.tabVectorImages.Size = New System.Drawing.Size(652, 492)
        Me.tabVectorImages.TabIndex = 2
        Me.tabVectorImages.Text = "Vector Images"
        Me.tabVectorImages.UseVisualStyleBackColor = True
        '
        'tabFontIcons
        '
        Me.tabFontIcons.Location = New System.Drawing.Point(4, 24)
        Me.tabFontIcons.Name = "tabFontIcons"
        Me.tabFontIcons.Size = New System.Drawing.Size(652, 492)
        Me.tabFontIcons.TabIndex = 3
        Me.tabFontIcons.Text = "Font Icons"
        Me.tabFontIcons.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.Gray
        Me.lblVersion.Location = New System.Drawing.Point(12, 548)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(87, 15)
        Me.lblVersion.TabIndex = 3
        Me.lblVersion.Text = "Version 1.0.0.0"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(582, 543)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(487, 543)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 30)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'NXImagePickerDialog
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(684, 591)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tabControl)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NXImagePickerDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Image Picker"
        Me.tabControl.ResumeLayout(False)
        Me.tabImagePicker.ResumeLayout(False)
        Me.panelPreview.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLeft.ResumeLayout(False)
        Me.grpResourceContext.ResumeLayout(False)
        Me.grpResourceContext.PerformLayout()
        Me.panelProjectResource.ResumeLayout(False)
        Me.panelProjectResource.PerformLayout()
        Me.panelLocalResource.ResumeLayout(False)
        Me.tabRasterImages.ResumeLayout(False)
        Me.tabRasterImages.PerformLayout()
        Me.panelRasterFilters.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#Region "Campos de Controles"

    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabImagePicker As System.Windows.Forms.TabPage
    Friend WithEvents tabRasterImages As System.Windows.Forms.TabPage
    Friend WithEvents tabVectorImages As System.Windows.Forms.TabPage
    Friend WithEvents tabFontIcons As System.Windows.Forms.TabPage
    Friend WithEvents panelLeft As System.Windows.Forms.Panel
    Friend WithEvents grpResourceContext As System.Windows.Forms.GroupBox
    Friend WithEvents rbLocalResource As System.Windows.Forms.RadioButton
    Friend WithEvents panelLocalResource As System.Windows.Forms.Panel
    Friend WithEvents lstLocalResources As System.Windows.Forms.ListBox
    Friend WithEvents btnClearLocal As System.Windows.Forms.Button
    Friend WithEvents btnImportLocal As System.Windows.Forms.Button
    Friend WithEvents rbProjectResource As System.Windows.Forms.RadioButton
    Friend WithEvents panelProjectResource As System.Windows.Forms.Panel
    Friend WithEvents txtProjectResource As System.Windows.Forms.TextBox
    Friend WithEvents lblProjectResource As System.Windows.Forms.Label
    Friend WithEvents btnImportProject As System.Windows.Forms.Button
    Friend WithEvents panelPreview As System.Windows.Forms.Panel
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents panelRasterFilters As System.Windows.Forms.Panel
    Friend WithEvents txtRasterSearch As System.Windows.Forms.TextBox
    Friend WithEvents chkListCategories As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkListSize As System.Windows.Forms.CheckedListBox
    Friend WithEvents flowRasterIcons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbAddToProject As System.Windows.Forms.RadioButton
    Friend WithEvents rbAddToForm As System.Windows.Forms.RadioButton
    Friend WithEvents lblCategories As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label

#End Region

End Class
