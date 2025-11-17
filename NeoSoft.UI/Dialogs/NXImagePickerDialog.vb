Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Reflection

#Region "Image Picker Dialog"

''' <summary>
''' Diálogo personalizado para seleccionar imágenes - Compatible con el diseñador de Visual Studio
''' </summary>
Public Class NXImagePickerDialog
    Inherits Form

#Region "Propiedades Públicas"

    Private _selectedImage As Image = Nothing
    Private _selectedImagePath As String = ""
    Private _selectedImageSource As ImageSource = ImageSource.None
    Private _resourceName As String = ""

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

    ''' <summary>
    ''' Obtiene el nombre del recurso seleccionado
    ''' </summary>
    <Browsable(False)>
    Public ReadOnly Property ResourceName As String
        Get
            Return _resourceName
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
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        ' Tab Image Picker - Recurso Local
        AddHandler btnImportLocal.Click, AddressOf BtnImportLocal_Click
        AddHandler btnClearLocal.Click, AddressOf BtnClearLocal_Click
        AddHandler lstLocalResources.SelectedIndexChanged, AddressOf LstLocalResources_SelectedIndexChanged
        AddHandler lstLocalResources.DoubleClick, AddressOf LstLocalResources_DoubleClick

        ' Tab Image Picker - Recursos del Proyecto
        AddHandler lstProjectResources.SelectedIndexChanged, AddressOf LstProjectResources_SelectedIndexChanged
        AddHandler lstProjectResources.DoubleClick, AddressOf LstProjectResources_DoubleClick

        ' Radio buttons
        AddHandler rbLocalResource.CheckedChanged, AddressOf ResourceRadioButton_CheckedChanged
        AddHandler rbProjectResource.CheckedChanged, AddressOf ResourceRadioButton_CheckedChanged

        ' Raster Images Tab
        AddHandler txtRasterSearch.Enter, AddressOf TxtRasterSearch_Enter
        AddHandler txtRasterSearch.Leave, AddressOf TxtRasterSearch_Leave
        AddHandler txtRasterSearch.TextChanged, AddressOf TxtRasterSearch_TextChanged
    End Sub

#End Region

#Region "Inicialización"

    Private Sub NXImagePickerDialog_Load(sender As Object, e As EventArgs)
        ' Tab por defecto: Image Picker
        tabControl.SelectedIndex = 0

        ' Seleccionar por defecto "Recurso Local"
        rbLocalResource.Checked = True
        UpdateResourcePanels()

        ' Cargar recursos del proyecto del usuario
        LoadProjectResources()

        ' Inicializar tabs de iconos predefinidos
        InitializeRasterImagesTab()

        ' Versión
        If lblVersion IsNot Nothing Then
            lblVersion.Text = $"NeoSoft.UI v{Application.ProductVersion}"
        End If
    End Sub

#End Region

