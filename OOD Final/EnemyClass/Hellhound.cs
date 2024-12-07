using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Hellhound : Enemy
    {
        public Hellhound() : base("Hellhound", 35) { }

        public override string GetDescription()
        {
            return "A slight, nimble canine.";
        }
    }
}
