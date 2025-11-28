Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports NeoSoft.UI.Controls

''' <summary>
''' Formulario de demostración de NXCheckComboBox y NXListBox
''' </summary>
Public Class FormNXCheckComboBoxDemo

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
        SetupDemoData()
    End Sub

#End Region

#Region "Configuración de Datos Demo"

    Private Sub SetupDemoData()
        SetupCheckComboData()
        SetupListBoxData()
    End Sub

    Private Sub SetupCheckComboData()
        ' NXCheckComboBox 1: Simple
        nxCheckCombo1.Placeholder = "Seleccione un país..."
        nxCheckCombo1.AddItem("Ecuador")
        nxCheckCombo1.AddItem("Colombia")
        nxCheckCombo1.AddItem("Perú")
        nxCheckCombo1.AddItem("Chile")
        nxCheckCombo1.AddItem("Argentina")
        nxCheckCombo1.AddItem("Brasil")
        nxCheckCombo1.AddItem("México")
        nxCheckCombo1.AddItem("España")

        ' NXCheckComboBox 2: Con Iconos
        nxCheckCombo2.Placeholder = "Seleccione red social..."
        nxCheckCombo2.AddItem(New NXComboBox.NXComboBoxItem("Facebook", "fb", CreateSimpleIcon("F", Color.FromArgb(66, 103, 178))))
        nxCheckCombo2.AddItem(New NXComboBox.NXComboBoxItem("Twitter", "tw", CreateSimpleIcon("T", Color.FromArgb(29, 161, 242))))
        nxCheckCombo2.AddItem(New NXComboBox.NXComboBoxItem("Instagram", "ig", CreateSimpleIcon("I", Color.FromArgb(225, 48, 108))))
        nxCheckCombo2.AddItem(New NXComboBox.NXComboBoxItem("LinkedIn", "li", CreateSimpleIcon("L", Color.FromArgb(0, 119, 181))))

        ' NXCheckComboBox 3: Con Grupos
        nxCheckCombo3.Placeholder = "Seleccione categoría..."
        nxCheckCombo3.AddItem(New NXComboBox.NXComboBoxItem("Manzana", "apple", Nothing, "Frutas"))
        nxCheckCombo3.AddItem(New NXComboBox.NXComboBoxItem("Naranja", "orange", Nothing, "Frutas"))
        nxCheckCombo3.AddItem(New NXComboBox.NXComboBoxItem("Zanahoria", "carrot", Nothing, "Verduras"))
        nxCheckCombo3.AddItem(New NXComboBox.NXComboBoxItem("Brócoli", "broccoli", Nothing, "Verduras"))
        nxCheckCombo3.AddItem(New NXComboBox.NXComboBoxItem("Leche", "milk", Nothing, "Lácteos"))
        nxCheckCombo3.AddItem(New NXComboBox.NXComboBoxItem("Queso", "cheese", Nothing, "Lácteos"))

        ' NXCheckComboBox 4: Multi-Selección
        nxCheckCombo4.Placeholder = "Seleccione lenguajes..."
        nxCheckCombo4.MultiSelect = NXComboBox.SelectionMode.MultiCheckbox
        nxCheckCombo4.AddItem("C#")
        nxCheckCombo4.AddItem("VB.NET")
        nxCheckCombo4.AddItem("Python")
        nxCheckCombo4.AddItem("JavaScript")
        nxCheckCombo4.AddItem("Java")
        nxCheckCombo4.AddItem("C++")
        nxCheckCombo4.AddItem("PHP")
        nxCheckCombo4.AddItem("Ruby")
    End Sub

    Private Sub SetupListBoxData()
        ' NXListBox Simple
        For i = 1 To 30
            nxListSimple.AddItem($"Item de Lista {i:D2}", i)
        Next

        ' NXListBox Checkboxes
        nxListCheckboxes.AddItem("📧 Revisar emails pendientes")
        nxListCheckboxes.AddItem("📊 Completar reporte mensual")
        nxListCheckboxes.AddItem("📞 Llamar a cliente importante")
        nxListCheckboxes.AddItem("📝 Actualizar documentación")
        nxListCheckboxes.AddItem("🎤 Preparar presentación Q4")
        nxListCheckboxes.AddItem("🔍 Revisar código fuente")
        nxListCheckboxes.AddItem("🧪 Testing de nuevas features")
        nxListCheckboxes.AddItem("💾 Backup de base de datos")
        nxListCheckboxes.AddItem("⬆️ Actualizar dependencias")
        nxListCheckboxes.AddItem("👥 Reunión con el equipo")
        nxListCheckboxes.AddItem("🐛 Resolver bugs críticos")
        nxListCheckboxes.AddItem("🚀 Deploy a producción")

        ' NXListBox Iconos
        LoadSampleContacts()
    End Sub

    Private Sub LoadSampleContacts()
        ' Opción 1: Array de arrays (jagged array)
        Dim contacts As String()() = {
            New String() {"Juan Pérez", "juan.perez@empresa.com", "+593-99-123-4567"},
            New String() {"María García", "maria.garcia@empresa.com", "+593-98-234-5678"},
            New String() {"Carlos López", "carlos.lopez@empresa.com", "+593-97-345-6789"},
            New String() {"Ana Martínez", "ana.martinez@empresa.com", "+593-96-456-7890"},
            New String() {"Luis Rodríguez", "luis.rodriguez@empresa.com", "+593-95-567-8901"}
        }

        For Each contact In contacts
            Dim icon = CreateContactIcon(contact(0).Substring(0, 1))
            Dim item As New NXListBox.NXListBoxItem(contact(0), Nothing, icon)
            item.SubItems.Add(contact(1))
            item.SubItems.Add(contact(2))
            nxListIcons.AddItem(item)
        Next
    End Sub

#End Region

#Region "Helpers - Crear Iconos"

    Private Function CreateSimpleIcon(letter As String, bgColor As Color) As Image
        Dim bmp As New Bitmap(20, 20)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Using brush As New SolidBrush(Color.FromArgb(200, bgColor))
                g.FillEllipse(brush, 0, 0, 19, 19)
            End Using
            Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                Using brush As New SolidBrush(Color.White)
                    Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    g.DrawString(letter, font, brush, New RectangleF(0, 0, 20, 20), sf)
                End Using
            End Using
        End Using
        Return bmp
    End Function

    Private Function CreateContactIcon(initial As String) As Image
        Dim bmp As New Bitmap(32, 32)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim colors() As Color = {Color.FromArgb(0, 120, 215), Color.FromArgb(0, 153, 188), Color.FromArgb(232, 17, 35), Color.FromArgb(255, 140, 0), Color.FromArgb(76, 175, 80)}
            Dim bgColor = colors(New Random(initial.GetHashCode()).Next(colors.Length))
            Using brush As New SolidBrush(bgColor)
                g.FillEllipse(brush, 0, 0, 31, 31)
            End Using
            Using brush As New SolidBrush(Color.White)
                Using font As New Font("Segoe UI", 14, FontStyle.Bold)
                    Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    g.DrawString(initial.ToUpper(), font, brush, New Rectangle(0, 0, 32, 32), sf)
                End Using
            End Using
        End Using
        Return bmp
    End Function

#End Region

#Region "Eventos NXCheckComboBox"

    Private Sub NxCheckCombo1_CheckedChanged(sender As Object, e As EventArgs) Handles nxCheckCombo1.CheckedChanged
        lblStatus1.Text = If(nxCheckCombo1.Checked, "Estado: Habilitado ✓", "Estado: Deshabilitado")
        lblStatus1.ForeColor = If(nxCheckCombo1.Checked, Color.FromArgb(40, 167, 69), Color.FromArgb(108, 117, 125))
    End Sub

    Private Sub NxCheckCombo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nxCheckCombo1.SelectedIndexChanged
        lblSelection1.Text = If(nxCheckCombo1.SelectedItem IsNot Nothing, $"Selección: {nxCheckCombo1.SelectedItem.Text}", "Selección: (ninguna)")
    End Sub

    Private Sub NxCheckCombo2_CheckedChanged(sender As Object, e As EventArgs) Handles nxCheckCombo2.CheckedChanged
        lblStatus2.Text = If(nxCheckCombo2.Checked, "Estado: Habilitado ✓", "Estado: Deshabilitado")
        lblStatus2.ForeColor = If(nxCheckCombo2.Checked, Color.FromArgb(40, 167, 69), Color.FromArgb(108, 117, 125))
    End Sub

    Private Sub NxCheckCombo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nxCheckCombo2.SelectedIndexChanged
        lblSelection2.Text = If(nxCheckCombo2.SelectedItem IsNot Nothing, $"Selección: {nxCheckCombo2.SelectedItem.Text}", "Selección: (ninguna)")
    End Sub

    Private Sub NxCheckCombo3_CheckedChanged(sender As Object, e As EventArgs) Handles nxCheckCombo3.CheckedChanged
        lblStatus3.Text = If(nxCheckCombo3.Checked, "Estado: Habilitado ✓", "Estado: Deshabilitado")
        lblStatus3.ForeColor = If(nxCheckCombo3.Checked, Color.FromArgb(40, 167, 69), Color.FromArgb(108, 117, 125))
    End Sub

    Private Sub NxCheckCombo3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nxCheckCombo3.SelectedIndexChanged
        If nxCheckCombo3.SelectedItem IsNot Nothing Then
            lblSelection3.Text = $"Selección: {nxCheckCombo3.SelectedItem.Text} (Grupo: {nxCheckCombo3.SelectedItem.Group})"
        Else
            lblSelection3.Text = "Selección: (ninguna)"
        End If
    End Sub

    Private Sub NxCheckCombo4_CheckedChanged(sender As Object, e As EventArgs) Handles nxCheckCombo4.CheckedChanged
        lblStatus4.Text = If(nxCheckCombo4.Checked, "Estado: Habilitado ✓", "Estado: Deshabilitado")
        lblStatus4.ForeColor = If(nxCheckCombo4.Checked, Color.FromArgb(40, 167, 69), Color.FromArgb(108, 117, 125))
    End Sub

    Private Sub NxCheckCombo4_SelectedItemsChanged(sender As Object, e As EventArgs) Handles nxCheckCombo4.SelectedItemsChanged
        If nxCheckCombo4.SelectedItems.Count > 0 Then
            Dim texts = String.Join(", ", nxCheckCombo4.SelectedItems.Select(Function(i) i.Text))
            lblSelection4.Text = $"Selección: {texts} ({nxCheckCombo4.SelectedItems.Count} items)"
        Else
            lblSelection4.Text = "Selección: (ninguna)"
        End If
    End Sub

#End Region

#Region "Eventos NXListBox Simple"

    Private Sub NxListSimple_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nxListSimple.SelectedIndexChanged
        If nxListSimple.SelectedItem IsNot Nothing Then
            lblListSelection.Text = $"✅ Selección:{Environment.NewLine}{Environment.NewLine}" &
                                   $"Texto: {nxListSimple.SelectedItem.Text}{Environment.NewLine}" &
                                   $"Valor: {nxListSimple.SelectedItem.Value}{Environment.NewLine}" &
                                   $"Índice: {nxListSimple.SelectedIndex}"
        Else
            lblListSelection.Text = "Selección: (ninguna)"
        End If
    End Sub

    Private Sub BtnAddListItem_Click(sender As Object, e As EventArgs) Handles btnAddListItem.Click
        Static counter As Integer = 31
        nxListSimple.AddItem($"Item de Lista {counter:D2}", counter)
        counter += 1
    End Sub

    Private Sub BtnRemoveListItem_Click(sender As Object, e As EventArgs) Handles btnRemoveListItem.Click
        If nxListSimple.SelectedIndex >= 0 Then nxListSimple.RemoveItem(nxListSimple.SelectedIndex)
    End Sub

#End Region

#Region "Eventos NXListBox Checkboxes"

    Private Sub NxListCheckboxes_ItemCheck(sender As Object, e As NXListBox.ItemCheckEventArgs) Handles nxListCheckboxes.ItemCheck
        BeginInvoke(New Action(AddressOf UpdateCheckedListCount))
    End Sub

    Private Sub UpdateCheckedListCount()
        Dim checkedItems = nxListCheckboxes.Items.Where(Function(i) i.IsChecked).ToList()
        lblCheckedListCount.Text = $"✅ Items marcados: {checkedItems.Count}{Environment.NewLine}{Environment.NewLine}"
        If checkedItems.Count > 0 Then
            lblCheckedListCount.Text &= "Lista de tareas marcadas:" & Environment.NewLine
            For Each item In checkedItems.Take(8)
                lblCheckedListCount.Text &= $"• {item.Text}{Environment.NewLine}"
            Next
            If checkedItems.Count > 8 Then lblCheckedListCount.Text &= $"... y {checkedItems.Count - 8} más"
        End If
    End Sub

    Private Sub BtnCheckAllList_Click(sender As Object, e As EventArgs) Handles btnCheckAllList.Click
        For Each item In nxListCheckboxes.Items
            item.IsChecked = True
        Next
        UpdateCheckedListCount()
        nxListCheckboxes.Invalidate()
    End Sub

    Private Sub BtnUncheckAllList_Click(sender As Object, e As EventArgs) Handles btnUncheckAllList.Click
        For Each item In nxListCheckboxes.Items
            item.IsChecked = False
        Next
        UpdateCheckedListCount()
        nxListCheckboxes.Invalidate()
    End Sub

#End Region

#Region "Eventos NXListBox Iconos"

    Private Sub NxListIcons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nxListIcons.SelectedIndexChanged
        If nxListIcons.SelectedItem IsNot Nothing Then
            Dim item = nxListIcons.SelectedItem
            lblContactListInfo.Text = $"📇 Información del Contacto{Environment.NewLine}{Environment.NewLine}👤 Nombre:{Environment.NewLine}{item.Text}{Environment.NewLine}{Environment.NewLine}"
            If item.SubItems.Count >= 2 Then
                lblContactListInfo.Text &= $"📧 Email:{Environment.NewLine}{item.SubItems(0)}{Environment.NewLine}{Environment.NewLine}📱 Teléfono:{Environment.NewLine}{item.SubItems(1)}"
            End If
        Else
            lblContactListInfo.Text = "📇 Información del Contacto" & Environment.NewLine & Environment.NewLine & "Selecciona un contacto."
        End If
    End Sub

    Private Sub BtnAddContactList_Click(sender As Object, e As EventArgs) Handles btnAddContactList.Click
        Dim names() As String = {"Diego Morales", "Sofía Torres", "Andrés Castro"}
        Dim emails() As String = {"diego@mail.com", "sofia@mail.com", "andres@mail.com"}
        Dim phones() As String = {"+593-94-111-2222", "+593-93-222-3333", "+593-92-333-4444"}

        Dim rand As New Random()
        Dim idx = rand.Next(names.Length)

        Dim icon = CreateContactIcon(names(idx).Substring(0, 1))
        Dim item As New NXListBox.NXListBoxItem(names(idx), Nothing, icon)
        item.SubItems.Add(emails(idx))
        item.SubItems.Add(phones(idx))
        nxListIcons.AddItem(item)
    End Sub

#End Region

End Class