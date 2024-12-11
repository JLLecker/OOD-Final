using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Kobold : Enemy
    {
        public Kobold(string type, int hitPoints, int attackPower)
            : base(type, hitPoints, attackPower)
        {
        }
    }
}
