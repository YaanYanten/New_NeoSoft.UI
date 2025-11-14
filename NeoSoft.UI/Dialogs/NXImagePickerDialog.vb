Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Namespace Dialogs

    ''' <summary>
    ''' Diálogo personalizado para seleccionar imágenes de múltiples fuentes.
    ''' Soporta recursos locales, recursos del proyecto, imágenes raster, vectoriales e iconos de fuentes.
    ''' </summary>
    ''' <remarks>
    ''' NXImagePickerDialog proporciona una interfaz completa para la selección de imágenes
    ''' con vista previa, filtros y múltiples opciones de origen.
    ''' </remarks>
    Public Class NXImagePickerDialog

#Region "Propiedades Públicas"

        Private _selectedImage As Image = Nothing
        Private _selectedImagePath As String = ""
        Private _selectedImageSource As ImageSource = ImageSource.None

        ''' <summary>
        ''' Obtiene la imagen seleccionada por el usuario
        ''' </summary>
        <Browsable(False)>
        Public ReadOnly Property SelectedImage As Image
            Get
                Return _selectedImage
            End Get
        End Property

        ''' <summary>
        ''' Obtiene la ruta del archivo de imagen seleccionado
        ''' </summary>
        <Browsable(False)>
        Public ReadOnly Property SelectedImagePath As String
            Get
                Return _selectedImagePath
            End Get
        End Property

        ''' <summary>
        ''' Obtiene el origen de la imagen seleccionada
        ''' </summary>
        <Browsable(False)>
        Public ReadOnly Property SelectedImageSource As ImageSource
            Get
                Return _selectedImageSource
            End Get
        End Property

#End Region

#Region "Enumeraciones"

        ''' <summary>
        ''' Define los posibles orígenes de imagen
        ''' </summary>
        Public Enum ImageSource
            ''' <summary>Ninguna imagen seleccionada</summary>
            None
            ''' <summary>Recurso local del formulario</summary>
            LocalResource
            ''' <summary>Recurso del proyecto</summary>
            ProjectResource
            ''' <summary>Imagen raster (PNG, JPG, etc.)</summary>
            RasterImage
            ''' <summary>Imagen vectorial (SVG, etc.)</summary>
            VectorImage
            ''' <summary>Icono de fuente</summary>
            FontIcon
        End Enum

#End Region

#Region "Constructor"

        Public Sub New()
            InitializeComponent()

            ' Configurar eventos
            AddHandler Me.Load, AddressOf NXImagePickerDialog_Load
            AddHandler btnOK.Click, AddressOf BtnOK_Click
            AddHandler btnImportLocal.Click, AddressOf BtnImportLocal_Click
            AddHandler btnClearLocal.Click, AddressOf BtnClearLocal_Click
            AddHandler btnImportProject.Click, AddressOf BtnImportProject_Click
            AddHandler lstLocalResources.SelectedIndexChanged, AddressOf LstLocalResources_SelectedIndexChanged
            AddHandler rbLocalResource.CheckedChanged, AddressOf ResourceRadioButton_CheckedChanged
            AddHandler rbProjectResource.CheckedChanged, AddressOf ResourceRadioButton_CheckedChanged
            AddHandler txtRasterSearch.Enter, AddressOf TxtRasterSearch_Enter
            AddHandler txtRasterSearch.Leave, AddressOf TxtRasterSearch_Leave
            AddHandler txtRasterSearch.TextChanged, AddressOf TxtRasterSearch_TextChanged
        End Sub

#End Region

