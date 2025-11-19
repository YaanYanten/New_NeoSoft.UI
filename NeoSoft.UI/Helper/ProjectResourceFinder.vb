Imports System.IO
Imports System.Text.RegularExpressions

Namespace Helpers

    ''' <summary>
    ''' Helper para encontrar archivos de recursos (.resx) en proyectos de Visual Studio
    ''' </summary>
    Public Class ProjectResourceFinder

#Region "Clases de Datos"

        Public Class ResxFileInfo
            Public Property Name As String
            Public Property FullPath As String
            Public Property DisplayName As String
            Public Property ProjectName As String
            Public Property IsMainResource As Boolean

            Public Overrides Function ToString() As String
                Return DisplayName
            End Function
        End Class

        Private Class ProjectInfo
            Public Property Name As String
            Public Property FullPath As String
            Public Property Directory As String
        End Class

#End Region

#Region "Métodos Públicos"

        Public Shared Function FindResourceFiles(controlType As Type,
                                                Optional designerContext As ComponentModel.ITypeDescriptorContext = Nothing) As List(Of ResxFileInfo)
            Dim results As New List(Of ResxFileInfo)

            Try
                Dim assembly As Reflection.Assembly = controlType.Assembly
                Dim projectDir As String = FindProjectDirectory(assembly, designerContext)
                If String.IsNullOrEmpty(projectDir) Then Return results

                Dim slnFile As String = FindSolutionFile(projectDir)
                If Not String.IsNullOrEmpty(slnFile) Then
                    Dim projects As List(Of ProjectInfo) = ParseSolutionFile(slnFile)
                    For Each proj As ProjectInfo In projects
                        results.AddRange(FindResxInProject(proj))
                    Next
                Else
                    Dim currentProject As New ProjectInfo With {
                        .Name = Path.GetFileName(projectDir),
                        .FullPath = projectDir,
                        .Directory = projectDir
                    }
                    results.AddRange(FindResxInProject(currentProject))
                End If

                results = results.OrderByDescending(Function(r) r.IsMainResource).
                                 ThenBy(Function(r) r.ProjectName).
                                 ThenBy(Function(r) r.Name).ToList()

            Catch ex As Exception
                Debug.WriteLine($"Error en FindResourceFiles: {ex.Message}")
            End Try

            Return results
        End Function

#End Region

#Region "Búsqueda de Directorios"

        Private Shared Function FindProjectDirectory(assembly As Reflection.Assembly,
                                                     Optional designerContext As ComponentModel.ITypeDescriptorContext = Nothing) As String
            Try
                ' Método 1: Desde IDesignerHost
                If designerContext IsNot Nothing Then
                    Try
                        Dim serviceProvider As IServiceProvider = TryCast(designerContext, IServiceProvider)
                        If serviceProvider IsNot Nothing Then
                            Dim designerHost As ComponentModel.Design.IDesignerHost =
                                TryCast(serviceProvider.GetService(GetType(ComponentModel.Design.IDesignerHost)),
                                        ComponentModel.Design.IDesignerHost)

                            If designerHost IsNot Nothing AndAlso designerHost.RootComponent IsNot Nothing Then
                                Dim componentAssembly As Reflection.Assembly = designerHost.RootComponent.GetType().Assembly
                                If Not String.IsNullOrEmpty(componentAssembly.Location) AndAlso
                                   Not componentAssembly.Location.Contains("AppData") Then
                                    Dim projDir As String = SearchForProjectFile(Path.GetDirectoryName(componentAssembly.Location))
                                    If Not String.IsNullOrEmpty(projDir) Then Return projDir
                                End If
                            End If
                        End If
                    Catch
                    End Try
                End If

                ' Método 2: Desde assembly location
                Dim assemblyPath As String = assembly.Location

                If assemblyPath.Contains("AppData") OrElse assemblyPath.Contains("Temp") Then
                    Try
                        If Not String.IsNullOrEmpty(assembly.CodeBase) Then
                            Dim uri As New Uri(assembly.CodeBase)
                            Dim codeBasePath As String = uri.LocalPath

                            If codeBasePath.Contains("AppData") Then
                                ' Método 3: Buscar en ubicaciones comunes
                                Dim commonPaths As String() = {
                                    "C:\Users\" & Environment.UserName & "\source\repos",
                                    "C:\Users\" & Environment.UserName & "\Documents\Visual Studio 2022\Projects",
                                    "C:\Users\" & Environment.UserName & "\Documents\Visual Studio 2019\Projects",
                                    "C:\Projects",
                                    "C:\Proyectos",
                                    "C:\Users\" & Environment.UserName & "\Desktop"
                                }

                                Dim projectName As String = assembly.GetName().Name
                                For Each commonPath As String In commonPaths
                                    If Directory.Exists(commonPath) Then
                                        Try
                                            Dim foundProjects As String() = Directory.GetFiles(commonPath, $"*{projectName}*.vbproj", SearchOption.AllDirectories)
                                            If foundProjects.Length > 0 Then Return Path.GetDirectoryName(foundProjects(0))

                                            foundProjects = Directory.GetFiles(commonPath, $"*{projectName}*.csproj", SearchOption.AllDirectories)
                                            If foundProjects.Length > 0 Then Return Path.GetDirectoryName(foundProjects(0))
                                        Catch
                                        End Try
                                    End If
                                Next
                                Return Nothing
                            Else
                                assemblyPath = codeBasePath
                            End If
                        End If
                    Catch
                    End Try
                End If

                If String.IsNullOrEmpty(assemblyPath) OrElse Not File.Exists(assemblyPath) Then Return Nothing
                Return SearchForProjectFile(Path.GetDirectoryName(assemblyPath))

            Catch ex As Exception
                Debug.WriteLine($"Error en FindProjectDirectory: {ex.Message}")
            End Try

            Return Nothing
        End Function

        Private Shared Function SearchForProjectFile(startPath As String) As String
            Try
                Dim currentDir As New DirectoryInfo(startPath)
                Dim maxLevels As Integer = 10
                Dim level As Integer = 0

                While currentDir IsNot Nothing AndAlso level < maxLevels
                    Dim projectFiles As String() = Directory.GetFiles(currentDir.FullName, "*.vbproj")
                    If projectFiles.Length = 0 Then
                        projectFiles = Directory.GetFiles(currentDir.FullName, "*.csproj")
                    End If

                    If projectFiles.Length > 0 Then Return currentDir.FullName

                    currentDir = currentDir.Parent
                    level += 1
                End While
            Catch
            End Try

            Return Nothing
        End Function

        Private Shared Function FindSolutionFile(startDirectory As String) As String
            Try
                Dim currentDir As New DirectoryInfo(startDirectory)
                Dim maxLevels As Integer = 5
                Dim level As Integer = 0

                While currentDir IsNot Nothing AndAlso level < maxLevels
                    Dim slnFiles As String() = Directory.GetFiles(currentDir.FullName, "*.sln")
                    If slnFiles.Length > 0 Then Return slnFiles(0)

                    currentDir = currentDir.Parent
                    level += 1
                End While
            Catch
            End Try

            Return Nothing
        End Function

#End Region

#Region "Parseo de Solución"

        Private Shared Function ParseSolutionFile(slnPath As String) As List(Of ProjectInfo)
            Dim projects As New List(Of ProjectInfo)

            Try
                Dim slnDirectory As String = Path.GetDirectoryName(slnPath)
                Dim slnContent As String = File.ReadAllText(slnPath)
                Dim projectPattern As String = "Project\(""{[^}]+}""\)\s*=\s*""([^""]+)""\s*,\s*""([^""]+)"""
                Dim matches As MatchCollection = Regex.Matches(slnContent, projectPattern)

                For Each match As Match In matches
                    Try
                        Dim projectName As String = match.Groups(1).Value
                        Dim projectRelativePath As String = match.Groups(2).Value
                        Dim projectFullPath As String = Path.GetFullPath(Path.Combine(slnDirectory, projectRelativePath))

                        If (projectFullPath.EndsWith(".vbproj", StringComparison.OrdinalIgnoreCase) OrElse
                            projectFullPath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase)) AndAlso
                            File.Exists(projectFullPath) Then

                            projects.Add(New ProjectInfo With {
                                .Name = projectName,
                                .FullPath = projectFullPath,
                                .Directory = Path.GetDirectoryName(projectFullPath)
                            })
                        End If
                    Catch
                        Continue For
                    End Try
                Next
            Catch ex As Exception
                Debug.WriteLine($"Error parseando .sln: {ex.Message}")
            End Try

            Return projects
        End Function

#End Region

#Region "Búsqueda de .resx"

        Private Shared Function FindResxInProject(project As ProjectInfo) As List(Of ResxFileInfo)
            Dim results As New List(Of ResxFileInfo)

            Try
                If Not Directory.Exists(project.Directory) Then Return results

                Dim resxFiles As String() = Directory.GetFiles(project.Directory, "*.resx", SearchOption.AllDirectories)

                For Each resxFile As String In resxFiles
                    Try
                        Dim relativePath As String = resxFile.Replace(project.Directory, "").TrimStart("\"c, "/"c)

                        ' Filtrar carpetas no deseadas
                        If relativePath.Contains("obj\") OrElse relativePath.Contains("bin\") OrElse
                           relativePath.Contains(".vs\") OrElse relativePath.Contains("packages\") OrElse
                           relativePath.Contains("BackupFiles\") Then
                            Continue For
                        End If

                        Dim fileName As String = Path.GetFileName(resxFile)

                        ' Solo Resources.resx principales
                        If Not fileName.Equals("Resources.resx", StringComparison.OrdinalIgnoreCase) Then
                            Continue For
                        End If

                        Dim folderName As String = Path.GetDirectoryName(relativePath)
                        If String.IsNullOrEmpty(folderName) Then folderName = "(raíz)"

                        Dim isMainResource As Boolean = folderName.Contains("My Project") OrElse
                                                       folderName.Contains("Properties") OrElse
                                                       folderName = "(raíz)"

                        If isMainResource Then
                            results.Add(New ResxFileInfo With {
                                .Name = fileName,
                                .FullPath = resxFile,
                                .DisplayName = $"{fileName} [{project.Name}]",
                                .ProjectName = project.Name,
                                .IsMainResource = True
                            })
                        End If
                    Catch
                        Continue For
                    End Try
                Next
            Catch ex As Exception
                Debug.WriteLine($"Error en FindResxInProject: {ex.Message}")
            End Try

            Return results
        End Function

#End Region

    End Class

End Namespace