Imports NeoSoft.UI.Controls
Imports NeoSoft.UI.Theming
Imports System.Threading
Imports System.Threading.Tasks

Public Class FormProgressBarDemo

#Region "Campos Privados"

    Private cancellationTokenSource As CancellationTokenSource

#End Region

#Region "Constructor y Load"

    Public Sub New()
        InitializeComponent()

        ' Configurar controles
        ConfigureControls()
    End Sub

    Private Sub FormProgressBarDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ⭐ CARGAR Y APLICAR TEMA GUARDADO
        ThemeSettings.ApplyStoredThemeToForm(Me)
    End Sub

#End Region

#Region "Configuración"

    Private Sub ConfigureControls()
        ' Progress Bar 1 - Continuo básico
        pgbContinuous.Minimum = 0
        pgbContinuous.Maximum = 100
        pgbContinuous.Value = 0
        pgbContinuous.ShowPercentage = True
        pgbContinuous.Style = NXProgressBar.ProgressBarStyle.Continuous
        pgbContinuous.UseTheme = True ' ⭐ Usar tema

        ' Progress Bar 2 - Bloques con separadores
        pgbBlocks.Minimum = 0
        pgbBlocks.Maximum = 100
        pgbBlocks.Value = 0
        pgbBlocks.ShowSeparators = True
        pgbBlocks.SeparatorCount = 10
        pgbBlocks.Style = NXProgressBar.ProgressBarStyle.Blocks
        pgbBlocks.UseTheme = True ' ⭐ Usar tema

        ' Progress Bar 3 - Marquee
        pgbMarquee.Style = NXProgressBar.ProgressBarStyle.Marquee
        pgbMarquee.ShowPercentage = True
        pgbMarquee.CustomText = "Procesando..."
        pgbMarquee.UseTheme = True ' ⭐ Usar tema

        ' Progress Bar 4 - Con gradiente - PERMITE INTERACCIÓN CON MOUSE
        pgbGradient.UseGradient = True
        pgbGradient.ProgressColor = Color.FromArgb(76, 175, 80)
        pgbGradient.ProgressColor2 = Color.FromArgb(139, 195, 74)
        pgbGradient.ShowPercentage = True
        pgbGradient.AllowMouseInteraction = True ' ⭐ PERMITIR CLIC
        pgbGradient.Value = 0
        pgbGradient.Minimum = 0
        pgbGradient.Maximum = 100
        ' NO usar tema aquí para mostrar colores personalizados
        pgbGradient.UseTheme = False

        ' Progress Bar 5 - Vertical - PERMITE INTERACCIÓN CON MOUSE
        pgbVertical.Orientation = NXProgressBar.ProgressBarOrientation.Vertical
        pgbVertical.ShowPercentage = True
        pgbVertical.Value = 60
        pgbVertical.AllowMouseInteraction = True ' ⭐ PERMITIR CLIC
        pgbVertical.UseTheme = True ' ⭐ Usar tema

        ' Deshabilitar botones de stop al inicio
        btnStopOperation1.Enabled = False
        btnStopOperation2.Enabled = False
        btnStopOperation3.Enabled = False
    End Sub

#End Region

