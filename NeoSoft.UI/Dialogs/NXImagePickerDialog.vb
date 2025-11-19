Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Resources
Imports System.Text.RegularExpressions
Imports System.Xml
Imports NeoSoft.UI.Common
Imports NeoSoft.UI.Helpers

''' <summary>
''' Diálogo avanzado para selección de imágenes con múltiples fuentes
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

#Region "Campos Privados"

    Private _selectedImage As Image = Nothing
    Private _selectedImagePath As String = ""
    Private _selectedImageSource As ImageSource = ImageSource.None
    Private _resourceName As String = ""
    Private _designerContext As ComponentModel.ITypeDescriptorContext = Nothing

#End Region

#Region "Propiedades Públicas"

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

#Region "Constructor e Inicialización"

    Public Sub New()
        InitializeComponent()
        InitializeDialog()
    End Sub

    Private Sub InitializeDialog()
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.MinimumSize = New Size(700, 500)

        If tabControl IsNot Nothing Then tabControl.SelectedIndex = 0
        If rbLocalResource IsNot Nothing Then rbLocalResource.Checked = True

        If picPreview IsNot Nothing Then
            picPreview.SizeMode = PictureBoxSizeMode.Zoom
            picPreview.BackColor = Color.FromArgb(245, 245, 245)
        End If

        If lblVersion IsNot Nothing Then
            lblVersion.Text = "NeoSoft.UI v1.0 - Image Picker Dialog"
        End If
    End Sub

#End Region

#Region "TAB: Image Picker (Standard)"

#Region "Recursos Locales"

    Private Sub BtnImportLocal_Click(sender As Object, e As EventArgs) Handles btnImportLocal.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar Imagen"
            ofd.Filter = "Archivos de Imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|" &
                         "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|ICO|*.ico|Todos los archivos|*.*"
            ofd.FilterIndex = 1
            ofd.Multiselect = False

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim img As Image = Image.FromFile(ofd.FileName)
                    If picPreview.Image IsNot Nothing Then picPreview.Image.Dispose()

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

