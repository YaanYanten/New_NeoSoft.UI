Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Reflection
Imports System.Resources
Imports System.Collections
Imports System.Xml
Imports System.Linq
Imports NeoSoft.UI.Common
Imports NeoSoft.UI.Helpers

''' <summary>
''' Diálogo avanzado para selección de imágenes con múltiples fuentes
''' CORREGIDO: Sin bloqueo de controles - Usa configuración no-modal
''' </summary>
Partial Public Class NXImagePickerDialog
    Inherits Form

#Region "Enumeraciones"

    Public Enum ImageSource
        None
        LocalResource
        ProjectResource
        RasterImage
        VectorImage
        FontIcon
    End Enum

#End Region

#Region "Propiedades Públicas"

    Private _selectedImage As Image = Nothing
    Private _selectedImagePath As String = ""
    Private _selectedImageSource As ImageSource = ImageSource.None
    Private _resourceName As String = ""
    Private _designerContext As ComponentModel.ITypeDescriptorContext = Nothing

    Public ReadOnly Property SelectedImage As Image
        Get
            Return _selectedImage
        End Get
    End Property

    Public ReadOnly Property SelectedImagePath As String
        Get
            Return _selectedImagePath
        End Get
    End Property

    Public ReadOnly Property SelectedImageSource As ImageSource
        Get
            Return _selectedImageSource
        End Get
    End Property

    Public ReadOnly Property ResourceName As String
        Get
            Return _resourceName
        End Get
    End Property

    Public Sub SetDesignerContext(context As ComponentModel.ITypeDescriptorContext)
        _designerContext = context
    End Sub

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
        InitializeDialog()
    End Sub

#End Region

#Region "Inicialización"

    Private Sub InitializeDialog()
        ' Configuración para evitar bloqueo modal
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.MinimumSize = New Size(700, 500)

        ' Tab inicial
        If tabControl IsNot Nothing Then
            tabControl.SelectedIndex = 0
        End If

        ' Radio button inicial
        If rbLocalResource IsNot Nothing Then
            rbLocalResource.Checked = True
        End If

        ' Preview
        If picPreview IsNot Nothing Then
            picPreview.SizeMode = PictureBoxSizeMode.Zoom
            picPreview.BackColor = Color.FromArgb(245, 245, 245)
        End If

        ' Versión
        If lblVersion IsNot Nothing Then
            lblVersion.Text = "NeoSoft.UI v1.0 - Image Picker Dialog"
        End If
    End Sub

#End Region

