using SimpleGameLibrary.Config;
using SimpleGameLibrary.Core;
using SimpleGameLibrary.Logging;
using SimpleGameLibrary.Utils;
using SimpleGameLibrary.Interfaces;
using SimpleGameDemo.Helpers;
using SimpleGameLibrary.Items;
using SimpleGameLibrary.Items.Composites;

Console.ForegroundColor = ConsoleColor.Red;
Console.Title = "SimpleGame Demo";
Console.WriteLine("=== SimpleGameFramework Demo ===");
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;

// Load config and initialize logging
var config = ConfigLoaderXML.Load();
GameLogger.Init(config.Logging.LogFilePath, Enum.Parse<LogLevel>(config.Logging.MinimumLevel, true));

// Log the game configuration
GameLogger.Info("-- The game is afoot --");
GameLogger.Info("Game Configuration Loaded:");
GameLogger.Info($"Game Level: {config.GameLevel}");
GameLogger.Info($"Logging Level: {config.Logging.MinimumLevel}");
GameLogger.Info($"Log File Path: {config.Logging.LogFilePath}");
GameLogger.Info($"World Size: {config.World.Width} x {config.World.Height}");

// Create the world
var world = new World(config.World.Width, config.World.Height);

// Create creatures
var knight = GameFactory.Create<ICreature>("Knight", new Position(1, 1)); // Factory pattern applied
var goblin = GameFactory.Create<ICreature>("Goblin", new Position(2, 1));

if (knight is null || goblin is null)
{
    GameLogger.Error("Failed to create creatures via GameFactory.");
    return;
}

// Create items
var sword = GameFactory.Create<IAttackItem>("BasicSword");
var shield = GameFactory.Create<IDefenseItem>("BasicShield");
var basicDagger = GameFactory.Create<IAttackItem>("BasicDagger");
var bash = GameFactory.Create<IAttackItem>("BasicBash");
var swordAndBash = new AttackItemComposite();
swordAndBash.Add(sword!); // Composite pattern applied
swordAndBash.Add(bash!); // Composite pattern applied
var dagger = new BoostedAttackItem(basicDagger!); // Decorator pattern applied

// Equip creatures
knight.Attacks.Add(sword!);
knight.Defenses.Add(shield!);
goblin.Attacks.Add(dagger!);

// Add creatures to world
world.AddCreature(knight);
world.AddCreature(goblin);

// Set strategy for goblin
goblin.AttackStrategy = null;
knight.AttackStrategy = null;

// Simulate a turn
Console.WriteLine("\n-- Battle Begins --\n");
knight.Hit(goblin);
if (goblin.IsAlive) goblin.Hit(knight);
if (knight.IsAlive) knight.Attacks.Add(swordAndBash!);
if (knight.IsAlive) knight.Hit(goblin);
if (goblin.IsAlive) goblin.Hit(knight);

// Final status
Console.WriteLine("\n-- Final Status --");
Console.WriteLine($"{knight.Name}: {knight.HitPoint} HP");
Console.WriteLine($"{goblin.Name}: {goblin.HitPoint} HP");

LogHelper.OpenLogFile();
Console.WriteLine("Log file opened. Check game_log.txt for details.");
Console.ReadLine();
