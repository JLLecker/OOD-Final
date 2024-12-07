using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Kobold : Enemy
    {
        public Kobold() : base("Kobold", 23) { }

        public override string GetDescription()
        {
            return "A mischievous little creature, quick and nimble.";
        }
    }
}