#Region "Métodos Privados - Inicialización"

        Private Sub NXImagePickerDialog_Load(sender As Object, e As EventArgs)
            ' Inicializar componentes
            InitializeRasterImagesTab()
            UpdateResourcePanels()

            ' Establecer versión
            lblVersion.Text = $"Version {Application.ProductVersion}"
        End Sub

        Private Sub InitializeRasterImagesTab()
            ' Configurar búsqueda con placeholder
            txtRasterSearch.ForeColor = Color.Gray
            txtRasterSearch.Text = "Enter text to search..."

            ' Inicializar categorías
            If chkListCategories.Items.Count = 0 Then
                chkListCategories.Items.Clear()
                chkListCategories.Items.AddRange(New String() {
                    "Select All",
                    "Actions",
                    "Alignment",
                    "Analysis",
                    "Appearance",
                    "Arrange",
                    "Arrows",
                    "Business Objects",
                    "Chart",
                    "Communication",
                    "Data",
                    "Edit",
                    "File",
                    "Format",
                    "Interface",
                    "Media",
                    "Navigation",
                    "Office",
                    "Security"
                })
            End If

            ' Inicializar tamaños
            If chkListSize.Items.Count = 0 Then
                chkListSize.Items.Clear()
                chkListSize.Items.AddRange(New String() {"16x16", "32x32", "48x48", "64x64"})
            End If

            ' Suscribir eventos de filtros
            AddHandler chkListCategories.ItemCheck, AddressOf ChkListCategories_ItemCheck
            AddHandler chkListSize.ItemCheck, AddressOf ChkListSize_ItemCheck
        End Sub

#End Region

#Region "Métodos Privados - Recursos Locales"

        Private Sub BtnImportLocal_Click(sender As Object, e As EventArgs)
            Using ofd As New OpenFileDialog()
                ofd.Title = "Select Image File"
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|All Files|*.*"
                ofd.Multiselect = True

                If ofd.ShowDialog() = DialogResult.OK Then
                    For Each filePath As String In ofd.FileNames
                        Dim fileName As String = Path.GetFileName(filePath)
                        If Not lstLocalResources.Items.Contains(fileName) Then
                            lstLocalResources.Items.Add(filePath)
                        End If
                    Next

                    ' Seleccionar el primer archivo importado
                    If lstLocalResources.Items.Count > 0 Then
                        lstLocalResources.SelectedIndex = 0
                    End If
                End If
            End Using
        End Sub

        Private Sub BtnClearLocal_Click(sender As Object, e As EventArgs)
            lstLocalResources.Items.Clear()
            picPreview.Image = Nothing
            _selectedImage = Nothing
            _selectedImagePath = ""
        End Sub

        Private Sub LstLocalResources_SelectedIndexChanged(sender As Object, e As EventArgs)
            If lstLocalResources.SelectedIndex >= 0 Then
                Try
                    Dim filePath As String = lstLocalResources.SelectedItem.ToString()
                    If File.Exists(filePath) Then
                        ' Cargar y mostrar la imagen
                        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
                            picPreview.Image = Image.FromStream(fs)
                        End Using
                        _selectedImagePath = filePath
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

#End Region

