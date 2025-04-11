namespace SimpleGameLibrary.Interfaces;
/// <summary>
/// Represents an object that can be looted by a creature.
/// </summary>
public interface ILootable
{
    /// <summary>
    /// Method to be called when the object is looted by a creature.
    /// </summary>
    /// <param name="looter">The creature that loots the object.</param>
    public void LootedBy(ICreature looter);
}
