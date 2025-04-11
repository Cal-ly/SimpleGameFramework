using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Interfaces;
/// <summary>
/// Represents a logger for logging messages with different log levels.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs a message with the specified log level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="level">The log level of the message. Defaults to <see cref="LogLevel.Info"/>.</param>
    void Log(string message, LogLevel level = LogLevel.Info);
}
