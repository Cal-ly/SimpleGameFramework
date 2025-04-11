using System.Text.Json;
using SimpleGameLibrary.Core;

namespace SimpleGameLibrary.Config;

/// <summary>
/// Provides functionality to load game configuration from a JSON file.
/// </summary>
public static class ConfigLoaderJSON
{
    /// <summary>
    /// Loads the game configuration from the specified file path.
    /// </summary>
    /// <param name="path">The relative or absolute path to the configuration file. Defaults to "gameconfig.json".</param>
    /// <returns>The loaded <see cref="GameConfig"/> object containing the game settings.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the configuration file is not found at the specified path.</exception>
    /// <exception cref="JsonException">Thrown when the JSON content in the file is invalid or cannot be deserialized.</exception>
    public static GameConfig Load(string path = "gameconfig.json")
    {
        // Get the full path of the configuration file
        string fullPath = ConfigHelper.GetConfigFilePath(path);

        // Ensure the file exists
        if (!File.Exists(fullPath))
            throw new FileNotFoundException("Configuration file not found.", fullPath);

        // Read and deserialize the JSON content
        var json = File.ReadAllText(fullPath);
        return JsonSerializer.Deserialize<GameConfig>(json) ?? new GameConfig();
    }
}
