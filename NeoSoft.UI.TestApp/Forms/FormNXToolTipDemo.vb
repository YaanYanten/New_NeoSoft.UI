Imports System.Drawing
Imports System.Windows.Forms
Imports NeoSoft.UI.Controls

''' <summary>
''' Formulario de demostración de NXToolTip y NXComboBox
''' </summary>
Public Class FormNXToolTipDemo

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
        SetupTooltips()
        SetupComboBoxes()
    End Sub

#End Region

#Region "Configuración de Tooltips"

    Private Sub SetupTooltips()
        ' ===== SECCIÓN 1: ESTILOS PREDEFINIDOS =====
        nxToolTip1.SetToolTip(btnDefault, "Este es el estilo por defecto del tooltip")
        nxToolTip1.SetToolTipStyle(btnDefault, NXToolTip.TooltipStyle.Default)

        nxToolTip1.SetToolTip(btnInfo, "Información importante para el usuario")
        nxToolTip1.SetToolTipStyle(btnInfo, NXToolTip.TooltipStyle.Info)

        nxToolTip1.SetToolTip(btnSuccess, "Operación completada exitosamente")
        nxToolTip1.SetToolTipStyle(btnSuccess, NXToolTip.TooltipStyle.Success)

        nxToolTip1.SetToolTip(btnWarning, "¡Advertencia! Proceda con precaución")
        nxToolTip1.SetToolTipStyle(btnWarning, NXToolTip.TooltipStyle.Warning)

        nxToolTip1.SetToolTip(btnError, "Error crítico detectado en el sistema")
        nxToolTip1.SetToolTipStyle(btnError, NXToolTip.TooltipStyle.Error)

        nxToolTip1.SetToolTip(btnDark, "Estilo oscuro para interfaces dark mode")
        nxToolTip1.SetToolTipStyle(btnDark, NXToolTip.TooltipStyle.Dark)

        ' ===== SECCIÓN 2: CON ICONOS =====
        nxToolTip1.SetToolTip(btnIconInfo, "Esta es información adicional del sistema")
        nxToolTip1.SetToolTipIcon(btnIconInfo, NXToolTip.TooltipIcon.Info)
        nxToolTip1.SetToolTipStyle(btnIconInfo, NXToolTip.TooltipStyle.Info)

        nxToolTip1.SetToolTip(btnIconWarning, "Atención: Esta acción no se puede deshacer")
        nxToolTip1.SetToolTipIcon(btnIconWarning, NXToolTip.TooltipIcon.Warning)
        nxToolTip1.SetToolTipStyle(btnIconWarning, NXToolTip.TooltipStyle.Warning)

        nxToolTip1.SetToolTip(btnIconError, "Error: No se puede conectar al servidor")
        nxToolTip1.SetToolTipIcon(btnIconError, NXToolTip.TooltipIcon.Error)
        nxToolTip1.SetToolTipStyle(btnIconError, NXToolTip.TooltipStyle.Error)

        nxToolTip1.SetToolTip(btnIconSuccess, "¡Perfecto! Todos los cambios fueron guardados")
        nxToolTip1.SetToolTipIcon(btnIconSuccess, NXToolTip.TooltipIcon.Success)
        nxToolTip1.SetToolTipStyle(btnIconSuccess, NXToolTip.TooltipStyle.Success)

        nxToolTip1.SetToolTip(btnIconHelp, "¿Necesitas ayuda? Presiona F1 para más información")
        nxToolTip1.SetToolTipIcon(btnIconHelp, NXToolTip.TooltipIcon.Help)
        nxToolTip1.SetToolTipStyle(btnIconHelp, NXToolTip.TooltipStyle.Info)

        ' ===== SECCIÓN 3: CON TÍTULOS =====
        nxToolTip1.SetToolTipTitle(btnTitleSimple, "Información del Usuario")
        nxToolTip1.SetToolTip(btnTitleSimple, "Juan Pérez - Administrador del Sistema")
        nxToolTip1.SetToolTipStyle(btnTitleSimple, NXToolTip.TooltipStyle.Default)

        nxToolTip1.SetToolTipTitle(btnTitleIcon, "Notificación")
        nxToolTip1.SetToolTip(btnTitleIcon, "Tienes 5 mensajes nuevos sin leer")
        nxToolTip1.SetToolTipIcon(btnTitleIcon, NXToolTip.TooltipIcon.Info)
        nxToolTip1.SetToolTipStyle(btnTitleIcon, NXToolTip.TooltipStyle.Info)

        nxToolTip1.SetToolTipTitle(btnTitleLong, "Detalles de la Transacción Financiera")
        nxToolTip1.SetToolTip(btnTitleLong, "La transacción se procesó correctamente y el monto fue acreditado")
        nxToolTip1.SetToolTipIcon(btnTitleLong, NXToolTip.TooltipIcon.Success)
        nxToolTip1.SetToolTipStyle(btnTitleLong, NXToolTip.TooltipStyle.Success)

        ' ===== SECCIÓN 4: HTML BÁSICO =====
        nxToolTip1.SetToolTip(btnHtmlBold, "Este texto está en <b>negrita (bold)</b> para énfasis")
        nxToolTip1.SetToolTipStyle(btnHtmlBold, NXToolTip.TooltipStyle.Default)

        nxToolTip1.SetToolTip(btnHtmlItalic, "Este texto está en <i>cursiva (italic)</i> para destacar")
        nxToolTip1.SetToolTipStyle(btnHtmlItalic, NXToolTip.TooltipStyle.Default)

        nxToolTip1.SetToolTip(btnHtmlMixed, "Puedes usar <b>negrita</b>, <i>cursiva</i> y <u>subrayado</u> juntos")
        nxToolTip1.SetToolTipStyle(btnHtmlMixed, NXToolTip.TooltipStyle.Info)

        nxToolTip1.SetToolTip(btnHtmlMultiline, "Primera línea de texto<br/>Segunda línea de texto<br/><b>Tercera</b> línea en <i>negrita</i>")
        nxToolTip1.SetToolTipIcon(btnHtmlMultiline, NXToolTip.TooltipIcon.Info)
        nxToolTip1.SetToolTipStyle(btnHtmlMultiline, NXToolTip.TooltipStyle.Default)

        ' ===== SECCIÓN 5: POSICIONAMIENTO =====
        nxToolTip1.SetToolTip(btnPosAuto, "Posicionamiento automático inteligente")
        nxToolTip1.SetToolTipPosition(btnPosAuto, NXToolTip.TooltipPosition.Auto)
        nxToolTip1.SetToolTipStyle(btnPosAuto, NXToolTip.TooltipStyle.Default)

        nxToolTip1.SetToolTip(btnPosTop, "Este tooltip aparece ARRIBA del control")
        nxToolTip1.SetToolTipPosition(btnPosTop, NXToolTip.TooltipPosition.Top)
        nxToolTip1.SetToolTipStyle(btnPosTop, NXToolTip.TooltipStyle.Info)

        nxToolTip1.SetToolTip(btnPosBottom, "Este tooltip aparece ABAJO del control")
        nxToolTip1.SetToolTipPosition(btnPosBottom, NXToolTip.TooltipPosition.Bottom)
        nxToolTip1.SetToolTipStyle(btnPosBottom, NXToolTip.TooltipStyle.Success)

        nxToolTip1.SetToolTip(btnPosLeft, "Este tooltip aparece a la IZQUIERDA")
        nxToolTip1.SetToolTipPosition(btnPosLeft, NXToolTip.TooltipPosition.Left)
        nxToolTip1.SetToolTipStyle(btnPosLeft, NXToolTip.TooltipStyle.Warning)

        nxToolTip1.SetToolTip(btnPosRight, "Este tooltip aparece a la DERECHA")
        nxToolTip1.SetToolTipPosition(btnPosRight, NXToolTip.TooltipPosition.Right)
        nxToolTip1.SetToolTipStyle(btnPosRight, NXToolTip.TooltipStyle.Error)
    End Sub

#End Region

#Region "Configuración de ComboBoxes"

    Private Sub SetupComboBoxes()
        ' ===== COMBOBOX SIMPLE =====
        nxComboSimple.AddItems(New String() {
            "Ecuador",
            "Colombia",
            "Perú",
            "Chile",
            "Argentina",
            "Brasil",
            "México",
            "España"
        })

        ' Tooltip para combobox simple
        nxToolTip1.SetToolTip(nxComboSimple, "ComboBox simple con <b>búsqueda incremental</b> y autocompletado")
        nxToolTip1.SetToolTipStyle(nxComboSimple, NXToolTip.TooltipStyle.Info)

        ' ===== COMBOBOX CON ICONOS =====
        ' Crear iconos simples (puedes reemplazar con iconos reales)
        Dim homeIcon As Image = CreateSimpleIcon("🏠", Color.FromArgb(33, 150, 243))
        Dim workIcon As Image = CreateSimpleIcon("💼", Color.FromArgb(76, 175, 80))
        Dim mailIcon As Image = CreateSimpleIcon("✉", Color.FromArgb(255, 152, 0))
        Dim phoneIcon As Image = CreateSimpleIcon("📞", Color.FromArgb(156, 39, 176))

        nxComboWithIcons.AddItem(New NXComboBox.NXComboBoxItem("Inicio", "home", homeIcon))
        nxComboWithIcons.AddItem(New NXComboBox.NXComboBoxItem("Trabajo", "work", workIcon))
        nxComboWithIcons.AddItem(New NXComboBox.NXComboBoxItem("Correo", "mail", mailIcon))
        nxComboWithIcons.AddItem(New NXComboBox.NXComboBoxItem("Teléfono", "phone", phoneIcon))

        ' Tooltip para combobox con iconos
        nxToolTip1.SetToolTip(nxComboWithIcons, "ComboBox con <b>iconos</b> en cada item")
        nxToolTip1.SetToolTipIcon(nxComboWithIcons, NXToolTip.TooltipIcon.Info)
        nxToolTip1.SetToolTipStyle(nxComboWithIcons, NXToolTip.TooltipStyle.Success)

        ' ===== COMBOBOX CON GRUPOS =====
        ' Frutas
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Manzana", "apple", Nothing, "Frutas"))
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Naranja", "orange", Nothing, "Frutas"))
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Plátano", "banana", Nothing, "Frutas"))

        ' Verduras
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Zanahoria", "carrot", Nothing, "Verduras"))
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Brócoli", "broccoli", Nothing, "Verduras"))
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Lechuga", "lettuce", Nothing, "Verduras"))

        ' Lácteos
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Leche", "milk", Nothing, "Lácteos"))
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Queso", "cheese", Nothing, "Lácteos"))
        nxComboWithGroups.AddItem(New NXComboBox.NXComboBoxItem("Yogurt", "yogurt", Nothing, "Lácteos"))

        ' Tooltip para combobox con grupos
        nxToolTip1.SetToolTip(nxComboWithGroups, "ComboBox con items <b>organizados en grupos</b>")
        nxToolTip1.SetToolTipIcon(nxComboWithGroups, NXToolTip.TooltipIcon.Info)
        nxToolTip1.SetToolTipStyle(nxComboWithGroups, NXToolTip.TooltipStyle.Warning)

        ' ===== COMBOBOX MULTI-SELECCIÓN =====
        nxComboMultiSelect.AddItems(New String() {
            "C#",
            "VB.NET",
            "Python",
            "JavaScript",
            "Java",
            "C++",
            "PHP",
            "Ruby"
        })

        ' Tooltip para multi-selección
        nxToolTip1.SetToolTipTitle(nxComboMultiSelect, "Multi-Selección")
        nxToolTip1.SetToolTip(nxComboMultiSelect,
            "Selecciona <b>múltiples opciones</b><br/>" &
            "usando <i>checkboxes</i>")
        nxToolTip1.SetToolTipIcon(nxComboMultiSelect, NXToolTip.TooltipIcon.Success)
        nxToolTip1.SetToolTipStyle(nxComboMultiSelect, NXToolTip.TooltipStyle.Info)
    End Sub

    Private Function CreateSimpleIcon(emoji As String, bgColor As Color) As Image
        Dim bmp As New Bitmap(20, 20)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

            ' Fondo circular
            Using brush As New SolidBrush(Color.FromArgb(50, bgColor))
                g.FillEllipse(brush, 0, 0, 19, 19)
            End Using

            ' Emoji/texto
            Using brush As New SolidBrush(bgColor)
                Using font As New Font("Segoe UI Emoji", 10, FontStyle.Bold)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(emoji, font, brush, New RectangleF(0, 0, 20, 20), sf)
                End Using
            End Using
        End Using
        Return bmp
    End Function

#End Region

#Region "Eventos de Configuración"

    Private Sub CboAnimation_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case cboAnimation.SelectedIndex
            Case 0
                nxToolTip1.Animation = NXToolTip.AnimationEffect.None
            Case 1
                nxToolTip1.Animation = NXToolTip.AnimationEffect.Fade
            Case 2
                nxToolTip1.Animation = NXToolTip.AnimationEffect.Slide
            Case 3
                nxToolTip1.Animation = NXToolTip.AnimationEffect.Zoom
        End Select
    End Sub

    Private Sub NumShowDelay_ValueChanged(sender As Object, e As EventArgs)
        nxToolTip1.ShowDelay = CInt(numShowDelay.Value)
    End Sub

    Private Sub NumAutoHide_ValueChanged(sender As Object, e As EventArgs)
        nxToolTip1.AutoHideDelay = CInt(numAutoHide.Value)
    End Sub

#End Region

End Class