#Region "Métodos Privados - Recursos del Proyecto"

        Private Sub BtnImportProject_Click(sender As Object, e As EventArgs)
            MessageBox.Show("Import to project resources functionality." & vbCrLf &
                          "This will add the image to My.Resources in a real implementation.",
                          "Project Resources", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub ResourceRadioButton_CheckedChanged(sender As Object, e As EventArgs)
            UpdateResourcePanels()
        End Sub

        Private Sub UpdateResourcePanels()
            panelLocalResource.Enabled = rbLocalResource.Checked
            panelProjectResource.Enabled = rbProjectResource.Checked
        End Sub

#End Region

#Region "Métodos Privados - Búsqueda y Filtros de Raster"

        Private Sub TxtRasterSearch_Enter(sender As Object, e As EventArgs)
            ' Limpiar placeholder al obtener foco
            If txtRasterSearch.Text = "Enter text to search..." Then
                txtRasterSearch.Text = ""
                txtRasterSearch.ForeColor = Color.Black
            End If
        End Sub

        Private Sub TxtRasterSearch_Leave(sender As Object, e As EventArgs)
            ' Restaurar placeholder si está vacío
            If String.IsNullOrWhiteSpace(txtRasterSearch.Text) Then
                txtRasterSearch.Text = "Enter text to search..."
                txtRasterSearch.ForeColor = Color.Gray
            End If
        End Sub

        Private Sub TxtRasterSearch_TextChanged(sender As Object, e As EventArgs)
            ' Filtrar iconos raster según búsqueda
            If txtRasterSearch.ForeColor = Color.Black Then
                FilterRasterIcons()
            End If
        End Sub

        Private Sub ChkListCategories_ItemCheck(sender As Object, e As ItemCheckEventArgs)
            ' Manejar "Select All"
            If e.Index = 0 Then ' "Select All"
                BeginInvoke(New Action(Sub()
                                           Dim checkAll As Boolean = (e.NewValue = CheckState.Checked)
                                           For i As Integer = 1 To chkListCategories.Items.Count - 1
                                               chkListCategories.SetItemChecked(i, checkAll)
                                           Next
                                           FilterRasterIcons()
                                       End Sub))
            Else
                BeginInvoke(New Action(AddressOf FilterRasterIcons))
            End If
        End Sub

        Private Sub ChkListSize_ItemCheck(sender As Object, e As ItemCheckEventArgs)
            BeginInvoke(New Action(AddressOf FilterRasterIcons))
        End Sub

        Private Sub FilterRasterIcons()
            ' Aquí implementarías la lógica de filtrado de iconos
            ' Por ahora, es un placeholder para la funcionalidad futura
            flowRasterIcons.Controls.Clear()

            ' Ejemplo: Agregar algunos iconos de muestra
            Dim selectedCategories As New List(Of String)
            For i As Integer = 1 To chkListCategories.Items.Count - 1
                If chkListCategories.GetItemChecked(i) Then
                    selectedCategories.Add(chkListCategories.Items(i).ToString())
                End If
            Next

            Dim selectedSizes As New List(Of String)
            For i As Integer = 0 To chkListSize.Items.Count - 1
                If chkListSize.GetItemChecked(i) Then
                    selectedSizes.Add(chkListSize.Items(i).ToString())
                End If
            Next

            ' TODO: Cargar y filtrar iconos reales según categorías y tamaños seleccionados
        End Sub

#End Region

#Region "Métodos Privados - Botones de Acción"

        Private Sub BtnOK_Click(sender As Object, e As EventArgs)
            ' Determinar qué imagen está seleccionada
            Select Case TabControl.SelectedIndex
                Case 0 ' Image Picker tab
                    If rbLocalResource.Checked Then
                        If lstLocalResources.SelectedIndex >= 0 Then
                            _selectedImageSource = ImageSource.LocalResource
                            _selectedImage = picPreview.Image
                            Me.DialogResult = DialogResult.OK
                        Else
                            MessageBox.Show("Please select an image from the local resources.",
                                          "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.DialogResult = DialogResult.None
                        End If
                    ElseIf rbProjectResource.Checked Then
                        _selectedImageSource = ImageSource.ProjectResource
                        ' TODO: Obtener imagen del proyecto
                        MessageBox.Show("Project resource selection not yet implemented.",
                                      "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.None
                    End If

                Case 1 ' Raster Images tab
                    _selectedImageSource = ImageSource.RasterImage
                    ' TODO: Obtener imagen seleccionada de flowRasterIcons
                    MessageBox.Show("Raster image selection not yet implemented.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.None

                Case 2 ' Vector Images tab
                    _selectedImageSource = ImageSource.VectorImage
                    MessageBox.Show("Vector image selection not yet implemented.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.None

                Case 3 ' Font Icons tab
                    _selectedImageSource = ImageSource.FontIcon
                    MessageBox.Show("Font icon selection not yet implemented.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.None
            End Select
        End Sub

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Muestra el diálogo y retorna el resultado
        ''' </summary>
        Public Shadows Function ShowDialog(owner As IWin32Window) As DialogResult
            Return MyBase.ShowDialog(owner)
        End Function

        ''' <summary>
        ''' Limpia la selección actual
        ''' </summary>
        Public Sub ClearSelection()
            _selectedImage = Nothing
            _selectedImagePath = ""
            _selectedImageSource = ImageSource.None
            picPreview.Image = Nothing
            lstLocalResources.ClearSelected()
        End Sub

#End Region

#Region "Métodos Protegidos"

        Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
            ' Limpiar recursos de imágenes si se cancela
            If Me.DialogResult = DialogResult.Cancel Then
                If picPreview.Image IsNot Nothing Then
                    ' No limpiar la imagen de preview aquí, podría estar en uso
                    picPreview.Image = Nothing
                End If
            End If

            MyBase.OnFormClosing(e)
        End Sub

#End Region

    End Class

End Namespace
