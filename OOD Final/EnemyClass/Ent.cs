using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public class Ent : Enemy
    {
        public Ent() : base("Ent", 80) { }

        public override string GetDescription()
        {
            return "A stout, sentient tree.";
        }
    }
}
