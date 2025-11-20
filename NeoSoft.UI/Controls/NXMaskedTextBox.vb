Imports System.ComponentModel
Imports System.Windows.Forms
Imports NeoSoft.UI.Helpers

Namespace Controls

    ''' <summary>
    ''' MaskedTextBox personalizado con validación en tiempo real
    ''' </summary>
    Friend Class NXMaskedTextBox
        Inherits MaskedTextBox

#Region "Campos Privados"

        Private _validationRule As MaskValidationRules.MaskRule
        Private _isInitializing As Boolean = False

#End Region

#Region "Constructor"

        Public Sub New()
            MyBase.New()
            Me.BeepOnError = False
            Me.RejectInputOnFirstFailure = False
            Me.PromptChar = "_"c
            Me.HidePromptOnLeave = False
        End Sub

#End Region

#Region "Propiedades"

        Public Property ValidationRule As MaskValidationRules.MaskRule
            Get
                Return _validationRule
            End Get
            Set(value As MaskValidationRules.MaskRule)
                _validationRule = value
                If value IsNot Nothing Then
                    Me.Mask = value.Mask
                End If
            End Set
        End Property

#End Region

#Region "Métodos Protegidos - Eventos"

        Protected Overrides Sub OnGotFocus(e As EventArgs)
            MyBase.OnGotFocus(e)

            ' Si la regla indica que debe poner la fecha actual
            If _validationRule IsNot Nothing AndAlso
               _validationRule.SetCurrentDateOnFocus AndAlso
               String.IsNullOrWhiteSpace(Me.Text.Replace("_", "").Replace("/", "").Replace("-", "").Replace(":", "").Replace(" ", "")) Then

                _isInitializing = True

                Try
                    Dim now As DateTime = DateTime.Now

                    Select Case _validationRule.RuleType
                        Case MaskValidationRules.MaskRuleType.ShortDate
                            Me.Text = now.ToString("dd/MM/yyyy")

                        Case MaskValidationRules.MaskRuleType.ISODate
                            Me.Text = now.ToString("yyyy-MM-dd")

                        Case MaskValidationRules.MaskRuleType.DateTime
                            Me.Text = now.ToString("dd/MM/yyyy HH:mm")

                        Case MaskValidationRules.MaskRuleType.Time24
                            Me.Text = now.ToString("HH:mm")

                        Case MaskValidationRules.MaskRuleType.Time12
                            Me.Text = now.ToString("hh:mm tt")
                    End Select

                    Me.SelectAll()
                Finally
                    _isInitializing = False
                End Try
            End If
        End Sub

        Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
            ' No validar durante inicialización
            If _isInitializing Then
                MyBase.OnKeyPress(e)
                Return
            End If

            ' Si no hay regla de validación, comportamiento normal
            If _validationRule Is Nothing OrElse Not _validationRule.ValidateWhileTyping Then
                MyBase.OnKeyPress(e)
                Return
            End If

            ' No validar teclas de control (Backspace, Delete, Enter, etc.)
            If Char.IsControl(e.KeyChar) Then
                MyBase.OnKeyPress(e)
                Return
            End If

            ' ⭐ CRÍTICO: Validar con el validador personalizado ANTES de permitir la tecla
            If _validationRule.CustomValidator IsNot Nothing Then
                ' Obtener posición real sin contar caracteres de formato
                Dim realPosition As Integer = GetRealCursorPosition()

                Dim isValid As Boolean = _validationRule.CustomValidator(Me.Text, realPosition, e.KeyChar)

                If Not isValid Then
                    e.Handled = True ' ⭐ RECHAZAR la entrada
                    System.Media.SystemSounds.Beep.Play()
                    Debug.WriteLine($"❌ Rechazado: '{e.KeyChar}' en posición {realPosition} - Texto actual: '{Me.Text}'")
                    Return
                Else
                    Debug.WriteLine($"✅ Aceptado: '{e.KeyChar}' en posición {realPosition}")
                End If
            End If

            MyBase.OnKeyPress(e)
        End Sub

        ''' <summary>
        ''' Obtiene la posición real del cursor sin contar caracteres de formato
        ''' </summary>
        Private Function GetRealCursorPosition() As Integer
            Dim position As Integer = Me.SelectionStart
            Dim textUpToCursor As String = Me.Text.Substring(0, Math.Min(position, Me.Text.Length))

            ' Contar solo los dígitos/caracteres reales (sin separadores)
            Dim realPos As Integer = 0
            For Each c As Char In textUpToCursor
                If Char.IsDigit(c) OrElse Char.IsLetter(c) Then
                    realPos += 1
                End If
            Next

            Return realPos
        End Function

#End Region

    End Class

End Namespace