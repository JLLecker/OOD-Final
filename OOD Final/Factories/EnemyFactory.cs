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
        public static Enemy CreateRandomEnemy(Random random)
        {
            string[] enemyTypes = { "Balrog", "Dragon", "Ent", "Hellhound", "Kobold" };
            string enemyType = enemyTypes[random.Next(enemyTypes.Length)];

            switch (enemyType)
            {
                case "Balrog": return new Balrog();
                case "Dragon": return new Dragon();
                case "Ent": return new Ent();
                case "Hellhound": return new Hellhound();
                case "Kobold": return new Kobold();
                default: return null;
            };
        }
    }
}
