using System.Diagnostics;

namespace SimpleGameLibrary.Logging;

/// <summary>
/// Provides logging functionality for the game.
/// </summary>
/// <remarks> Be aware, this is cleartext. Do NOT pass sensitive information</remarks>
public static class GameLogger
{
    private static bool _isInitialized = false;

    /// <summary>
    /// Gets or sets the minimum log level for logging messages.
    /// </summary>
    public static LogLevel MinimumLevel { get; set; } = LogLevel.Info;

    /// <summary>
    /// Initializes the logger with the specified log file path and log level.
    /// </summary>
    /// <param name="logFilePath">The path to the log file. Defaults to "game_log.txt".</param>
    /// <param name="level">The minimum log level. Defaults to <see cref="LogLevel.Info"/>.</param>
    public static void Init(string logFilePath = "game_log.txt", LogLevel level = LogLevel.Info)
    {
        if (_isInitialized) return;

        MinimumLevel = level;

        Trace.Listeners.Clear();

        var fileListener = new TextWriterTraceListener(logFilePath);
        Trace.Listeners.Add(fileListener);

        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;

        _isInitialized = true;
        Log(LogLevel.Info, "Logger initialized");
    }

    /// <summary>
    /// Logs a message with the specified log level.
    /// </summary>
    /// <param name="level">The log level of the message.</param>
    /// <param name="message">The message to log.</param>
    public static void Log(LogLevel level, string message)
    {
        if (level < MinimumLevel) return;

        string tag = level.ToString().ToUpper();
        string output = $"[{DateTime.Now:HH:mm:ss}] [{tag}] {message}";

        if (level >= LogLevel.Warning)
        {
            Console.ForegroundColor = level switch
            {
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                _ => Console.ForegroundColor
            };
        }

        Trace.WriteLine(output);

        if (level >= LogLevel.Warning)
        {
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="msg">The message to log.</param>
    public static void Debug(string msg) => Log(LogLevel.Debug, msg);

    /// <summary>
    /// Logs an info message.
    /// </summary>
    /// <param name="msg">The message to log.</param>
    public static void Info(string msg) => Log(LogLevel.Info, msg);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="msg">The message to log.</param>
    public static void Warn(string msg) => Log(LogLevel.Warning, msg);

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="msg">The message to log.</param>
    public static void Error(string msg) => Log(LogLevel.Error, msg);
}
