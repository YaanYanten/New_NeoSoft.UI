Imports System.Text.RegularExpressions

Namespace Helpers

    ''' <summary>
    ''' Reglas de validación para máscaras de entrada
    ''' Define restricciones y validaciones en tiempo real
    ''' </summary>
    Public Class MaskValidationRules

#Region "Enumeraciones"

        Public Enum MaskRuleType
            None
            ShortDate           ' dd/MM/yyyy
            ISODate             ' yyyy-MM-dd
            DateTime            ' dd/MM/yyyy HH:mm
            Time24              ' HH:mm
            Time12              ' hh:mm AA
            PhoneNumber         ' (000) 000-0000
            SocialSecurity      ' 000-00-0000
            ZipCode             ' 00000 o 00000-0000
            IPv4                ' 000.000.000.000
            Numeric             ' 000,000.00
            Custom
        End Enum

#End Region

#Region "Clase de Regla"

        Public Class MaskRule
            Public Property RuleType As MaskRuleType
            Public Property Mask As String
            Public Property PromptChar As Char = "_"c
            Public Property AllowPromptAsInput As Boolean = False
            Public Property ValidateWhileTyping As Boolean = True
            Public Property SetCurrentDateOnFocus As Boolean = False
            Public Property MinYear As Integer = 1800
            Public Property MaxYear As Integer = 2200

            ' Delegado para validación personalizada
            Public Property CustomValidator As Func(Of String, Integer, Char, Boolean)
        End Class

#End Region