#Region "Eventos de Botones"

    Private Async Sub BtnStartOperation1_Click(sender As Object, e As EventArgs) Handles btnStartOperation1.Click
        btnStartOperation1.Enabled = False
        btnStopOperation1.Enabled = True

        pgbContinuous.BeginOperation()

        ' Simular operación con progreso incremental
        cancellationTokenSource = New CancellationTokenSource()

        Try
            For i As Integer = 0 To 100
                If cancellationTokenSource.Token.IsCancellationRequested Then
                    Exit For
                End If

                pgbContinuous.Value = i
                Await Task.Delay(50, cancellationTokenSource.Token)
            Next

            If Not cancellationTokenSource.Token.IsCancellationRequested Then
                pgbContinuous.CompleteOperation()
                MessageBox.Show("Operación completada exitosamente!", "NXProgressBar Demo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As TaskCanceledException
            ' Operación cancelada
        Finally
            btnStartOperation1.Enabled = True
            btnStopOperation1.Enabled = False
        End Try
    End Sub

    Private Sub BtnStopOperation1_Click(sender As Object, e As EventArgs) Handles btnStopOperation1.Click
        If cancellationTokenSource IsNot Nothing Then
            cancellationTokenSource.Cancel()
            pgbContinuous.CancelOperation()
        End If
    End Sub

    Private Async Sub BtnStartOperation2_Click(sender As Object, e As EventArgs) Handles btnStartOperation2.Click
        btnStartOperation2.Enabled = False
        btnStopOperation2.Enabled = True

        pgbBlocks.BeginOperation()
        cancellationTokenSource = New CancellationTokenSource()

        Try
            For i As Integer = 0 To 100 Step 10
                If cancellationTokenSource.Token.IsCancellationRequested Then
                    Exit For
                End If

                pgbBlocks.Value = i
                Await Task.Delay(300, cancellationTokenSource.Token)
            Next

            If Not cancellationTokenSource.Token.IsCancellationRequested Then
                pgbBlocks.CompleteOperation()
                MessageBox.Show("Descarga completada!", "NXProgressBar Demo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As TaskCanceledException
            ' Operación cancelada
        Finally
            btnStartOperation2.Enabled = True
            btnStopOperation2.Enabled = False
        End Try
    End Sub

    Private Sub BtnStopOperation2_Click(sender As Object, e As EventArgs) Handles btnStopOperation2.Click
        If cancellationTokenSource IsNot Nothing Then
            cancellationTokenSource.Cancel()
            pgbBlocks.CancelOperation()
        End If
    End Sub

    Private Async Sub BtnStartOperation3_Click(sender As Object, e As EventArgs) Handles btnStartOperation3.Click
        btnStartOperation3.Enabled = False
        btnStopOperation3.Enabled = True

        pgbMarquee.BeginOperation()

        ' Simular operación indeterminada
        cancellationTokenSource = New CancellationTokenSource()

        Try
            ' Simular operación de 5 segundos
            Await Task.Delay(5000, cancellationTokenSource.Token)

            If Not cancellationTokenSource.Token.IsCancellationRequested Then
                pgbMarquee.CompleteOperation()
                MessageBox.Show("Sincronización completada!", "NXProgressBar Demo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As TaskCanceledException
            ' Operación cancelada
        Finally
            btnStartOperation3.Enabled = True
            btnStopOperation3.Enabled = False
        End Try
    End Sub

    Private Sub BtnStopOperation3_Click(sender As Object, e As EventArgs) Handles btnStopOperation3.Click
        If cancellationTokenSource IsNot Nothing Then
            cancellationTokenSource.Cancel()
            pgbMarquee.CancelOperation()
        End If
    End Sub

    Private Sub BtnIncrement_Click(sender As Object, e As EventArgs) Handles btnIncrement.Click
        ' Incrementar directamente sin necesidad de operación activa
        Dim newValue As Integer = pgbGradient.Value + 10
        If newValue > pgbGradient.Maximum Then newValue = pgbGradient.Maximum
        pgbGradient.Value = newValue
    End Sub

    Private Sub BtnDecrement_Click(sender As Object, e As EventArgs) Handles btnDecrement.Click
        ' Decrementar directamente sin necesidad de operación activa
        Dim newValue As Integer = pgbGradient.Value - 10
        If newValue < pgbGradient.Minimum Then newValue = pgbGradient.Minimum
        pgbGradient.Value = newValue
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        pgbGradient.Value = pgbGradient.Minimum
    End Sub

#End Region

#Region "Eventos de CheckBoxes"

    Private Sub ChkShowPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPercentage.CheckedChanged
        pgbContinuous.ShowPercentage = chkShowPercentage.Checked
        pgbBlocks.ShowPercentage = chkShowPercentage.Checked
        pgbGradient.ShowPercentage = chkShowPercentage.Checked
    End Sub

    Private Sub ChkShowSeparators_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSeparators.CheckedChanged
        pgbContinuous.ShowSeparators = chkShowSeparators.Checked
        pgbGradient.ShowSeparators = chkShowSeparators.Checked
    End Sub

    Private Sub ChkUseGradient_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseGradient.CheckedChanged
        pgbContinuous.UseGradient = chkUseGradient.Checked
        pgbGradient.UseGradient = chkUseGradient.Checked
    End Sub

#End Region

#Region "Eventos de ProgressBar"

    Private Sub PgbContinuous_ValueChanged(sender As Object, e As EventArgs) Handles pgbContinuous.ValueChanged
        lblValue1.Text = $"Valor: {pgbContinuous.Value} / {pgbContinuous.Maximum}"
    End Sub

    Private Sub PgbBlocks_ValueChanged(sender As Object, e As EventArgs) Handles pgbBlocks.ValueChanged
        lblValue2.Text = $"Progreso: {pgbBlocks.PercentComplete:0}%"
    End Sub

    Private Sub PgbGradient_ValueChanged(sender As Object, e As EventArgs) Handles pgbGradient.ValueChanged
        lblValue4.Text = $"Valor: {pgbGradient.Value}"
    End Sub

    Private Sub PgbContinuous_ProgressCompleted(sender As Object, e As EventArgs) Handles pgbContinuous.ProgressCompleted
        Console.WriteLine("✅ Operación 1 completada")
    End Sub

    Private Sub PgbBlocks_ProgressCompleted(sender As Object, e As EventArgs) Handles pgbBlocks.ProgressCompleted
        Console.WriteLine("✅ Operación 2 completada")
    End Sub

    Private Sub PgbMarquee_ProgressCompleted(sender As Object, e As EventArgs) Handles pgbMarquee.ProgressCompleted
        Console.WriteLine("✅ Operación 3 completada")
    End Sub

#End Region

#Region "Cleanup"

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cancellationTokenSource IsNot Nothing Then
            cancellationTokenSource.Cancel()
            cancellationTokenSource.Dispose()
        End If

        MyBase.OnFormClosing(e)
    End Sub

#End Region

End Class