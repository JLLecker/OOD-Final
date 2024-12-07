using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.CharClass;

namespace OOD_Final.Factories
{
    public class CharacterFactory
    {
        public static Character CreateCharacter(string type, string name)
        {
            switch (type.ToLower())
            {
                case "warrior":
                    return new Warrior(name);
                case "mage":
                    return new Mage(name);
                case "thief":
                    return new Thief(name);
                case "archer":
                    return new Archer(name);
                case "knight":
                    return new Knight(name);
                default:
                    Console.WriteLine("Please choose Warrior, Mage, Thief, Archer or Knight.");
                    return null;
            };
        }
    }
}