#Region "Recursos del Proyecto"

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

    Private Sub LoadProjectResources()
        If cboResourceFiles Is Nothing OrElse lstProjectResources Is Nothing Then Return
        If _designerContext Is Nothing Then Return

        cboResourceFiles.Items.Clear()
        lstProjectResources.Items.Clear()

        Try
            If _designerContext.Instance Is Nothing Then Return

            Dim controlType As Type = _designerContext.Instance.GetType()
            Dim resxFiles As List(Of ProjectResourceFinder.ResxFileInfo) =
                ProjectResourceFinder.FindResourceFiles(controlType, _designerContext)

            If resxFiles Is Nothing OrElse resxFiles.Count = 0 Then Return

            For Each resxFile As ProjectResourceFinder.ResxFileInfo In resxFiles
                cboResourceFiles.Items.Add(resxFile)
            Next

            Dim hostProjectName As String = GetHostProjectNameFromFiles()
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

    Private Function GetHostProjectNameFromFiles() As String
        Try
            If _designerContext Is Nothing Then Return Nothing

            Dim serviceProvider As IServiceProvider = TryCast(_designerContext, IServiceProvider)
            If serviceProvider IsNot Nothing Then
                Dim designerHost As ComponentModel.Design.IDesignerHost =
                    TryCast(serviceProvider.GetService(GetType(ComponentModel.Design.IDesignerHost)),
                            ComponentModel.Design.IDesignerHost)

                If designerHost IsNot Nothing AndAlso designerHost.RootComponent IsNot Nothing Then
                    Dim formName As String = Nothing
                    If designerHost.RootComponent.Site IsNot Nothing Then
                        formName = designerHost.RootComponent.Site.Name
                    End If

                    If String.IsNullOrEmpty(formName) Then
                        formName = designerHost.RootComponent.GetType().Name
                    End If

                    If Not String.IsNullOrEmpty(formName) Then
                        Dim controlType As Type = _designerContext.Instance.GetType()
                        Dim resxFiles As List(Of ProjectResourceFinder.ResxFileInfo) =
                            ProjectResourceFinder.FindResourceFiles(controlType, _designerContext)

                        If resxFiles IsNot Nothing AndAlso resxFiles.Count > 0 Then
                            For Each resxFile In resxFiles
                                Dim projectDir As String = Path.GetDirectoryName(Path.GetDirectoryName(resxFile.FullPath))

                                Try
                                    Dim formFiles As String() = Directory.GetFiles(projectDir, $"{formName}.vb", SearchOption.AllDirectories)
                                    If formFiles.Length = 0 Then
                                        formFiles = Directory.GetFiles(projectDir, $"{formName}.Designer.vb", SearchOption.AllDirectories)
                                    End If

                                    If formFiles.Length > 0 Then Return resxFile.ProjectName
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
        If cboResourceFiles.SelectedIndex < 0 OrElse lstProjectResources Is Nothing Then Return

        lstProjectResources.Items.Clear()
        lstProjectResources.Items.Add(New ResourceImageInfo With {.Name = "(empty)", .Image = Nothing, .FilePath = ""})

        Try
            Dim selectedItem As Object = cboResourceFiles.SelectedItem
            If Not TypeOf selectedItem Is ProjectResourceFinder.ResxFileInfo Then Return

            Dim resxInfo As ProjectResourceFinder.ResxFileInfo = DirectCast(selectedItem, ProjectResourceFinder.ResxFileInfo)
            Dim resxPath As String = resxInfo.FullPath
            If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then Return

            Dim resxDirectory As String = Path.GetDirectoryName(resxPath)

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = resxDirectory

                For Each entry As DictionaryEntry In reader
                    Try
                        Dim resourceName As String = entry.Key.ToString()
                        Dim resourceValue As Object = entry.Value

                        If TypeOf resourceValue Is Image OrElse TypeOf resourceValue Is Bitmap OrElse TypeOf resourceValue Is Icon Then
                            lstProjectResources.Items.Add(New ResourceImageInfo With {
                                .Name = resourceName,
                                .Image = If(TypeOf resourceValue Is Icon, DirectCast(resourceValue, Icon).ToBitmap(), DirectCast(resourceValue, Image)),
                                .FilePath = resxPath
                            })
                        End If
                    Catch
                        Try
                            Dim resourceName As String = entry.Key.ToString()
                            Dim manualImage As Image = LoadImageManually(resxPath, resourceName, resxDirectory)
                            If manualImage IsNot Nothing Then
                                lstProjectResources.Items.Add(New ResourceImageInfo With {
                                    .Name = resourceName, .Image = manualImage, .FilePath = resxPath
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

    Private Sub LstProjectResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProjectResources.SelectedIndexChanged
        If lstProjectResources.SelectedIndex < 0 Then Return

        Try
            Dim selectedItem As Object = lstProjectResources.SelectedItem
            If Not TypeOf selectedItem Is ResourceImageInfo Then Return

            Dim resourceInfo As ResourceImageInfo = DirectCast(selectedItem, ResourceImageInfo)

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

            If picPreview.Image IsNot Nothing Then picPreview.Image.Dispose()
            picPreview.Image = New Bitmap(resourceInfo.Image)
            _selectedImage = New Bitmap(resourceInfo.Image)
            _selectedImagePath = resourceInfo.FilePath
            _selectedImageSource = ImageSource.ProjectResource
            _resourceName = resourceInfo.Name
        Catch ex As Exception
            Debug.WriteLine($"Error al seleccionar recurso: {ex.Message}")
        End Try
    End Sub

    Private Sub BtnImportProject_Click(sender As Object, e As EventArgs) Handles btnImportProject.Click
        If _designerContext Is Nothing OrElse cboResourceFiles Is Nothing OrElse cboResourceFiles.SelectedIndex < 0 Then Return

        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar Imagen para agregar a Resources"
            ofd.Filter = "Archivos de Imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|ICO|*.ico|Todos los archivos|*.*"
            ofd.FilterIndex = 1
            ofd.Multiselect = False

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Try
                Dim selectedItem As Object = cboResourceFiles.SelectedItem
                If Not TypeOf selectedItem Is ProjectResourceFinder.ResxFileInfo Then Return

                Dim selectedResxInfo As ProjectResourceFinder.ResxFileInfo = DirectCast(selectedItem, ProjectResourceFinder.ResxFileInfo)
                Dim resxPath As String = selectedResxInfo.FullPath
                If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then Return

                Dim resxDirectory As String = Path.GetDirectoryName(resxPath)
                Dim projectResourcesDir As String = Path.Combine(Path.GetDirectoryName(resxDirectory), "Resources")
                If Not Directory.Exists(projectResourcesDir) Then Directory.CreateDirectory(projectResourcesDir)

                Dim originalFileName As String = Path.GetFileName(ofd.FileName)
                Dim targetPath As String = Path.Combine(projectResourcesDir, originalFileName)

                If File.Exists(targetPath) Then
                    Dim overwriteResult As DialogResult = MessageBox.Show(
                        $"El archivo '{originalFileName}' ya existe en Resources.{vbCrLf}{vbCrLf}¿Deseas reemplazarlo?",
                        "Archivo Existente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    If overwriteResult = DialogResult.Cancel Then Return

                    If overwriteResult = DialogResult.No Then
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

                File.Copy(ofd.FileName, targetPath, True)
                AddImageToResxFile(resxPath, targetPath, Path.GetFileNameWithoutExtension(originalFileName))
                RefreshResourceList(selectedResxInfo)
            Catch ex As Exception
                Debug.WriteLine($"Error importando imagen: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Sub RefreshResourceList(resxInfo As ProjectResourceFinder.ResxFileInfo)
        If lstProjectResources Is Nothing Then Return

        lstProjectResources.Items.Clear()
        lstProjectResources.Items.Add(New ResourceImageInfo With {.Name = "(empty)", .Image = Nothing, .FilePath = ""})

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

                        If TypeOf resourceValue Is Image OrElse TypeOf resourceValue Is Bitmap OrElse TypeOf resourceValue Is Icon Then
                            lstProjectResources.Items.Add(New ResourceImageInfo With {
                                .Name = resourceName,
                                .Image = If(TypeOf resourceValue Is Icon, DirectCast(resourceValue, Icon).ToBitmap(), DirectCast(resourceValue, Image)),
                                .FilePath = resxPath
                            })
                        End If
                    Catch
                        Try
                            Dim resourceName As String = entry.Key.ToString()
                            Dim manualImage As Image = LoadImageManually(resxPath, resourceName, resxDirectory)
                            If manualImage IsNot Nothing Then
                                lstProjectResources.Items.Add(New ResourceImageInfo With {.Name = resourceName, .Image = manualImage, .FilePath = resxPath})
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
            Dim resources As New Hashtable()

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = Path.GetDirectoryName(resxPath)
                For Each entry As DictionaryEntry In reader
                    resources.Add(entry.Key, entry.Value)
                Next
            End Using

            Dim resxDir As String = Path.GetDirectoryName(resxPath)
            Dim imageUri As New Uri(imagePath)
            Dim resxUri As New Uri(resxDir & "\")
            Dim relativePath As String = resxUri.MakeRelativeUri(imageUri).ToString().Replace("/", "\")
            Dim fileRef As New Resources.ResXFileRef(relativePath, GetType(Bitmap).AssemblyQualifiedName)

            If resources.ContainsKey(resourceName) Then
                resources(resourceName) = fileRef
            Else
                resources.Add(resourceName, fileRef)
            End If

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

    Private Function LoadImageManually(resxPath As String, resourceName As String, baseDirectory As String) As Image
        Try
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(resxPath)

            Dim dataNode As Xml.XmlNode = xmlDoc.SelectSingleNode($"//data[@name='{resourceName}']")
            If dataNode Is Nothing Then Return Nothing

            Dim valueNode As Xml.XmlNode = dataNode.SelectSingleNode("value")
            If valueNode Is Nothing Then Return Nothing

            Dim value As String = valueNode.InnerText.Trim()

            If value.Contains(";") Then
                Dim parts As String() = value.Split(";"c)
                If parts.Length > 0 Then
                    Dim relativePath As String = parts(0).Trim()
                    Dim fullPath As String = Path.Combine(baseDirectory, relativePath)
                    If File.Exists(fullPath) Then Return Image.FromFile(fullPath)

                    Dim commonSubDirs As String() = {"Resources", "..\Resources", "..\..\Resources"}
                    For Each subDir As String In commonSubDirs
                        Dim altPath As String = Path.Combine(baseDirectory, subDir, Path.GetFileName(relativePath))
                        If File.Exists(altPath) Then Return Image.FromFile(altPath)
                    Next
                End If
            ElseIf value.Length > 100 Then
                Try
                    Dim imageBytes As Byte() = Convert.FromBase64String(value)
                    Using ms As New MemoryStream(imageBytes)
                        Return Image.FromStream(ms)
                    End Using
                Catch
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

#End Region

#Region "TAB: Raster Images (Rastrear Imagen)"

#Region "Campos Privados - Raster Images"

    Private _rasterImagesBasePath As String = ""
    Private _selectedCategories As New List(Of String)
    Private _selectedSizes As New List(Of String)
    Private _availableSizes As New HashSet(Of String)
    Private _isLoadingCategories As Boolean = False

    ' ⭐ CACHE DE IMÁGENES PARA EVITAR RECARGAS
    Private _imageCache As New Dictionary(Of String, Image)
    Private _allIconsInfo As New List(Of IconInfo)

#End Region

#Region "Inicialización - Raster Images"

    Private Sub InitializeRasterImagesTab()
        Try
            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
            TraceLogger.WriteLine("=== INICIALIZANDO TAB: RASTER IMAGES ===")
            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")

            _isLoadingCategories = True

            ' Limpiar controles y caché
            If chkListCategories IsNot Nothing Then chkListCategories.Items.Clear()
            If chkListSize IsNot Nothing Then chkListSize.Items.Clear()
            If flowRasterIcons IsNot Nothing Then flowRasterIcons.Controls.Clear()

            _imageCache.Clear()
            _allIconsInfo.Clear()

            ' Obtener la ruta física de las imágenes de la DLL
            _rasterImagesBasePath = GetDllImagesPath()

            If String.IsNullOrEmpty(_rasterImagesBasePath) Then
                TraceLogger.WriteLine("⚠️ No se pudo determinar la ruta de Resources\Images de la DLL")
                _isLoadingCategories = False
                Return
            End If

            TraceLogger.WriteLine($"✅ Ruta base de la DLL: {_rasterImagesBasePath}")

            ' Cargar categorías
            LoadRasterCategories()

            ' ⭐ CARGAR TODAS LAS IMÁGENES EN MEMORIA UNA SOLA VEZ
            LoadAllIconsToMemory()

            ' ⭐ ACTUALIZAR LISTAS DE SELECCIÓN ANTES DE MOSTRAR
            UpdateSelectedCategories()
            UpdateSelectedSizes()

            _isLoadingCategories = False

            TraceLogger.WriteLine($"📊 Categorías seleccionadas: {_selectedCategories.Count}")
            TraceLogger.WriteLine($"📊 Tamaños seleccionados: {_selectedSizes.Count}")

            ' Mostrar iconos con filtro inicial
            FilterAndDisplayIcons()

            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en InitializeRasterImagesTab: {ex.Message}")
            TraceLogger.WriteException(ex)
            _isLoadingCategories = False
        End Try
    End Sub

    Private Function GetDllImagesPath() As String
        Try
            TraceLogger.WriteLine("🔍 Buscando ruta de Resources\Images de la DLL NeoSoft.UI...")

            Dim neoSoftAssembly As Reflection.Assembly = Me.GetType().Assembly
            Dim dllDirectory As String = Path.GetDirectoryName(neoSoftAssembly.Location)
            Dim projectDirectory As String = FindNeoSoftUIProjectDirectory(dllDirectory)

            If Not String.IsNullOrEmpty(projectDirectory) Then
                Dim imagesPath As String = Path.Combine(projectDirectory, "Resources", "Images")

                If Directory.Exists(imagesPath) Then
                    TraceLogger.WriteLine("✅ Carpeta Resources\Images encontrada en el proyecto de la DLL")
                    Return imagesPath
                End If
            End If

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en GetDllImagesPath: {ex.Message}")
        End Try

        Return Nothing
    End Function

    Private Function FindNeoSoftUIProjectDirectory(startPath As String) As String
        Try
            Dim currentDir As New DirectoryInfo(startPath)
            Dim maxLevels As Integer = 10
            Dim level As Integer = 0

            While currentDir IsNot Nothing AndAlso level < maxLevels
                Dim projectFiles As String() = Directory.GetFiles(currentDir.FullName, "NeoSoft.UI.vbproj")
                If projectFiles.Length > 0 Then
                    Return currentDir.FullName
                End If

                currentDir = currentDir.Parent
                level += 1
            End While

            ' Buscar en ubicaciones comunes
            Dim commonPaths As String() = {
                "C:\Users\" & Environment.UserName & "\source\repos",
                "C:\Users\" & Environment.UserName & "\Documents\Visual Studio 2022\Projects",
                "C:\Users\" & Environment.UserName & "\Documents\Visual Studio 2019\Projects"
            }

            For Each commonPath As String In commonPaths
                If Directory.Exists(commonPath) Then
                    Try
                        Dim foundProjects As String() = Directory.GetFiles(commonPath, "NeoSoft.UI.vbproj", SearchOption.AllDirectories)
                        If foundProjects.Length > 0 Then
                            Return Path.GetDirectoryName(foundProjects(0))
                        End If
                    Catch
                    End Try
                End If
            Next

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en FindNeoSoftUIProjectDirectory: {ex.Message}")
        End Try

        Return Nothing
    End Function

#End Region

#Region "Carga de Categorías"

    Private Sub LoadRasterCategories()
        Try
            If String.IsNullOrEmpty(_rasterImagesBasePath) OrElse Not Directory.Exists(_rasterImagesBasePath) Then
                Return
            End If

            TraceLogger.WriteLine("📋 Cargando categorías...")

            Dim subdirectories As String() = Directory.GetDirectories(_rasterImagesBasePath)
            If subdirectories.Length = 0 Then Return

            chkListCategories.Items.Clear()
            chkListCategories.Items.Add("SELECT ALL", CheckState.Checked)

            For Each subdir As String In subdirectories
                Dim categoryName As String = Path.GetFileName(subdir)
                chkListCategories.Items.Add(categoryName, CheckState.Checked)
            Next

            TraceLogger.WriteLine($"📊 Total de categorías: {chkListCategories.Items.Count - 1}")

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en LoadRasterCategories: {ex.Message}")
        End Try
    End Sub

#End Region

#Region "Carga de Todas las Imágenes en Memoria - UNA SOLA VEZ"

    Private Sub LoadAllIconsToMemory()
        Try
            TraceLogger.WriteLine("💾 CARGANDO TODAS LAS IMÁGENES EN MEMORIA...")
            Dim startTime As DateTime = DateTime.Now

            If String.IsNullOrEmpty(_rasterImagesBasePath) OrElse Not Directory.Exists(_rasterImagesBasePath) Then
                TraceLogger.WriteLine("⚠️ Ruta base no válida")
                Return
            End If

            Dim totalIcons As Integer = 0
            Dim categories As String() = Directory.GetDirectories(_rasterImagesBasePath)

            TraceLogger.WriteLine($"📂 Total de carpetas de categorías encontradas: {categories.Length}")

            For Each categoryPath As String In categories
                Dim categoryName As String = Path.GetFileName(categoryPath)
                TraceLogger.WriteLine($"  📂 Procesando categoría: {categoryName}")

                Dim sizeDirectories As String() = Directory.GetDirectories(categoryPath, "ICONS_*")
                TraceLogger.WriteLine($"     📏 Tamaños encontrados: {sizeDirectories.Length}")

                For Each sizePath As String In sizeDirectories
                    Dim sizeName As String = Path.GetFileName(sizePath)

                    ' Agregar tamaño a disponibles
                    If Not _availableSizes.Contains(sizeName) Then
                        _availableSizes.Add(sizeName)
                        TraceLogger.WriteLine($"        ✅ Tamaño agregado: {sizeName}")
                    End If

                    Dim imageFiles As String() = Directory.GetFiles(sizePath, "*.*").
                        Where(Function(f) f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) OrElse
                                         f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) OrElse
                                         f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) OrElse
                                         f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) OrElse
                                         f.EndsWith(".ico", StringComparison.OrdinalIgnoreCase)).ToArray()

                    TraceLogger.WriteLine($"        🖼️ Archivos de imagen encontrados: {imageFiles.Length}")

                    For Each imageFile As String In imageFiles
                        Try
                            ' ⭐ CARGAR IMAGEN EN CACHÉ
                            If Not _imageCache.ContainsKey(imageFile) Then
                                _imageCache(imageFile) = Image.FromFile(imageFile)
                            End If

                            Dim fileName As String = Path.GetFileNameWithoutExtension(imageFile)
                            Dim baseName As String = ExtractBaseName(fileName)

                            _allIconsInfo.Add(New IconInfo With {
                                .BaseName = baseName,
                                .FullPath = imageFile,
                                .Category = categoryName,
                                .Size = sizeName,
                                .FileName = fileName,
                                .IsFromDll = True
                            })

                            totalIcons += 1
                        Catch ex As Exception
                            TraceLogger.WriteLine($"⚠️ Error cargando {Path.GetFileName(imageFile)}: {ex.Message}")
                        End Try
                    Next
                Next
            Next

            Dim elapsed As TimeSpan = DateTime.Now - startTime
            TraceLogger.WriteLine($"✅ {totalIcons} imágenes cargadas en memoria en {elapsed.TotalMilliseconds:F0}ms")
            TraceLogger.WriteLine($"📊 Total de tamaños detectados: {_availableSizes.Count}")
            TraceLogger.WriteLine($"📊 Total de iconos info: {_allIconsInfo.Count}")

            ' Cargar lista de tamaños
            LoadSizesList()

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en LoadAllIconsToMemory: {ex.Message}")
            TraceLogger.WriteException(ex)
        End Try
    End Sub

    Private Sub LoadSizesList()
        Try
            chkListSize.Items.Clear()

            Dim sortedSizes = _availableSizes.OrderBy(Function(s)
                                                          Dim parts As String() = s.Split("_"c)
                                                          If parts.Length = 2 Then
                                                              Dim sizeValue As Integer
                                                              If Integer.TryParse(parts(1), sizeValue) Then
                                                                  Return sizeValue
                                                              End If
                                                          End If
                                                          Return 0
                                                      End Function).ToList()

            For Each sizeName As String In sortedSizes
                chkListSize.Items.Add(sizeName, CheckState.Checked)
            Next

            UpdateSelectedSizes()

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en LoadSizesList: {ex.Message}")
        End Try
    End Sub

    Private Function ExtractBaseName(fileName As String) As String
        Dim pattern As String = "_x_\d+$"
        Return Regex.Replace(fileName, pattern, "", RegexOptions.IgnoreCase)
    End Function

#End Region

#Region "Eventos - Categorías"

    Private Sub ChkListCategories_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkListCategories.ItemCheck
        If _isLoadingCategories Then Return

        If e.Index = 0 Then ' SELECT ALL
            Dim newState As CheckState = e.NewValue
            BeginInvoke(New Action(Sub()
                                       _isLoadingCategories = True
                                       For i As Integer = 1 To chkListCategories.Items.Count - 1
                                           chkListCategories.SetItemChecked(i, newState = CheckState.Checked)
                                       Next
                                       _isLoadingCategories = False
                                       UpdateSelectedCategories()
                                       FilterAndDisplayIcons()
                                   End Sub))
        Else
            BeginInvoke(New Action(Sub()
                                       UpdateSelectedCategories()
                                       FilterAndDisplayIcons()
                                   End Sub))
        End If
    End Sub

    Private Sub UpdateSelectedCategories()
        _selectedCategories.Clear()

        If chkListCategories Is Nothing OrElse chkListCategories.Items.Count <= 1 Then
            TraceLogger.WriteLine("⚠️ No hay categorías para seleccionar")
            Return
        End If

        For i As Integer = 1 To chkListCategories.Items.Count - 1 ' Saltar SELECT ALL
            If chkListCategories.GetItemChecked(i) Then
                Dim category As String = chkListCategories.Items(i).ToString()
                _selectedCategories.Add(category)
                TraceLogger.WriteLine($"  ✅ Categoría seleccionada: {category}")
            End If
        Next

        TraceLogger.WriteLine($"📊 Total categorías seleccionadas: {_selectedCategories.Count}")
    End Sub

#End Region

#Region "Eventos - Tamaños"

    Private Sub ChkListSize_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkListSize.ItemCheck
        BeginInvoke(New Action(Sub()
                                   UpdateSelectedSizes()
                                   FilterAndDisplayIcons()
                               End Sub))
    End Sub

    Private Sub UpdateSelectedSizes()
        _selectedSizes.Clear()

        If chkListSize Is Nothing OrElse chkListSize.Items.Count = 0 Then
            TraceLogger.WriteLine("⚠️ No hay tamaños para seleccionar")
            Return
        End If

        For i As Integer = 0 To chkListSize.Items.Count - 1
            If chkListSize.GetItemChecked(i) Then
                Dim size As String = chkListSize.Items(i).ToString()
                _selectedSizes.Add(size)
                TraceLogger.WriteLine($"  ✅ Tamaño seleccionado: {size}")
            End If
        Next

        TraceLogger.WriteLine($"📊 Total tamaños seleccionados: {_selectedSizes.Count}")
    End Sub

#End Region

#Region "Filtrado y Visualización de Iconos - OPTIMIZADO"

    Private Sub FilterAndDisplayIcons()
        Try
            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
            TraceLogger.WriteLine("🔄 FILTRANDO Y MOSTRANDO ICONOS...")
            TraceLogger.WriteLine($"   Categorías seleccionadas: {_selectedCategories.Count}")
            TraceLogger.WriteLine($"   Tamaños seleccionados: {_selectedSizes.Count}")
            TraceLogger.WriteLine($"   Total iconos disponibles: {_allIconsInfo.Count}")

            Dim startTime As DateTime = DateTime.Now

            ' ⭐ SUSPENDER LAYOUT
            flowRasterIcons.SuspendLayout()
            flowRasterIcons.Controls.Clear()

            If _selectedCategories.Count = 0 Then
                TraceLogger.WriteLine("⚠️ No hay categorías seleccionadas - no se mostrarán iconos")
                flowRasterIcons.ResumeLayout()
                TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
                Return
            End If

            If _selectedSizes.Count = 0 Then
                TraceLogger.WriteLine("⚠️ No hay tamaños seleccionados - no se mostrarán iconos")
                flowRasterIcons.ResumeLayout()
                TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
                Return
            End If

            ' ⭐ FILTRAR ICONOS SIN RECARGAR IMÁGENES
            Dim filteredIcons = _allIconsInfo.Where(Function(icon)
                                                        Dim matchCategory = _selectedCategories.Contains(icon.Category)
                                                        Dim matchSize = _selectedSizes.Contains(icon.Size)
                                                        Return matchCategory AndAlso matchSize
                                                    End Function).
                                              OrderBy(Function(i) i.Category).
                                              ThenBy(Function(i) i.BaseName).
                                              ThenBy(Function(i) i.Size).ToList()

            TraceLogger.WriteLine($"📊 Iconos después del filtro: {filteredIcons.Count}")

            If filteredIcons.Count = 0 Then
                TraceLogger.WriteLine("⚠️ Ningún icono coincide con los filtros")
            End If

            ' ⭐ CREAR CONTROLES CON IMÁGENES DEL CACHÉ
            Dim createdControls As Integer = 0
            For Each iconInfo In filteredIcons
                Try
                    CreateSingleIconControlFromCache(iconInfo)
                    createdControls += 1
                Catch ex As Exception
                    TraceLogger.WriteLine($"⚠️ Error creando control para {iconInfo.FileName}: {ex.Message}")
                End Try
            Next

            TraceLogger.WriteLine($"📊 Controles creados: {createdControls}")

            ' ⭐ REANUDAR LAYOUT
            flowRasterIcons.ResumeLayout(True)

            Dim elapsed As TimeSpan = DateTime.Now - startTime
            TraceLogger.WriteLine($"✅ Iconos mostrados en {elapsed.TotalMilliseconds:F0}ms")
            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en FilterAndDisplayIcons: {ex.Message}")
            TraceLogger.WriteException(ex)
            flowRasterIcons.ResumeLayout()
        End Try
    End Sub

#End Region

#Region "Creación de Controles - DESDE CACHÉ"

    Private Sub CreateSingleIconControlFromCache(iconInfo As IconInfo)
        Try
            ' Panel contenedor
            Dim iconPanel As New Panel With {
                .Width = 80,
                .Height = 100,
                .BorderStyle = BorderStyle.FixedSingle,
                .Margin = New Padding(3),
                .BackColor = Color.White,
                .Cursor = Cursors.Hand,
                .Tag = iconInfo
            }

            ' ⭐ USAR IMAGEN DEL CACHÉ (NO RECARGAR)
            Dim cachedImage As Image = Nothing
            If _imageCache.TryGetValue(iconInfo.FullPath, cachedImage) Then
                Dim picBox As New PictureBox With {
                    .Image = cachedImage,
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .Width = 70,
                    .Height = 70,
                    .Left = 5,
                    .Top = 5,
                    .Cursor = Cursors.Hand,
                    .Tag = iconInfo
                }

                Dim lblName As New Label With {
                    .Text = iconInfo.BaseName,
                    .Width = 70,
                    .Height = 20,
                    .Left = 5,
                    .Top = 78,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Font = New Font("Segoe UI", 7.0F, FontStyle.Regular),
                    .ForeColor = Color.FromArgb(64, 64, 64)
                }

                Dim tooltip As New ToolTip()
                tooltip.SetToolTip(picBox, $"{iconInfo.FileName}{vbCrLf}Categoría: {iconInfo.Category}{vbCrLf}Tamaño: {iconInfo.Size}")

                AddHandler picBox.Click, AddressOf RasterIcon_Click
                AddHandler iconPanel.Click, AddressOf RasterIcon_Click
                AddHandler picBox.MouseEnter, Sub() iconPanel.BackColor = Color.FromArgb(230, 240, 255)
                AddHandler picBox.MouseLeave, Sub() iconPanel.BackColor = Color.White
                AddHandler iconPanel.MouseEnter, Sub() iconPanel.BackColor = Color.FromArgb(230, 240, 255)
                AddHandler iconPanel.MouseLeave, Sub() iconPanel.BackColor = Color.White

                iconPanel.Controls.Add(picBox)
                iconPanel.Controls.Add(lblName)
            End If

            flowRasterIcons.Controls.Add(iconPanel)

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en CreateSingleIconControlFromCache: {ex.Message}")
        End Try
    End Sub

#End Region

#Region "Eventos - Selección de Iconos"

    Private Sub RasterIcon_Click(sender As Object, e As EventArgs)
        Try
            Dim iconInfo As IconInfo = Nothing

            If TypeOf sender Is PictureBox Then
                iconInfo = TryCast(DirectCast(sender, PictureBox).Tag, IconInfo)
            ElseIf TypeOf sender Is Panel Then
                iconInfo = TryCast(DirectCast(sender, Panel).Tag, IconInfo)
            End If

            If iconInfo Is Nothing Then Return

            TraceLogger.WriteLine($"🖱️ Icono seleccionado: {iconInfo.FileName}")

            If picPreview.Image IsNot Nothing Then picPreview.Image.Dispose()

            ' ⭐ USAR IMAGEN DEL CACHÉ PARA PREVIEW
            Dim cachedImage As Image = Nothing
            If _imageCache.TryGetValue(iconInfo.FullPath, cachedImage) Then
                picPreview.Image = New Bitmap(cachedImage)
            End If

            If _selectedImage IsNot Nothing Then _selectedImage.Dispose()
            If _imageCache.TryGetValue(iconInfo.FullPath, cachedImage) Then
                _selectedImage = New Bitmap(cachedImage)
            End If

            _selectedImagePath = iconInfo.FullPath
            _selectedImageSource = ImageSource.RasterImage
            _resourceName = iconInfo.BaseName

            HighlightSelectedIcon(sender)

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en RasterIcon_Click: {ex.Message}")
        End Try
    End Sub

    Private Sub HighlightSelectedIcon(selectedControl As Object)
        For Each control As Control In flowRasterIcons.Controls
            If TypeOf control Is Panel Then
                control.BackColor = Color.White
            End If
        Next

        If TypeOf selectedControl Is PictureBox Then
            Dim pic As PictureBox = DirectCast(selectedControl, PictureBox)
            If TypeOf pic.Parent Is Panel Then
                pic.Parent.BackColor = Color.FromArgb(180, 220, 255)
            End If
        ElseIf TypeOf selectedControl Is Panel Then
            DirectCast(selectedControl, Panel).BackColor = Color.FromArgb(180, 220, 255)
        End If
    End Sub

#End Region

#Region "Limpieza - Liberar Caché"

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        ' Liberar todas las imágenes del caché
        For Each img In _imageCache.Values
            Try
                img.Dispose()
            Catch
            End Try
        Next
        _imageCache.Clear()

        MyBase.OnFormClosed(e)
    End Sub

#End Region

#Region "Clase de Datos - IconInfo"

    Private Class IconInfo
        Public Property BaseName As String
        Public Property FullPath As String
        Public Property Category As String
        Public Property Size As String
        Public Property FileName As String
        Public Property IsFromDll As Boolean
    End Class

#End Region

#End Region

#Region "TAB: Vector Images"

    ' TODO: Implementar funcionalidad de imágenes vectoriales

#End Region

#Region "TAB: Font Icons"

    ' TODO: Implementar funcionalidad de iconos de fuentes

#End Region

#Region "Eventos del Formulario"

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl.SelectedIndexChanged
        If tabControl Is Nothing Then Return

        Select Case tabControl.SelectedIndex
            Case 0 ' Image Picker
            Case 1 ' Raster Images
            Case 2 ' Vector Images
            Case 3 ' Font Icons
        End Select
    End Sub

    Private Sub NXImagePickerDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabControl.SelectedIndex = 1
        rbProjectResource.Checked = True

        ' Inicializar tab de Raster Images
        InitializeRasterImagesTab()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If Me.DialogResult = DialogResult.Cancel Then ClearSelection()
        MyBase.OnFormClosing(e)
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

End Class