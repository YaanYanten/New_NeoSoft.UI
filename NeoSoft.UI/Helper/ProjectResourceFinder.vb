Imports System.IO
Imports System.Text.RegularExpressions
Imports NeoSoft.UI.Common

Namespace Helpers

    ''' <summary>
    ''' Helper para encontrar archivos de recursos (.resx) en proyectos de Visual Studio
    ''' SIN usar DTE - Solo lectura directa del sistema de archivos
    ''' </summary>
    Public Class ProjectResourceFinder

#Region "Clases de Datos"

        ''' <summary>
        ''' Información de un archivo .resx encontrado
        ''' </summary>
        Public Class ResxFileInfo
            Public Property Name As String
            Public Property FullPath As String
            Public Property DisplayName As String
            Public Property ProjectName As String
            Public Property IsMainResource As Boolean ' True si es Resources.resx principal

            Public Overrides Function ToString() As String
                Return DisplayName
            End Function
        End Class

        ''' <summary>
        ''' Información de un proyecto encontrado
        ''' </summary>
        Private Class ProjectInfo
            Public Property Name As String
            Public Property FullPath As String
            Public Property Directory As String
        End Class

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Encuentra todos los archivos .resx desde un Type de control Y contexto del diseñador
        ''' </summary>
        Public Shared Function FindResourceFiles(controlType As Type, Optional designerContext As ComponentModel.ITypeDescriptorContext = Nothing) As List(Of ResxFileInfo)
            TraceLogger.WriteLine("")
            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
            TraceLogger.WriteLine("=== ProjectResourceFinder: Búsqueda de Archivos .resx ===")
            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
            TraceLogger.WriteLine("")

            Dim results As New List(Of ResxFileInfo)

            Try
                ' 1. Obtener información del assembly
                Dim assembly As Reflection.Assembly = controlType.Assembly
                TraceLogger.WriteLine($"📦 Assembly: {assembly.GetName().Name}")
                TraceLogger.WriteLine($"   Location: {assembly.Location}")

                ' 2. Buscar el directorio del proyecto (con contexto del diseñador)
                Dim projectDir As String = FindProjectDirectory(assembly, designerContext)
                If String.IsNullOrEmpty(projectDir) Then
                    TraceLogger.WriteLine("❌ No se pudo encontrar el directorio del proyecto")
                    Return results
                End If

                TraceLogger.WriteLine($"✅ Directorio del proyecto encontrado: {projectDir}")

                ' 3. Buscar archivo .sln
                Dim slnFile As String = FindSolutionFile(projectDir)
                If Not String.IsNullOrEmpty(slnFile) Then
                    TraceLogger.WriteLine($"✅ Archivo .sln encontrado: {Path.GetFileName(slnFile)}")

                    ' 4. Parsear .sln y buscar todos los proyectos
                    Dim projects As List(Of ProjectInfo) = ParseSolutionFile(slnFile)
                    TraceLogger.WriteLine($"📊 Total de proyectos en la solución: {projects.Count}")

                    ' 5. Buscar archivos .resx en cada proyecto
                    For Each proj As ProjectInfo In projects
                        TraceLogger.WriteLine($"   🔍 Buscando en proyecto: {proj.Name}")
                        Dim resxFiles As List(Of ResxFileInfo) = FindResxInProject(proj)
                        results.AddRange(resxFiles)
                    Next

                Else
                    ' Si no hay .sln, buscar solo en el proyecto actual
                    TraceLogger.WriteLine("⚠️ No se encontró archivo .sln, buscando en proyecto actual...")
                    Dim currentProject As New ProjectInfo With {
                        .Name = Path.GetFileName(projectDir),
                        .FullPath = projectDir,
                        .Directory = projectDir
                    }
                    Dim resxFiles As List(Of ResxFileInfo) = FindResxInProject(currentProject)
                    results.AddRange(resxFiles)
                End If

                ' 6. Ordenar resultados: Resources.resx primero
                results = results.OrderByDescending(Function(r) r.IsMainResource).
                                 ThenBy(Function(r) r.ProjectName).
                                 ThenBy(Function(r) r.Name).ToList()

                TraceLogger.WriteLine("")
                TraceLogger.WriteLine($"✅ Total de archivos .resx encontrados: {results.Count}")
                If results.Count > 0 Then
                    TraceLogger.WriteLine("📋 Archivos encontrados:")
                    For i As Integer = 0 To Math.Min(results.Count - 1, 9)
                        Dim prefix As String = If(results(i).IsMainResource, "⭐", "  ")
                        TraceLogger.WriteLine($"{prefix} {i + 1}. {results(i).DisplayName}")
                    Next
                    If results.Count > 10 Then
                        TraceLogger.WriteLine($"   ... y {results.Count - 10} más")
                    End If
                End If
                TraceLogger.WriteLine("")

            Catch ex As Exception
                TraceLogger.WriteLine("❌ ERROR en FindResourceFiles:")
                TraceLogger.WriteException(ex)
            End Try

            TraceLogger.WriteLine("════════════════════════════════════════════════════════════")
            Return results
        End Function

#End Region

#Region "Métodos Privados - Búsqueda de Directorios"

        ''' <summary>
        ''' Encuentra el directorio del proyecto desde el assembly O desde el contexto del diseñador
        ''' </summary>
        Private Shared Function FindProjectDirectory(assembly As Reflection.Assembly, Optional designerContext As ComponentModel.ITypeDescriptorContext = Nothing) As String
            Try
                ' MÉTODO 1: Intentar obtener la ruta desde IDesignerHost (MEJOR OPCIÓN)
                If designerContext IsNot Nothing Then
                    TraceLogger.WriteLine("🔍 Intentando obtener ruta desde IDesignerHost...")

                    Try
                        Dim serviceProvider As IServiceProvider = TryCast(designerContext, IServiceProvider)
                        If serviceProvider IsNot Nothing Then
                            ' Obtener IDesignerHost
                            Dim designerHost As ComponentModel.Design.IDesignerHost =
                                TryCast(serviceProvider.GetService(GetType(ComponentModel.Design.IDesignerHost)),
                                        ComponentModel.Design.IDesignerHost)

                            If designerHost IsNot Nothing Then
                                TraceLogger.WriteLine("   ✅ IDesignerHost obtenido")

                                ' Obtener el componente raíz (Form o UserControl)
                                Dim rootComponent As ComponentModel.IComponent = designerHost.RootComponent
                                If rootComponent IsNot Nothing Then
                                    TraceLogger.WriteLine($"   Root Component: {rootComponent.GetType().Name}")

                                    ' Obtener IReferenceService para acceder a la información del proyecto
                                    Dim refService As ComponentModel.Design.IReferenceService =
                                        TryCast(serviceProvider.GetService(GetType(ComponentModel.Design.IReferenceService)),
                                                ComponentModel.Design.IReferenceService)

                                    If refService IsNot Nothing Then
                                        TraceLogger.WriteLine("   ✅ IReferenceService obtenido")
                                    End If

                                    ' Intentar obtener el archivo del formulario desde el ensamblado del componente
                                    Dim componentAssembly As Reflection.Assembly = rootComponent.GetType().Assembly
                                    TraceLogger.WriteLine($"   Component Assembly: {componentAssembly.GetName().Name}")
                                    TraceLogger.WriteLine($"   Component Location: {componentAssembly.Location}")

                                    ' Si el Location del componente NO está en AppData, úsalo
                                    If Not String.IsNullOrEmpty(componentAssembly.Location) AndAlso
                                       Not componentAssembly.Location.Contains("AppData") Then
                                        Dim componentDir As String = Path.GetDirectoryName(componentAssembly.Location)
                                        TraceLogger.WriteLine($"   ✅ Usando ruta del componente: {componentDir}")

                                        ' Buscar .vbproj/.csproj desde esta ubicación
                                        Dim projDir As String = SearchForProjectFile(componentDir)
                                        If Not String.IsNullOrEmpty(projDir) Then
                                            Return projDir
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        TraceLogger.WriteLine($"   ⚠️ Error en método IDesignerHost: {ex.Message}")
                    End Try
                End If

                ' MÉTODO 2: Intentar obtener la ruta del assembly (FALLBACK)
                Dim assemblyPath As String = assembly.Location

                ' Si está en AppData (temporal de VS), usar CodeBase
                If assemblyPath.Contains("AppData") OrElse assemblyPath.Contains("Temp") Then
                    Try
                        ' Intentar con CodeBase primero
                        If Not String.IsNullOrEmpty(assembly.CodeBase) Then
                            Dim uri As New Uri(assembly.CodeBase)
                            Dim codeBasePath As String = uri.LocalPath
                            TraceLogger.WriteLine($"   📁 Usando CodeBase: {codeBasePath}")

                            ' Si CodeBase también está en AppData, necesitamos otra estrategia
                            If codeBasePath.Contains("AppData") Then
                                TraceLogger.WriteLine($"   ⚠️ CodeBase también está en AppData")
                                TraceLogger.WriteLine($"   🔍 Buscando archivos .resx en todo el sistema...")

                                ' MÉTODO 3: Buscar en las unidades comunes del sistema
                                Dim commonPaths As String() = {
                                    "C:\Projects",
                                    "C:\Proyectos",
                                    "C:\Users\" & Environment.UserName & "\Documents\Visual Studio 2022\Projects",
                                    "C:\Users\" & Environment.UserName & "\Documents\Visual Studio 2019\Projects",
                                    "C:\Users\" & Environment.UserName & "\source\repos",
                                    "C:\Users\" & Environment.UserName & "\Desktop"
                                }

                                For Each commonPath As String In commonPaths
                                    If Directory.Exists(commonPath) Then
                                        TraceLogger.WriteLine($"   Buscando en: {commonPath}")

                                        ' Buscar proyectos con nombre similar al assembly
                                        Dim projectName As String = assembly.GetName().Name
                                        Dim searchPattern As String = $"*{projectName}*.vbproj"

                                        Try
                                            Dim foundProjects As String() = Directory.GetFiles(commonPath, searchPattern, SearchOption.AllDirectories)
                                            If foundProjects.Length > 0 Then
                                                TraceLogger.WriteLine($"   ✅ Proyecto encontrado: {foundProjects(0)}")
                                                Return Path.GetDirectoryName(foundProjects(0))
                                            End If

                                            ' También buscar .csproj
                                            searchPattern = $"*{projectName}*.csproj"
                                            foundProjects = Directory.GetFiles(commonPath, searchPattern, SearchOption.AllDirectories)
                                            If foundProjects.Length > 0 Then
                                                TraceLogger.WriteLine($"   ✅ Proyecto encontrado: {foundProjects(0)}")
                                                Return Path.GetDirectoryName(foundProjects(0))
                                            End If
                                        Catch
                                            ' Ignorar errores de acceso a carpetas
                                        End Try
                                    End If
                                Next

                                Return Nothing ' No se encontró
                            Else
                                assemblyPath = codeBasePath
                            End If
                        End If
                    Catch ex As Exception
                        TraceLogger.WriteLine($"   ⚠️ Error usando CodeBase: {ex.Message}")
                    End Try
                End If

                If String.IsNullOrEmpty(assemblyPath) OrElse Not File.Exists(assemblyPath) Then
                    Return Nothing
                End If

                ' Buscar hacia arriba hasta encontrar un archivo .vbproj o .csproj
                Dim searchResult As String = SearchForProjectFile(Path.GetDirectoryName(assemblyPath))
                Return searchResult

            Catch ex As Exception
                TraceLogger.WriteLine($"⚠️ Error en FindProjectDirectory: {ex.Message}")
            End Try

            Return Nothing
        End Function

        ''' <summary>
        ''' Busca un archivo de proyecto (.vbproj o .csproj) subiendo niveles desde startPath
        ''' </summary>
        Private Shared Function SearchForProjectFile(startPath As String) As String
            Try
                Dim currentDir As New DirectoryInfo(startPath)
                Dim maxLevels As Integer = 10
                Dim level As Integer = 0

                While currentDir IsNot Nothing AndAlso level < maxLevels
                    TraceLogger.WriteLine($"   Nivel {level}: {currentDir.Name}")

                    ' Buscar archivos de proyecto
                    Dim projectFiles As String() = Directory.GetFiles(currentDir.FullName, "*.vbproj")
                    If projectFiles.Length = 0 Then
                        projectFiles = Directory.GetFiles(currentDir.FullName, "*.csproj")
                    End If

                    If projectFiles.Length > 0 Then
                        TraceLogger.WriteLine($"   ✅ Archivo de proyecto encontrado: {Path.GetFileName(projectFiles(0))}")
                        Return currentDir.FullName
                    End If

                    currentDir = currentDir.Parent
                    level += 1
                End While
            Catch ex As Exception
                TraceLogger.WriteLine($"   ⚠️ Error en SearchForProjectFile: {ex.Message}")
            End Try

            Return Nothing
        End Function

        ''' <summary>
        ''' Busca el archivo .sln en el directorio y directorios padres
        ''' </summary>
        Private Shared Function FindSolutionFile(startDirectory As String) As String
            Try
                Dim currentDir As New DirectoryInfo(startDirectory)
                Dim maxLevels As Integer = 5
                Dim level As Integer = 0

                While currentDir IsNot Nothing AndAlso level < maxLevels
                    Dim slnFiles As String() = Directory.GetFiles(currentDir.FullName, "*.sln")
                    If slnFiles.Length > 0 Then
                        Return slnFiles(0) ' Retornar el primer .sln encontrado
                    End If

                    currentDir = currentDir.Parent
                    level += 1
                End While

            Catch ex As Exception
                TraceLogger.WriteLine($"⚠️ Error en FindSolutionFile: {ex.Message}")
            End Try

            Return Nothing
        End Function