#Region "Reglas Predefinidas"

        ''' <summary>
        ''' Obtiene la regla de validación según la máscara
        ''' </summary>
        Public Shared Function GetRuleForMask(mask As String) As MaskRule
            If String.IsNullOrEmpty(mask) Then
                Return New MaskRule With {.RuleType = MaskRuleType.None, .Mask = ""}
            End If

            ' Detectar tipo de máscara
            If mask = "00/00/0000" Then
                Return CreateShortDateRule()
            ElseIf mask = "00/00/00" Then
                ' ⭐ Fecha corta con año de 2 dígitos
                Return New MaskRule With {
                    .RuleType = MaskRuleType.ShortDate,
                    .Mask = "00/00/00",
                    .ValidateWhileTyping = True,
                    .SetCurrentDateOnFocus = True,
                    .CustomValidator = AddressOf ValidateShortDate2DigitYearInput
                }
            ElseIf mask = "0000-00-00" Then
                Return CreateISODateRule()
            ElseIf mask.Contains("/") AndAlso mask.Contains(":") Then
                Return CreateDateTimeRule(mask)
            ElseIf mask.Contains(":") AndAlso Not mask.Contains("/") Then
                If mask.ToUpper().Contains("A") Then
                    Return CreateTime12Rule()
                Else
                    Return CreateTime24Rule()
                End If
            ElseIf mask.Contains("(") AndAlso mask.Contains(")") Then
                Return CreatePhoneNumberRule()
            ElseIf mask = "000-00-0000" Then
                Return CreateSocialSecurityRule()
            ElseIf mask.Contains(".") AndAlso mask.Split("."c).Length = 4 Then
                Return CreateIPv4Rule()
            ElseIf mask.Contains(",") OrElse mask.Contains(".") Then
                Return CreateNumericRule(mask)
            Else
                Return New MaskRule With {
                    .RuleType = MaskRuleType.None,
                    .Mask = mask,
                    .ValidateWhileTyping = False
                }
            End If
        End Function

        Private Shared Function CreateShortDateRule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.ShortDate,
                .Mask = "00/00/0000",
                .ValidateWhileTyping = True,
                .SetCurrentDateOnFocus = True,
                .CustomValidator = AddressOf ValidateShortDateInput
            }
        End Function

        Private Shared Function CreateISODateRule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.ISODate,
                .Mask = "0000-00-00",
                .ValidateWhileTyping = True,
                .SetCurrentDateOnFocus = True,
                .CustomValidator = AddressOf ValidateISODateInput
            }
        End Function

        Private Shared Function CreateDateTimeRule(mask As String) As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.DateTime,
                .Mask = mask,
                .ValidateWhileTyping = True,
                .SetCurrentDateOnFocus = True,
                .CustomValidator = AddressOf ValidateDateTimeInput
            }
        End Function

        Private Shared Function CreateTime24Rule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.Time24,
                .Mask = "00:00",
                .ValidateWhileTyping = True,
                .CustomValidator = AddressOf ValidateTime24Input
            }
        End Function

        Private Shared Function CreateTime12Rule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.Time12,
                .Mask = "00:00 AA",
                .ValidateWhileTyping = True,
                .CustomValidator = AddressOf ValidateTime12Input
            }
        End Function

        Private Shared Function CreatePhoneNumberRule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.PhoneNumber,
                .Mask = "(000) 000-0000",
                .ValidateWhileTyping = True,
                .CustomValidator = AddressOf ValidatePhoneNumberInput
            }
        End Function

        Private Shared Function CreateSocialSecurityRule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.SocialSecurity,
                .Mask = "000-00-0000",
                .ValidateWhileTyping = False ' No validar mientras escribe (es secuencial)
            }
        End Function

        Private Shared Function CreateIPv4Rule() As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.IPv4,
                .Mask = "000.000.000.000",
                .ValidateWhileTyping = True,
                .CustomValidator = AddressOf ValidateIPv4Input
            }
        End Function

        Private Shared Function CreateNumericRule(mask As String) As MaskRule
            Return New MaskRule With {
                .RuleType = MaskRuleType.Numeric,
                .Mask = mask,
                .ValidateWhileTyping = False ' Los separadores ya están fijos
            }
        End Function

#End Region

#Region "Validadores en Tiempo Real"

        ''' <summary>
        ''' Valida entrada para fecha corta (dd/MM/yyyy)
        ''' </summary>
        Private Shared Function ValidateShortDateInput(currentText As String, position As Integer, charToAdd As Char) As Boolean
            ' Solo aceptar dígitos
            If Not Char.IsDigit(charToAdd) Then
                Return False
            End If

            Try
                ' Construir texto temporal con el nuevo carácter
                Dim tempText As String = currentText.Replace("_", "0").Replace("/", "")

                ' Insertar el nuevo dígito en la posición correcta
                If position < tempText.Length Then
                    tempText = tempText.Remove(position, 1).Insert(position, charToAdd.ToString())
                Else
                    tempText = tempText.PadRight(position, "0"c) & charToAdd
                End If

                ' Asegurar que tenemos suficientes dígitos
                If tempText.Length < position + 1 Then
                    Return True ' Aún no hay suficientes dígitos para validar
                End If

                ' ⭐ VALIDAR SEGÚN POSICIÓN
                ' Formato: dd/MM/yyyy (posiciones 0-1: día, 2-3: mes, 4-7: año)

                ' Validar PRIMER dígito del día (posición 0)
                If position = 0 Then
                    Dim firstDigit As Integer = Integer.Parse(charToAdd.ToString())
                    If firstDigit > 3 Then Return False ' Día no puede empezar con 4-9
                    Return True
                End If

                ' Validar SEGUNDO dígito del día (posición 1)
                If position = 1 Then
                    Dim day As Integer = Integer.Parse(tempText.Substring(0, 2))
                    If day < 1 OrElse day > 31 Then Return False
                    Return True
                End If

                ' Validar PRIMER dígito del mes (posición 2)
                If position = 2 Then
                    Dim firstDigit As Integer = Integer.Parse(charToAdd.ToString())
                    If firstDigit > 1 Then Return False ' Mes no puede empezar con 2-9
                    Return True
                End If

                ' Validar SEGUNDO dígito del mes (posición 3)
                If position = 3 Then
                    Dim month As Integer = Integer.Parse(tempText.Substring(2, 2))
                    If month < 1 OrElse month > 12 Then Return False

                    ' ⭐ VALIDAR DÍA SEGÚN MES
                    Dim day As Integer = Integer.Parse(tempText.Substring(0, 2))
                    If month = 2 AndAlso day > 29 Then Return False ' Febrero máx 29
                    If (month = 4 OrElse month = 6 OrElse month = 9 OrElse month = 11) AndAlso day > 30 Then Return False ' Meses de 30 días

                    Return True
                End If

                ' Validar año (posiciones 4-7)
                If position >= 4 Then
                    ' Solo validar año completo
                    If position = 7 AndAlso tempText.Length >= 8 Then
                        Dim year As Integer = Integer.Parse(tempText.Substring(4, 4))
                        If year < 1800 OrElse year > 2200 Then Return False

                        ' ⭐ VALIDAR DÍA SEGÚN MES Y AÑO (años bisiestos)
                        Dim day As Integer = Integer.Parse(tempText.Substring(0, 2))
                        Dim month As Integer = Integer.Parse(tempText.Substring(2, 2))

                        If month = 2 AndAlso day = 29 Then
                            ' Validar año bisiesto
                            Dim isLeapYear As Boolean = (year Mod 4 = 0 AndAlso year Mod 100 <> 0) OrElse (year Mod 400 = 0)
                            If Not isLeapYear Then Return False
                        End If
                    End If
                End If

                Return True

            Catch ex As Exception
                Debug.WriteLine($"Error en validación: {ex.Message}")
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Valida entrada para fecha corta de 2 dígitos (dd/MM/yy)
        ''' </summary>
        Private Shared Function ValidateShortDate2DigitYearInput(currentText As String, position As Integer, charToAdd As Char) As Boolean
            If Not Char.IsDigit(charToAdd) Then Return False

            Try
                Dim tempText As String = currentText.Replace("_", "0").Replace("/", "")

                If position < tempText.Length Then
                    tempText = tempText.Remove(position, 1).Insert(position, charToAdd.ToString())
                End If

                ' Validar día (posiciones 0-1)
                If position = 0 Then
                    If Integer.Parse(charToAdd.ToString()) > 3 Then Return False
                    Return True
                End If

                If position = 1 Then
                    Dim day As Integer = Integer.Parse(tempText.Substring(0, 2))
                    If day < 1 OrElse day > 31 Then Return False
                    Return True
                End If

                ' Validar mes (posiciones 2-3)
                If position = 2 Then
                    If Integer.Parse(charToAdd.ToString()) > 1 Then Return False
                    Return True
                End If

                If position = 3 Then
                    Dim month As Integer = Integer.Parse(tempText.Substring(2, 2))
                    If month < 1 OrElse month > 12 Then Return False

                    Dim day As Integer = Integer.Parse(tempText.Substring(0, 2))
                    If month = 2 AndAlso day > 29 Then Return False
                    If (month = 4 OrElse month = 6 OrElse month = 9 OrElse month = 11) AndAlso day > 30 Then Return False

                    Return True
                End If

                Return True

            Catch
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Valida entrada para fecha ISO (yyyy-MM-dd)
        ''' </summary>
        Private Shared Function ValidateISODateInput(currentText As String, position As Integer, charToAdd As Char) As Boolean
            Dim tempText As String = currentText
            If position < tempText.Length Then
                tempText = tempText.Remove(position, 1).Insert(position, charToAdd.ToString())
            End If

            tempText = tempText.Replace("_", "0").Replace("-", "")

            ' Validar año (posiciones 0-3)
            If tempText.Length >= 4 AndAlso position <= 3 Then
                Dim year As Integer
                If Integer.TryParse(tempText.Substring(0, 4), year) Then
                    If year < 1800 OrElse year > 2200 Then Return False
                End If
            End If

            ' Validar mes (posiciones 4-5)
            If tempText.Length >= 6 AndAlso position >= 4 AndAlso position <= 5 Then
                Dim month As Integer
                If Integer.TryParse(tempText.Substring(4, 2), month) Then
                    If month < 1 OrElse month > 12 Then Return False
                End If
            End If

            ' Validar día (posiciones 6-7)
            If tempText.Length >= 8 AndAlso position >= 6 Then
                Dim day As Integer
                If Integer.TryParse(tempText.Substring(6, 2), day) Then
                    If day < 1 OrElse day > 31 Then Return False
                End If
            End If

            Return True
        End Function

        ''' <summary>
        ''' Valida entrada para fecha y hora
        ''' </summary>
        Private Shared Function ValidateDateTimeInput(currentText As String, position As Integer, charToAdd As Char) As Boolean
            ' Separar fecha de hora (espacio como delimitador)
            Dim parts As String() = currentText.Split(" "c)

            If parts.Length >= 1 AndAlso position < parts(0).Length Then
                ' Validar parte de fecha
                Return ValidateShortDateInput(parts(0), position, charToAdd)
            ElseIf parts.Length >= 2 Then
                ' Validar parte de hora
                Dim hourPosition As Integer = position - parts(0).Length - 1
                Return ValidateTime24Input(parts(1), hourPosition, charToAdd)
            End If

            Return True
        End Function

        ''' <summary>
        ''' Valida entrada para hora 24h (HH:mm)
        ''' </summary>
        Private Shared Function ValidateTime24Input(currentText As String, position As Integer, charToAdd As Char) As Boolean
            Dim tempText As String = currentText
            If position < tempText.Length Then
                tempText = tempText.Remove(position, 1).Insert(position, charToAdd.ToString())
            End If

            tempText = tempText.Replace("_", "0").Replace(":", "")

            ' Validar hora (posiciones 0-1)
            If tempText.Length >= 2 AndAlso position <= 1 Then
                Dim hour As Integer
                If Integer.TryParse(tempText.Substring(0, 2), hour) Then
                    If hour < 0 OrElse hour > 23 Then Return False
                End If
            End If

            ' Validar minutos (posiciones 2-3)
            If tempText.Length >= 4 AndAlso position >= 2 Then
                Dim minute As Integer
                If Integer.TryParse(tempText.Substring(2, 2), minute) Then
                    If minute < 0 OrElse minute > 59 Then Return False
                End If
            End If

            Return True
        End Function

        ''' <summary>
        ''' Valida entrada para hora 12h (hh:mm AA)
        ''' </summary>
        Private Shared Function ValidateTime12Input(currentText As String, position As Integer, charToAdd As Char) As Boolean
            Dim tempText As String = currentText
            If position < tempText.Length Then
                tempText = tempText.Remove(position, 1).Insert(position, charToAdd.ToString())
            End If

            ' Remover AM/PM y espacios
            tempText = Regex.Replace(tempText, "[AaPpMm\s_]", "").Replace(":", "")

            ' Validar hora (posiciones 0-1)
            If tempText.Length >= 2 AndAlso position <= 1 Then
                Dim hour As Integer
                If Integer.TryParse(tempText.Substring(0, Math.Min(2, tempText.Length)), hour) Then
                    If hour < 1 OrElse hour > 12 Then Return False
                End If
            End If

            ' Validar minutos (posiciones 2-3)
            If tempText.Length >= 4 AndAlso position >= 2 AndAlso position <= 4 Then
                Dim minute As Integer
                If Integer.TryParse(tempText.Substring(2, Math.Min(2, tempText.Length - 2)), minute) Then
                    If minute < 0 OrElse minute > 59 Then Return False
                End If
            End If

            Return True
        End Function

        ''' <summary>
        ''' Valida entrada para número de teléfono
        ''' </summary>
        Private Shared Function ValidatePhoneNumberInput(currentText As String, position As Integer, charToAdd As Char) As Boolean
            ' Solo permitir dígitos (los paréntesis y guiones están fijos en la máscara)
            Return Char.IsDigit(charToAdd)
        End Function

        ''' <summary>
        ''' Valida entrada para IPv4
        ''' </summary>
        Private Shared Function ValidateIPv4Input(currentText As String, position As Integer, charToAdd As Char) As Boolean
            Dim tempText As String = currentText
            If position < tempText.Length Then
                tempText = tempText.Remove(position, 1).Insert(position, charToAdd.ToString())
            End If

            ' Dividir por octetos
            Dim parts As String() = tempText.Split("."c)

            ' Determinar en qué octeto está la posición
            Dim currentDots As Integer = currentText.Substring(0, Math.Min(position, currentText.Length)).Count(Function(c) c = "."c)

            If currentDots < parts.Length Then
                Dim octetValue As String = parts(currentDots).Replace("_", "")
                If Not String.IsNullOrEmpty(octetValue) Then
                    Dim octet As Integer
                    If Integer.TryParse(octetValue, octet) Then
                        If octet < 0 OrElse octet > 255 Then Return False
                    End If
                End If
            End If

            Return True
        End Function

#End Region

    End Class

End Namespace