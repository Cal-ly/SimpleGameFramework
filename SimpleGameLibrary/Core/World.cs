using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Core;
/// <summary>
/// Represents the game world.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="World"/> class with the specified width and height.
/// </remarks>
/// <param name="width">The width of the world.</param>
/// <param name="height">The height of the world.</param>
public class World(int width, int height)
{
    /// <summary>
    /// Gets or sets the width of the world.
    /// </summary>
    public int Width { get; set; } = width;

    /// <summary>
    /// Gets or sets the height of the world.
    /// </summary>
    public int Height { get; set; } = height;

    /// <summary>
    /// Gets or sets the list of creatures in the world.
    /// </summary>
    public List<ICreature> Creatures { get; set; } = [];

    /// <summary>
    /// Gets or sets the list of world objects in the world.
    /// </summary>
    public List<IWorldObject> WorldObjects { get; set; } = [];

    /// <summary>
    /// Gets or sets the list of positions in the world.
    /// </summary>
    public List<Position> Positions { get; set; } = [];

    /// <summary>
    /// Adds a creature to the world.
    /// </summary>
    /// <param name="creature">The creature to add.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the creature's position is out of bounds.</exception>
    public void AddCreature(ICreature creature)
    {
        if (creature.Position.PosX < Width && creature.Position.PosY < Height)
        {
            Creatures.Add(creature);
            GameLogger.Info($"Creature '{creature.Name}' added at {creature.Position.PosX},{creature.Position.PosY}.");
        }
        else
        {
            GameLogger.Error($"Creature '{creature.Name}' position out of bounds.");
            throw new ArgumentOutOfRangeException(nameof(creature), "Creature position is out of bounds.");
        }
    }

    /// <summary>
    /// Removes a creature from the world.
    /// </summary>
    /// <param name="creature">The creature to remove.</param>
    public void RemoveCreature(ICreature creature)
    {
        if (Creatures.Remove(creature))
        {
            GameLogger.Info($"Creature '{creature.Name}' removed from world.");
        }
        else
        {
            GameLogger.Warn($"Attempted to remove unknown creature '{creature.Name}'.");
        }
    }

    /// <summary>
    /// Adds a world object to the world.
    /// </summary>
    /// <param name="worldObject">The world object to add.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the world object's position is out of bounds.</exception>
    public void AddWorldObject(IWorldObject worldObject)
    {
        if (worldObject.Position.PosX < Width && worldObject.Position.PosY < Height)
        {
            WorldObjects.Add(worldObject);
            GameLogger.Info($"World object '{worldObject.Name}' added at {worldObject.Position.PosX},{worldObject.Position.PosY}.");
        }
        else
        {
            GameLogger.Error($"World object '{worldObject.Name}' position out of bounds.");
            throw new ArgumentOutOfRangeException(nameof(worldObject), "World object position is out of bounds.");
        }
    }
}
