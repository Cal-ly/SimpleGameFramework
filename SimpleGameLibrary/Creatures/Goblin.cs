using SimpleGameLibrary.Attributes;
using SimpleGameLibrary.Core;

namespace SimpleGameLibrary.Creatures;

/// <summary>
/// A small, but nimble enemy creature.
/// </summary>
[Creatable]
public class Goblin(Position position) : TemplateCreature("Goblin", 50, position)
{
}