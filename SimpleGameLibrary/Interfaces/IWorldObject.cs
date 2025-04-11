using SimpleGameLibrary.Core;

namespace SimpleGameLibrary.Interfaces;

/// <summary>
/// Represents an object in the game world.
/// </summary>
public interface IWorldObject
{
    /// <summary>
    /// Gets or sets the name of the world object.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the world object is removable.
    /// </summary>
    public bool IsRemovable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the world object is visible.
    /// </summary>
    public bool IsVisible { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the world object is lootable.
    /// </summary>
    public bool IsLootable { get; set; }

    /// <summary>
    /// Gets or sets the position of the world object.
    /// </summary>
    public Position Position { get; set; }
}
