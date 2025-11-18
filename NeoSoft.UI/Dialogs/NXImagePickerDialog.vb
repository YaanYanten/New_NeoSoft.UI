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
        TraceLogger.Initialize()
        TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
        TraceLogger.WriteLine("NXImagePickerDialog - Constructor (Non-Modal Version)")
        TraceLogger.WriteLine("════════════════════════════════════════════════════════════")

        InitializeComponent()
        InitializeDialog()

        TraceLogger.WriteLine("✅ NXImagePickerDialog inicializado correctamente")
        TraceLogger.WriteLine("")
    End Sub

#End Region

#Region "Inicialización"

    Private Sub InitializeDialog()
        ' ⭐ CRÍTICO: Configuración para evitar bloqueo modal
        ' NO usar FixedDialog, usar Sizable para comportamiento no-modal
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        ' Tamaño mínimo para evitar que se haga muy pequeño
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
            lblVersion.Text = "NeoSoft.UI v1.0 - Image Picker Dialog (Non-Modal)"
        End If

        TraceLogger.WriteLine("✅ Configuración no-modal aplicada")
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
                    MessageBox.Show("Error al cargar la imagen:" & vbCrLf & ex.Message,
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub


    ''' <summary>
    ''' Botón para importar imagen al Resources.resx del proyecto
    ''' CORREGIDO: Importa al archivo seleccionado en el ComboBox (sin doble apertura)
    ''' </summary>
    Private Sub BtnImportProject_Click(sender As Object, e As EventArgs) Handles btnImportProject.Click
        ' Verificar que tenemos contexto del diseñador
        If _designerContext Is Nothing Then
            MessageBox.Show("No hay contexto de diseñador disponible." & vbCrLf &
                      "Esta función solo está disponible en tiempo de diseño.",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' ⭐ VERIFICAR QUE HAY UN ARCHIVO .RESX SELECCIONADO EN EL COMBO
        If cboResourceFiles Is Nothing OrElse cboResourceFiles.SelectedIndex < 0 Then
            MessageBox.Show("Por favor, selecciona un archivo de recursos en el ComboBox.",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar Imagen para agregar a Resources"
            ofd.Filter = "Archivos de Imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|" &
                        "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|ICO|*.ico|" &
                        "Todos los archivos|*.*"
            ofd.FilterIndex = 1
            ofd.Multiselect = False

            Dim dialogResult As DialogResult = ofd.ShowDialog()

            ' ⭐ SALIR SI SE CANCELA
            If dialogResult <> DialogResult.OK Then
                TraceLogger.WriteLine("ℹ️ Usuario canceló la selección de imagen")
                Return
            End If

            Try
                TraceLogger.WriteLine("=== IMPORTANDO IMAGEN A RESOURCES.RESX ===")
                TraceLogger.WriteLine($"Archivo seleccionado: {ofd.FileName}")

                ' ⭐ OBTENER EL ARCHIVO .RESX SELECCIONADO EN EL COMBO
                Dim selectedItem As Object = cboResourceFiles.SelectedItem

                If Not TypeOf selectedItem Is ProjectResourceFinder.ResxFileInfo Then
                    MessageBox.Show("Error: El item seleccionado no es válido.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim selectedResxInfo As ProjectResourceFinder.ResxFileInfo =
                DirectCast(selectedItem, ProjectResourceFinder.ResxFileInfo)

                Dim resxPath As String = selectedResxInfo.FullPath

                TraceLogger.WriteLine($"✅ Resources.resx seleccionado: {selectedResxInfo.DisplayName}")
                TraceLogger.WriteLine($"📍 Ruta: {resxPath}")

                If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then
                    TraceLogger.WriteLine($"❌ El archivo .resx no existe: {resxPath}")
                    MessageBox.Show("No se encontró el archivo de recursos seleccionado.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Obtener el directorio Resources del proyecto
                Dim resxDirectory As String = Path.GetDirectoryName(resxPath)
                Dim projectResourcesDir As String = Path.Combine(
                Path.GetDirectoryName(resxDirectory),
                "Resources")

                ' Crear carpeta Resources si no existe
                If Not Directory.Exists(projectResourcesDir) Then
                    Directory.CreateDirectory(projectResourcesDir)
                    TraceLogger.WriteLine($"📁 Carpeta Resources creada: {projectResourcesDir}")
                End If

                ' Copiar imagen a la carpeta Resources
                Dim originalFileName As String = Path.GetFileName(ofd.FileName)
                Dim targetPath As String = Path.Combine(projectResourcesDir, originalFileName)

                ' Verificar si ya existe y preguntar
                If File.Exists(targetPath) Then
                    Dim overwriteResult As DialogResult = MessageBox.Show(
                    $"El archivo '{originalFileName}' ya existe en Resources.{vbCrLf}{vbCrLf}" &
                    "¿Deseas reemplazarlo?",
                    "Archivo Existente",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question)

                    If overwriteResult = DialogResult.Cancel Then
                        Return
                    ElseIf overwriteResult = DialogResult.No Then
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
                TraceLogger.WriteLine($"✅ Imagen copiada a: {targetPath}")

                ' ⭐ Agregar al archivo .resx SELECCIONADO (no al principal)
                AddImageToResxFile(resxPath, targetPath,
                             Path.GetFileNameWithoutExtension(originalFileName))

                ' ⭐ RECARGAR MANUALMENTE SIN CAMBIAR SelectedIndex
                RefreshResourceList(selectedResxInfo)

                TraceLogger.WriteLine("✅ Imagen importada exitosamente")
                MessageBox.Show($"Imagen '{originalFileName}' agregada exitosamente a {selectedResxInfo.DisplayName}",
                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                TraceLogger.WriteLine($"❌ Error importando imagen: {ex.Message}")
                TraceLogger.WriteException(ex)
                MessageBox.Show("Error al importar la imagen:" & vbCrLf & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Recarga la lista de recursos para un archivo .resx específico SIN cambiar SelectedIndex
    ''' </summary>
    Private Sub RefreshResourceList(resxInfo As ProjectResourceFinder.ResxFileInfo)
        If lstProjectResources Is Nothing Then Return

        lstProjectResources.Items.Clear()

        ' Agregar item (empty) al inicio
        lstProjectResources.Items.Add(New ResourceImageInfo With {
        .Name = "(empty)",
        .Image = Nothing,
        .FilePath = ""
    })

        TraceLogger.WriteLine($"=== REFRESCANDO RECURSOS DEL ARCHIVO ===")
        TraceLogger.WriteLine($"📁 Archivo: {resxInfo.Name}")

        Try
            Dim resxPath As String = resxInfo.FullPath

            If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then
                TraceLogger.WriteLine($"❌ El archivo no existe: {resxPath}")
                Return
            End If

            Dim resxDirectory As String = Path.GetDirectoryName(resxPath)

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = resxDirectory

                Dim imageCount As Integer = 0

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

                            imageCount += 1
                        End If

                    Catch ex As Exception
                        TraceLogger.WriteLine($"  ⚠️ Error procesando recurso '{entry.Key}': {ex.Message}")

                        Try
                            Dim resourceName As String = entry.Key.ToString()
                            Dim manualImage As Image = LoadImageManually(resxPath, resourceName, resxDirectory)

                            If manualImage IsNot Nothing Then
                                lstProjectResources.Items.Add(New ResourceImageInfo With {
                                .Name = resourceName,
                                .Image = manualImage,
                                .FilePath = resxPath
                            })

                                imageCount += 1
                            End If
                        Catch manualEx As Exception
                            TraceLogger.WriteLine($"  ❌ Error en carga manual: {manualEx.Message}")
                        End Try

                        Continue For
                    End Try
                Next

                TraceLogger.WriteLine($"📊 Total de imágenes cargadas: {imageCount}")
            End Using

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ ERROR al refrescar recursos: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Agrega una imagen al archivo .resx
    ''' </summary>
    Private Sub AddImageToResxFile(resxPath As String, imagePath As String, resourceName As String)
        Try
            TraceLogger.WriteLine($"📝 Agregando imagen al .resx...")
            TraceLogger.WriteLine($"   .resx: {resxPath}")
            TraceLogger.WriteLine($"   Imagen: {imagePath}")
            TraceLogger.WriteLine($"   Nombre: {resourceName}")

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

            TraceLogger.WriteLine($"   Ruta relativa: {relativePath}")

            ' Crear ResXFileRef para la imagen
            Dim fileRef As New Resources.ResXFileRef(relativePath, GetType(Bitmap).AssemblyQualifiedName)

            ' Agregar o reemplazar el recurso
            If resources.ContainsKey(resourceName) Then
                resources(resourceName) = fileRef
                TraceLogger.WriteLine($"   ⚠️ Recurso '{resourceName}' reemplazado")
            Else
                resources.Add(resourceName, fileRef)
                TraceLogger.WriteLine($"   ✅ Recurso '{resourceName}' agregado")
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

            TraceLogger.WriteLine($"✅ Archivo .resx actualizado exitosamente")

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error en AddImageToResxFile: {ex.Message}")
            Throw
        End Try
    End Sub

    Private Sub BtnClearLocal_Click(sender As Object, e As EventArgs) Handles btnClearLocal.Click
        ' Limpiar preview
        If picPreview IsNot Nothing AndAlso picPreview.Image IsNot Nothing Then
            picPreview.Image.Dispose()
            picPreview.Image = Nothing
        End If

        ' Limpiar selección
        If _selectedImage IsNot Nothing Then
            _selectedImage.Dispose()
            _selectedImage = Nothing
        End If

        _selectedImagePath = ""
        _selectedImageSource = ImageSource.None
        _resourceName = ""

        TraceLogger.WriteLine("🗑️ Selección de imagen limpiada")
    End Sub

#End Region

#Region "Gestión de Recursos del Proyecto"

    Private Sub RbLocalResource_CheckedChanged(sender As Object, e As EventArgs) Handles rbLocalResource.CheckedChanged
        If rbLocalResource.Checked Then
            ' Habilitar controles locales
            btnImportLocal.Enabled = True
            btnClearLocal.Enabled = True

            ' Deshabilitar controles de proyecto
            cboResourceFiles.Enabled = False
            lstProjectResources.Enabled = False

            TraceLogger.WriteLine("📂 Modo: Recursos Locales")
        End If
    End Sub

    Private Sub RbProjectResource_CheckedChanged(sender As Object, e As EventArgs) Handles rbProjectResource.CheckedChanged
        If rbProjectResource.Checked Then
            ' Deshabilitar controles locales
            btnImportLocal.Enabled = False
            btnClearLocal.Enabled = False

            ' Habilitar controles de proyecto
            cboResourceFiles.Enabled = True
            lstProjectResources.Enabled = True

            ' Cargar recursos del proyecto
            LoadProjectResources()

            TraceLogger.WriteLine("📦 Modo: Recursos del Proyecto")
        End If
    End Sub

    Private Sub LstProjectResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProjectResources.SelectedIndexChanged
        If lstProjectResources.SelectedIndex < 0 Then Return

        Try
            Dim selectedItem As Object = lstProjectResources.SelectedItem

            If TypeOf selectedItem Is ResourceImageInfo Then
                Dim resourceInfo As ResourceImageInfo = DirectCast(selectedItem, ResourceImageInfo)

                ' ⭐ SI ES (empty), LIMPIAR LA IMAGEN
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

                    TraceLogger.WriteLine("🗑️ Selección limpiada - (empty) seleccionado")
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

                TraceLogger.WriteLine($"✅ Recurso del proyecto seleccionado: {resourceInfo.Name}")
            End If

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ Error al seleccionar recurso: {ex.Message}")
            MessageBox.Show("Error al cargar el recurso seleccionado:" & vbCrLf & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProjectResources()
        If cboResourceFiles Is Nothing OrElse lstProjectResources Is Nothing Then
            TraceLogger.WriteLine("⚠️ Controles no inicializados")
            Return
        End If

        cboResourceFiles.Items.Clear()
        lstProjectResources.Items.Clear()

        TraceLogger.WriteLine("")
        TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
        TraceLogger.WriteLine("=== CARGA DE RECURSOS DEL PROYECTO ===")
        TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
        TraceLogger.WriteLine("")

        If _designerContext Is Nothing Then
            TraceLogger.WriteLine("❌ CRÍTICO: _designerContext es Nothing")
            MessageBox.Show("No hay contexto de diseñador disponible." & vbCrLf &
                              "Esta función solo está disponible en tiempo de diseño.",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        TraceLogger.WriteLine("✅ _designerContext existe")

        Try
            If _designerContext.Instance Is Nothing Then
                TraceLogger.WriteLine("❌ _designerContext.Instance es Nothing")
                MessageBox.Show("No se pudo obtener el control que está siendo editado.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim controlType As Type = _designerContext.Instance.GetType()
            TraceLogger.WriteLine($"📦 Control Type: {controlType.FullName}")
            TraceLogger.WriteLine($"   Assembly: {controlType.Assembly.GetName().Name}")

            Dim resxFiles As List(Of ProjectResourceFinder.ResxFileInfo) =
                ProjectResourceFinder.FindResourceFiles(controlType, _designerContext)

            If resxFiles Is Nothing OrElse resxFiles.Count = 0 Then
                TraceLogger.WriteLine("⚠️ No se encontraron archivos .resx")
                MessageBox.Show("No se encontraron archivos de recursos (.resx) en el proyecto." & vbCrLf &
                              "Asegúrate de que tu proyecto contiene archivos .resx",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            For Each resxFile As ProjectResourceFinder.ResxFileInfo In resxFiles
                cboResourceFiles.Items.Add(resxFile)
            Next

            TraceLogger.WriteLine($"✅ {resxFiles.Count} archivos .resx cargados en el ComboBox")

            If cboResourceFiles.Items.Count > 0 Then
                cboResourceFiles.SelectedIndex = 0

                Dim firstFile As ProjectResourceFinder.ResxFileInfo =
                    DirectCast(cboResourceFiles.SelectedItem, ProjectResourceFinder.ResxFileInfo)
                TraceLogger.WriteLine($"📌 Archivo seleccionado por defecto: {firstFile.DisplayName}")
            End If

        Catch ex As Exception
            TraceLogger.WriteLine("")
            TraceLogger.WriteLine("❌ ERROR GENERAL EN LoadProjectResources:")
            TraceLogger.WriteException(ex)
            MessageBox.Show("Error al cargar recursos del proyecto:" & vbCrLf & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
        TraceLogger.WriteLine("")
    End Sub

    Private Sub CboResourceFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResourceFiles.SelectedIndexChanged
        If cboResourceFiles.SelectedIndex < 0 Then Return
        If lstProjectResources Is Nothing Then Return

        lstProjectResources.Items.Clear()

        ' ⭐ AGREGAR ITEM (empty) AL INICIO
        lstProjectResources.Items.Add(New ResourceImageInfo With {
        .Name = "(empty)",
        .Image = Nothing,
        .FilePath = ""
    })

        TraceLogger.WriteLine($"=== CARGANDO RECURSOS DEL ARCHIVO SELECCIONADO ===")

        Try
            Dim selectedItem As Object = cboResourceFiles.SelectedItem

            If Not TypeOf selectedItem Is ProjectResourceFinder.ResxFileInfo Then
                TraceLogger.WriteLine("⚠️ El item seleccionado no es un ResxFileInfo")
                Return
            End If

            Dim resxInfo As ProjectResourceFinder.ResxFileInfo =
            DirectCast(selectedItem, ProjectResourceFinder.ResxFileInfo)

            Dim resxPath As String = resxInfo.FullPath
            TraceLogger.WriteLine($"📁 Archivo seleccionado: {resxInfo.Name}")
            TraceLogger.WriteLine($"📍 Ruta completa: {resxPath}")

            If String.IsNullOrEmpty(resxPath) OrElse Not File.Exists(resxPath) Then
                TraceLogger.WriteLine($"❌ El archivo no existe: {resxPath}")
                MessageBox.Show("No se pudo encontrar el archivo de recursos.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim resxDirectory As String = Path.GetDirectoryName(resxPath)
            TraceLogger.WriteLine($"📂 Directorio base del .resx: {resxDirectory}")

            Using reader As New Resources.ResXResourceReader(resxPath)
                reader.BasePath = resxDirectory
                TraceLogger.WriteLine($"✅ BasePath configurado: {reader.BasePath}")

                Dim imageCount As Integer = 0

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

                            imageCount += 1
                            TraceLogger.WriteLine($"  ✅ Imagen encontrada: {resourceName}")
                        End If

                    Catch ex As Exception
                        TraceLogger.WriteLine($"  ⚠️ Error procesando recurso '{entry.Key}': {ex.Message}")

                        Try
                            Dim resourceName As String = entry.Key.ToString()
                            Dim manualImage As Image = LoadImageManually(resxPath, resourceName, resxDirectory)

                            If manualImage IsNot Nothing Then
                                lstProjectResources.Items.Add(New ResourceImageInfo With {
                                .Name = resourceName,
                                .Image = manualImage,
                                .FilePath = resxPath
                            })

                                imageCount += 1
                                TraceLogger.WriteLine($"  ✅ Imagen cargada manualmente: {resourceName}")
                            End If
                        Catch manualEx As Exception
                            TraceLogger.WriteLine($"  ❌ Error en carga manual: {manualEx.Message}")
                        End Try

                        Continue For
                    End Try
                Next

                TraceLogger.WriteLine($"📊 Total de imágenes cargadas: {imageCount}")

                If imageCount = 0 Then
                    MessageBox.Show("El archivo de recursos no contiene imágenes." & vbCrLf & vbCrLf &
                              "Esto puede deberse a que las imágenes tienen rutas relativas inválidas." & vbCrLf &
                              "Revisa el Output window para más detalles.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            TraceLogger.WriteLine($"❌ ERROR al cargar recursos: {ex.Message}")
            TraceLogger.WriteLine($"Stack Trace: {ex.StackTrace}")
            MessageBox.Show("Error al leer el archivo de recursos:" & vbCrLf & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function LoadImageManually(resxPath As String, resourceName As String, baseDirectory As String) As Image
        Try
            TraceLogger.WriteLine($"      🔍 Intentando carga manual de: {resourceName}")

            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(resxPath)

            Dim nsmgr As New Xml.XmlNamespaceManager(xmlDoc.NameTable)
            Dim dataNode As Xml.XmlNode = xmlDoc.SelectSingleNode($"//data[@name='{resourceName}']", nsmgr)

            If dataNode Is Nothing Then
                TraceLogger.WriteLine($"      ❌ No se encontró el nodo para: {resourceName}")
                Return Nothing
            End If

            Dim typeAttr As Xml.XmlAttribute = dataNode.Attributes("type")
            If typeAttr IsNot Nothing Then
                TraceLogger.WriteLine($"      📝 Tipo: {typeAttr.Value}")
            End If

            Dim valueNode As Xml.XmlNode = dataNode.SelectSingleNode("value")
            If valueNode Is Nothing Then
                TraceLogger.WriteLine($"      ❌ No se encontró el nodo value")
                Return Nothing
            End If

            Dim value As String = valueNode.InnerText.Trim()
            TraceLogger.WriteLine($"      📄 Value: {If(value.Length > 50, value.Substring(0, 50) & "...", value)}")

            If value.Contains(";") Then
                Dim parts As String() = value.Split(";"c)
                If parts.Length > 0 Then
                    Dim relativePath As String = parts(0).Trim()
                    TraceLogger.WriteLine($"      📁 Ruta relativa detectada: {relativePath}")

                    Dim fullPath As String = Path.Combine(baseDirectory, relativePath)
                    TraceLogger.WriteLine($"      🔗 Ruta completa: {fullPath}")

                    If File.Exists(fullPath) Then
                        TraceLogger.WriteLine($"      ✅ Archivo encontrado, cargando...")
                        Return Image.FromFile(fullPath)
                    Else
                        TraceLogger.WriteLine($"      ❌ Archivo no existe: {fullPath}")

                        Dim commonSubDirs As String() = {"Resources", "..\Resources", "..\..\Resources"}
                        For Each subDir As String In commonSubDirs
                            Dim altPath As String = Path.Combine(baseDirectory, subDir, Path.GetFileName(relativePath))
                            TraceLogger.WriteLine($"      🔍 Intentando: {altPath}")

                            If File.Exists(altPath) Then
                                TraceLogger.WriteLine($"      ✅ Encontrado en ubicación alternativa")
                                Return Image.FromFile(altPath)
                            End If
                        Next
                    End If
                End If
            ElseIf value.Length > 100 Then
                TraceLogger.WriteLine($"      📦 Detectado como Base64, intentando decodificar...")
                Try
                    Dim imageBytes As Byte() = Convert.FromBase64String(value)
                    Using ms As New MemoryStream(imageBytes)
                        Return Image.FromStream(ms)
                    End Using
                Catch base64Ex As Exception
                    TraceLogger.WriteLine($"      ❌ Error decodificando Base64: {base64Ex.Message}")
                End Try
            End If

        Catch ex As Exception
            TraceLogger.WriteLine($"      ❌ Error en LoadImageManually: {ex.Message}")
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

#End Region

End Class