Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft
Imports NeoSoft.UI.Controls

''' <summary>
''' Formulario de pruebas para controles NeoSoft.UI
''' Incluye: NXNumericUpDown
''' </summary>
Public Class frmNXControlTest1

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
        SetupDemoData()
    End Sub

#End Region

#Region "Configuración de Datos Demo"

    Private Sub SetupDemoData()
        SetupNumericUpDownData()
    End Sub

    Private Sub SetupNumericUpDownData()
        ' Tab 1: Formatos - Ya configurados en Designer

        ' Tab 2: Máscaras - Ya configurados en Designer

        ' Tab 3: Validación - Ya configurados en Designer

        ' Tab 4: Personalización - Ya configurados en Designer
    End Sub

#End Region

#Region "Eventos - NXNumericUpDown Formatos (Tab 1)"

    Private Sub NumInteger_ValueChanged(sender As Object, e As EventArgs) Handles numInteger.ValueChanged
        lblIntegerValue.Text = $"Valor: {numInteger.Value}"
    End Sub

    Private Sub NumDecimal_ValueChanged(sender As Object, e As EventArgs) Handles numDecimal.ValueChanged
        lblDecimalValue.Text = $"Valor: {numDecimal.Value}"
    End Sub

    Private Sub NumCurrency_ValueChanged(sender As Object, e As EventArgs) Handles numCurrency.ValueChanged
        lblCurrencyValue.Text = $"Valor: {numCurrency.Value}"
    End Sub

    Private Sub NumPercentage_ValueChanged(sender As Object, e As EventArgs) Handles numPercentage.ValueChanged
        lblPercentageValue.Text = $"Valor: {numPercentage.Value}"
    End Sub

#End Region

#Region "Eventos - NXNumericUpDown Máscaras (Tab 2)"

    Private Sub NumPhone_ValueChanged(sender As Object, e As EventArgs)
        lblPhoneValue.Text = $"Valor: {numPhone.Value}"
    End Sub

    Private Sub NumZip_ValueChanged(sender As Object, e As EventArgs)
        lblZipValue.Text = $"Valor: {numZip.Value}"
    End Sub

    Private Sub NumTime_ValueChanged(sender As Object, e As EventArgs)
        lblTimeValue.Text = $"Valor: {numTime.Value}"
    End Sub

    Private Sub NumIP_ValueChanged(sender As Object, e As EventArgs)
        lblIPValue.Text = $"Valor: {numIP.Value}"
    End Sub

#End Region

#Region "Eventos - NXNumericUpDown Validación (Tab 3)"

    Private Sub NumRange_ValueChanged(sender As Object, e As EventArgs)
        lblRangeValue.Text = $"Valor: {numRange.Value}"
    End Sub

    Private Sub NumWrap_ValueChanged(sender As Object, e As EventArgs)
        lblWrapValue.Text = $"Valor: {numWrap.Value}"
    End Sub

    Private Sub NumNegative_ValueChanged(sender As Object, e As EventArgs)
        lblNegativeValue.Text = $"Valor: {numNegative.Value}"
    End Sub

    Private Sub NumPositive_ValueChanged(sender As Object, e As EventArgs)
        lblPositiveValue.Text = $"Valor: {numPositive.Value}"
    End Sub

#End Region

#Region "Eventos - NXNumericUpDown Personalización (Tab 4)"

    Private Sub NumPrefix_ValueChanged(sender As Object, e As EventArgs)
        lblPrefixValue.Text = $"Valor: {numPrefix.Value}"
    End Sub

    Private Sub NumSuffix_ValueChanged(sender As Object, e As EventArgs)
        lblSuffixValue.Text = $"Valor: {numSuffix.Value}"
    End Sub

    Private Sub NumReadOnly_ValueChanged(sender As Object, e As EventArgs)
        lblReadOnlyValue.Text = $"Valor: {numReadOnly.Value}"
    End Sub

    Private Sub NumIncrement_ValueChanged(sender As Object, e As EventArgs)
        lblIncrementValue.Text = $"Valor: {numIncrement.Value}"
    End Sub

#End Region

End Class