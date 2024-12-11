using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.EnemyClass;

namespace OOD_Final.Factories
{
    public class EnemyFactory
    {

        public static Enemy CreateRandomEnemy()
        {
            var random = new Random();
            var enemyArray = new[] { "balrog", "dragon", "ent", "hellhound", "kobold" };
            var randomEnemy = enemyArray[random.Next(enemyArray.Length)];
            switch (randomEnemy.ToLower())
            {
                case "balrog":
                    return new Balrog("Balrog", 300, 50);
                case "dragon":
                    return new Dragon("Dragon", 400, 60);
                case "ent":
                    return new Ent("Ent", 250, 30);
                case "hellhound":
                    return new Hellhound("Hellhound", 200, 40);
                case "kobold":
                    return new Kobold("Kobold", 100, 15);
                default:
                    throw new ArgumentException($"Unknown enemy type: {randomEnemy}");
            }
        }
    }
}
