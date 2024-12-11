using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Dragon : Enemy
    {
        public Dragon(string type, int hitPoints, int attackPower)
            : base(type, hitPoints, attackPower)
        {
        }
    }
}
