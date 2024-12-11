using System;
using System.Collections.Generic;
using OOD_Final.Actions;
using OOD_Final.Interfaces;

namespace OOD_Final.Factories
{
    public class CharacterFactory
    {
        // Dictionary to store character configurations
        private static readonly Dictionary<string, (int HitPoints, int AttackPower, List<IAction> Actions)> characterConfigs =
            new Dictionary<string, (int, int, List<IAction>)>
            {
                {
                    "warrior",
                    (250, 40, new List<IAction> { new MeleeAttack(), new ShieldAttack() })
                },
                {
                    "mage",
                    (200, 45, new List<IAction> { new SpellAttack(), new SneakAttack() })
                },
                {
                    "thief",
                    (220, 50, new List<IAction> { new SneakAttack(), new MeleeAttack() })
                },
                {
                    "archer",
                    (210, 30, new List<IAction> { new RangedAttack(), new SneakAttack() })
                },
                {
                    "knight",
                    (400, 20, new List<IAction> { new ShieldAttack(), new MeleeAttack() })
                }
            };

        public static (Character, ActionContext) CreateCharacter(string type, string name)
        {
            // Convert type to lowercase for consistency
            type = type.ToLower();

            // Check if the character type exists
            if (!characterConfigs.TryGetValue(type, out var config))
            {
                throw new ArgumentException($"Invalid character class: '{type}'. Valid options are Warrior, Mage, Archer, Thief, Knight.");
            }

            // Create a new character using the configuration
            var character = new Character(name, type, config.HitPoints, config.AttackPower, config.Actions);
            return (character, character.ActionContext);
        }
    }
}
