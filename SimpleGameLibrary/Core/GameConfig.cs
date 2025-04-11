namespace SimpleGameLibrary.Core;

/// <summary>
/// Represents the game configuration.
/// </summary>
public class GameConfig
{
    /// <summary>
    /// Gets or sets the world configuration.
    /// </summary>
    public WorldConfig World { get; set; } = new();

    /// <summary>
    /// Gets or sets the game level.
    /// </summary>
    public string GameLevel { get; set; } = "Normal";

    /// <summary>
    /// Gets or sets the logging configuration.
    /// </summary>
    public LoggingConfig Logging { get; set; } = new();
}

/// <summary>
/// Represents the world configuration.
/// </summary>
public class WorldConfig
{
    /// <summary>
    /// Gets or sets the width of the world.
    /// </summary>
    public int Width { get; set; } = 10;

    /// <summary>
    /// Gets or sets the height of the world.
    /// </summary>
    public int Height { get; set; } = 10;
}

/// <summary>
/// Represents the logging configuration.
/// </summary>
public class LoggingConfig
{
    /// <summary>
    /// Gets or sets the minimum logging level.
    /// </summary>
    public string MinimumLevel { get; set; } = "Info";

    /// <summary>
    /// Gets or sets the log file path.
    /// </summary>
    public string LogFilePath { get; set; } = "game_log.txt";
}
