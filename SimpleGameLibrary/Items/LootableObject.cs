using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Core;

namespace SimpleGameLibrary.Items;

/// <summary>
/// Represents a basic lootable object in the game.
/// </summary>
public class LootableObject : ILootable, IWorldObject
{
    /// <summary>
    /// Gets or sets the name of the lootable object.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the object is removable.
    /// </summary>
    public bool IsRemovable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the object is visible.
    /// </summary>
    public bool IsVisible { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the object is lootable.
    /// </summary>
    public bool IsLootable { get; set; } = true;

    /// <summary>
    /// Gets or sets the position of the lootable object.
    /// </summary>
    public required Position Position { get; set; }

    /// <summary>
    /// Method to be called when the object is looted by a creature.
    /// </summary>
    /// <param name="looter">The creature that loots the object.</param>
    public void LootedBy(ICreature looter)
    {
        if (IsLootable)
        {
            // Example logic: Print a message and make the object non-lootable
            Console.WriteLine($"{looter.Name} looted {Name} at position ({Position.PosX}, {Position.PosY}).");
            IsLootable = false;
            IsVisible = false; // Optionally hide the object after looting
        }
        else
        {
            Console.WriteLine($"{Name} is no longer lootable.");
        }
    }
}
