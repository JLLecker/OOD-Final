using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Balrog : Enemy
    {
        public Balrog() : base("Balrog", 115) { }

        public override string GetDescription()
        {
            return "A large, fiery beast.";
        }
    }
}
