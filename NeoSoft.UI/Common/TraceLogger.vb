Imports System.IO
Imports System.Text

''' <summary>
''' Logger que escribe a archivo para diagnóstico cuando Debug.WriteLine no funciona
''' </summary>
Public Class TraceLogger
    Private Shared _logFilePath As String = Nothing
    Private Shared _lockObject As New Object()
    Private Shared _isInitialized As Boolean = False

    ''' <summary>
    ''' Inicializa el logger y crea el archivo de log
    ''' </summary>
    Public Shared Sub Initialize()
        If _isInitialized Then Return

        Try
            Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            _logFilePath = Path.Combine(desktopPath, "NeoSoft_TraceLogger.txt")

            If File.Exists(_logFilePath) Then
                File.AppendAllText(_logFilePath, vbCrLf & vbCrLf &
                                     "═══════════════════════════════════════════════════════════════" & vbCrLf &
                                     $"NUEVA SESIÓN: {DateTime.Now:yyyy-MM-dd HH:mm:ss}" & vbCrLf &
                                     "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf)
            Else
                File.WriteAllText(_logFilePath,
                                    "═══════════════════════════════════════════════════════════════" & vbCrLf &
                                    "NeoSoft.UI - Trace Logger" & vbCrLf &
                                    $"Iniciado: {DateTime.Now:yyyy-MM-dd HH:mm:ss}" & vbCrLf &
                                    $"Usuario: {Environment.UserName}" & vbCrLf &
                                    $"Computadora: {Environment.MachineName}" & vbCrLf &
                                    "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf)
            End If

            _isInitialized = True
            WriteLine("✅ TraceLogger inicializado correctamente")
            WriteLine($"📁 Archivo de log: {_logFilePath}")
            WriteLine("")

        Catch ex As Exception
            Try
                _logFilePath = Path.Combine(Path.GetTempPath(), "NeoSoft_TraceLogger.txt")
                File.WriteAllText(_logFilePath, $"[{DateTime.Now:HH:mm:ss.fff}] Logger inicializado en TEMP{vbCrLf}")
                _isInitialized = True
            Catch
                _isInitialized = False
            End Try
        End Try
    End Sub

    ''' <summary>
    ''' Escribe una línea en el log (acepta interpolación de strings)
    ''' </summary>
    Public Shared Sub WriteLine(message As String)
        If Not _isInitialized Then Initialize()
        If Not _isInitialized Then Return

        Try
            SyncLock _lockObject
                Dim timestamp As String = DateTime.Now.ToString("HH:mm:ss.fff")
                ' ⭐ Escapar llaves para evitar FormatException
                Dim safeMessage = message.Replace("{", "{{").Replace("}", "}}")
                Dim logLine As String = $"[{timestamp}] {safeMessage}{vbCrLf}"
                File.AppendAllText(_logFilePath, logLine)
            End SyncLock
        Catch ex As Exception
            ' Silencioso si falla
        End Try
    End Sub

    ''' <summary>
    ''' Escribe con información de contexto
    ''' </summary>
    Public Shared Sub LogDebug(context As String, message As String)
        WriteLine($"{context} {message}")
    End Sub

    Public Shared Sub LogInfo(context As String, message As String)
        WriteLine($"ℹ️ {context} {message}")
    End Sub

    Public Shared Sub LogWarning(context As String, message As String)
        WriteLine($"⚠️ {context} {message}")
    End Sub

    Public Shared Sub LogError(context As String, message As String, Optional ex As Exception = Nothing)
        WriteLine($"❌ {context} {message}")
        If ex IsNot Nothing Then
            WriteException(ex, context)
        End If
    End Sub

    ''' <summary>
    ''' Escribe una línea vacía
    ''' </summary>
    Public Shared Sub WriteLine()
        WriteLine("")
    End Sub

    ''' <summary>
    ''' Escribe un separador visual
    ''' </summary>
    Public Shared Sub WriteSeparator(Optional title As String = "")
        If String.IsNullOrEmpty(title) Then
            WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━")
        Else
            WriteLine($"━━━ {title} ━━━")
        End If
    End Sub

    ''' <summary>
    ''' Escribe información de excepción
    ''' </summary>
    Public Shared Sub WriteException(ex As Exception, Optional context As String = "")
        If Not String.IsNullOrEmpty(context) Then
            WriteLine($"❌ EXCEPCIÓN EN: {context}")
        Else
            WriteLine("❌ EXCEPCIÓN:")
        End If
        WriteLine($"   Tipo: {ex.GetType().FullName}")
        WriteLine($"   Mensaje: {ex.Message}")
        WriteLine($"   Stack Trace:")
        For Each line As String In ex.StackTrace.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            WriteLine($"      {line.Trim()}")
        Next

        If ex.InnerException IsNot Nothing Then
            WriteLine("")
            WriteLine("   Inner Exception:")
            WriteLine($"      Tipo: {ex.InnerException.GetType().FullName}")
            WriteLine($"      Mensaje: {ex.InnerException.Message}")
        End If
        WriteLine("")
    End Sub

    Public Shared Sub OpenLog()
        If Not _isInitialized Then Initialize()
        If Not _isInitialized OrElse String.IsNullOrEmpty(_logFilePath) Then Return

        Try
            If File.Exists(_logFilePath) Then
                Process.Start("notepad.exe", _logFilePath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared ReadOnly Property LogFilePath As String
        Get
            If Not _isInitialized Then Initialize()
            Return _logFilePath
        End Get
    End Property

    Public Shared Sub Clear()
        If Not _isInitialized Then Initialize()
        If Not _isInitialized OrElse String.IsNullOrEmpty(_logFilePath) Then Return

        Try
            SyncLock _lockObject
                File.WriteAllText(_logFilePath, $"[{DateTime.Now:HH:mm:ss.fff}] Log limpiado{vbCrLf}")
            End SyncLock
        Catch ex As Exception
        End Try
    End Sub

End Class