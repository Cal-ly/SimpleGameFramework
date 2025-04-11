namespace SimpleGameLibrary.Config;
/// <summary>
/// Provides helper methods for configuration file operations.
/// </summary>
public static class ConfigHelper
{
    /// <summary>
    /// Gets the full path of a configuration file based on the provided relative file path.
    /// </summary>
    /// <param name="filePath">The relative path to the configuration file.</param>
    /// <returns>The full path to the configuration file.</returns>
    /// <exception cref="ArgumentException">Thrown when the provided file path is null, empty, or whitespace.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified configuration file does not exist.</exception>
    public static string GetConfigFilePath(string filePath)
    {
        var solutionRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..");
        string fullPath = Path.Combine(solutionRoot, filePath) ?? string.Empty;

        if (string.IsNullOrWhiteSpace(fullPath))
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

        if (!File.Exists(fullPath))
            throw new FileNotFoundException("The specified configuration file was not found.", fullPath);

        return fullPath;
    }
}
