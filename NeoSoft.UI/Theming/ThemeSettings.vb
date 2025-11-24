Imports Microsoft.Win32
Imports System

Namespace Theming

    ''' <summary>
    ''' Gestiona la persistencia del tema seleccionado en el Registry
    ''' </summary>
    Public Class ThemeSettings

#Region "Constantes"

        Private Const REGISTRY_KEY As String = "SOFTWARE\NeoSoft\UI"
        Private Const THEME_NAME_VALUE As String = "CurrentTheme"
        Private Const DEFAULT_THEME As String = "Default"

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Guarda el nombre del tema actual en el Registry
        ''' </summary>
        Public Shared Sub SaveCurrentTheme(themeName As String)
            Try
                Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY)
                    If key IsNot Nothing Then
                        key.SetValue(THEME_NAME_VALUE, themeName, RegistryValueKind.String)
                        Console.WriteLine($"✅ Tema guardado: {themeName}")
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine($"❌ Error al guardar tema: {ex.Message}")
            End Try
        End Sub

        ''' <summary>
        ''' Carga el nombre del tema desde el Registry
        ''' </summary>
        Public Shared Function LoadCurrentTheme() As String
            Try
                Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY)
                    If key IsNot Nothing Then
                        Dim themeName As Object = key.GetValue(THEME_NAME_VALUE)
                        If themeName IsNot Nothing Then
                            Console.WriteLine($"✅ Tema cargado: {themeName}")
                            Return themeName.ToString()
                        End If
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine($"❌ Error al cargar tema: {ex.Message}")
            End Try

            ' Si no hay tema guardado, retornar default
            Console.WriteLine($"ℹ️ Usando tema por defecto: {DEFAULT_THEME}")
            Return DEFAULT_THEME
        End Function

        ''' <summary>
        ''' Aplica el tema guardado a un formulario y sus controles
        ''' </summary>
        Public Shared Sub ApplyStoredThemeToForm(form As Form)
            Dim themeName As String = LoadCurrentTheme()

            ' Inicializar temas si no están inicializados
            If NXThemeManager.Instance.AvailableThemes.Count = 0 Then
                NXThemeManager.Instance.InitializeBuiltInThemes()
            End If

            ' Aplicar tema
            If NXThemeManager.Instance.AvailableThemes.ContainsKey(themeName) Then
                NXThemeManager.Instance.ApplyTheme(themeName)
                NXThemeHelper.ApplyThemeToForm(form, NXThemeManager.Instance.CurrentTheme)
                Console.WriteLine($"✅ Tema '{themeName}' aplicado a {form.Name}")
            Else
                ' Si el tema no existe, usar Default
                Console.WriteLine($"⚠️ Tema '{themeName}' no encontrado, usando Default")
                NXThemeManager.Instance.ApplyTheme(DEFAULT_THEME)
                NXThemeHelper.ApplyThemeToForm(form, NXThemeManager.Instance.CurrentTheme)
            End If
        End Sub

        ''' <summary>
        ''' Elimina la configuración guardada
        ''' </summary>
        Public Shared Sub ClearSettings()
            Try
                Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY, True)
                    If key IsNot Nothing Then
                        key.DeleteValue(THEME_NAME_VALUE, False)
                        Console.WriteLine("✅ Configuración de tema eliminada")
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine($"❌ Error al limpiar configuración: {ex.Message}")
            End Try
        End Sub

#End Region

    End Class

End Namespace