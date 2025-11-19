<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NXImagePickerDialog
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
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabImagePicker = New System.Windows.Forms.TabPage()
        Me.panelPreview = New System.Windows.Forms.Panel()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.grpResourceContext = New System.Windows.Forms.GroupBox()
        Me.panelProjectResource = New System.Windows.Forms.Panel()
        Me.btnImportProject = New System.Windows.Forms.Button()
        Me.lstProjectResources = New System.Windows.Forms.ListBox()
        Me.lblResourceFile = New System.Windows.Forms.Label()
        Me.cboResourceFiles = New System.Windows.Forms.ComboBox()
        Me.rbProjectResource = New System.Windows.Forms.RadioButton()
        Me.panelLocalResource = New System.Windows.Forms.Panel()
        Me.btnClearLocal = New System.Windows.Forms.Button()
        Me.btnImportLocal = New System.Windows.Forms.Button()
        Me.rbLocalResource = New System.Windows.Forms.RadioButton()
        Me.tabRasterImages = New System.Windows.Forms.TabPage()
        Me.flowRasterIcons = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelRasterFilters = New System.Windows.Forms.Panel()
        Me.lblCategories = New System.Windows.Forms.Label()
        Me.chkListCategories = New System.Windows.Forms.CheckedListBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.chkListSize = New System.Windows.Forms.CheckedListBox()
        Me.txtRasterSearch = New System.Windows.Forms.TextBox()
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
        Me.panelPreview.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPreview.Controls.Add(Me.picPreview)
        Me.panelPreview.Location = New System.Drawing.Point(290, 10)
        Me.panelPreview.Name = "panelPreview"
        Me.panelPreview.Size = New System.Drawing.Size(350, 470)
        Me.panelPreview.TabIndex = 1
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.White
        Me.picPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview.Location = New System.Drawing.Point(0, 0)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(348, 468)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
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
        Me.panelProjectResource.Controls.Add(Me.lstProjectResources)
        Me.panelProjectResource.Controls.Add(Me.lblResourceFile)
        Me.panelProjectResource.Controls.Add(Me.cboResourceFiles)
        Me.panelProjectResource.Location = New System.Drawing.Point(15, 150)
        Me.panelProjectResource.Name = "panelProjectResource"
        Me.panelProjectResource.Size = New System.Drawing.Size(240, 310)
        Me.panelProjectResource.TabIndex = 3
        '
        'btnImportProject
        '
        Me.btnImportProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImportProject.Location = New System.Drawing.Point(10, 270)
        Me.btnImportProject.Name = "btnImportProject"
        Me.btnImportProject.Size = New System.Drawing.Size(100, 30)
        Me.btnImportProject.TabIndex = 3
        Me.btnImportProject.Text = "Import..."
        Me.btnImportProject.UseVisualStyleBackColor = True
        '
        'lstProjectResources
        '
        Me.lstProjectResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProjectResources.FormattingEnabled = True
        Me.lstProjectResources.ItemHeight = 15
        Me.lstProjectResources.Location = New System.Drawing.Point(10, 65)
        Me.lstProjectResources.Name = "lstProjectResources"
        Me.lstProjectResources.Size = New System.Drawing.Size(220, 199)
        Me.lstProjectResources.TabIndex = 2
        '
        'lblResourceFile
        '
        Me.lblResourceFile.AutoSize = True
        Me.lblResourceFile.Location = New System.Drawing.Point(10, 10)
        Me.lblResourceFile.Name = "lblResourceFile"
        Me.lblResourceFile.Size = New System.Drawing.Size(77, 15)
        Me.lblResourceFile.TabIndex = 0
        Me.lblResourceFile.Text = "Resource file:"
        '
        'cboResourceFiles
        '
        Me.cboResourceFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboResourceFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResourceFiles.FormattingEnabled = True
        Me.cboResourceFiles.Location = New System.Drawing.Point(10, 30)
        Me.cboResourceFiles.Name = "cboResourceFiles"
        Me.cboResourceFiles.Size = New System.Drawing.Size(220, 23)
        Me.cboResourceFiles.TabIndex = 1
        '
        'rbProjectResource
        '
        Me.rbProjectResource.AutoSize = True
        Me.rbProjectResource.Location = New System.Drawing.Point(15, 125)
        Me.rbProjectResource.Name = "rbProjectResource"
        Me.rbProjectResource.Size = New System.Drawing.Size(110, 19)
        Me.rbProjectResource.TabIndex = 2
        Me.rbProjectResource.Text = "Project resource"
        Me.rbProjectResource.UseVisualStyleBackColor = True
        '
        'panelLocalResource
        '
        Me.panelLocalResource.Controls.Add(Me.btnClearLocal)
        Me.panelLocalResource.Controls.Add(Me.btnImportLocal)
        Me.panelLocalResource.Location = New System.Drawing.Point(15, 45)
        Me.panelLocalResource.Name = "panelLocalResource"
        Me.panelLocalResource.Size = New System.Drawing.Size(240, 70)
        Me.panelLocalResource.TabIndex = 1
        '
        'btnClearLocal
        '
        Me.btnClearLocal.Location = New System.Drawing.Point(120, 10)
        Me.btnClearLocal.Name = "btnClearLocal"
        Me.btnClearLocal.Size = New System.Drawing.Size(100, 30)
        Me.btnClearLocal.TabIndex = 1
        Me.btnClearLocal.Text = "Clear"
        Me.btnClearLocal.UseVisualStyleBackColor = True
        '
        'btnImportLocal
        '
        Me.btnImportLocal.Location = New System.Drawing.Point(10, 10)
        Me.btnImportLocal.Name = "btnImportLocal"
        Me.btnImportLocal.Size = New System.Drawing.Size(100, 30)
        Me.btnImportLocal.TabIndex = 0
        Me.btnImportLocal.Text = "Import..."
        Me.btnImportLocal.UseVisualStyleBackColor = True
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
        Me.flowRasterIcons.Size = New System.Drawing.Size(410, 440)
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
        Me.panelRasterFilters.Size = New System.Drawing.Size(210, 440)
        Me.panelRasterFilters.TabIndex = 1
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
        Me.chkListCategories.FormattingEnabled = True
        Me.chkListCategories.Location = New System.Drawing.Point(5, 25)
        Me.chkListCategories.Name = "chkListCategories"
        Me.chkListCategories.Size = New System.Drawing.Size(195, 310)
        Me.chkListCategories.TabIndex = 1
        '
        'lblSize
        '
        Me.lblSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSize.Location = New System.Drawing.Point(5, 350)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(190, 15)
        Me.lblSize.TabIndex = 2
        Me.lblSize.Text = "Size"
        '
        'chkListSize
        '
        Me.chkListSize.CheckOnClick = True
        Me.chkListSize.FormattingEnabled = True
        Me.chkListSize.Location = New System.Drawing.Point(5, 370)
        Me.chkListSize.Name = "chkListSize"
        Me.chkListSize.Size = New System.Drawing.Size(195, 58)
        Me.chkListSize.TabIndex = 3
        '
        'txtRasterSearch
        '
        Me.txtRasterSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtRasterSearch.Location = New System.Drawing.Point(430, 10)
        Me.txtRasterSearch.Name = "txtRasterSearch"
        Me.txtRasterSearch.Size = New System.Drawing.Size(200, 23)
        Me.txtRasterSearch.TabIndex = 0
        Me.txtRasterSearch.Text = "Enter text to search..."
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
        Me.lblVersion.Size = New System.Drawing.Size(97, 15)
        Me.lblVersion.TabIndex = 3
        Me.lblVersion.Text = "NeoSoft.UI v1.0.0"
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 630)
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

    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabImagePicker As TabPage
    Friend WithEvents tabRasterImages As TabPage
    Friend WithEvents tabVectorImages As TabPage
    Friend WithEvents tabFontIcons As TabPage
    Friend WithEvents panelLeft As Panel
    Friend WithEvents grpResourceContext As GroupBox
    Friend WithEvents rbLocalResource As RadioButton
    Friend WithEvents panelLocalResource As Panel
    Friend WithEvents btnClearLocal As Button
    Friend WithEvents btnImportLocal As Button
    Friend WithEvents rbProjectResource As RadioButton
    Friend WithEvents panelProjectResource As Panel
    Friend WithEvents lstProjectResources As ListBox
    Friend WithEvents btnImportProject As Button
    Friend WithEvents cboResourceFiles As ComboBox
    Friend WithEvents lblResourceFile As Label
    Friend WithEvents panelPreview As Panel
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblVersion As Label
    Friend WithEvents panelRasterFilters As Panel
    Friend WithEvents txtRasterSearch As TextBox
    Friend WithEvents chkListCategories As CheckedListBox
    Friend WithEvents chkListSize As CheckedListBox
    Friend WithEvents flowRasterIcons As FlowLayoutPanel
    Friend WithEvents lblCategories As Label
    Friend WithEvents lblSize As Label

End Class