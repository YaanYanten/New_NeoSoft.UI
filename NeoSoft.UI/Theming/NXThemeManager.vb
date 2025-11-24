Imports System.Drawing

Namespace Theming

    ''' <summary>
    ''' Gestor central de temas para todos los controles NX
    ''' </summary>
    Public Class NXThemeManager

#Region "Singleton"

        Private Shared _instance As NXThemeManager

        Public Shared ReadOnly Property Instance As NXThemeManager
            Get
                If _instance Is Nothing Then
                    _instance = New NXThemeManager()
                End If
                Return _instance
            End Get
        End Property

        Private Sub New()
            ' Cargar tema por defecto
            _currentTheme = CreateDefaultTheme()
        End Sub

#End Region

#Region "Campos Privados"

        Private _currentTheme As NXTheme
        Private _availableThemes As New Dictionary(Of String, NXTheme)

#End Region

#Region "Propiedades"

        Public ReadOnly Property CurrentTheme As NXTheme
            Get
                Return _currentTheme
            End Get
        End Property

        Public ReadOnly Property AvailableThemes As Dictionary(Of String, NXTheme)
            Get
                Return _availableThemes
            End Get
        End Property

#End Region

#Region "Eventos"

        Public Event ThemeChanged As EventHandler(Of ThemeChangedEventArgs)

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Aplica un tema a toda la aplicación
        ''' </summary>
        Public Sub ApplyTheme(themeName As String)
            If _availableThemes.ContainsKey(themeName) Then
                _currentTheme = _availableThemes(themeName)
                RaiseEvent ThemeChanged(Me, New ThemeChangedEventArgs(_currentTheme))
            End If
        End Sub

        ''' <summary>
        ''' Aplica un tema personalizado
        ''' </summary>
        Public Sub ApplyTheme(theme As NXTheme)
            _currentTheme = theme
            RaiseEvent ThemeChanged(Me, New ThemeChangedEventArgs(_currentTheme))
        End Sub

        ''' <summary>
        ''' Registra un tema personalizado
        ''' </summary>
        Public Sub RegisterTheme(themeName As String, theme As NXTheme)
            If Not _availableThemes.ContainsKey(themeName) Then
                _availableThemes.Add(themeName, theme)
            Else
                _availableThemes(themeName) = theme
            End If
        End Sub

        ''' <summary>
        ''' Inicializa los temas predefinidos
        ''' </summary>
        Public Sub InitializeBuiltInThemes()
            _availableThemes.Clear()

            _availableThemes.Add("Default", CreateDefaultTheme())
            _availableThemes.Add("Office2019", CreateOffice2019Theme())
            _availableThemes.Add("Material", CreateMaterialTheme())
            _availableThemes.Add("Fluent", CreateFluentTheme())
            _availableThemes.Add("VisualStudio", CreateVisualStudioTheme())
            _availableThemes.Add("Dark", CreateDarkTheme())
            _availableThemes.Add("HighContrast", CreateHighContrastTheme())
            _availableThemes.Add("Breeze", CreateBreezeTheme())
            _availableThemes.Add("Crystal", CreateCrystalTheme())
            _availableThemes.Add("Office2013", CreateOffice2013Theme())
        End Sub

#End Region

#Region "Temas Predefinidos"

        Private Function CreateDefaultTheme() As NXTheme
            Return New NXTheme With {
                .Name = "Default",
                .DisplayName = "Default (Windows)",
                .Description = "Tema por defecto del sistema",
                .BackColor = Color.White,
                .ForeColor = Color.FromArgb(33, 33, 33),
                .PrimaryColor = Color.FromArgb(0, 120, 215),
                .SecondaryColor = Color.FromArgb(118, 118, 118),
                .AccentColor = Color.FromArgb(0, 99, 177),
                .SuccessColor = Color.FromArgb(76, 175, 80),
                .WarningColor = Color.FromArgb(255, 152, 0),
                .ErrorColor = Color.FromArgb(244, 67, 54),
                .InfoColor = Color.FromArgb(33, 150, 243),
                .BorderColor = Color.FromArgb(200, 200, 200),
                .DisabledColor = Color.FromArgb(189, 189, 189),
                .HoverColor = Color.FromArgb(229, 241, 251),
                .PressedColor = Color.FromArgb(204, 228, 247),
                .ShadowColor = Color.FromArgb(100, 0, 0, 0),
                .FormBackColor = Color.FromArgb(245, 245, 245),
                .PanelBackColor = Color.White,
                .ControlBackColor = Color.White,
                .GroupHeaderBackColor = Color.FromArgb(245, 245, 245),
                .GroupForeColor = Color.FromArgb(33, 33, 33),
                .BorderRadius = 4,
                .ButtonBorderRadius = 4,
                .TextBoxBorderRadius = 4,
                .GroupBorderRadius = 8,
                .AnimationDuration = 200
            }
        End Function

        Private Function CreateOffice2019Theme() As NXTheme
            Return New NXTheme With {
                .Name = "Office2019",
                .DisplayName = "Office 2019",
                .Description = "Tema inspirado en Microsoft Office 2019",
                .BackColor = Color.White,
                .ForeColor = Color.FromArgb(68, 68, 68),
                .PrimaryColor = Color.FromArgb(43, 87, 154),
                .SecondaryColor = Color.FromArgb(118, 118, 118),
                .AccentColor = Color.FromArgb(0, 114, 198),
                .SuccessColor = Color.FromArgb(92, 184, 92),
                .WarningColor = Color.FromArgb(240, 173, 78),
                .ErrorColor = Color.FromArgb(217, 83, 79),
                .InfoColor = Color.FromArgb(91, 192, 222),
                .BorderColor = Color.FromArgb(171, 171, 171),
                .DisabledColor = Color.FromArgb(204, 204, 204),
                .HoverColor = Color.FromArgb(242, 242, 242),
                .PressedColor = Color.FromArgb(225, 225, 225),
                .ShadowColor = Color.FromArgb(80, 0, 0, 0),
                .FormBackColor = Color.FromArgb(243, 243, 243),
                .PanelBackColor = Color.White,
                .ControlBackColor = Color.White,
                .GroupHeaderBackColor = Color.FromArgb(242, 242, 242),
                .GroupForeColor = Color.FromArgb(68, 68, 68),
                .BorderRadius = 2,
                .ButtonBorderRadius = 2,
                .TextBoxBorderRadius = 2,
                .GroupBorderRadius = 2,
                .AnimationDuration = 150
            }
        End Function

        Private Function CreateMaterialTheme() As NXTheme
            Return New NXTheme With {
                .Name = "Material",
                .DisplayName = "Material Design",
                .Description = "Tema basado en Material Design de Google",
                .BackColor = Color.White,
                .ForeColor = Color.FromArgb(33, 33, 33),
                .PrimaryColor = Color.FromArgb(33, 150, 243),
                .SecondaryColor = Color.FromArgb(255, 64, 129),
                .AccentColor = Color.FromArgb(255, 215, 64),
                .SuccessColor = Color.FromArgb(76, 175, 80),
                .WarningColor = Color.FromArgb(255, 152, 0),
                .ErrorColor = Color.FromArgb(244, 67, 54),
                .InfoColor = Color.FromArgb(3, 169, 244),
                .BorderColor = Color.FromArgb(224, 224, 224),
                .DisabledColor = Color.FromArgb(189, 189, 189),
                .HoverColor = Color.FromArgb(245, 245, 245),
                .PressedColor = Color.FromArgb(238, 238, 238),
                .ShadowColor = Color.FromArgb(120, 0, 0, 0),
                .FormBackColor = Color.FromArgb(250, 250, 250),
                .PanelBackColor = Color.White,
                .ControlBackColor = Color.White,
                .GroupHeaderBackColor = Color.FromArgb(245, 245, 245),
                .GroupForeColor = Color.FromArgb(33, 33, 33),
                .BorderRadius = 4,
                .ButtonBorderRadius = 4,
                .TextBoxBorderRadius = 4,
                .GroupBorderRadius = 4,
                .AnimationDuration = 250
            }
        End Function

        Private Function CreateFluentTheme() As NXTheme
            Return New NXTheme With {
                .Name = "Fluent",
                .DisplayName = "Fluent Design",
                .Description = "Tema basado en Fluent Design System",
                .BackColor = Color.FromArgb(243, 243, 243),
                .ForeColor = Color.FromArgb(50, 49, 48),
                .PrimaryColor = Color.FromArgb(0, 120, 212),
                .SecondaryColor = Color.FromArgb(96, 94, 92),
                .AccentColor = Color.FromArgb(0, 99, 177),
                .SuccessColor = Color.FromArgb(16, 124, 16),
                .WarningColor = Color.FromArgb(255, 185, 0),
                .ErrorColor = Color.FromArgb(196, 43, 28),
                .InfoColor = Color.FromArgb(0, 120, 212),
                .BorderColor = Color.FromArgb(237, 235, 233),
                .DisabledColor = Color.FromArgb(200, 198, 196),
                .HoverColor = Color.FromArgb(237, 235, 233),
                .PressedColor = Color.FromArgb(225, 223, 221),
                .ShadowColor = Color.FromArgb(60, 0, 0, 0),
                .FormBackColor = Color.FromArgb(250, 249, 248),
                .PanelBackColor = Color.White,
                .ControlBackColor = Color.White,
                .GroupHeaderBackColor = Color.FromArgb(237, 235, 233),
                .GroupForeColor = Color.FromArgb(50, 49, 48),
                .BorderRadius = 2,
                .ButtonBorderRadius = 2,
                .TextBoxBorderRadius = 2,
                .GroupBorderRadius = 2,
                .AnimationDuration = 200
            }
        End Function

        Private Function CreateVisualStudioTheme() As NXTheme
            Return New NXTheme With {
                .Name = "VisualStudio",
                .DisplayName = "Visual Studio",
                .Description = "Tema inspirado en Visual Studio IDE",
                .BackColor = Color.FromArgb(37, 37, 38),
                .ForeColor = Color.FromArgb(241, 241, 241),
                .PrimaryColor = Color.FromArgb(0, 122, 204),
                .SecondaryColor = Color.FromArgb(104, 104, 104),
                .AccentColor = Color.FromArgb(0, 151, 251),
                .SuccessColor = Color.FromArgb(73, 177, 117),
                .WarningColor = Color.FromArgb(252, 207, 49),
                .ErrorColor = Color.FromArgb(244, 71, 71),
                .InfoColor = Color.FromArgb(90, 193, 232),
                .BorderColor = Color.FromArgb(63, 63, 70),
                .DisabledColor = Color.FromArgb(90, 90, 90),
                .HoverColor = Color.FromArgb(62, 62, 64),
                .PressedColor = Color.FromArgb(51, 51, 55),
                .ShadowColor = Color.FromArgb(100, 0, 0, 0),
                .FormBackColor = Color.FromArgb(45, 45, 48),
                .PanelBackColor = Color.FromArgb(37, 37, 38),
                .ControlBackColor = Color.FromArgb(37, 37, 38),
                .GroupHeaderBackColor = Color.FromArgb(62, 62, 64),
                .GroupForeColor = Color.FromArgb(241, 241, 241),
                .BorderRadius = 0,
                .ButtonBorderRadius = 0,
                .TextBoxBorderRadius = 0,
                .GroupBorderRadius = 0,
                .AnimationDuration = 150
            }
        End Function

        Private Function CreateDarkTheme() As NXTheme
            Return New NXTheme With {
                .Name = "Dark",
                .DisplayName = "Dark Mode",
                .Description = "Tema oscuro para reducir fatiga visual",
                .BackColor = Color.FromArgb(30, 30, 30),
                .ForeColor = Color.FromArgb(230, 230, 230),
                .PrimaryColor = Color.FromArgb(0, 122, 204),
                .SecondaryColor = Color.FromArgb(100, 100, 100),
                .AccentColor = Color.FromArgb(0, 153, 255),
                .SuccessColor = Color.FromArgb(76, 175, 80),
                .WarningColor = Color.FromArgb(255, 183, 77),
                .ErrorColor = Color.FromArgb(239, 83, 80),
                .InfoColor = Color.FromArgb(41, 182, 246),
                .BorderColor = Color.FromArgb(60, 60, 60),
                .DisabledColor = Color.FromArgb(80, 80, 80),
                .HoverColor = Color.FromArgb(50, 50, 50),
                .PressedColor = Color.FromArgb(40, 40, 40),
                .ShadowColor = Color.FromArgb(150, 0, 0, 0),
                .FormBackColor = Color.FromArgb(25, 25, 25),
                .PanelBackColor = Color.FromArgb(30, 30, 30),
                .ControlBackColor = Color.FromArgb(30, 30, 30),
                .GroupHeaderBackColor = Color.FromArgb(40, 40, 40),
                .GroupForeColor = Color.FromArgb(230, 230, 230),
                .BorderRadius = 4,
                .ButtonBorderRadius = 4,
                .TextBoxBorderRadius = 4,
                .GroupBorderRadius = 8,
                .AnimationDuration = 200
            }
        End Function

        Private Function CreateHighContrastTheme() As NXTheme
            Return New NXTheme With {
                .Name = "HighContrast",
                .DisplayName = "High Contrast",
                .Description = "Tema de alto contraste para accesibilidad",
                .BackColor = Color.Black,
                .ForeColor = Color.White,
                .PrimaryColor = Color.FromArgb(0, 255, 255),
                .SecondaryColor = Color.FromArgb(128, 128, 128),
                .AccentColor = Color.Yellow,
                .SuccessColor = Color.Lime,
                .WarningColor = Color.Yellow,
                .ErrorColor = Color.Red,
                .InfoColor = Color.Cyan,
                .BorderColor = Color.White,
                .DisabledColor = Color.FromArgb(128, 128, 128),
                .HoverColor = Color.FromArgb(0, 64, 64),
                .PressedColor = Color.FromArgb(0, 32, 32),
                .ShadowColor = Color.Transparent,
                .FormBackColor = Color.Black,
                .PanelBackColor = Color.Black,
                .ControlBackColor = Color.Black,
                .GroupHeaderBackColor = Color.FromArgb(0, 0, 0),
                .GroupForeColor = Color.White,
                .BorderRadius = 0,
                .ButtonBorderRadius = 0,
                .TextBoxBorderRadius = 0,
                .GroupBorderRadius = 0,
                .AnimationDuration = 0
            }
        End Function

        Private Function CreateBreezeTheme() As NXTheme
            Return New NXTheme With {
                .Name = "Breeze",
                .DisplayName = "Breeze",
                .Description = "Tema inspirado en KDE Breeze",
                .BackColor = Color.FromArgb(239, 240, 241),
                .ForeColor = Color.FromArgb(49, 54, 59),
                .PrimaryColor = Color.FromArgb(61, 174, 233),
                .SecondaryColor = Color.FromArgb(127, 140, 141),
                .AccentColor = Color.FromArgb(41, 128, 185),
                .SuccessColor = Color.FromArgb(39, 174, 96),
                .WarningColor = Color.FromArgb(243, 156, 18),
                .ErrorColor = Color.FromArgb(231, 76, 60),
                .InfoColor = Color.FromArgb(52, 152, 219),
                .BorderColor = Color.FromArgb(189, 195, 199),
                .DisabledColor = Color.FromArgb(149, 165, 166),
                .HoverColor = Color.FromArgb(220, 223, 228),
                .PressedColor = Color.FromArgb(189, 195, 199),
                .ShadowColor = Color.FromArgb(80, 0, 0, 0),
                .FormBackColor = Color.FromArgb(252, 252, 252),
                .PanelBackColor = Color.White,
                .ControlBackColor = Color.White,
                .GroupHeaderBackColor = Color.FromArgb(220, 223, 228),
                .GroupForeColor = Color.FromArgb(49, 54, 59),
                .BorderRadius = 3,
                .ButtonBorderRadius = 3,
                .TextBoxBorderRadius = 3,
                .GroupBorderRadius = 3,
                .AnimationDuration = 200
            }
        End Function

        Private Function CreateCrystalTheme() As NXTheme
            Return New NXTheme With {
                .Name = "Crystal",
                .DisplayName = "Crystal",
                .Description = "Tema cristalino con colores brillantes",
                .BackColor = Color.FromArgb(240, 248, 255),
                .ForeColor = Color.FromArgb(25, 25, 112),
                .PrimaryColor = Color.FromArgb(65, 105, 225),
                .SecondaryColor = Color.FromArgb(119, 136, 153),
                .AccentColor = Color.FromArgb(30, 144, 255),
                .SuccessColor = Color.FromArgb(60, 179, 113),
                .WarningColor = Color.FromArgb(255, 215, 0),
                .ErrorColor = Color.FromArgb(220, 20, 60),
                .InfoColor = Color.FromArgb(135, 206, 250),
                .BorderColor = Color.FromArgb(176, 196, 222),
                .DisabledColor = Color.FromArgb(211, 211, 211),
                .HoverColor = Color.FromArgb(230, 240, 255),
                .PressedColor = Color.FromArgb(200, 220, 255),
                .ShadowColor = Color.FromArgb(100, 70, 130, 180),
                .FormBackColor = Color.FromArgb(248, 248, 255),
                .PanelBackColor = Color.FromArgb(240, 248, 255),
                .ControlBackColor = Color.FromArgb(240, 248, 255),
                .GroupHeaderBackColor = Color.FromArgb(230, 240, 255),
                .GroupForeColor = Color.FromArgb(25, 25, 112),
                .BorderRadius = 6,
                .ButtonBorderRadius = 6,
                .TextBoxBorderRadius = 6,
                .GroupBorderRadius = 6,
                .AnimationDuration = 250
            }
        End Function

        Private Function CreateOffice2013Theme() As NXTheme
            Return New NXTheme With {
                .Name = "Office2013",
                .DisplayName = "Office 2013",
                .Description = "Tema inspirado en Microsoft Office 2013",
                .BackColor = Color.White,
                .ForeColor = Color.FromArgb(68, 68, 68),
                .PrimaryColor = Color.FromArgb(43, 87, 154),
                .SecondaryColor = Color.FromArgb(128, 128, 128),
                .AccentColor = Color.FromArgb(38, 114, 236),
                .SuccessColor = Color.FromArgb(92, 184, 92),
                .WarningColor = Color.FromArgb(240, 173, 78),
                .ErrorColor = Color.FromArgb(217, 83, 79),
                .InfoColor = Color.FromArgb(91, 192, 222),
                .BorderColor = Color.FromArgb(171, 171, 171),
                .DisabledColor = Color.FromArgb(204, 204, 204),
                .HoverColor = Color.FromArgb(239, 243, 248),
                .PressedColor = Color.FromArgb(217, 226, 238),
                .ShadowColor = Color.FromArgb(60, 0, 0, 0),
                .FormBackColor = Color.White,
                .PanelBackColor = Color.White,
                .ControlBackColor = Color.White,
                .GroupHeaderBackColor = Color.FromArgb(239, 243, 248),
                .GroupForeColor = Color.FromArgb(68, 68, 68),
                .BorderRadius = 0,
                .ButtonBorderRadius = 0,
                .TextBoxBorderRadius = 0,
                .GroupBorderRadius = 0,
                .AnimationDuration = 150
            }
        End Function

#End Region

    End Class

End Namespace