#End Region

#Region "Métodos Privados - Parseo de Solución"

        ''' <summary>
        ''' Parsea un archivo .sln y extrae la lista de proyectos
        ''' </summary>
        Private Shared Function ParseSolutionFile(slnPath As String) As List(Of ProjectInfo)
            Dim projects As New List(Of ProjectInfo)

            Try
                Dim slnDirectory As String = Path.GetDirectoryName(slnPath)
                Dim slnContent As String = File.ReadAllText(slnPath)

                ' Regex para encontrar proyectos en el .sln
                ' Formato: Project("{GUID}") = "ProjectName", "Path\To\Project.vbproj", "{GUID}"
                Dim projectPattern As String = "Project\(""{[^}]+}""\)\s*=\s*""([^""]+)""\s*,\s*""([^""]+)"""
                Dim matches As MatchCollection = Regex.Matches(slnContent, projectPattern)

                TraceLogger.WriteLine($"   Proyectos encontrados en .sln: {matches.Count}")

                For Each match As Match In matches
                    Try
                        Dim projectName As String = match.Groups(1).Value
                        Dim projectRelativePath As String = match.Groups(2).Value

                        ' Convertir ruta relativa a absoluta
                        Dim projectFullPath As String = Path.Combine(slnDirectory, projectRelativePath)
                        projectFullPath = Path.GetFullPath(projectFullPath)

                        ' Verificar que sea un proyecto VB o C#
                        If projectFullPath.EndsWith(".vbproj", StringComparison.OrdinalIgnoreCase) OrElse
                           projectFullPath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase) Then

                            If File.Exists(projectFullPath) Then
                                projects.Add(New ProjectInfo With {
                                    .Name = projectName,
                                    .FullPath = projectFullPath,
                                    .Directory = Path.GetDirectoryName(projectFullPath)
                                })

                                TraceLogger.WriteLine($"      ✅ {projectName}")
                            Else
                                TraceLogger.WriteLine($"      ⚠️ {projectName} (archivo no existe)")
                            End If
                        End If

                    Catch ex As Exception
                        TraceLogger.WriteLine($"      ⚠️ Error procesando proyecto: {ex.Message}")
                        Continue For
                    End Try
                Next

            Catch ex As Exception
                TraceLogger.WriteLine($"❌ Error parseando .sln: {ex.Message}")
            End Try

            Return projects
        End Function

#End Region

#Region "Métodos Privados - Búsqueda de .resx"

        ''' <summary>
        ''' Busca todos los archivos .resx en un proyecto
        ''' </summary>
        Private Shared Function FindResxInProject(project As ProjectInfo) As List(Of ResxFileInfo)
            Dim results As New List(Of ResxFileInfo)

            Try
                If Not Directory.Exists(project.Directory) Then
                    Return results
                End If

                ' Buscar todos los .resx en el proyecto (recursivo)
                Dim resxFiles As String() = Directory.GetFiles(project.Directory, "*.resx", SearchOption.AllDirectories)

                For Each resxFile As String In resxFiles
                    Try
                        Dim relativePath As String = resxFile.Replace(project.Directory, "").TrimStart("\"c, "/"c)

                        ' Filtrar carpetas no deseadas
                        If relativePath.Contains("obj\") OrElse
                   relativePath.Contains("bin\") OrElse
                   relativePath.Contains(".vs\") OrElse
                   relativePath.Contains("packages\") OrElse
                   relativePath.Contains("BackupFiles\") Then
                            Continue For
                        End If

                        Dim fileName As String = Path.GetFileName(resxFile)
                        Dim folderName As String = Path.GetDirectoryName(relativePath)

                        If String.IsNullOrEmpty(folderName) Then
                            folderName = "(raíz)"
                        End If

                        ' ⭐ FILTRO: SOLO Resources.resx PRINCIPALES
                        ' Ignorar archivos .resx de formularios (FormMain.resx, UserControl1.resx, etc.)
                        If Not fileName.Equals("Resources.resx", StringComparison.OrdinalIgnoreCase) Then
                            TraceLogger.WriteLine($"      ⏭️ Ignorando archivo no principal: {fileName}")
                            Continue For
                        End If

                        ' Detectar si es el Resources.resx principal
                        Dim isMainResource As Boolean = False

                        ' Verificar si está en My Project o Properties (ubicación estándar)
                        If folderName.Contains("My Project") OrElse folderName.Contains("Properties") Then
                            isMainResource = True
                        Else
                            ' Si está en la raíz del proyecto también se considera principal
                            If folderName = "(raíz)" Then
                                isMainResource = True
                            End If
                        End If

                        ' Solo agregar si es un Resources.resx principal
                        If isMainResource Then
                            Dim displayName As String = $"{fileName} [{project.Name}]"

                            results.Add(New ResxFileInfo With {
                        .Name = fileName,
                        .FullPath = resxFile,
                        .DisplayName = displayName,
                        .ProjectName = project.Name,
                        .IsMainResource = True
                    })

                            TraceLogger.WriteLine($"      ✅ Resources.resx principal agregado: {displayName}")
                        Else
                            TraceLogger.WriteLine($"      ⏭️ Ignorando Resources.resx no principal en: {folderName}")
                        End If

                    Catch ex As Exception
                        TraceLogger.WriteLine($"      ⚠️ Error procesando {Path.GetFileName(resxFile)}: {ex.Message}")
                        Continue For
                    End Try
                Next

            Catch ex As Exception
                TraceLogger.WriteLine($"❌ Error en FindResxInProject: {ex.Message}")
            End Try

            Return results
        End Function

#End Region

    End Class

End Namespace