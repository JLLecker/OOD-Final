using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Dragon : Enemy
    {
        public Dragon() : base("Dragon", 120) { }

        public override string GetDescription()
        {
            return "A formidable foe.";
        }
    }
}
