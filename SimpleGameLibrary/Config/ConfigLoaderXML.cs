using SimpleGameLibrary.Core;
using System.IO;
using System.Xml.Linq;

namespace SimpleGameLibrary.Config;
/// <summary>
/// Provides functionality to load game configuration from an XML file.
/// </summary>
public static class ConfigLoaderXML
{
    /// <summary>
    /// Loads the game configuration from the specified XML file.
    /// </summary>
    /// <param name="path">The relative or absolute path to the XML configuration file. Defaults to "gameconfig.xml".</param>
    /// <returns>The loaded <see cref="GameConfig"/> object containing the game settings.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the configuration file is not found at the specified path.</exception>
    /// <exception cref="System.Xml.XmlException">Thrown when the XML content in the file is invalid or cannot be parsed.</exception>
    public static GameConfig Load(string path = "gameconfig.xml")
    {
        string fullPath = ConfigHelper.GetConfigFilePath(path);

        var document = XDocument.Load(fullPath);

        var config = new GameConfig
        {
            World = new WorldConfig
            {
                Width = int.Parse(document.Root?.Element("World")?.Element("Width")?.Value ?? "10"),
                Height = int.Parse(document.Root?.Element("World")?.Element("Height")?.Value ?? "10")
            },
            GameLevel = document.Root?.Element("GameLevel")?.Value ?? string.Empty,
            Logging = new LoggingConfig
            {
                MinimumLevel = document.Root?.Element("Logging")?.Element("MinimumLevel")?.Value ?? "Info",
                LogFilePath = document.Root?.Element("Logging")?.Element("LogFilePath")?.Value ?? "game_log.txt"
            }
        };

        return config;
    }
}
