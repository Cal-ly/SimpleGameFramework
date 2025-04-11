using SimpleGameLibrary.Attributes;
using SimpleGameLibrary.Core;

namespace SimpleGameLibrary.Creatures;

/// <summary>
/// A strong warrior with high hit points.
/// </summary>
[Creatable]
public class Knight(Position position) : TemplateCreature("Knight", 150, position)
{
}