#Region "Gestión de Recursos Locales"

    Private Sub BtnImportLocal_Click(sender As Object, e As EventArgs) Handles btnImportLocal.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar Imagen"
            ofd.Filter = "Archivos de Imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|" &
                            "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|ICO|*.ico|" &
                            "Todos los archivos|*.*"
            ofd.FilterIndex = 1
            ofd.Multiselect = False

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim img As Image = Image.FromFile(ofd.FileName)

                    If picPreview.Image IsNot Nothing Then
                        picPreview.Image.Dispose()
                    End If
                    picPreview.Image = New Bitmap(img)

                    _selectedImage = New Bitmap(img)
                    _selectedImagePath = ofd.FileName
                    _selectedImageSource = ImageSource.LocalResource
                    _resourceName = Path.GetFileNameWithoutExtension(ofd.FileName)

                    img.Dispose()
                Catch ex As Exception
                    Debug.WriteLine($"Error al cargar imagen: {ex.Message}")
                End Try
            End If
        End Using
    End Sub

    Private Sub BtnImportProject_Click(sender As Object, e As EventArgs) Handles btnImportProject.Click
        If _designerContext Is Nothing Then Return
        If cboResourceFiles Is Nothing OrElse cboResourceFiles.SelectedIndex < 0 Then Return

        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar Imagen para agregar a Resources"
            ofd.Filter = "Archivos de Imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|" &
                        "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|ICO|*.ico|" &
                        "Todos los archivos|*.*"
            ofd.FilterIndex = 1
            ofd.Multiselect = False

            Dim dialogResult As DialogResult = ofd.ShowDialog()
            If dialogResult <> DialogResult.OK Then Return

            Try
                Dim selectedItem As Object = cboResourceFiles.SelectedItem
                If Not TypeOf selectedItem Is ProjectResourceFinder.ResxFileInfo Then Return

                Dim selectedResxInfo As ProjectResourceFinder.ResxFileInfo =
                    DirectCast(selectedItem, ProjectResourceFinder.ResxFileInfo)

                Dim resxPath As String = selectedResxInfo.FullPath
                If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then Return

                ' Obtener el directorio Resources del proyecto
                Dim resxDirectory As String = Path.GetDirectoryName(resxPath)
                Dim projectResourcesDir As String = Path.Combine(
                    Path.GetDirectoryName(resxDirectory), "Resources")

                ' Crear carpeta Resources si no existe
                If Not Directory.Exists(projectResourcesDir) Then
                    Directory.CreateDirectory(projectResourcesDir)
                End If

                ' Copiar imagen a la carpeta Resources
                Dim originalFileName As String = Path.GetFileName(ofd.FileName)
                Dim targetPath As String = Path.Combine(projectResourcesDir, originalFileName)

                ' Verificar si ya existe
                If File.Exists(targetPath) Then
                    Dim overwriteResult As DialogResult = MessageBox.Show(
                        $"El archivo '{originalFileName}' ya existe en Resources.{vbCrLf}{vbCrLf}" &
                        "¿Deseas reemplazarlo?",
                        "Archivo Existente",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question)

                    If overwriteResult = DialogResult.Cancel Then Return

                    If overwriteResult = DialogResult.No Then
                        ' Generar nombre único
                        Dim baseName As String = Path.GetFileNameWithoutExtension(originalFileName)
                        Dim extension As String = Path.GetExtension(originalFileName)
                        Dim counter As Integer = 1

                        Do While File.Exists(targetPath)
                            targetPath = Path.Combine(projectResourcesDir, $"{baseName}_{counter}{extension}")
                            counter += 1
                        Loop

                        originalFileName = Path.GetFileName(targetPath)
                    End If
                End If

                ' Copiar archivo
                File.Copy(ofd.FileName, targetPath, True)

                ' Agregar al archivo .resx
                AddImageToResxFile(resxPath, targetPath, Path.GetFileNameWithoutExtension(originalFileName))

                ' Recargar la lista
                RefreshResourceList(selectedResxInfo)

            Catch ex As Exception
                Debug.WriteLine($"Error importando imagen: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Sub RefreshResourceList(resxInfo As ProjectResourceFinder.ResxFileInfo)
        If lstProjectResources Is Nothing Then Return

        lstProjectResources.Items.Clear()

        ' Agregar item (empty) al inicio
        lstProjectResources.Items.Add(New ResourceImageInfo With {
            .Name = "(empty)",
            .Image = Nothing,
            .FilePath = ""
        })

        Try
            Dim resxPath As String = resxInfo.FullPath
            If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then Return

            Dim resxDirectory As String = Path.GetDirectoryName(resxPath)

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = resxDirectory

                For Each entry As DictionaryEntry In reader
                    Try
                        Dim resourceName As String = entry.Key.ToString()
                        Dim resourceValue As Object = entry.Value

                        If TypeOf resourceValue Is Image OrElse
                           TypeOf resourceValue Is Bitmap OrElse
                           TypeOf resourceValue Is Icon Then

                            lstProjectResources.Items.Add(New ResourceImageInfo With {
                                .Name = resourceName,
                                .Image = If(TypeOf resourceValue Is Icon,
                                          DirectCast(resourceValue, Icon).ToBitmap(),
                                          DirectCast(resourceValue, Image)),
                                .FilePath = resxPath
                            })
                        End If
                    Catch ex As Exception
                        Try
                            Dim resourceName As String = entry.Key.ToString()
                            Dim manualImage As Image = LoadImageManually(resxPath, resourceName, resxDirectory)

                            If manualImage IsNot Nothing Then
                                lstProjectResources.Items.Add(New ResourceImageInfo With {
                                    .Name = resourceName,
                                    .Image = manualImage,
                                    .FilePath = resxPath
                                })
                            End If
                        Catch
                            Continue For
                        End Try
                    End Try
                Next
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error al refrescar recursos: {ex.Message}")
        End Try
    End Sub

    Private Sub AddImageToResxFile(resxPath As String, imagePath As String, resourceName As String)
        Try
            ' Leer el .resx existente
            Dim resources As New Hashtable()

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = Path.GetDirectoryName(resxPath)

                For Each entry As DictionaryEntry In reader
                    resources.Add(entry.Key, entry.Value)
                Next
            End Using

            ' Calcular ruta relativa desde el .resx a la imagen
            Dim resxDir As String = Path.GetDirectoryName(resxPath)
            Dim imageUri As New Uri(imagePath)
            Dim resxUri As New Uri(resxDir & "\")
            Dim relativePath As String = resxUri.MakeRelativeUri(imageUri).ToString().Replace("/", "\")

            ' Crear ResXFileRef para la imagen
            Dim fileRef As New Resources.ResXFileRef(relativePath, GetType(Bitmap).AssemblyQualifiedName)

            ' Agregar o reemplazar el recurso
            If resources.ContainsKey(resourceName) Then
                resources(resourceName) = fileRef
            Else
                resources.Add(resourceName, fileRef)
            End If

            ' Escribir el .resx actualizado
            Using writer As New Resources.ResXResourceWriter(resxPath)
                For Each key As Object In resources.Keys
                    Dim value As Object = resources(key)

                    If TypeOf value Is Resources.ResXFileRef Then
                        writer.AddResource(New Resources.ResXDataNode(key.ToString(), value))
                    ElseIf TypeOf value Is Byte() Then
                        writer.AddResource(key.ToString(), value)
                    Else
                        writer.AddResource(key.ToString(), value)
                    End If
                Next

                writer.Generate()
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error en AddImageToResxFile: {ex.Message}")
            Throw
        End Try
    End Sub

    Private Sub BtnClearLocal_Click(sender As Object, e As EventArgs) Handles btnClearLocal.Click
        If picPreview IsNot Nothing AndAlso picPreview.Image IsNot Nothing Then
            picPreview.Image.Dispose()
            picPreview.Image = Nothing
        End If

        If _selectedImage IsNot Nothing Then
            _selectedImage.Dispose()
            _selectedImage = Nothing
        End If

        _selectedImagePath = ""
        _selectedImageSource = ImageSource.None
        _resourceName = ""
    End Sub

#End Region

#Region "Gestión de Recursos del Proyecto"

    Private Sub RbLocalResource_CheckedChanged(sender As Object, e As EventArgs) Handles rbLocalResource.CheckedChanged
        If rbLocalResource.Checked Then
            btnImportLocal.Enabled = True
            btnClearLocal.Enabled = True
            cboResourceFiles.Enabled = False
            lstProjectResources.Enabled = False
        End If
    End Sub

    Private Sub RbProjectResource_CheckedChanged(sender As Object, e As EventArgs) Handles rbProjectResource.CheckedChanged
        If rbProjectResource.Checked Then
            btnImportLocal.Enabled = False
            btnClearLocal.Enabled = False
            cboResourceFiles.Enabled = True
            lstProjectResources.Enabled = True
            LoadProjectResources()
        End If
    End Sub

    Private Sub LstProjectResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProjectResources.SelectedIndexChanged
        If lstProjectResources.SelectedIndex < 0 Then Return

        Try
            Dim selectedItem As Object = lstProjectResources.SelectedItem

            If TypeOf selectedItem Is ResourceImageInfo Then
                Dim resourceInfo As ResourceImageInfo = DirectCast(selectedItem, ResourceImageInfo)

                ' Si es (empty), limpiar la imagen
                If resourceInfo.Name = "(empty)" Then
                    If picPreview IsNot Nothing AndAlso picPreview.Image IsNot Nothing Then
                        picPreview.Image.Dispose()
                        picPreview.Image = Nothing
                    End If

                    If _selectedImage IsNot Nothing Then
                        _selectedImage.Dispose()
                        _selectedImage = Nothing
                    End If

                    _selectedImagePath = ""
                    _selectedImageSource = ImageSource.None
                    _resourceName = ""
                    Return
                End If

                ' Cargar imagen normal
                If picPreview.Image IsNot Nothing Then
                    picPreview.Image.Dispose()
                End If

                picPreview.Image = New Bitmap(resourceInfo.Image)
                _selectedImage = New Bitmap(resourceInfo.Image)
                _selectedImagePath = resourceInfo.FilePath
                _selectedImageSource = ImageSource.ProjectResource
                _resourceName = resourceInfo.Name
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error al seleccionar recurso: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadProjectResources()
        If cboResourceFiles Is Nothing OrElse lstProjectResources Is Nothing Then Return
        If _designerContext Is Nothing Then Return

        cboResourceFiles.Items.Clear()
        lstProjectResources.Items.Clear()

        Try
            If _designerContext.Instance Is Nothing Then Return

            Dim controlType As Type = _designerContext.Instance.GetType()

            ' Obtener archivos .resx
            Dim resxFiles As List(Of ProjectResourceFinder.ResxFileInfo) =
                ProjectResourceFinder.FindResourceFiles(controlType, _designerContext)

            If resxFiles Is Nothing OrElse resxFiles.Count = 0 Then Return

            ' Cargar combo
            For Each resxFile As ProjectResourceFinder.ResxFileInfo In resxFiles
                cboResourceFiles.Items.Add(resxFile)
            Next

            ' Detectar proyecto host
            Dim hostProjectName As String = GetHostProjectNameFromFiles()

            ' Selección inteligente
            Dim selectedIndex As Integer = 0

            If Not String.IsNullOrEmpty(hostProjectName) Then
                For i As Integer = 0 To resxFiles.Count - 1
                    If resxFiles(i).ProjectName.Equals(hostProjectName, StringComparison.OrdinalIgnoreCase) Then
                        selectedIndex = i
                        Exit For
                    End If
                Next
            End If

            If cboResourceFiles.Items.Count > 0 Then
                cboResourceFiles.SelectedIndex = selectedIndex
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error en LoadProjectResources: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Detecta el proyecto del formulario buscando el archivo .vb/.Designer.vb
    ''' </summary>
    Private Function GetHostProjectNameFromFiles() As String
        Try
            If _designerContext Is Nothing Then Return Nothing

            Dim serviceProvider As IServiceProvider = TryCast(_designerContext, IServiceProvider)
            If serviceProvider IsNot Nothing Then
                Dim designerHost As ComponentModel.Design.IDesignerHost =
                    TryCast(serviceProvider.GetService(GetType(ComponentModel.Design.IDesignerHost)),
                            ComponentModel.Design.IDesignerHost)

                If designerHost IsNot Nothing AndAlso designerHost.RootComponent IsNot Nothing Then

                    ' Obtener el nombre del formulario desde Site
                    Dim formName As String = Nothing
                    If designerHost.RootComponent.Site IsNot Nothing Then
                        formName = designerHost.RootComponent.Site.Name
                    End If

                    ' Si no hay nombre, intentar con el tipo
                    If String.IsNullOrEmpty(formName) Then
                        formName = designerHost.RootComponent.GetType().Name
                    End If

                    If Not String.IsNullOrEmpty(formName) Then
                        ' Obtener la lista de proyectos
                        Dim controlType As Type = _designerContext.Instance.GetType()
                        Dim resxFiles As List(Of ProjectResourceFinder.ResxFileInfo) =
                            ProjectResourceFinder.FindResourceFiles(controlType, _designerContext)

                        If resxFiles IsNot Nothing AndAlso resxFiles.Count > 0 Then
                            For Each resxFile In resxFiles
                                ' Obtener el directorio del proyecto
                                Dim projectDir As String = Path.GetDirectoryName(Path.GetDirectoryName(resxFile.FullPath))

                                Try
                                    ' Buscar archivo del formulario
                                    Dim formFiles As String() = Directory.GetFiles(projectDir, $"{formName}.vb", SearchOption.AllDirectories)

                                    ' También buscar .Designer.vb
                                    If formFiles.Length = 0 Then
                                        formFiles = Directory.GetFiles(projectDir, $"{formName}.Designer.vb", SearchOption.AllDirectories)
                                    End If

                                    If formFiles.Length > 0 Then
                                        Return resxFile.ProjectName
                                    End If
                                Catch
                                    Continue For
                                End Try
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error en GetHostProjectNameFromFiles: {ex.Message}")
        End Try

        Return Nothing
    End Function

    Private Sub CboResourceFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResourceFiles.SelectedIndexChanged
        If cboResourceFiles.SelectedIndex < 0 Then Return
        If lstProjectResources Is Nothing Then Return

        lstProjectResources.Items.Clear()

        ' Agregar item (empty) al inicio
        lstProjectResources.Items.Add(New ResourceImageInfo With {
            .Name = "(empty)",
            .Image = Nothing,
            .FilePath = ""
        })

        Try
            Dim selectedItem As Object = cboResourceFiles.SelectedItem
            If Not TypeOf selectedItem Is ProjectResourceFinder.ResxFileInfo Then Return

            Dim resxInfo As ProjectResourceFinder.ResxFileInfo =
                DirectCast(selectedItem, ProjectResourceFinder.ResxFileInfo)

            Dim resxPath As String = resxInfo.FullPath
            If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then Return

            Dim resxDirectory As String = Path.GetDirectoryName(resxPath)

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = resxDirectory

                For Each entry As DictionaryEntry In reader
                    Try
                        Dim resourceName As String = entry.Key.ToString()
                        Dim resourceValue As Object = entry.Value

                        If TypeOf resourceValue Is Image OrElse
                           TypeOf resourceValue Is Bitmap OrElse
                           TypeOf resourceValue Is Icon Then

                            lstProjectResources.Items.Add(New ResourceImageInfo With {
                                .Name = resourceName,
                                .Image = If(TypeOf resourceValue Is Icon,
                                          DirectCast(resourceValue, Icon).ToBitmap(),
                                          DirectCast(resourceValue, Image)),
                                .FilePath = resxPath
                            })
                        End If
                    Catch ex As Exception
                        Try
                            Dim resourceName As String = entry.Key.ToString()
                            Dim manualImage As Image = LoadImageManually(resxPath, resourceName, resxDirectory)

                            If manualImage IsNot Nothing Then
                                lstProjectResources.Items.Add(New ResourceImageInfo With {
                                    .Name = resourceName,
                                    .Image = manualImage,
                                    .FilePath = resxPath
                                })
                            End If
                        Catch
                            Continue For
                        End Try
                    End Try
                Next
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error al cargar recursos: {ex.Message}")
        End Try
    End Sub

    Private Function LoadImageManually(resxPath As String, resourceName As String, baseDirectory As String) As Image
        Try
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(resxPath)

            Dim nsmgr As New Xml.XmlNamespaceManager(xmlDoc.NameTable)
            Dim dataNode As Xml.XmlNode = xmlDoc.SelectSingleNode($"//data[@name='{resourceName}']", nsmgr)
            If dataNode Is Nothing Then Return Nothing

            Dim valueNode As Xml.XmlNode = dataNode.SelectSingleNode("value")
            If valueNode Is Nothing Then Return Nothing

            Dim value As String = valueNode.InnerText.Trim()

            If value.Contains(";") Then
                Dim parts As String() = value.Split(";"c)
                If parts.Length > 0 Then
                    Dim relativePath As String = parts(0).Trim()
                    Dim fullPath As String = Path.Combine(baseDirectory, relativePath)

                    If File.Exists(fullPath) Then
                        Return Image.FromFile(fullPath)
                    Else
                        Dim commonSubDirs As String() = {"Resources", "..\Resources", "..\..\Resources"}
                        For Each subDir As String In commonSubDirs
                            Dim altPath As String = Path.Combine(baseDirectory, subDir, Path.GetFileName(relativePath))
                            If File.Exists(altPath) Then
                                Return Image.FromFile(altPath)
                            End If
                        Next
                    End If
                End If
            ElseIf value.Length > 100 Then
                Try
                    Dim imageBytes As Byte() = Convert.FromBase64String(value)
                    Using ms As New MemoryStream(imageBytes)
                        Return Image.FromStream(ms)
                    End Using
                Catch
                    ' Ignorar error de Base64
                End Try
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error en LoadImageManually: {ex.Message}")
        End Try

        Return Nothing
    End Function

    Private Class ResourceImageInfo
        Public Property Name As String
        Public Property Image As Image
        Public Property FilePath As String

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

#End Region

#Region "Gestión de Tabs"

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl.SelectedIndexChanged
        If tabControl Is Nothing Then Return

        Select Case tabControl.SelectedIndex
            Case 0 ' Image Picker
            Case 1 ' Raster Images
            Case 2 ' Vector Images
            Case 3 ' Font Icons
        End Select
    End Sub

#End Region

#Region "Botones de Acción"

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearSelection()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Métodos Públicos"

    Public Sub ClearSelection()
        If picPreview IsNot Nothing AndAlso picPreview.Image IsNot Nothing Then
            picPreview.Image.Dispose()
            picPreview.Image = Nothing
        End If

        If _selectedImage IsNot Nothing AndAlso _selectedImage IsNot picPreview.Image Then
            _selectedImage.Dispose()
        End If

        _selectedImage = Nothing
        _selectedImagePath = ""
        _selectedImageSource = ImageSource.None
        _resourceName = ""
    End Sub

#End Region

#Region "Limpieza"

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If Me.DialogResult = DialogResult.Cancel Then
            ClearSelection()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub NXImagePickerDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabControl.SelectedIndex = 1
        rbProjectResource.Checked = True
    End Sub

#End Region

End Class