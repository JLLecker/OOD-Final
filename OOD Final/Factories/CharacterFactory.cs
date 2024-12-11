using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Actions;
using OOD_Final.CharClass;
using OOD_Final.Interfaces;

namespace OOD_Final.Factories
{
    public class CharacterFactory
    {
        public static (Character, ActionContext) CreateCharacter(string type, string name)
        {
            Character character;

            switch (type.ToLower())
            {
                case "warrior":
                    character = new Warrior(name, "Warrior", 250, 40, new MeleeAttack(), new ShieldAttack());
                    break;
                case "mage":
                    character = new Mage(name, "Mage", 200, 45, new SpellAttack(), new SneakAttack());
                    break;
                case "thief":
                    character = new Thief(name, "Thief", 220, 50, new SneakAttack(), new MeleeAttack());
                    break;
                case "archer":
                    character = new Archer(name, "Archer", 210, 30, new RangedAttack(), new SneakAttack());
                    break;
                case "knight":
                    character = new Knight(name, "Knight", 400, 20, new ShieldAttack(), new MeleeAttack());
                    break;
                default:
                    throw new ArgumentException($"Invalid character class: '{type}'. Valid options are Mage, Warrior, Archer, Thief, Knight.");
            };

            return (character, character.ActionContext);
        }
    }
}
