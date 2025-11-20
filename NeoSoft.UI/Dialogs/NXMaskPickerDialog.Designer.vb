Partial Class NXMaskPickerDialog

    Private components As System.ComponentModel.IContainer = Nothing

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
        Me.lblMaskType = New System.Windows.Forms.Label()
        Me.lblMasks = New System.Windows.Forms.Label()
        Me.lstMaskType = New System.Windows.Forms.ListBox()
        Me.lstMasks = New System.Windows.Forms.ListBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtMaskPreview = New System.Windows.Forms.TextBox()
        Me.chkAdvancedSettings = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblLearnMore = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblMaskType
        '
        Me.lblMaskType.AutoSize = True
        Me.lblMaskType.Location = New System.Drawing.Point(22, 42)
        Me.lblMaskType.Name = "lblMaskType"
        Me.lblMaskType.Size = New System.Drawing.Size(62, 13)
        Me.lblMaskType.TabIndex = 0
        Me.lblMaskType.Text = "Mask Type:"
        '
        'lblMasks
        '
        Me.lblMasks.AutoSize = True
        Me.lblMasks.Location = New System.Drawing.Point(221, 42)
        Me.lblMasks.Name = "lblMasks"
        Me.lblMasks.Size = New System.Drawing.Size(42, 13)
        Me.lblMasks.TabIndex = 1
        Me.lblMasks.Text = "Masks:"
        '
        'lstMaskType
        '
        Me.lstMaskType.FormattingEnabled = True
        Me.lstMaskType.Location = New System.Drawing.Point(22, 62)
        Me.lstMaskType.Name = "lstMaskType"
        Me.lstMaskType.Size = New System.Drawing.Size(180, 290)
        Me.lstMaskType.TabIndex = 2
        '
        'lstMasks
        '
        Me.lstMasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstMasks.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMasks.FormattingEnabled = True
        Me.lstMasks.ItemHeight = 20
        Me.lstMasks.Location = New System.Drawing.Point(221, 62)
        Me.lstMasks.Name = "lstMasks"
        Me.lstMasks.Size = New System.Drawing.Size(510, 284)
        Me.lstMasks.TabIndex = 3
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDescription.Location = New System.Drawing.Point(22, 362)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Padding = New System.Windows.Forms.Padding(5)
        Me.lblDescription.Size = New System.Drawing.Size(709, 52)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Masks for entering date values (without time part)."
        '
        'txtMaskPreview
        '
        Me.txtMaskPreview.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaskPreview.Location = New System.Drawing.Point(221, 422)
        Me.txtMaskPreview.Name = "txtMaskPreview"
        Me.txtMaskPreview.ReadOnly = True
        Me.txtMaskPreview.Size = New System.Drawing.Size(510, 23)
        Me.txtMaskPreview.TabIndex = 5
        '
        'chkAdvancedSettings
        '
        Me.chkAdvancedSettings.AutoSize = True
        Me.chkAdvancedSettings.Location = New System.Drawing.Point(22, 472)
        Me.chkAdvancedSettings.Name = "chkAdvancedSettings"
        Me.chkAdvancedSettings.Size = New System.Drawing.Size(121, 17)
        Me.chkAdvancedSettings.TabIndex = 6
        Me.chkAdvancedSettings.Text = "Advanced Settings"
        Me.chkAdvancedSettings.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(575, 468)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 28)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(656, 468)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblLearnMore
        '
        Me.lblLearnMore.AutoSize = True
        Me.lblLearnMore.Location = New System.Drawing.Point(33, 389)
        Me.lblLearnMore.Name = "lblLearnMore"
        Me.lblLearnMore.Size = New System.Drawing.Size(100, 13)
        Me.lblLearnMore.TabIndex = 9
        Me.lblLearnMore.TabStop = True
        Me.lblLearnMore.Text = "Learn more online"
        '
        'NXMaskPickerDialog
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(754, 511)
        Me.Controls.Add(Me.lblLearnMore)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkAdvancedSettings)
        Me.Controls.Add(Me.txtMaskPreview)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lstMasks)
        Me.Controls.Add(Me.lstMaskType)
        Me.Controls.Add(Me.lblMasks)
        Me.Controls.Add(Me.lblMaskType)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NXMaskPickerDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mask Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMaskType As Label
    Friend WithEvents lblMasks As Label
    Friend WithEvents lstMaskType As ListBox
    Friend WithEvents lstMasks As ListBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtMaskPreview As TextBox
    Friend WithEvents chkAdvancedSettings As CheckBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblLearnMore As LinkLabel
End Class