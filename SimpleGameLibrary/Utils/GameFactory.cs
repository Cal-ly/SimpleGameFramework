namespace SimpleGameLibrary.Utils;

/// <summary>
/// Utility class for creating game objects using reflection.
/// </summary>
public static class GameFactory
{
    /// <summary>
    /// Creates an instance of a class by its type name.
    /// </summary>
    /// <typeparam name="T">The interface or base type to cast to.</typeparam>
    /// <param name="typeName">The full or simple name of the class.</param>
    /// <param name="args">Constructor arguments.</param>
    /// <returns>An instance of the type, or null if not found or failed.</returns>
    public static T? Create<T>(string typeName, params object[] args) where T : class
    {
        var type = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t =>
                typeof(T).IsAssignableFrom(t) &&
                !t.IsAbstract &&
                (t.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase) ||
                 t.FullName?.EndsWith(typeName, StringComparison.OrdinalIgnoreCase) == true));

        if (type == null)
            return null;

        try
        {
            return Activator.CreateInstance(type, args) as T;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Gets all creatable types assignable to T.
    /// </summary>
    /// <typeparam name="T">The base type/interface.</typeparam>
    /// <returns>List of type names.</returns>
    public static List<string> ListAvailableTypes<T>()
    {
        return [.. AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t => t.Name)
            .OrderBy(n => n, StringComparer.Ordinal)];
    }
}