#Region "TAB 1: IMAGE PICKER - Recurso Local"

    ''' <summary>
    ''' Botón "Importar" - Funciona exactamente como el diálogo estándar de VB.NET
    ''' </summary>
    Private Sub BtnImportLocal_Click(sender As Object, e As EventArgs)
        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar archivo de imagen"
            ofd.Filter = "Todos los archivos de imagen|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff;*.ico;*.emf;*.wmf|" &
                        "Archivos de mapa de bits (*.bmp)|*.bmp|" &
                        "Archivos JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" &
                        "Archivos PNG (*.png)|*.png|" &
                        "Archivos GIF (*.gif)|*.gif|" &
                        "Archivos TIFF (*.tif;*.tiff)|*.tif;*.tiff|" &
                        "Archivos de icono (*.ico)|*.ico|" &
                        "Archivos de metarchivo (*.emf;*.wmf)|*.emf;*.wmf|" &
                        "Todos los archivos (*.*)|*.*"
            ofd.FilterIndex = 1
            ofd.Multiselect = True
            ofd.RestoreDirectory = True

            If ofd.ShowDialog() = DialogResult.OK Then
                ' Agregar archivos a la lista
                For Each filePath As String In ofd.FileNames
                    If Not lstLocalResources.Items.Contains(filePath) Then
                        lstLocalResources.Items.Add(filePath)
                    End If
                Next

                ' Seleccionar el primero automáticamente
                If ofd.FileNames.Length > 0 Then
                    lstLocalResources.SelectedItem = ofd.FileNames(0)
                End If
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Al seleccionar un archivo de la lista, cargar la imagen
    ''' </summary>
    Private Sub LstLocalResources_SelectedIndexChanged(sender As Object, e As EventArgs)
        If lstLocalResources.SelectedIndex >= 0 Then
            Dim filePath As String = lstLocalResources.SelectedItem.ToString()
            LoadImageFromFile(filePath)
        End If
    End Sub

    ''' <summary>
    ''' Doble clic en la lista = Seleccionar y cerrar
    ''' </summary>
    Private Sub LstLocalResources_DoubleClick(sender As Object, e As EventArgs)
        If lstLocalResources.SelectedIndex >= 0 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Carga una imagen desde un archivo local
    ''' </summary>
    Private Sub LoadImageFromFile(filePath As String)
        Try
            If File.Exists(filePath) Then
                ' Limpiar imagen anterior
                If picPreview.Image IsNot Nothing Then
                    Dim oldImg As Image = picPreview.Image
                    picPreview.Image = Nothing
                    If oldImg IsNot _selectedImage AndAlso _selectedImageSource <> ImageSource.ProjectResource Then
                        Try
                            oldImg.Dispose()
                        Catch
                        End Try
                    End If
                End If

                ' Cargar imagen usando FileStream (no bloquea el archivo)
                Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim img As Image = Image.FromStream(fs)

                    ' Mostrar en preview
                    picPreview.Image = img

                    ' Guardar selección
                    _selectedImage = img
                    _selectedImagePath = filePath
                    _selectedImageSource = ImageSource.LocalResource
                    _resourceName = ""

                    ' Actualizar información
                    UpdateImageInfo(img)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al cargar la imagen:{vbCrLf}{ex.Message}",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            picPreview.Image = Nothing
            UpdateImageInfo(Nothing)
        End Try
    End Sub

    ''' <summary>
    ''' Botón "Clear" - Limpiar lista
    ''' </summary>
    Private Sub BtnClearLocal_Click(sender As Object, e As EventArgs)
        lstLocalResources.Items.Clear()
        picPreview.Image = Nothing
        _selectedImage = Nothing
        _selectedImagePath = ""
        UpdateImageInfo(Nothing)
    End Sub

#End Region

#Region "TAB 1: IMAGE PICKER - Recursos del Proyecto"

    ''' <summary>
    ''' Carga los recursos del proyecto del usuario (My.Resources)
    ''' </summary>
    Private Sub LoadProjectResources()
        Try
            lstProjectResources.Items.Clear()

            ' Obtener el ensamblado de la aplicación del usuario
            Dim assembly As Assembly = Assembly.GetEntryAssembly()
            If assembly Is Nothing Then
                assembly = Assembly.GetCallingAssembly()
            End If
            If assembly Is Nothing Then
                assembly = Assembly.GetExecutingAssembly()
            End If

            ' Buscar el tipo "Resources" en My.Resources del proyecto del usuario
            Dim resourceType As Type = Nothing
            For Each type As Type In assembly.GetTypes()
                If type.Name = "Resources" AndAlso
                   type.Namespace IsNot Nothing AndAlso
                   type.Namespace.Contains(".My.Resources") Then
                    resourceType = type
                    Exit For
                End If
            Next

            If resourceType IsNot Nothing Then
                ' Obtener propiedades estáticas (recursos)
                Dim properties = resourceType.GetProperties(BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic)

                Dim imageNames As New List(Of String)

                ' Filtrar solo imágenes
                For Each prop In properties
                    If prop.PropertyType Is GetType(Image) OrElse
                       prop.PropertyType Is GetType(Bitmap) OrElse
                       prop.PropertyType Is GetType(Icon) Then
                        imageNames.Add(prop.Name)
                    End If
                Next

                ' Ordenar alfabéticamente
                imageNames.Sort()

                ' Agregar a la lista
                For Each Names In imageNames
                    lstProjectResources.Items.Add(Names)
                Next
            End If

            ' Si no hay recursos
            If lstProjectResources.Items.Count = 0 Then
                lstProjectResources.Items.Add("(No hay recursos de imagen en el proyecto)")
            End If

        Catch ex As Exception
            lstProjectResources.Items.Clear()
            lstProjectResources.Items.Add("(Error al cargar recursos)")
        End Try
    End Sub

    ''' <summary>
    ''' Al seleccionar un recurso del proyecto
    ''' </summary>
    Private Sub LstProjectResources_SelectedIndexChanged(sender As Object, e As EventArgs)
        If lstProjectResources.SelectedIndex >= 0 Then
            Dim resourceName As String = lstProjectResources.SelectedItem.ToString()

            ' Verificar que no sea un mensaje
            If resourceName.StartsWith("(") Then
                Return
            End If

            LoadImageFromProjectResource(resourceName)
        End If
    End Sub

    ''' <summary>
    ''' Doble clic = Seleccionar y cerrar
    ''' </summary>
    Private Sub LstProjectResources_DoubleClick(sender As Object, e As EventArgs)
        If lstProjectResources.SelectedIndex >= 0 Then
            Dim resourceName As String = lstProjectResources.SelectedItem.ToString()
            If Not resourceName.StartsWith("(") Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Carga una imagen desde My.Resources del proyecto del usuario
    ''' </summary>
    Private Sub LoadImageFromProjectResource(resourceName As String)
        Try
            Dim assembly As Assembly = Assembly.GetEntryAssembly()
            If assembly Is Nothing Then assembly = Assembly.GetCallingAssembly()
            If assembly Is Nothing Then assembly = Assembly.GetExecutingAssembly()

            ' Buscar el tipo Resources
            Dim resourceType As Type = Nothing
            For Each type As Type In assembly.GetTypes()
                If type.Name = "Resources" AndAlso
                   type.Namespace IsNot Nothing AndAlso
                   type.Namespace.Contains(".My.Resources") Then
                    resourceType = type
                    Exit For
                End If
            Next

            If resourceType IsNot Nothing Then
                ' Obtener la propiedad del recurso
                Dim prop = resourceType.GetProperty(resourceName,
                                                   BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic)

                If prop IsNot Nothing Then
                    Dim value = prop.GetValue(Nothing, Nothing)
                    Dim img As Image = Nothing

                    ' Convertir según el tipo
                    If TypeOf value Is Icon Then
                        img = DirectCast(value, Icon).ToBitmap()
                    ElseIf TypeOf value Is Image Then
                        img = DirectCast(value, Image)
                    End If

                    If img IsNot Nothing Then
                        ' Limpiar imagen anterior
                        If picPreview.Image IsNot Nothing Then
                            Dim oldImg As Image = picPreview.Image
                            picPreview.Image = Nothing
                            If oldImg IsNot _selectedImage OrElse _selectedImageSource <> ImageSource.ProjectResource Then
                                Try
                                    oldImg.Dispose()
                                Catch
                                End Try
                            End If
                        End If

                        ' Mostrar preview
                        picPreview.Image = img

                        ' Guardar selección
                        _selectedImage = img
                        _resourceName = resourceName
                        _selectedImagePath = $"My.Resources.{resourceName}"
                        _selectedImageSource = ImageSource.ProjectResource

                        ' Actualizar info
                        UpdateImageInfo(img)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al cargar el recurso:{vbCrLf}{ex.Message}",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            picPreview.Image = Nothing
            UpdateImageInfo(Nothing)
        End Try
    End Sub

#End Region

#Region "TAB 2: RASTER IMAGES - Iconos Predefinidos"

    ''' <summary>
    ''' Inicializar el tab de Raster Images con iconos predefinidos
    ''' </summary>
    Private Sub InitializeRasterImagesTab()
        ' Configurar búsqueda con placeholder
        If txtRasterSearch IsNot Nothing Then
            txtRasterSearch.ForeColor = Color.Gray
            txtRasterSearch.Text = "Enter text to search..."
        End If

        ' Inicializar categorías
        If chkListCategories IsNot Nothing AndAlso chkListCategories.Items.Count = 0 Then
            chkListCategories.Items.Clear()
            chkListCategories.Items.AddRange(New String() {
                "Select All",
                "Actions",
                "Alignment",
                "Arrows",
                "Business",
                "Communication",
                "Data",
                "Edit",
                "File",
                "Interface",
                "Media",
                "Navigation",
                "Office"
            })

            ' Suscribir eventos
            AddHandler chkListCategories.ItemCheck, AddressOf ChkListCategories_ItemCheck
        End If

        ' Inicializar tamaños
        If chkListSize IsNot Nothing AndAlso chkListSize.Items.Count = 0 Then
            chkListSize.Items.Clear()
            chkListSize.Items.AddRange(New String() {"16x16", "32x32", "48x48"})

            ' Suscribir eventos
            AddHandler chkListSize.ItemCheck, AddressOf ChkListSize_ItemCheck
        End If

        ' Cargar iconos predefinidos por primera vez
        LoadPredefinedRasterIcons()
    End Sub

    Private Sub TxtRasterSearch_Enter(sender As Object, e As EventArgs)
        If txtRasterSearch.Text = "Enter text to search..." Then
            txtRasterSearch.Text = ""
            txtRasterSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtRasterSearch_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtRasterSearch.Text) Then
            txtRasterSearch.Text = "Enter text to search..."
            txtRasterSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TxtRasterSearch_TextChanged(sender As Object, e As EventArgs)
        If txtRasterSearch.ForeColor = Color.Black Then
            FilterRasterIcons()
        End If
    End Sub

    Private Sub ChkListCategories_ItemCheck(sender As Object, e As ItemCheckEventArgs)
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

    ''' <summary>
    ''' Carga los iconos predefinidos embebidos en NeoSoft.UI
    ''' </summary>
    Private Sub LoadPredefinedRasterIcons()
        If flowRasterIcons Is Nothing Then Return

        flowRasterIcons.Controls.Clear()

        ' TODO: Aquí cargarías tus iconos predefinidos de Resources de NeoSoft.UI
        ' Por ahora, agregar iconos de ejemplo

        ' Ejemplo de cómo agregar iconos predefinidos:
        ' Dim iconNames As String() = {"Home", "Save", "Open", "Close", "Settings", "User", "Search", "Edit"}
        ' For Each iconName In iconNames
        '     Dim pb As New PictureBox()
        '     pb.Size = New Size(48, 48)
        '     pb.SizeMode = PictureBoxSizeMode.CenterImage
        '     pb.Image = My.Resources.ResourceManager.GetObject(iconName) ' Tus iconos embebidos
        '     pb.BorderStyle = BorderStyle.FixedSingle
        '     pb.Cursor = Cursors.Hand
        '     pb.Tag = iconName
        '     AddHandler pb.Click, AddressOf RasterIcon_Click
        '     flowRasterIcons.Controls.Add(pb)
        ' Next

        ' Por ahora, mensaje placeholder
        Dim lblPlaceholder As New Label()
        lblPlaceholder.Text = "Los iconos predefinidos se cargarán aquí" & vbCrLf &
                             "desde los recursos embebidos de NeoSoft.UI"
        lblPlaceholder.AutoSize = True
        lblPlaceholder.ForeColor = Color.Gray
        flowRasterIcons.Controls.Add(lblPlaceholder)
    End Sub

    Private Sub FilterRasterIcons()
        ' TODO: Implementar filtrado de iconos según búsqueda, categoría y tamaño
        ' Por ahora, recargar todos
        LoadPredefinedRasterIcons()
    End Sub

    Private Sub RasterIcon_Click(sender As Object, e As EventArgs)
        Dim pb As PictureBox = TryCast(sender, PictureBox)
        If pb IsNot Nothing AndAlso pb.Image IsNot Nothing Then
            ' Seleccionar este icono
            _selectedImage = pb.Image
            _selectedImagePath = $"NeoSoft.UI.Resources.{pb.Tag}"
            _selectedImageSource = ImageSource.RasterImage
            _resourceName = pb.Tag.ToString()

            ' Mostrar en preview
            picPreview.Image = pb.Image
            UpdateImageInfo(pb.Image)

            ' Opcional: Cerrar automáticamente
            ' Me.DialogResult = DialogResult.OK
            ' Me.Close()
        End If
    End Sub

#End Region

#Region "Actualización de Interfaz"

    Private Sub ResourceRadioButton_CheckedChanged(sender As Object, e As EventArgs)
        UpdateResourcePanels()
    End Sub

    Private Sub UpdateResourcePanels()
        If panelLocalResource IsNot Nothing Then
            panelLocalResource.Enabled = rbLocalResource.Checked
        End If

        If panelProjectResource IsNot Nothing Then
            panelProjectResource.Enabled = rbProjectResource.Checked
        End If
    End Sub

    Private Sub UpdateImageInfo(img As Image)
        If lblImageInfo Is Nothing Then Return

        If img IsNot Nothing Then
            Try
                Dim sizeInBytes As Long = 0
                Try
                    Using ms As New MemoryStream()
                        img.Save(ms, img.RawFormat)
                        sizeInBytes = ms.Length
                    End Using
                Catch
                End Try

                Dim sizeText As String = FormatFileSize(sizeInBytes)
                Dim formatName As String = GetImageFormatName(img.RawFormat)

                lblImageInfo.Text = $"{img.Width} x {img.Height} px | {formatName} | {sizeText}"
            Catch
                lblImageInfo.Text = $"{img.Width} x {img.Height} px"
            End Try
        Else
            lblImageInfo.Text = "Sin imagen seleccionada"
        End If
    End Sub

    Private Function GetImageFormatName(format As ImageFormat) As String
        If format.Equals(ImageFormat.Bmp) Then Return "BMP"
        If format.Equals(ImageFormat.Jpeg) Then Return "JPEG"
        If format.Equals(ImageFormat.Png) Then Return "PNG"
        If format.Equals(ImageFormat.Gif) Then Return "GIF"
        If format.Equals(ImageFormat.Tiff) Then Return "TIFF"
        If format.Equals(ImageFormat.Icon) Then Return "ICO"
        Return "Unknown"
    End Function

    Private Function FormatFileSize(bytes As Long) As String
        If bytes < 1024 Then Return $"{bytes} bytes"
        If bytes < 1024 * 1024 Then Return $"{(bytes / 1024.0):F2} KB"
        Return $"{(bytes / (1024.0 * 1024.0)):F2} MB"
    End Function

#End Region

#Region "Botones OK y Cancel"

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        ' Verificar que hay imagen seleccionada
        If _selectedImage Is Nothing Then
            MessageBox.Show("Por favor seleccione una imagen.",
                          "Sin selección",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.None
            Return
        End If

        ' Cerrar con OK
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' Muestra el diálogo con un propietario
    ''' </summary>
    Public Shadows Function ShowDialog(owner As IWin32Window) As DialogResult
        Return MyBase.ShowDialog(owner)
    End Function

    ''' <summary>
    ''' Muestra el diálogo sin propietario
    ''' </summary>
    Public Shadows Function ShowDialog() As DialogResult
        Return MyBase.ShowDialog()
    End Function

    ''' <summary>
    ''' Limpia la selección actual
    ''' </summary>
    Public Sub ClearSelection()
        _selectedImage = Nothing
        _selectedImagePath = ""
        _selectedImageSource = ImageSource.None
        _resourceName = ""

        If picPreview IsNot Nothing Then
            picPreview.Image = Nothing
        End If

        If lstLocalResources IsNot Nothing Then
            lstLocalResources.ClearSelected()
        End If

        If lstProjectResources IsNot Nothing Then
            lstProjectResources.ClearSelected()
        End If

        UpdateImageInfo(Nothing)
    End Sub

    Private Sub btnImportProject_Click(sender As Object, e As EventArgs) Handles btnImportProject.Click
        Try
            ' Intentar abrir la ventana de recursos del proyecto usando DTE
            ' Esto requiere referencias adicionales (EnvDTE)

            ' Alternativa simple: Solo refrescar y mostrar instrucciones
            LoadProjectResources()

            Dim result = MessageBox.Show(
                "¿Desea abrir la ventana de recursos del proyecto?" & vbCrLf & vbCrLf &
                "Haga clic en Sí para ver las instrucciones," & vbCrLf &
                "o en No para solo actualizar la lista de recursos.",
                "Importar Recursos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                MessageBox.Show(
                    "Para agregar imágenes a los recursos del proyecto:" & vbCrLf & vbCrLf &
                    "1. En el Explorador de soluciones, doble clic en 'My Project'" & vbCrLf &
                    "2. Ir a la pestaña 'Recursos'" & vbCrLf &
                    "3. En el dropdown, seleccionar 'Imágenes'" & vbCrLf &
                    "4. Clic en 'Agregar recurso' → 'Agregar archivo existente...'" & vbCrLf &
                    "5. Seleccionar la(s) imagen(es)" & vbCrLf &
                    "6. Guardar el proyecto (Ctrl+S)" & vbCrLf & vbCrLf &
                    "Después cierre y vuelva a abrir este diálogo para ver los nuevos recursos.",
                    "Cómo Importar Recursos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

#End Region

End Class

#End Region
