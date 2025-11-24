Imports NeoSoft.UI.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProgressBarDemo
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
        Me.pnlDemo1 = New NeoSoft.UI.Controls.NXPanel()
        Me.lblValue1 = New NeoSoft.UI.Controls.NXLabel()
        Me.btnStopOperation1 = New NeoSoft.UI.Controls.NXButton()
        Me.btnStartOperation1 = New NeoSoft.UI.Controls.NXButton()
        Me.pgbContinuous = New NeoSoft.UI.Controls.NXProgressBar()
        Me.lblDemo1 = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlDemo2 = New NeoSoft.UI.Controls.NXPanel()
        Me.lblValue2 = New NeoSoft.UI.Controls.NXLabel()
        Me.btnStopOperation2 = New NeoSoft.UI.Controls.NXButton()
        Me.btnStartOperation2 = New NeoSoft.UI.Controls.NXButton()
        Me.pgbBlocks = New NeoSoft.UI.Controls.NXProgressBar()
        Me.lblDemo2 = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlDemo3 = New NeoSoft.UI.Controls.NXPanel()
        Me.btnStopOperation3 = New NeoSoft.UI.Controls.NXButton()
        Me.btnStartOperation3 = New NeoSoft.UI.Controls.NXButton()
        Me.pgbMarquee = New NeoSoft.UI.Controls.NXProgressBar()
        Me.lblDemo3 = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlDemo4 = New NeoSoft.UI.Controls.NXPanel()
        Me.lblValue4 = New NeoSoft.UI.Controls.NXLabel()
        Me.btnReset = New NeoSoft.UI.Controls.NXButton()
        Me.btnDecrement = New NeoSoft.UI.Controls.NXButton()
        Me.btnIncrement = New NeoSoft.UI.Controls.NXButton()
        Me.pgbGradient = New NeoSoft.UI.Controls.NXProgressBar()
        Me.lblDemo4 = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlDemo5 = New NeoSoft.UI.Controls.NXPanel()
        Me.pgbVertical = New NeoSoft.UI.Controls.NXProgressBar()
        Me.lblDemo5 = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlOptions = New NeoSoft.UI.Controls.NXPanel()
        Me.chkUseGradient = New System.Windows.Forms.CheckBox()
        Me.chkShowSeparators = New System.Windows.Forms.CheckBox()
        Me.chkShowPercentage = New System.Windows.Forms.CheckBox()
        Me.lblOptions = New NeoSoft.UI.Controls.NXLabel()
        Me.pnlDemo1.SuspendLayout()
        Me.pnlDemo2.SuspendLayout()
        Me.pnlDemo3.SuspendLayout()
        Me.pnlDemo4.SuspendLayout()
        Me.pnlDemo5.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
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
        Me.lblTitle.Text = "📊 NXProgressBar - Demostración"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDemo1
        '
        Me.pnlDemo1.BackColor = System.Drawing.Color.White
        Me.pnlDemo1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlDemo1.BorderRadius = 4
        Me.pnlDemo1.BorderSize = 1
        Me.pnlDemo1.Controls.Add(Me.lblValue1)
        Me.pnlDemo1.Controls.Add(Me.btnStopOperation1)
        Me.pnlDemo1.Controls.Add(Me.btnStartOperation1)
        Me.pnlDemo1.Controls.Add(Me.pgbContinuous)
        Me.pnlDemo1.Controls.Add(Me.lblDemo1)
        Me.pnlDemo1.Location = New System.Drawing.Point(20, 70)
        Me.pnlDemo1.Name = "pnlDemo1"
        Me.pnlDemo1.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlDemo1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlDemo1.ShowShadow = True
        Me.pnlDemo1.Size = New System.Drawing.Size(480, 140)
        Me.pnlDemo1.TabIndex = 1
        Me.pnlDemo1.UseTheme = True
        '
        'lblValue1
        '
        Me.lblValue1.BackColor = System.Drawing.Color.Transparent
        Me.lblValue1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblValue1.BorderRadius = 4
        Me.lblValue1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblValue1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblValue1.GradientColor = System.Drawing.Color.Empty
        Me.lblValue1.Location = New System.Drawing.Point(260, 105)
        Me.lblValue1.Name = "lblValue1"
        Me.lblValue1.OutlineColor = System.Drawing.Color.Black
        Me.lblValue1.Padding = New System.Windows.Forms.Padding(5)
        Me.lblValue1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblValue1.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblValue1.Size = New System.Drawing.Size(210, 28)
        Me.lblValue1.TabIndex = 4
        Me.lblValue1.Text = "Valor: 0 / 100"
        Me.lblValue1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblValue1.UseTheme = True
        '
        'btnStopOperation1
        '
        Me.btnStopOperation1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnStopOperation1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnStopOperation1.BorderRadius = 4
        Me.btnStopOperation1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStopOperation1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnStopOperation1.ForeColor = System.Drawing.Color.White
        Me.btnStopOperation1.HoverBackColor = System.Drawing.Color.Empty
        Me.btnStopOperation1.Image = Nothing
        Me.btnStopOperation1.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnStopOperation1.Location = New System.Drawing.Point(135, 105)
        Me.btnStopOperation1.Name = "btnStopOperation1"
        Me.btnStopOperation1.PressedBackColor = System.Drawing.Color.Empty
        Me.btnStopOperation1.Size = New System.Drawing.Size(120, 28)
        Me.btnStopOperation1.TabIndex = 3
        Me.btnStopOperation1.Text = "⏹ Detener"
        '
        'btnStartOperation1
        '
        Me.btnStartOperation1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnStartOperation1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnStartOperation1.BorderRadius = 4
        Me.btnStartOperation1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStartOperation1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnStartOperation1.ForeColor = System.Drawing.Color.White
        Me.btnStartOperation1.HoverBackColor = System.Drawing.Color.Empty
        Me.btnStartOperation1.Image = Nothing
        Me.btnStartOperation1.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnStartOperation1.Location = New System.Drawing.Point(10, 105)
        Me.btnStartOperation1.Name = "btnStartOperation1"
        Me.btnStartOperation1.PressedBackColor = System.Drawing.Color.Empty
        Me.btnStartOperation1.Size = New System.Drawing.Size(120, 28)
        Me.btnStartOperation1.TabIndex = 2
        Me.btnStartOperation1.Text = "▶ Iniciar"
        Me.btnStartOperation1.UseTheme = True
        '
        'pgbContinuous
        '
        Me.pgbContinuous.BackColor = System.Drawing.Color.Transparent
        Me.pgbContinuous.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.pgbContinuous.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pgbContinuous.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pgbContinuous.Location = New System.Drawing.Point(10, 45)
        Me.pgbContinuous.Name = "pgbContinuous"
        Me.pgbContinuous.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.pgbContinuous.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.pgbContinuous.SeparatorColor = System.Drawing.Color.White
        Me.pgbContinuous.Size = New System.Drawing.Size(460, 30)
        Me.pgbContinuous.TabIndex = 1
        Me.pgbContinuous.TextColor = System.Drawing.Color.White
        Me.pgbContinuous.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.pgbContinuous.UseTheme = True
        '
        'lblDemo1
        '
        Me.lblDemo1.BackColor = System.Drawing.Color.Transparent
        Me.lblDemo1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblDemo1.BorderRadius = 4
        Me.lblDemo1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDemo1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblDemo1.GradientColor = System.Drawing.Color.Empty
        Me.lblDemo1.Location = New System.Drawing.Point(10, 10)
        Me.lblDemo1.Name = "lblDemo1"
        Me.lblDemo1.OutlineColor = System.Drawing.Color.Black
        Me.lblDemo1.Padding = New System.Windows.Forms.Padding(5)
        Me.lblDemo1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDemo1.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblDemo1.Size = New System.Drawing.Size(460, 25)
        Me.lblDemo1.TabIndex = 0
        Me.lblDemo1.Text = "1. Barra Continua con Operación"
        Me.lblDemo1.UseTheme = True
        '
        'pnlDemo2
        '
        Me.pnlDemo2.BackColor = System.Drawing.Color.White
        Me.pnlDemo2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlDemo2.BorderSize = 1
        Me.pnlDemo2.Controls.Add(Me.lblValue2)
        Me.pnlDemo2.Controls.Add(Me.btnStopOperation2)
        Me.pnlDemo2.Controls.Add(Me.btnStartOperation2)
        Me.pnlDemo2.Controls.Add(Me.pgbBlocks)
        Me.pnlDemo2.Controls.Add(Me.lblDemo2)
        Me.pnlDemo2.Location = New System.Drawing.Point(510, 70)
        Me.pnlDemo2.Name = "pnlDemo2"
        Me.pnlDemo2.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlDemo2.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlDemo2.ShowShadow = True
        Me.pnlDemo2.Size = New System.Drawing.Size(480, 140)
        Me.pnlDemo2.TabIndex = 2
        '
        'lblValue2
        '
        Me.lblValue2.BackColor = System.Drawing.Color.Transparent
        Me.lblValue2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblValue2.BorderRadius = 4
        Me.lblValue2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblValue2.ForeColor = System.Drawing.Color.Black
        Me.lblValue2.GradientColor = System.Drawing.Color.Empty
        Me.lblValue2.Location = New System.Drawing.Point(260, 105)
        Me.lblValue2.Name = "lblValue2"
        Me.lblValue2.OutlineColor = System.Drawing.Color.Black
        Me.lblValue2.Padding = New System.Windows.Forms.Padding(5)
        Me.lblValue2.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblValue2.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblValue2.Size = New System.Drawing.Size(210, 28)
        Me.lblValue2.TabIndex = 4
        Me.lblValue2.Text = "Progreso: 0%"
        Me.lblValue2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnStopOperation2
        '
        Me.btnStopOperation2.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnStopOperation2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnStopOperation2.BorderRadius = 4
        Me.btnStopOperation2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStopOperation2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnStopOperation2.ForeColor = System.Drawing.Color.White
        Me.btnStopOperation2.HoverBackColor = System.Drawing.Color.Empty
        Me.btnStopOperation2.Image = Nothing
        Me.btnStopOperation2.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnStopOperation2.Location = New System.Drawing.Point(135, 105)
        Me.btnStopOperation2.Name = "btnStopOperation2"
        Me.btnStopOperation2.PressedBackColor = System.Drawing.Color.Empty
        Me.btnStopOperation2.Size = New System.Drawing.Size(120, 28)
        Me.btnStopOperation2.TabIndex = 3
        Me.btnStopOperation2.Text = "❌ Cancelar"
        '
        'btnStartOperation2
        '
        Me.btnStartOperation2.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnStartOperation2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnStartOperation2.BorderRadius = 4
        Me.btnStartOperation2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStartOperation2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnStartOperation2.ForeColor = System.Drawing.Color.White
        Me.btnStartOperation2.HoverBackColor = System.Drawing.Color.Empty
        Me.btnStartOperation2.Image = Nothing
        Me.btnStartOperation2.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnStartOperation2.Location = New System.Drawing.Point(10, 105)
        Me.btnStartOperation2.Name = "btnStartOperation2"
        Me.btnStartOperation2.PressedBackColor = System.Drawing.Color.Empty
        Me.btnStartOperation2.Size = New System.Drawing.Size(120, 28)
        Me.btnStartOperation2.TabIndex = 2
        Me.btnStartOperation2.Text = "📥 Descargar"
        '
        'pgbBlocks
        '
        Me.pgbBlocks.BackColor = System.Drawing.Color.Transparent
        Me.pgbBlocks.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pgbBlocks.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pgbBlocks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pgbBlocks.Location = New System.Drawing.Point(10, 45)
        Me.pgbBlocks.Name = "pgbBlocks"
        Me.pgbBlocks.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.pgbBlocks.ProgressColor2 = System.Drawing.Color.Empty
        Me.pgbBlocks.SeparatorColor = System.Drawing.Color.White
        Me.pgbBlocks.ShowSeparators = True
        Me.pgbBlocks.Size = New System.Drawing.Size(460, 30)
        Me.pgbBlocks.Style = NeoSoft.UI.Controls.NXProgressBar.ProgressBarStyle.Blocks
        Me.pgbBlocks.TabIndex = 1
        Me.pgbBlocks.TextColor = System.Drawing.Color.White
        Me.pgbBlocks.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        '
        'lblDemo2
        '
        Me.lblDemo2.BackColor = System.Drawing.Color.Transparent
        Me.lblDemo2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblDemo2.BorderRadius = 4
        Me.lblDemo2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDemo2.ForeColor = System.Drawing.Color.Black
        Me.lblDemo2.GradientColor = System.Drawing.Color.Empty
        Me.lblDemo2.Location = New System.Drawing.Point(10, 10)
        Me.lblDemo2.Name = "lblDemo2"
        Me.lblDemo2.OutlineColor = System.Drawing.Color.Black
        Me.lblDemo2.Padding = New System.Windows.Forms.Padding(5)
        Me.lblDemo2.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDemo2.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblDemo2.Size = New System.Drawing.Size(460, 25)
        Me.lblDemo2.TabIndex = 0
        Me.lblDemo2.Text = "2. Barra por Bloques con Separadores"
        '
        'pnlDemo3
        '
        Me.pnlDemo3.BackColor = System.Drawing.Color.White
        Me.pnlDemo3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlDemo3.BorderSize = 1
        Me.pnlDemo3.Controls.Add(Me.btnStopOperation3)
        Me.pnlDemo3.Controls.Add(Me.btnStartOperation3)
        Me.pnlDemo3.Controls.Add(Me.pgbMarquee)
        Me.pnlDemo3.Controls.Add(Me.lblDemo3)
        Me.pnlDemo3.Location = New System.Drawing.Point(20, 220)
        Me.pnlDemo3.Name = "pnlDemo3"
        Me.pnlDemo3.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlDemo3.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlDemo3.ShowShadow = True
        Me.pnlDemo3.Size = New System.Drawing.Size(480, 120)
        Me.pnlDemo3.TabIndex = 3
        '
        'btnStopOperation3
        '
        Me.btnStopOperation3.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnStopOperation3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnStopOperation3.BorderRadius = 4
        Me.btnStopOperation3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStopOperation3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnStopOperation3.ForeColor = System.Drawing.Color.White
        Me.btnStopOperation3.HoverBackColor = System.Drawing.Color.Empty
        Me.btnStopOperation3.Image = Nothing
        Me.btnStopOperation3.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnStopOperation3.Location = New System.Drawing.Point(135, 85)
        Me.btnStopOperation3.Name = "btnStopOperation3"
        Me.btnStopOperation3.PressedBackColor = System.Drawing.Color.Empty
        Me.btnStopOperation3.Size = New System.Drawing.Size(120, 28)
        Me.btnStopOperation3.TabIndex = 3
        Me.btnStopOperation3.Text = "⏸ Pausar"
        '
        'btnStartOperation3
        '
        Me.btnStartOperation3.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnStartOperation3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnStartOperation3.BorderRadius = 4
        Me.btnStartOperation3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStartOperation3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnStartOperation3.ForeColor = System.Drawing.Color.White
        Me.btnStartOperation3.HoverBackColor = System.Drawing.Color.Empty
        Me.btnStartOperation3.Image = Nothing
        Me.btnStartOperation3.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnStartOperation3.Location = New System.Drawing.Point(10, 85)
        Me.btnStartOperation3.Name = "btnStartOperation3"
        Me.btnStartOperation3.PressedBackColor = System.Drawing.Color.Empty
        Me.btnStartOperation3.Size = New System.Drawing.Size(120, 28)
        Me.btnStartOperation3.TabIndex = 2
        Me.btnStartOperation3.Text = "🔄 Sincronizar"
        '
        'pgbMarquee
        '
        Me.pgbMarquee.BackColor = System.Drawing.Color.Transparent
        Me.pgbMarquee.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pgbMarquee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pgbMarquee.Cursor = System.Windows.Forms.Cursors.Default
        Me.pgbMarquee.Location = New System.Drawing.Point(10, 45)
        Me.pgbMarquee.Name = "pgbMarquee"
        Me.pgbMarquee.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pgbMarquee.ProgressColor2 = System.Drawing.Color.Empty
        Me.pgbMarquee.SeparatorColor = System.Drawing.Color.White
        Me.pgbMarquee.Size = New System.Drawing.Size(460, 30)
        Me.pgbMarquee.Style = NeoSoft.UI.Controls.NXProgressBar.ProgressBarStyle.Marquee
        Me.pgbMarquee.TabIndex = 1
        Me.pgbMarquee.TextColor = System.Drawing.Color.White
        Me.pgbMarquee.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        '
        'lblDemo3
        '
        Me.lblDemo3.BackColor = System.Drawing.Color.Transparent
        Me.lblDemo3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblDemo3.BorderRadius = 4
        Me.lblDemo3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDemo3.ForeColor = System.Drawing.Color.Black
        Me.lblDemo3.GradientColor = System.Drawing.Color.Empty
        Me.lblDemo3.Location = New System.Drawing.Point(10, 10)
        Me.lblDemo3.Name = "lblDemo3"
        Me.lblDemo3.OutlineColor = System.Drawing.Color.Black
        Me.lblDemo3.Padding = New System.Windows.Forms.Padding(5)
        Me.lblDemo3.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDemo3.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblDemo3.Size = New System.Drawing.Size(460, 25)
        Me.lblDemo3.TabIndex = 0
        Me.lblDemo3.Text = "3. Marquee (Progreso Indeterminado)"
        '
        'pnlDemo4
        '
        Me.pnlDemo4.BackColor = System.Drawing.Color.White
        Me.pnlDemo4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlDemo4.BorderRadius = 4
        Me.pnlDemo4.BorderSize = 1
        Me.pnlDemo4.Controls.Add(Me.lblValue4)
        Me.pnlDemo4.Controls.Add(Me.btnReset)
        Me.pnlDemo4.Controls.Add(Me.btnDecrement)
        Me.pnlDemo4.Controls.Add(Me.btnIncrement)
        Me.pnlDemo4.Controls.Add(Me.pgbGradient)
        Me.pnlDemo4.Controls.Add(Me.lblDemo4)
        Me.pnlDemo4.Location = New System.Drawing.Point(510, 220)
        Me.pnlDemo4.Name = "pnlDemo4"
        Me.pnlDemo4.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlDemo4.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlDemo4.ShowShadow = True
        Me.pnlDemo4.Size = New System.Drawing.Size(370, 120)
        Me.pnlDemo4.TabIndex = 4
        Me.pnlDemo4.UseTheme = True
        '
        'lblValue4
        '
        Me.lblValue4.BackColor = System.Drawing.Color.Transparent
        Me.lblValue4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblValue4.BorderRadius = 4
        Me.lblValue4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblValue4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblValue4.GradientColor = System.Drawing.Color.Empty
        Me.lblValue4.Location = New System.Drawing.Point(265, 85)
        Me.lblValue4.Name = "lblValue4"
        Me.lblValue4.OutlineColor = System.Drawing.Color.Black
        Me.lblValue4.Padding = New System.Windows.Forms.Padding(5)
        Me.lblValue4.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblValue4.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblValue4.Size = New System.Drawing.Size(95, 28)
        Me.lblValue4.TabIndex = 5
        Me.lblValue4.Text = "Valor: 0"
        Me.lblValue4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblValue4.UseTheme = True
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnReset.BorderRadius = 4
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.HoverBackColor = System.Drawing.Color.Empty
        Me.btnReset.Image = Nothing
        Me.btnReset.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnReset.Location = New System.Drawing.Point(180, 85)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.PressedBackColor = System.Drawing.Color.Empty
        Me.btnReset.Size = New System.Drawing.Size(80, 28)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "🔄 Reset"
        Me.btnReset.UseTheme = True
        '
        'btnDecrement
        '
        Me.btnDecrement.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnDecrement.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnDecrement.BorderRadius = 4
        Me.btnDecrement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDecrement.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnDecrement.ForeColor = System.Drawing.Color.White
        Me.btnDecrement.HoverBackColor = System.Drawing.Color.Empty
        Me.btnDecrement.Image = Nothing
        Me.btnDecrement.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnDecrement.Location = New System.Drawing.Point(95, 85)
        Me.btnDecrement.Name = "btnDecrement"
        Me.btnDecrement.PressedBackColor = System.Drawing.Color.Empty
        Me.btnDecrement.Size = New System.Drawing.Size(80, 28)
        Me.btnDecrement.TabIndex = 3
        Me.btnDecrement.Text = "➖ -10"
        Me.btnDecrement.UseTheme = True
        '
        'btnIncrement
        '
        Me.btnIncrement.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnIncrement.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnIncrement.BorderRadius = 4
        Me.btnIncrement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncrement.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnIncrement.ForeColor = System.Drawing.Color.White
        Me.btnIncrement.HoverBackColor = System.Drawing.Color.Empty
        Me.btnIncrement.Image = Nothing
        Me.btnIncrement.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnIncrement.Location = New System.Drawing.Point(10, 85)
        Me.btnIncrement.Name = "btnIncrement"
        Me.btnIncrement.PressedBackColor = System.Drawing.Color.Empty
        Me.btnIncrement.Size = New System.Drawing.Size(80, 28)
        Me.btnIncrement.TabIndex = 2
        Me.btnIncrement.Text = "➕ +10"
        Me.btnIncrement.UseTheme = True
        '
        'pgbGradient
        '
        Me.pgbGradient.BackColor = System.Drawing.Color.Transparent
        Me.pgbGradient.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.pgbGradient.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pgbGradient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pgbGradient.Location = New System.Drawing.Point(10, 45)
        Me.pgbGradient.Name = "pgbGradient"
        Me.pgbGradient.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.pgbGradient.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.pgbGradient.SeparatorColor = System.Drawing.Color.White
        Me.pgbGradient.Size = New System.Drawing.Size(350, 30)
        Me.pgbGradient.TabIndex = 1
        Me.pgbGradient.TextColor = System.Drawing.Color.White
        Me.pgbGradient.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.pgbGradient.UseTheme = True
        '
        'lblDemo4
        '
        Me.lblDemo4.BackColor = System.Drawing.Color.Transparent
        Me.lblDemo4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblDemo4.BorderRadius = 4
        Me.lblDemo4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDemo4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblDemo4.GradientColor = System.Drawing.Color.Empty
        Me.lblDemo4.Location = New System.Drawing.Point(10, 10)
        Me.lblDemo4.Name = "lblDemo4"
        Me.lblDemo4.OutlineColor = System.Drawing.Color.Black
        Me.lblDemo4.Padding = New System.Windows.Forms.Padding(5)
        Me.lblDemo4.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDemo4.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblDemo4.Size = New System.Drawing.Size(350, 25)
        Me.lblDemo4.TabIndex = 0
        Me.lblDemo4.Text = "4. Con Gradiente - Control Manual"
        Me.lblDemo4.UseTheme = True
        '
        'pnlDemo5
        '
        Me.pnlDemo5.BackColor = System.Drawing.Color.White
        Me.pnlDemo5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlDemo5.BorderRadius = 4
        Me.pnlDemo5.BorderSize = 1
        Me.pnlDemo5.Controls.Add(Me.pgbVertical)
        Me.pnlDemo5.Controls.Add(Me.lblDemo5)
        Me.pnlDemo5.Location = New System.Drawing.Point(890, 220)
        Me.pnlDemo5.Name = "pnlDemo5"
        Me.pnlDemo5.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlDemo5.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlDemo5.ShowShadow = True
        Me.pnlDemo5.Size = New System.Drawing.Size(100, 230)
        Me.pnlDemo5.TabIndex = 5
        Me.pnlDemo5.UseTheme = True
        '
        'pgbVertical
        '
        Me.pgbVertical.BackColor = System.Drawing.Color.Transparent
        Me.pgbVertical.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pgbVertical.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pgbVertical.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pgbVertical.Location = New System.Drawing.Point(30, 60)
        Me.pgbVertical.Name = "pgbVertical"
        Me.pgbVertical.Orientation = NeoSoft.UI.Controls.NXProgressBar.ProgressBarOrientation.Vertical
        Me.pgbVertical.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pgbVertical.ProgressColor2 = System.Drawing.Color.Empty
        Me.pgbVertical.SeparatorColor = System.Drawing.Color.White
        Me.pgbVertical.Size = New System.Drawing.Size(40, 160)
        Me.pgbVertical.TabIndex = 1
        Me.pgbVertical.TextColor = System.Drawing.Color.White
        Me.pgbVertical.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.pgbVertical.Value = 60
        '
        'lblDemo5
        '
        Me.lblDemo5.BackColor = System.Drawing.Color.Transparent
        Me.lblDemo5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblDemo5.BorderRadius = 4
        Me.lblDemo5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDemo5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblDemo5.GradientColor = System.Drawing.Color.Empty
        Me.lblDemo5.Location = New System.Drawing.Point(10, 10)
        Me.lblDemo5.Name = "lblDemo5"
        Me.lblDemo5.OutlineColor = System.Drawing.Color.Black
        Me.lblDemo5.Padding = New System.Windows.Forms.Padding(5)
        Me.lblDemo5.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDemo5.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblDemo5.Size = New System.Drawing.Size(80, 40)
        Me.lblDemo5.TabIndex = 0
        Me.lblDemo5.Text = "5. Vertical"
        Me.lblDemo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDemo5.UseTheme = True
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.White
        Me.pnlOptions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.pnlOptions.BorderSize = 1
        Me.pnlOptions.Controls.Add(Me.chkUseGradient)
        Me.pnlOptions.Controls.Add(Me.chkShowSeparators)
        Me.pnlOptions.Controls.Add(Me.chkShowPercentage)
        Me.pnlOptions.Controls.Add(Me.lblOptions)
        Me.pnlOptions.Location = New System.Drawing.Point(20, 350)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlOptions.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlOptions.ShowShadow = True
        Me.pnlOptions.Size = New System.Drawing.Size(860, 100)
        Me.pnlOptions.TabIndex = 6
        '
        'chkUseGradient
        '
        Me.chkUseGradient.AutoSize = True
        Me.chkUseGradient.Checked = True
        Me.chkUseGradient.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseGradient.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkUseGradient.Location = New System.Drawing.Point(340, 50)
        Me.chkUseGradient.Name = "chkUseGradient"
        Me.chkUseGradient.Size = New System.Drawing.Size(103, 19)
        Me.chkUseGradient.TabIndex = 3
        Me.chkUseGradient.Text = "Usar Gradiente"
        Me.chkUseGradient.UseVisualStyleBackColor = True
        '
        'chkShowSeparators
        '
        Me.chkShowSeparators.AutoSize = True
        Me.chkShowSeparators.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkShowSeparators.Location = New System.Drawing.Point(180, 50)
        Me.chkShowSeparators.Name = "chkShowSeparators"
        Me.chkShowSeparators.Size = New System.Drawing.Size(134, 19)
        Me.chkShowSeparators.TabIndex = 2
        Me.chkShowSeparators.Text = "Mostrar Separadores"
        Me.chkShowSeparators.UseVisualStyleBackColor = True
        '
        'chkShowPercentage
        '
        Me.chkShowPercentage.AutoSize = True
        Me.chkShowPercentage.Checked = True
        Me.chkShowPercentage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowPercentage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkShowPercentage.Location = New System.Drawing.Point(20, 50)
        Me.chkShowPercentage.Name = "chkShowPercentage"
        Me.chkShowPercentage.Size = New System.Drawing.Size(126, 19)
        Me.chkShowPercentage.TabIndex = 1
        Me.chkShowPercentage.Text = "Mostrar Porcentaje"
        Me.chkShowPercentage.UseVisualStyleBackColor = True
        '
        'lblOptions
        '
        Me.lblOptions.BackColor = System.Drawing.Color.Transparent
        Me.lblOptions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblOptions.BorderRadius = 4
        Me.lblOptions.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblOptions.ForeColor = System.Drawing.Color.Black
        Me.lblOptions.GradientColor = System.Drawing.Color.Empty
        Me.lblOptions.Location = New System.Drawing.Point(10, 10)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.OutlineColor = System.Drawing.Color.Black
        Me.lblOptions.Padding = New System.Windows.Forms.Padding(5)
        Me.lblOptions.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOptions.ShadowOffset = New System.Drawing.Point(1, 1)
        Me.lblOptions.Size = New System.Drawing.Size(840, 25)
        Me.lblOptions.TabIndex = 0
        Me.lblOptions.Text = "⚙ Opciones Globales"
        '
        'FormProgressBarDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 470)
        Me.Controls.Add(Me.pnlOptions)
        Me.Controls.Add(Me.pnlDemo5)
        Me.Controls.Add(Me.pnlDemo4)
        Me.Controls.Add(Me.pnlDemo3)
        Me.Controls.Add(Me.pnlDemo2)
        Me.Controls.Add(Me.pnlDemo1)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FormProgressBarDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NXProgressBar - Demostración Completa"
        Me.pnlDemo1.ResumeLayout(False)
        Me.pnlDemo2.ResumeLayout(False)
        Me.pnlDemo3.ResumeLayout(False)
        Me.pnlDemo4.ResumeLayout(False)
        Me.pnlDemo5.ResumeLayout(False)
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As NXLabel
    Friend WithEvents pnlDemo1 As NXPanel
    Friend WithEvents lblDemo1 As NXLabel
    Friend WithEvents pgbContinuous As NXProgressBar
    Friend WithEvents btnStartOperation1 As NXButton
    Friend WithEvents btnStopOperation1 As NXButton
    Friend WithEvents lblValue1 As NXLabel
    Friend WithEvents pnlDemo2 As NXPanel
    Friend WithEvents lblDemo2 As NXLabel
    Friend WithEvents pgbBlocks As NXProgressBar
    Friend WithEvents btnStartOperation2 As NXButton
    Friend WithEvents btnStopOperation2 As NXButton
    Friend WithEvents lblValue2 As NXLabel
    Friend WithEvents pnlDemo3 As NXPanel
    Friend WithEvents lblDemo3 As NXLabel
    Friend WithEvents pgbMarquee As NXProgressBar
    Friend WithEvents btnStartOperation3 As NXButton
    Friend WithEvents btnStopOperation3 As NXButton
    Friend WithEvents pnlDemo4 As NXPanel
    Friend WithEvents lblDemo4 As NXLabel
    Friend WithEvents pgbGradient As NXProgressBar
    Friend WithEvents btnIncrement As NXButton
    Friend WithEvents btnDecrement As NXButton
    Friend WithEvents btnReset As NXButton
    Friend WithEvents lblValue4 As NXLabel
    Friend WithEvents pnlDemo5 As NXPanel
    Friend WithEvents lblDemo5 As NXLabel
    Friend WithEvents pgbVertical As NXProgressBar
    Friend WithEvents pnlOptions As NXPanel
    Friend WithEvents lblOptions As NXLabel
    Friend WithEvents chkShowPercentage As CheckBox
    Friend WithEvents chkShowSeparators As CheckBox
    Friend WithEvents chkUseGradient As CheckBox
End Class